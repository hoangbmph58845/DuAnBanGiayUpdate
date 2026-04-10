namespace DuAnBanGiay
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            label1 = new Label();
            pnlMenu = new Panel();
            panel1 = new Panel();
            btnLogOut = new Button();
            btnThongKe = new Button();
            btnTaiKhoan = new Button();
            bntKhachHang = new Button();
            btnVoucher = new Button();
            btnSanPham = new Button();
            btnBanHang = new Button();
            pnlContent = new Panel();
            pnlHeader.SuspendLayout();
            pnlMenu.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.SteelBlue;
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(908, 60);
            pnlHeader.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(417, 45);
            label1.TabIndex = 0;
            label1.Text = "Hệ thống quản lý bán giày";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(36, 64, 110);
            pnlMenu.Controls.Add(panel1);
            pnlMenu.Controls.Add(btnThongKe);
            pnlMenu.Controls.Add(btnTaiKhoan);
            pnlMenu.Controls.Add(bntKhachHang);
            pnlMenu.Controls.Add(btnVoucher);
            pnlMenu.Controls.Add(btnSanPham);
            pnlMenu.Controls.Add(btnBanHang);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 60);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(300, 561);
            pnlMenu.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogOut);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 411);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 150);
            panel1.TabIndex = 8;
            // 
            // btnLogOut
            // 
            btnLogOut.Dock = DockStyle.Bottom;
            btnLogOut.Location = new Point(0, 116);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(300, 34);
            btnLogOut.TabIndex = 0;
            btnLogOut.Text = "Đăng xuất";
            btnLogOut.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            btnThongKe.Dock = DockStyle.Top;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(0, 170);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Padding = new Padding(20, 0, 0, 0);
            btnThongKe.Size = new Size(300, 34);
            btnThongKe.TabIndex = 5;
            btnThongKe.Text = "Thống kê";
            btnThongKe.TextAlign = ContentAlignment.MiddleLeft;
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.Dock = DockStyle.Top;
            btnTaiKhoan.FlatAppearance.BorderSize = 0;
            btnTaiKhoan.FlatStyle = FlatStyle.Flat;
            btnTaiKhoan.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnTaiKhoan.ForeColor = Color.White;
            btnTaiKhoan.Location = new Point(0, 136);
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.Padding = new Padding(20, 0, 0, 0);
            btnTaiKhoan.Size = new Size(300, 34);
            btnTaiKhoan.TabIndex = 4;
            btnTaiKhoan.Text = "Tài Khoàn";
            btnTaiKhoan.TextAlign = ContentAlignment.MiddleLeft;
            btnTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // bntKhachHang
            // 
            bntKhachHang.Dock = DockStyle.Top;
            bntKhachHang.FlatAppearance.BorderSize = 0;
            bntKhachHang.FlatStyle = FlatStyle.Flat;
            bntKhachHang.Font = new Font("Microsoft Sans Serif", 8.25F);
            bntKhachHang.ForeColor = Color.White;
            bntKhachHang.Location = new Point(0, 102);
            bntKhachHang.Name = "bntKhachHang";
            bntKhachHang.Padding = new Padding(20, 0, 0, 0);
            bntKhachHang.Size = new Size(300, 34);
            bntKhachHang.TabIndex = 3;
            bntKhachHang.Text = "Khách hàng";
            bntKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            bntKhachHang.UseVisualStyleBackColor = true;
            // 
            // btnVoucher
            // 
            btnVoucher.Dock = DockStyle.Top;
            btnVoucher.FlatAppearance.BorderSize = 0;
            btnVoucher.FlatStyle = FlatStyle.Flat;
            btnVoucher.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnVoucher.ForeColor = Color.White;
            btnVoucher.Location = new Point(0, 68);
            btnVoucher.Name = "btnVoucher";
            btnVoucher.Padding = new Padding(20, 0, 0, 0);
            btnVoucher.Size = new Size(300, 34);
            btnVoucher.TabIndex = 2;
            btnVoucher.Text = "Voucher- Khuyến mãi";
            btnVoucher.TextAlign = ContentAlignment.MiddleLeft;
            btnVoucher.UseVisualStyleBackColor = true;
            btnVoucher.Click += btnVoucher_Click;
            // 
            // btnSanPham
            // 
            btnSanPham.Dock = DockStyle.Top;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnSanPham.ForeColor = Color.White;
            btnSanPham.Location = new Point(0, 34);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Padding = new Padding(20, 0, 0, 0);
            btnSanPham.Size = new Size(300, 34);
            btnSanPham.TabIndex = 1;
            btnSanPham.Text = "Chi tiết sản phẩm";
            btnSanPham.TextAlign = ContentAlignment.MiddleLeft;
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnBanHang
            // 
            btnBanHang.Dock = DockStyle.Top;
            btnBanHang.FlatAppearance.BorderSize = 0;
            btnBanHang.FlatStyle = FlatStyle.Flat;
            btnBanHang.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnBanHang.ForeColor = Color.White;
            btnBanHang.Location = new Point(0, 0);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Padding = new Padding(20, 0, 0, 0);
            btnBanHang.Size = new Size(300, 34);
            btnBanHang.TabIndex = 0;
            btnBanHang.Text = "Hóa đơn";
            btnBanHang.TextAlign = ContentAlignment.MiddleLeft;
            btnBanHang.UseVisualStyleBackColor = true;
            btnBanHang.Click += btnBanHang_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(300, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(608, 561);
            pnlContent.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 621);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Controls.Add(pnlHeader);
            Name = "MainForm";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlHeader;
        private Label label1;
        private Panel pnlMenu;
        private Panel panel1;
        private Button btnLogOut;
        private Button btnThongKe;
        private Button btnTaiKhoan;
        private Button bntKhachHang;
        private Button btnVoucher;
        private Button btnSanPham;
        private Button btnBanHang;
        private Panel pnlContent;
    }
}
