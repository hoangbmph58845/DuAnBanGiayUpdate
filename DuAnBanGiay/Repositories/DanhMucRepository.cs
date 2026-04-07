using DuAnBanGiay.Data;
using DuAnBanGiay.Models;
using Microsoft.Data.SqlClient;

namespace DuAnBanGiay.Repositories;

internal sealed class DanhMucRepository
{
    public List<DanhMucItem> GetThuongHieu()
        => GetList("SELECT MaThuongHieu AS Id, TenThuongHieu AS Name FROM ThuongHieu ORDER BY TenThuongHieu");

    public List<DanhMucItem> GetTheLoai()
        => GetList("SELECT MaTheLoai AS Id, TenTheLoai AS Name FROM TheLoai ORDER BY TenTheLoai");

    public List<DanhMucItem> GetNhaCungCap()
        => GetList("SELECT MaNCC AS Id, TenNCC AS Name FROM NhaCungCap ORDER BY TenNCC");

    public List<DanhMucItem> GetChatLieu()
        => GetList("SELECT MaChatLieu AS Id, TenChatLieu AS Name FROM ChatLieu ORDER BY TenChatLieu");

    public List<DanhMucItem> GetMau()
        => GetList("SELECT MaMau AS Id, TenMau AS Name FROM Mau ORDER BY TenMau");

    public List<DanhMucItem> GetSize()
        => GetList("SELECT MaKichThuoc AS Id, CONVERT(NVARCHAR(50), SoSize) AS Name FROM Size ORDER BY SoSize");

    private static List<DanhMucItem> GetList(string sql)
    {
        using var conn = Db.OpenConnection();
        using var cmd = new SqlCommand(sql, conn);
        using var r = cmd.ExecuteReader();
        var list = new List<DanhMucItem>();
        while (r.Read())
        {
            list.Add(new DanhMucItem
            {
                Id = r.GetInt32(0),
                Name = r.GetString(1),
            });
        }
        return list;
    }
}

