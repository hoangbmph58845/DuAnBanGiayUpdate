using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class CTSP_KM
{
    public int MaCTSP { get; set; }

    public int MaKhuyenMai { get; set; }

    public int? TrangThai { get; set; }

    public virtual ChiTietSanPham MaCTSPNavigation { get; set; } = null!;

    public virtual KhuyenMai MaKhuyenMaiNavigation { get; set; } = null!;
}
