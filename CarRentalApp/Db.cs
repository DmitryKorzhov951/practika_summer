using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CarRentalApp
{
    /// <summary>
    /// Простая обёртка над SqlConnection для всего приложения.
    /// </summary>
    public static class Db
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["CarRentalDB"]?.ConnectionString
            ?? @"Server=(localdb)\MSSQLLocalDB;Database=CarRentalDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection Open()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public static DataTable LoadTable(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = Open())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (var da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
            }
            return dt;
        }

        public static int Exec(string sql, params SqlParameter[] parameters)
        {
            using (var conn = Open())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
