using System;
using System.Data;
using System.Data.SqlClient;

namespace PosyanduProject
{
    public static class DatabaseHelper
    {
        // ======================================================================================
        // [PERSIAPAN UCP 3 - CLIENT SERVER] 
        // Jika besok aplikasi dijalankan di laptop teman, matikan (comment) connection string 
        // yang atas, lalu hidupkan connection string yang bawah. Ganti IP dan Password-nya!
        // ======================================================================================

        // 1. Connection String Lokal (Dipakai saat di laptop Anda sendiri)
        private const string _connectionString =
            @"Server=LAPTOP-VL5SDNPR\GHATANHARDANNI;Database=SistemManajemenPosyandu;Integrated Security=True;";

        // 2. Connection String Jaringan / Client-Server (Dipakai saat di-install di laptop teman)
        // private const string _connectionString = 
        //    @"Data Source=192.168.x.x; Initial Catalog=SistemManajemenPosyandu; User ID=sa; Password=PasswordSQLAnda;";

        // ======================================================================================

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Fungsi ini dibutuhkan oleh form-form yang menggunakan Disconnected Architecture (DataAdapter)
        public static string GetConnectionString()
        {
            return _connectionString;
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
                // [BARU] Catat error ke database jika gagal tes koneksi (opsional)
                CatatLogError($"Tes Koneksi Gagal: {ex.Message}");
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
                        da.SelectCommand.Parameters.AddRange(parameters);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // ==============================================================
        // [FITUR BARU UCP 3] FUNGSI PENCATAT ERROR KE DATABASE (LOGGING)
        // Sesuai dengan Modul Praktikum - Error Handling & Logging
        // ==============================================================
        public static void CatatLogError(string pesanError)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    string query = "INSERT INTO LogError (waktu, pesan_error) VALUES (GETDATE(), @pesan)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Memasukkan pesan error dari try-catch ke dalam tabel LogError
                        cmd.Parameters.AddWithValue("@pesan", pesanError);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Blok catch ini sengaja DIBIARKAN KOSONG.
                // Tujuannya: Jika fungsi pencatat Log ini sendiri yang gagal (misal koneksi terputus total), 
                // aplikasi tidak akan ikut nge-crash / freeze.
            }
        }
    }
}