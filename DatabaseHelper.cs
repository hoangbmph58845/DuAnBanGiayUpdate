using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsDashboard;

public class DatabaseHelper
{
    // Chuỗi kết nối SQL Server (Tùy chỉnh TrustServerCertificate=True cho local SQL)
    private readonly string _connectionString = @"Server=.;Database=QL_BanGiay_Final;Integrated Security=True;TrustServerCertificate=True;";

    /// <summary>
    /// Lấy dữ liệu từ database (Dùng cho SELECT)
    /// </summary>
    /// <param name="query">Câu lệnh SQL</param>
    /// <returns>DataTable chứa kết quả</returns>
    public DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Lỗi GetData: " + ex.Message);
        }
        return dt;
    }

    /// <summary>
    /// Thực thi câu lệnh SQL (Dùng cho INSERT, UPDATE, DELETE)
    /// </summary>
    /// <param name="query">Câu lệnh SQL</param>
    /// <returns>Số dòng bị ảnh hưởng hoặc -1 nếu lỗi</returns>
    public int Execute(string query)
    {
        int rowsAffected = -1;
        try
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Lỗi Execute: " + ex.Message);
        }
        return rowsAffected;
    }

    /// <summary>
    /// Kiểm tra kết nối tới cơ sở dữ liệu
    /// </summary>
    public bool CheckConnection()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}
