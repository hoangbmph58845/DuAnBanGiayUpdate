using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string? TenKhachHang { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
