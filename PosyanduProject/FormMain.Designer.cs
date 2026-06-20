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
            this.btnMenuPertumbuhan = new System.Windows.Forms.Button();
            this.btnMenuImunisasi = new System.Windows.Forms.Button();
            this.btnMenuJadwal = new System.Windows.Forms.Button();
            this.btnMenuBalita = new System.Windows.Forms.Button();
            this.btnMenuVaksin = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnMenuLaporan);
            this.pnlSidebar.Controls.Add(this.btnMenuPertumbuhan);
            this.pnlSidebar.Controls.Add(this.btnMenuImunisasi);
            this.pnlSidebar.Controls.Add(this.btnMenuJadwal);
            this.pnlSidebar.Controls.Add(this.btnMenuBalita);
            this.pnlSidebar.Controls.Add(this.btnMenuVaksin);
            this.pnlSidebar.Controls.Add(this.pictureBox1);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 603);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnMenuVaksin
            // 
            this.btnMenuVaksin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuVaksin.FlatAppearance.BorderSize = 0;
            this.btnMenuVaksin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnMenuVaksin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuVaksin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuVaksin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnMenuVaksin.Location = new System.Drawing.Point(0, 160);
            this.btnMenuVaksin.Name = "btnMenuVaksin";
            this.btnMenuVaksin.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuVaksin.Size = new System.Drawing.Size(250, 50);
            this.btnMenuVaksin.TabIndex = 4;
            this.btnMenuVaksin.Text = "Kelola Vaksin";
            this.btnMenuVaksin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuVaksin.UseVisualStyleBackColor = true;
            this.btnMenuVaksin.Click += new System.EventHandler(this.btnMenuVaksin_Click);
            // 
            // btnMenuBalita
            // 
            this.btnMenuBalita.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuBalita.FlatAppearance.BorderSize = 0;
            this.btnMenuBalita.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnMenuBalita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBalita.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuBalita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnMenuBalita.Location = new System.Drawing.Point(0, 210);
            this.btnMenuBalita.Name = "btnMenuBalita";
            this.btnMenuBalita.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuBalita.Size = new System.Drawing.Size(250, 50);
            this.btnMenuBalita.TabIndex = 3;
            this.btnMenuBalita.Text = "Kelola Balita";
            this.btnMenuBalita.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuBalita.UseVisualStyleBackColor = true;
            this.btnMenuBalita.Click += new System.EventHandler(this.btnMenuBalita_Click);
            // 
            // btnMenuJadwal
            // 
            this.btnMenuJadwal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuJadwal.FlatAppearance.BorderSize = 0;
            this.btnMenuJadwal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnMenuJadwal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuJadwal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuJadwal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnMenuJadwal.Location = new System.Drawing.Point(0, 260);
            this.btnMenuJadwal.Name = "btnMenuJadwal";
            this.btnMenuJadwal.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuJadwal.Size = new System.Drawing.Size(250, 50);
            this.btnMenuJadwal.TabIndex = 2;
            this.btnMenuJadwal.Text = "Jadwal Posyandu";
            this.btnMenuJadwal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuJadwal.UseVisualStyleBackColor = true;
            this.btnMenuJadwal.Click += new System.EventHandler(this.btnMenuJadwal_Click);
            // 
            // btnMenuImunisasi
            // 
            this.btnMenuImunisasi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuImunisasi.FlatAppearance.BorderSize = 0;
            this.btnMenuImunisasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnMenuImunisasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuImunisasi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuImunisasi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnMenuImunisasi.Location = new System.Drawing.Point(0, 310);
            this.btnMenuImunisasi.Name = "btnMenuImunisasi";
            this.btnMenuImunisasi.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuImunisasi.Size = new System.Drawing.Size(250, 50);
            this.btnMenuImunisasi.TabIndex = 1;
            this.btnMenuImunisasi.Text = "Input Imunisasi";
            this.btnMenuImunisasi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuImunisasi.UseVisualStyleBackColor = true;
            this.btnMenuImunisasi.Click += new System.EventHandler(this.btnMenuImunisasi_Click);
            // 
            // btnMenuPertumbuhan
            // 
            this.btnMenuPertumbuhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuPertumbuhan.FlatAppearance.BorderSize = 0;
            this.btnMenuPertumbuhan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnMenuPertumbuhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPertumbuhan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuPertumbuhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnMenuPertumbuhan.Location = new System.Drawing.Point(0, 360);
            this.btnMenuPertumbuhan.Name = "btnMenuPertumbuhan";
            this.btnMenuPertumbuhan.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuPertumbuhan.Size = new System.Drawing.Size(250, 50);
            this.btnMenuPertumbuhan.TabIndex = 7;
            this.btnMenuPertumbuhan.Text = "Pertumbuhan Balita";
            this.btnMenuPertumbuhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPertumbuhan.UseVisualStyleBackColor = true;
            this.btnMenuPertumbuhan.Click += new System.EventHandler(this.btnMenuPertumbuhan_Click);
            // 
            // btnMenuLaporan
            // 
            this.btnMenuLaporan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuLaporan.FlatAppearance.BorderSize = 0;
            this.btnMenuLaporan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.btnMenuLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLaporan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenuLaporan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.btnMenuLaporan.Location = new System.Drawing.Point(0, 410);
            this.btnMenuLaporan.Name = "btnMenuLaporan";
            this.btnMenuLaporan.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuLaporan.Size = new System.Drawing.Size(250, 50);
            this.btnMenuLaporan.TabIndex = 0;
            this.btnMenuLaporan.Text = "Laporan";
            this.btnMenuLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuLaporan.UseVisualStyleBackColor = true;
            this.btnMenuLaporan.Click += new System.EventHandler(this.btnMenuLaporan_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 543);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(250, 60);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(250, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(692, 603);
            this.pnlContent.TabIndex = 1;
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