using Microsoft.EntityFrameworkCore;
using DuAnBanGiay.DataContext;
using DuAnBanGiay.Models;

namespace DuAnBanGiay.GUI;

public class UCChiTietSanPham : UserControl
{
    // Màu sắc đồng bộ Dashboard
    private static readonly Color PrimaryNavy = Color.FromArgb(28, 59, 97);
    private static readonly Color LabelClr = Color.FromArgb(64, 64, 64);

    // Controls bộ lọc
    private TextBox txtTimKiem = null!;
    private ComboBox cboLocThuongHieu = null!;
    private ComboBox cboLocTheLoai = null!;
    private ComboBox cboLocMau = null!;
    private ComboBox cboLocSize = null!;

    // DataGridView chính
    private DataGridView dgvChiTietSP = null!;

    public UCChiTietSanPham()
    {
        Dock = DockStyle.Fill;
        BackColor = Color.FromArgb(240, 243, 246);
        Padding = new Padding(10);

        InitializeUI();
        LoadFilterData();
        LoadChiTietSPData();
    }

    // ═══════════════════════════════════════════════════════════════
    //  LOAD DỮ LIỆU BỘ LỌC
    // ═══════════════════════════════════════════════════════════════
    private void LoadFilterData()
    {
        try
        {
            using var ctx = new QlBanGiayFinalContext();

            cboLocThuongHieu.Items.Clear();
            cboLocThuongHieu.Items.Add("-- Tất cả --");
            foreach (var th in ctx.ThuongHieus.OrderBy(t => t.TenThuongHieu).ToList())
                cboLocThuongHieu.Items.Add(th);
            cboLocThuongHieu.DisplayMember = "TenThuongHieu";
            cboLocThuongHieu.SelectedIndex = 0;

            cboLocTheLoai.Items.Clear();
            cboLocTheLoai.Items.Add("-- Tất cả --");
            foreach (var tl in ctx.TheLoais.OrderBy(t => t.TenTheLoai).ToList())
                cboLocTheLoai.Items.Add(tl);
            cboLocTheLoai.DisplayMember = "TenTheLoai";
            cboLocTheLoai.SelectedIndex = 0;

            cboLocMau.Items.Clear();
            cboLocMau.Items.Add("-- Tất cả --");
            foreach (var m in ctx.Maus.OrderBy(m => m.TenMau).ToList())
                cboLocMau.Items.Add(m);
            cboLocMau.DisplayMember = "TenMau";
            cboLocMau.SelectedIndex = 0;

            cboLocSize.Items.Clear();
            cboLocSize.Items.Add("-- Tất cả --");
            foreach (var s in ctx.KichThuocs.OrderBy(s => s.SoSize).ToList())
                cboLocSize.Items.Add(s);
            cboLocSize.DisplayMember = "SoSize";
            cboLocSize.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi LoadFilterData: " + ex.Message);
        }
    }

    // ═══════════════════════════════════════════════════════════════
    //  LOAD DỮ LIỆU CHI TIẾT SẢN PHẨM
    // ═══════════════════════════════════════════════════════════════
    private void LoadChiTietSPData()
    {
        try
        {
            using var ctx = new QlBanGiayFinalContext();

            IQueryable<ChiTietSanPham> query = ctx.ChiTietSanPhams
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.MaThuongHieuNavigation)
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.MaTheLoaiNavigation)
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.NhaCungCapNavigation)
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.ChatLieuNavigation)
                .Include(ct => ct.MaMauNavigation)
                .Include(ct => ct.MaKichThuocNavigation);

            // Lọc theo tên sản phẩm
            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(ct => ct.MaSanPhamNavigation.TenSp.Contains(keyword));

            // Lọc theo thương hiệu
            if (cboLocThuongHieu.SelectedIndex > 0 && cboLocThuongHieu.SelectedItem is ThuongHieu th)
                query = query.Where(ct => ct.MaSanPhamNavigation.MaThuongHieu == th.MaThuongHieu);

            // Lọc theo thể loại
            if (cboLocTheLoai.SelectedIndex > 0 && cboLocTheLoai.SelectedItem is TheLoai tl)
                query = query.Where(ct => ct.MaSanPhamNavigation.MaTheLoai == tl.MaTheLoai);

            // Lọc theo màu
            if (cboLocMau.SelectedIndex > 0 && cboLocMau.SelectedItem is Mau mau)
                query = query.Where(ct => ct.MaMau == mau.MaMau);

            // Lọc theo size
            if (cboLocSize.SelectedIndex > 0 && cboLocSize.SelectedItem is KichThuoc size)
                query = query.Where(ct => ct.MaKichThuoc == size.MaKichThuoc);

            var list = query.OrderBy(ct => ct.MaCtsp).ToList();

            dgvChiTietSP.Rows.Clear();
            int stt = 1;
            foreach (var ct in list)
            {
                var sp = ct.MaSanPhamNavigation;
                string trangThai = ct.TrangThai == 1 ? "Đang bán" : "Ngưng bán";

                dgvChiTietSP.Rows.Add(
                    stt++,
                    ct.MaCtsp,
                    sp?.TenSp ?? "",
                    sp?.MaThuongHieuNavigation?.TenThuongHieu ?? "",
                    sp?.MaTheLoaiNavigation?.TenTheLoai ?? "",
                    sp?.NhaCungCapNavigation?.TenNcc ?? "",
                    sp?.ChatLieuNavigation?.TenChatLieu ?? "",
                    ct.MaMauNavigation?.TenMau ?? "",
                    ct.MaKichThuocNavigation?.SoSize.ToString() ?? "",
               
                    ct.GiaBan.ToString("N0") + " đ",
                    ct.SoLuongTon,
                    trangThai
                );
                dgvChiTietSP.Rows[dgvChiTietSP.Rows.Count - 1].Tag = ct.MaCtsp;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi LoadChiTietSPData: " + ex.Message);
        }
    }

    // ═══════════════════════════════════════════════════════════════
    //  THIẾT KẾ GIAO DIỆN
    // ═══════════════════════════════════════════════════════════════
    private void InitializeUI()
    {
        var mainLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
        mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        Controls.Add(mainLayout);

        // ── 1. Bộ lọc / Tìm kiếm ──────────────────────────────
        var gbFilter = CreateGroup("Tìm kiếm & Bộ lọc", 0);
        gbFilter.Dock = DockStyle.Fill;
        mainLayout.Controls.Add(gbFilter, 0, 0);

        gbFilter.Controls.Add(new Label { Text = "Tìm kiếm:", Location = new Point(15, 28), AutoSize = true, ForeColor = LabelClr });
        txtTimKiem = new TextBox { Location = new Point(85, 25), Width = 200, PlaceholderText = "Nhập tên sản phẩm..." };
        gbFilter.Controls.Add(txtTimKiem);

        gbFilter.Controls.Add(new Label { Text = "Thương hiệu:", Location = new Point(300, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocThuongHieu = new ComboBox { Location = new Point(390, 25), Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocThuongHieu);

        gbFilter.Controls.Add(new Label { Text = "Thể loại:", Location = new Point(535, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocTheLoai = new ComboBox { Location = new Point(600, 25), Width = 120, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocTheLoai);

        gbFilter.Controls.Add(new Label { Text = "Màu:", Location = new Point(735, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocMau = new ComboBox { Location = new Point(775, 25), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocMau);

        gbFilter.Controls.Add(new Label { Text = "Size:", Location = new Point(890, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocSize = new ComboBox { Location = new Point(930, 25), Width = 70, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocSize);

        var btnTimKiem = CreateButton("Tìm kiếm", 1020, 23, 90, 28, PrimaryNavy);
        btnTimKiem.Click += (s, e) => LoadChiTietSPData();
        gbFilter.Controls.Add(btnTimKiem);

        var btnLamMoi = CreateButton("Làm mới", 1120, 23, 90, 28, Color.FromArgb(92, 184, 92));
        btnLamMoi.Click += (s, e) =>
        {
            txtTimKiem.Clear();
            cboLocThuongHieu.SelectedIndex = 0;
            cboLocTheLoai.SelectedIndex = 0;
            cboLocMau.SelectedIndex = 0;
            cboLocSize.SelectedIndex = 0;
            LoadChiTietSPData();
        };
        gbFilter.Controls.Add(btnLamMoi);

        // Buttons CRUD
        var btnThem = CreateButton("Thêm mới", 15, 65, 100, 30, Color.FromArgb(0, 123, 255));
        btnThem.Click += BtnThem_Click;
        gbFilter.Controls.Add(btnThem);

        var btnSua = CreateButton("Sửa", 125, 65, 80, 30, Color.FromArgb(255, 193, 7));
        btnSua.ForeColor = Color.Black;
        btnSua.Click += BtnSua_Click;
        gbFilter.Controls.Add(btnSua);

        var btnXoa = CreateButton("Xóa", 215, 65, 80, 30, Color.FromArgb(220, 53, 69));
        btnXoa.Click += BtnXoa_Click;
        gbFilter.Controls.Add(btnXoa);

        // ── 2. DataGridView Chi tiết sản phẩm ──────────────────
        var gbData = CreateGroup("Danh sách chi tiết sản phẩm", 0);
        gbData.Dock = DockStyle.Fill;
        mainLayout.Controls.Add(gbData, 0, 1);

        dgvChiTietSP = CreateDGV();
        dgvChiTietSP.Dock = DockStyle.Fill;
        dgvChiTietSP.ReadOnly = true;
        dgvChiTietSP.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText = "STT", Name = "STT", Width = 50 },
            new DataGridViewTextBoxColumn { HeaderText = "Mã CTSP", Name = "MaCTSP", Width = 70 },
            new DataGridViewTextBoxColumn { HeaderText = "Tên SP", Name = "TenSP", Width = 160 },
            new DataGridViewTextBoxColumn { HeaderText = "Thương hiệu", Name = "ThuongHieu", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Thể loại", Name = "TheLoai", Width = 90 },
            new DataGridViewTextBoxColumn { HeaderText = "NCC", Name = "NCC", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Chất liệu", Name = "ChatLieu", Width = 80 },
            new DataGridViewTextBoxColumn { HeaderText = "Màu", Name = "Mau", Width = 70 },
            new DataGridViewTextBoxColumn { HeaderText = "Size", Name = "SizeCol", Width = 50 },
            new DataGridViewTextBoxColumn { HeaderText = "Giá nhập", Name = "GiaNhap", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Giá bán", Name = "GiaBan", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Tồn kho", Name = "SoLuongTon", Width = 70 },
            new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", Name = "TrangThaiCol", Width = 90 }
        );
        gbData.Controls.Add(dgvChiTietSP);
    }

    // ═══════════════════════════════════════════════════════════════
    //  XỬ LÝ SỰ KIỆN CRUD
    // ═══════════════════════════════════════════════════════════════
    private void BtnThem_Click(object? sender, EventArgs e)
    {
        var dlg = new ChiTietSanPhamDialog();
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            LoadChiTietSPData();
        }
    }

    private void BtnSua_Click(object? sender, EventArgs e)
    {
        if (dgvChiTietSP.CurrentRow == null || dgvChiTietSP.CurrentRow.Tag is not int maCtsp)
        {
            MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var dlg = new ChiTietSanPhamDialog(maCtsp);
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            LoadChiTietSPData();
        }
    }

    private void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (dgvChiTietSP.CurrentRow == null || dgvChiTietSP.CurrentRow.Tag is not int maCtsp)
        {
            MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa chi tiết sản phẩm này?\n(Thao tác này sẽ chuyển trạng thái thành \"Ngưng bán\")",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                using var ctx = new QlBanGiayFinalContext();
                var ct = ctx.ChiTietSanPhams.Find(maCtsp);
                if (ct != null)
                {
                    ct.TrangThai = 0;
                    ctx.SaveChanges();
                    MessageBox.Show("Đã chuyển trạng thái thành \"Ngưng bán\"!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChiTietSPData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // ── Helper UI Methods ──────────────────────────────────────────
    private GroupBox CreateGroup(string title, int height) => new GroupBox { Text = title, Height = height, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Padding = new Padding(10), BackColor = Color.White };

    private DataGridView CreateDGV()
    {
        var d = new DataGridView
        {
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            GridColor = Color.LightGray,
            RowHeadersVisible = false,
            AllowUserToAddRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            EnableHeadersVisualStyles = false,
            Font = new Font("Segoe UI", 9F),
        };
        d.ColumnHeadersDefaultCellStyle.BackColor = PrimaryNavy;
        d.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        d.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        d.ColumnHeadersHeight = 30;
        d.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
