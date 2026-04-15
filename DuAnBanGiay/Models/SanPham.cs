using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class SanPham
{
    public int MaSanPham { get; set; }

    public string TenSp { get; set; } = null!;

    public int? MaThuongHieu { get; set; }

    public int? MaTheLoai { get; set; }

    public int? NhaCungCap { get; set; }

    public int? ChatLieu { get; set; }

    public int? TrangThai { get; set; }

    public virtual ChatLieu? ChatLieuNavigation { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual TheLoai? MaTheLoaiNavigation { get; set; }

    public virtual ThuongHieu? MaThuongHieuNavigation { get; set; }

    public virtual NhaCungCap? NhaCungCapNavigation { get; set; }
}
