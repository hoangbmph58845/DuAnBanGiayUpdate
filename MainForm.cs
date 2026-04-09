using System.Drawing.Drawing2D;
using Microsoft.EntityFrameworkCore;
using WinFormsDashboard.Data;
using WinFormsDashboard.Data.Models;
using Size = System.Drawing.Size;

namespace WinFormsDashboard;

public class MainForm : Form
{
    // ── Color Palette (Navy Blue/Gray phong cách chuyên nghiệp) ──
    private static readonly Color PrimaryNavy    = Color.FromArgb(28, 59, 97);
    private static readonly Color SidebarHover   = Color.FromArgb(43, 84, 126);
    private static readonly Color SidebarActive  = Color.FromArgb(0, 122, 204);
    private static readonly Color ContentBg      = Color.FromArgb(240, 243, 246);
    private static readonly Color HeaderTextClr  = Color.White;
    private static readonly Color LabelClr       = Color.FromArgb(64, 64, 64);
    private static readonly Color BorderClr      = Color.FromArgb(200, 200, 200);

    // ── Layout constants ──────────────────────────────────────────
    private const int SidebarWidth = 220;
    private const int HeaderHeight = 50;

    // ── Controls ──────────────────────────────────────────────────
    private Panel pnlSidebar   = null!;
    private Panel pnlHeader    = null!;
    private Panel pnlContent   = null!;
    private Label lblHeaderTitle = null!;

    private readonly List<SidebarMenuItem> _menuItems = new();
    private int _selectedIndex = 1; // Default to "Sản phẩm"

    // ── Menu definition (Giống trong ảnh) ─────────────────────────
    private static readonly string[] MenuNames =
    {
        "Hóa đơn",
        "Chi tiết sản phẩm",
        "Voucher - Khuyến mãi",
        "Khách hàng",
        "Tài khoản",
        "Thống kê"
    };

    public MainForm()
    {
        InitializeComponent();
        BuildSidebar();
        BuildHeader();
        BuildContentArea();
        SelectMenu(1); // Mặc định mở trang Chi tiết sản phẩm
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        Text            = "Hệ thống quản lý bán giày";
        StartPosition   = FormStartPosition.CenterScreen;
        MinimumSize     = new Size(1200, 800);
        Size            = new Size(1366, 850);
        BackColor       = ContentBg;
        Font            = new Font("Segoe UI", 9F, FontStyle.Regular);
        DoubleBuffered  = true;
        ResumeLayout(false);
    }

    // ═══════════════════════════════════════════════════════════════
    //  Sidebar & Navigation
    // ═══════════════════════════════════════════════════════════════
    private void BuildSidebar()
    {
        pnlSidebar = new Panel
        {
            Width     = SidebarWidth,
            Dock      = DockStyle.Left,
            BackColor = PrimaryNavy,
        };
        Controls.Add(pnlSidebar);

        // Logo/Top spacer
        var pnlSpacer = new Panel { Dock = DockStyle.Top, Height = 40 };
        pnlSidebar.Controls.Add(pnlSpacer);

        // Menu items
        for (int i = MenuNames.Length - 1; i >= 0; i--)
        {
            var item = new SidebarMenuItem(MenuNames[i], i)
            {
                Dock   = DockStyle.Top,
                Height = 45,
                Cursor = Cursors.Hand
            };
            int idx = i;
            item.Click += (_, _) => SelectMenu(idx);
            pnlSidebar.Controls.Add(item);
            _menuItems.Add(item);
        }
        _menuItems.Reverse();

        // Logout Button (Bottom)
        var btnLogout = new Button
        {
            Text            = "Đăng xuất",
            Dock            = DockStyle.Bottom,
            Height          = 40,
            FlatStyle       = FlatStyle.Flat,
            ForeColor       = Color.White,
            BackColor       = Color.FromArgb(40, 60, 85),
            Font            = new Font("Segoe UI", 9F, FontStyle.Bold),
            TextAlign       = ContentAlignment.MiddleLeft,
            Padding         = new Padding(15, 0, 0, 0)
        };
        btnLogout.FlatAppearance.BorderSize = 0;
        pnlSidebar.Controls.Add(btnLogout);
    }

    private void BuildHeader()
    {
        pnlHeader = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = HeaderHeight,
            BackColor = PrimaryNavy,
        };
        Controls.Add(pnlHeader);

        lblHeaderTitle = new Label
        {
            Text      = "Hệ thống quản lý bán giày",
            ForeColor = HeaderTextClr,
            Font      = new Font("Segoe UI", 16F, FontStyle.Bold),
            AutoSize  = true,
            Location  = new Point(15, 8)
        };
        pnlHeader.Controls.Add(lblHeaderTitle);
    }

    private void BuildContentArea()
    {
        pnlContent = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = ContentBg,
            Padding = new Padding(10)
        };
        Controls.Add(pnlContent);
        pnlContent.BringToFront();
    }

    private void SelectMenu(int index)
    {
        _selectedIndex = index;
        foreach (var m in _menuItems)
        {
            m.IsSelected = (m.Index == index);
            m.Invalidate();
        }

        if (index == 0)      LoadInvoicePage();
        else if (index == 1) LoadChiTietSanPhamPage();
        else LoadPlaceholder(MenuNames[index]);
    }

    private void LoadInvoicePage()
    {
        pnlContent.Controls.Clear();
        var page = new HoaDonPage();
        pnlContent.Controls.Add(page);
    }

    // ═══════════════════════════════════════════════════════════════
    //  Trang Chi Tiết Sản Phẩm (Dùng EF Core)
    // ═══════════════════════════════════════════════════════════════

    private TextBox txtTimKiem = null!;
    private ComboBox cboLocThuongHieu = null!;
    private ComboBox cboLocTheLoai = null!;
    private ComboBox cboLocMau = null!;
    private ComboBox cboLocSize = null!;
    private DataGridView dgvChiTietSP = null!;

    private void LoadChiTietSanPhamPage()
    {
        pnlContent.Controls.Clear();
        pnlContent.SuspendLayout();

        // ── 1. Bộ lọc / Tìm kiếm ──────────────────────────────
        var gbFilter = CreateGroup("Tìm kiếm & Bộ lọc", 90);
        gbFilter.Dock = DockStyle.Top;
        pnlContent.Controls.Add(gbFilter);

        gbFilter.Controls.Add(new Label { Text = "Tìm kiếm:", Location = new Point(15, 28), AutoSize = true, ForeColor = LabelClr });
        txtTimKiem = new TextBox { Location = new Point(85, 25), Width = 220, PlaceholderText = "Nhập tên sản phẩm..." };
        gbFilter.Controls.Add(txtTimKiem);

        gbFilter.Controls.Add(new Label { Text = "Thương hiệu:", Location = new Point(320, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocThuongHieu = new ComboBox { Location = new Point(405, 25), Width = 140, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocThuongHieu);

        gbFilter.Controls.Add(new Label { Text = "Thể loại:", Location = new Point(560, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocTheLoai = new ComboBox { Location = new Point(620, 25), Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocTheLoai);

        gbFilter.Controls.Add(new Label { Text = "Màu:", Location = new Point(765, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocMau = new ComboBox { Location = new Point(800, 25), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocMau);

        gbFilter.Controls.Add(new Label { Text = "Size:", Location = new Point(915, 28), AutoSize = true, ForeColor = LabelClr });
        cboLocSize = new ComboBox { Location = new Point(950, 25), Width = 80, DropDownStyle = ComboBoxStyle.DropDownList };
        gbFilter.Controls.Add(cboLocSize);

        var btnTimKiem = new Button { Text = "Tìm kiếm", Location = new Point(1050, 23), Width = 90, Height = 28, BackColor = PrimaryNavy, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand };
        btnTimKiem.Click += (s, e) => LoadChiTietSPData();
        gbFilter.Controls.Add(btnTimKiem);

        var btnLamMoi = new Button { Text = "Làm mới", Location = new Point(1050, 55), Width = 90, Height = 28, BackColor = Color.FromArgb(92, 184, 92), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand };
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

        gbFilter.BringToFront();

        // ── 1.5. Toolbar CRUD ─────────────────────────────────
        var pnlToolbar = new Panel { Dock = DockStyle.Top, Height = 45, BackColor = ContentBg };

        var btnThemMoi = new Button { Text = "Thêm mới", Location = new Point(5, 8), Width = 100, Height = 30, BackColor = Color.FromArgb(0, 150, 136), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand };
        btnThemMoi.FlatAppearance.BorderSize = 0;
        btnThemMoi.Click += BtnThemMoi_Click;
        pnlToolbar.Controls.Add(btnThemMoi);

        var btnSua = new Button { Text = "Sửa", Location = new Point(115, 8), Width = 80, Height = 30, BackColor = Color.FromArgb(33, 150, 243), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand };
        btnSua.FlatAppearance.BorderSize = 0;
        btnSua.Click += BtnSua_Click;
        pnlToolbar.Controls.Add(btnSua);

        var btnXoa = new Button { Text = "Xóa", Location = new Point(205, 8), Width = 80, Height = 30, BackColor = Color.FromArgb(244, 67, 54), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Cursor = Cursors.Hand };
        btnXoa.FlatAppearance.BorderSize = 0;
        btnXoa.Click += BtnXoa_Click;
        pnlToolbar.Controls.Add(btnXoa);

        pnlContent.Controls.Add(pnlToolbar);
        pnlToolbar.BringToFront();

        // ── 2. DataGridView Chi tiết sản phẩm ──────────────────
        dgvChiTietSP = CreateDGV();
        dgvChiTietSP.Dock = DockStyle.Fill;
        dgvChiTietSP.ReadOnly = true;
        dgvChiTietSP.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText = "STT",          Name = "STT",         Width = 50 },
            new DataGridViewTextBoxColumn { HeaderText = "Mã CTSP",     Name = "MaCTSP",      Width = 70 },
            new DataGridViewTextBoxColumn { HeaderText = "Tên SP",      Name = "TenSP",       Width = 160 },
            new DataGridViewTextBoxColumn { HeaderText = "Thương hiệu", Name = "ThuongHieu",  Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Thể loại",    Name = "TheLoai",     Width = 90 },
            new DataGridViewTextBoxColumn { HeaderText = "NCC",         Name = "NCC",         Width = 110 },
            new DataGridViewTextBoxColumn { HeaderText = "Chất liệu",   Name = "ChatLieu",    Width = 80 },
            new DataGridViewTextBoxColumn { HeaderText = "Màu",         Name = "Mau",         Width = 70 },
            new DataGridViewTextBoxColumn { HeaderText = "Size",        Name = "SizeCol",     Width = 50 },
            new DataGridViewTextBoxColumn { HeaderText = "Giá nhập",    Name = "GiaNhap",     Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Giá bán",     Name = "GiaBan",      Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Tồn kho",     Name = "SoLuongTon",  Width = 70 },
            new DataGridViewTextBoxColumn { HeaderText = "Trạng thái",  Name = "TrangThaiCol", Width = 90 }
        );
        dgvChiTietSP.CellDoubleClick += (s, ev) => { if (ev.RowIndex >= 0) BtnSua_Click(s, ev); };

        pnlContent.Controls.Add(dgvChiTietSP);
        dgvChiTietSP.BringToFront();

        pnlContent.ResumeLayout(true);

        // Load dữ liệu bộ lọc + dữ liệu chính
        LoadFilterDataForCTSP();
        LoadChiTietSPData();
    }

    private void LoadFilterDataForCTSP()
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
            foreach (var s in ctx.Sizes.OrderBy(s => s.SoSize).ToList())
                cboLocSize.Items.Add(s);
            cboLocSize.DisplayMember = "SoSize";
            cboLocSize.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi LoadFilterDataForCTSP: " + ex.Message);
        }
    }

    private void LoadChiTietSPData()
    {
        try
        {
            using var ctx = new QlBanGiayFinalContext();

            IQueryable<ChiTietSanPham> query = ctx.ChiTietSanPhams
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.MaThuongHieuNavigation)
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.MaTheLoaiNavigation)
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.MaNCCNavigation)
                .Include(ct => ct.MaSanPhamNavigation).ThenInclude(sp => sp.MaChatLieuNavigation)
                .Include(ct => ct.MaMauNavigation)
                .Include(ct => ct.MaKichThuocNavigation);

            // Lọc theo tên sản phẩm
            string keyword = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(ct => ct.MaSanPhamNavigation.TenSP.Contains(keyword));

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
            if (cboLocSize.SelectedIndex > 0 && cboLocSize.SelectedItem is WinFormsDashboard.Data.Models.Size sizeModel)
                query = query.Where(ct => ct.MaKichThuoc == sizeModel.MaKichThuoc);

            var list = query.OrderBy(ct => ct.MaCTSP).ToList();

            dgvChiTietSP.Rows.Clear();
            int stt = 1;
            foreach (var ct in list)
            {
                var sp = ct.MaSanPhamNavigation;
                string trangThai = ct.TrangThai == 1 ? "Đang bán" : "Ngưng bán";

                dgvChiTietSP.Rows.Add(
                    stt++,
                    ct.MaCTSP,
                    sp?.TenSP ?? "",
                    sp?.MaThuongHieuNavigation?.TenThuongHieu ?? "",
                    sp?.MaTheLoaiNavigation?.TenTheLoai ?? "",
                    sp?.MaNCCNavigation?.TenNCC ?? "",
                    sp?.MaChatLieuNavigation?.TenChatLieu ?? "",
                    ct.MaMauNavigation?.TenMau ?? "",
                    ct.MaKichThuocNavigation?.SoSize.ToString() ?? "",
                    ct.GiaNhap.ToString("N0") + " đ",
                    ct.GiaBan.ToString("N0") + " đ",
                    ct.SoLuongTon,
                    trangThai
                );
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi LoadChiTietSPData: " + ex.Message);
        }
    }

    // ── CRUD Chi Tiết Sản Phẩm ──────────────────────────────────
    private void BtnThemMoi_Click(object? sender, EventArgs e)
    {
        using var dlg = new ChiTietSanPhamDialog();
        if (dlg.ShowDialog(this) == DialogResult.OK)
            LoadChiTietSPData();
    }

    private void BtnSua_Click(object? sender, EventArgs e)
    {
        if (dgvChiTietSP.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một dòng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        int maCTSP = Convert.ToInt32(dgvChiTietSP.CurrentRow.Cells["MaCTSP"].Value);
        using var dlg = new ChiTietSanPhamDialog(maCTSP);
        if (dlg.ShowDialog(this) == DialogResult.OK)
            LoadChiTietSPData();
    }

    private void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (dgvChiTietSP.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int maCTSP = Convert.ToInt32(dgvChiTietSP.CurrentRow.Cells["MaCTSP"].Value);
        string tenSP = dgvChiTietSP.CurrentRow.Cells["TenSP"].Value?.ToString() ?? "";

        var result = MessageBox.Show(
            $"Bạn có chắc chắn muốn xóa chi tiết sản phẩm?\n\nMã CTSP: {maCTSP}\nSản phẩm: {tenSP}",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button2);

        if (result != DialogResult.Yes) return;

        try
        {
            using var ctx = new QlBanGiayFinalContext();
            var ct = ctx.ChiTietSanPhams.Find(maCTSP);
            if (ct == null)
            {
                MessageBox.Show("Không tìm thấy chi tiết sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctx.ChiTietSanPhams.Remove(ct);
            ctx.SaveChanges();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadChiTietSPData();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show("Không thể xóa vì chi tiết sản phẩm đang được sử dụng trong hóa đơn hoặc khuyến mãi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadPlaceholder(string name)
    {
        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(new Label { Text = "Trang " + name + " đang phát triển", AutoSize = true, Location = new Point(20, 20), Font = new Font("Segoe UI", 14) });
    }

    // ── Helper UI Methods ──────────────────────────────────────────
    private GroupBox CreateGroup(string title, int height)
    {
        return new GroupBox
        {
            Text = title,
            Height = height,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            Padding = new Padding(10),
            Margin = new Padding(0, 0, 0, 10),
        };
    }

    private DataGridView CreateDGV()
    {
        var dgv = new DataGridView
        {
            BackgroundColor             = Color.White,
            BorderStyle                 = BorderStyle.FixedSingle,
            GridColor                   = Color.LightGray,
            RowHeadersVisible           = false,
            AllowUserToAddRows          = false,
            AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode               = DataGridViewSelectionMode.FullRowSelect,
            EnableHeadersVisualStyles   = false,
            Font                        = new Font("Segoe UI", 9F),
        };
        dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryNavy;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 30;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 243, 255);
        dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

        return dgv;
    }
}

// ── Custom Sidebar Control ──────────────────────────────────────
public class SidebarMenuItem : Control
{
    private bool _hovered;
    public string ItemName { get; }
    public int Index { get; }
    public bool IsSelected { get; set; }

    public SidebarMenuItem(string name, int index)
    {
        ItemName = name;
        Index = index;
        DoubleBuffered = true;
    }

    protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); }
    protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        var rect = ClientRectangle;

        if (IsSelected)
        {
            using var b = new SolidBrush(Color.FromArgb(0, 122, 204));
            g.FillRectangle(b, rect);
        }
        else if (_hovered)
        {
            using var b = new SolidBrush(Color.FromArgb(43, 84, 126));
            g.FillRectangle(b, rect);
        }

        using var font = new Font("Segoe UI", 10F, IsSelected ? FontStyle.Bold : FontStyle.Regular);
        using var brush = new SolidBrush(Color.White);
        g.DrawString(ItemName, font, brush, 15, 12);
    }
}
