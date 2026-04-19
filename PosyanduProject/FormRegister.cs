using System;
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

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Harap isi semua kolom data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtKonfirmasi.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int cekUser = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Users WHERE username=@u",
                    new SqlParameter("@u", txtUsername.Text.Trim())));

                if (cekUser > 0)
                {
                    MessageBox.Show("Username sudah digunakan, silakan pilih yang lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                string sql = "INSERT INTO Users (nama_lengkap, username, password, role) VALUES (@nama, @user, @pass, 'OrangTua')";

                int baris = DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@nama", txtNama.Text.Trim()),
                    new SqlParameter("@user", txtUsername.Text.Trim()),
                    new SqlParameter("@pass", txtPassword.Text)
                );

                if (baris > 0)
                {
                    MessageBox.Show("✅ Akun berhasil dibuat! Silakan Login.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
    }

}