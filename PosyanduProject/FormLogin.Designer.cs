namespace PosyanduProject
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppDesc = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkDaftar = new System.Windows.Forms.LinkLabel();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.panelLeft.Controls.Add(this.pictureBox1);
            this.panelLeft.Controls.Add(this.lblAppName);
            this.panelLeft.Controls.Add(this.lblAppDesc);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(210, 400);
            this.panelLeft.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(-104, 182);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(428, 56);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "Sistem Manajemen\r\nVaksin Posyandu";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppDesc
            // 
            this.lblAppDesc.Font = new System.Drawing.Font("Segoe UI", 8.2F);
            this.lblAppDesc.ForeColor = System.Drawing.Color.White;
            this.lblAppDesc.Location = new System.Drawing.Point(10, 278);
            this.lblAppDesc.Name = "lblAppDesc";
            this.lblAppDesc.Size = new System.Drawing.Size(186, 70);
            this.lblAppDesc.TabIndex = 2;
            this.lblAppDesc.Text = "Platform terpadu pengelolaan data vaksinasi & kesehatan anak.";
            this.lblAppDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.panelRight.Controls.Add(this.lblWelcome);
            this.panelRight.Controls.Add(this.lblSubtitle);
            this.panelRight.Controls.Add(this.lblUsername);
            this.panelRight.Controls.Add(this.txtUsername);
            this.panelRight.Controls.Add(this.lblPassword);
            this.panelRight.Controls.Add(this.txtPassword);
            this.panelRight.Controls.Add(this.chkShowPassword);
            this.panelRight.Controls.Add(this.lblError);
            this.panelRight.Controls.Add(this.btnLogin);
            this.panelRight.Controls.Add(this.linkDaftar);
            this.panelRight.Location = new System.Drawing.Point(210, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(330, 400);
            this.panelRight.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(42)))), ((int)(((byte)(24)))));
            this.lblWelcome.Location = new System.Drawing.Point(30, 34);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 35);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Selamat Datang";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.lblSubtitle.Location = new System.Drawing.Point(32, 64);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(227, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Silakan masuk untuk melanjutkan";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.lblUsername.Location = new System.Drawing.Point(30, 104);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 19);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "USERNAME";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(32)))));
            this.txtUsername.Location = new System.Drawing.Point(30, 122);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(270, 30);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.lblPassword.Location = new System.Drawing.Point(30, 164);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(87, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "PASSWORD";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(32)))));
            this.txtPassword.Location = new System.Drawing.Point(30, 182);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(270, 30);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.chkShowPassword.Location = new System.Drawing.Point(30, 218);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(163, 24);
            this.chkShowPassword.TabIndex = 6;
            this.chkShowPassword.Text = "Tampilkan Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(245)))));
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblError.Location = new System.Drawing.Point(30, 248);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(270, 22);
            this.lblError.TabIndex = 7;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(30, 278);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(270, 38);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkDaftar
            // 
            this.linkDaftar.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(78)))), ((int)(((byte)(45)))));
            this.linkDaftar.AutoSize = true;
            this.linkDaftar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.linkDaftar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(150)))), ((int)(((byte)(128)))));
            this.linkDaftar.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(65)))));
            this.linkDaftar.Location = new System.Drawing.Point(52, 332);
            this.linkDaftar.Name = "linkDaftar";
            this.linkDaftar.Size = new System.Drawing.Size(226, 20);
            this.linkDaftar.TabIndex = 9;
            this.linkDaftar.TabStop = true;
            this.linkDaftar.Text = "Belum punya akun? Daftar di sini";
            this.linkDaftar.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(138)))), ((int)(((byte)(80)))));
            this.linkDaftar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDaftar_LinkClicked);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(78)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(540, 400);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login – Sistem Manajemen Vaksin Posyandu";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppDesc;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkDaftar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}