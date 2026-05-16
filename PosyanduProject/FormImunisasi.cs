using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormImunisasi : Form
    {
        // 1. Variabel Disconnected Architecture (Modul 8)
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtImunisasi = new DataTable();

        public FormImunisasi()
        {
            InitializeComponent();
        }

        private void FormImunisasi_Load(object sender, EventArgs e)
        {
            if (txtIdImunisasi != null) txtIdImunisasi.ReadOnly = true;
            if (txtStokInfo != null) txtStokInfo.ReadOnly = true;

            if (dtpSuntik != null)
            {
                dtpSuntik.MaxDate = DateTime.Today.AddYears(1);
                dtpSuntik.MinDate = DateTime.Today.AddYears(-5);
            }

            if (cmbStatus != null && cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.AddRange(new[] { "Terdaftar", "Selesai", "Batal" });
                cmbStatus.SelectedIndex = 0;
            }

            // === PENGATURAN BINDING NAVIGATOR (Modul 8) ===
            if (bindingNavigator1 != null)
            {
                bindingNavigator1.BindingSource = bindingSource;
            }
            bindingSource.CurrentChanged += bindingSource_CurrentChanged;
            // ==============================================

            LoadComboBoxes();
            LoadData(); // Memanggil VIEW (Modul 9)
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
                var dtV = DatabaseHelper.GetDataTable("SELECT id_vaksin, nama_vaksin, stok FROM Vaksin WHERE stok > 0 ORDER BY nama_vaksin");
                foreach (DataRow r in dtV.Rows)
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
                object stok = DatabaseHelper.ExecuteScalar(
                    "SELECT stok FROM Vaksin WHERE id_vaksin = @id",
                    new SqlParameter("@id", vks.Id));

                if (stok != null)
                {
                    txtStokInfo.Text = stok.ToString() + " Dosis";

                    if (Convert.ToInt32(stok) <= 5)
                        txtStokInfo.BackColor = Color.LightCoral;
                    else
                        txtStokInfo.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal mengambil info stok: " + ex.Message); }
        }

        // ==========================================
        // 2. LOAD DATA MENGGUNAKAN VIEW (Modul 9)
        // ==========================================
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    string query = "SELECT * FROM vwImunisasiPublic";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtImunisasi = new DataTable();
                        da.Fill(dtImunisasi);

                        bindingSource.DataSource = dtImunisasi;
                        if (dgvImunisasi != null) dgvImunisasi.DataSource = bindingSource;
                    }
                }

                FormatGrid(); // Panggil fungsi mewarnai tabel
                HitungTotal(); // Panggil SP Count
            }
            catch (Exception ex) { MessageBox.Show("Gagal memuat data: " + ex.Message); }
        }

        private void FormatGrid()
        {
            if (dgvImunisasi == null) return;
            foreach (DataGridViewRow row in dgvImunisasi.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                if (status == "Selesai") row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (status == "Batal") row.DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        // === FUNGSI SAKTI: Sinkronisasi Class ComboItem saat Navigator digeser ===
        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;

            DataRowView rowView = (DataRowView)bindingSource.Current;

            txtIdImunisasi.Text = rowView["ID"].ToString();
            if (txtNoAntrean != null) txtNoAntrean.Text = rowView["No. Antrean"].ToString();

            string status = rowView["Status"].ToString();
            if (cmbStatus.Items.Contains(status)) cmbStatus.SelectedItem = status;

            string tglStr = rowView["Tgl Suntik"].ToString();

            // Membaca format tanggal beserta jamnya secara spesifik
            if (DateTime.TryParseExact(tglStr, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tglExact))
            {
                if (dtpSuntik != null) dtpSuntik.Value = tglExact;
            }
            // Fallback jika formatnya berbeda
            else if (DateTime.TryParse(tglStr, out DateTime tglFallback))
            {
                if (dtpSuntik != null) dtpSuntik.Value = tglFallback;
            }

            // Sinkronisasi ComboBox yang berisi Class ComboItem
            string namaBlt = rowView["Nama Balita"].ToString();
            foreach (ComboItem item in cmbBalita.Items) { if (item.Teks == namaBlt) { cmbBalita.SelectedItem = item; break; } }

            string namaVks = rowView["Vaksin"].ToString();
            foreach (ComboItem item in cmbVaksin.Items) { if (item.Teks == namaVks) { cmbVaksin.SelectedItem = item; break; } }

            string infoJdw = rowView["Jadwal"].ToString();
            foreach (ComboItem item in cmbJadwal.Items) { if (item.Teks == infoJdw) { cmbJadwal.SelectedItem = item; break; } }
        }

        // ==========================================
        // 4. SP COUNT DENGAN OUTPUT PARAMETER (Modul 10)
        // ==========================================
        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CountImunisasi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        if (lblTotal != null) // Pastikan lblTotal ditambahkan di Designer
                        {
                            lblTotal.Text = "Total Transaksi Imunisasi: " + outputParam.Value.ToString();
                        }
                        this.Text = "Manajemen Transaksi Imunisasi | " + outputParam.Value.ToString() + " Data";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal menghitung total: " + ex.Message); }
        }

        // ==========================================
        // 5. CRUD DENGAN STORED PROCEDURE & TRANSAKSI
        // ==========================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            var blt = (ComboItem)cmbBalita.SelectedItem;
            var vks = (ComboItem)cmbVaksin.SelectedItem;
            var jdw = (ComboItem)cmbJadwal.SelectedItem;

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

            bool isSuccess = false;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var trx = conn.BeginTransaction()) // LOGIKA TRANSAKSI ANDA DIPERTAHANKAN!
                    {
                        try
                        {
                            // [PERBAIKAN] Nama parameter disamakan persis dengan di SQL Server
                            using (var cmd1 = new SqlCommand("sp_InsertImunisasi", conn, trx))
                            {
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Parameters.AddWithValue("@id_balita", blt.Id);
                                cmd1.Parameters.AddWithValue("@id_vaksin", vks.Id);
                                cmd1.Parameters.AddWithValue("@id_jadwal", jdw.Id);
                                cmd1.Parameters.AddWithValue("@id_petugas", SessionManager.IdUser > 0 ? SessionManager.IdUser : 1);
                                cmd1.Parameters.AddWithValue("@no_antrean", txtNoAntrean.Text.Trim());
                                cmd1.Parameters.AddWithValue("@tgl_suntik", dtpSuntik.Value);
                                cmd1.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                                cmd1.ExecuteNonQuery();
                            }

                            // Hanya potong stok jika statusnya 'Selesai'
                            if (cmbStatus.SelectedItem.ToString() == "Selesai")
                            {
                                using (var cmd2 = new SqlCommand("UPDATE Vaksin SET stok = stok - 1 WHERE id_vaksin = @id", conn, trx))
                                {
                                    cmd2.Parameters.AddWithValue("@id", vks.Id);
                                    cmd2.ExecuteNonQuery();
                                }
                            }

                            trx.Commit();
                            isSuccess = true;
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

            if (isSuccess)
            {
                MessageBox.Show("✅ Transaksi imunisasi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadComboBoxes();
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdImunisasi.Text)) { MessageBox.Show("Pilih data di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateImunisasi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // [PERBAIKAN] Nama parameter disamakan dengan SQL
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdImunisasi.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("✅ Status berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LoadComboBoxes();
            }
            catch (Exception ex) { MessageBox.Show("Error Update: " + ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdImunisasi.Text))
            {
                MessageBox.Show("Pilih data dulu dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Yakin ingin menghapus data transaksi ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteImunisasi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdImunisasi.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("✅ Data transaksi berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal menghapus data: " + ex.Message); }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchImunisasi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", txtCari.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtImunisasi = new DataTable();
                            da.Fill(dtImunisasi);
                            bindingSource.DataSource = dtImunisasi;
                        }
                    }
                }
                FormatGrid();
            }
            catch (Exception ex) { MessageBox.Show("Gagal mencari data: " + ex.Message); }
        }

        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private void dgvImunisasi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Dikosongkan karena sinkronisasi sudah ditangani oleh bindingSource_CurrentChanged
        }

        private bool Validasi()
        {
            if (cmbBalita.SelectedItem == null || cmbVaksin.SelectedItem == null || cmbJadwal.SelectedItem == null)
            {
                MessageBox.Show("Harap pilih Balita, Vaksin, dan Jadwal!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }
            if (string.IsNullOrWhiteSpace(txtNoAntrean.Text))
            {
                MessageBox.Show("No. Antrean wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }
            if (dtpSuntik.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Tanggal suntik tidak boleh di masa depan!", "Cacat Logika", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }

            // Validasi umur anak
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

        private void txtNoAntrean_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void BersihForm()
        {
            // bindingSource.AddNew(); <-- HAPUS ATAU BERI GARIS MIRING PADA BARIS INI

            if (txtIdImunisasi != null) txtIdImunisasi.Clear(); // Tambahkan baris ini
            if (txtNoAntrean != null) txtNoAntrean.Clear();
            if (txtStokInfo != null) txtStokInfo.Clear();
            if (cmbStatus != null) cmbStatus.SelectedIndex = 0;
            if (dtpSuntik != null) dtpSuntik.Value = DateTime.Now;

            if (cmbBalita != null) cmbBalita.SelectedIndex = -1;
            if (cmbVaksin != null) cmbVaksin.SelectedIndex = -1;
            if (cmbJadwal != null) cmbJadwal.SelectedIndex = -1;
        }
    }

    // [DIPERTAHANKAN] Class pendukung untuk menyimpan ID di ComboBox
    public class ComboItem
    {
        public int Id { get; }
        public string Teks { get; }
        public ComboItem(int id, string teks) { Id = id; Teks = teks; }
        public override string ToString() => Teks;
    }
}