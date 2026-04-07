namespace DuAnBanGiay.Models;

/// <summary>
/// Giá trị lưu trong cột TrangThai (SanPham, ChiTietSanPham, ...). DB vẫn dùng int 0/1.
/// </summary>
internal enum TrangThaiBan : int
{
    NgungBan = 0,
    DangBan = 1,
}

internal static class TrangThaiBanHienThi
{
    public static string LayChu(TrangThaiBan t) => t switch
    {
        TrangThaiBan.DangBan => "Đang bán",
        _ => "Ngưng bán",
    };

    public static string LayChu(int giaTriDb) => LayChu((TrangThaiBan)giaTriDb);
}
