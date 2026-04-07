namespace DuAnBanGiay
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnSanPham.Click += (_, _) => ShowControl(new UCSanPham());
            btnBanHang.Click += (_, _) => ShowControl(new UCBanHang());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ShowControl(UserControl control)
        {
            pnlContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(control);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {

            pnlContent.Controls.Clear(); 

            UCBanHang uc = new UCBanHang();
            uc.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(uc);


        }
    }
}
