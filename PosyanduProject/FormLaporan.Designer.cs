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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnRefreshStok = new System.Windows.Forms.Button();
            this.labelBulan = new System.Windows.Forms.Label();
            this.cmbBulan = new System.Windows.Forms.ComboBox();
            this.labelTahun = new System.Windows.Forms.Label();
            this.cmbTahun = new System.Windows.Forms.ComboBox();
            this.btnFilterCakupan = new System.Windows.Forms.Button();
            this.lblStatusLaporan = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.chartVaksin = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnCetakStok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVaksin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshStok
            // 
            this.btnRefreshStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnRefreshStok.FlatAppearance.BorderSize = 0;
            this.btnRefreshStok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStok.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshStok.ForeColor = System.Drawing.Color.White;
            this.btnRefreshStok.Location = new System.Drawing.Point(30, 80);
            this.btnRefreshStok.Name = "btnRefreshStok";
            this.btnRefreshStok.Size = new System.Drawing.Size(150, 35);
            this.btnRefreshStok.TabIndex = 0;
            this.btnRefreshStok.Text = "Rekap Stok Vaksin";
            this.btnRefreshStok.UseVisualStyleBackColor = false;
            this.btnRefreshStok.Click += new System.EventHandler(this.btnRefreshStok_Click);
            // 
            // labelBulan
            // 
            this.labelBulan.AutoSize = true;
            this.labelBulan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelBulan.Location = new System.Drawing.Point(200, 87);
            this.labelBulan.Name = "labelBulan";
            this.labelBulan.Size = new System.Drawing.Size(49, 20);
            this.labelBulan.TabIndex = 1;
            this.labelBulan.Text = "Bulan:";
            // 
            // cmbBulan
            // 
            this.cmbBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBulan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbBulan.FormattingEnabled = true;
            this.cmbBulan.Location = new System.Drawing.Point(250, 84);
            this.cmbBulan.Name = "cmbBulan";
            this.cmbBulan.Size = new System.Drawing.Size(120, 28);
            this.cmbBulan.TabIndex = 2;
            // 
            // labelTahun
            // 
            this.labelTahun.AutoSize = true;
            this.labelTahun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelTahun.Location = new System.Drawing.Point(390, 87);
            this.labelTahun.Name = "labelTahun";
            this.labelTahun.Size = new System.Drawing.Size(50, 20);
            this.labelTahun.TabIndex = 3;
            this.labelTahun.Text = "Tahun:";
            // 
            // cmbTahun
            // 
            this.cmbTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTahun.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbTahun.FormattingEnabled = true;
            this.cmbTahun.Location = new System.Drawing.Point(440, 84);
            this.cmbTahun.Name = "cmbTahun";
            this.cmbTahun.Size = new System.Drawing.Size(100, 28);
            this.cmbTahun.TabIndex = 4;
            // 
            // btnFilterCakupan
            // 
            this.btnFilterCakupan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnFilterCakupan.FlatAppearance.BorderSize = 0;
            this.btnFilterCakupan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterCakupan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFilterCakupan.ForeColor = System.Drawing.Color.White;
            this.btnFilterCakupan.Location = new System.Drawing.Point(560, 80);
            this.btnFilterCakupan.Name = "btnFilterCakupan";
            this.btnFilterCakupan.Size = new System.Drawing.Size(180, 35);
            this.btnFilterCakupan.TabIndex = 5;
            this.btnFilterCakupan.Text = "Filter Laporan Cakupan";
            this.btnFilterCakupan.UseVisualStyleBackColor = false;
            this.btnFilterCakupan.Click += new System.EventHandler(this.btnFilterCakupan_Click);
            // 
            // lblStatusLaporan
            // 
            this.lblStatusLaporan.AutoSize = true;
            this.lblStatusLaporan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusLaporan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatusLaporan.Location = new System.Drawing.Point(30, 130);
            this.lblStatusLaporan.Name = "lblStatusLaporan";
            this.lblStatusLaporan.Size = new System.Drawing.Size(145, 23);
            this.lblStatusLaporan.TabIndex = 6;
            this.lblStatusLaporan.Text = "Menampilkan: ...";
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvLaporan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaporan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLaporan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLaporan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLaporan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLaporan.ColumnHeadersHeight = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaporan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLaporan.EnableHeadersVisualStyles = false;
            this.dgvLaporan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvLaporan.Location = new System.Drawing.Point(30, 160);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.RowHeadersVisible = false;
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.RowTemplate.Height = 35;
            this.dgvLaporan.Size = new System.Drawing.Size(600, 520);
            this.dgvLaporan.TabIndex = 7;
            // 
            // chartVaksin
            // 
            this.chartVaksin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartVaksin.ChartAreas.Add(chartArea2);
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartVaksin.Legends.Add(legend2);
            this.chartVaksin.Location = new System.Drawing.Point(650, 160);
            this.chartVaksin.Name = "chartVaksin";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartVaksin.Series.Add(series2);
            this.chartVaksin.Size = new System.Drawing.Size(600, 520);
            this.chartVaksin.TabIndex = 8;
            this.chartVaksin.Text = "chart1";
            this.chartVaksin.Click += new System.EventHandler(this.chartVaksin_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(336, 37);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "Laporan & Visualisasi Data";
            // 
            // btnCetak
            // 
            this.btnCetak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCetak.FlatAppearance.BorderSize = 0;
            this.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetak.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCetak.ForeColor = System.Drawing.Color.White;
            this.btnCetak.Location = new System.Drawing.Point(760, 80);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(140, 35);
            this.btnCetak.TabIndex = 25;
            this.btnCetak.Text = "Cetak Laporan";
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // btnCetakStok
            // 
            this.btnCetakStok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
            this.btnCetakStok.FlatAppearance.BorderSize = 0;
            this.btnCetakStok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetakStok.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCetakStok.ForeColor = System.Drawing.Color.White;
            this.btnCetakStok.Location = new System.Drawing.Point(920, 80);
            this.btnCetakStok.Name = "btnCetakStok";
            this.btnCetakStok.Size = new System.Drawing.Size(150, 35);
            this.btnCetakStok.TabIndex = 26;
            this.btnCetakStok.Text = "Cetak Stok Vaksin";
            this.btnCetakStok.UseVisualStyleBackColor = false;
            this.btnCetakStok.Click += new System.EventHandler(this.btnCetakStok_Click);
            // 
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btnCetakStok);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.lblTitle);
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
            this.Text = "Laporan & Visualisasi";
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
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnCetakStok;
    }
}