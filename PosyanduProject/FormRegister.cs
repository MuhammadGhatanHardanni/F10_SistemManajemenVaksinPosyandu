using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // [UX] Memastikan kolom password disamarkan saat form pertama kali dimuat
            if (txtPassword != null) txtPassword.UseSystemPasswordChar = true;
            if (txtKonfirmasi != null) txtKonfirmasi.UseSystemPasswordChar = true;
        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Harap isi semua kolom data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [VALIDASI] Mengecek panjang minimal password untuk keamanan
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password minimal harus 6 karakter!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtKonfirmasi.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKonfirmasi.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Memanggil STORED PROCEDURE Cerdas
                    using (SqlCommand cmd = new SqlCommand("sp_RegisterUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                        conn.Open();
                        // Mengambil hasil dari operasi IF EXISTS di dalam SQL Server
                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        if (result == 0)
                        {
                            // Output 0 berarti SP menemukan username duplikat
                            MessageBox.Show("Username sudah digunakan, silakan pilih yang lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                        }
                        else if (result == 1)
                        {
                            // Output 1 berarti SP berhasil melakukan Insert
                            MessageBox.Show("✅ Akun berhasil dibuat! Silakan Login.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Menutup form register dan kembali ke form login
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan sistem: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // [FITUR BARU] Toggle Tampilkan Password untuk 2 kolom sekaligus
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShowPassword.Checked;

            if (txtPassword != null)
            {
                txtPassword.UseSystemPasswordChar = !show;
                if (show) txtPassword.PasswordChar = '\0';
            }

            if (txtKonfirmasi != null)
            {
                txtKonfirmasi.UseSystemPasswordChar = !show;
                if (show) txtKonfirmasi.PasswordChar = '\0';
            }
        }

        // [UX] Fungsi navigasi Enter antar TextBox
        private void txtNama_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtUsername.Focus(); }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtPassword.Focus(); }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; txtKonfirmasi.Focus(); }
        }

        private void txtKonfirmasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnDaftar_Click(sender, e); }
        }
    }
}