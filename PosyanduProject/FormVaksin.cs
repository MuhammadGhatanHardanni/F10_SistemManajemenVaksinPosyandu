using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormVaksin : Form
    {
        public FormVaksin()
        {
            InitializeComponent();
        }

        private void FormVaksin_Load(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void TampilkanData(string filter = "")
        {
            if (dgvVaksin == null) return;

            string sql = @"SELECT id_vaksin AS [ID], 
                                  nama_vaksin AS [Nama Vaksin], 
                                  stok AS [Stok],
                                  CONVERT(varchar,tgl_kedaluwarsa,103) AS [Tgl Kedaluwarsa],
                                  deskripsi AS [Deskripsi]
                           FROM Vaksin";

            try
            {
                DataTable dt;

                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " WHERE nama_vaksin LIKE @filter ORDER BY nama_vaksin";
                    dt = DatabaseHelper.GetDataTable(sql, new SqlParameter("@filter", "%" + filter + "%"));
                }
                else
                {
                    sql += " ORDER BY nama_vaksin";
                    dt = DatabaseHelper.GetDataTable(sql);
                }

                dgvVaksin.DataSource = dt;

                if (dgvVaksin.Columns.Contains("ID")) dgvVaksin.Columns["ID"].Width = 50;
                if (dgvVaksin.Columns.Contains("Stok")) dgvVaksin.Columns["Stok"].Width = 60;

                foreach (DataGridViewRow row in dgvVaksin.Rows)
                {
                    if (row.Cells["Stok"].Value != null &&
                        int.TryParse(row.Cells["Stok"].Value.ToString(), out int stok) && stok < 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCari_Click(object sender, EventArgs e) => TampilkanData(txtCari.Text.Trim());
        private void btnTampilkan_Click(object sender, EventArgs e) { txtCari.Clear(); TampilkanData(); }
        private void txtCari_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) btnCari_Click(sender, e); }

        private void dgvVaksin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvVaksin.Rows[e.RowIndex];

            txtIdVaksin.Text = row.Cells["ID"].Value?.ToString() ?? "";
            txtNamaVaksin.Text = row.Cells["Nama Vaksin"].Value?.ToString() ?? "";
            txtStok.Text = row.Cells["Stok"].Value?.ToString() ?? "";
            txtDeskripsi.Text = row.Cells["Deskripsi"].Value?.ToString() ?? "";

            string tglStr = row.Cells["Tgl Kedaluwarsa"].Value?.ToString() ?? "";
            if (DateTime.TryParseExact(tglStr, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime tgl))
            {
                if (dtpKedaluwarsa != null) dtpKedaluwarsa.Value = tgl;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            int dupCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Vaksin WHERE nama_vaksin = @nama",
                new SqlParameter("@nama", txtNamaVaksin.Text.Trim())));

            if (dupCount > 0)
            {
                MessageBox.Show("Nama vaksin sudah ada di database!", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO Vaksin (nama_vaksin, stok, tgl_kedaluwarsa, deskripsi) VALUES (@nama, @stok, @tgl, @desk)";
                int baris = DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@nama", txtNamaVaksin.Text.Trim()),
                    new SqlParameter("@stok", int.Parse(txtStok.Text.Trim())),
                    new SqlParameter("@tgl", dtpKedaluwarsa.Value.Date),
                    new SqlParameter("@desk", txtDeskripsi.Text.Trim()));

                if (baris > 0) { MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information); BersihkanForm(); TampilkanData(); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVaksin.Text)) { MessageBox.Show("Pilih data dulu dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!ValidasiInput()) return;

            try
            {
                string sql = "UPDATE Vaksin SET nama_vaksin=@nama, stok=@stok, tgl_kedaluwarsa=@tgl, deskripsi=@desk WHERE id_vaksin=@id";
                int baris = DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@nama", txtNamaVaksin.Text.Trim()),
                    new SqlParameter("@stok", int.Parse(txtStok.Text.Trim())),
                    new SqlParameter("@tgl", dtpKedaluwarsa.Value.Date),
                    new SqlParameter("@desk", txtDeskripsi.Text.Trim()),
                    new SqlParameter("@id", int.Parse(txtIdVaksin.Text)));

                if (baris > 0) { MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information); BersihkanForm(); TampilkanData(); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVaksin.Text)) { MessageBox.Show("Pilih data dulu dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Yakin ingin menghapus vaksin ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int dipakai = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Transaksi_Imunisasi WHERE id_vaksin = @id",
                new SqlParameter("@id", int.Parse(txtIdVaksin.Text))));

            if (dipakai > 0) { MessageBox.Show("Vaksin sedang digunakan di data imunisasi, tidak bisa dihapus!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                int baris = DatabaseHelper.ExecuteNonQuery("DELETE FROM Vaksin WHERE id_vaksin = @id", new SqlParameter("@id", int.Parse(txtIdVaksin.Text)));
                if (baris > 0) { MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information); BersihkanForm(); TampilkanData(); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnBersih_Click(object sender, EventArgs e) => BersihkanForm();

        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(txtNamaVaksin.Text)) { MessageBox.Show("Nama vaksin tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }
            if (string.IsNullOrWhiteSpace(txtStok.Text) || !int.TryParse(txtStok.Text, out int stok) || stok < 0) { MessageBox.Show("Stok harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            if (dtpKedaluwarsa != null && dtpKedaluwarsa.Value.Date < DateTime.Today) { MessageBox.Show("Tanggal kedaluwarsa tidak valid (masa lalu)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            return true;
        }

        private void BersihkanForm()
        {
            if (txtIdVaksin != null) txtIdVaksin.Clear();
            if (txtNamaVaksin != null) txtNamaVaksin.Clear();
            if (txtStok != null) txtStok.Clear();
            if (txtDeskripsi != null) txtDeskripsi.Clear();
            if (dtpKedaluwarsa != null) dtpKedaluwarsa.Value = DateTime.Today.AddMonths(6);
            if (txtCari != null) txtCari.Clear();
        }
    }
}