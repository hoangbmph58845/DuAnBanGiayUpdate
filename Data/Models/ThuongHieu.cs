using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class ThuongHieu
{
    public int MaThuongHieu { get; set; }

    public string TenThuongHieu { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
