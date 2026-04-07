
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using QLBanGiay;


namespace QLBanGiay.GUI
{
    public partial class frmvoucher : Form
    {
        public frmvoucher()
        {
            InitializeComponent();
        }
        bool isLoaded = false;
        private void frmvoucher_Load(object sender, EventArgs e)
        {
            LoadVoucher();
            LoadData();
            LoadVoucherToCombo();
            isLoaded = true;
            dgvVoucher.Columns["MaVoucher"].HeaderText = "ID";
            dgvVoucher.Columns["MaCode"].HeaderText = "Mã Voucher";
            dgvVoucher.Columns["SoTienGiam"].HeaderText = "Tiền giảm";
            dgvVoucher.Columns["DieuKienGiam"].HeaderText = "Điều kiện";
            dgvVoucher.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvVoucher.Columns["MaVoucher"].Visible = false;
            dgvVoucher.Columns["TrangThai"].DefaultCellStyle.NullValue = "Hoạt động";
            dgvVoucher.Columns["SoTienGiam"].DefaultCellStyle.Format = "N0";
            dgvVoucher.CellFormatting += dgvVoucher_CellFormatting;
            lblTienGiam.Text = "Tiền giảm: 0 đ";
            lblThanhToan.Text = "Thanh toán: 0 đ";
        }

        private void dgvVoucher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVoucher.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "1")
                        e.Value = "Hoạt động";
                    else
                        e.Value = "Ngưng";
                }
            }
        }
        void LoadVoucher()
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                dgvVoucher.DataSource = db.Vouchers.ToList();
            }
        }
        void LoadData()
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                dgvVoucher.DataSource = db.Vouchers.ToList();
            }
        }
        void LoadVoucherToCombo()
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                var list = db.Vouchers
                    .Select(x => new
                    {
                        x.MaVoucher,
                        HienThi = "Voucher " + x.MaCode +
                                  " - Giảm " + x.SoTienGiam + "đ"
                    })
                    .ToList();

                cboVoucher.DataSource = list;
                cboVoucher.DisplayMember = "HienThi";   // 👈 đẹp
                cboVoucher.ValueMember = "MaVoucher";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            decimal giam, dk;

            if (!decimal.TryParse(txtGiam.Text, out giam) ||
                !decimal.TryParse(txtDK.Text, out dk))
            {
                MessageBox.Show("Nhập số hợp lệ!");
                return;
            }

            using (var db = new QL_BanGiay_FinalEntities())
            {
                // check trùng
                string code = txtCode.Text.Trim();

                bool exists = db.Vouchers.Any(x => x.MaCode == code);
                if (exists)
                {
                    MessageBox.Show("Mã voucher đã tồn tại!");
                    return;
                }
                var v = new Voucher
                {
                    MaCode = txtCode.Text,   // 👈 dùng mã code
                    SoTienGiam = giam,
                    DieuKienGiam = dk,
                    TrangThai = 1
                };

                db.Vouchers.Add(v);
                db.SaveChanges();

                MessageBox.Show("Thêm thành công!");
            }

            // load lại grid
            LoadData();
            LoadVoucher();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            decimal giam, dk;

            if (!decimal.TryParse(txtGiam.Text, out giam) ||
                !decimal.TryParse(txtDK.Text, out dk))
            {
                MessageBox.Show("Nhập số hợp lệ!");
                return;
            }

            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = db.Vouchers
                    .FirstOrDefault(x => x.MaCode == txtCode.Text);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy voucher!");
                    return;
                }

                v.SoTienGiam = giam;
                v.DieuKienGiam = dk;

                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
            }

            LoadVoucher();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return;
            }

            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = db.Vouchers
                    .FirstOrDefault(x => x.MaCode == txtCode.Text);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy voucher!");
                    return;
                }

                db.Vouchers.Remove(v);
                db.SaveChanges();

                MessageBox.Show("Xóa thành công!");
            }

            LoadVoucher();
        }

        private void dgvVoucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCode.Text = dgvVoucher.Rows[e.RowIndex].Cells["MaCode"].Value.ToString();
                txtGiam.Text = dgvVoucher.Rows[e.RowIndex].Cells["SoTienGiam"].Value.ToString();
                txtDK.Text = dgvVoucher.Rows[e.RowIndex].Cells["DieuKienGiam"].Value.ToString();
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Không làm gì hết
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            decimal tongTien;
            decimal tienGiam = 0;

            if (!decimal.TryParse(txtTongTien.Text, out tongTien))
            {
                MessageBox.Show("Nhập tổng tiền hợp lệ!");
                return;
            }

            using (var db = new QL_BanGiay_FinalEntities())
            {
                int maVoucher = (int)cboVoucher.SelectedValue;

                var voucher = db.Vouchers
                    .FirstOrDefault(x => x.MaVoucher == maVoucher);

                if (voucher == null)
                {
                    MessageBox.Show("Không tìm thấy voucher!");
                    return;
                }

                // ❌ Nếu đã ngưng thì không dùng được
                if (voucher.TrangThai == 0)
                {
                    MessageBox.Show("Voucher đã ngưng!");
                    return;
                }

                // ✔ Check điều kiện
                if (tongTien >= (voucher.DieuKienGiam ?? 0))
                {
                    tienGiam = voucher.SoTienGiam ?? 0;

                    // 👉 TRỪ TIỀN
                    decimal thanhToan = tongTien - tienGiam;

                    lblTienGiam.Text = "Tiền giảm: " + tienGiam.ToString("N0") + " đ";
                    lblThanhToan.Text = "Thanh toán: " + thanhToan.ToString("N0") + " đ";

                    MessageBox.Show("Áp dụng voucher thành công!");

                    // 🎯 VẤN ĐỀ 2: ĐỔI TRẠNG THÁI
                    voucher.TrangThai = 0;
                    db.SaveChanges();

                    LoadVoucher();
                    LoadVoucherToCombo();
                }
                else
                {
                    MessageBox.Show("Không đủ điều kiện!");
                    lblTienGiam.Text = "Tiền giảm: 0 đ";
                    lblThanhToan.Text = "Thanh toán: " + tongTien.ToString("N0") + " đ";
                }
            }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            decimal tongTien;

            if (decimal.TryParse(txtTongTien.Text, out tongTien))
            {
                lblThanhToan.Text = "Thanh toán: " + tongTien.ToString("N0") + " đ";
            }
            else
            {
                lblThanhToan.Text = "Thanh toán: 0 đ";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
