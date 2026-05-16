using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormBalita : Form
    {
        private DataTable dtBalita = new DataTable();

        public FormBalita()
        {
            InitializeComponent();
        }

        private void FormBalita_Load(object sender, EventArgs e)
        {
            if (txtIdBalita != null) txtIdBalita.ReadOnly = true;
            if (txtNik != null) txtNik.MaxLength = 16;
            if (txtNamaBalita != null) txtNamaBalita.MaxLength = 100;

            if (dtpLahir != null)
            {
                dtpLahir.MaxDate = DateTime.Today;
                dtpLahir.MinDate = DateTime.Today.AddYears(-5);
            }

            if (cmbJenisKelamin != null && cmbJenisKelamin.Items.Count == 0)
            {
                cmbJenisKelamin.Items.AddRange(new[] { "L - Laki-laki", "P - Perempuan" });
                cmbJenisKelamin.SelectedIndex = 0;
            }


            LoadDataOrangTua();
        }

        private void LoadDataOrangTua()
        {
            try
            {
                DataTable dt = DatabaseHelper.GetDataTable("SELECT id_user, nama_lengkap FROM Users WHERE role = 'OrangTua'");
                if (cmbOrangTua != null)
                {
                    cmbOrangTua.DataSource = dt;
                    cmbOrangTua.DisplayMember = "nama_lengkap";
                    cmbOrangTua.ValueMember = "id_user";
                    cmbOrangTua.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal memuat data Orang Tua: " + ex.Message); }
        }


        // CRUD MENGGUNAKAN STORED PROCEDURE
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertBalita", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_ortu", Convert.ToInt32(cmbOrangTua.SelectedValue));
                        cmd.Parameters.AddWithValue("@nik", txtNik.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNamaBalita.Text.Trim());
                        cmd.Parameters.AddWithValue("@tgl", dtpLahir.Value.Date);
                        cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.SelectedIndex == 0 ? "L" : "P");
                        cmd.Parameters.AddWithValue("@ortu", cmbOrangTua.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data balita berhasil ditambah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("NIK sudah terdaftar!", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Error Database: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdBalita.Text)) { MessageBox.Show("Pilih data dulu dari tabel!"); return; }
            if (!Validasi()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateBalita", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdBalita.Text));
                        cmd.Parameters.AddWithValue("@nik", txtNik.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNamaBalita.Text.Trim());
                        cmd.Parameters.AddWithValue("@tgl", dtpLahir.Value.Date);
                        cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.SelectedIndex == 0 ? "L" : "P");
                        cmd.Parameters.AddWithValue("@ortu", cmbOrangTua.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) MessageBox.Show("NIK sudah digunakan balita lain!", "Duplikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Error Database: " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdBalita.Text)) { MessageBox.Show("Pilih data dulu!"); return; }
            if (MessageBox.Show("Yakin HAPUS data balita ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteBalita", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdBalita.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) MessageBox.Show("Akses Ditolak: Balita memiliki riwayat imunisasi/pertumbuhan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchBalita", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", txtCari.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtBalita = new DataTable();
                            da.Fill(dtBalita);
                            bindingSource.DataSource = dtBalita;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal mencari data: " + ex.Message); }
        }

        // VALIDASI
        private void btnTampilkan_Click(object sender, EventArgs e) { txtCari.Clear(); LoadData(); }
        private void txtCari_KeyDown(object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) btnCari_Click(sender, e); }
        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private void dgvBalita_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private bool Validasi()
        {
            if (string.IsNullOrWhiteSpace(txtNik.Text) || txtNik.Text.Trim().Length != 16)
            { MessageBox.Show("NIK harus tepat 16 digit!"); txtNik.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtNamaBalita.Text))
            { MessageBox.Show("Nama balita tidak boleh kosong!"); txtNamaBalita.Focus(); return false; }

            if (Regex.IsMatch(txtNamaBalita.Text, @"[@#$%^&*<>]"))
            { MessageBox.Show("Nama balita tidak boleh mengandung simbol khusus!"); return false; }

            if (cmbOrangTua == null || cmbOrangTua.SelectedIndex == -1)
            { MessageBox.Show("Pilih nama orang tua terlebih dahulu!"); cmbOrangTua?.Focus(); return false; }

            return true;
        }

        private void BersihForm()
        {
            if (txtIdBalita != null) txtIdBalita.Clear();
            if (txtNik != null) txtNik.Clear();
            if (txtNamaBalita != null) txtNamaBalita.Clear();
            if (txtCari != null) txtCari.Clear();

            if (dtpLahir != null) dtpLahir.Value = DateTime.Today.AddYears(-1);
            if (cmbJenisKelamin != null) cmbJenisKelamin.SelectedIndex = 0;
            if (cmbOrangTua != null) cmbOrangTua.SelectedIndex = -1;
        }

        private void txtNik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtNamaBalita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\'' && e.KeyChar != '-')
                e.Handled = true;
        }
    }
}