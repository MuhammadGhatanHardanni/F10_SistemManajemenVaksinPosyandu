using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormImunisasi : Form
    {
        public FormImunisasi()
        {
            InitializeComponent();
        }

        private void FormImunisasi_Load(object sender, EventArgs e)
        {
            if (cmbStatus != null && cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.AddRange(new[] { "Terdaftar", "Selesai", "Batal" });
                cmbStatus.SelectedIndex = 0;
            }

            LoadComboBoxes();
            TampilkanData();
        }

        private void LoadComboBoxes()
        {
            if (cmbBalita == null || cmbVaksin == null || cmbJadwal == null) return;

            try
            {
                cmbBalita.Items.Clear();
                var dtB = DatabaseHelper.GetDataTable("SELECT id_balita, nama_balita FROM Balita ORDER BY nama_balita");
                foreach (DataRow r in dtB.Rows)
                    cmbBalita.Items.Add(new ComboItem(Convert.ToInt32(r["id_balita"]), r["nama_balita"].ToString()));

                cmbVaksin.Items.Clear();
                var dtV = DatabaseHelper.GetDataTable("SELECT id_vaksin, nama_vaksin, stok FROM Vaksin WHERE stok > 0 ORDER BY nama_vaksin");
                foreach (DataRow r in dtV.Rows)
                    cmbVaksin.Items.Add(new ComboItem(Convert.ToInt32(r["id_vaksin"]), $"{r["nama_vaksin"]} (Stok: {r["stok"]})"));

                cmbJadwal.Items.Clear();
                var dtJ = DatabaseHelper.GetDataTable("SELECT id_jadwal, CONVERT(varchar,tgl_pelaksanaan,106) + ' - ' + lokasi AS info FROM Jadwal_Posyandu ORDER BY tgl_pelaksanaan DESC");
                foreach (DataRow r in dtJ.Rows)
                    cmbJadwal.Items.Add(new ComboItem(Convert.ToInt32(r["id_jadwal"]), r["info"].ToString()));

                if (cmbBalita.Items.Count > 0) cmbBalita.SelectedIndex = 0;
                if (cmbVaksin.Items.Count > 0) cmbVaksin.SelectedIndex = 0;
                if (cmbJadwal.Items.Count > 0) cmbJadwal.SelectedIndex = 0;
            }
            catch (Exception ex) { MessageBox.Show("Gagal memuat dropdown: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TampilkanData(string filter = "")
        {
            if (dgvImunisasi == null) return;

            string sql = @"SELECT ti.id_imunisasi AS [ID], 
                                  b.nama_balita AS [Nama Balita], 
                                  v.nama_vaksin AS [Vaksin],
                                  CONVERT(varchar,j.tgl_pelaksanaan,106) + ' - ' + j.lokasi AS [Jadwal],
                                  ti.no_antrean AS [No. Antrean], 
                                  CONVERT(varchar,ti.tgl_suntik,103) AS [Tgl Suntik], 
                                  ti.status AS [Status]
                           FROM Transaksi_Imunisasi ti
                           JOIN Balita b ON b.id_balita = ti.id_balita
                           JOIN Vaksin v ON v.id_vaksin = ti.id_vaksin
                           JOIN Jadwal_Posyandu j ON j.id_jadwal = ti.id_jadwal";

            try
            {
                DataTable dt;
                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " WHERE b.nama_balita LIKE @f ORDER BY ti.tgl_suntik DESC";
                    dt = DatabaseHelper.GetDataTable(sql, new SqlParameter("@f", "%" + filter.Trim() + "%"));
                }
                else
                {
                    sql += " ORDER BY ti.tgl_suntik DESC";
                    dt = DatabaseHelper.GetDataTable(sql);
                }

                dgvImunisasi.DataSource = dt;

                foreach (DataGridViewRow row in dgvImunisasi.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    if (status == "Selesai") row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (status == "Batal") row.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            var blt = (ComboItem)cmbBalita.SelectedItem;
            var vks = (ComboItem)cmbVaksin.SelectedItem;
            var jdw = (cmbJadwal.SelectedItem as ComboItem);

            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    using (var trx = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlInsert = @"INSERT INTO Transaksi_Imunisasi (id_balita, id_vaksin, id_jadwal, id_petugas, no_antrean, tgl_suntik, status) 
                                                 VALUES (@b, @v, @j, @p, @no, @tgl, @st)";

                            using (var cmd1 = new SqlCommand(sqlInsert, conn, trx))
                            {
                                cmd1.Parameters.AddWithValue("@b", blt.Id);
                                cmd1.Parameters.AddWithValue("@v", vks.Id);
                                cmd1.Parameters.AddWithValue("@j", jdw.Id);
                                cmd1.Parameters.AddWithValue("@p", SessionManager.IdUser > 0 ? SessionManager.IdUser : 1);
                                cmd1.Parameters.AddWithValue("@no", txtNoAntrean.Text.Trim());
                                cmd1.Parameters.AddWithValue("@tgl", dtpSuntik.Value);
                                cmd1.Parameters.AddWithValue("@st", cmbStatus.SelectedItem.ToString());
                                cmd1.ExecuteNonQuery();
                            }

                            using (var cmd2 = new SqlCommand("UPDATE Vaksin SET stok = stok - 1 WHERE id_vaksin = @id", conn, trx))
                            {
                                cmd2.Parameters.AddWithValue("@id", vks.Id);
                                cmd2.ExecuteNonQuery();
                            }

                            trx.Commit();
                            MessageBox.Show("✅ Transaksi imunisasi berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BersihForm(); LoadComboBoxes(); TampilkanData();
                        }
                        catch (Exception ex)
                        {
                            trx.Rollback();
                            MessageBox.Show("Transaksi Gagal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Koneksi Gagal: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdImunisasi.Text)) { MessageBox.Show("Pilih data di tabel!"); return; }

            string sql = "UPDATE Transaksi_Imunisasi SET status=@st WHERE id_imunisasi=@id";
            DatabaseHelper.ExecuteNonQuery(sql,
                new SqlParameter("@st", cmbStatus.SelectedItem.ToString()),
                new SqlParameter("@id", int.Parse(txtIdImunisasi.Text)));

            MessageBox.Show("Status diperbarui!");
            TampilkanData();
        }

        private void dgvImunisasi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvImunisasi.Rows[e.RowIndex];
            txtIdImunisasi.Text = row.Cells["ID"].Value?.ToString() ?? "";
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString() ?? "Terdaftar";
        }

        private void btnCari_Click(object sender, EventArgs e) => TampilkanData(txtCari.Text.Trim());
        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private bool Validasi()
        {
            if (cmbBalita.SelectedItem == null || cmbVaksin.SelectedItem == null || cmbJadwal.SelectedItem == null)
            { MessageBox.Show("Harap pilih Balita, Vaksin, dan Jadwal!"); return false; }
            if (string.IsNullOrWhiteSpace(txtNoAntrean.Text))
            { MessageBox.Show("No. Antrean wajib diisi!"); return false; }
            return true;
        }

        private void BersihForm()
        {
            if (txtIdImunisasi != null) txtIdImunisasi.Clear();
            if (txtNoAntrean != null) txtNoAntrean.Clear();
            if (cmbStatus != null) cmbStatus.SelectedIndex = 0;
            if (dtpSuntik != null) dtpSuntik.Value = DateTime.Now;
        }
    }

    public class ComboItem
    {
        public int Id { get; }
        public string Teks { get; }
        public ComboItem(int id, string teks) { Id = id; Teks = teks; }
        public override string ToString() => Teks;
    }
}