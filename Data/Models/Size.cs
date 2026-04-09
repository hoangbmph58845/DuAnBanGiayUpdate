using System;
using System.Collections.Generic;

namespace WinFormsDashboard.Data.Models;

public partial class Size
{
    public int MaKichThuoc { get; set; }

    public int SoSize { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}
