using DuAnBanGiay.GUI;
using QLBanGiay.GUI;

namespace DuAnBanGiay
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        // Trang Hóa Đơn (xem hóa đơn - chỉ đọc, có bộ lọc)
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            UCHoaDon uc = new UCHoaDon();
            uc.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(uc);
        }

        // Trang Chi tiết sản phẩm (CRUD)
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            UCChiTietSanPham uc = new UCChiTietSanPham();
            uc.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(uc);
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            frmvoucher frm = new frmvoucher();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(frm);
            frm.Show();
        }
    }
}
