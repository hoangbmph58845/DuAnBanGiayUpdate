namespace DuAnBanGiay.Models;

internal sealed class SanPhamRow
{
    public int MaSanPham { get; init; }
    public string TenSP { get; init; } = "";
    public int? MaThuongHieu { get; init; }
    public string ThuongHieu { get; init; } = "";
    public int? MaTheLoai { get; init; }
    public string TheLoai { get; init; } = "";
    /// <summary>FK tới NhaCungCap.MaNCC; cột trên bảng SanPham là NhaCungCap.</summary>
    public int? MaNhaCungCap { get; init; }
    public string TenNCC { get; init; } = "";
    /// <summary>FK tới ChatLieu.MaChatLieu; cột trên bảng SanPham là ChatLieu.</summary>
    public int? MaChatLieu { get; init; }
    public string TenChatLieu { get; init; } = "";
    public int TrangThai { get; init; }
    public string TrangThaiHienThi => TrangThaiBanHienThi.LayChu(TrangThai);
    public int TongTon { get; init; }
}
