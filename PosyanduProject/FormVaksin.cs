using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormVaksin : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtVaksin = new DataTable();

        public FormVaksin()
        {
            InitializeComponent();
        }

        private void FormVaksin_Load(object sender, EventArgs e)
        {
            if (txtIdVaksin != null) txtIdVaksin.ReadOnly = true;
            if (txtNamaVaksin != null) txtNamaVaksin.MaxLength = 50;
            if (txtDeskripsi != null) txtDeskripsi.MaxLength = 255;
            if (txtStok != null) txtStok.MaxLength = 5;

            if (dtpKedaluwarsa != null)
            {
                dtpKedaluwarsa.MaxDate = DateTime.Today.AddYears(10);
            }

            // BINDING NAVIGATOR
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
                    string query = "SELECT * FROM vwVaksinPublic";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtVaksin = new DataTable();
                        da.Fill(dtVaksin);

                        bindingSource.DataSource = dtVaksin;
                        if (dgvVaksin != null) dgvVaksin.DataSource = bindingSource;
                    }
                }

                FormatGrid(); // Warnai stok yang mau habis
                HitungTotal(); // Panggil SP Count
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormVaksin (Load Data): " + ex.Message);
            }
        }

        private void FormatGrid()
        {
            if (dgvVaksin == null) return;

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

        // IMPLEMENTASI BINDING
        private void BindControls()
        {
            txtIdVaksin.DataBindings.Clear();
            txtNamaVaksin.DataBindings.Clear();
            txtStok.DataBindings.Clear();
            txtDeskripsi.DataBindings.Clear();

            // Binding harus sesuai dengan nama kolom (alias) di VIEW vwVaksinPublic
            txtIdVaksin.DataBindings.Add("Text", bindingSource, "ID");
            txtNamaVaksin.DataBindings.Add("Text", bindingSource, "Vaksin");
            txtStok.DataBindings.Add("Text", bindingSource, "Stok");
            txtDeskripsi.DataBindings.Add("Text", bindingSource, "Deskripsi");
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;

            DataRowView rowView = (DataRowView)bindingSource.Current;

            // Mengisi ID agar validasi Update/Hapus berjalan lancar
            txtIdVaksin.Text = rowView["ID"].ToString();

            // Update Tanggal Kedaluwarsa secara manual
            string tglStr = rowView["Tgl Expired"].ToString();
            if (DateTime.TryParse(tglStr, out DateTime tgl))
            {
                if (dtpKedaluwarsa != null) dtpKedaluwarsa.Value = tgl;
            }
        }

        // SP COUNT 
        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CountVaksin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        if (lblTotal != null)
                        {
                            lblTotal.Text = "Total Jenis Vaksin: " + outputParam.Value.ToString();
                        }
                        this.Text = "Manajemen Vaksin | " + outputParam.Value.ToString() + " Jenis Vaksin";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormVaksin (Hitung Total): " + ex.Message);
            }
        }

        // CRUD MENGGUNAKAN STORED PROCEDURE
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertVaksin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nama", txtNamaVaksin.Text.Trim());
                        cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text.Trim()));
                        cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@tgl", dtpKedaluwarsa.Value.Date);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data vaksin berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihkanForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormVaksin (Tambah): " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVaksin.Text))
            {
                MessageBox.Show("Pilih data dulu dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            if (!ValidasiInput()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateVaksin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdVaksin.Text));
                        cmd.Parameters.AddWithValue("@nama", txtNamaVaksin.Text.Trim());
                        cmd.Parameters.AddWithValue("@stok", int.Parse(txtStok.Text.Trim()));
                        cmd.Parameters.AddWithValue("@deskripsi", txtDeskripsi.Text.Trim());
                        cmd.Parameters.AddWithValue("@tgl", dtpKedaluwarsa.Value.Date);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihkanForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormVaksin (Update): " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVaksin.Text)) { MessageBox.Show("Pilih data dulu dari tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Yakin ingin menghapus vaksin ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteVaksin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdVaksin.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihkanForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) MessageBox.Show("Vaksin sedang digunakan di data imunisasi, tidak bisa dihapus!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Error: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormVaksin (Hapus): " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchVaksin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", txtCari.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtVaksin = new DataTable();
                            da.Fill(dtVaksin);
                            bindingSource.DataSource = dtVaksin;
                        }
                    }
                }
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari data: " + ex.Message);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormVaksin (Cari): " + ex.Message);
            }
        }

        private void btnTampilkan_Click(object sender, EventArgs e) { txtCari.Clear(); LoadData(); }
        private void txtCari_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) btnCari_Click(sender, e); }
        private void btnBersih_Click(object sender, EventArgs e) => BersihkanForm();

        private void dgvVaksin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Dikosongkan karena sudah diambil alih oleh bindingSource_CurrentChanged
        }

        private bool ValidasiInput()
        {
            string namaVaksin = txtNamaVaksin.Text.Trim();

            if (string.IsNullOrWhiteSpace(namaVaksin))
            {
                MessageBox.Show("Nama vaksin tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaVaksin.Focus();
                return false;
            }

            if (namaVaksin.Length < 3)
            {
                MessageBox.Show("Nama vaksin terlalu pendek! Minimal 3 karakter.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaVaksin.Focus();
                return false;
            }

            if (!Regex.IsMatch(namaVaksin, @"[a-zA-Z]"))
            {
                MessageBox.Show("Nama vaksin tidak valid! Harus mengandung huruf alfabet.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaVaksin.Focus();
                return false;
            }

            if (Regex.IsMatch(namaVaksin, @"[@#$%^&*<>]"))
            {
                MessageBox.Show("Nama vaksin tidak boleh mengandung simbol khusus (@, #, $, dll)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaVaksin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStok.Text) || !int.TryParse(txtStok.Text, out int stok) || stok < 0)
            {
                MessageBox.Show("Stok harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStok.Focus();
                return false;
            }

            if (dtpKedaluwarsa != null)
            {
                if (dtpKedaluwarsa.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("Tanggal kedaluwarsa tidak valid (masa lalu)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                TimeSpan selisihWaktu = dtpKedaluwarsa.Value.Date - DateTime.Today;
                if (selisihWaktu.TotalDays <= 30)
                {
                    DialogResult konfirmasi = MessageBox.Show(
                        "Perhatian: Vaksin ini akan kedaluwarsa dalam waktu kurang dari 1 bulan (" + selisihWaktu.TotalDays + " hari).\n\nApakah Anda yakin tetap ingin menyimpannya?",
                        "Peringatan Kedaluwarsa Dekat",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (konfirmasi == DialogResult.No) return false;
                }
            }

            return true;
        }

        private void BersihkanForm()
        {
            if (txtIdVaksin != null) txtIdVaksin.Clear();
            if (txtNamaVaksin != null) txtNamaVaksin.Clear();
            if (txtStok != null) txtStok.Clear();
            if (txtDeskripsi != null) txtDeskripsi.Clear();
            if (txtCari != null) txtCari.Clear();

            if (dtpKedaluwarsa != null) dtpKedaluwarsa.Value = DateTime.Today.AddMonths(6);
        }

        // Sesuai kesepakatan, KeyPress dibebaskan agar tidak kaku, pertahanan dijaga penuh oleh ValidasiInput (Regex)
        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNamaVaksin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}