using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class HoaDonChiTiet
{
    public int MaHDCT { get; set; }

    public int? MaHoaDon { get; set; }

    public int? MaCTSP { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual ChiTietSanPham? MaCTSPNavigation { get; set; }

    public virtual HoaDon? MaHoaDonNavigation { get; set; }
}
