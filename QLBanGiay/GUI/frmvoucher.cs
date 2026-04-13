
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
    public partial class btnNgung : Form
    {
        public btnNgung()
        {
            InitializeComponent();
        }
        bool isLoaded = false;
        private void frmvoucher_Load(object sender, EventArgs e)
        {
            LoadVoucher();
            LoadData();
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
        }

        private void dgvVoucher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVoucher.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                if (e.Value != null)
                {
                    e.Value = (int)e.Value == 1 ? "Hoạt động" : "Ngưng";
                }
            }

        }
        private void dgvVoucher_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvVoucher.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }
        void LoadVoucher()
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                var list = db.Vouchers.ToList();

                // ❗ DÒNG NÀY PHẢI CÓ TRƯỚC
                dgvVoucher.DataSource = list;

                // ❗ STT PHẢI ĐẶT NGAY SAU ĐÂY
                dgvVoucher.RowPostPaint -= dgvVoucher_RowPostPaint;
                dgvVoucher.RowPostPaint += dgvVoucher_RowPostPaint;
                foreach (var v in list)
                {
                    DateTime now = DateTime.Now;

                    if (v.NgayBatDau > now || v.NgayKetThuc < now)
                    {
                        v.TrangThai = 0;
                    }
                }
                db.SaveChanges();
                    
            }
        }
        void LoadData()
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                dgvVoucher.DataSource = db.Vouchers.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            decimal giam, dk;
            int soluong;

            if (!decimal.TryParse(txtGiam.Text, out giam) ||
                !decimal.TryParse(txtDK.Text, out dk) ||
                !int.TryParse(txtSoLuong.Text, out soluong))
            {
                MessageBox.Show("Nhập số hợp lệ!");
                return;
            }

            using (var db = new QL_BanGiay_FinalEntities())
            {
                // check trùng MaCode
                bool exists = db.Vouchers.Any(x => x.MaCode == txtCode.Text);

                if (exists)
                {
                    MessageBox.Show("Mã voucher đã tồn tại!");
                    return;
                }

                var v = new Voucher
                {
                    MaCode = txtCode.Text,
                    SoTienGiam = giam,
                    DieuKienGiam = dk,
                    SoLuong = soluong,
                    NgayBatDau = dtpBatDau.Value,
                    NgayKetThuc = dtpKetThuc.Value,
                    GhiChu = txtGhiChu.Text,
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
            int soluong;

            if (!decimal.TryParse(txtGiam.Text, out giam) ||
                !decimal.TryParse(txtDK.Text, out dk) ||
                !int.TryParse(txtSoLuong.Text, out soluong))
            {
                MessageBox.Show("Sai dữ liệu!");
                return;
            }

            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = db.Vouchers.FirstOrDefault(x => x.MaCode == txtCode.Text);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy!");
                    return;
                }

                v.SoTienGiam = giam;
                v.DieuKienGiam = dk;
                v.NgayBatDau = dtpBatDau.Value;
                v.NgayKetThuc = dtpKetThuc.Value;
                v.SoLuong = soluong;
                v.GhiChu = txtGhiChu.Text;

                db.SaveChanges();
            }

            MessageBox.Show("Cập nhật OK!");
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
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private int GetTrangThai(DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;

            if (now < start) return 0; // chưa tới ngày
            if (now > end) return 0;   // hết hạn

            return 1; // đang hoạt động

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = db.Vouchers.FirstOrDefault(x => x.MaCode == txtCode.Text);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy voucher!");
                    return;
                }

                v.TrangThai = 0; // 0 = ngưng

                db.SaveChanges();

                MessageBox.Show("Đã ngưng voucher!");
            }

            LoadVoucher();
        }

        private void btnKichHoat_Click(object sender, EventArgs e)
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = db.Vouchers.FirstOrDefault(x => x.MaCode == txtCode.Text);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy!");
                    return;
                }

                v.TrangThai = 1;

                db.SaveChanges();

                MessageBox.Show("Đã kích hoạt!");
            }

            LoadVoucher();
        }
    }
}
