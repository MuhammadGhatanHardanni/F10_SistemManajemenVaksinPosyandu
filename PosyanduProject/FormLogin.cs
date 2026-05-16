using System;
using System.Data;
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

                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Menggabungkan string secara langsung
                string sql = "SELECT id_user, nama_lengkap, username, role " +
                             "FROM Users " +
                             "WHERE username = '" + username + "' AND password = '" + password + "'";

                DataTable dt = DatabaseHelper.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Menyimpan data ke SessionManager
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error koneksi database:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fungsi agar bisa tekan ENTER saat berada di kolom Password
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Menghilangkan bunyi "ding" pada Windows
                btnLogin_Click(sender, e); // Memanggil tombol login
            }
        }

        // Fungsi agar bisa tekan ENTER saat berada di kolom Username
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus(); // Pindah ke kolom password jika tekan enter di username
            }
        }

        // Event ketika CheckBox Show Password di klik/berubah
        

        private void linkDaftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister frmReg = new FormRegister();
            frmReg.ShowDialog();
        }
    }
}