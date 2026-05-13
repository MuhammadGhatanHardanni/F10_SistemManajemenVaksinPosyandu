namespace PosyanduProject
{
    partial class FormImunisasi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdImunisasi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBalita = new System.Windows.Forms.ComboBox();
            this.Vaksin = new System.Windows.Forms.Label();
            this.cmbVaksin = new System.Windows.Forms.ComboBox();
            this.txtStokInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbJadwal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoAntrean = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSuntik = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnBersih = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.dgvImunisasi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImunisasi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            this.label1.Visible = false;
            // 
            // txtIdImunisasi
            // 
            this.txtIdImunisasi.BackColor = System.Drawing.Color.LightGray;
            this.txtIdImunisasi.Location = new System.Drawing.Point(26, 28);
            this.txtIdImunisasi.Name = "txtIdImunisasi";
            this.txtIdImunisasi.ReadOnly = true;
            this.txtIdImunisasi.Size = new System.Drawing.Size(100, 22);
            this.txtIdImunisasi.TabIndex = 1;
            this.txtIdImunisasi.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Balita";
            // 
            // cmbBalita
            // 
            this.cmbBalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBalita.FormattingEnabled = true;
            this.cmbBalita.Location = new System.Drawing.Point(26, 82);
            this.cmbBalita.Name = "cmbBalita";
            this.cmbBalita.Size = new System.Drawing.Size(200, 24);
            this.cmbBalita.TabIndex = 3;
            // 
            // Vaksin
            // 
            this.Vaksin.AutoSize = true;
            this.Vaksin.Location = new System.Drawing.Point(23, 119);
            this.Vaksin.Name = "Vaksin";
            this.Vaksin.Size = new System.Drawing.Size(48, 16);
            this.Vaksin.TabIndex = 4;
            this.Vaksin.Text = "Vaksin";
            // 
            // cmbVaksin
            // 
            this.cmbVaksin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaksin.FormattingEnabled = true;
            this.cmbVaksin.Location = new System.Drawing.Point(26, 138);
            this.cmbVaksin.Name = "cmbVaksin";
            this.cmbVaksin.Size = new System.Drawing.Size(141, 24);
            this.cmbVaksin.TabIndex = 5;
            this.cmbVaksin.SelectedIndexChanged += new System.EventHandler(this.cmbVaksin_SelectedIndexChanged);
            // 
            // txtStokInfo
            // 
            this.txtStokInfo.Location = new System.Drawing.Point(173, 140);
            this.txtStokInfo.Name = "txtStokInfo";
            this.txtStokInfo.ReadOnly = true;
            this.txtStokInfo.Size = new System.Drawing.Size(53, 22);
            this.txtStokInfo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jadwal";
            // 
            // cmbJadwal
            // 
            this.cmbJadwal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJadwal.FormattingEnabled = true;
            this.cmbJadwal.Location = new System.Drawing.Point(29, 194);
            this.cmbJadwal.Name = "cmbJadwal";
            this.cmbJadwal.Size = new System.Drawing.Size(197, 24);
            this.cmbJadwal.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "No. Antrean";
            // 
            // txtNoAntrean
            // 
            this.txtNoAntrean.Location = new System.Drawing.Point(29, 250);
            this.txtNoAntrean.Name = "txtNoAntrean";
            this.txtNoAntrean.Size = new System.Drawing.Size(100, 22);
            this.txtNoAntrean.TabIndex = 10;
            this.txtNoAntrean.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoAntrean_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tanggal Suntik";
            // 
            // dtpSuntik
            // 
            this.dtpSuntik.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpSuntik.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSuntik.Location = new System.Drawing.Point(26, 304);
            this.dtpSuntik.Name = "dtpSuntik";
            this.dtpSuntik.Size = new System.Drawing.Size(200, 22);
            this.dtpSuntik.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(26, 359);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(103, 24);
            this.cmbStatus.TabIndex = 14;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.Green;
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(25, 401);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 37);
            this.btnSimpan.TabIndex = 15;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Blue;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(106, 401);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 37);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.Red;
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(187, 401);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 37);
            this.btnBatal.TabIndex = 17;
            this.btnBatal.Text = "Batalkan";
            this.btnBatal.UseVisualStyleBackColor = false;
            // 
            // btnBersih
            // 
            this.btnBersih.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBersih.ForeColor = System.Drawing.Color.White;
            this.btnBersih.Location = new System.Drawing.Point(268, 401);
            this.btnBersih.Name = "btnBersih";
            this.btnBersih.Size = new System.Drawing.Size(75, 37);
            this.btnBersih.TabIndex = 18;
            this.btnBersih.Text = "Bersih";
            this.btnBersih.UseVisualStyleBackColor = false;
            this.btnBersih.Click += new System.EventHandler(this.btnBersih_Click);
            // 
            // txtCari
            // 
            this.txtCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCari.Location = new System.Drawing.Point(369, 27);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(190, 22);
            this.txtCari.TabIndex = 19;
            // 
            // btnCari
            // 
            this.btnCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCari.Location = new System.Drawing.Point(565, 27);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 23);
            this.btnCari.TabIndex = 20;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTampilkan.Location = new System.Drawing.Point(646, 27);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(111, 23);
            this.btnTampilkan.TabIndex = 21;
            this.btnTampilkan.Text = "Tampilkan Data";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            // 
            // dgvImunisasi
            // 
            this.dgvImunisasi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImunisasi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImunisasi.BackgroundColor = System.Drawing.Color.White;
            this.dgvImunisasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImunisasi.Location = new System.Drawing.Point(369, 63);
            this.dgvImunisasi.Name = "dgvImunisasi";
            this.dgvImunisasi.RowHeadersWidth = 51;
            this.dgvImunisasi.RowTemplate.Height = 24;
            this.dgvImunisasi.Size = new System.Drawing.Size(388, 375);
            this.dgvImunisasi.TabIndex = 22;
            this.dgvImunisasi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImunisasi_CellClick);
            // 
            // FormImunisasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvImunisasi);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnBersih);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpSuntik);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoAntrean);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbJadwal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStokInfo);
            this.Controls.Add(this.cmbVaksin);
            this.Controls.Add(this.Vaksin);
            this.Controls.Add(this.cmbBalita);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdImunisasi);
            this.Controls.Add(this.label1);
            this.Name = "FormImunisasi";
            this.Text = "FormImunisasi";
            this.Load += new System.EventHandler(this.FormImunisasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImunisasi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdImunisasi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBalita;
        private System.Windows.Forms.Label Vaksin;
        private System.Windows.Forms.ComboBox cmbVaksin;
        private System.Windows.Forms.TextBox txtStokInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbJadwal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoAntrean;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSuntik;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnBersih;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.DataGridView dgvImunisasi;
    }
}