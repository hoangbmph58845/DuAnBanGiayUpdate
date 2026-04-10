using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class KichThuoc
{
    public int MaKichThuoc { get; set; }

    public int SoSize { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}
