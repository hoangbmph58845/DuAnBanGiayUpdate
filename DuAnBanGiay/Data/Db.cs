using System.Configuration;
using Microsoft.Data.SqlClient;

namespace DuAnBanGiay.Data;

internal static class Db
{
    public static SqlConnection OpenConnection()
    {
        var cs = ConfigurationManager.ConnectionStrings["QLBanGiay"]?.ConnectionString;
        if (string.IsNullOrWhiteSpace(cs))
        {
            throw new InvalidOperationException(
                "Thiếu connection string 'QLBanGiay' trong App.config.");
        }

        var conn = new SqlConnection(cs);
        conn.Open();
        return conn;
    }
}

