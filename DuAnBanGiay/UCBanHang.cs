using DuAnBanGiay.DataContext;
using DuAnBanGiay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DuAnBanGiay
{
    public partial class UCBanHang : UserControl
    {
        private int? _maHoaDonHienTai = null;
        private bool _laHoaDonCho = false;
        private decimal _giamVoucher = 0;
        private decimal _giamKhuyenMai = 0;
        private bool _dangLoad = false;

        public UCBanHang()
        {
            InitializeComponent();

            InitGioHang();
            LoadSanPham();
            LoadComboBoxFilter();
            InitDgvHoaDon();
            LoadHoaDon();
            LoadKhachHang();
            LoadVoucher();
            LoadKhuyenMai();
            
        }
        // ══════════════════════════════════════════════
        //  INIT / LOAD
        // ══════════════════════════════════════════════

        void InitDgvHoaDon()
        {
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add("STT", "STT");
            dgvHoaDon.Columns.Add("MaHoaDon", "Mã HĐ");
            dgvHoaDon.Columns.Add("TrangThai", "Trạng thái");
        }

        void LoadHoaDon()
        {
            using var db = new QlBanGiayFinalContext();
            var list = db.HoaDons.OrderBy(x => x.MaHoaDon)
                                  .Select(x => new { x.MaHoaDon, x.TrangThai })
                                  .ToList();
            dgvHoaDon.Rows.Clear();
            int stt = 1;
            foreach (var hd in list)
            {
                string tt = hd.TrangThai switch
                {
                    0 => "Chờ",
                    1 => "Đã thanh toán",
                    2 => "Đã hủy",
                    _ => "Không xác định"
                };
                dgvHoaDon.Rows.Add(stt++, hd.MaHoaDon, tt);
            }
        }

        void InitGioHang()
        {
            dgvGioHang.Columns.Clear();
            dgvGioHang.Columns.Add("MaCtsp", "MaCTSP");
            dgvGioHang.Columns.Add("TenSP", "Tên SP");
            dgvGioHang.Columns.Add("Size", "Size");
            dgvGioHang.Columns.Add("Mau", "Màu");
            dgvGioHang.Columns.Add("SoLuong", "SL");
            dgvGioHang.Columns.Add("Gia", "Giá");
            dgvGioHang.Columns.Add("ThanhTien", "Thành tiền");
            dgvGioHang.Columns.Add("TonKho", "Tồn kho");

            dgvGioHang.Columns["MaCtsp"].Visible = false;
            dgvGioHang.Columns["TonKho"].Visible = false;

            // Tất cả cột đều ReadOnly — chỉ sửa qua context menu
            foreach (DataGridViewColumn col in dgvGioHang.Columns)
                col.ReadOnly = true;

            dgvGioHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        void LoadSanPham()
        {
            using var db = new QlBanGiayFinalContext();
            dgvSanPham.DataSource = db.ChiTietSanPhams
                .Where(x => x.TrangThai == 1)
                .Select(x => new
                {
                    x.MaCtsp,
                    TenSP = x.MaSanPhamNavigation.TenSp,
                    Hang = x.MaSanPhamNavigation.MaThuongHieuNavigation.TenThuongHieu,
                    Size = x.MaKichThuocNavigation.SoSize,
                    Mau = x.MaMauNavigation.TenMau,
                    Gia = x.GiaBan,
                    TonKho = x.SoLuongTon
                }).ToList();
        }

        void LoadComboBoxFilter()
        {
            _dangLoad = true;
            using var db = new QlBanGiayFinalContext();

            cboHang.DataSource = null; cboHang.DisplayMember = "TenThuongHieu"; cboHang.ValueMember = "MaThuongHieu";
            cboHang.DataSource = db.ThuongHieus.ToList(); cboHang.SelectedIndex = -1; cboHang.Text = "-- Hãng --";

            cboSize.DataSource = null; cboSize.DisplayMember = "SoSize"; cboSize.ValueMember = "MaKichThuoc";
            cboSize.DataSource = db.Sizes.ToList(); cboSize.SelectedIndex = -1; cboSize.Text = "-- Size --";

            cboMau.DataSource = null; cboMau.DisplayMember = "TenMau"; cboMau.ValueMember = "MaMau";
            cboMau.DataSource = db.Maus.ToList(); cboMau.SelectedIndex = -1; cboMau.Text = "-- Màu --";

            _dangLoad = false;
        }

        void LoadKhachHang()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("-- Khách vãng lai --");
            comboBox2.SelectedIndex = 0;
        }

        void LoadVoucher()
        {
            using var db = new QlBanGiayFinalContext();
            cboVoucher.Items.Clear();
            cboVoucher.Items.Add("-- Không dùng --");
            foreach (var v in db.Vouchers.Where(v => v.TrangThai == 1).ToList())
                cboVoucher.Items.Add(v.MaCode);
            cboVoucher.SelectedIndex = 0;
        }

        void LoadKhuyenMai()
        {
            using var db = new QlBanGiayFinalContext();
            var today = DateOnly.FromDateTime(DateTime.Today);

            cboGiamGia.Items.Clear();
            cboGiamGia.Items.Add("-- Không dùng --");
            foreach (var k in db.KhuyenMais
                                 .Where(x => x.TrangThai == 1
                                          && x.NgayBatDau <= today
                                          && x.NgayKetThuc >= today)
                                 .ToList())
                cboGiamGia.Items.Add(k.TenKhuyenMai);
            cboGiamGia.SelectedIndex = 0;
        }

        // ══════════════════════════════════════════════
        //  HÓA ĐƠN
        // ══════════════════════════════════════════════


        void FilterSanPham()
        {
            if (_dangLoad) return;

            using (var db = new QlBanGiayFinalContext())
            {
                var query = db.ChiTietSanPhams
                    .Where(x => x.TrangThai == 1)
                    .AsQueryable();

                string keyword = txtTimKiem.Text.Trim();
                if (!string.IsNullOrWhiteSpace(keyword))
                    query = query.Where(x => x.MaSanPhamNavigation.TenSp.ToLower().Contains(keyword.ToLower()));


                if (cboHang.SelectedValue is int maHang && maHang > 0)
                    query = query.Where(x => x.MaSanPhamNavigation.MaThuongHieu == maHang);


                if (cboSize.SelectedValue is int maSize && maSize > 0)
                    query = query.Where(x => x.MaKichThuoc == maSize);


                if (cboMau.SelectedValue is int maMau && maMau > 0)
                    query = query.Where(x => x.MaMau == maMau);

                dgvSanPham.DataSource = query.Select(x => new
                {
                    x.MaCtsp,
                    TenSP = x.MaSanPhamNavigation.TenSp,
                    Hang = x.MaSanPhamNavigation.MaThuongHieuNavigation.TenThuongHieu,
                    Size = x.MaKichThuocNavigation.SoSize,
                    Mau = x.MaMauNavigation.TenMau,
                    Gia = x.GiaBan,
                    TonKho = x.SoLuongTon
                }).ToList();
            }
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            FilterSanPham();
        }


        private void btnXoaBoLoc_Click(object sender, EventArgs e)
        {
            _dangLoad = true;

            txtTimKiem.Clear();
            cboHang.SelectedIndex = -1;
            cboHang.Text = "-- Hãng --";

            cboSize.SelectedIndex = -1;
            cboSize.Text = "-- Size --";

            cboMau.SelectedIndex = -1;
            cboMau.Text = "-- Màu --";

            _dangLoad = false;

            FilterSanPham();
        }

        private void cboHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSanPham();
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSanPham();
        }

        private void cboMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSanPham();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHoaDon.Rows[e.RowIndex];
            string tt = row.Cells["TrangThai"].Value?.ToString() ?? "";
            if (tt != "Chờ")
            {
                dgvGioHang.Rows.Clear();
                _maHoaDonHienTai = null;
                _laHoaDonCho = false;
                _giamVoucher = 0;
                _giamKhuyenMai = 0;
                lblMaHD.Text = "";
                cboVoucher.SelectedIndex = 0;
                cboGiamGia.SelectedIndex = 0;
                txtSDT.Clear();
                TinhTongCong();

                if (tt == "Đã thanh toán" || tt == "Đã hủy")
                    MessageBox.Show($"Hóa đơn này đã {tt.ToLower()}, không thể chỉnh sửa.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maHD = Convert.ToInt32(row.Cells["MaHoaDon"].Value);
            _maHoaDonHienTai = maHD;
            _laHoaDonCho = true;
            lblMaHD.Text = maHD.ToString();
            LoadGioHangTuHoaDon(maHD);
        }
        void LoadGioHangTuHoaDon(int maHD)
        {
            using var db = new QlBanGiayFinalContext();

            var hd = db.HoaDons.FirstOrDefault(x => x.MaHoaDon == maHD);

            // Reset giảm giá
            _giamVoucher = 0;
            _giamKhuyenMai = 0;
            cboVoucher.SelectedIndex = 0;
            cboGiamGia.SelectedIndex = 0;

            // Load voucher của hóa đơn
            if (hd?.MaVoucher != null)
            {
                var v = db.Vouchers.Find(hd.MaVoucher);
                if (v != null)
                {
                    for (int i = 1; i < cboVoucher.Items.Count; i++)
                        if (cboVoucher.Items[i].ToString() == v.MaCode)
                        {
                            cboVoucher.SelectedIndex = i;
                            _giamVoucher = v.SoTienGiam ?? 0;
                            break;
                        }
                }
            }
            if (hd?.MaKh != null)
            {
                var kh = db.KhachHangs.Find(hd.MaKh);
                if (kh != null) txtSDT.Text = kh.SoDienThoai;
            }
            else txtSDT.Clear();

            // Load giỏ hàng
            var chiTiet = db.HoaDonChiTiets
                .Where(x => x.MaHoaDon == maHD)
                .Select(x => new
                {
                    x.MaCtsp,
                    TenSP = x.MaCtspNavigation.MaSanPhamNavigation.TenSp,
                    Size = x.MaCtspNavigation.MaKichThuocNavigation.SoSize.ToString(),
                    Mau = x.MaCtspNavigation.MaMauNavigation.TenMau,
                    x.SoLuong,
                    x.DonGia,
                    x.ThanhTien,
                    TonKho = x.MaCtspNavigation.SoLuongTon
                }).ToList();

            dgvGioHang.Rows.Clear();
            foreach (var ct in chiTiet)
                dgvGioHang.Rows.Add(ct.MaCtsp, ct.TenSP, ct.Size, ct.Mau,
                                    ct.SoLuong, ct.DonGia, ct.ThanhTien, ct.TonKho);

            TinhTongCong();
        }

        private void btnthemHD_Click(object sender, EventArgs e)
        {
            _maHoaDonHienTai = null;
            _laHoaDonCho = false;
            _giamVoucher = 0;
            _giamKhuyenMai = 0;
            lblMaHD.Text = "(Mới)";
            dgvGioHang.Rows.Clear();
            cboVoucher.SelectedIndex = 0;
            cboGiamGia.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            txtSDT.Clear();
            txtTienDua.Clear();
            lblTienThua.Text = "";
            TinhTongCong();
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSanPham.Rows[e.RowIndex];
            int maCtsp = Convert.ToInt32(row.Cells["MaCtsp"].Value);
            string ten = row.Cells["TenSP"].Value?.ToString();
            string size = row.Cells["Size"].Value?.ToString();
            string mau = row.Cells["Mau"].Value?.ToString();
            decimal gia = Convert.ToDecimal(row.Cells["Gia"].Value);
            int tonKho = Convert.ToInt32(row.Cells["TonKho"].Value);

            ThemVaoGioHang(maCtsp, ten, size, mau, gia, tonKho);
        }

        void ThemVaoGioHang(int maCtsp, string ten, string size, string mau, decimal gia, int tonKho)
        {
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                if (Convert.ToInt32(row.Cells["MaCtsp"].Value) == maCtsp)
                {
                    int sl = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    if (sl >= tonKho)
                    {
                        MessageBox.Show($"Đã đạt tối đa tồn kho ({tonKho})!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    sl++;
                    row.Cells["SoLuong"].Value = sl;
                    row.Cells["ThanhTien"].Value = sl * gia;
                    TinhTongCong();
                    return;
                }
            }

            if (tonKho <= 0)
            {
                MessageBox.Show("Sản phẩm đã hết hàng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgvGioHang.Rows.Add(maCtsp, ten, size, mau, 1, gia, gia, tonKho);
            TinhTongCong();
        }

        private void dgvGioHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvGioHang.Rows[e.RowIndex].IsNewRow) return;

            var row = dgvGioHang.Rows[e.RowIndex];
            string ten = row.Cells["TenSP"].Value?.ToString();
            int sl = Convert.ToInt32(row.Cells["SoLuong"].Value);
            decimal gia = Convert.ToDecimal(row.Cells["Gia"].Value);
            int tonKho = Convert.ToInt32(row.Cells["TonKho"].Value);

            var menu = new ContextMenuStrip();

            // Tiêu đề
            var title = new ToolStripMenuItem($"🛒  {ten}  |  SL: {sl}  |  Tồn: {tonKho}");
            title.Enabled = false;
            title.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Tăng
            var itemTang = new ToolStripMenuItem("➕  Tăng số lượng");
            itemTang.Click += (s, ev) =>
            {
                if (sl >= tonKho)
                {
                    MessageBox.Show($"Không đủ tồn kho (tối đa {tonKho})!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sl++;
                row.Cells["SoLuong"].Value = sl;
                row.Cells["ThanhTien"].Value = sl * gia;
                TinhTongCong();
            };

            // Giảm
            var itemGiam = new ToolStripMenuItem("➖  Giảm số lượng");
            itemGiam.Click += (s, ev) =>
            {
                if (sl <= 1)
                {
                    MessageBox.Show("Số lượng tối thiểu là 1!\nNếu muốn xóa, hãy chọn 'Xóa sản phẩm'.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sl--;
                row.Cells["SoLuong"].Value = sl;
                row.Cells["ThanhTien"].Value = sl * gia;
                TinhTongCong();
            };

            // Nhập tay
            var itemNhap = new ToolStripMenuItem("✏️  Nhập số lượng...");
            itemNhap.Click += (s, ev) =>
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Nhập số lượng mới (tối đa {tonKho}):", "Tùy chỉnh số lượng", sl.ToString());
                if (string.IsNullOrWhiteSpace(input)) return;
                if (!int.TryParse(input, out int slMoi) || slMoi <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (slMoi > tonKho)
                {
                    MessageBox.Show($"Vượt quá tồn kho ({tonKho})!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                sl = slMoi;
                row.Cells["SoLuong"].Value = sl;
                row.Cells["ThanhTien"].Value = sl * gia;
                TinhTongCong();
            };

            // Xóa
            var itemXoa = new ToolStripMenuItem("🗑️  Xóa sản phẩm");
            itemXoa.ForeColor = Color.Red;
            itemXoa.Click += (s, ev) =>
            {
                if (MessageBox.Show($"Xóa \"{ten}\" khỏi giỏ hàng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvGioHang.Rows.Remove(row);
                    TinhTongCong();
                }
            };

            menu.Items.AddRange(new ToolStripItem[]
            {
                title, new ToolStripSeparator(),
                itemTang, itemGiam, itemNhap,
                new ToolStripSeparator(), itemXoa
            });
            menu.Show(dgvGioHang, dgvGioHang.PointToClient(Cursor.Position));
        }


        decimal LayTamTinh()
        {
            decimal t = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                t += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            return t;
        }

        decimal LayTongCong()
        {
            decimal t = LayTamTinh() - _giamVoucher - _giamKhuyenMai;
            return t < 0 ? 0 : t;
        }

        void TinhTongCong()
        {
            decimal tamTinh = LayTamTinh();
            decimal tongCong = LayTongCong();
            int tongSL = 0;

            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                tongSL += Convert.ToInt32(row.Cells["SoLuong"].Value);
            }

            lblTongTien.Text = tamTinh.ToString("N0") + " đ";
            lblSoLuong.Text = tongSL.ToString();
            label13.Text = tamTinh.ToString("N0") + " đ";   // Tạm tính
            cboVoucher.Text = _giamVoucher > 0 ? "-" + _giamVoucher.ToString("N0") + " đ" : "0 đ";
            // Giảm giá KM hiển thị qua comboBox3, giá trị ra label nếu có
            lblTongCong.Text = tongCong.ToString("N0") + " đ";

            TinhTienThua();
        }

        void TinhTienThua()
        {
            decimal tongCong = LayTongCong();
            if (!decimal.TryParse(txtTienDua.Text.Replace(",", "").Replace(".", ""),
                                  out decimal tienDua))
                tienDua = 0;

            decimal thua = tienDua - tongCong;
            lblTienThua.Text = thua >= 0 ? thua.ToString("N0") + " đ" : "Chưa đủ tiền";
            lblTienThua.ForeColor = thua >= 0 ? Color.Blue : Color.Red;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        int? LayMaKhachHangTheoSDT(QlBanGiayFinalContext db)
        {
            string sdt = txtSDT.Text.Trim();
            if (string.IsNullOrWhiteSpace(sdt)) return null;

            var kh = db.KhachHangs.FirstOrDefault(k => k.SoDienThoai == sdt);
            if (kh != null) return kh.MaKh;

            var khMoi = new KhachHang { TenKhachHang = "Khách vãng lai", SoDienThoai = sdt };
            db.KhachHangs.Add(khMoi);
            db.SaveChanges();
            return khMoi.MaKh;
        }

        int? LayMaVoucher(QlBanGiayFinalContext db)
        {
            if (cboVoucher.SelectedIndex <= 0) return null;
            string maCode = cboVoucher.SelectedItem?.ToString();
            return db.Vouchers.FirstOrDefault(v => v.MaCode == maCode)?.MaVoucher;
        }
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (!ckoCash.Checked && !ckoCK.Checked)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            decimal tongCong = LayTongCong();

            if (ckoCash.Checked)
            {
                if (!decimal.TryParse(txtTienDua.Text.Replace(",", "").Replace(".", ""),
                                      out decimal tienDua) || tienDua < tongCong)
                {
                    MessageBox.Show("Tiền khách đưa chưa đủ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
            }

            try
            {
                using var db = new QlBanGiayFinalContext();

                if (_laHoaDonCho && _maHoaDonHienTai.HasValue)
                {
                    var hd = db.HoaDons.Include(x => x.HoaDonChiTiets)
                                       .First(x => x.MaHoaDon == _maHoaDonHienTai);
                    hd.TrangThai = 1;
                    hd.TongTien = tongCong;
                    hd.MaKh = LayMaKhachHangTheoSDT(db);
                    hd.MaVoucher = LayMaVoucher(db);
                    db.HoaDonChiTiets.RemoveRange(hd.HoaDonChiTiets);
                    ThemChiTietHoaDon(db, hd.MaHoaDon);
                    TruTonKho(db);
                }
                else
                {
                    var hd = new HoaDon
                    {
                        TrangThai = 1,
                        TongTien = tongCong,
                        NgayLap = DateTime.Now,
                        MaKh = LayMaKhachHangTheoSDT(db),
                        MaVoucher = LayMaVoucher(db)
                    };
                    db.HoaDons.Add(hd);
                    db.SaveChanges();
                    ThemChiTietHoaDon(db, hd.MaHoaDon);
                    TruTonKho(db);
                }

                db.SaveChanges();
                MessageBox.Show("Thanh toán thành công! ", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDon();
                LoadSanPham();
                btnthemHD_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════
        //  LƯU HÓA ĐƠN CHỜ
        // ══════════════════════════════════════════════

        private void BtnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            try
            {
                using var db = new QlBanGiayFinalContext();

                if (_laHoaDonCho && _maHoaDonHienTai.HasValue)
                {
                    var hd = db.HoaDons.Include(x => x.HoaDonChiTiets)
                                       .First(x => x.MaHoaDon == _maHoaDonHienTai);
                    hd.TongTien = LayTongCong();
                    hd.MaKh = LayMaKhachHangTheoSDT(db);
                    hd.MaVoucher = LayMaVoucher(db);
                    // TrangThai giữ nguyên = 0
                    db.HoaDonChiTiets.RemoveRange(hd.HoaDonChiTiets);
                    ThemChiTietHoaDon(db, hd.MaHoaDon);
                }
                else
                {
                    var hd = new HoaDon
                    {
                        TrangThai = 0,
                        TongTien = LayTongCong(),
                        NgayLap = DateTime.Now,
                        MaKh = LayMaKhachHangTheoSDT(db),
                        MaVoucher = LayMaVoucher(db)
                    };
                    db.HoaDons.Add(hd);
                    db.SaveChanges();
                    _maHoaDonHienTai = hd.MaHoaDon;
                    _laHoaDonCho = true;
                    lblMaHD.Text = hd.MaHoaDon.ToString();
                    ThemChiTietHoaDon(db, hd.MaHoaDon);
                }

                db.SaveChanges();
                MessageBox.Show("Đã lưu hóa đơn chờ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════
        //  HỦY HÓA ĐƠN
        // ══════════════════════════════════════════════

        private void BtnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (_laHoaDonCho && _maHoaDonHienTai.HasValue)
            {
                if (MessageBox.Show(
                    $"Đây là hóa đơn chờ (Mã: {_maHoaDonHienTai}).\nBạn có thật sự muốn hủy không?",
                    "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                try
                {
                    using var db = new QlBanGiayFinalContext();
                    var hd = db.HoaDons.Find(_maHoaDonHienTai);
                    if (hd != null) { hd.TrangThai = 2; db.SaveChanges(); }

                    MessageBox.Show("Đã hủy hóa đơn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDon();
                    btnthemHD_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // HD mới chưa lưu → chỉ reset UI
                btnthemHD_Click(null, null);
            }
        }

        // ══════════════════════════════════════════════
        //  HELPER — DB
        // ══════════════════════════════════════════════

        void ThemChiTietHoaDon(QlBanGiayFinalContext db, int maHD)
        {
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                int maCtsp = Convert.ToInt32(row.Cells["MaCtsp"].Value);
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal donGia = Convert.ToDecimal(row.Cells["Gia"].Value);
                db.HoaDonChiTiets.Add(new HoaDonChiTiet
                {
                    MaHoaDon = maHD,
                    MaCtsp = maCtsp,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = soLuong * donGia
                });
            }
        }

        void TruTonKho(QlBanGiayFinalContext db)
        {
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.IsNewRow) continue;
                int maCtsp = Convert.ToInt32(row.Cells["MaCtsp"].Value);
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                var sp = db.ChiTietSanPhams.Find(maCtsp);
                if (sp != null) sp.SoLuongTon -= soLuong;
            }
        }

        private void txtTienDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            BeginInvoke(new Action(TinhTienThua));
        }

        private void ckoCK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckoCK.Checked)
            {
                ckoCK.Checked = false; // Bỏ check ngay
                MessageBox.Show("Tính năng chuyển khoản sẽ sớm được phát triển.\nVui lòng thử lại sau!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}