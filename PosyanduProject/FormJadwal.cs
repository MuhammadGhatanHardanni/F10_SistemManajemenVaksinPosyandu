using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormJadwal : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtJadwal = new DataTable();

        public FormJadwal()
        {
            InitializeComponent();
        }

        private void FormJadwal_Load(object sender, EventArgs e)
        {
            if (txtIdJadwal != null) txtIdJadwal.ReadOnly = true;
            if (txtLokasi != null) txtLokasi.MaxLength = 100;
            if (txtKeterangan != null) txtKeterangan.MaxLength = 255;

            if (dtpPelaksanaan != null)
            {
                dtpPelaksanaan.MinDate = DateTime.Today.AddYears(-5);
                dtpPelaksanaan.MaxDate = DateTime.Today.AddYears(2);
            }

            if (SessionManager.Role == "OrangTua")
            {
                if (btnTambah != null) btnTambah.Visible = false;
                if (btnUpdate != null) btnUpdate.Visible = false;
                if (btnHapus != null) btnHapus.Visible = false;
                if (btnBersih != null) btnBersih.Visible = false;

                if (dtpPelaksanaan != null) dtpPelaksanaan.Visible = false;
                if (txtLokasi != null) txtLokasi.Visible = false;
                if (txtKeterangan != null) txtKeterangan.Visible = false;
                if (txtIdJadwal != null) txtIdJadwal.Visible = false;

                if (label1 != null) label1.Visible = false;
                if (label2 != null) label2.Visible = false;
                if (label3 != null) label3.Visible = false;
                if (label4 != null) label4.Visible = false;
            }

            if (bindingNavigator1 != null)
            {
                bindingNavigator1.BindingSource = bindingSource;
            }
            bindingSource.CurrentChanged += bindingSource_CurrentChanged;

            LoadData();
            BindControls();
        }

        // LOAD DATA MENGGUNAKAN VIEW
        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Mengambil data dari VIEW 
                    string query = "SELECT * FROM vwJadwalPublic";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtJadwal = new DataTable();
                        da.Fill(dtJadwal);

                        bindingSource.DataSource = dtJadwal;
                        if (dgvJadwal != null)
                        {
                            dgvJadwal.DataSource = bindingSource;
                            if (dgvJadwal.Columns.Contains("ID")) dgvJadwal.Columns["ID"].Width = 50;
                        }
                    }
                }

                HitungTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormJadwal (Load Data): " + ex.Message);
            }
        }

        // IMPLEMENTASI BINDING
        private void BindControls()
        {
            txtIdJadwal.DataBindings.Clear();
            txtLokasi.DataBindings.Clear();
            txtKeterangan.DataBindings.Clear();

            txtIdJadwal.DataBindings.Add("Text", bindingSource, "ID");
            txtLokasi.DataBindings.Add("Text", bindingSource, "Lokasi");
            txtKeterangan.DataBindings.Add("Text", bindingSource, "Keterangan");
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;

            DataRowView rowView = (DataRowView)bindingSource.Current;

            // Memasukkan ID untuk kebutuhan Update/Delete
            txtIdJadwal.Text = rowView["ID"].ToString();

            // Update Tanggal Pelaksanaan
            string tglStr = rowView["Tgl Pelaksanaan"].ToString();
            if (DateTime.TryParse(tglStr, out DateTime tgl))
            {
                if (dtpPelaksanaan != null) dtpPelaksanaan.Value = tgl;
            }
            // Fallback jika format dd MMM yyyy gagal diparse otomatis
            else if (DateTime.TryParseExact(tglStr, "dd MMM yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tglExact))
            {
                if (dtpPelaksanaan != null) dtpPelaksanaan.Value = tglExact;
            }
        }

        // 4. SP COUNT 
        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CountJadwal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        if (lblTotal != null) // Pastikan Anda sudah menambahkan lblTotal di Designer
                        {
                            lblTotal.Text = "Total Jadwal: " + outputParam.Value.ToString();
                        }
                        this.Text = "Manajemen Jadwal | " + outputParam.Value.ToString() + " Jadwal Posyandu";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormJadwal (Hitung Total): " + ex.Message);
            }
        }

        // 5. CRUD MENGGUNAKAN STORED PROCEDURE
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            if (dtpPelaksanaan.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Tidak dapat membuat jadwal untuk masa lalu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dupCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Jadwal_Posyandu WHERE tgl_pelaksanaan = @tgl AND lokasi = @lok",
                new SqlParameter("@tgl", dtpPelaksanaan.Value.Date),
                new SqlParameter("@lok", txtLokasi.Text.Trim())));

            if (dupCount > 0)
            {
                MessageBox.Show("Jadwal untuk tanggal dan lokasi tersebut sudah ada!", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertJadwal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tgl", dtpPelaksanaan.Value.Date);
                        cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text.Trim());
                        cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("✅ Jadwal berhasil ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormJadwal (Tambah): " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdJadwal.Text)) { Warn(); return; }
            if (!Validasi()) return;

            int dupCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Jadwal_Posyandu WHERE tgl_pelaksanaan = @tgl AND lokasi = @lok AND id_jadwal != @id",
                new SqlParameter("@tgl", dtpPelaksanaan.Value.Date),
                new SqlParameter("@lok", txtLokasi.Text.Trim()),
                new SqlParameter("@id", int.Parse(txtIdJadwal.Text))));

            if (dupCount > 0)
            {
                MessageBox.Show("Jadwal untuk tanggal dan lokasi tersebut bentrok dengan jadwal lain!", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Ubah jadwal ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateJadwal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdJadwal.Text));
                        cmd.Parameters.AddWithValue("@tgl", dtpPelaksanaan.Value.Date);
                        cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text.Trim());
                        cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("✅ Jadwal berhasil diperbarui!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormJadwal (Update): " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdJadwal.Text)) { Warn(); return; }
            if (MessageBox.Show("HAPUS jadwal ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteJadwal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdJadwal.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("✅ Jadwal berhasil dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) MessageBox.Show("Akses Ditolak: Jadwal sudah dipakai dalam transaksi imunisasi, tidak bisa dihapus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else MessageBox.Show("Error Database: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormJadwal (Hapus): " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchJadwal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", txtCari.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtJadwal = new DataTable();
                            da.Fill(dtJadwal);
                            bindingSource.DataSource = dtJadwal;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari data: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormJadwal (Cari): " + ex.Message);
            }
        }

        // EVENT & VALIDASI
        private void btnTampilkan_Click(object sender, EventArgs e) { txtCari.Clear(); LoadData(); }
        private void txtCari_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) btnCari_Click(sender, e); }
        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Dikosongkan karena sinkronisasi sudah ditangani oleh bindingSource_CurrentChanged
        }

        private bool Validasi()
        {
            if (string.IsNullOrWhiteSpace(txtLokasi.Text))
            {
                MessageBox.Show("Lokasi tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLokasi.Focus();
                return false;
            }

            if (Regex.IsMatch(txtLokasi.Text, @"[@#$%^&*<>]"))
            {
                MessageBox.Show("Lokasi tidak boleh mengandung simbol khusus (@, #, $, dll)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void Warn() => MessageBox.Show("Pilih data dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void BersihForm()
        {
            if (txtIdJadwal != null) txtIdJadwal.Clear();
            if (txtLokasi != null) txtLokasi.Clear();
            if (txtKeterangan != null) txtKeterangan.Clear();
            if (txtCari != null) txtCari.Clear();

            if (dtpPelaksanaan != null) dtpPelaksanaan.Value = DateTime.Today;
        }
    }
}