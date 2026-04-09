using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanGiay.DB
{
    public class DBConnect
    {
        public static SqlConnection GetConnection()
        {
            string conn = @"Data Source=MINH\SQLEXPRESS;Initial Catalog=QL_BanGiay_Final;Integrated Security=True";
            return new SqlConnection(conn);
        }
    }
}
