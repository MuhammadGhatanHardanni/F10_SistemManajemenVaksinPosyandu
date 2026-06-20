namespace PosyanduProject
{
    partial class FormCetakKIA
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
            this.crvKIA = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvKIA
            // 
            this.crvKIA.ActiveViewIndex = -1;
            this.crvKIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvKIA.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvKIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvKIA.Location = new System.Drawing.Point(0, 0);
            this.crvKIA.Name = "crvKIA";
            this.crvKIA.Size = new System.Drawing.Size(800, 450);
            this.crvKIA.TabIndex = 0;
            // 
            // FormCetakKIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvKIA);
            this.Name = "FormCetakKIA";
            this.Text = "FormCetakKIA";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvKIA;
    }
}