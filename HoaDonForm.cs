using Microsoft.EntityFrameworkCore;
using WinFormsDashboard.Data;
using WinFormsDashboard.Data.Models;
using Size = System.Drawing.Size;

namespace WinFormsDashboard;

public class HoaDonPage : Panel
{
    // Màu sắc đồng bộ Dashboard
    private static readonly Color PrimaryNavy = Color.FromArgb(28, 59, 97);
    private static readonly Color LabelClr    = Color.FromArgb(64, 64, 64);

    // Controls chính
    private ComboBox cboLocKhachHang = null!;
    private ComboBox cboLocTrangThai = null!;
    private DateTimePicker dtpTuNgay = null!;
    private DateTimePicker dtpDenNgay = null!;
    private DataGridView dgvHoaDon = null!;
    private DataGridView dgvHoaDonChiTiet = null!;
    private Label lblTongTien = null!;
    private Label lblSoHoaDon = null!;

    public HoaDonPage()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.FromArgb(240, 243, 246);
        Padding = new Padding(10);

        InitializeUI();
        LoadFilterData();
        LoadHoaDon();
    }

    // ═══════════════════════════════════════════════════════════════
    //  LOAD DỮ LIỆU TỪ EF Core
    // ═══════════════════════════════════════════════════════════════
    private void LoadFilterData()
    {
        try
        {
            using var ctx = new QlBanGiayFinalContext();

            // Load danh sách khách hàng cho bộ lọc
            var khachHangs = ctx.KhachHangs.OrderBy(k => k.TenKhachHang).ToList();
            cboLocKhachHang.Items.Clear();
            cboLocKhachHang.Items.Add("-- Tất cả --");
            foreach (var kh in khachHangs)
                cboLocKhachHang.Items.Add(kh);
            cboLocKhachHang.SelectedIndex = 0;
            cboLocKhachHang.DisplayMember = "TenKhachHang";

            // Trạng thái
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.Add("-- Tất cả --");
            cboLocTrangThai.Items.Add("Hóa đơn chờ");
            cboLocTrangThai.Items.Add("Đã thanh toán");
            cboLocTrangThai.Items.Add("Đã hủy");
            cboLocTrangThai.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi LoadFilterData: " + ex.Message);
        }
    }

    private void LoadHoaDon()
    {
        if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
        {
            MessageBox.Show(
                "\"Từ ngày\" không được lớn hơn \"Đến ngày\"!\nVui lòng chọn lại khoảng thời gian hợp lệ.",
                "Lỗi bộ lọc ngày",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            dtpTuNgay.Focus();
            return;
        }

        try
        {
            using var ctx = new QlBanGiayFinalContext();

            IQueryable<HoaDon> query = ctx.HoaDons
                .Include(h => h.MaKHNavigation)
                .Include(h => h.MaVoucherNavigation)
                .Include(h => h.HoaDonChiTiets);

            // Lọc theo ngày
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);
            query = query.Where(h => h.NgayLap >= tuNgay && h.NgayLap < denNgay);

            // Lọc theo khách hàng
            if (cboLocKhachHang.SelectedIndex > 0 && cboLocKhachHang.SelectedItem is KhachHang selectedKH)
            {
                query = query.Where(h => h.MaKH == selectedKH.MaKH);
            }

            // Lọc theo trạng thái
            if (cboLocTrangThai.SelectedIndex > 0)
            {
                int trangThai = cboLocTrangThai.SelectedIndex - 1;
                query = query.Where(h => h.TrangThai == trangThai);
            }

            var hoaDons = query.OrderByDescending(h => h.NgayLap).ToList();

            dgvHoaDon.Rows.Clear();
            int stt = 1;
            foreach (var hd in hoaDons)
            {
                string tenKH = hd.MaKHNavigation?.TenKhachHang ?? "(Khách lẻ)";
                string voucher = hd.MaVoucherNavigation?.MaCode ?? "(Không)";
                string trangThaiStr = hd.TrangThai switch
                {
                    0 => "Hóa đơn chờ",
                    1 => "Đã thanh toán",
                    2 => "Đã hủy",
                    _ => "Không rõ"
                };

                dgvHoaDon.Rows.Add(
                    stt++,
                    hd.MaHoaDon,
                    tenKH,
                    voucher,
                    hd.NgayLap?.ToString("dd/MM/yyyy HH:mm") ?? "",
                    hd.TongTien?.ToString("N0") + " đ",
                    trangThaiStr
                );
                dgvHoaDon.Rows[dgvHoaDon.Rows.Count - 1].Tag = hd.MaHoaDon;
            }

            // Cập nhật thống kê
            decimal tongTien = hoaDons
                .Where(h => h.TrangThai == 1)
                .Sum(h => h.TongTien ?? 0);
            lblTongTien.Text = $"Tổng tiền (đã thanh toán): {tongTien:N0} đ";
            lblSoHoaDon.Text = $"Số hóa đơn: {hoaDons.Count}";

            // Xóa chi tiết khi reload
            dgvHoaDonChiTiet.Rows.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi LoadHoaDon: " + ex.Message);
        }
    }

    private void LoadChiTietHoaDon(int maHoaDon)
    {
        try
        {
            using var ctx = new QlBanGiayFinalContext();
            var chiTiets = ctx.HoaDonChiTiets
                .Include(ct => ct.MaCTSPNavigation)
                    .ThenInclude(ctsp => ctsp!.MaSanPhamNavigation)
                .Include(ct => ct.MaCTSPNavigation)
                    .ThenInclude(ctsp => ctsp!.MaMauNavigation)
                .Include(ct => ct.MaCTSPNavigation)
                    .ThenInclude(ctsp => ctsp!.MaKichThuocNavigation)
                .Where(ct => ct.MaHoaDon == maHoaDon)
                .ToList();

            dgvHoaDonChiTiet.Rows.Clear();
            int stt = 1;
            foreach (var ct in chiTiets)
            {
                string tenSP = ct.MaCTSPNavigation?.MaSanPhamNavigation?.TenSP ?? "";
                string mau = ct.MaCTSPNavigation?.MaMauNavigation?.TenMau ?? "";
                string size = ct.MaCTSPNavigation?.MaKichThuocNavigation?.SoSize.ToString() ?? "";

                dgvHoaDonChiTiet.Rows.Add(
                    stt++,
                    ct.MaHDCT,
                    tenSP,
                    mau,
                    size,
                    ct.SoLuong,
                    ct.DonGia?.ToString("N0") + " đ",
                    ct.ThanhTien?.ToString("N0") + " đ"
                );
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi LoadChiTietHoaDon: " + ex.Message);
        }
    }

    // ═══════════════════════════════════════════════════════════════
    //  THIẾT KẾ GIAO DIỆN
    // ═══════════════════════════════════════════════════════════════
    private void InitializeUI()
    {
        var mainSplit = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1 };
        mainSplit.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
        mainSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        mainSplit.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        Controls.Add(mainSplit);

        // ── 1. Bộ lọc ──────────────────────────────────────────
        var gbFilter = CreateGroup("Bộ lọc hóa đơn", 0);
        gbFilter.Dock = DockStyle.Fill;
        mainSplit.Controls.Add(gbFilter, 0, 0);

        gbFilter.Controls.Add(new Label { Text = "Từ ngày:", Location = new Point(15, 28), AutoSize = true, Font = new Font("Segoe UI", 9F) });
        dtpTuNgay = new DateTimePicker { Location = new Point(80, 25), Width = 140, Format = DateTimePickerFormat.Short };
        dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
        dtpTuNgay.ValueChanged += (s, e) =>
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
                dtpDenNgay.Value = dtpTuNgay.Value;
        };
        gbFilter.Controls.Add(dtpTuNgay);

        gbFilter.Controls.Add(new Label { Text = "Đến ngày:", Location = new Point(235, 28), AutoSize = true, Font = new Font("Segoe UI", 9F) });
        dtpDenNgay = new DateTimePicker { Location = new Point(310, 25), Width = 140, Format = DateTimePickerFormat.Short };
        dtpDenNgay.ValueChanged += (s, e) =>
        {
            if (dtpDenNgay.Value.Date < dtpTuNgay.Value.Date)
                dtpTuNgay.Value = dtpDenNgay.Value;
        };
        gbFilter.Controls.Add(dtpDenNgay);

        gbFilter.Controls.Add(new Label { Text = "Khách hàng:", Location = new Point(470, 28), AutoSize = true, Font = new Font("Segoe UI", 9F) });
        cboLocKhachHang = new ComboBox { Location = new Point(555, 25), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocKhachHang);

        gbFilter.Controls.Add(new Label { Text = "Trạng thái:", Location = new Point(750, 28), AutoSize = true, Font = new Font("Segoe UI", 9F) });
        cboLocTrangThai = new ComboBox { Location = new Point(830, 25), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocTrangThai);

        var btnLoc = CreateButton("Lọc", 1000, 23, 80, 28, PrimaryNavy);
        btnLoc.Click += (s, e) => LoadHoaDon();
        gbFilter.Controls.Add(btnLoc);

        var btnLamMoi = CreateButton("Làm mới", 1090, 23, 80, 28, Color.FromArgb(92, 184, 92));
        btnLamMoi.Click += (s, e) =>
        {
            dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Today;
            cboLocKhachHang.SelectedIndex = 0;
            cboLocTrangThai.SelectedIndex = 0;
            LoadHoaDon();
        };
        gbFilter.Controls.Add(btnLamMoi);

        // Thống kê
        lblSoHoaDon = new Label { Text = "Số hóa đơn: 0", Location = new Point(15, 60), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = PrimaryNavy };
        gbFilter.Controls.Add(lblSoHoaDon);

        lblTongTien = new Label { Text = "Tổng tiền (đã thanh toán): 0 đ", Location = new Point(250, 60), AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.DarkRed };
        gbFilter.Controls.Add(lblTongTien);

        // ── 2. Danh sách hóa đơn ────────────────────────────────
        var gbHoaDon = CreateGroup("Danh sách hóa đơn (Click để xem chi tiết)", 0);
        gbHoaDon.Dock = DockStyle.Fill;
        mainSplit.Controls.Add(gbHoaDon, 0, 1);

        dgvHoaDon = CreateDGV();
        dgvHoaDon.Dock = DockStyle.Fill;
        dgvHoaDon.ReadOnly = true;
        dgvHoaDon.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "STT",        HeaderText = "STT",           Width = 50,  ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "MaHoaDon",   HeaderText = "Mã HĐ",        Width = 70,  ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "TenKH",      HeaderText = "Khách hàng",    Width = 180, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "MaVoucher",  HeaderText = "Voucher",       Width = 100, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "NgayLap",    HeaderText = "Ngày lập",      Width = 150, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "TongTien",   HeaderText = "Tổng tiền",     Width = 130, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "TrangThai",  HeaderText = "Trạng thái",    Width = 120, ReadOnly = true }
        );
        dgvHoaDon.CellClick += (s, e) =>
        {
            if (e.RowIndex >= 0 && dgvHoaDon.Rows[e.RowIndex].Tag is int maHD)
            {
                LoadChiTietHoaDon(maHD);
            }
        };
        gbHoaDon.Controls.Add(dgvHoaDon);

        // ── 3. Chi tiết hóa đơn ─────────────────────────────────
        var gbChiTiet = CreateGroup("Chi tiết hóa đơn", 0);
        gbChiTiet.Dock = DockStyle.Fill;
        mainSplit.Controls.Add(gbChiTiet, 0, 2);

        dgvHoaDonChiTiet = CreateDGV();
        dgvHoaDonChiTiet.Dock = DockStyle.Fill;
        dgvHoaDonChiTiet.ReadOnly = true;
        dgvHoaDonChiTiet.Columns.AddRange(
            new DataGridViewTextBoxColumn { Name = "STT",       HeaderText = "STT",           Width = 50,  ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "MaHDCT",    HeaderText = "Mã HDCT",       Width = 80,  ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "TenSP",     HeaderText = "Tên sản phẩm",  Width = 200, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "Mau",       HeaderText = "Màu",           Width = 80,  ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "SizeCol",   HeaderText = "Size",          Width = 60,  ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "SoLuong",   HeaderText = "Số lượng",      Width = 80,  ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "DonGia",    HeaderText = "Đơn giá",       Width = 120, ReadOnly = true },
            new DataGridViewTextBoxColumn { Name = "ThanhTien", HeaderText = "Thành tiền",    Width = 120, ReadOnly = true }
        );
        gbChiTiet.Controls.Add(dgvHoaDonChiTiet);
    }

    // ── Helper UI Methods ──────────────────────────────────────────
    private GroupBox CreateGroup(string title, int height) => new GroupBox { Text = title, Height = height, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(10), BackColor = Color.White };

    private DataGridView CreateDGV()
    {
        var d = new DataGridView
        {
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            EnableHeadersVisualStyles = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        d.ColumnHeadersDefaultCellStyle.BackColor = PrimaryNavy;
        d.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        d.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        d.ColumnHeadersHeight = 35;
        d.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 255);
        d.DefaultCellStyle.SelectionForeColor = Color.Black;
        return d;
    }

    private Button CreateButton(string t, int x, int y, int w, int h, Color bg) => new Button
    {
        Text = t,
        Location = new Point(x, y),
        Size = new Size(w, h),
        BackColor = bg,
        ForeColor = Color.White,
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 9F, FontStyle.Bold),
        Cursor = Cursors.Hand
    };
}
