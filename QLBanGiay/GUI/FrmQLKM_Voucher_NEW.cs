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
using System.Data.Entity;

namespace QLBanGiay.GUI
{
    public partial class FrmQLKM_Voucher_NEW : Form

    {
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvVoucher.Rows[e.RowIndex];

            txtCode.Text = row.Cells["MaCode"].Value.ToString();
            txtGiam.Text = row.Cells["SoTienGiam"].Value.ToString();
            txtDK.Text = row.Cells["DieuKienGiam"].Value.ToString();
            txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString() ?? "";
        }
        public FrmQLKM_Voucher_NEW()
        {
            InitializeComponent();
        }

        private void FrmQLKM_Voucher_NEW_Load(object sender, EventArgs e)
        {
            dgvVoucher.AutoGenerateColumns = true;
            dgvKM.AutoGenerateColumns = true;

            LoadVoucher();
            LoadDataKM();

            rdoHoatDong.Checked = true;
            dgvVoucher.CellFormatting += dgvVoucher_CellFormatting;
            dgvKM.CellFormatting += dgvKM_CellFormatting;
            cboLoai.Items.Clear();
            cboLoai.Items.Add("Phần trăm");
            cboLoai.Items.Add("Tiền");
            cboLoai.SelectedIndex = 0;
            StyleGrid(dgvVoucher);
            StyleGrid(dgvKM);
            // ===== VOUCHER =====
            StyleButton(btnAddVoucher, Color.FromArgb(40, 167, 69));     // xanh lá
            StyleButton(btnUpdateVoucher, Color.FromArgb(255, 193, 7));  // vàng
            StyleButton(btnDeleteVoucher, Color.FromArgb(220, 53, 69));  // đỏ
            StyleButton(btnBatDau, Color.FromArgb(0, 123, 255));   // xanh dương
            StyleButton(btnNgung, Color.Gray);                     // xám

            // ===== KHUYẾN MÃI =====
            StyleButton(btnAddKM, Color.FromArgb(40, 167, 69));
            StyleButton(btnUpdateKM, Color.FromArgb(255, 193, 7));
            StyleButton(btnDeleteKM, Color.FromArgb(220, 53, 69));
            this.BackColor = Color.FromArgb(240, 242, 245);

            // panel top (màu xanh đậm)
            pnTop.BackColor = Color.FromArgb(0, 123, 255);

            // panel left (sidebar xanh đậm hơn)
            pnLeft.BackColor = Color.FromArgb(45, 62, 80);

        }
        void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }
        void StyleGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void LoadVoucher()
        {
            QL_BanGiay_FinalEntities db = new QL_BanGiay_FinalEntities();
            var data = db.Vouchers.Select(v => new
            {
                Ma_Voucher = v.MaVoucher,
                Ma_Code = v.MaCode,
                So_tien_giam = v.SoTienGiam,
                Dieu_kien = v.DieuKienGiam,
                Trang_thai = v.TrangThai == 1 ? "Hoạt động" : "Ngưng"
            }).ToList();

            dgvVoucher.DataSource = data;

            dgvVoucher.Columns[0].HeaderText = "Mã Voucher";
            dgvVoucher.Columns[1].HeaderText = "Mã Code";
            dgvVoucher.Columns[2].HeaderText = "Số tiền giảm";
            dgvVoucher.Columns[3].HeaderText = "Điều kiện";
            dgvVoucher.Columns[4].HeaderText = "Trạng thái";
            foreach (DataGridViewRow row in dgvVoucher.Rows)
            {
                if (row.Cells["Trang_thai"].Value.ToString() == "Hoạt động")
                {
                    row.Cells["Trang_thai"].Style.ForeColor = Color.Green;
                }
                else
                {
                    row.Cells["Trang_thai"].Style.ForeColor = Color.Red;
                }
            }
        }

        void LoadDataKM()
        {
            QL_BanGiay_FinalEntities db = new QL_BanGiay_FinalEntities();
            var data = db.KhuyenMais.Select(km => new
            {
                Ma_KM = km.MaKhuyenMai,
                Ten_Khuyen_Mai = km.TenKhuyenMai,
                Loai_Giam = km.LoaiGiam == 1 ? "Giảm %" : "Giảm tiền",
                Gia_Tri_Giam = km.GiaTriGiam,
                Ngay_Bat_Dau = km.NgayBatDau,
                Ngay_Ket_Thuc = km.NgayKetThuc,
                Trang_Thai = km.TrangThai == 1 ? "Hoạt động" : "Ngưng"
            }).ToList();

            dgvKM.DataSource = data;

            // đổi tên header
            dgvKM.Columns[0].HeaderText = "Mã KM";
            dgvKM.Columns[1].HeaderText = "Tên khuyến mãi";
            dgvKM.Columns[2].HeaderText = "Loại giảm";
            dgvKM.Columns[3].HeaderText = "Giá trị giảm";
            dgvKM.Columns[4].HeaderText = "Ngày bắt đầu";
            dgvKM.Columns[5].HeaderText = "Ngày kết thúc";
            dgvKM.Columns[6].HeaderText = "Trạng thái";
            foreach (DataGridViewRow row in dgvKM.Rows)
            {
                if (row.Cells["Trang_thai"].Value.ToString() == "Hoạt động")
                {
                    row.Cells["Trang_thai"].Style.ForeColor = Color.Green;
                }
                else
                {
                    row.Cells["Trang_thai"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void dgvVoucher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVoucher.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                if (e.Value != null)
                {
                    int value = Convert.ToInt32(e.Value);
                    e.Value = value == 1 ? "Hoạt động" : "Ngưng";
                }
            }
        }

        private void dgvKM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKM.Columns[e.ColumnIndex].Name == "LoaiGiam" && e.Value != null)
            {
                e.Value = (int)e.Value == 1 ? "Phần trăm" : "Tiền";
            }

            if (dgvKM.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                e.Value = (int)e.Value == 1 ? "Hoạt động" : "Ngưng";
            }
        }

        private void dgvKM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvKM.Rows[e.RowIndex];

            txtTenKM.Text = row.Cells["TenKhuyenMai"].Value?.ToString() ?? "";
            txtGiaTri.Text = row.Cells["GiaTriGiam"].Value?.ToString() ?? "";

            int loai = Convert.ToInt32(row.Cells["LoaiGiam"].Value);

            // ❗ CHỐNG LỖI
            if (cboLoai.Items.Count > 0)
            {
                cboLoai.SelectedIndex = loai == 1 ? 0 : 1;
            }

            dtpBatDau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
            dtpKetThuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);

            int tt = Convert.ToInt32(row.Cells["TrangThai"].Value);
            rdoHoatDong.Checked = tt == 1;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal giaTri;

            if (!decimal.TryParse(txtGiaTri.Text, out giaTri))
            {
                MessageBox.Show("Nhập giá trị hợp lệ!");
                return;
            }

            // ❗ VALIDATE
            if (!ValidateKM()) return;
            if (!ValidateTrangThaiKM()) return;

            if (dtpBatDau.Value < dtpKetThuc.Value)
            {
                MessageBox.Show("Ngày không hợp lệ!");
                return;
            }


            using (var db = new QL_BanGiay_FinalEntities())
            {
                var km = new KhuyenMai
                {
                    TenKhuyenMai = txtTenKM.Text,
                    LoaiGiam = cboLoai.SelectedIndex == 0 ? 1 : 2,
                    GiaTriGiam = giaTri,
                    NgayBatDau = dtpBatDau.Value,
                    NgayKetThuc = dtpKetThuc.Value,
                    TrangThai = rdoHoatDong.Checked ? 1 : 0
                };

                db.KhuyenMais.Add(km);
                db.SaveChanges();
            }

            MessageBox.Show("Thêm thành công!");
            LoadDataKM();
        }

        private void btnAddVoucher_Click(object sender, EventArgs e)
        {
            decimal giam, dk;

            if (!decimal.TryParse(txtGiam.Text, out giam) ||
                !decimal.TryParse(txtDK.Text, out dk))
            {
                MessageBox.Show("Sai dữ liệu!");
                return;
            }
            if (txtCode.Text == "")
            {
                MessageBox.Show("Chưa nhập mã!");
                return;
            }
            if (!ValidateVoucher()) return;

            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = new Voucher
                {
                    MaCode = txtCode.Text,
                    SoTienGiam = giam,
                    DieuKienGiam = dk,
                    NgayBatDau = dtpBatDau.Value,
                    NgayKetThuc = dtpKetThuc.Value,
                    TrangThai = 1
                };

                db.Vouchers.Add(v);
                db.SaveChanges();
            }

            MessageBox.Show("Thêm thành công!");
            LoadVoucher();
        }

        private void btnUpdateVoucher_Click(object sender, EventArgs e)
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = db.Vouchers.FirstOrDefault(x => x.MaCode == txtCode.Text);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy!");
                    return;
                }
                if (txtCode.Text == "")
                {
                    MessageBox.Show("Chưa nhập mã!");
                    return;
                }

                if (!decimal.TryParse(txtGiam.Text, out decimal giam))
                {
                    MessageBox.Show("Sai tiền giảm!");
                    return;
                }
                v.SoTienGiam = decimal.Parse(txtGiam.Text);
                v.DieuKienGiam = decimal.Parse(txtDK.Text);
                v.SoLuong = int.Parse(txtSoLuong.Text);
                v.NgayBatDau = dtpBatDau.Value;
                v.NgayKetThuc = dtpKetThuc.Value;
                v.GhiChu = txtGhiChu.Text;

                db.SaveChanges();
            }

            MessageBox.Show("Cập nhật thành công!");
            LoadVoucher();
        }

        private void btnUpdateKM_Click(object sender, EventArgs e)
        {
            if (dgvKM.CurrentRow == null) return;

            decimal giaTri;
            if (!decimal.TryParse(txtGiaTri.Text, out giaTri))
            {
                MessageBox.Show("Sai giá trị!");
                return;
            }

            // ❗ VALIDATE
            if (!ValidateKM()) return;
            if (!ValidateTrangThaiKM()) return;

            int id = Convert.ToInt32(dgvKM.CurrentRow.Cells["MaKhuyenMai"].Value);

            using (var db = new QL_BanGiay_FinalEntities())
            {
                var km = db.KhuyenMais.Find(id);

                if (km != null)
                {
                    km.TenKhuyenMai = txtTenKM.Text;
                    km.LoaiGiam = cboLoai.SelectedIndex == 0 ? 1 : 2;
                    km.GiaTriGiam = giaTri;
                    km.NgayBatDau = dtpBatDau.Value;
                    km.NgayKetThuc = dtpKetThuc.Value;
                    km.TrangThai = rdoHoatDong.Checked ? 1 : 0;

                    db.SaveChanges();
                }
            }

            MessageBox.Show("Cập nhật thành công!");
            LoadDataKM();
        }

        private void btnDeleteVoucher_Click(object sender, EventArgs e)
        {
            using (var db = new QL_BanGiay_FinalEntities())
            {
                var v = db.Vouchers.FirstOrDefault(x => x.MaCode == txtCode.Text);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy!");
                    return;
                }
                if (txtCode.Text == "")
                {
                    MessageBox.Show("Chưa nhập mã!");
                    return;
                }

                if (!decimal.TryParse(txtGiam.Text, out decimal giam))
                {
                    MessageBox.Show("Sai tiền giảm!");
                    return;
                }
                db.Vouchers.Remove(v);
                db.SaveChanges();
            }

            MessageBox.Show("Xóa thành công!");
            LoadVoucher();
        }

        private void btnDeleteKM_Click(object sender, EventArgs e)
        {
            if (dgvKM.CurrentRow == null)
            {
                MessageBox.Show("Chưa chọn!");
                return;
            }

            int id = Convert.ToInt32(dgvKM.CurrentRow.Cells["MaKhuyenMai"].Value);

            using (var db = new QL_BanGiay_FinalEntities())
            {
                // ❗ xóa bảng phụ trước
                var list = db.CTSP_KM.Where(x => x.MaKhuyenMai == id).ToList();
                db.CTSP_KM.RemoveRange(list);

                var km = db.KhuyenMais.Find(id);

                if (km != null)
                {
                    db.KhuyenMais.Remove(km);
                    db.SaveChanges();
                }
            }

            MessageBox.Show("Xóa thành công!");
            LoadDataKM();
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Chưa chọn voucher!");
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

                v.TrangThai = 0; // ❌ NGƯNG

                db.SaveChanges();
            }

            MessageBox.Show("Đã ngưng voucher!");
            LoadVoucher();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Chưa chọn voucher!");
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

                v.TrangThai = 1; // ✅ HOẠT ĐỘNG

                db.SaveChanges();
            }

            MessageBox.Show("Đã kích hoạt voucher!");
            LoadVoucher();
        }
        bool ValidateTrangThaiKM()
        {
            if (!rdoHoatDong.Checked && !rdoNgung.Checked)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!");
                return false;
            }
            return true;
        }
        bool ValidateKM()
        {
            decimal giaTri;

            if (string.IsNullOrWhiteSpace(txtTenKM.Text))
            {
                MessageBox.Show("Tên KM không được trống!");
                return false;
            }

            if (!decimal.TryParse(txtGiaTri.Text, out giaTri))
            {
                MessageBox.Show("Giá trị không hợp lệ!");
                return false;
            }

            // ❗ % phải từ 1 → 100
            if (cboLoai.SelectedIndex == 0 && (giaTri <= 0 || giaTri > 100))
            {
                MessageBox.Show("Phần trăm phải từ 1 → 100!");
                return false;
            }

            // ❗ tiền phải > 0
            if (cboLoai.SelectedIndex == 1 && giaTri <= 0)
            {
                MessageBox.Show("Số tiền phải > 0!");
                return false;
            }

            // ❗ ngày
            if (dtpBatDau.Value > dtpKetThuc.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải <= ngày kết thúc!");
                return false;
            }

            return true;
        }
        bool ValidateVoucher()
        {
            decimal giam, dk;
            int soluong;

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Mã voucher không được trống!");
                return false;
            }

            if (!decimal.TryParse(txtGiam.Text, out giam) || giam <= 0)
            {
                MessageBox.Show("Tiền giảm phải > 0!");
                return false;
            }

            if (!decimal.TryParse(txtDK.Text, out dk) || dk < 0)
            {
                MessageBox.Show("Điều kiện không hợp lệ!");
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text, out soluong) || soluong <= 0)
            {
                MessageBox.Show("Số lượng phải > 0!");
                return false;
            }

            if (dtpBatDau.Value < dtpKetThuc.Value)
            {
                MessageBox.Show("Ngày không hợp lệ!");
                return false;
            }

            return true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void paMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
