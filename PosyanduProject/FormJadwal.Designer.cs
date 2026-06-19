namespace PosyanduProject
{
    partial class FormJadwal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJadwal));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdJadwal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPelaksanaan = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLokasi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnBersih = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.dgvJadwal = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Jadwal";
            this.label1.Visible = false;
            // 
            // txtIdJadwal
            // 
            this.txtIdJadwal.Location = new System.Drawing.Point(15, 28);
            this.txtIdJadwal.Name = "txtIdJadwal";
            this.txtIdJadwal.ReadOnly = true;
            this.txtIdJadwal.Size = new System.Drawing.Size(63, 22);
            this.txtIdJadwal.TabIndex = 1;
            this.txtIdJadwal.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tanggal Pelaksanaan";
            // 
            // dtpPelaksanaan
            // 
            this.dtpPelaksanaan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPelaksanaan.Location = new System.Drawing.Point(18, 91);
            this.dtpPelaksanaan.Name = "dtpPelaksanaan";
            this.dtpPelaksanaan.Size = new System.Drawing.Size(138, 22);
            this.dtpPelaksanaan.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lokasi";
            // 
            // txtLokasi
            // 
            this.txtLokasi.Location = new System.Drawing.Point(21, 150);
            this.txtLokasi.Name = "txtLokasi";
            this.txtLokasi.Size = new System.Drawing.Size(135, 22);
            this.txtLokasi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(21, 213);
            this.txtKeterangan.Multiline = true;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(135, 77);
            this.txtKeterangan.TabIndex = 7;
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Green;
            this.btnTambah.ForeColor = System.Drawing.Color.White;
            this.btnTambah.Location = new System.Drawing.Point(21, 296);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 35);
            this.btnTambah.TabIndex = 8;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Blue;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(142, 296);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 36);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(21, 367);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 35);
            this.btnHapus.TabIndex = 10;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnBersih
            // 
            this.btnBersih.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnBersih.Location = new System.Drawing.Point(142, 367);
            this.btnBersih.Name = "btnBersih";
            this.btnBersih.Size = new System.Drawing.Size(75, 35);
            this.btnBersih.TabIndex = 11;
            this.btnBersih.Text = "Bersih";
            this.btnBersih.UseVisualStyleBackColor = false;
            this.btnBersih.Click += new System.EventHandler(this.btnBersih_Click);
            // 
            // txtCari
            // 
            this.txtCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCari.Location = new System.Drawing.Point(368, 32);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(190, 22);
            this.txtCari.TabIndex = 12;
            this.txtCari.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCari_KeyDown);
            // 
            // btnCari
            // 
            this.btnCari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCari.Location = new System.Drawing.Point(564, 32);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 23);
            this.btnCari.TabIndex = 13;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTampilkan.Location = new System.Drawing.Point(645, 32);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(111, 23);
            this.btnTampilkan.TabIndex = 14;
            this.btnTampilkan.Text = "Tampilkan Data";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            // 
            // dgvJadwal
            // 
            this.dgvJadwal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJadwal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJadwal.BackgroundColor = System.Drawing.Color.White;
            this.dgvJadwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJadwal.Location = new System.Drawing.Point(368, 76);
            this.dgvJadwal.Name = "dgvJadwal";
            this.dgvJadwal.RowHeadersWidth = 51;
            this.dgvJadwal.RowTemplate.Height = 24;
            this.dgvJadwal.Size = new System.Drawing.Size(388, 342);
            this.dgvJadwal.TabIndex = 15;
            this.dgvJadwal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJadwal_CellClick);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(800, 31);
            this.bindingNavigator1.TabIndex = 16;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(365, 57);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 16);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "label5";
            // 
            // FormJadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dgvJadwal);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnBersih);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.txtKeterangan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLokasi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpPelaksanaan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdJadwal);
            this.Controls.Add(this.label1);
            this.Name = "FormJadwal";
            this.Text = "FormJadwal";
            this.Load += new System.EventHandler(this.FormJadwal_Load);
            this.Click += new System.EventHandler(this.btnTambah_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJadwal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdJadwal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPelaksanaan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLokasi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnBersih;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.DataGridView dgvJadwal;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label lblTotal;
    }
}