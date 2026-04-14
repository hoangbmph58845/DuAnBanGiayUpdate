using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class NhaCungCap
{
    public int MaNCC { get; set; }

    public string TenNCC { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
