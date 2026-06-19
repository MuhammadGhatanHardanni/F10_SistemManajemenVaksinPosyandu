namespace PosyanduProject
{
    partial class FormLaporan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnRefreshStok = new System.Windows.Forms.Button();
            this.labelBulan = new System.Windows.Forms.Label();
            this.cmbBulan = new System.Windows.Forms.ComboBox();
            this.labelTahun = new System.Windows.Forms.Label();
            this.cmbTahun = new System.Windows.Forms.ComboBox();
            this.btnFilterCakupan = new System.Windows.Forms.Button();
            this.lblStatusLaporan = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.chartVaksin = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVaksin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshStok
            // 
            this.btnRefreshStok.Location = new System.Drawing.Point(12, 12);
            this.btnRefreshStok.Name = "btnRefreshStok";
            this.btnRefreshStok.Size = new System.Drawing.Size(86, 23);
            this.btnRefreshStok.TabIndex = 0;
            this.btnRefreshStok.Text = "Stok Vaksin";
            this.btnRefreshStok.UseVisualStyleBackColor = true;
            this.btnRefreshStok.Click += new System.EventHandler(this.btnRefreshStok_Click);
            // 
            // labelBulan
            // 
            this.labelBulan.AutoSize = true;
            this.labelBulan.Location = new System.Drawing.Point(123, 15);
            this.labelBulan.Name = "labelBulan";
            this.labelBulan.Size = new System.Drawing.Size(44, 16);
            this.labelBulan.TabIndex = 1;
            this.labelBulan.Text = "Bulan:";
            // 
            // cmbBulan
            // 
            this.cmbBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBulan.FormattingEnabled = true;
            this.cmbBulan.Location = new System.Drawing.Point(187, 13);
            this.cmbBulan.Name = "cmbBulan";
            this.cmbBulan.Size = new System.Drawing.Size(121, 24);
            this.cmbBulan.TabIndex = 2;
            // 
            // labelTahun
            // 
            this.labelTahun.AutoSize = true;
            this.labelTahun.Location = new System.Drawing.Point(335, 15);
            this.labelTahun.Name = "labelTahun";
            this.labelTahun.Size = new System.Drawing.Size(48, 16);
            this.labelTahun.TabIndex = 3;
            this.labelTahun.Text = "Tahun:";
            // 
            // cmbTahun
            // 
            this.cmbTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTahun.FormattingEnabled = true;
            this.cmbTahun.Location = new System.Drawing.Point(402, 11);
            this.cmbTahun.Name = "cmbTahun";
            this.cmbTahun.Size = new System.Drawing.Size(121, 24);
            this.cmbTahun.TabIndex = 4;
            // 
            // btnFilterCakupan
            // 
            this.btnFilterCakupan.Location = new System.Drawing.Point(552, 12);
            this.btnFilterCakupan.Name = "btnFilterCakupan";
            this.btnFilterCakupan.Size = new System.Drawing.Size(151, 23);
            this.btnFilterCakupan.TabIndex = 5;
            this.btnFilterCakupan.Text = "Filter Laporan Bulanan";
            this.btnFilterCakupan.UseVisualStyleBackColor = true;
            this.btnFilterCakupan.Click += new System.EventHandler(this.btnFilterCakupan_Click);
            // 
            // lblStatusLaporan
            // 
            this.lblStatusLaporan.AutoSize = true;
            this.lblStatusLaporan.Location = new System.Drawing.Point(12, 59);
            this.lblStatusLaporan.Name = "lblStatusLaporan";
            this.lblStatusLaporan.Size = new System.Drawing.Size(103, 16);
            this.lblStatusLaporan.TabIndex = 6;
            this.lblStatusLaporan.Text = "Menampilkan: ...";
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvLaporan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(15, 89);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersVisible = false;
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.RowTemplate.Height = 24;
            this.dgvLaporan.Size = new System.Drawing.Size(467, 349);
            this.dgvLaporan.TabIndex = 7;
            // 
            // chartVaksin
            // 
            this.chartVaksin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartVaksin.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVaksin.Legends.Add(legend1);
            this.chartVaksin.Location = new System.Drawing.Point(488, 89);
            this.chartVaksin.Name = "chartVaksin";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartVaksin.Series.Add(series1);
            this.chartVaksin.Size = new System.Drawing.Size(300, 349);
            this.chartVaksin.TabIndex = 8;
            this.chartVaksin.Text = "chart1";
            this.chartVaksin.Click += new System.EventHandler(this.chartVaksin_Click);
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartVaksin);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.lblStatusLaporan);
            this.Controls.Add(this.btnFilterCakupan);
            this.Controls.Add(this.cmbTahun);
            this.Controls.Add(this.labelTahun);
            this.Controls.Add(this.cmbBulan);
            this.Controls.Add(this.labelBulan);
            this.Controls.Add(this.btnRefreshStok);
            this.Name = "FormLaporan";
            this.Text = "FormLaporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVaksin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefreshStok;
        private System.Windows.Forms.Label labelBulan;
        private System.Windows.Forms.ComboBox cmbBulan;
        private System.Windows.Forms.Label labelTahun;
        private System.Windows.Forms.ComboBox cmbTahun;
        private System.Windows.Forms.Button btnFilterCakupan;
        private System.Windows.Forms.Label lblStatusLaporan;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVaksin;
    }
}