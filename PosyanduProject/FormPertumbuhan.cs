using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormPertumbuhan : Form
    {
        public FormPertumbuhan()
        {
            InitializeComponent();
        }

        private void FormPertumbuhan_Load(object sender, EventArgs e)
        {
            // Mengunci ID agar tidak bisa diedit manual
            if (txtIdPertumbuhan != null) txtIdPertumbuhan.ReadOnly = true;

            // Batasi kalender (Maksimal hari ini, Minimal 5 tahun lalu)
            if (dtpTimbang != null)
            {
                dtpTimbang.MaxDate = DateTime.Today;
                dtpTimbang.MinDate = DateTime.Today.AddYears(-5);
            }

            // [LOGIKA KEAMANAN] Sembunyikan fitur input jika yang login Orang Tua
            if (SessionManager.Role == "OrangTua")
            {
                // Sembunyikan semua tombol
                btnSimpan.Visible = btnUpdate.Visible = btnHapus.Visible = btnBersih.Visible = false;

                // Sembunyikan semua input dan labelnya
                cmbBalita.Visible = dtpTimbang.Visible = txtBerat.Visible = false;
                txtTinggi.Visible = txtLingkarKepala.Visible = txtCatatan.Visible = false;
                txtIdPertumbuhan.Visible = false;

                // Menyembunyikan semua label (lbl1 sampai lbl7)
                lbl1.Visible = lbl2.Visible = lbl3.Visible = lbl4.Visible = false;
                lbl5.Visible = lbl6.Visible = lbl7.Visible = false;
            }

            LoadComboBoxBalita();
            TampilkanData();
        }

        private void LoadComboBoxBalita()
        {
            try
            {
                cmbBalita.Items.Clear();
                var dt = DatabaseHelper.GetDataTable("SELECT id_balita, nama_balita FROM Balita ORDER BY nama_balita");
                foreach (DataRow r in dt.Rows)
                    cmbBalita.Items.Add(new ComboItem(Convert.ToInt32(r["id_balita"]), r["nama_balita"].ToString()));

                cmbBalita.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Gagal memuat Balita: " + ex.Message); }
        }

        private void TampilkanData(string filter = "")
        {
            string sql = @"SELECT cp.id_pertumbuhan AS [ID], 
                                  b.nama_balita AS [Nama Balita], 
                                  CONVERT(varchar, cp.tgl_timbang, 106) AS [Tgl Timbang], 
                                  cp.berat_badan AS [Berat (kg)], 
                                  cp.tinggi_badan AS [Tinggi (cm)], 
                                  cp.lingkar_kepala AS [Lingkar Kepala],
                                  cp.catatan_tambahan AS [Catatan]
                           FROM Catatan_Pertumbuhan cp
                           JOIN Balita b ON cp.id_balita = b.id_balita";

            try
            {
                DataTable dt;
                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " WHERE b.nama_balita LIKE @f ORDER BY cp.tgl_timbang DESC";
                    dt = DatabaseHelper.GetDataTable(sql, new SqlParameter("@f", "%" + filter.Trim() + "%"));
                }
                else
                {
                    sql += " ORDER BY cp.tgl_timbang DESC";
                    dt = DatabaseHelper.GetDataTable(sql);
                }
                dgvPertumbuhan.DataSource = dt;
            }
            catch (Exception ex) { MessageBox.Show("Error Tampil Data: " + ex.Message); }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            var blt = (ComboItem)cmbBalita.SelectedItem;
            try
            {
                string sql = @"INSERT INTO Catatan_Pertumbuhan (id_balita, id_petugas, tgl_timbang, berat_badan, tinggi_badan, lingkar_kepala, catatan_tambahan) 
                               VALUES (@b, @p, @tgl, @berat, @tinggi, @lk, @ctt)";

                DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@b", blt.Id),
                    new SqlParameter("@p", SessionManager.IdUser > 0 ? SessionManager.IdUser : 1),
                    new SqlParameter("@tgl", dtpTimbang.Value.Date),
                    new SqlParameter("@berat", ParseDecimal(txtBerat.Text)),
                    new SqlParameter("@tinggi", ParseDecimal(txtTinggi.Text)),
                    new SqlParameter("@lk", ParseDecimal(txtLingkarKepala.Text)),
                    new SqlParameter("@ctt", txtCatatan.Text.Trim())
                );

                MessageBox.Show("✅ Catatan pertumbuhan berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPertumbuhan.Text)) { MessageBox.Show("Pilih data dulu di tabel!"); return; }
            if (!Validasi()) return;

            try
            {
                string sql = @"UPDATE Catatan_Pertumbuhan 
                               SET tgl_timbang=@tgl, berat_badan=@berat, tinggi_badan=@tinggi, lingkar_kepala=@lk, catatan_tambahan=@ctt 
                               WHERE id_pertumbuhan=@id";

                DatabaseHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@tgl", dtpTimbang.Value.Date),
                    new SqlParameter("@berat", ParseDecimal(txtBerat.Text)),
                    new SqlParameter("@tinggi", ParseDecimal(txtTinggi.Text)),
                    new SqlParameter("@lk", ParseDecimal(txtLingkarKepala.Text)),
                    new SqlParameter("@ctt", txtCatatan.Text.Trim()),
                    new SqlParameter("@id", int.Parse(txtIdPertumbuhan.Text))
                );

                MessageBox.Show("✅ Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Update: " + ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPertumbuhan.Text)) { MessageBox.Show("Pilih data dulu di tabel!"); return; }
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Catatan_Pertumbuhan WHERE id_pertumbuhan=@id",
                    new SqlParameter("@id", int.Parse(txtIdPertumbuhan.Text)));

                MessageBox.Show("✅ Data berhasil dihapus!");
                BersihForm();
                TampilkanData();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
        }

        private void dgvPertumbuhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvPertumbuhan.Rows[e.RowIndex];

            txtIdPertumbuhan.Text = row.Cells["ID"].Value?.ToString() ?? "";
            txtBerat.Text = row.Cells["Berat (kg)"].Value?.ToString() ?? "";
            txtTinggi.Text = row.Cells["Tinggi (cm)"].Value?.ToString() ?? "";
            txtLingkarKepala.Text = row.Cells["Lingkar Kepala"].Value?.ToString() ?? "";
            txtCatatan.Text = row.Cells["Catatan"].Value?.ToString() ?? "";

            string tglStr = row.Cells["Tgl Timbang"].Value?.ToString() ?? "";
            if (DateTime.TryParse(tglStr, out DateTime tgl)) dtpTimbang.Value = tgl;
        }

        private void btnCari_Click(object sender, EventArgs e) => TampilkanData(txtCari.Text);
        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private bool Validasi()
        {
            if (cmbBalita.SelectedItem == null) { MessageBox.Show("Pilih balita!"); return false; }
            if (string.IsNullOrWhiteSpace(txtBerat.Text) || string.IsNullOrWhiteSpace(txtTinggi.Text))
            {
                MessageBox.Show("Berat dan Tinggi badan wajib diisi!"); return false;
            }
            return true;
        }

        private decimal ParseDecimal(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            decimal.TryParse(text.Replace(".", ","), out decimal result);
            return result;
        }

        private void BersihForm()
        {
            txtIdPertumbuhan.Clear();
            txtBerat.Clear();
            txtTinggi.Clear();
            txtLingkarKepala.Clear();
            txtCatatan.Clear();
            cmbBalita.SelectedIndex = -1;
            dtpTimbang.Value = DateTime.Today;
        }
    }
}