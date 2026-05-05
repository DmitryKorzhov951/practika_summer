using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalApp
{
    /// <summary>Простой доступ к БД.</summary>
    static class Db
    {
        public static string ConnStr =>
            ConfigurationManager.ConnectionStrings["CarRentalDB"].ConnectionString;

        public static SqlConnection Open()
        {
            var c = new SqlConnection(ConnStr);
            c.Open();
            return c;
        }

        public static DataTable Load(string sql, params SqlParameter[] prms)
        {
            var dt = new DataTable();
            using var conn = new SqlConnection(ConnStr);
            using var cmd  = new SqlCommand(sql, conn);
            if (prms != null) cmd.Parameters.AddRange(prms);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static int Exec(string sql, params SqlParameter[] prms)
        {
            using var conn = new SqlConnection(ConnStr);
            conn.Open();
            using var cmd = new SqlCommand(sql, conn);
            if (prms != null) cmd.Parameters.AddRange(prms);
            return cmd.ExecuteNonQuery();
        }
    }
}
