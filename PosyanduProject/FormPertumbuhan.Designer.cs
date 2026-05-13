namespace PosyanduProject
{
    partial class FormPertumbuhan
    {
        private System.ComponentModel.IContainer components = null;

        // Deklarasi Komponen UI
        private System.Windows.Forms.ComboBox cmbBalita;
        private System.Windows.Forms.DateTimePicker dtpTimbang;
        private System.Windows.Forms.TextBox txtBerat;
        private System.Windows.Forms.TextBox txtTinggi;
        private System.Windows.Forms.TextBox txtLingkarKepala;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.TextBox txtIdPertumbuhan;
        private System.Windows.Forms.DataGridView dgvPertumbuhan;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnBersih;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label lbl1, lbl2, lbl3, lbl4, lbl5, lbl6, lbl7;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbBalita = new System.Windows.Forms.ComboBox();
            this.dtpTimbang = new System.Windows.Forms.DateTimePicker();
            this.txtBerat = new System.Windows.Forms.TextBox();
            this.txtTinggi = new System.Windows.Forms.TextBox();
            this.txtLingkarKepala = new System.Windows.Forms.TextBox();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.txtIdPertumbuhan = new System.Windows.Forms.TextBox();
            this.dgvPertumbuhan = new System.Windows.Forms.DataGridView();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnBersih = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPertumbuhan)).BeginInit();
            this.SuspendLayout();

            // === Pengaturan Form ===
            this.Text = "Manajemen Pertumbuhan Balita";
            this.Size = new System.Drawing.Size(920, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // === Posisi Label & Input (Sisi Kiri) ===
            int xLabel = 20, xInput = 140, yStart = 30, gap = 35;

            // ID Pertumbuhan
            this.lbl1.Text = "ID:"; this.lbl1.Location = new System.Drawing.Point(xLabel, yStart);
            this.txtIdPertumbuhan.Location = new System.Drawing.Point(xInput, yStart - 3);
            this.txtIdPertumbuhan.Size = new System.Drawing.Size(100, 20);

            // Pilih Balita
            this.lbl2.Text = "Balita:"; this.lbl2.Location = new System.Drawing.Point(xLabel, yStart + gap);
            this.cmbBalita.Location = new System.Drawing.Point(xInput, yStart + gap - 3);
            this.cmbBalita.Size = new System.Drawing.Size(200, 21);
            this.cmbBalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Tanggal Timbang
            this.lbl3.Text = "Tgl Timbang:"; this.lbl3.Location = new System.Drawing.Point(xLabel, yStart + (gap * 2));
            this.dtpTimbang.Location = new System.Drawing.Point(xInput, yStart + (gap * 2) - 3);
            this.dtpTimbang.Size = new System.Drawing.Size(200, 20);

            // Berat Badan
            this.lbl4.Text = "Berat (kg):"; this.lbl4.Location = new System.Drawing.Point(xLabel, yStart + (gap * 3));
            this.txtBerat.Location = new System.Drawing.Point(xInput, yStart + (gap * 3) - 3);
            this.txtBerat.Size = new System.Drawing.Size(80, 20);

            // Tinggi Badan
            this.lbl5.Text = "Tinggi (cm):"; this.lbl5.Location = new System.Drawing.Point(xLabel, yStart + (gap * 4));
            this.txtTinggi.Location = new System.Drawing.Point(xInput, yStart + (gap * 4) - 3);
            this.txtTinggi.Size = new System.Drawing.Size(80, 20);

            // Lingkar Kepala
            this.lbl6.Text = "Lingkar Kepala:"; this.lbl6.Location = new System.Drawing.Point(xLabel, yStart + (gap * 5));
            this.txtLingkarKepala.Location = new System.Drawing.Point(xInput, yStart + (gap * 5) - 3);
            this.txtLingkarKepala.Size = new System.Drawing.Size(80, 20);

            // Catatan
            this.lbl7.Text = "Catatan:"; this.lbl7.Location = new System.Drawing.Point(xLabel, yStart + (gap * 6));
            this.txtCatatan.Location = new System.Drawing.Point(xInput, yStart + (gap * 6) - 3);
            this.txtCatatan.Size = new System.Drawing.Size(200, 80);
            this.txtCatatan.Multiline = true;

            // === Tombol (Sisi Kiri Bawah) ===
            this.btnSimpan.Text = "Simpan"; this.btnSimpan.Location = new System.Drawing.Point(20, 350);
            this.btnSimpan.BackColor = System.Drawing.Color.DarkGreen; this.btnSimpan.ForeColor = System.Drawing.Color.White;

            this.btnUpdate.Text = "Update"; this.btnUpdate.Location = new System.Drawing.Point(100, 350);
            this.btnUpdate.BackColor = System.Drawing.Color.DarkBlue; this.btnUpdate.ForeColor = System.Drawing.Color.White;

            this.btnHapus.Text = "Hapus"; this.btnHapus.Location = new System.Drawing.Point(180, 350);
            this.btnHapus.BackColor = System.Drawing.Color.DarkRed; this.btnHapus.ForeColor = System.Drawing.Color.White;

            this.btnBersih.Text = "Bersih"; this.btnBersih.Location = new System.Drawing.Point(260, 350);

            // === Pencarian & Tabel (Sisi Kanan) ===
            this.txtCari.Location = new System.Drawing.Point(400, 27);
            this.txtCari.Size = new System.Drawing.Size(350, 20);

            this.btnCari.Text = "Cari"; this.btnCari.Location = new System.Drawing.Point(760, 25);

            this.dgvPertumbuhan.Location = new System.Drawing.Point(400, 60);
            this.dgvPertumbuhan.Size = new System.Drawing.Size(480, 430);
            this.dgvPertumbuhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPertumbuhan.AllowUserToAddRows = false;
            this.dgvPertumbuhan.ReadOnly = true;

            // === Menambahkan ke Form ===
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lbl1, this.lbl2, this.lbl3, this.lbl4, this.lbl5, this.lbl6, this.lbl7,
                this.txtIdPertumbuhan, this.cmbBalita, this.dtpTimbang, this.txtBerat,
                this.txtTinggi, this.txtLingkarKepala, this.txtCatatan, this.txtCari,
                this.btnSimpan, this.btnUpdate, this.btnHapus, this.btnBersih, this.btnCari,
                this.dgvPertumbuhan
            });

            // === Menghubungkan Event ke Kode .cs ===
            this.Load += new System.EventHandler(this.FormPertumbuhan_Load);
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            this.btnBersih.Click += new System.EventHandler(this.btnBersih_Click);
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            this.dgvPertumbuhan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPertumbuhan_CellClick);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPertumbuhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}