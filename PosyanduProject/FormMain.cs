using System;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormMain : Form
    {
        private Form activeForm = null;

        public FormMain()
        {
            InitializeComponent();
            SetupSidebarMenu();
        }

        private void SetupSidebarMenu()
        {
            btnMenuVaksin.Visible = false;
            btnMenuBalita.Visible = false;
            btnMenuJadwal.Visible = false;
            btnMenuLaporan.Visible = false;
            btnMenuImunisasi.Visible = false;

            if (SessionManager.IsAdmin)
            {
                btnMenuVaksin.Visible = true;
                btnMenuBalita.Visible = true;
                btnMenuJadwal.Visible = true;
                btnMenuLaporan.Visible = true;
            }
            else if (SessionManager.IsPetugas)
            {
                btnMenuBalita.Visible = true;
                btnMenuJadwal.Visible = true;
                btnMenuImunisasi.Visible = true;
            }
            else
            {
                btnMenuJadwal.Visible = true;
                btnMenuLaporan.Visible = true;
                btnMenuLaporan.Text = "Riwayat Imunisasi";
            }
        }

        private void OpenForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnMenuVaksin_Click(object sender, EventArgs e)
        {
            OpenForm(new FormVaksin());
        }

        private void btnMenuBalita_Click(object sender, EventArgs e)
        {
            OpenForm(new FormBalita());
        }

        private void btnMenuJadwal_Click(object sender, EventArgs e)
        {
            OpenForm(new FormJadwal());
        }

        private void btnMenuImunisasi_Click(object sender, EventArgs e)
        {
            OpenForm(new FormImunisasi());
        }

        private void btnMenuLaporan_Click(object sender, EventArgs e)
        {
            OpenForm(new FormLaporan());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Clear();
            this.Close(); 
        }
    }
}