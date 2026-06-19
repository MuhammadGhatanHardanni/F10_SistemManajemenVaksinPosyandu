using System;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void btnCek_Click(object sender, EventArgs e)
        {

            bool ok = DatabaseHelper.TestConnection(out string pesan);

            if (ok)
            {
                lblStatus.Text = "TERHUBUNG";
                lblStatus.ForeColor = Color.ForestGreen;
                btnLanjut.Enabled = true;
            }
            else
            {
                lblStatus.Text = "GAGAL TERHUBUNG";
                lblStatus.ForeColor = Color.Crimson;
                btnLanjut.Enabled = false;
            }
        }

        private void btnLanjut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formLogin = new FormLogin();

            formLogin.FormClosed += (s, args) => this.Close();
            formLogin.Show();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}