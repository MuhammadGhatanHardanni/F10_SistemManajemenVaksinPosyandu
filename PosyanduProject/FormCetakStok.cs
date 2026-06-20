using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormCetakStok : Form
    {
        public FormCetakStok()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormCetakStok_Load);
        }

        private void FormCetakStok_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Kita gunakan query langsung ke View yang sudah ada
                    string query = "SELECT * FROM vwLaporanStokVaksin";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dtStok = new DataTable();
                            da.Fill(dtStok);

                            var listStok = new System.Collections.Generic.List<DataStok>();
                            foreach (DataRow row in dtStok.Rows)
                            {
                                listStok.Add(new DataStok
                                {
                                    Nama_Vaksin = row["Nama Vaksin"].ToString(),
                                    Stok_Tersisa = Convert.ToInt32(row["Stok Tersisa"]),
                                    Kedaluwarsa = row["Kedaluwarsa"].ToString(),
                                    Keterangan = row["Keterangan"].ToString()
                                });
                            }

                            // Memanggil file ReportStok.rpt yang sudah Anda buat
                            ReportStok report = new ReportStok();
                            report.SetDataSource(listStok); // Passing List, bukan DataTable
                            crvViewer.ReportSource = report;

                            crvViewer.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan cetak stok: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseHelper.CatatLogError("FormCetakStok: " + ex.Message);
            }
        }
    }
}
