using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormCetakLembar : Form
    {
        // Variabel untuk menyimpan ID Jadwal yang dikirim dari form sebelumnya
        private int idJadwalTerpilih;

        // Constructor diubah agar bisa menerima parameter idJadwal
        public FormCetakLembar(int idJadwal)
        {
            InitializeComponent();
            this.idJadwalTerpilih = idJadwal;

            // Mengaitkan event Load secara manual
            this.Load += new EventHandler(FormCetakLembar_Load);
        }

        private void FormCetakLembar_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Memanggil Stored Procedure yang sudah kita buat di database
                    using (SqlCommand cmd = new SqlCommand("sp_CetakLembarKerja", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Memasukkan parameter ID Jadwal
                        cmd.Parameters.AddWithValue("@id_jadwal", idJadwalTerpilih);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dtLembar = new DataTable();
                            da.Fill(dtLembar);

                            // Memanggil file ReportLembarKerja.rpt yang sudah Anda desain
                            ReportLembarKerja report = new ReportLembarKerja();

                            // Memasukkan data dari database ke dalam report
                            report.SetDataSource(dtLembar);

                            // Menampilkan report ke layar Viewer
                            // Pastikan nama CrystalReportViewer di Toolbox Anda adalah crvLembar
                            crvLembar.ReportSource = report;
                            crvLembar.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat lembar kerja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseHelper.CatatLogError("FormCetakLembar: " + ex.Message);
            }
        }
    }
}