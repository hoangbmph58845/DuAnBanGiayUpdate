using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class KhuyenMai
{
    public int MaKhuyenMai { get; set; }

    public string? TenKhuyenMai { get; set; }

    public int? LoaiGiam { get; set; }

    public decimal? GiaTriGiam { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public int? TrangThai { get; set; }

    public virtual ICollection<CTSP_KM> CTSP_KMs { get; set; } = new List<CTSP_KM>();
}
