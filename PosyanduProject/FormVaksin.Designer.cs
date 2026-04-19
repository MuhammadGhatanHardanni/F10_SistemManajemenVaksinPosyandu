namespace PosyanduProject
{
    partial class FormVaksin
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
            this.txtIdVaksin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNamaVaksin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStok = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpKedaluwarsa = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeskripsi = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnBersih = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.dgvVaksin = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaksin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Vaksin";
            // 
            // txtIdVaksin
            // 
            this.txtIdVaksin.Location = new System.Drawing.Point(66, 86);
            this.txtIdVaksin.Name = "txtIdVaksin";
            this.txtIdVaksin.ReadOnly = true;
            this.txtIdVaksin.Size = new System.Drawing.Size(100, 22);
            this.txtIdVaksin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Vaksin";
            // 
            // txtNamaVaksin
            // 
            this.txtNamaVaksin.Location = new System.Drawing.Point(69, 142);
            this.txtNamaVaksin.Name = "txtNamaVaksin";
            this.txtNamaVaksin.Size = new System.Drawing.Size(173, 22);
            this.txtNamaVaksin.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stok";
            // 
            // txtStok
            // 
            this.txtStok.Location = new System.Drawing.Point(69, 196);
            this.txtStok.Name = "txtStok";
            this.txtStok.Size = new System.Drawing.Size(173, 22);
            this.txtStok.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tgl Expired";
            // 
            // dtpKedaluwarsa
            // 
            this.dtpKedaluwarsa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKedaluwarsa.Location = new System.Drawing.Point(69, 251);
            this.dtpKedaluwarsa.Name = "dtpKedaluwarsa";
            this.dtpKedaluwarsa.Size = new System.Drawing.Size(200, 22);
            this.dtpKedaluwarsa.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Deskripsi";
            // 
            // txtDeskripsi
            // 
            this.txtDeskripsi.Location = new System.Drawing.Point(66, 305);
            this.txtDeskripsi.Multiline = true;
            this.txtDeskripsi.Name = "txtDeskripsi";
            this.txtDeskripsi.Size = new System.Drawing.Size(176, 58);
            this.txtDeskripsi.TabIndex = 9;
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Green;
            this.btnTambah.ForeColor = System.Drawing.Color.White;
            this.btnTambah.Location = new System.Drawing.Point(66, 369);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(80, 35);
            this.btnTambah.TabIndex = 10;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Blue;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(167, 369);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 35);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(69, 410);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(80, 35);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnBersih
            // 
            this.btnBersih.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnBersih.ForeColor = System.Drawing.Color.White;
            this.btnBersih.Location = new System.Drawing.Point(167, 410);
            this.btnBersih.Name = "btnBersih";
            this.btnBersih.Size = new System.Drawing.Size(80, 35);
            this.btnBersih.TabIndex = 13;
            this.btnBersih.Text = "Bersih";
            this.btnBersih.UseVisualStyleBackColor = false;
            this.btnBersih.Click += new System.EventHandler(this.btnBersih_Click);
            // 
            // txtCari
            // 
            this.txtCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCari.Location = new System.Drawing.Point(374, 45);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(156, 22);
            this.txtCari.TabIndex = 14;
            this.txtCari.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCari_KeyDown);
            // 
            // btnCari
            // 
            this.btnCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCari.Location = new System.Drawing.Point(536, 44);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 23);
            this.btnCari.TabIndex = 15;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTampilkan.Location = new System.Drawing.Point(617, 45);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(111, 23);
            this.btnTampilkan.TabIndex = 16;
            this.btnTampilkan.Text = "Tampilkan Data";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // dgvVaksin
            // 
            this.dgvVaksin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVaksin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVaksin.BackgroundColor = System.Drawing.Color.White;
            this.dgvVaksin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaksin.Location = new System.Drawing.Point(374, 86);
            this.dgvVaksin.Name = "dgvVaksin";
            this.dgvVaksin.RowHeadersVisible = false;
            this.dgvVaksin.RowHeadersWidth = 51;
            this.dgvVaksin.RowTemplate.Height = 24;
            this.dgvVaksin.Size = new System.Drawing.Size(354, 326);
            this.dgvVaksin.TabIndex = 17;
            this.dgvVaksin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVaksin_CellClick);
            // 
            // FormVaksin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvVaksin);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnBersih);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtDeskripsi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpKedaluwarsa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNamaVaksin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdVaksin);
            this.Controls.Add(this.label1);
            this.Name = "FormVaksin";
            this.Text = "FormVaksin";
            this.Load += new System.EventHandler(this.FormVaksin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaksin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdVaksin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNamaVaksin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpKedaluwarsa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDeskripsi;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnBersih;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.DataGridView dgvVaksin;
    }
}