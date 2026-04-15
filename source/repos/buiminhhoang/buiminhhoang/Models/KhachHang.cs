using System;
using System.Collections.Generic;

namespace buiminhhoang.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string Ten { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string? Email { get; set; }

    public string MaLoaiKhach { get; set; } = null!;

    public virtual LoaiKhachHang MaLoaiKhachNavigation { get; set; } = null!;
}
