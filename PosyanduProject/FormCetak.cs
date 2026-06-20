using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormCetak : Form
    {
        private int filterBulan;
        private int filterTahun;

        // Constructor diubah agar bisa menerima data Bulan dan Tahun dari FormLaporan
        public FormCetak(int bulan, int tahun)
        {
            InitializeComponent();
            this.filterBulan = bulan;
            this.filterTahun = tahun;

            // Mengaitkan event Load secara manual agar pasti tereksekusi
            this.Load += new EventHandler(FormCetak_Load);
        }

        private void FormCetak_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Memanggil Stored Procedure yang sama persis seperti di FormLaporan
                    using (SqlCommand cmd = new SqlCommand("sp_FilterCakupanImunisasi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@bln", filterBulan);
                        cmd.Parameters.AddWithValue("@thn", filterTahun);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dtCakupan = new DataTable();
                            da.Fill(dtCakupan);

                            // Mengubah spasi menjadi underscore agar persis seperti di Class DataCakupan
                            if (dtCakupan.Columns.Contains("Nama Anak"))
                            {
                                dtCakupan.Columns["Nama Anak"].ColumnName = "Nama_Anak";
                            }

                            // Memanggil file ReportCakupan.rpt yang sudah Anda desain tadi
                            ReportCakupan report = new ReportCakupan();

                            // Memasukkan data dari database ke dalam report
                            report.SetDataSource(dtCakupan);

                            // crvViewer adalah nama CrystalReportViewer di Toolbox (Pastikan Name-nya sudah diubah)
                            crvViewer.ReportSource = report;
                            crvViewer.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan cetak: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseHelper.CatatLogError("FormCetak: " + ex.Message);
            }
        }
    }
}