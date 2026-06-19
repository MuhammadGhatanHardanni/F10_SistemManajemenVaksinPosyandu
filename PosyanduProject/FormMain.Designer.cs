namespace PosyanduProject
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMenuLaporan = new System.Windows.Forms.Button();
            this.btnMenuPertumbuhan = new System.Windows.Forms.Button(); // Tambahan baru
            this.btnMenuVaksin = new System.Windows.Forms.Button();
            this.btnMenuBalita = new System.Windows.Forms.Button();
            this.btnMenuJadwal = new System.Windows.Forms.Button();
            this.btnMenuImunisasi = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.pnlSidebar.Controls.Add(this.pictureBox1);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnMenuLaporan);
            this.pnlSidebar.Controls.Add(this.btnMenuPertumbuhan); // Menambahkan ke sidebar
            this.pnlSidebar.Controls.Add(this.btnMenuImunisasi);
            this.pnlSidebar.Controls.Add(this.btnMenuJadwal);
            this.pnlSidebar.Controls.Add(this.btnMenuBalita);
            this.pnlSidebar.Controls.Add(this.btnMenuVaksin);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 603);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 264);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 44);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMenuLaporan
            // 
            this.btnMenuLaporan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuLaporan.FlatAppearance.BorderSize = 0;
            this.btnMenuLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLaporan.ForeColor = System.Drawing.Color.White;
            this.btnMenuLaporan.Location = new System.Drawing.Point(0, 220);
            this.btnMenuLaporan.Name = "btnMenuLaporan";
            this.btnMenuLaporan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuLaporan.Size = new System.Drawing.Size(200, 44);
            this.btnMenuLaporan.TabIndex = 0;
            this.btnMenuLaporan.Text = "Laporan";
            this.btnMenuLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuLaporan.UseVisualStyleBackColor = true;
            this.btnMenuLaporan.Click += new System.EventHandler(this.btnMenuLaporan_Click);
            // 
            // btnMenuPertumbuhan
            // 
            this.btnMenuPertumbuhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuPertumbuhan.FlatAppearance.BorderSize = 0;
            this.btnMenuPertumbuhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPertumbuhan.ForeColor = System.Drawing.Color.White;
            this.btnMenuPertumbuhan.Location = new System.Drawing.Point(0, 176);
            this.btnMenuPertumbuhan.Name = "btnMenuPertumbuhan";
            this.btnMenuPertumbuhan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuPertumbuhan.Size = new System.Drawing.Size(200, 44);
            this.btnMenuPertumbuhan.TabIndex = 7;
            this.btnMenuPertumbuhan.Text = "Pertumbuhan Balita";
            this.btnMenuPertumbuhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPertumbuhan.UseVisualStyleBackColor = true;
            this.btnMenuPertumbuhan.Click += new System.EventHandler(this.btnMenuPertumbuhan_Click);
            // 
            // btnMenuImunisasi
            // 
            this.btnMenuImunisasi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuImunisasi.FlatAppearance.BorderSize = 0;
            this.btnMenuImunisasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuImunisasi.ForeColor = System.Drawing.Color.White;
            this.btnMenuImunisasi.Location = new System.Drawing.Point(0, 132);
            this.btnMenuImunisasi.Name = "btnMenuImunisasi";
            this.btnMenuImunisasi.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuImunisasi.Size = new System.Drawing.Size(200, 44);
            this.btnMenuImunisasi.TabIndex = 1;
            this.btnMenuImunisasi.Text = "Input Imunisasi";
            this.btnMenuImunisasi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuImunisasi.UseVisualStyleBackColor = true;
            this.btnMenuImunisasi.Click += new System.EventHandler(this.btnMenuImunisasi_Click);
            // 
            // btnMenuJadwal
            // 
            this.btnMenuJadwal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuJadwal.FlatAppearance.BorderSize = 0;
            this.btnMenuJadwal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuJadwal.ForeColor = System.Drawing.Color.White;
            this.btnMenuJadwal.Location = new System.Drawing.Point(0, 88);
            this.btnMenuJadwal.Name = "btnMenuJadwal";
            this.btnMenuJadwal.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuJadwal.Size = new System.Drawing.Size(200, 44);
            this.btnMenuJadwal.TabIndex = 2;
            this.btnMenuJadwal.Text = "Jadwal Posyandu";
            this.btnMenuJadwal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuJadwal.UseVisualStyleBackColor = true;
            this.btnMenuJadwal.Click += new System.EventHandler(this.btnMenuJadwal_Click);
            // 
            // btnMenuBalita
            // 
            this.btnMenuBalita.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuBalita.FlatAppearance.BorderSize = 0;
            this.btnMenuBalita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBalita.ForeColor = System.Drawing.Color.White;
            this.btnMenuBalita.Location = new System.Drawing.Point(0, 44);
            this.btnMenuBalita.Name = "btnMenuBalita";
            this.btnMenuBalita.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuBalita.Size = new System.Drawing.Size(200, 44);
            this.btnMenuBalita.TabIndex = 3;
            this.btnMenuBalita.Text = "Kelola Balita";
            this.btnMenuBalita.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuBalita.UseVisualStyleBackColor = true;
            this.btnMenuBalita.Click += new System.EventHandler(this.btnMenuBalita_Click);
            // 
            // btnMenuVaksin
            // 
            this.btnMenuVaksin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuVaksin.FlatAppearance.BorderSize = 0;
            this.btnMenuVaksin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuVaksin.ForeColor = System.Drawing.Color.White;
            this.btnMenuVaksin.Location = new System.Drawing.Point(0, 0);
            this.btnMenuVaksin.Name = "btnMenuVaksin";
            this.btnMenuVaksin.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuVaksin.Size = new System.Drawing.Size(200, 44);
            this.btnMenuVaksin.TabIndex = 4;
            this.btnMenuVaksin.Text = "Kelola Vaksin";
            this.btnMenuVaksin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuVaksin.UseVisualStyleBackColor = true;
            this.btnMenuVaksin.Click += new System.EventHandler(this.btnMenuVaksin_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(742, 603);
            this.pnlContent.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 409);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 603);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Manajemen Vaksin Posyandu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMenuVaksin;
        private System.Windows.Forms.Button btnMenuBalita;
        private System.Windows.Forms.Button btnMenuJadwal;
        private System.Windows.Forms.Button btnMenuImunisasi;
        private System.Windows.Forms.Button btnMenuPertumbuhan; // Deklarasi tombol baru
        private System.Windows.Forms.Button btnMenuLaporan;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}