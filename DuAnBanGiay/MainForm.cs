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

        private void btnBanHang_Click(object sender, EventArgs e)
        {

            pnlContent.Controls.Clear();

            UCBanHang uc = new UCBanHang();
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
