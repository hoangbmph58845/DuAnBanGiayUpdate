using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class Voucher
{
    public int MaVoucher { get; set; }

    public string? MaCode { get; set; }

    public decimal? SoTienGiam { get; set; }

    public decimal? DieuKienGiam { get; set; }

    public int? TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
