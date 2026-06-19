using System;

namespace PosyanduProject
{
    public static class SessionManager
    {
        public static int IdUser { get; set; }
        public static string NamaLengkap { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }  // Bidan | Petugas | OrangTua

        public static void Clear()
        {
            IdUser = 0;
            NamaLengkap = null;
            Username = null;
            Role = null;
        }

        public static bool IsAdmin => Role == "Bidan";

        public static bool IsPetugas => Role == "Petugas" || Role == "Bidan";
    }
}