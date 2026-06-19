namespace PosyanduProject
{
    partial class FormSplash
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
            this.btnCek = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnKeluar = new System.Windows.Forms.Button();
            this.btnLanjut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Koneksi Database Posyandu";
            // 
            // btnCek
            // 
            this.btnCek.Location = new System.Drawing.Point(150, 88);
            this.btnCek.Name = "btnCek";
            this.btnCek.Size = new System.Drawing.Size(250, 40);
            this.btnCek.TabIndex = 1;
            this.btnCek.Text = "Tes Koneksi Database";
            this.btnCek.UseVisualStyleBackColor = true;
            this.btnCek.Click += new System.EventHandler(this.btnCek_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblStatus.Location = new System.Drawing.Point(214, 143);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 25);
            this.lblStatus.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(40, 178);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(500, 60);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Silakan tekan tombol di atas untuk menguji koneksi";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnKeluar
            // 
            this.btnKeluar.BackColor = System.Drawing.Color.Crimson;
            this.btnKeluar.ForeColor = System.Drawing.Color.White;
            this.btnKeluar.Location = new System.Drawing.Point(43, 256);
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.Size = new System.Drawing.Size(75, 35);
            this.btnKeluar.TabIndex = 5;
            this.btnKeluar.Text = "Keluar";
            this.btnKeluar.UseVisualStyleBackColor = false;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            // 
            // btnLanjut
            // 
            this.btnLanjut.BackColor = System.Drawing.Color.ForestGreen;
            this.btnLanjut.Enabled = false;
            this.btnLanjut.ForeColor = System.Drawing.Color.White;
            this.btnLanjut.Location = new System.Drawing.Point(422, 256);
            this.btnLanjut.Name = "btnLanjut";
            this.btnLanjut.Size = new System.Drawing.Size(118, 35);
            this.btnLanjut.TabIndex = 6;
            this.btnLanjut.Text = "Lanjut ke Login";
            this.btnLanjut.UseVisualStyleBackColor = false;
            this.btnLanjut.Click += new System.EventHandler(this.btnLanjut_Click);
            // 
            // FormSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 303);
            this.Controls.Add(this.btnLanjut);
            this.Controls.Add(this.btnKeluar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCek);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Manajemen Vaksin Posyandu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCek;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnKeluar;
        private System.Windows.Forms.Button btnLanjut;
    }
}