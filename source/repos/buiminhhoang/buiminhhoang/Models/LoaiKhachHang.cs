using System;
using System.Collections.Generic;

namespace buiminhhoang.Models;

public partial class LoaiKhachHang
{
    public string MaLoai { get; set; } = null!;

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();
}
