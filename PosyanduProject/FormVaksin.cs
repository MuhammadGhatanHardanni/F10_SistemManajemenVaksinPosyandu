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

        

        // 5. CRUD MENGGUNAKAN STORED PROCEDURE
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
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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
            catch (Exception ex) { MessageBox.Show("Gagal mencari data: " + ex.Message); }
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
            if (string.IsNullOrWhiteSpace(txtNamaVaksin.Text))
            {
                MessageBox.Show("Nama vaksin tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }

            if (Regex.IsMatch(txtNamaVaksin.Text, @"[@#$%^&*<>]"))
            {
                MessageBox.Show("Nama vaksin tidak boleh mengandung simbol khusus (@, #, $, dll)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }

            if (string.IsNullOrWhiteSpace(txtStok.Text) || !int.TryParse(txtStok.Text, out int stok) || stok < 0)
            {
                MessageBox.Show("Stok harus berupa angka positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
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

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtNamaVaksin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) && 
                !char.IsWhiteSpace(e.KeyChar) &&
                e.KeyChar != '-')
            {
                e.Handled = true; 
            }
        }
    }
}