using DuAnBanGiay.Data;
using DuAnBanGiay.Models;
using Microsoft.Data.SqlClient;
using static DuAnBanGiay.Models.TrangThaiBan;

namespace DuAnBanGiay.Repositories;

internal sealed class ChiTietSanPhamRepository
{
    public List<ChiTietSanPhamRow> GetBySanPham(int maSanPham)
    {
        const string sql = @"
SELECT
    ct.MaCTSP,
    ct.MaSanPham,
    sp.TenSP,
    ct.MaMau,
    m.TenMau,
    ct.MaKichThuoc,
    s.SoSize,
    ct.GiaBan,
    ct.SoLuongTon,
    ct.TrangThai
FROM ChiTietSanPham ct
INNER JOIN SanPham sp ON sp.MaSanPham = ct.MaSanPham
INNER JOIN Mau m ON m.MaMau = ct.MaMau
INNER JOIN Size s ON s.MaKichThuoc = ct.MaKichThuoc
WHERE ct.MaSanPham = @MaSanPham
ORDER BY ct.MaCTSP DESC;";

        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
        using var r = cmd.ExecuteReader();

        var list = new List<ChiTietSanPhamRow>();
        while (r.Read())
        {
            list.Add(new ChiTietSanPhamRow
            {
                MaCTSP = r.GetInt32(0),
                MaSanPham = r.GetInt32(1),
                TenSP = r.GetString(2),
                MaMau = r.GetInt32(3),
                Mau = r.GetString(4),
                MaKichThuoc = r.GetInt32(5),
                SoSize = r.GetInt32(6),
                GiaBan = r.GetDecimal(7),
                SoLuongTon = r.GetInt32(8),
                TrangThai = r.GetInt32(9),
            });
        }
        return list;
    }

    public int Insert(int maSanPham, int maMau, int maKichThuoc, decimal giaBan, int soLuongTon, int trangThai)
    {
        const string sql = @"
INSERT INTO ChiTietSanPham(MaSanPham, MaMau, MaKichThuoc, GiaBan, SoLuongTon, TrangThai)
OUTPUT INSERTED.MaCTSP
VALUES(@MaSanPham, @MaMau, @MaKichThuoc, @GiaBan, @SoLuongTon, @TrangThai);";

        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
        cmd.Parameters.AddWithValue("@MaMau", maMau);
        cmd.Parameters.AddWithValue("@MaKichThuoc", maKichThuoc);
        cmd.Parameters.AddWithValue("@GiaBan", giaBan);
        cmd.Parameters.AddWithValue("@SoLuongTon", soLuongTon);
        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
        return (int)cmd.ExecuteScalar()!;
    }

    public void Update(int maCtsp, int maSanPham, int maMau, int maKichThuoc, decimal giaBan, int soLuongTon, int trangThai)
    {
        const string sql = @"
UPDATE ChiTietSanPham
SET MaSanPham = @MaSanPham,
    MaMau = @MaMau,
    MaKichThuoc = @MaKichThuoc,
    GiaBan = @GiaBan,
    SoLuongTon = @SoLuongTon,
    TrangThai = @TrangThai
WHERE MaCTSP = @MaCTSP;";

        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@MaCTSP", maCtsp);
        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
        cmd.Parameters.AddWithValue("@MaMau", maMau);
        cmd.Parameters.AddWithValue("@MaKichThuoc", maKichThuoc);
        cmd.Parameters.AddWithValue("@GiaBan", giaBan);
        cmd.Parameters.AddWithValue("@SoLuongTon", soLuongTon);
        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
        cmd.ExecuteNonQuery();
    }

    public void Delete(int maCtsp)
    {
        var sql = $"UPDATE ChiTietSanPham SET TrangThai = {(int)NgungBan} WHERE MaCTSP = @MaCTSP;";
        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@MaCTSP", maCtsp);
        cmd.ExecuteNonQuery();
    }
}
