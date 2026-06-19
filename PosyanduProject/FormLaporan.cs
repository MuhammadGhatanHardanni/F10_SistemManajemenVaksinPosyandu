using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormLaporan : Form
    {
        // 1. Deklarasi Data Binding (Syarat Ujian)
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtLaporan = new DataTable();

        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            // Mencegah user mengedit isi tabel laporan (Wajib untuk form Laporan)
            if (dgvLaporan != null)
            {
                dgvLaporan.ReadOnly = true;
                dgvLaporan.AllowUserToAddRows = false;
                dgvLaporan.AllowUserToDeleteRows = false;
            }

            SetupFilterControls();

            // Menerapkan tampilan berdasarkan Role Akses
            if (SessionManager.Role == "OrangTua")
            {
                ApplyOrangTuaView();
                LoadRiwayatOrangTua();
            }
            else
            {
                LoadLaporanStok();
            }
        }

        private void SetupFilterControls()
        {
            if (cmbTahun != null && cmbTahun.Items.Count == 0)
            {
                for (int y = DateTime.Today.Year; y >= DateTime.Today.Year - 5; y--)
                    cmbTahun.Items.Add(y);
                cmbTahun.SelectedIndex = 0;
            }

            if (cmbBulan != null && cmbBulan.Items.Count == 0)
            {
                string[] bulanList = { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
                cmbBulan.Items.AddRange(bulanList);
                cmbBulan.SelectedIndex = DateTime.Today.Month - 1;
            }
        }

        private void ApplyOrangTuaView()
        {
            // Menyembunyikan elemen filter dan tombol stok khusus untuk Orang Tua
            if (btnRefreshStok != null) btnRefreshStok.Visible = false;
            if (btnFilterCakupan != null) btnFilterCakupan.Visible = false;
            if (cmbBulan != null) cmbBulan.Visible = false;
            if (cmbTahun != null) cmbTahun.Visible = false;
            if (labelBulan != null) labelBulan.Visible = false;
            if (labelTahun != null) labelTahun.Visible = false;
        }

        // ==============================================================
        // SYARAT UJIAN 1: PENGGUNAAN VIEW (Untuk Kueri Tampil Data)
        // ==============================================================
        private void LoadLaporanStok()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Memanggil objek VIEW yang sudah dibuat di SQL Server
                    string query = "SELECT * FROM vwLaporanStokVaksin";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtLaporan = new DataTable();
                        da.Fill(dtLaporan);

                        // Menerapkan Binding ke DataGridView
                        bindingSource.DataSource = dtLaporan;
                        if (dgvLaporan != null) dgvLaporan.DataSource = bindingSource;
                    }
                }

                // Pewarnaan Kondisional Dinamis
                if (dgvLaporan != null)
                {
                    foreach (DataGridViewRow row in dgvLaporan.Rows)
                    {
                        string ket = row.Cells["Keterangan"].Value?.ToString() ?? "";
                        if (ket.Contains("KEDALUWARSA")) row.DefaultCellStyle.BackColor = Color.LightCoral;
                        else if (ket.Contains("Rendah")) row.DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }

                if (lblStatusLaporan != null)
                    lblStatusLaporan.Text = $"Mode: Rekap Stok | Total Jenis Vaksin: {dtLaporan.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan stok: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // SYARAT UJIAN 2: PENGGUNAAN STORED PROCEDURE (Untuk Pemfilteran)
        // ==============================================================
        private void LoadCakupanImunisasi()
        {
            if (cmbBulan == null || cmbTahun == null || cmbTahun.SelectedItem == null) return;

            int bulan = cmbBulan.SelectedIndex + 1;
            int tahun = Convert.ToInt32(cmbTahun.SelectedItem);

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Memanggil Stored Procedure untuk Filter
                    using (SqlCommand cmd = new SqlCommand("sp_FilterCakupanImunisasi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@bln", bulan);
                        cmd.Parameters.AddWithValue("@thn", tahun);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtLaporan = new DataTable();
                            da.Fill(dtLaporan);

                            // Menerapkan Binding ke DataGridView
                            bindingSource.DataSource = dtLaporan;
                            if (dgvLaporan != null) dgvLaporan.DataSource = bindingSource;
                        }
                    }
                }

                // Reset warna grid menjadi default jika pindah dari laporan stok
                if (dgvLaporan != null)
                {
                    foreach (DataGridViewRow row in dgvLaporan.Rows)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }

                if (lblStatusLaporan != null)
                    lblStatusLaporan.Text = $"Mode: Cakupan {cmbBulan.Text} {tahun} | Total: {dtLaporan.Rows.Count} Transaksi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat cakupan imunisasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRiwayatOrangTua()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    // Memanggil SP Filter Khusus Role Orang Tua
                    using (SqlCommand cmd = new SqlCommand("sp_RiwayatImunisasiOrangTua", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@uid", SessionManager.IdUser);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtLaporan = new DataTable();
                            da.Fill(dtLaporan);

                            // Menerapkan Binding
                            bindingSource.DataSource = dtLaporan;
                            if (dgvLaporan != null) dgvLaporan.DataSource = bindingSource;
                        }
                    }
                }

                if (lblStatusLaporan != null)
                    lblStatusLaporan.Text = $"Riwayat Imunisasi Anak Anda ({dtLaporan.Rows.Count} Data)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==============================================================
        // TOMBOL NAVIGASI FILTER
        // ==============================================================
        private void btnRefreshStok_Click(object sender, EventArgs e) => LoadLaporanStok();
        private void btnFilterCakupan_Click(object sender, EventArgs e) => LoadCakupanImunisasi();
    }
}