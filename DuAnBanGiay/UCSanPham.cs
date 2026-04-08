using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAnBanGiay.Models;
using DuAnBanGiay.Repositories;
using static DuAnBanGiay.Models.TrangThaiBan;

namespace DuAnBanGiay
{
    public partial class UCSanPham : UserControl
    {
        private readonly DanhMucRepository _danhMucRepo = new();
        private readonly SanPhamRepository _sanPhamRepo = new();
        private readonly ChiTietSanPhamRepository _ctRepo = new();

        public UCSanPham()
        {
            InitializeComponent();
            Load += UCSanPham_Load;
            btnSearch.Click += (_, _) => LoadGrid();
            btnLamMoi.Click += (_, _) => ResetForm();
            btnThem.Click += (_, _) => AddSanPham();
            btnSua.Click += (_, _) => UpdateSanPham();
            btnXoa.Click += (_, _) => DeleteSanPham();
            txtSearch.KeyDown += TxtSearch_KeyDown;
            dataGridView1.SelectionChanged += (_, _) =>
            {
                FillFormFromSelectedRow();
                LoadBienTheFromSelectedSanPham();
            };

            btnThemCT.Click += (_, _) => AddBienThe();
            btnSuaCT.Click += (_, _) => UpdateBienThe();
            btnXoaCT.Click += (_, _) => DeleteBienThe();
            dgvBienThe.SelectionChanged += (_, _) => FillBienTheFromSelectedRow();
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadGrid();
            }
        }

        private void UCSanPham_Load(object? sender, EventArgs e)
        {
            try
            {
                BindDanhMucCombos();
                SetupGrid();
                SetupBienTheGrid();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không kết nối được database.\n\n{ex.Message}\n\n" +
                    "Kiểm tra App.config (connection string 'QLBanGiay') và SQL Server đang chạy.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BindDanhMucCombos()
        {
            cbThuongHieu.DataSource = _danhMucRepo.GetThuongHieu();
            cbThuongHieu.DisplayMember = nameof(DanhMucItem.Name);
            cbThuongHieu.ValueMember = nameof(DanhMucItem.Id);

            cbTheLoai.DataSource = _danhMucRepo.GetTheLoai();
            cbTheLoai.DisplayMember = nameof(DanhMucItem.Name);
            cbTheLoai.ValueMember = nameof(DanhMucItem.Id);

            cbNCC.DataSource = _danhMucRepo.GetNhaCungCap();
            cbNCC.DisplayMember = nameof(DanhMucItem.Name);
            cbNCC.ValueMember = nameof(DanhMucItem.Id);

            cbChatLieu.DataSource = _danhMucRepo.GetChatLieu();
            cbChatLieu.DisplayMember = nameof(DanhMucItem.Name);
            cbChatLieu.ValueMember = nameof(DanhMucItem.Id);

            cbMau.DataSource = _danhMucRepo.GetMau();
            cbMau.DisplayMember = nameof(DanhMucItem.Name);
            cbMau.ValueMember = nameof(DanhMucItem.Id);

            cbSize.DataSource = _danhMucRepo.GetSize();
            cbSize.DisplayMember = nameof(DanhMucItem.Name);
            cbSize.ValueMember = nameof(DanhMucItem.Id);
        }

        private void SetupGrid()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void SetupBienTheGrid()
        {
            dgvBienThe.AutoGenerateColumns = true;
            dgvBienThe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBienThe.MultiSelect = false;
            dgvBienThe.ReadOnly = true;
            dgvBienThe.AllowUserToAddRows = false;
            dgvBienThe.AllowUserToDeleteRows = false;
        }

        private void LoadGrid()
        {
            var rows = _sanPhamRepo.Search(txtSearch.Text);
            dataGridView1.DataSource = rows;

            if (dataGridView1.Columns["MaThuongHieu"] is not null) dataGridView1.Columns["MaThuongHieu"].Visible = false;
            if (dataGridView1.Columns["MaTheLoai"] is not null) dataGridView1.Columns["MaTheLoai"].Visible = false;
            if (dataGridView1.Columns["MaNhaCungCap"] is not null) dataGridView1.Columns["MaNhaCungCap"].Visible = false;
            if (dataGridView1.Columns["MaChatLieu"] is not null) dataGridView1.Columns["MaChatLieu"].Visible = false;
            if (dataGridView1.Columns["TrangThai"] is not null) dataGridView1.Columns["TrangThai"].Visible = false;
            if (dataGridView1.Columns["TrangThaiHienThi"] is not null)
                dataGridView1.Columns["TrangThaiHienThi"].HeaderText = "Trạng thái";
        }

        private void ResetForm()
        {
            txtSearch.Text = "";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            chkTrangThai.Checked = true;
            if (cbThuongHieu.Items.Count > 0) cbThuongHieu.SelectedIndex = 0;
            if (cbTheLoai.Items.Count > 0) cbTheLoai.SelectedIndex = 0;
            if (cbNCC.Items.Count > 0) cbNCC.SelectedIndex = 0;
            if (cbChatLieu.Items.Count > 0) cbChatLieu.SelectedIndex = 0;
            ResetBienTheForm();
            LoadGrid();
            LoadBienTheFromSelectedSanPham();
        }

        private void ResetBienTheForm()
        {
            txtMaCTSP.Text = "";
            txtGiaBan.Text = "";
            txtSoLuongTon.Text = "";
            chkTrangThaiCT.Checked = true;
            if (cbMau.Items.Count > 0) cbMau.SelectedIndex = 0;
            if (cbSize.Items.Count > 0) cbSize.SelectedIndex = 0;
            dgvBienThe.DataSource = null;
        }

        private SanPhamRow? SelectedRow()
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is SanPhamRow row) return row;
            return null;
        }

        private void FillFormFromSelectedRow()
        {
            var row = SelectedRow();
            if (row is null) return;

            txtMaSP.Text = row.MaSanPham.ToString();
            txtTenSP.Text = row.TenSP;
            chkTrangThai.Checked = row.TrangThai == (int)DangBan;

            if (row.MaThuongHieu is not null) cbThuongHieu.SelectedValue = row.MaThuongHieu.Value;
            if (row.MaTheLoai is not null) cbTheLoai.SelectedValue = row.MaTheLoai.Value;
            if (row.MaNhaCungCap is not null) cbNCC.SelectedValue = row.MaNhaCungCap.Value;
            if (row.MaChatLieu is not null) cbChatLieu.SelectedValue = row.MaChatLieu.Value;
        }

        private void LoadBienTheFromSelectedSanPham()
        {
            var sp = SelectedRow();
            if (sp is null)
            {
                dgvBienThe.DataSource = null;
                return;
            }

            var rows = _ctRepo.GetBySanPham(sp.MaSanPham);
            dgvBienThe.DataSource = rows;

            if (dgvBienThe.Columns["MaSanPham"] is not null) dgvBienThe.Columns["MaSanPham"].Visible = false;
            if (dgvBienThe.Columns["TenSP"] is not null) dgvBienThe.Columns["TenSP"].Visible = false;
            if (dgvBienThe.Columns["MaMau"] is not null) dgvBienThe.Columns["MaMau"].Visible = false;
            if (dgvBienThe.Columns["MaKichThuoc"] is not null) dgvBienThe.Columns["MaKichThuoc"].Visible = false;
            if (dgvBienThe.Columns["TrangThai"] is not null) dgvBienThe.Columns["TrangThai"].Visible = false;
            if (dgvBienThe.Columns["TrangThaiHienThi"] is not null)
                dgvBienThe.Columns["TrangThaiHienThi"].HeaderText = "Trạng thái";
        }

        private ChiTietSanPhamRow? SelectedBienTheRow()
        {
            if (dgvBienThe.CurrentRow?.DataBoundItem is ChiTietSanPhamRow row) return row;
            return null;
        }

        private void FillBienTheFromSelectedRow()
        {
            var row = SelectedBienTheRow();
            if (row is null) return;

            txtMaCTSP.Text = row.MaCTSP.ToString();
            cbMau.SelectedValue = row.MaMau;
            cbSize.SelectedValue = row.MaKichThuoc;
            txtGiaBan.Text = row.GiaBan.ToString("0.##");
            txtSoLuongTon.Text = row.SoLuongTon.ToString();
            chkTrangThaiCT.Checked = row.TrangThai == (int)DangBan;
        }

        private bool TryReadBienTheInputs(out int maSanPham, out int maMau, out int maKichThuoc, out decimal giaBan, out int soLuongTon, out int trangThai)
        {
            maSanPham = 0;
            maMau = 0;
            maKichThuoc = 0;
            giaBan = 0;
            soLuongTon = 0;
            trangThai = (int)(chkTrangThaiCT.Checked ? DangBan : NgungBan);

            var sp = SelectedRow();
            if (sp is null)
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm ở danh sách phía trên.");
                return false;
            }
            maSanPham = sp.MaSanPham;

            if (cbMau.SelectedValue is not int mau)
            {
                MessageBox.Show("Vui lòng chọn màu.");
                return false;
            }
            maMau = mau;

            if (cbSize.SelectedValue is not int size)
            {
                MessageBox.Show("Vui lòng chọn size.");
                return false;
            }
            maKichThuoc = size;

            if (!decimal.TryParse(txtGiaBan.Text, out giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.");
                return false;
            }

            if (!int.TryParse(txtSoLuongTon.Text, out soLuongTon) || soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ.");
                return false;
            }

            return true;
        }

        private void AddBienThe()
        {
            if (!TryReadBienTheInputs(out var maSp, out var maMau, out var maSize, out var giaBan, out var ton, out var tt))
                return;

            try
            {
                var id = _ctRepo.Insert(maSp, maMau, maSize, giaBan, ton, tt);
                LoadBienTheFromSelectedSanPham();
                txtMaCTSP.Text = id.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể thêm biến thể.\n\n{ex.Message}\n\n" +
                    "Lưu ý: (Sản phẩm + Màu + Size) phải là duy nhất (UQ_SKU).",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateBienThe()
        {
            if (!int.TryParse(txtMaCTSP.Text, out var maCtsp))
            {
                MessageBox.Show("Vui lòng chọn 1 biến thể để sửa.");
                return;
            }

            if (!TryReadBienTheInputs(out var maSp, out var maMau, out var maSize, out var giaBan, out var ton, out var tt))
                return;

            try
            {
                _ctRepo.Update(maCtsp, maSp, maMau, maSize, giaBan, ton, tt);
                LoadBienTheFromSelectedSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể sửa biến thể.\n\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DeleteBienThe()
        {
            if (!int.TryParse(txtMaCTSP.Text, out var maCtsp))
            {
                MessageBox.Show("Vui lòng chọn 1 biến thể để xóa.");
                return;
            }

            var ok = MessageBox.Show(
                "Xóa sẽ chuyển biến thể sang trạng thái ngưng bán. Bạn chắc chứ?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ok != DialogResult.Yes) return;

            _ctRepo.Delete(maCtsp);
            LoadBienTheFromSelectedSanPham();
        }

        private void AddSanPham()
        {
            var ten = (txtTenSP.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm.");
                return;
            }

            var id = _sanPhamRepo.Insert(
                ten,
                (int?)cbThuongHieu.SelectedValue,
                (int?)cbTheLoai.SelectedValue,
                (int?)cbNCC.SelectedValue,
                (int?)cbChatLieu.SelectedValue,
                (int)(chkTrangThai.Checked ? DangBan : NgungBan));

            LoadGrid();
            txtMaSP.Text = id.ToString();
            LoadBienTheFromSelectedSanPham();
        }

        private void UpdateSanPham()
        {
            if (!int.TryParse(txtMaSP.Text, out var maSp))
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm để sửa.");
                return;
            }

            var ten = (txtTenSP.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập Tên sản phẩm.");
                return;
            }

            _sanPhamRepo.Update(
                maSp,
                ten,
                (int?)cbThuongHieu.SelectedValue,
                (int?)cbTheLoai.SelectedValue,
                (int?)cbNCC.SelectedValue,
                (int?)cbChatLieu.SelectedValue,
                (int)(chkTrangThai.Checked ? DangBan : NgungBan));

            LoadGrid();
        }

        private void DeleteSanPham()
        {
            if (!int.TryParse(txtMaSP.Text, out var maSp))
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm để xóa.");
                return;
            }

            var ok = MessageBox.Show(
                "Xóa sẽ chuyển sản phẩm sang trạng thái ngưng bán. Bạn chắc chứ?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ok != DialogResult.Yes) return;

            _sanPhamRepo.Delete(maSp);
            LoadGrid();
        }
    }
}
