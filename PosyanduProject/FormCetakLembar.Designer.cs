namespace PosyanduProject
{
    partial class FormCetakLembar
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
            this.crvLembar = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvLembar
            // 
            this.crvLembar.ActiveViewIndex = -1;
            this.crvLembar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvLembar.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvLembar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvLembar.Location = new System.Drawing.Point(0, 0);
            this.crvLembar.Name = "crvLembar";
            this.crvLembar.Size = new System.Drawing.Size(800, 450);
            this.crvLembar.TabIndex = 0;
            // 
            // FormCetakLembar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvLembar);
            this.Name = "FormCetakLembar";
            this.Text = "FormCetakLembar";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvLembar;
    }
}