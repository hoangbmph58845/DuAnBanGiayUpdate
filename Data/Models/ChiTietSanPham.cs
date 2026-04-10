using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class ChiTietSanPham
{
    public int MaCTSP { get; set; }

    public int MaSanPham { get; set; }

    public int MaMau { get; set; }

    public int MaKichThuoc { get; set; }

    public decimal GiaNhap { get; set; }

    public decimal GiaBan { get; set; }

    public int SoLuongTon { get; set; }

    public int? TrangThai { get; set; }

    public virtual ICollection<CTSP_KM> CTSP_KMs { get; set; } = new List<CTSP_KM>();

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual Size MaKichThuocNavigation { get; set; } = null!;

    public virtual Mau MaMauNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
