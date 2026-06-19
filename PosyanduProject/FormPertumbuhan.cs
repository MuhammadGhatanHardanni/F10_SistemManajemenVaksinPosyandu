using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions; // Ditambahkan untuk validasi simbol
using System.Windows.Forms;

namespace PosyanduProject
{
    public partial class FormPertumbuhan : Form
    {
        // 1. Variabel Disconnected Architecture (Modul 8)
        private BindingSource bindingSource = new BindingSource();
        private DataTable dtPertumbuhan = new DataTable();

        public FormPertumbuhan()
        {
            InitializeComponent();

            // 1. Menyambungkan event Load
            this.Load += FormPertumbuhan_Load;

            // 2. Menyambungkan kabel tombol-tombol CRUD
            if (btnSimpan != null) btnSimpan.Click += btnSimpan_Click;
            if (btnUpdate != null) btnUpdate.Click += btnUpdate_Click;
            if (btnHapus != null) btnHapus.Click += btnHapus_Click;
            if (btnBersih != null) btnBersih.Click += btnBersih_Click;

            // 3. Menyambungkan kabel pencarian & klik tabel
            if (btnCari != null) btnCari.Click += btnCari_Click;
            if (dgvPertumbuhan != null) dgvPertumbuhan.CellClick += dgvPertumbuhan_CellClick;

            // 4. [FITUR BARU] Menyambungkan validasi KeyPress ke kolom angka
            if (txtBerat != null) txtBerat.KeyPress += txtAngkaDesimal_KeyPress;
            if (txtTinggi != null) txtTinggi.KeyPress += txtAngkaDesimal_KeyPress;
            if (txtLingkarKepala != null) txtLingkarKepala.KeyPress += txtAngkaDesimal_KeyPress;
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

            // [LOGIKA KEAMANAN DIPERTAHANKAN] Sembunyikan fitur input jika yang login Orang Tua
            if (SessionManager.Role == "OrangTua")
            {
                if (btnSimpan != null) btnSimpan.Visible = false;
                if (btnUpdate != null) btnUpdate.Visible = false;
                if (btnHapus != null) btnHapus.Visible = false;
                if (btnBersih != null) btnBersih.Visible = false;

                if (cmbBalita != null) cmbBalita.Visible = false;
                if (dtpTimbang != null) dtpTimbang.Visible = false;
                if (txtBerat != null) txtBerat.Visible = false;
                if (txtTinggi != null) txtTinggi.Visible = false;
                if (txtLingkarKepala != null) txtLingkarKepala.Visible = false;
                if (txtCatatan != null) txtCatatan.Visible = false;
                if (txtIdPertumbuhan != null) txtIdPertumbuhan.Visible = false;

                if (lbl1 != null) lbl1.Visible = false;
                if (lbl2 != null) lbl2.Visible = false;
                if (lbl3 != null) lbl3.Visible = false;
                if (lbl4 != null) lbl4.Visible = false;
                if (lbl5 != null) lbl5.Visible = false;
                if (lbl6 != null) lbl6.Visible = false;
                if (lbl7 != null) lbl7.Visible = false;
            }

            // === PENGATURAN BINDING NAVIGATOR (Modul 8) ===
            // Asumsi: Anda sudah menambahkan BindingNavigator di Designer
            // if (bindingNavigator1 != null) bindingNavigator1.BindingSource = bindingSource;

            bindingSource.CurrentChanged += bindingSource_CurrentChanged;
            // ==============================================

            LoadComboBoxBalita();
            LoadData(); // Memanggil VIEW (Modul 9)
            BindControls(); // Menghubungkan TextBox dengan BindingSource
        }

        private void LoadComboBoxBalita()
        {
            try
            {
                if (cmbBalita == null) return;
                cmbBalita.Items.Clear();
                var dt = DatabaseHelper.GetDataTable("SELECT id_balita, nama_balita FROM Balita ORDER BY nama_balita");
                foreach (DataRow r in dt.Rows)
                    cmbBalita.Items.Add(new ComboItem(Convert.ToInt32(r["id_balita"]), r["nama_balita"].ToString()));

                cmbBalita.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat Balita: " + ex.Message);
                DatabaseHelper.CatatLogError("FormPertumbuhan (Load Balita): " + ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    string query = "SELECT * FROM vwPertumbuhanPublic";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        dtPertumbuhan = new DataTable();
                        da.Fill(dtPertumbuhan);

                        // 1. Masukkan data ke BindingSource
                        bindingSource.DataSource = dtPertumbuhan;

                        // 2. Sambungkan ke Tabel (DataGridView)
                        if (dgvPertumbuhan != null) dgvPertumbuhan.DataSource = bindingSource;

                        // 3. Paksa Navigator untuk membaca data yang sama!
                        if (bindingNavigator1 != null) bindingNavigator1.BindingSource = bindingSource;
                    }
                }

                HitungTotal(); // Panggil SP Count
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
                DatabaseHelper.CatatLogError("FormPertumbuhan (Load Data): " + ex.Message);
            }
        }

        private void BindControls()
        {
            if (txtIdPertumbuhan != null) { txtIdPertumbuhan.DataBindings.Clear(); txtIdPertumbuhan.DataBindings.Add("Text", bindingSource, "ID"); }
            if (txtBerat != null) { txtBerat.DataBindings.Clear(); txtBerat.DataBindings.Add("Text", bindingSource, "Berat (kg)"); }
            if (txtTinggi != null) { txtTinggi.DataBindings.Clear(); txtTinggi.DataBindings.Add("Text", bindingSource, "Tinggi (cm)"); }
            if (txtLingkarKepala != null) { txtLingkarKepala.DataBindings.Clear(); txtLingkarKepala.DataBindings.Add("Text", bindingSource, "Lingkar Kepala"); }
            if (txtCatatan != null) { txtCatatan.DataBindings.Clear(); txtCatatan.DataBindings.Add("Text", bindingSource, "Catatan"); }
        }

        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current == null) return;

            DataRowView rowView = (DataRowView)bindingSource.Current;

            if (txtIdPertumbuhan != null) txtIdPertumbuhan.Text = rowView["ID"].ToString();

            string tglStr = rowView["Tgl Timbang"].ToString();
            if (DateTime.TryParseExact(tglStr, "dd MMM yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tglExact))
            {
                if (dtpTimbang != null) dtpTimbang.Value = tglExact;
            }
            else if (DateTime.TryParse(tglStr, out DateTime tglFallback))
            {
                if (dtpTimbang != null) dtpTimbang.Value = tglFallback;
            }

            if (cmbBalita != null)
            {
                string namaBlt = rowView["Nama Balita"].ToString();
                foreach (ComboItem item in cmbBalita.Items)
                {
                    if (item.Teks == namaBlt) { cmbBalita.SelectedItem = item; break; }
                }
            }
        }

        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CountPertumbuhan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter outputParam = new SqlParameter("@Total", SqlDbType.Int);
                        outputParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        if (lblTotal != null)
                        {
                            lblTotal.Text = "Total Catatan Pertumbuhan: " + outputParam.Value.ToString();
                        }
                        this.Text = "Manajemen Pertumbuhan Balita | " + outputParam.Value.ToString() + " Catatan Data";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghitung total: " + ex.Message);
                DatabaseHelper.CatatLogError("FormPertumbuhan (Hitung Total): " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!Validasi()) return;

            var blt = (ComboItem)cmbBalita.SelectedItem;
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertPertumbuhan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_balita", blt.Id);
                        cmd.Parameters.AddWithValue("@id_petugas", SessionManager.IdUser > 0 ? SessionManager.IdUser : 1);
                        cmd.Parameters.AddWithValue("@tgl", dtpTimbang.Value.Date);
                        cmd.Parameters.AddWithValue("@berat", ParseDecimal(txtBerat.Text));
                        cmd.Parameters.AddWithValue("@tinggi", ParseDecimal(txtTinggi.Text));
                        cmd.Parameters.AddWithValue("@lk", ParseDecimal(txtLingkarKepala.Text));
                        cmd.Parameters.AddWithValue("@catatan", txtCatatan.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("✅ Catatan pertumbuhan berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BersihForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Simpan: " + ex.Message);
                DatabaseHelper.CatatLogError("FormPertumbuhan (Tambah): " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPertumbuhan.Text)) { MessageBox.Show("Pilih data dulu di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!Validasi()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdatePertumbuhan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdPertumbuhan.Text));
                        cmd.Parameters.AddWithValue("@tgl", dtpTimbang.Value.Date);
                        cmd.Parameters.AddWithValue("@berat", ParseDecimal(txtBerat.Text));
                        cmd.Parameters.AddWithValue("@tinggi", ParseDecimal(txtTinggi.Text));
                        cmd.Parameters.AddWithValue("@lk", ParseDecimal(txtLingkarKepala.Text));
                        cmd.Parameters.AddWithValue("@catatan", txtCatatan.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("✅ Data berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Update: " + ex.Message);
                DatabaseHelper.CatatLogError("FormPertumbuhan (Update): " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdPertumbuhan.Text)) { MessageBox.Show("Pilih data dulu di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show("Yakin ingin menghapus catatan pertumbuhan ini?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeletePertumbuhan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", int.Parse(txtIdPertumbuhan.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("✅ Data berhasil dihapus!");
                BersihForm();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Hapus: " + ex.Message);
                DatabaseHelper.CatatLogError("FormPertumbuhan (Hapus): " + ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchPertumbuhan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@keyword", txtCari.Text.Trim());

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dtPertumbuhan = new DataTable();
                            da.Fill(dtPertumbuhan);
                            bindingSource.DataSource = dtPertumbuhan;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari data: " + ex.Message);
                DatabaseHelper.CatatLogError("FormPertumbuhan (Cari): " + ex.Message);
            }
        }

        private void btnBersih_Click(object sender, EventArgs e) => BersihForm();

        private void dgvPertumbuhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Dikosongkan
        }

        // ==========================================
        // FITUR BARU: LOGIKA VALIDASI INPUT
        // ==========================================

        // Memblokir huruf dan simbol (kecuali koma dan titik) secara real-time
        private void txtAngkaDesimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Mengizinkan angka, tombol backspace, koma (,), dan titik (.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true; // Memblokir huruf
            }

            // Mencegah pengetikan lebih dari satu koma atau titik
            TextBox txt = sender as TextBox;
            if (txt != null && (e.KeyChar == '.' || e.KeyChar == ',') && (txt.Text.Contains(".") || txt.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        // Validasi saat tombol Simpan/Update ditekan
        private bool Validasi()
        {
            if (cmbBalita.SelectedItem == null)
            {
                MessageBox.Show("Harap pilih data Balita terlebih dahulu!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBerat.Text) || ParseDecimal(txtBerat.Text) <= 0)
            {
                MessageBox.Show("Berat badan wajib diisi dengan angka lebih dari 0!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTinggi.Text) || ParseDecimal(txtTinggi.Text) <= 0)
            {
                MessageBox.Show("Tinggi badan wajib diisi dengan angka lebih dari 0!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTinggi.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtLingkarKepala.Text) && ParseDecimal(txtLingkarKepala.Text) <= 0)
            {
                MessageBox.Show("Jika lingkar kepala diisi, nilainya harus berupa angka lebih dari 0!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLingkarKepala.Focus();
                return false;
            }

            if (Regex.IsMatch(txtCatatan.Text, @"[<>^*%]"))
            {
                MessageBox.Show("Catatan tidak boleh mengandung simbol berbahaya (<, >, ^, *, %)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCatatan.Focus();
                return false;
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
            if (txtIdPertumbuhan != null) txtIdPertumbuhan.Clear();
            if (txtBerat != null) txtBerat.Clear();
            if (txtTinggi != null) txtTinggi.Clear();
            if (txtLingkarKepala != null) txtLingkarKepala.Clear();
            if (txtCatatan != null) txtCatatan.Clear();
            if (txtCari != null) txtCari.Clear();
            if (cmbBalita != null) cmbBalita.SelectedIndex = -1;
            if (dtpTimbang != null) dtpTimbang.Value = DateTime.Today;
        }
    }
}