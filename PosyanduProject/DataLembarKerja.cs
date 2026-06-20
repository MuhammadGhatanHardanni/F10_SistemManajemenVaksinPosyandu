using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosyanduProject
{
    public class DataLembarKerja
    {
        // Bagian Header (Informasi Jadwal)
        public string Tanggal_Pelaksanaan { get; set; }
        public string Lokasi { get; set; }
        public string Keterangan { get; set; }

        // Bagian Details (Daftar Anak & Antrean)
        public string No_Antrean { get; set; }
        public string Nama_Balita { get; set; }
        public string Nama_Vaksin { get; set; }
        public string Status { get; set; }
    }
}