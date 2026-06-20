using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormImunisasi : Form
    {
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

            // [UPDATE] Membatasi input maksimal 4 karakter untuk no antrean
            if (txtNoAntrean != null) txtNoAntrean.MaxLength = 4;
            // Menyambungkan validasi KeyPress ke txtNoAntrean
            if (txtNoAntrean != null) txtNoAntrean.KeyPress += txtNoAntrean_KeyPress;

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

            if (bindingNavigator1 != null)
            {
                bindingNavigator1.BindingSource = bindingSource;
            }
            bindingSource.CurrentChanged += bindingSource_CurrentChanged;

            LoadComboBoxes();
            LoadData();
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
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat dropdown: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DatabaseHelper.CatatLogError("FormImunisasi (Load ComboBoxes): " + ex.Message);
            }
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
                    txtStokInfo.BackColor = (Convert.ToInt32(stok) <= 5) ? Color.LightCoral : SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil info stok: " + ex.Message);
                DatabaseHelper.CatatLogError("FormImunisasi (Cek Stok Vaksin): " + ex.Message);
            }
        }

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
                FormatGrid();
                HitungTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
                DatabaseHelper.CatatLogError("FormImunisasi (Load Data): " + ex.Message);
            }
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

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;
            DataRowView rowView = (DataRowView)bindingSource.Current;
            txtIdImunisasi.Text = rowView["ID"].ToString();
            if (txtNoAntrean != null) txtNoAntrean.Text = rowView["No. Antrean"].ToString();
            string status = rowView["Status"].ToString();
            if (cmbStatus.Items.Contains(status)) cmbStatus.SelectedItem = status;
            string tglStr = rowView["Tgl Suntik"].ToString();
            if (DateTime.TryParseExact(tglStr, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tglExact))
            { if (dtpSuntik != null) dtpSuntik.Value = tglExact; }
            else if (DateTime.TryParse(tglStr, out DateTime tglFallback))
            { if (dtpSuntik != null) dtpSuntik.Value = tglFallback; }
            string namaBlt = rowView["Nama Balita"].ToString();
            foreach (ComboItem item in cmbBalita.Items) { if (item.Teks == namaBlt) { cmbBalita.SelectedItem = item; break; } }
            string namaVks = rowView["Vaksin"].ToString();
            foreach (ComboItem item in cmbVaksin.Items) { if (item.Teks == namaVks) { cmbVaksin.SelectedItem = item; break; } }
            string infoJdw = rowView["Jadwal"].ToString();
            foreach (ComboItem item in cmbJadwal.Items) { if (item.Teks == infoJdw) { cmbJadwal.SelectedItem = item; break; } }
        }

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
                        if (lblTotal != null) lblTotal.Text = "Total Transaksi Imunisasi: " + outputParam.Value.ToString();
                        this.Text = "Manajemen Transaksi Imunisasi | " + outputParam.Value.ToString() + " Data";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;
            var blt = (ComboItem)cmbBalita.SelectedItem;
            var vks = (ComboItem)cmbVaksin.SelectedItem;
            var jdw = (ComboItem)cmbJadwal.SelectedItem;

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var trx = conn.BeginTransaction())
                    {
                        try
                        {
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
                            if (cmbStatus.SelectedItem.ToString() == "Selesai")
                            {
                                using (var cmd2 = new SqlCommand("UPDATE Vaksin SET stok = stok - 1 WHERE id_vaksin = @id", conn, trx))
                                {
                                    cmd2.Parameters.AddWithValue("@id", vks.Id);
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            trx.Commit();
                            MessageBox.Show("✅ Transaksi berhasil disimpan!");
                            BersihForm();
                            LoadData();
                        }
                        catch (Exception ex) { trx.Rollback(); throw ex; }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdImunisasi.Text)) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateImunisasi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdImunisasi.Text));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdImunisasi.Text)) return;
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
                BersihForm();
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private void dgvImunisasi_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private bool Validasi()
        {
            // 1. Cek apakah ada ComboBox yang belum dipilih
            if (cmbBalita.SelectedItem == null || cmbVaksin.SelectedItem == null || cmbJadwal.SelectedItem == null)
            {
                MessageBox.Show("Harap lengkapi semua data (Balita, Vaksin, dan Jadwal)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. Cek apakah No Antrean kosong
            string noAntrean = txtNoAntrean.Text.Trim();
            if (string.IsNullOrWhiteSpace(noAntrean))
            {
                MessageBox.Show("No. Antrean wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoAntrean.Focus();
                return false;
            }

            // 3. Validasi panjang maksimal 4 karakter (menjaga agar tidak melebihi kolom database)
            if (noAntrean.Length > 4)
            {
                MessageBox.Show("No. Antrean maksimal 4 karakter!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoAntrean.Focus();
                return false;
            }

            // 4. Cek apakah tanggal suntik tidak di masa depan
            if (dtpSuntik.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Tanggal suntik tidak boleh di masa depan!", "Cacat Logika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // [UPDATE] Validasi KeyPress untuk No Antrean
        private void txtNoAntrean_KeyPress(object sender, KeyPressEventArgs e)
        {
            // [UPDATE] Mengizinkan angka, huruf (alfabet), dan tombol kontrol (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true; // Blokir jika bukan huruf atau angka
            }

            // Opsional: Jika ingin huruf otomatis menjadi huruf besar (kapital) agar rapi
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void BersihForm()
        {
            txtIdImunisasi?.Clear();
            txtNoAntrean?.Clear();
            txtStokInfo?.Clear();
            cmbStatus.SelectedIndex = 0;
            dtpSuntik.Value = DateTime.Now;
            cmbBalita.SelectedIndex = -1;
            cmbVaksin.SelectedIndex = -1;
            cmbJadwal.SelectedIndex = -1;
        }
    }

    public class ComboItem
    {
        public int Id { get; }
        public string Teks { get; }
        public ComboItem(int id, string teks) { Id = id; Teks = teks; }
        public override string ToString() => Teks;
    }
}