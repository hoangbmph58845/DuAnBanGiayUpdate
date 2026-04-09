using DuAnBanGiay.Data;
using DuAnBanGiay.Models;
using Microsoft.Data.SqlClient;
using static DuAnBanGiay.Models.TrangThaiBan;

namespace DuAnBanGiay.Repositories;

internal sealed class SanPhamRepository
{
    public List<SanPhamRow> Search(string? keyword)
    {
        var kw = (keyword ?? "").Trim();
        var chiLayBienTheDangBan = (int)DangBan;

        var sql = $@"
SELECT
    sp.MaSanPham,
    sp.TenSP,
    sp.MaThuongHieu,
    ISNULL(th.TenThuongHieu, N'') AS ThuongHieu,
    sp.MaTheLoai,
    ISNULL(tl.TenTheLoai, N'') AS TheLoai,
    sp.NhaCungCap,
    ISNULL(ncc.TenNCC, N'') AS TenNCC,
    sp.ChatLieu,
    ISNULL(cl.TenChatLieu, N'') AS TenChatLieu,
    sp.TrangThai,
    ISNULL(SUM(ct.SoLuongTon), 0) AS TongTon
FROM SanPham sp
LEFT JOIN ThuongHieu th ON th.MaThuongHieu = sp.MaThuongHieu
LEFT JOIN TheLoai tl ON tl.MaTheLoai = sp.MaTheLoai
LEFT JOIN NhaCungCap ncc ON ncc.MaNCC = sp.NhaCungCap
LEFT JOIN ChatLieu cl ON cl.MaChatLieu = sp.ChatLieu
LEFT JOIN ChiTietSanPham ct ON ct.MaSanPham = sp.MaSanPham AND ct.TrangThai = {chiLayBienTheDangBan}
WHERE (@kw = N'' OR sp.TenSP LIKE N'%' + @kw + N'%' OR CONVERT(NVARCHAR(20), sp.MaSanPham) LIKE N'%' + @kw + N'%')
GROUP BY
    sp.MaSanPham, sp.TenSP, sp.MaThuongHieu, th.TenThuongHieu,
    sp.MaTheLoai, tl.TenTheLoai, sp.NhaCungCap, ncc.TenNCC,
    sp.ChatLieu, cl.TenChatLieu, sp.TrangThai
ORDER BY sp.MaSanPham DESC;";

        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@kw", kw);
        using var r = cmd.ExecuteReader();
        var list = new List<SanPhamRow>();
        while (r.Read())
        {
            list.Add(new SanPhamRow
            {
                MaSanPham = r.GetInt32(0),
                TenSP = r.GetString(1),
                MaThuongHieu = r.IsDBNull(2) ? null : r.GetInt32(2),
                ThuongHieu = r.GetString(3),
                MaTheLoai = r.IsDBNull(4) ? null : r.GetInt32(4),
                TheLoai = r.GetString(5),
                MaNhaCungCap = r.IsDBNull(6) ? null : r.GetInt32(6),
                TenNCC = r.GetString(7),
                MaChatLieu = r.IsDBNull(8) ? null : r.GetInt32(8),
                TenChatLieu = r.GetString(9),
                TrangThai = r.IsDBNull(10) ? 0 : r.GetInt32(10),
                TongTon = r.IsDBNull(11) ? 0 : r.GetInt32(11),
            });
        }

        return list;
    }

    public int Insert(string tenSp, int? maThuongHieu, int? maTheLoai, int? maNcc, int? maChatLieu, int trangThai)
    {
        const string sql = @"
INSERT INTO SanPham(TenSP, MaThuongHieu, MaTheLoai, NhaCungCap, ChatLieu, TrangThai)
OUTPUT INSERTED.MaSanPham
VALUES(@TenSP, @MaThuongHieu, @MaTheLoai, @NhaCungCap, @ChatLieu, @TrangThai);";

        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@TenSP", tenSp);
        cmd.Parameters.AddWithValue("@MaThuongHieu", (object?)maThuongHieu ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@MaTheLoai", (object?)maTheLoai ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@NhaCungCap", (object?)maNcc ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ChatLieu", (object?)maChatLieu ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
        return (int)cmd.ExecuteScalar()!;
    }

    public void Update(int maSanPham, string tenSp, int? maThuongHieu, int? maTheLoai, int? maNcc, int? maChatLieu, int trangThai)
    {
        const string sql = @"
UPDATE SanPham
SET TenSP = @TenSP,
    MaThuongHieu = @MaThuongHieu,
    MaTheLoai = @MaTheLoai,
    NhaCungCap = @NhaCungCap,
    ChatLieu = @ChatLieu,
    TrangThai = @TrangThai
WHERE MaSanPham = @MaSanPham;";

        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
        cmd.Parameters.AddWithValue("@TenSP", tenSp);
        cmd.Parameters.AddWithValue("@MaThuongHieu", (object?)maThuongHieu ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@MaTheLoai", (object?)maTheLoai ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@NhaCungCap", (object?)maNcc ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@ChatLieu", (object?)maChatLieu ?? DBNull.Value);
        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
        cmd.ExecuteNonQuery();
    }

    public void Delete(int maSanPham)
    {
        var sql = $"UPDATE SanPham SET TrangThai = {(int)NgungBan} WHERE MaSanPham = @MaSanPham;";
        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
        cmd.ExecuteNonQuery();
    }
}
