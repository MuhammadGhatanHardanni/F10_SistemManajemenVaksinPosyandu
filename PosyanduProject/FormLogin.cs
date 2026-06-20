using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (txtPassword != null)
            {
                txtPassword.UseSystemPasswordChar = true;
            }

            // [UPDATE] Membatasi input agar sesuai dengan database
            if (txtUsername != null) txtUsername.MaxLength = 50;
            if (txtPassword != null) txtPassword.MaxLength = 255;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "⚠ Username dan password tidak boleh kosong.";
                return;
            }

            try
            {
                string sql = "SELECT id_user, nama_lengkap, username, role FROM Users WHERE username = @user AND password = @pass";

                DataTable dt = DatabaseHelper.GetDataTable(sql,
                    new SqlParameter("@user", txtUsername.Text.Trim()),
                    new SqlParameter("@pass", txtPassword.Text.Trim())
                );

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    SessionManager.IdUser = Convert.ToInt32(row["id_user"]);
                    SessionManager.NamaLengkap = row["nama_lengkap"].ToString();
                    SessionManager.Username = row["username"].ToString();
                    SessionManager.Role = row["role"].ToString();

                    this.Hide();

                    var main = new FormMain();
                    main.FormClosed += (s, args) => this.Close();
                    main.Show();
                }
                else
                {
                    lblError.Text = "✗ Username atau password salah.";
                    txtPassword.Clear();
                    txtPassword.Focus();

                    DatabaseHelper.CatatLogError("Login Gagal: Username atau Password salah untuk user: " + txtUsername.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error koneksi database:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DatabaseHelper.CatatLogError("FormLogin (Koneksi Database): " + ex.Message);
            }
        }

        // Fungsi agar bisa tekan ENTER saat berada di kolom Password
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, e);
            }
        }

        // Fungsi agar bisa tekan ENTER saat berada di kolom Username
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
            }
        }

        // Event ketika CheckBox Show Password di klik
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword != null)
            {
                if (chkShowPassword.Checked)
                {
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.PasswordChar = '\0';
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                }
            }
        }

        private void linkDaftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister frmReg = new FormRegister();
            frmReg.ShowDialog();
        }
    }
}