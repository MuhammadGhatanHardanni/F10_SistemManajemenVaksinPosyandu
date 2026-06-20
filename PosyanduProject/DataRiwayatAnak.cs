using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosyanduProject
{
    public class DataRiwayatAnak
    {
        // Bagian Header (Data Diri Anak)
        public string NIK { get; set; }
        public string Nama_Anak { get; set; }
        public string Nama_Ibu { get; set; }
        public string Tanggal_Lahir { get; set; }

        // Bagian Detail (Riwayat Imunisasi)
        public string Tanggal_Suntik { get; set; }
        public string Nama_Vaksin { get; set; }
        public string Berat_Badan { get; set; }
        public string Tinggi_Badan { get; set; }
        public string Nama_Petugas { get; set; }
    }
}