using DuAnBanGiay.DataContext;
using DuAnBanGiay.Models;
using DuAnBanGiay.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAnBanGiay
{
    public partial class taikhoan : UserControl
    {
        private NhanVienRepository repo = new NhanVienRepository();
        public taikhoan()
        {
            InitializeComponent();
            dgrNhanVien.CellClick += dgrNhanVien_CellClick;
            LoadData(); // 👈 thêm dòng này
        }
        // LOAD DATA GRID
        private void LoadData()
        {
            dgrNhanVien.DataSource = repo.GetAll();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien()
            {
                MaNhanVien = txtMaNv.Text,
                Ten = txtTenNv.Text,
                GioiTinh = rdoNam.Checked,
                NgaySinh = dateNgaySinh.Value,
                Sdt = txtSdt.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                TrangThai = 1,
                MaChucVu = cbbChucVu.SelectedValue.ToString(),
                TaiKhoan = txtTaiKhoan.Text,
                MatKhau = txtMatKhau.Text
            };

            repo.Add(nv);
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien()
            {
                Ten = txtTenNv.Text,
                GioiTinh = rdoNam.Checked,
                NgaySinh = dateNgaySinh.Value,
                Sdt = txtSdt.Text,
                Email = txtEmail.Text,
                DiaChi = txtDiaChi.Text,
                TrangThai = 1,
                MaChucVu = cbbChucVu.SelectedValue.ToString(),
                TaiKhoan = txtTaiKhoan.Text,
                MatKhau = txtMatKhau.Text
            };

            repo.Update(txtMaNv.Text, nv);
            LoadData();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void dgrNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgrNhanVien.Rows[e.RowIndex];

            txtMaNv.Text = row.Cells["MaNhanVien"].Value?.ToString();
            txtTenNv.Text = row.Cells["Ten"].Value?.ToString();
            txtSdt.Text = row.Cells["Sdt"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            txtTaiKhoan.Text = row.Cells["TaiKhoan"].Value?.ToString();

            // giới tính
            if (row.Cells["GioiTinh"].Value?.ToString() == "Nam")
                rdoNam.Checked = true;
            else
                rdoNu.Checked = true;

            // ngày sinh
            if (row.Cells["NgaySinh"].Value != null)
                dateNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);

            // combobox chức vụ
            if (row.Cells["TenChucVu"].Value != null)
                cbbChucVu.Text = row.Cells["TenChucVu"].Value.ToString();
        }
    }
}
