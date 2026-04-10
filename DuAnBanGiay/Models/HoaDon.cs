using System;
using System.Collections.Generic;

namespace DuAnBanGiay.Models;

public partial class HoaDon
{
    public int MaHoaDon { get; set; }

    public int? MaKh { get; set; }

    public int? MaVoucher { get; set; }

    public DateTime? NgayLap { get; set; }

    public decimal? TongTien { get; set; }

    public int? TrangThai { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual Voucher? MaVoucherNavigation { get; set; }
}
