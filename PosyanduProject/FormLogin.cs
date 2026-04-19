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
                string sql = @"SELECT id_user, nama_lengkap, username, role 
                               FROM Users 
                               WHERE username = @uname AND password = @pwd";

                DataTable dt = DatabaseHelper.GetDataTable(sql,
                    new SqlParameter("@uname", txtUsername.Text.Trim()),
                    new SqlParameter("@pwd", txtPassword.Text.Trim())
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error koneksi database:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkDaftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister frmReg = new FormRegister();
            frmReg.ShowDialog();
        }

    }
}