using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class CtspKm
{
    public int MaCtsp { get; set; }

    public int MaKhuyenMai { get; set; }

    public int? TrangThai { get; set; }

    public virtual ChiTietSanPham MaCtspNavigation { get; set; } = null!;

    public virtual KhuyenMai MaKhuyenMaiNavigation { get; set; } = null!;
}
