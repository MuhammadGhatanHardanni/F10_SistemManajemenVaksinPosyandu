using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormLaporan : Form
    {
        public FormLaporan()
        {
            InitializeComponent();
        }

        private void FormLaporan_Load(object sender, EventArgs e)
        {
            SetupFilterControls();

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
            if (btnRefreshStok != null) btnRefreshStok.Visible = false;
            if (btnFilterCakupan != null) btnFilterCakupan.Visible = false;
            if (cmbBulan != null) cmbBulan.Visible = false;
            if (cmbTahun != null) cmbTahun.Visible = false;
            if (labelBulan != null) labelBulan.Visible = false;
            if (labelTahun != null) labelTahun.Visible = false;
        }

        private void LoadLaporanStok()
        {
            if (dgvLaporan == null) return;

            string sql = @"SELECT v.nama_vaksin AS [Nama Vaksin], 
                                  v.stok AS [Stok Tersisa], 
                                  CONVERT(varchar, v.tgl_kedaluwarsa, 106) AS [Kedaluwarsa],
                                  CASE 
                                    WHEN v.tgl_kedaluwarsa < GETDATE() THEN '⚠️ KEDALUWARSA!'
                                    WHEN v.stok < 10 THEN '❗ Stok Rendah'
                                    ELSE '✅ Aman' 
                                  END AS [Keterangan]
                           FROM Vaksin v 
                           ORDER BY v.stok ASC";

            DataTable dt = DatabaseHelper.GetDataTable(sql);
            dgvLaporan.DataSource = dt;

            foreach (DataGridViewRow row in dgvLaporan.Rows)
            {
                string ket = row.Cells["Keterangan"].Value?.ToString() ?? "";
                if (ket.Contains("KEDALUWARSA")) row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (ket.Contains("Rendah")) row.DefaultCellStyle.BackColor = Color.LightYellow;
            }

            if (lblStatusLaporan != null)
                lblStatusLaporan.Text = $"Mode: Rekap Stok | Total Jenis Vaksin: {dt.Rows.Count}";
        }

        private void LoadCakupanImunisasi()
        {
            if (dgvLaporan == null || cmbBulan == null || cmbTahun == null) return;

            int bulan = cmbBulan.SelectedIndex + 1;
            int tahun = Convert.ToInt32(cmbTahun.SelectedItem);

            string sql = @"SELECT b.nama_balita AS [Nama Anak], 
                                  v.nama_vaksin AS [Vaksin],
                                  CONVERT(varchar, ti.tgl_suntik, 103) AS [Tanggal], 
                                  u.nama_lengkap AS [Petugas], 
                                  ti.status AS [Status]
                           FROM Transaksi_Imunisasi ti
                           JOIN Balita b ON b.id_balita = ti.id_balita
                           JOIN Vaksin v ON v.id_vaksin = ti.id_vaksin
                           JOIN Users u ON u.id_user = ti.id_petugas
                           WHERE MONTH(ti.tgl_suntik) = @bln AND YEAR(ti.tgl_suntik) = @thn
                           ORDER BY ti.tgl_suntik DESC";

            DataTable dt = DatabaseHelper.GetDataTable(sql,
                           new SqlParameter("@bln", bulan),
                           new SqlParameter("@thn", tahun));

            dgvLaporan.DataSource = dt;

            if (lblStatusLaporan != null)
                lblStatusLaporan.Text = $"Mode: Cakupan {cmbBulan.Text} {tahun} | Total: {dt.Rows.Count} Transaksi";
        }

        private void LoadRiwayatOrangTua()
        {
            if (dgvLaporan == null) return;

            string sql = @"SELECT b.nama_balita AS [Nama Anak], 
                                  v.nama_vaksin AS [Vaksin],
                                  CONVERT(varchar, ti.tgl_suntik, 103) AS [Tanggal], 
                                  ti.status AS [Status]
                           FROM Transaksi_Imunisasi ti
                           JOIN Balita b ON b.id_balita = ti.id_balita
                           JOIN Vaksin v ON v.id_vaksin = ti.id_vaksin
                           JOIN Users u ON u.nama_lengkap = b.nama_ortu
                           WHERE u.id_user = @uid
                           ORDER BY ti.tgl_suntik DESC";

            DataTable dt = DatabaseHelper.GetDataTable(sql, new SqlParameter("@uid", SessionManager.IdUser));
            dgvLaporan.DataSource = dt;

            if (lblStatusLaporan != null)
                lblStatusLaporan.Text = $"Riwayat Imunisasi Anak Anda ({dt.Rows.Count} Data)";
        }

        private void btnRefreshStok_Click(object sender, EventArgs e) => LoadLaporanStok();
        private void btnFilterCakupan_Click(object sender, EventArgs e) => LoadCakupanImunisasi();
    }
}