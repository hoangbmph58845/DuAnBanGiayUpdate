using DuAnBanGiay.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanGiay.GUI
{
    public partial class frmKhuyenMai : Form
    {
        public frmKhuyenMai()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        bool isLoaded = false;
        void LoadKM()
        {
            using (var db = new QlBanGiayFinalContext())
            {
                var list = db.KhuyenMais.ToList();

                foreach (var km in list)
                {
                    DateOnly now = DateOnly.FromDateTime(DateTime.Now);

                    if (km.NgayBatDau <= now && km.NgayKetThuc >= now)
                        km.TrangThai = 1;
                    else
                        km.TrangThai = 0;
                }

                db.SaveChanges();
            }
        }
        private void frmKhuyenMai_Load_1(object sender, EventArgs e)
        {
            dgvKM.AutoGenerateColumns = true;

            LoadKM();        // xử lý logic
            LoadDataKM();    // load dữ liệu
            isLoaded = true;

            cboLoai.Items.Add("%");
            cboLoai.Items.Add("Tiền");

            cboLoai.SelectedIndex = 0;
            rdoHoatDong.Checked = true;
            dgvKM.Columns["MaKhuyenMai"].HeaderText = "Mã KM";
            dgvKM.Columns["TenKhuyenMai"].HeaderText = "Tên KM";
            dgvKM.Columns["LoaiGiam"].HeaderText = "Loại";
            dgvKM.Columns["GiaTriGiam"].HeaderText = "Giá trị";
            dgvKM.Columns["TrangThai"].HeaderText = "Trạng thái";
        }
        void LoadDataKM()
        {
            using (var db = new QlBanGiayFinalContext())
            {
                var list = db.KhuyenMais
                    .Select(x => new
                    {
                        x.MaKhuyenMai,
                        x.TenKhuyenMai,
                        LoaiGiam = x.LoaiGiam == 1 ? "%" : "Tiền",
                        x.GiaTriGiam,
                        x.NgayBatDau,
                        x.NgayKetThuc,
                        TrangThai = x.TrangThai == 1 ? "Hoạt động" : "Ngưng"
                    })
                    .ToList();

                dgvKM.DataSource = list;

                dgvKM.RowPostPaint -= dgvKM_RowPostPaint;
                dgvKM.RowPostPaint += dgvKM_RowPostPaint;
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal giaTri;

            if (!decimal.TryParse(txtGiaTri.Text, out giaTri))
            {
                MessageBox.Show("Nhập giá trị hợp lệ!");
                return;
            }
            if (cboLoai.SelectedIndex == 0 && giaTri > 50)
            {
                MessageBox.Show("Không được giảm quá 50%!");
                return;
            }

            // 🔥 giới hạn giảm tiền
            if (cboLoai.SelectedIndex == 1 && giaTri > 500000)
            {
                MessageBox.Show("Không được giảm quá 500.000!");
                return;
            }

            // 🔥 VALIDATE % CHUẨN
            if (cboLoai.SelectedIndex == 0) // Phần trăm
            {
                // 🔥 lấy số trong tên bằng Regex
                var match = System.Text.RegularExpressions.Regex.Match(txtTenKM.Text, @"\d+");

                if (match.Success)
                {
                    decimal ptTen = decimal.Parse(match.Value);

                    if (ptTen != giaTri)
                    {
                        MessageBox.Show("Tên KM và % không khớp!");
                        return;
                    }
                }

                // validate range
                if (giaTri <= 0 || giaTri > 100)
                {
                    MessageBox.Show("Phần trăm phải từ 1 → 100!");
                    return;
                }
            }

            // 🔥 VALIDATE NGÀY
            if (dtpBatDau.Value > dtpKetThuc.Value)
            {
                MessageBox.Show("Ngày không hợp lệ!");
                return;
            }

            using (var db = new QlBanGiayFinalContext())
            {
                var km = new DuAnBanGiay.Models.KhuyenMai
                {
                    TenKhuyenMai = txtTenKM.Text,
                    LoaiGiam = cboLoai.SelectedIndex == 0 ? 1 : 2,
                    GiaTriGiam = giaTri,
                    NgayBatDau = DateOnly.FromDateTime(dtpBatDau.Value),   
                    NgayKetThuc = DateOnly.FromDateTime(dtpKetThuc.Value),
                    TrangThai = rdoHoatDong.Checked ? 1 : 0
                };

                db.KhuyenMais.Add(km);
                db.SaveChanges();
            }

            MessageBox.Show("Thêm thành công!");
            LoadKM();
            LoadDataKM();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvKM.CurrentRow == null) return;
            if (dtpKetThuc.Value < DateTime.Now)
            {
                MessageBox.Show("Không thể sửa KM đã hết hạn!");
                return;
            }

            int id = (int)dgvKM.CurrentRow.Cells["MaKhuyenMai"].Value;

            using (var db = new QlBanGiayFinalContext())
            {
                var km = db.KhuyenMais.Find(id);

                if (km != null)
                {
                    km.TenKhuyenMai = txtTenKM.Text;
                    km.LoaiGiam = cboLoai.SelectedIndex == 0 ? 1 : 2;
                    km.GiaTriGiam = decimal.Parse(txtGiaTri.Text);
                    km.NgayBatDau = DateOnly.FromDateTime(dtpBatDau.Value);
                    km.NgayKetThuc = DateOnly.FromDateTime(dtpKetThuc.Value);
                    km.TrangThai = rdoHoatDong.Checked ? 1 : 0;

                    db.SaveChanges();
                }
            }

            MessageBox.Show("Cập nhật thành công!");
            LoadKM();
            LoadDataKM();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvKM.CurrentRow == null) return;

            int id = (int)dgvKM.CurrentRow.Cells["MaKhuyenMai"].Value;

            using (var db = new QlBanGiayFinalContext())
            {
                // 🔥 1. XÓA BẢNG PHỤ TRƯỚC
                var list = db.CtspKms.Where(x => x.MaKhuyenMai == id).ToList();

                if (list.Count > 0)
                {
                    db.CtspKms.RemoveRange(list);
                }

                // 🔥 2. XÓA KHUYẾN MÃI
                var km = db.KhuyenMais.Find(id);

                if (km != null)
                {
                    db.KhuyenMais.Remove(km);
                }

                db.SaveChanges();
            }

            MessageBox.Show("Xóa thành công!");
            LoadKM();
            LoadDataKM();
        }

        private void dgvKM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKM.CurrentRow == null) return;

            // 🔹 Tên + Giá trị
            txtTenKM.Text = dgvKM.CurrentRow.Cells["TenKhuyenMai"].Value?.ToString() ?? "";
            txtGiaTri.Text = dgvKM.CurrentRow.Cells["GiaTriGiam"].Value?.ToString() ?? "";

            // 🔹 Loại giảm (STRING → ComboBox)
            var loaiValue = dgvKM.CurrentRow.Cells["LoaiGiam"].Value;

            if (loaiValue != null)
            {
                string loai = loaiValue.ToString();

                if (loai == "Phần trăm")
                    cboLoai.SelectedIndex = 0;
                else
                    cboLoai.SelectedIndex = 1;
            }

            // 🔹 Ngày
            if (dgvKM.CurrentRow.Cells["NgayBatDau"].Value != null)
                dtpBatDau.Value = Convert.ToDateTime(dgvKM.CurrentRow.Cells["NgayBatDau"].Value);

            if (dgvKM.CurrentRow.Cells["NgayKetThuc"].Value != null)
                dtpKetThuc.Value = Convert.ToDateTime(dgvKM.CurrentRow.Cells["NgayKetThuc"].Value);

            // 🔹 Trạng thái (STRING → RadioButton)
            var ttValue = dgvKM.CurrentRow.Cells["TrangThai"].Value;

            if (ttValue != null)
            {
                string tt = ttValue.ToString();

                if (tt == "Hoạt động")
                {
                    rdoHoatDong.Checked = true;
                }
                else
                {
                    rdoNgung.Checked = true;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvKM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvKM.Columns.Contains("STT") && e.RowIndex >= 0)
            {
                var row = dgvKM.Rows[e.RowIndex];

                if (!row.IsNewRow)
                {
                    row.Cells["STT"].Value = (e.RowIndex + 1).ToString();
                }
            }
        }

    }
}
