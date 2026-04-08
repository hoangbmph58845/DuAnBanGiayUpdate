using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class Mau
{
    public int MaMau { get; set; }

    public string TenMau { get; set; } = null!;

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}
