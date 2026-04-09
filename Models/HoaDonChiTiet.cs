using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class HoaDonChiTiet
{
    public int MaHdct { get; set; }

    public int? MaHoaDon { get; set; }

    public int? MaCtsp { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual ChiTietSanPham? MaCtspNavigation { get; set; }

    public virtual HoaDon? MaHoaDonNavigation { get; set; }
}
