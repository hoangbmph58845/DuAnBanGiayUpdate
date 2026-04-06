namespace DuAnBanGiay.Models;

internal sealed class ChiTietSanPhamRow
{
    public int MaCTSP { get; init; }
    public int MaSanPham { get; init; }
    public string TenSP { get; init; } = "";
    public int MaMau { get; init; }
    public string Mau { get; init; } = "";
    public int MaKichThuoc { get; init; }
    public int SoSize { get; init; }
    public decimal GiaBan { get; init; }
    public int SoLuongTon { get; init; }
    public int TrangThai { get; init; }
    public string TrangThaiHienThi => TrangThaiBanHienThi.LayChu(TrangThai);
}
