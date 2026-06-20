using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormCetakKIA : Form
    {
        // Variabel untuk menyimpan NIK yang dikirim
        private string filterNIK;

        // Constructor diubah untuk menerima parameter NIK
        public FormCetakKIA(string nik)
        {
            InitializeComponent();
            this.filterNIK = nik;

            // Mengaitkan event Load saat form terbuka
            this.Load += new EventHandler(FormCetakKIA_Load);
        }

        private void FormCetakKIA_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Memanggil Stored Procedure untuk Riwayat Anak
                    using (SqlCommand cmd = new SqlCommand("sp_CetakBukuKIA", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Memasukkan parameter NIK ke dalam kueri
                        cmd.Parameters.AddWithValue("@NIK_Anak", filterNIK);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dtKIA = new DataTable();
                            da.Fill(dtKIA);

                            // Memanggil file ReportKIA.rpt yang sudah Anda desain
                            ReportKIA report = new ReportKIA();

                            // Memasukkan data ke dalam report
                            report.SetDataSource(dtKIA);

                            // crvKIA adalah nama CrystalReportViewer di Toolbox (Pastikan Name-nya sudah diubah)
                            crvKIA.ReportSource = report;
                            crvKIA.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat KIA: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseHelper.CatatLogError("FormCetakKIA: " + ex.Message);
            }
        }
    }
}