using System.Data;
using System.Drawing.Drawing2D;
using Microsoft.Data.SqlClient;

namespace WinFormsDashboard;

public class HoaDonPage : Panel
{
    // Màu sắc đồng bộ Dashboard
    private static readonly Color PrimaryNavy = Color.FromArgb(28, 59, 97);
    private static readonly Color LabelClr    = Color.FromArgb(64, 64, 64);

    // Database Helper
    private readonly DatabaseHelper db = new DatabaseHelper();

    // Controls chính
    private ComboBox cboKhachHang = null!;
    private ComboBox cboVoucher = null!;
    private DataGridView dgvSanPham = null!;
    private DataGridView dgvHoaDonChiTiet = null!;
    private TextBox txtMaHD = null!;
    private TextBox txtTongTien = null!;
    private DateTimePicker dtpNgayLap = null!;
    private Label lblVoucherInfo = null!;

    public HoaDonPage()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.FromArgb(240, 243, 246);
        Padding = new Padding(10);
        
        InitializeUI();
        LoadData();
        
        // Đăng ký sự kiện tính toán
        dgvHoaDonChiTiet.CellValueChanged += (s, e) => CalculateTotal();
        dgvHoaDonChiTiet.RowsRemoved      += (s, e) => CalculateTotal();
        cboVoucher.SelectedIndexChanged   += (s, e) => CalculateTotal();
    }

    // ═══════════════════════════════════════════════════════════════
    //  LOAD DỮ LIỆU TỪ SQL SERVER
    // ═══════════════════════════════════════════════════════════════
    private void LoadData()
    {
        try {
            // 1. Load Khách hàng
            DataTable dtKH = db.GetData("SELECT * FROM KhachHang");
            if (dtKH.Rows.Count > 0) {
                cboKhachHang.DataSource = dtKH;
                cboKhachHang.ValueMember = dtKH.Columns[0].ColumnName; 
                cboKhachHang.DisplayMember = dtKH.Columns.Count > 1 ? dtKH.Columns[1].ColumnName : dtKH.Columns[0].ColumnName;
            }

            // 2. Load Voucher
            DataTable dtVoucher = db.GetData("SELECT * FROM Voucher");
            string colMaVC = dtVoucher.Columns[0].ColumnName;
            string colTenVC = dtVoucher.Columns.Count > 1 ? dtVoucher.Columns[1].ColumnName : colMaVC;
            string colGiam  = dtVoucher.Columns.Count > 2 ? dtVoucher.Columns[2].ColumnName : "";

            DataRow newRow = dtVoucher.NewRow();
            newRow[colMaVC] = DBNull.Value;
            newRow[colTenVC] = "-- Không áp dụng --";
            if (!string.IsNullOrEmpty(colGiam)) newRow[colGiam] = 0;
            dtVoucher.Rows.InsertAt(newRow, 0);
            
            cboVoucher.DataSource = dtVoucher;
            cboVoucher.ValueMember = colMaVC;
            cboVoucher.DisplayMember = colTenVC;

            // 3. Load Sản phẩm chi tiết (Dùng QUERY thông minh để tìm tên cột thực tế)
            // Tôi sẽ lấy danh sách cột của từng bảng để tự khớp nối
            DataTable colsCT = db.GetData("SELECT TOP 0 * FROM ChiTietSanPham");
            DataTable colsSP = db.GetData("SELECT TOP 0 * FROM SanPham");
            DataTable colsMau = db.GetData("SELECT TOP 0 * FROM Mau");
            DataTable colsSize = db.GetData("SELECT TOP 0 * FROM Size");

            // Tìm tên cột "Mã" của từng bảng (thường là cột đầu tiên)
            string pkSP = colsSP.Columns[0].ColumnName;
            string pkMau = colsMau.Columns[0].ColumnName;
            string pkSize = colsSize.Columns[0].ColumnName;

            // Xây dựng câu SQL dựa trên tên cột thực tế tìm được
            // Chúng ta giả định cột liên kết trong ChiTietSanPham có tên giống cột khóa chính ở bảng gốc
            string sqlSP = $@"
                SELECT ct.*, s.{colsSP.Columns[1].ColumnName} as TenSP, m.{colsMau.Columns[1].ColumnName} as Mau, sz.{colsSize.Columns[1].ColumnName} as Size 
                FROM ChiTietSanPham ct
                INNER JOIN SanPham s ON ct.{pkSP} = s.{pkSP}
                INNER JOIN Mau m ON ct.{pkMau} = m.{pkMau}
                INNER JOIN Size sz ON ct.{pkSize} = sz.{pkSize}";
            
            DataTable dtSP = db.GetData(sqlSP);
            dgvSanPham.DataSource = dtSP;

        } catch (Exception ex) {
            MessageBox.Show("Lỗi LoadData: " + ex.Message + "\n\nVui lòng kiểm tra lại tên các cột trong Database.");
        }
    }

    // ═══════════════════════════════════════════════════════════════
    //  XỬ LÝ NGHIỆP VỤ (HÀM BỔ TRỢ)
    // ═══════════════════════════════════════════════════════════════
    
    private void CalculateTotal()
    {
        decimal subTotal = 0;
        foreach (DataGridViewRow row in dgvHoaDonChiTiet.Rows)
        {
            if (row.Cells["SoLuong"].Value != null && row.Cells["DonGia"].Value != null)
            {
                int qty = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal price = Convert.ToDecimal(row.Cells["DonGia"].Value);
                decimal amount = qty * price;
                row.Cells["ThanhTien"].Value = amount;
                subTotal += amount;
            }
        }

        decimal discount = 0;
        if (cboVoucher.SelectedValue != DBNull.Value && cboVoucher.SelectedItem is DataRowView drv)
        {
            discount = Convert.ToDecimal(drv["SoTienGiam"]);
        }

        decimal finalTotal = subTotal - discount;
        if (finalTotal < 0) finalTotal = 0;

        lblVoucherInfo.Text = $"Giảm giá: {discount:N0} đ";
        txtTongTien.Text = finalTotal.ToString("N0") + " đ";
        txtTongTien.Tag = finalTotal; // Lưu giá trị số để lưu DB
    }

    private void AddToCart(string maCTSP, string tenSP, decimal giaBan)
    {
        // Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
        foreach (DataGridViewRow row in dgvHoaDonChiTiet.Rows)
        {
            if (row.Cells["MaCTSP_Cart"].Value?.ToString() == maCTSP)
            {
                row.Cells["SoLuong"].Value = Convert.ToInt32(row.Cells["SoLuong"].Value) + 1;
                CalculateTotal();
                return;
            }
        }

        // Nếu chưa có, thêm mới
        dgvHoaDonChiTiet.Rows.Add(maCTSP, tenSP, 1, giaBan, giaBan);
        CalculateTotal();
    }

    // ═══════════════════════════════════════════════════════════════
    //  THIẾT KẾ GIAO DIỆN
    // ═══════════════════════════════════════════════════════════════
    private void InitializeUI()
    {
        var mainSplit = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
        mainSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
        mainSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
        Controls.Add(mainSplit);

        var topSplit = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 1, ColumnCount = 2, Margin = new Padding(0) };
        topSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
        topSplit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        mainSplit.Controls.Add(topSplit, 0, 0);

        // 1. Phía trái: Nhập liệu
        var gbInfo = CreateGroup("Thông tin hóa đơn", 0);
        gbInfo.Dock = DockStyle.Fill;
        topSplit.Controls.Add(gbInfo, 0, 0);

        txtMaHD = AddInputField(gbInfo, "Số HĐ", 15, 30, 100, 220);
        txtMaHD.ReadOnly = true;
        txtMaHD.PlaceholderText = "(Tự động sinh)";
        
        cboKhachHang = AddComboField(gbInfo, "Khách hàng", 15, 65, 100, 220);
        cboVoucher   = AddComboField(gbInfo, "Voucher", 15, 100, 100, 220);
        
        gbInfo.Controls.Add(new Label { Text = "Ngày lập:", Location = new Point(15, 138), AutoSize = true });
        dtpNgayLap = new DateTimePicker { Location = new Point(100, 135), Width = 220, Format = DateTimePickerFormat.Short };
        gbInfo.Controls.Add(dtpNgayLap);

        lblVoucherInfo = new Label { Text = "Giảm giá: 0 đ", Location = new Point(100, 165), AutoSize = true, ForeColor = Color.DarkRed, Font = new Font("Segoe UI", 9F, FontStyle.Italic) };
        gbInfo.Controls.Add(lblVoucherInfo);

        // 2. Phía phải: Grid Sản phẩm
        var gbProducts = CreateGroup("Danh sách sản phẩm (Click chọn để thêm)", 0);
        gbProducts.Dock = DockStyle.Fill;
        topSplit.Controls.Add(gbProducts, 1, 0);

        dgvSanPham = CreateDGV();
        dgvSanPham.Dock = DockStyle.Fill;
        dgvSanPham.CellClick += (s, e) => {
            if (e.RowIndex >= 0) {
                var row = dgvSanPham.Rows[e.RowIndex];
                AddToCart(row.Cells["MaCTSP"].Value.ToString()!, row.Cells["TenSP"].Value.ToString()!, Convert.ToDecimal(row.Cells["GiaBan"].Value));
            }
        };
        gbProducts.Controls.Add(dgvSanPham);

        // 3. Phía dưới: Grid Giỏ hàng
        var bottomLayout = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 10, 0, 0) };
        mainSplit.Controls.Add(bottomLayout, 0, 1);

        var gbDetails = CreateGroup("Chi tiết hóa đơn (Giỏ hàng)", 0);
        gbDetails.Dock = DockStyle.Fill;
        bottomLayout.Controls.Add(gbDetails);

        dgvHoaDonChiTiet = CreateDGV();
        dgvHoaDonChiTiet.Dock = DockStyle.Fill;
        dgvHoaDonChiTiet.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "MaCTSP_Cart", HeaderText = "Mã CTSP", Width = 80, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "TenSP_Cart",  HeaderText = "Tên sản phẩm", Width = 200, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "SoLuong",     HeaderText = "Số lượng", Width = 80 },
            new DataGridViewTextBoxColumn { Name = "DonGia",      HeaderText = "Đơn giá", Width = 100, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "ThanhTien",   HeaderText = "Thành tiền", Width = 120, ReadOnly = true }
        );
        gbDetails.Controls.Add(dgvHoaDonChiTiet);

        // 4. Panel Button & Tổng tiền
        var pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 60, Padding = new Padding(0, 5, 0, 0) };
        gbDetails.Controls.Add(pnlBottom);
        dgvHoaDonChiTiet.BringToFront();

        txtTongTien = new TextBox { 
            Location = new Point(pnlBottom.Width - 250, 12), 
            Width = 230, 
            Height = 40, 
            Font = new Font("Segoe UI", 16F, FontStyle.Bold), 
            ForeColor = Color.DarkRed, 
            TextAlign = HorizontalAlignment.Right, 
            ReadOnly = true,
            Text = "0 đ",
            Anchor = AnchorStyles.Top | AnchorStyles.Right
        };
        pnlBottom.Controls.Add(txtTongTien);
        pnlBottom.Controls.Add(new Label { Text = "TỔNG TIỀN:", Location = new Point(txtTongTien.Left - 100, 22), AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Anchor = AnchorStyles.Top | AnchorStyles.Right });

        var btnThem = CreateButton("Thêm sản phẩm", 0, 10, 130, 38, Color.FromArgb(92, 184, 92));
        btnThem.Click += (s, e) => MessageBox.Show("Vui lòng click vào bảng sản phẩm phía trên để chọn!");
        pnlBottom.Controls.Add(btnThem);

        var btnXoa = CreateButton("Xóa sản phẩm", 140, 10, 130, 38, Color.FromArgb(217, 83, 79));
        btnXoa.Click += (s, e) => {
            if (dgvHoaDonChiTiet.CurrentRow != null) dgvHoaDonChiTiet.Rows.Remove(dgvHoaDonChiTiet.CurrentRow);
        };
        pnlBottom.Controls.Add(btnXoa);

        var btnThanhToan = CreateButton(" THANH TOÁN ", 280, 10, 160, 38, PrimaryNavy);
        btnThanhToan.Click += (s, e) => HandleCheckout();
        pnlBottom.Controls.Add(btnThanhToan);
    }

    // ═══════════════════════════════════════════════════════════════
    //  QUY TRÌNH THANH TOÁN (INSERT DB)
    // ═══════════════════════════════════════════════════════════════
    private void HandleCheckout()
    {
        if (dgvHoaDonChiTiet.Rows.Count == 0) {
            MessageBox.Show("Vui lòng thêm sản phẩm vào giỏ hàng!");
            return;
        }

        try {
            using (SqlConnection conn = new SqlConnection(@"Server=DESKTOP-4Q61549\SQLEXPRESS03;Database=QL_BanGiay_Final;Integrated Security=True;TrustServerCertificate=True;"))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try {
                        // 1. Lưu Hóa Đơn
                        string sqlHD = @"INSERT INTO HoaDon (MaKH, MaVoucher, NgayLap, TongTien, TrangThai) 
                                         VALUES (@makh, @mavoucher, @ngay, @tong, 1); 
                                         SELECT SCOPE_IDENTITY();";
                        
                        SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                        cmdHD.Parameters.AddWithValue("@makh",      cboKhachHang.SelectedValue);
                        cmdHD.Parameters.AddWithValue("@mavoucher", cboVoucher.SelectedValue ?? DBNull.Value);
                        cmdHD.Parameters.AddWithValue("@ngay",      dtpNgayLap.Value);
                        cmdHD.Parameters.AddWithValue("@tong",      txtTongTien.Tag ?? 0);

                        int newMaHD = Convert.ToInt32(cmdHD.ExecuteScalar());

                        // 2. Lưu Chi Tiết Hóa Đơn
                        foreach (DataGridViewRow row in dgvHoaDonChiTiet.Rows)
                        {
                            string sqlCT = @"INSERT INTO HoaDonChiTiet (MaHoaDon, MaCTSP, SoLuong, DonGia, ThanhTien) 
                                             VALUES (@mahd, @mactsp, @sl, @dg, @tt)";
                            SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                            cmdCT.Parameters.AddWithValue("@mahd",   newMaHD);
                            cmdCT.Parameters.AddWithValue("@mactsp", row.Cells["MaCTSP_Cart"].Value);
                            cmdCT.Parameters.AddWithValue("@sl",     row.Cells["SoLuong"].Value);
                            cmdCT.Parameters.AddWithValue("@dg",     row.Cells["DonGia"].Value);
                            cmdCT.Parameters.AddWithValue("@tt",     row.Cells["ThanhTien"].Value);
                            cmdCT.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show($"Thanh toán thành công! Mã hóa đơn: {newMaHD}", "Thông báo");
                        
                        // Reset form
                        dgvHoaDonChiTiet.Rows.Clear();
                        CalculateTotal();
                    } catch (Exception ex) {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        } catch (Exception ex) {
            MessageBox.Show("Lỗi thanh toán: " + ex.Message);
        }
    }

    // ── Helper UI Methods ──────────────────────────────────────────
    private GroupBox CreateGroup(string title, int height) => new GroupBox { Text = title, Height = height, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(10), BackColor = Color.White };

    private TextBox AddInputField(Control p, string l, int lx, int ly, int ix, int iw) {
        p.Controls.Add(new Label { Text = l + ":", Location = new Point(lx, ly + 3), AutoSize = true, Font = new Font("Segoe UI", 9F) });
        var t = new TextBox { Location = new Point(ix, ly), Width = iw };
        p.Controls.Add(t); return t;
    }

    private ComboBox AddComboField(Control p, string l, int lx, int ly, int ix, int iw) {
        p.Controls.Add(new Label { Text = l + ":", Location = new Point(lx, ly + 3), AutoSize = true, Font = new Font("Segoe UI", 9F) });
        var c = new ComboBox { Location = new Point(ix, ly), Width = iw, DropDownStyle = ComboBoxStyle.DropDownList };
        p.Controls.Add(c); return c;
    }

    private DataGridView CreateDGV() {
        var d = new DataGridView { BackgroundColor = Color.White, BorderStyle = BorderStyle.None, RowHeadersVisible = false, AllowUserToAddRows = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect, EnableHeadersVisualStyles = false, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
        d.ColumnHeadersDefaultCellStyle.BackColor = PrimaryNavy; d.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; d.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold); d.ColumnHeadersHeight = 35;
        d.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 255); d.DefaultCellStyle.SelectionForeColor = Color.Black; return d;
    }

    private Button CreateButton(string t, int x, int y, int w, int h, Color bg) => new Button { Text = t, Location = new Point(x, y), Size = new Size(w, h), BackColor = bg, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand };
}
