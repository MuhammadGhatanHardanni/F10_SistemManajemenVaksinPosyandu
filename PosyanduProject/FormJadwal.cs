using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormJadwal : Form
    {
        public FormJadwal()
        {
            InitializeComponent();
        }

        private void FormJadwal_Load(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void TampilkanData(string filter = "")
        {
            if (dgvJadwal == null) return;

            string sql = @"SELECT id_jadwal AS [ID], 
                                  CONVERT(varchar, tgl_pelaksanaan, 106) AS [Tgl Pelaksanaan], 
                                  lokasi AS [Lokasi], 
                                  keterangan AS [Keterangan]
                           FROM   Jadwal_Posyandu";

            try
            {
                DataTable dt;
                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " WHERE lokasi LIKE @f ORDER BY tgl_pelaksanaan DESC";
                    dt = DatabaseHelper.GetDataTable(sql, new SqlParameter("@f", "%" + filter.Trim() + "%"));
                }
                else
                {
                    sql += " ORDER BY tgl_pelaksanaan DESC";
                    dt = DatabaseHelper.GetDataTable(sql);
                }

                dgvJadwal.DataSource = dt;

                if (dgvJadwal.Columns.Contains("ID")) dgvJadwal.Columns["ID"].Width = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCari_Click(object sender, EventArgs e) => TampilkanData(txtCari.Text.Trim());

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            txtCari.Clear();
            TampilkanData();
        }

        private void txtCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnCari_Click(sender, e);
        }

        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvJadwal.Rows[e.RowIndex];

            txtIdJadwal.Text = row.Cells["ID"].Value?.ToString() ?? "";
            txtLokasi.Text = row.Cells["Lokasi"].Value?.ToString() ?? "";
            txtKeterangan.Text = row.Cells["Keterangan"].Value?.ToString() ?? "";

            string tglStr = row.Cells["Tgl Pelaksanaan"].Value?.ToString() ?? "";
            if (DateTime.TryParseExact(tglStr, "dd MMM yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime tgl))
            {
                if (dtpPelaksanaan != null) dtpPelaksanaan.Value = tgl;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            try
            {
                string sql = "INSERT INTO Jadwal_Posyandu (tgl_pelaksanaan, lokasi, keterangan) VALUES (@tgl, @lok, @ket)";
                int baris = DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@tgl", dtpPelaksanaan.Value.Date),
                    new SqlParameter("@lok", txtLokasi.Text.Trim()),
                    new SqlParameter("@ket", txtKeterangan.Text.Trim()));

                if (baris > 0)
                {
                    MessageBox.Show("✅ Jadwal berhasil ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BersihForm();
                    TampilkanData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdJadwal.Text)) { Warn(); return; }
            if (!Validasi()) return;
            if (MessageBox.Show("Ubah jadwal ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                string sql = "UPDATE Jadwal_Posyandu SET tgl_pelaksanaan=@tgl, lokasi=@lok, keterangan=@ket WHERE id_jadwal=@id";
                int baris = DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@tgl", dtpPelaksanaan.Value.Date),
                    new SqlParameter("@lok", txtLokasi.Text.Trim()),
                    new SqlParameter("@ket", txtKeterangan.Text.Trim()),
                    new SqlParameter("@id", int.Parse(txtIdJadwal.Text)));

                if (baris > 0)
                {
                    MessageBox.Show("✅ Jadwal berhasil diperbarui!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BersihForm();
                    TampilkanData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdJadwal.Text)) { Warn(); return; }
            if (MessageBox.Show("HAPUS jadwal ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            int ada = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Transaksi_Imunisasi WHERE id_jadwal=@id",
                new SqlParameter("@id", int.Parse(txtIdJadwal.Text))));

            if (ada > 0)
            {
                MessageBox.Show("Jadwal sudah dipakai dalam transaksi, tidak bisa dihapus.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int baris = DatabaseHelper.ExecuteNonQuery("DELETE FROM Jadwal_Posyandu WHERE id_jadwal=@id", new SqlParameter("@id", int.Parse(txtIdJadwal.Text)));
                if (baris > 0)
                {
                    MessageBox.Show("✅ Jadwal berhasil dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BersihForm();
                    TampilkanData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private bool Validasi()
        {
            if (string.IsNullOrWhiteSpace(txtLokasi.Text))
            {
                MessageBox.Show("Lokasi tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLokasi.Focus();
                return false;
            }
            return true;
        }

        private void Warn() => MessageBox.Show("Pilih data dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void BersihForm()
        {
            txtIdJadwal?.Clear();
            txtLokasi?.Clear();
            txtKeterangan?.Clear();
            if (dtpPelaksanaan != null) dtpPelaksanaan.Value = DateTime.Today;
            txtCari?.Clear();
        }
    }
}