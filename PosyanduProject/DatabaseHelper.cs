using System;
using System.Data;
using System.Data.SqlClient;

namespace PosyanduProject
{
    public static class DatabaseHelper
    {
        private const string _connectionString =
            @"Server=LAPTOP-VL5SDNPR\GHATANHARDANNI;Database=PosyanduVaksin;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static bool TestConnection(out string pesan)
        {
            pesan = string.Empty;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    bool ok = conn.State == ConnectionState.Open;
                    pesan = ok
                        ? $"Terhubung ke: {conn.DataSource}  |  Database: {conn.Database}"
                        : "Koneksi gagal dibuka.";
                    return ok;
                }
            }
            catch (SqlException ex)
            {
                pesan = $"SQL Error ({ex.Number}): {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                pesan = $"Error: {ex.Message}";
                return false;
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable GetDataTable(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    if (parameters != null)
                        da.SelectCommand.Parameters.AddRange(parameters); // Diperbarui agar konsisten
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}