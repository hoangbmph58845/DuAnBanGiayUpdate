using System.Drawing.Drawing2D;

namespace WinFormsDashboard;

public class MainForm : Form
{
    // ── Color Palette (Navy Blue/Gray phong cách chuyên nghiệp) ──
    private static readonly Color PrimaryNavy    = Color.FromArgb(28, 59, 97);   // Sidebar & Header
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
        "Sản phẩm",
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
        SelectMenu(1); // Mặc định mở trang Sản phẩm
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

        if (index == 0)      LoadInvoicePage(); // Menu Bán hàng
        else if (index == 1) LoadProductPage(); // Menu Sản phẩm
        else LoadPlaceholder(MenuNames[index]);
    }

    private void LoadInvoicePage()
    {
        pnlContent.Controls.Clear();
        var page = new HoaDonPage();
        pnlContent.Controls.Add(page);
    }

    // ═══════════════════════════════════════════════════════════════
    //  Trang Sản Phẩm (Giống ảnh mẫu)
    // ═══════════════════════════════════════════════════════════════
    private void LoadProductPage()
    {
        pnlContent.Controls.Clear();
        pnlContent.SuspendLayout();

        // 1. Phía trên: Tìm kiếm
        var flowTop = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 40, FlowDirection = FlowDirection.LeftToRight };
        flowTop.Controls.Add(new TextBox { Width = 300, PlaceholderText = "Nhập tên sản phẩm hoặc mã..." });
        flowTop.Controls.Add(new Button { Text = "Tìm kiếm", Width = 100 });
        flowTop.Controls.Add(new Button { Text = "Làm mới", Width = 100 });
        pnlContent.Controls.Add(flowTop);

        // 2. Thông tin sản phẩm Group
        var gbInfo = CreateGroup("Thông tin sản phẩm", 130);
        gbInfo.Dock = DockStyle.Top;
        pnlContent.Controls.Add(gbInfo);
        gbInfo.BringToFront();

        // Nội dung của Thông tin sản phẩm
        int lx = 15, ly = 25, ix = 100, gap = 30;
        AddInputField(gbInfo, "Mã SP",   lx, ly, ix, 150);
        AddInputField(gbInfo, "Tên SP",  lx, ly + gap, ix, 300);
        AddComboField(gbInfo, "Thương hiệu", 350, ly, 450, 200, new[] { "Adidas", "Nike", "Converse" });
        AddComboField(gbInfo, "NCC", 350, ly + gap, 450, 200, new[] { "NCC Cần Thơ", "NCC Hà Nội" });
        AddComboField(gbInfo, "Thể loại", 700, ly, 780, 150, new[] { "Street", "Sneaker" });
        AddComboField(gbInfo, "Chất liệu", 700, ly + gap, 780, 150, new[] { "Lưới", "Vải", "Da" });
        
        var cbDangBan = new CheckBox { Text = "Đang bán", Location = new System.Drawing.Point(950, ly + gap), AutoSize = true };
        gbInfo.Controls.Add(cbDangBan);

        // Cụm nút bên phải gbInfo
        int bx = gbInfo.Width - 120;
        gbInfo.Controls.Add(new Button { Text = "Thêm", Location = new Point(1050, 20), Width = 100, Height = 25 });
        gbInfo.Controls.Add(new Button { Text = "Sửa",   Location = new Point(1050, 50), Width = 100, Height = 25, BackColor = Color.FromArgb(240, 173, 78), FlatStyle = FlatStyle.Flat });
        gbInfo.Controls.Add(new Button { Text = "Xóa (ẩn)", Location = new Point(1050, 80), Width = 100, Height = 25 });

        // 3. DataGridView Sản phẩm (Main)
        var dgvMain = CreateDGV();
        dgvMain.Dock = DockStyle.Top;
        dgvMain.Height = 250;
        dgvMain.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText = "MaSanPham",  DataPropertyName = "ID", Width = 90 },
            new DataGridViewTextBoxColumn { HeaderText = "TenSP",       DataPropertyName = "Name", Width = 150 },
            new DataGridViewTextBoxColumn { HeaderText = "ThuongHieu", DataPropertyName = "Brand", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "TheLoai",    DataPropertyName = "Type", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "TenNCC",     DataPropertyName = "Supplier", Width = 120 },
            new DataGridViewTextBoxColumn { HeaderText = "TenChatLieu", DataPropertyName = "Material", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Trạng thái",  DataPropertyName = "Status", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "TongTon",    DataPropertyName = "Stock", Width = 80 }
        );
        // Data mẫu
        dgvMain.Rows.Add("9", "Converse Classic", "Adidas", "Street", "NCC Cần Thơ", "Lưới", "Ngưng bán", "16");
        dgvMain.Rows.Add("8", "Nike Air Force 1", "Converse", "Sneaker", "NCC HCM", "Tổng hợp", "Ngưng bán", "25");
        dgvMain.Rows.Add("7", "Nike Air Force 1", "Adidas", "Football", "NCC Hà Nội", "Lưới", "Ngưng bán", "55");
        
        pnlContent.Controls.Add(dgvMain);
        dgvMain.BringToFront();

        // 4. Biến thể Group
        var gbVariant = CreateGroup("Biến thể (Chi tiết sản phẩm)", 120);
        gbVariant.Dock = DockStyle.Top;
        pnlContent.Controls.Add(gbVariant);
        gbVariant.BringToFront();

        AddInputField(gbVariant, "Mã CTSP", lx, 30, ix, 150);
        AddComboField(gbVariant, "Màu", 280, 30, 340, 120, new[] { "Trắng", "Đen", "Đỏ" });
        AddComboField(gbVariant, "Size", 480, 30, 540, 80, new[] { "39", "40", "41" });
        AddInputField(gbVariant, "Giá bán", 650, 30, 720, 150);
        AddInputField(gbVariant, "Tồn kho", lx, 70, ix, 150);
        
        var cbVariantSales = new CheckBox { Text = "Đang bán", Location = new Point(280, 70), AutoSize = true };
        gbVariant.Controls.Add(cbVariantSales);

        gbVariant.Controls.Add(new Button { Text = "Thêm CT", Location = new Point(450, 65), Width = 90 });
        gbVariant.Controls.Add(new Button { Text = "Sửa CT",   Location = new Point(550, 65), Width = 90 });
        gbVariant.Controls.Add(new Button { Text = "Xóa CT",   Location = new Point(650, 65), Width = 90 });

        // 5. DataGridView Biến thể (Sub)
        var dgvSub = CreateDGV();
        dgvSub.Dock = DockStyle.Fill; // Điền nốt phần còn lại
        dgvSub.Columns.AddRange(
            new DataGridViewTextBoxColumn { HeaderText = "MaCTSP",     Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Mau",        Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "SoSize",     Width = 80 },
            new DataGridViewTextBoxColumn { HeaderText = "GiaBan",     Width = 120 },
            new DataGridViewTextBoxColumn { HeaderText = "SoLuongTon", Width = 100 },
            new DataGridViewTextBoxColumn { HeaderText = "Trạng thái",  Width = 120 }
        );
        dgvSub.Rows.Add("48", "Trắng", "39", "1800000.00", "10", "Đang bán");
        dgvSub.Rows.Add("47", "Đỏ", "40", "1800000.00", "6", "Đang bán");

        pnlContent.Controls.Add(dgvSub);
        dgvSub.BringToFront();

        pnlContent.ResumeLayout(true);
    }

    private void LoadPlaceholder(string name)
    {
        pnlContent.Controls.Clear();
        pnlContent.Controls.Add(new Label { Text = "Trang " + name + " đang phát triển", AutoSize = true, Location = new Point(20, 20), Font = new Font("Segoe UI", 14) });
    }

    // ── Helper UI Methods ──────────────────────────────────────────
    private void AddInputField(Control parent, string labelText, int lx, int ly, int ix, int iWidth)
    {
        parent.Controls.Add(new Label { Text = labelText + ":", Location = new Point(lx, ly + 3), AutoSize = true, ForeColor = LabelClr });
        parent.Controls.Add(new TextBox { Location = new Point(ix, ly), Width = iWidth });
    }

    private void AddComboField(Control parent, string labelText, int lx, int ly, int ix, int iWidth, string[] items)
    {
        parent.Controls.Add(new Label { Text = labelText + ":", Location = new Point(lx, ly + 3), AutoSize = true, ForeColor = LabelClr });
        var cmb = new ComboBox { Location = new Point(ix, ly), Width = iWidth, DropDownStyle = ComboBoxStyle.DropDownList };
        cmb.Items.AddRange(items);
        if (items.Length > 0) cmb.SelectedIndex = 0;
        parent.Controls.Add(cmb);
    }

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
            RowHeadersVisible           = true,
            AllowUserToAddRows          = false,
            AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.None,
            SelectionMode               = DataGridViewSelectionMode.FullRowSelect,
            EnableHeadersVisualStyles   = false,
            Font                        = new Font("Segoe UI", 9F),
        };
        dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryNavy;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 30;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

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
