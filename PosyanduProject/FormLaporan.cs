using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; 
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

            // Sembunyikan grafik jika yang login orang tua (karena orang tua hanya melihat riwayat anak)
            if (chartVaksin != null) chartVaksin.Visible = false;

            // Sembunyikan tombol cetak untuk orang tua
            if (btnCetak != null) btnCetak.Visible = false;
            if (btnCetakStok != null) btnCetakStok.Visible = false;

            if (lblTitle != null) lblTitle.Text = "Riwayat Imunisasi Anak";
            
            // Perlebar grid karena chart disembunyikan
            if (dgvLaporan != null) 
            { 
                dgvLaporan.Left = 30; 
                dgvLaporan.Width = this.ClientSize.Width - 60;
                dgvLaporan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        // ==============================================================
        // PENGGUNAAN VIEW (Untuk Kueri Tampil Data)
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

                LoadGrafikVaksin();

                // Pastikan grafik terlihat
                if (chartVaksin != null) chartVaksin.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan stok: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DatabaseHelper.CatatLogError("FormLaporan (Load Laporan Stok): " + ex.Message);
            }
        }

        // ==============================================================
        // DASHBOARD GRAFIK KETERSEDIAAN STOK VAKSIN
        // ==============================================================
        private void LoadGrafikVaksin()
        {
            try
            {
                if (chartVaksin == null) return;

                // 1. Bersihkan grafik lama agar tidak menumpuk saat di-refresh
                chartVaksin.Series.Clear();
                chartVaksin.Titles.Clear();

                // 2. Tambahkan Judul Grafik
                chartVaksin.Titles.Add("Visualisasi Ketersediaan Stok Vaksin");
                chartVaksin.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);

                // 3. Buat seri data baru (Batang Grafik)
                Series series = chartVaksin.Series.Add("Stok Vaksin");
                series.ChartType = SeriesChartType.Column; // Grafik batang vertikal
                series.IsValueShownAsLabel = true; // Menampilkan angka stok di atas batang
                series.Color = Color.SteelBlue; // Warna default biru elegan

                // 4. Masukkan data ke dalam grafik
                foreach (DataRow row in dtLaporan.Rows)
                {
                    string namaVaksin = row["Nama Vaksin"].ToString();
                    int stok = Convert.ToInt32(row["Stok Tersisa"]);

                    // Menambahkan titik data X (Nama Vaksin) dan Y (Jumlah Stok)
                    int pointIndex = series.Points.AddXY(namaVaksin, stok);

                    // Jika stok kritis (< 10), ubah warna batang tersebut menjadi merah
                    if (stok < 10)
                    {
                        series.Points[pointIndex].Color = Color.IndianRed;
                    }
                }
            }
            catch (Exception ex)
            {
                DatabaseHelper.CatatLogError("FormLaporan (Render Grafik): " + ex.Message);
            }
        }

        // ==============================================================
        // PENGGUNAAN STORED PROCEDURE (Untuk Pemfilteran)
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

                // Sembunyikan grafik karena kita sedang melihat data cakupan imunisasi, bukan stok
                if (chartVaksin != null) chartVaksin.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat cakupan imunisasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // [TAMBAHAN UCP 3] Log Error
                DatabaseHelper.CatatLogError("FormLaporan (Load Cakupan Imunisasi): " + ex.Message);
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

                DatabaseHelper.CatatLogError("FormLaporan (Load Riwayat Orang Tua): " + ex.Message);
            }
        }

        // ==============================================================
        // TOMBOL NAVIGASI FILTER
        // ==============================================================
        private void btnRefreshStok_Click(object sender, EventArgs e) => LoadLaporanStok();
        private void btnFilterCakupan_Click(object sender, EventArgs e) => LoadCakupanImunisasi();

        private void chartVaksin_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            // Validasi agar memastikan ComboBox sudah dipilih
            if (cmbBulan.SelectedIndex == -1 || cmbTahun.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Bulan dan Tahun terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bulan = cmbBulan.SelectedIndex + 1;
            int tahun = Convert.ToInt32(cmbTahun.SelectedItem);

            // Membuka Form Cetak dengan mengirim parameter bulan dan tahun (Sesuai Modul Hal. 12)
            FormCetak formCetak = new FormCetak(bulan, tahun);
            formCetak.ShowDialog();
        }

        private void btnCetakStok_Click(object sender, EventArgs e)
        {
            FormCetakStok formCetakStok = new FormCetakStok();
            formCetakStok.ShowDialog();
        }

    }
}