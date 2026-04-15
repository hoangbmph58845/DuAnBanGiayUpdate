using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class ChiTietSanPham
{
    public int MaCtsp { get; set; }

    public int MaSanPham { get; set; }

    public int MaMau { get; set; }

    public int MaKichThuoc { get; set; }

    public decimal GiaBan { get; set; }

    public int SoLuongTon { get; set; }

    public int? TrangThai { get; set; }

    public virtual ICollection<CtspKm> CtspKms { get; set; } = new List<CtspKm>();

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual KichThuoc MaKichThuocNavigation { get; set; } = null!;

    public virtual Mau MaMauNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
