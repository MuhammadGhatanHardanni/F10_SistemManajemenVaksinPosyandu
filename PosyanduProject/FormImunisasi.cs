using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormImunisasi : Form
    {
        public FormImunisasi()
        {
            InitializeComponent();
        }

        private void FormImunisasi_Load(object sender, EventArgs e)
        {
            // [REVISI] Mengunci ID agar tidak bisa diedit manual
            if (txtIdImunisasi != null) txtIdImunisasi.ReadOnly = true;

            // [FITUR BARU] Mengunci TextBox Info Stok agar tidak bisa diedit manual oleh user
            if (txtStokInfo != null) txtStokInfo.ReadOnly = true;

            // [REVISI TANGGAL] Membatasi pemilihan tahun di kalender
            if (dtpSuntik != null)
            {
                // Memberikan kelonggaran 1 tahun ke depan agar DateTime.Now beserta jamnya tidak error.
                // Input masa depan tetap akan ditolak oleh fungsi Validasi().
                dtpSuntik.MaxDate = DateTime.Today.AddYears(1);
                dtpSuntik.MinDate = DateTime.Today.AddYears(-5); // Minimal mundur 5 tahun (usia maksimal balita)
            }

            if (cmbStatus != null && cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.AddRange(new[] { "Terdaftar", "Selesai", "Batal" });
                cmbStatus.SelectedIndex = 0;
            }

            LoadComboBoxes();
            TampilkanData();
        }

        private void LoadComboBoxes()
        {
            if (cmbBalita == null || cmbVaksin == null || cmbJadwal == null) return;

            try
            {
                cmbBalita.Items.Clear();
                var dtB = DatabaseHelper.GetDataTable("SELECT id_balita, nama_balita FROM Balita ORDER BY nama_balita");
                foreach (DataRow r in dtB.Rows)
                    cmbBalita.Items.Add(new ComboItem(Convert.ToInt32(r["id_balita"]), r["nama_balita"].ToString()));

                cmbVaksin.Items.Clear();
                // [REVISI] Hanya ambil vaksin yang stoknya > 0
                var dtV = DatabaseHelper.GetDataTable("SELECT id_vaksin, nama_vaksin, stok FROM Vaksin WHERE stok > 0 ORDER BY nama_vaksin");
                foreach (DataRow r in dtV.Rows)
                    // Hapus info stok dari nama vaksin di dropdown, karena sekarang akan ditampilkan di txtStokInfo
                    cmbVaksin.Items.Add(new ComboItem(Convert.ToInt32(r["id_vaksin"]), r["nama_vaksin"].ToString()));

                cmbJadwal.Items.Clear();
                var dtJ = DatabaseHelper.GetDataTable("SELECT id_jadwal, CONVERT(varchar,tgl_pelaksanaan,106) + ' - ' + lokasi AS info FROM Jadwal_Posyandu ORDER BY tgl_pelaksanaan DESC");
                foreach (DataRow r in dtJ.Rows)
                    cmbJadwal.Items.Add(new ComboItem(Convert.ToInt32(r["id_jadwal"]), r["info"].ToString()));

                if (cmbBalita.Items.Count > 0) cmbBalita.SelectedIndex = -1;
                if (cmbVaksin.Items.Count > 0) cmbVaksin.SelectedIndex = -1;
                if (cmbJadwal.Items.Count > 0) cmbJadwal.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Gagal memuat dropdown: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // [FITUR BARU] Event ketika ComboBox Vaksin berubah pilihan
        private void cmbVaksin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVaksin.SelectedItem == null || txtStokInfo == null)
            {
                if (txtStokInfo != null) txtStokInfo.Clear();
                return;
            }

            try
            {
                var vks = (ComboItem)cmbVaksin.SelectedItem;
                // Ambil sisa stok vaksin langsung dari database berdasarkan ID yang dipilih
                object stok = DatabaseHelper.ExecuteScalar(
                    "SELECT stok FROM Vaksin WHERE id_vaksin = @id",
                    new SqlParameter("@id", vks.Id));

                if (stok != null)
                {
                    txtStokInfo.Text = stok.ToString() + " Dosis"; // Munculkan teks di TextBox

                    // Opsional: Beri warna merah jika stok menipis (<= 5)
                    if (Convert.ToInt32(stok) <= 5)
                        txtStokInfo.BackColor = Color.LightCoral;
                    else
                        txtStokInfo.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil info stok: " + ex.Message);
            }
        }

        private void TampilkanData(string filter = "")
        {
            if (dgvImunisasi == null) return;

            string sql = @"SELECT ti.id_imunisasi AS [ID], 
                                  b.nama_balita AS [Nama Balita], 
                                  v.nama_vaksin AS [Vaksin],
                                  CONVERT(varchar,j.tgl_pelaksanaan,106) + ' - ' + j.lokasi AS [Jadwal],
                                  ti.no_antrean AS [No. Antrean], 
                                  CONVERT(varchar,ti.tgl_suntik,103) AS [Tgl Suntik], 
                                  ti.status AS [Status]
                           FROM Transaksi_Imunisasi ti
                           JOIN Balita b ON b.id_balita = ti.id_balita
                           JOIN Vaksin v ON v.id_vaksin = ti.id_vaksin
                           JOIN Jadwal_Posyandu j ON j.id_jadwal = ti.id_jadwal";

            try
            {
                DataTable dt;
                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " WHERE b.nama_balita LIKE @f ORDER BY ti.tgl_suntik DESC";
                    dt = DatabaseHelper.GetDataTable(sql, new SqlParameter("@f", "%" + filter.Trim() + "%"));
                }
                else
                {
                    sql += " ORDER BY ti.tgl_suntik DESC";
                    dt = DatabaseHelper.GetDataTable(sql);
                }

                dgvImunisasi.DataSource = dt;

                foreach (DataGridViewRow row in dgvImunisasi.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    if (status == "Selesai") row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (status == "Batal") row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            var blt = (ComboItem)cmbBalita.SelectedItem;
            var vks = (ComboItem)cmbVaksin.SelectedItem;
            var jdw = (ComboItem)cmbJadwal.SelectedItem;

            // [REVISI] Cek duplikasi: Apakah anak ini sudah terdaftar imunisasi yang sama di jadwal yang sama?
            int cek = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Transaksi_Imunisasi WHERE id_balita=@b AND id_vaksin=@v AND id_jadwal=@j",
                new SqlParameter("@b", blt.Id),
                new SqlParameter("@v", vks.Id),
                new SqlParameter("@j", jdw.Id)));

            if (cek > 0)
            {
                MessageBox.Show("Anak tersebut sudah terdaftar untuk vaksin ini pada jadwal yang dipilih!", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSuccess = false; // Flag penanda transaksi sukses

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var trx = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlInsert = @"INSERT INTO Transaksi_Imunisasi (id_balita, id_vaksin, id_jadwal, id_petugas, no_antrean, tgl_suntik, status) 
                                                 VALUES (@b, @v, @j, @p, @no, @tgl, @st)";

                            using (var cmd1 = new SqlCommand(sqlInsert, conn, trx))
                            {
                                cmd1.Parameters.AddWithValue("@b", blt.Id);
                                cmd1.Parameters.AddWithValue("@v", vks.Id);
                                cmd1.Parameters.AddWithValue("@j", jdw.Id);
                                cmd1.Parameters.AddWithValue("@p", SessionManager.IdUser > 0 ? SessionManager.IdUser : 1);
                                cmd1.Parameters.AddWithValue("@no", txtNoAntrean.Text.Trim());
                                cmd1.Parameters.AddWithValue("@tgl", dtpSuntik.Value); // Menyimpan beserta jamnya
                                cmd1.Parameters.AddWithValue("@st", cmbStatus.SelectedItem.ToString());
                                cmd1.ExecuteNonQuery();
                            }

                            // [REVISI] Hanya potong stok jika statusnya 'Selesai'
                            if (cmbStatus.SelectedItem.ToString() == "Selesai")
                            {
                                using (var cmd2 = new SqlCommand("UPDATE Vaksin SET stok = stok - 1 WHERE id_vaksin = @id", conn, trx))
                                {
                                    cmd2.Parameters.AddWithValue("@id", vks.Id);
                                    cmd2.ExecuteNonQuery();
                                }
                            }

                            trx.Commit();
                            isSuccess = true; // Tandai bahwa database sudah aman
                        }
                        catch (Exception ex)
                        {
                            trx.Rollback();
                            MessageBox.Show("Transaksi Gagal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Koneksi Gagal: " + ex.Message); }

            // Pindahkan proses bersih-bersih form ke luar blok transaksi try-catch
            if (isSuccess)
            {
                MessageBox.Show("✅ Transaksi imunisasi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadComboBoxes(); // Muat ulang combo box agar info stok terbaru terupdate
                TampilkanData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdImunisasi.Text)) { MessageBox.Show("Pilih data di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                string sql = "UPDATE Transaksi_Imunisasi SET status=@st WHERE id_imunisasi=@id";
                DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@st", cmbStatus.SelectedItem.ToString()),
                    new SqlParameter("@id", int.Parse(txtIdImunisasi.Text)));

                MessageBox.Show("✅ Status berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TampilkanData();
                LoadComboBoxes(); // Refresh stok di form jika terjadi perubahan
            }
            catch (Exception ex) { MessageBox.Show("Error Update: " + ex.Message); }
        }

        private void dgvImunisasi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvImunisasi.Rows[e.RowIndex];
            txtIdImunisasi.Text = row.Cells["ID"].Value?.ToString() ?? "";

            string status = row.Cells["Status"].Value?.ToString();
            if (cmbStatus.Items.Contains(status)) cmbStatus.SelectedItem = status;
        }

        private void btnCari_Click(object sender, EventArgs e) => TampilkanData(txtCari.Text.Trim());
        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private bool Validasi()
        {
            if (cmbBalita.SelectedItem == null || cmbVaksin.SelectedItem == null || cmbJadwal.SelectedItem == null)
            {
                MessageBox.Show("Harap pilih Balita, Vaksin, dan Jadwal!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNoAntrean.Text))
            {
                MessageBox.Show("No. Antrean wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // [REVISI TANGGAL 1] Mencegah input tanggal di masa depan secara manual
            if (dtpSuntik.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Tanggal suntik tidak boleh di masa depan!", "Cacat Logika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // [REVISI TANGGAL 2] Validasi agar tanggal suntik tidak mendahului tanggal lahir Balita
            var blt = (ComboItem)cmbBalita.SelectedItem;
            try
            {
                object tglLahirObj = DatabaseHelper.ExecuteScalar(
                    "SELECT tgl_lahir FROM Balita WHERE id_balita = @id",
                    new SqlParameter("@id", blt.Id));

                if (tglLahirObj != null)
                {
                    DateTime tglLahir = Convert.ToDateTime(tglLahirObj);
                    if (dtpSuntik.Value.Date < tglLahir.Date)
                    {
                        MessageBox.Show($"Cacat Logika! Balita ini lahir pada {tglLahir:dd/MM/yyyy}. Tidak bisa disuntik sebelum lahir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal memverifikasi umur balita: " + ex.Message); }

            return true;
        }

        // [REVISI] Hanya angka untuk nomor antrean
        private void txtNoAntrean_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void BersihForm()
        {
            if (txtIdImunisasi != null) txtIdImunisasi.Clear();
            if (txtNoAntrean != null) txtNoAntrean.Clear();
            if (txtStokInfo != null) txtStokInfo.Clear(); // Bersihkan juga kotak stok
            if (cmbStatus != null) cmbStatus.SelectedIndex = 0;

            // [KEMBALIKAN KE NOW] Sekarang jam akan muncul dengan benar tanpa menyebabkan crash
            if (dtpSuntik != null) dtpSuntik.Value = DateTime.Now;

            if (cmbBalita != null) cmbBalita.SelectedIndex = -1;
            if (cmbVaksin != null) cmbVaksin.SelectedIndex = -1;
            if (cmbJadwal != null) cmbJadwal.SelectedIndex = -1;
        }
    }

    // [PENTING] Class pendukung untuk menyimpan ID di ComboBox
    public class ComboItem
    {
        public int Id { get; }
        public string Teks { get; }
        public ComboItem(int id, string teks) { Id = id; Teks = teks; }
        public override string ToString() => Teks;
    }
}