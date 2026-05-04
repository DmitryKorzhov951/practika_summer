using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalApp
{
    static class Db
    {
        public static string ConnStr =>
            ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString;

        public static DataTable Load(string sql)
        {
            var dt = new DataTable();
            using var conn = new SqlConnection(ConnStr);
            using var da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
            return dt;
        }
    }
}
