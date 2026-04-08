namespace DuAnBanGiay
{
    partial class taikhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlContent = new Panel();
            btnLamMoi = new Button();
            btnSua = new Button();
            grbnhanvien = new GroupBox();
            dgrNhanVien = new DataGridView();
            grbtimKiem = new GroupBox();
            dateNgaySinh = new DateTimePicker();
            cbbTrangThai = new ComboBox();
            cbbChucVu = new ComboBox();
            rdoNu = new RadioButton();
            txtMatKhau = new TextBox();
            lbMatKhau = new Label();
            txtTaiKhoan = new TextBox();
            lbTaiKhoan = new Label();
            lbTrangThai = new Label();
            txtDiaChi = new TextBox();
            lbDiaChi = new Label();
            txtSdt = new TextBox();
            lbSdt = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            lbChucVu = new Label();
            lbNgaySinh = new Label();
            lbGioiTinh = new Label();
            txtTenNv = new TextBox();
            lbTenNv = new Label();
            rdoNam = new RadioButton();
            txtMaNv = new TextBox();
            btnThem = new Button();
            lbManv = new Label();
            pnlHeader = new Panel();
            label1 = new Label();
            pnlContent.SuspendLayout();
            grbnhanvien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgrNhanVien).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(btnLamMoi);
            pnlContent.Controls.Add(btnSua);
            pnlContent.Controls.Add(grbnhanvien);
            pnlContent.Controls.Add(grbtimKiem);
            pnlContent.Controls.Add(dateNgaySinh);
            pnlContent.Controls.Add(cbbTrangThai);
            pnlContent.Controls.Add(cbbChucVu);
            pnlContent.Controls.Add(rdoNu);
            pnlContent.Controls.Add(txtMatKhau);
            pnlContent.Controls.Add(lbMatKhau);
            pnlContent.Controls.Add(txtTaiKhoan);
            pnlContent.Controls.Add(lbTaiKhoan);
            pnlContent.Controls.Add(lbTrangThai);
            pnlContent.Controls.Add(txtDiaChi);
            pnlContent.Controls.Add(lbDiaChi);
            pnlContent.Controls.Add(txtSdt);
            pnlContent.Controls.Add(lbSdt);
            pnlContent.Controls.Add(txtEmail);
            pnlContent.Controls.Add(label7);
            pnlContent.Controls.Add(lbChucVu);
            pnlContent.Controls.Add(lbNgaySinh);
            pnlContent.Controls.Add(lbGioiTinh);
            pnlContent.Controls.Add(txtTenNv);
            pnlContent.Controls.Add(lbTenNv);
            pnlContent.Controls.Add(rdoNam);
            pnlContent.Controls.Add(txtMaNv);
            pnlContent.Controls.Add(btnThem);
            pnlContent.Controls.Add(lbManv);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 36);
            pnlContent.Margin = new Padding(2);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1738, 613);
            pnlContent.TabIndex = 6;
            pnlContent.Paint += pnlContent_Paint;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(250, 306);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(82, 22);
            btnLamMoi.TabIndex = 30;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(135, 306);
            btnSua.Margin = new Padding(3, 2, 3, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(82, 22);
            btnSua.TabIndex = 29;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // grbnhanvien
            // 
            grbnhanvien.Controls.Add(dgrNhanVien);
            grbnhanvien.Location = new Point(369, 90);
            grbnhanvien.Margin = new Padding(3, 2, 3, 2);
            grbnhanvien.Name = "grbnhanvien";
            grbnhanvien.Padding = new Padding(3, 2, 3, 2);
            grbnhanvien.Size = new Size(1366, 325);
            grbnhanvien.TabIndex = 0;
            grbnhanvien.TabStop = false;
            grbnhanvien.Text = "Danh Sách Nhân Viên";
            // 
            // dgrNhanVien
            // 
            dgrNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgrNhanVien.Location = new Point(5, 20);
            dgrNhanVien.Margin = new Padding(3, 2, 3, 2);
            dgrNhanVien.Name = "dgrNhanVien";
            dgrNhanVien.RowHeadersWidth = 51;
            dgrNhanVien.Size = new Size(1355, 301);
            dgrNhanVien.TabIndex = 0;
            dgrNhanVien.CellClick += dgrNhanVien_CellClick;
            // 
            // grbtimKiem
            // 
            grbtimKiem.Location = new Point(369, 4);
            grbtimKiem.Margin = new Padding(3, 2, 3, 2);
            grbtimKiem.Name = "grbtimKiem";
            grbtimKiem.Padding = new Padding(3, 2, 3, 2);
            grbtimKiem.Size = new Size(1138, 81);
            grbtimKiem.TabIndex = 28;
            grbtimKiem.TabStop = false;
            grbtimKiem.Text = "Bộ Lọc";
            // 
            // dateNgaySinh
            // 
            dateNgaySinh.Location = new Point(145, 84);
            dateNgaySinh.Margin = new Padding(3, 2, 3, 2);
            dateNgaySinh.Name = "dateNgaySinh";
            dateNgaySinh.Size = new Size(219, 23);
            dateNgaySinh.TabIndex = 27;
            // 
            // cbbTrangThai
            // 
            cbbTrangThai.FormattingEnabled = true;
            cbbTrangThai.Location = new Point(145, 209);
            cbbTrangThai.Margin = new Padding(3, 2, 3, 2);
            cbbTrangThai.Name = "cbbTrangThai";
            cbbTrangThai.Size = new Size(219, 23);
            cbbTrangThai.TabIndex = 26;
            // 
            // cbbChucVu
            // 
            cbbChucVu.FormattingEnabled = true;
            cbbChucVu.Location = new Point(145, 110);
            cbbChucVu.Margin = new Padding(3, 2, 3, 2);
            cbbChucVu.Name = "cbbChucVu";
            cbbChucVu.Size = new Size(219, 23);
            cbbChucVu.TabIndex = 25;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(271, 62);
            rdoNu.Margin = new Padding(3, 2, 3, 2);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(41, 19);
            rdoNu.TabIndex = 24;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(145, 260);
            txtMatKhau.Margin = new Padding(3, 2, 3, 2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(219, 23);
            txtMatKhau.TabIndex = 23;
            // 
            // lbMatKhau
            // 
            lbMatKhau.AutoSize = true;
            lbMatKhau.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMatKhau.Location = new Point(22, 259);
            lbMatKhau.Name = "lbMatKhau";
            lbMatKhau.Size = new Size(72, 20);
            lbMatKhau.TabIndex = 22;
            lbMatKhau.Text = "Mật Khẩu";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Location = new Point(145, 235);
            txtTaiKhoan.Margin = new Padding(3, 2, 3, 2);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(219, 23);
            txtTaiKhoan.TabIndex = 21;
            // 
            // lbTaiKhoan
            // 
            lbTaiKhoan.AutoSize = true;
            lbTaiKhoan.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTaiKhoan.Location = new Point(22, 234);
            lbTaiKhoan.Name = "lbTaiKhoan";
            lbTaiKhoan.Size = new Size(73, 20);
            lbTaiKhoan.TabIndex = 20;
            lbTaiKhoan.Text = "Tài Khoản";
            // 
            // lbTrangThai
            // 
            lbTrangThai.AutoSize = true;
            lbTrangThai.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTrangThai.Location = new Point(22, 209);
            lbTrangThai.Name = "lbTrangThai";
            lbTrangThai.Size = new Size(78, 20);
            lbTrangThai.TabIndex = 18;
            lbTrangThai.Text = "Trạng Thái";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(145, 185);
            txtDiaChi.Margin = new Padding(3, 2, 3, 2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(219, 23);
            txtDiaChi.TabIndex = 17;
            // 
            // lbDiaChi
            // 
            lbDiaChi.AutoSize = true;
            lbDiaChi.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDiaChi.Location = new Point(22, 184);
            lbDiaChi.Name = "lbDiaChi";
            lbDiaChi.Size = new Size(57, 20);
            lbDiaChi.TabIndex = 16;
            lbDiaChi.Text = "Địa Chỉ";
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(145, 160);
            txtSdt.Margin = new Padding(3, 2, 3, 2);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(219, 23);
            txtSdt.TabIndex = 15;
            // 
            // lbSdt
            // 
            lbSdt.AutoSize = true;
            lbSdt.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbSdt.Location = new Point(22, 160);
            lbSdt.Name = "lbSdt";
            lbSdt.Size = new Size(102, 20);
            lbSdt.TabIndex = 14;
            lbSdt.Text = "Số Điện Thoại";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(145, 136);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 23);
            txtEmail.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(22, 135);
            label7.Name = "label7";
            label7.Size = new Size(46, 20);
            label7.TabIndex = 12;
            label7.Text = "Email";
            // 
            // lbChucVu
            // 
            lbChucVu.AutoSize = true;
            lbChucVu.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbChucVu.Location = new Point(22, 110);
            lbChucVu.Name = "lbChucVu";
            lbChucVu.Size = new Size(63, 20);
            lbChucVu.TabIndex = 10;
            lbChucVu.Text = "Chức Vụ";
            // 
            // lbNgaySinh
            // 
            lbNgaySinh.AutoSize = true;
            lbNgaySinh.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNgaySinh.Location = new Point(22, 86);
            lbNgaySinh.Name = "lbNgaySinh";
            lbNgaySinh.Size = new Size(76, 20);
            lbNgaySinh.TabIndex = 8;
            lbNgaySinh.Text = "Ngày Sinh";
            // 
            // lbGioiTinh
            // 
            lbGioiTinh.AutoSize = true;
            lbGioiTinh.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbGioiTinh.Location = new Point(22, 61);
            lbGioiTinh.Name = "lbGioiTinh";
            lbGioiTinh.Size = new Size(68, 20);
            lbGioiTinh.TabIndex = 6;
            lbGioiTinh.Text = "Giới Tính";
            // 
            // txtTenNv
            // 
            txtTenNv.Location = new Point(145, 37);
            txtTenNv.Margin = new Padding(3, 2, 3, 2);
            txtTenNv.Name = "txtTenNv";
            txtTenNv.Size = new Size(219, 23);
            txtTenNv.TabIndex = 5;
            // 
            // lbTenNv
            // 
            lbTenNv.AutoSize = true;
            lbTenNv.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTenNv.Location = new Point(22, 36);
            lbTenNv.Name = "lbTenNv";
            lbTenNv.Size = new Size(104, 20);
            lbTenNv.TabIndex = 4;
            lbTenNv.Text = "Tên Nhân Viên";
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(145, 62);
            rdoNam.Margin = new Padding(3, 2, 3, 2);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(51, 19);
            rdoNam.TabIndex = 3;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtMaNv
            // 
            txtMaNv.Location = new Point(145, 12);
            txtMaNv.Margin = new Padding(3, 2, 3, 2);
            txtMaNv.Name = "txtMaNv";
            txtMaNv.Size = new Size(219, 23);
            txtMaNv.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(16, 306);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(82, 22);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += button1_Click;
            // 
            // lbManv
            // 
            lbManv.AutoSize = true;
            lbManv.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbManv.Location = new Point(22, 11);
            lbManv.Name = "lbManv";
            lbManv.Size = new Size(102, 20);
            lbManv.TabIndex = 0;
            lbManv.Text = "Mã Nhân Viên";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.SteelBlue;
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1738, 36);
            pnlHeader.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 30);
            label1.TabIndex = 0;
            label1.Text = "Tài Khoản ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // taikhoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "taikhoan";
            Size = new Size(1738, 649);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            grbnhanvien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgrNhanVien).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContent;
        private Panel pnlHeader;
        private Label label1;
        private TextBox txtMaNv;
        private Button btnThem;
        private Label lbManv;
        private TextBox txtMatKhau;
        private Label lbMatKhau;
        private TextBox txtTaiKhoan;
        private Label lbTaiKhoan;
        private Label lbTrangThai;
        private TextBox txtDiaChi;
        private Label lbDiaChi;
        private TextBox txtSdt;
        private Label lbSdt;
        private TextBox txtEmail;
        private Label label7;
        private Label lbChucVu;
        private Label lbNgaySinh;
        private Label lbGioiTinh;
        private TextBox txtTenNv;
        private Label lbTenNv;
        private RadioButton rdoNam;
        private DateTimePicker dateNgaySinh;
        private ComboBox cbbTrangThai;
        private ComboBox cbbChucVu;
        private RadioButton rdoNu;
        private GroupBox grbtimKiem;
        private GroupBox grbnhanvien;
        private Button btnLamMoi;
        private Button btnSua;
        private DataGridView dgrNhanVien;
    }
}