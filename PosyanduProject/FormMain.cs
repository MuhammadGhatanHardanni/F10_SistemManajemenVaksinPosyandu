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
            // 1. Sembunyikan semua tombol menu terlebih dahulu (Reset State)
            btnMenuVaksin.Visible = false;
            btnMenuBalita.Visible = false;
            btnMenuJadwal.Visible = false;
            btnMenuLaporan.Visible = false;
            btnMenuImunisasi.Visible = false;

            // Pastikan Anda sudah membuat tombol ini di Designer atau Designer.cs
            if (btnMenuPertumbuhan != null) btnMenuPertumbuhan.Visible = false;

            // 2. Tampilkan menu berdasarkan Role pengguna
            string role = SessionManager.Role;

            if (role == "Bidan")
            {
                btnMenuVaksin.Visible = true;
                btnMenuBalita.Visible = true;
                btnMenuJadwal.Visible = true;
                btnMenuLaporan.Visible = true;
                if (btnMenuPertumbuhan != null) btnMenuPertumbuhan.Visible = true;

                btnMenuLaporan.Text = "Laporan Lengkap";
            }
            else if (role == "Petugas")
            {
                btnMenuBalita.Visible = true;
                btnMenuJadwal.Visible = true;
                btnMenuImunisasi.Visible = true;
                if (btnMenuPertumbuhan != null) btnMenuPertumbuhan.Visible = true;
            }
            else if (role == "OrangTua")
            {
                btnMenuJadwal.Visible = true;
                if (btnMenuPertumbuhan != null) btnMenuPertumbuhan.Visible = true;
                btnMenuLaporan.Visible = true;

                // Mengubah teks agar lebih ramah untuk orang tua
                btnMenuLaporan.Text = "Riwayat Imunisasi";
                if (btnMenuPertumbuhan != null) btnMenuPertumbuhan.Text = "Riwayat Timbang";
            }
        }

        private void OpenForm(Form childForm)
        {
            // Menutup form yang sedang aktif jika ada
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // pnlContent adalah panel utama di tengah FormMain
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
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

        private void btnMenuPertumbuhan_Click(object sender, EventArgs e)
        {
            // Membuka form baru yang tadi kita buat
            OpenForm(new FormPertumbuhan());
        }

        private void btnMenuLaporan_Click(object sender, EventArgs e)
        {
            OpenForm(new FormLaporan());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.Clear();
                this.Close(); // Menutup FormMain dan kembali ke FormLogin (tergantung logika Program.cs)
            }
        }
    }
}