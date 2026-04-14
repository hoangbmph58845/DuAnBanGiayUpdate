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
    }
}
