using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class TheLoai
{
    public int MaTheLoai { get; set; }

    public string TenTheLoai { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
