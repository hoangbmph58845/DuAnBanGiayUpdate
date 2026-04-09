using WinFormsDashboard.Data;
using WinFormsDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using Size = System.Drawing.Size;

namespace WinFormsDashboard;

public class ChiTietSanPhamDialog : Form
{
    private static readonly Color PrimaryNavy = Color.FromArgb(28, 59, 97);
    private static readonly Color LabelClr = Color.FromArgb(64, 64, 64);

    private ComboBox cboSanPham = null!;
    private ComboBox cboMau = null!;
    private ComboBox cboSize = null!;
    private NumericUpDown nudGiaNhap = null!;
    private NumericUpDown nudGiaBan = null!;
    private NumericUpDown nudSoLuong = null!;
    private ComboBox cboTrangThai = null!;

    private readonly int? _maCTSP;

    public ChiTietSanPhamDialog(int? maCTSP = null)
    {
        _maCTSP = maCTSP;
        InitUI();
        LoadComboData();
        if (_maCTSP.HasValue) LoadEditData();
    }

    private void InitUI()
    {
        Text = _maCTSP.HasValue ? "Sửa chi tiết sản phẩm" : "Thêm chi tiết sản phẩm";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(430, 380);
        BackColor = Color.White;
        Font = new Font("Segoe UI", 9.5F);

        int y = 20, lblX = 20, ctrlX = 150, ctrlW = 255, rowH = 40;

        Controls.Add(new Label { Text = "Sản phẩm:", Location = new Point(lblX, y + 3), AutoSize = true, ForeColor = LabelClr });
        cboSanPham = new ComboBox { Location = new Point(ctrlX, y), Width = ctrlW, DropDownStyle = ComboBoxStyle.DropDownList };
        Controls.Add(cboSanPham);
        y += rowH;

        Controls.Add(new Label { Text = "Màu sắc:", Location = new Point(lblX, y + 3), AutoSize = true, ForeColor = LabelClr });
        cboMau = new ComboBox { Location = new Point(ctrlX, y), Width = ctrlW, DropDownStyle = ComboBoxStyle.DropDownList };
        Controls.Add(cboMau);
        y += rowH;

        Controls.Add(new Label { Text = "Size:", Location = new Point(lblX, y + 3), AutoSize = true, ForeColor = LabelClr });
        cboSize = new ComboBox { Location = new Point(ctrlX, y), Width = ctrlW, DropDownStyle = ComboBoxStyle.DropDownList };
        Controls.Add(cboSize);
        y += rowH;

        Controls.Add(new Label { Text = "Giá nhập:", Location = new Point(lblX, y + 3), AutoSize = true, ForeColor = LabelClr });
        nudGiaNhap = new NumericUpDown { Location = new Point(ctrlX, y), Width = ctrlW, Maximum = 999_999_999, DecimalPlaces = 0, ThousandsSeparator = true };
        Controls.Add(nudGiaNhap);
        y += rowH;

        Controls.Add(new Label { Text = "Giá bán:", Location = new Point(lblX, y + 3), AutoSize = true, ForeColor = LabelClr });
        nudGiaBan = new NumericUpDown { Location = new Point(ctrlX, y), Width = ctrlW, Maximum = 999_999_999, DecimalPlaces = 0, ThousandsSeparator = true };
        Controls.Add(nudGiaBan);
        y += rowH;

        Controls.Add(new Label { Text = "Số lượng tồn:", Location = new Point(lblX, y + 3), AutoSize = true, ForeColor = LabelClr });
        nudSoLuong = new NumericUpDown { Location = new Point(ctrlX, y), Width = ctrlW, Maximum = 999_999, DecimalPlaces = 0 };
        Controls.Add(nudSoLuong);
        y += rowH;

        Controls.Add(new Label { Text = "Trạng thái:", Location = new Point(lblX, y + 3), AutoSize = true, ForeColor = LabelClr });
        cboTrangThai = new ComboBox { Location = new Point(ctrlX, y), Width = ctrlW, DropDownStyle = ComboBoxStyle.DropDownList };
        cboTrangThai.Items.AddRange(new object[] { "Đang bán", "Ngưng bán" });
        cboTrangThai.SelectedIndex = 0;
        Controls.Add(cboTrangThai);
        y += rowH + 20;

        var btnLuu = new Button
        {
            Text = "Lưu",
            Location = new Point(ctrlX, y),
            Size = new Size(120, 35),
            BackColor = PrimaryNavy,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnLuu.FlatAppearance.BorderSize = 0;
        btnLuu.Click += BtnLuu_Click;
        Controls.Add(btnLuu);

        var btnHuy = new Button
        {
            Text = "Hủy",
            Location = new Point(ctrlX + 130, y),
            Size = new Size(120, 35),
            BackColor = Color.FromArgb(158, 158, 158),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Cursor = Cursors.Hand
        };
        btnHuy.FlatAppearance.BorderSize = 0;
        btnHuy.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        Controls.Add(btnHuy);
    }

    private void LoadComboData()
    {
        try
        {
            using var ctx = new QlBanGiayFinalContext();

            cboSanPham.DataSource = ctx.SanPhams.Where(sp => sp.TrangThai == 1).OrderBy(sp => sp.TenSP).ToList();
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSanPham";

            cboMau.DataSource = ctx.Maus.OrderBy(m => m.TenMau).ToList();
            cboMau.DisplayMember = "TenMau";
            cboMau.ValueMember = "MaMau";

            cboSize.DataSource = ctx.Sizes.OrderBy(s => s.SoSize).ToList();
            cboSize.DisplayMember = "SoSize";
            cboSize.ValueMember = "MaKichThuoc";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadEditData()
    {
        try
        {
            using var ctx = new QlBanGiayFinalContext();
            var ct = ctx.ChiTietSanPhams.FirstOrDefault(x => x.MaCTSP == _maCTSP);
            if (ct == null)
            {
                MessageBox.Show("Không tìm thấy chi tiết sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            cboSanPham.SelectedValue = ct.MaSanPham;
            cboMau.SelectedValue = ct.MaMau;
            cboSize.SelectedValue = ct.MaKichThuoc;
            nudGiaNhap.Value = ct.GiaNhap;
            nudGiaBan.Value = ct.GiaBan;
            nudSoLuong.Value = ct.SoLuongTon;
            cboTrangThai.SelectedIndex = ct.TrangThai == 1 ? 0 : 1;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi tải dữ liệu chỉnh sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnLuu_Click(object? sender, EventArgs e)
    {
        if (cboSanPham.SelectedItem is not SanPham selectedSP)
        {
            MessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (cboMau.SelectedItem is not Mau selectedMau)
        {
            MessageBox.Show("Vui lòng chọn màu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (cboSize.SelectedItem is not WinFormsDashboard.Data.Models.Size selectedSize)
        {
            MessageBox.Show("Vui lòng chọn size!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (nudGiaNhap.Value <= 0)
        {
            MessageBox.Show("Giá nhập phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (nudGiaBan.Value <= 0)
        {
            MessageBox.Show("Giá bán phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            using var ctx = new QlBanGiayFinalContext();

            var duplicateQuery = ctx.ChiTietSanPhams.Where(x =>
                x.MaSanPham == selectedSP.MaSanPham &&
                x.MaMau == selectedMau.MaMau &&
                x.MaKichThuoc == selectedSize.MaKichThuoc);

            if (_maCTSP.HasValue)
                duplicateQuery = duplicateQuery.Where(x => x.MaCTSP != _maCTSP.Value);

            if (duplicateQuery.Any())
            {
                MessageBox.Show("Biến thể sản phẩm (SP + Màu + Size) đã tồn tại!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_maCTSP.HasValue)
            {
                var ct = ctx.ChiTietSanPhams.Find(_maCTSP.Value);
                if (ct == null) return;

                ct.MaSanPham = selectedSP.MaSanPham;
                ct.MaMau = selectedMau.MaMau;
                ct.MaKichThuoc = selectedSize.MaKichThuoc;
                ct.GiaNhap = nudGiaNhap.Value;
                ct.GiaBan = nudGiaBan.Value;
                ct.SoLuongTon = (int)nudSoLuong.Value;
                ct.TrangThai = cboTrangThai.SelectedIndex == 0 ? 1 : 0;

                ctx.SaveChanges();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var newCT = new ChiTietSanPham
                {
                    MaSanPham = selectedSP.MaSanPham,
                    MaMau = selectedMau.MaMau,
                    MaKichThuoc = selectedSize.MaKichThuoc,
                    GiaNhap = nudGiaNhap.Value,
                    GiaBan = nudGiaBan.Value,
                    SoLuongTon = (int)nudSoLuong.Value,
                    TrangThai = cboTrangThai.SelectedIndex == 0 ? 1 : 0
                };
                ctx.ChiTietSanPhams.Add(newCT);
                ctx.SaveChanges();
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show("Lỗi lưu dữ liệu: Vi phạm ràng buộc dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
