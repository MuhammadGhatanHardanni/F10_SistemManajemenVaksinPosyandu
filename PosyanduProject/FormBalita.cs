using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormBalita : Form
    {
        public FormBalita()
        {
            InitializeComponent();
        }

        private void FormBalita_Load(object sender, EventArgs e)
        {
            if (cmbJenisKelamin != null && cmbJenisKelamin.Items.Count == 0)
            {
                cmbJenisKelamin.Items.AddRange(new[] { "L - Laki-laki", "P - Perempuan" });
                cmbJenisKelamin.SelectedIndex = 0;
            }

            LoadDataOrangTua();
            TampilkanData();
        }

        private void LoadDataOrangTua()
        {
            string sql = "SELECT id_user, nama_lengkap FROM Users WHERE role = 'OrangTua'";
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(sql);
                if (cmbOrangTua != null)
                {
                    cmbOrangTua.DataSource = dt;
                    cmbOrangTua.DisplayMember = "nama_lengkap";
                    cmbOrangTua.ValueMember = "id_user";       
                    cmbOrangTua.SelectedIndex = -1;           
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data Orang Tua: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TampilkanData(string filter = "")
        {
            if (dgvBalita == null) return;

            string sql = @"SELECT id_balita AS [ID], 
                                  id_orang_tua AS [ID_Ortu], 
                                  nik AS [NIK], 
                                  nama_balita AS [Nama Balita],
                                  CONVERT(varchar, tgl_lahir, 103) AS [Tgl Lahir],
                                  jenis_kelamin AS [JK], 
                                  nama_ortu AS [Nama Ortu],
                                  DATEDIFF(MONTH, tgl_lahir, GETDATE()) AS [Umur (bln)]
                           FROM   Balita";

            try
            {
                DataTable dt;
                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " WHERE nik LIKE @f OR nama_balita LIKE @f ORDER BY nama_balita";
                    dt = DatabaseHelper.GetDataTable(sql, new SqlParameter("@f", "%" + filter.Trim() + "%"));
                }
                else
                {
                    sql += " ORDER BY nama_balita";
                    dt = DatabaseHelper.GetDataTable(sql);
                }

                dgvBalita.DataSource = dt;

                if (dgvBalita.Columns.Contains("ID")) dgvBalita.Columns["ID"].Width = 40;
                if (dgvBalita.Columns.Contains("JK")) dgvBalita.Columns["JK"].Width = 40;
                if (dgvBalita.Columns.Contains("ID_Ortu")) dgvBalita.Columns["ID_Ortu"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCari_Click(object sender, EventArgs e) => TampilkanData(txtCari.Text.Trim());
        private void btnTampilkan_Click(object sender, EventArgs e) { txtCari.Clear(); TampilkanData(); }
        private void txtCari_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) btnCari_Click(sender, e); }

        private void dgvBalita_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvBalita.Rows[e.RowIndex];

            txtIdBalita.Text = row.Cells["ID"].Value?.ToString() ?? "";
            txtNik.Text = row.Cells["NIK"].Value?.ToString() ?? "";
            txtNamaBalita.Text = row.Cells["Nama Balita"].Value?.ToString() ?? "";

            if (cmbOrangTua != null && row.Cells["ID_Ortu"].Value != DBNull.Value)
            {
                cmbOrangTua.SelectedValue = row.Cells["ID_Ortu"].Value;
            }

            string jk = row.Cells["JK"].Value?.ToString() ?? "L";
            if (cmbJenisKelamin != null) cmbJenisKelamin.SelectedIndex = (jk == "L") ? 0 : 1;

            string tglStr = row.Cells["Tgl Lahir"].Value?.ToString() ?? "";
            if (DateTime.TryParseExact(tglStr, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime tgl))
            {
                if (dtpLahir != null) dtpLahir.Value = tgl;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            int dupNik = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Balita WHERE nik = @nik",
                new SqlParameter("@nik", txtNik.Text.Trim())));

            if (dupNik > 0)
            {
                MessageBox.Show("NIK sudah terdaftar!", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string jk = cmbJenisKelamin.SelectedIndex == 0 ? "L" : "P";

                string sql = "INSERT INTO Balita (id_orang_tua, nik, nama_balita, tgl_lahir, jenis_kelamin, nama_ortu) " +
                             "VALUES (@id_ortu, @nik, @nama, @tgl, @jk, @ortu)";

                int baris = DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_ortu", Convert.ToInt32(cmbOrangTua.SelectedValue)),
                    new SqlParameter("@nik", txtNik.Text.Trim()),
                    new SqlParameter("@nama", txtNamaBalita.Text.Trim()),
                    new SqlParameter("@tgl", dtpLahir.Value.Date),
                    new SqlParameter("@jk", jk),
                    new SqlParameter("@ortu", cmbOrangTua.Text.Trim()));

                if (baris > 0) { MessageBox.Show("Data balita berhasil ditambah!"); BersihForm(); TampilkanData(); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdBalita.Text)) { MessageBox.Show("Pilih data dulu!"); return; }
            if (!Validasi()) return;

            try
            {
                string jk = cmbJenisKelamin.SelectedIndex == 0 ? "L" : "P";

                string sql = "UPDATE Balita SET id_orang_tua=@id_ortu, nik=@nik, nama_balita=@nama, tgl_lahir=@tgl, jenis_kelamin=@jk, nama_ortu=@ortu WHERE id_balita=@id";

                int baris = DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id_ortu", Convert.ToInt32(cmbOrangTua.SelectedValue)),
                    new SqlParameter("@nik", txtNik.Text.Trim()),
                    new SqlParameter("@nama", txtNamaBalita.Text.Trim()),
                    new SqlParameter("@tgl", dtpLahir.Value.Date),
                    new SqlParameter("@jk", jk),
                    new SqlParameter("@ortu", cmbOrangTua.Text.Trim()),
                    new SqlParameter("@id", int.Parse(txtIdBalita.Text)));

                if (baris > 0) { MessageBox.Show("Data berhasil diperbarui!"); BersihForm(); TampilkanData(); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdBalita.Text)) { MessageBox.Show("Pilih data dulu!"); return; }
            if (MessageBox.Show("Yakin HAPUS data balita ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            int dipakai = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Transaksi_Imunisasi WHERE id_balita=@id",
                new SqlParameter("@id", int.Parse(txtIdBalita.Text))));

            if (dipakai > 0)
            {
                MessageBox.Show($"Balita memiliki {dipakai} riwayat imunisasi, tidak dapat dihapus.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                int baris = DatabaseHelper.ExecuteNonQuery("DELETE FROM Balita WHERE id_balita=@id", new SqlParameter("@id", int.Parse(txtIdBalita.Text)));
                if (baris > 0) { MessageBox.Show("Data berhasil dihapus!"); BersihForm(); TampilkanData(); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private bool Validasi()
        {
            if (string.IsNullOrWhiteSpace(txtNik.Text) || txtNik.Text.Trim().Length != 16)
            { MessageBox.Show("NIK harus tepat 16 digit!"); txtNik.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtNamaBalita.Text))
            { MessageBox.Show("Nama balita tidak boleh kosong!"); txtNamaBalita.Focus(); return false; }

            if (dtpLahir != null && dtpLahir.Value.Date > DateTime.Today)
            { MessageBox.Show("Tanggal lahir tidak valid (masa depan)!"); return false; }

            if (cmbOrangTua == null || cmbOrangTua.SelectedValue == null || cmbOrangTua.SelectedIndex == -1)
            { MessageBox.Show("Pilih nama orang tua terlebih dahulu!"); cmbOrangTua?.Focus(); return false; }

            return true;
        }

        private void BersihForm()
        {
            if (txtIdBalita != null) txtIdBalita.Clear();
            if (txtNik != null) txtNik.Clear();
            if (txtNamaBalita != null) txtNamaBalita.Clear();
            if (dtpLahir != null) dtpLahir.Value = DateTime.Today.AddYears(-1);
            if (cmbJenisKelamin != null) cmbJenisKelamin.SelectedIndex = 0;
            if (cmbOrangTua != null) cmbOrangTua.SelectedIndex = -1; 
            if (txtCari != null) txtCari.Clear();
        }
    }
}