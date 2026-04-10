namespace MobilBankacılık
{
    partial class Odemeler
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
            this.lstbxOdemeler = new System.Windows.Forms.ListBox();
            this.btnOde = new System.Windows.Forms.Button();
            this.cmbHesaplar = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lstbxOdemeler
            // 
            this.lstbxOdemeler.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstbxOdemeler.FormattingEnabled = true;
            this.lstbxOdemeler.ItemHeight = 31;
            this.lstbxOdemeler.Location = new System.Drawing.Point(12, 49);
            this.lstbxOdemeler.Name = "lstbxOdemeler";
            this.lstbxOdemeler.Size = new System.Drawing.Size(742, 252);
            this.lstbxOdemeler.TabIndex = 0;
            // 
            // btnOde
            // 
            this.btnOde.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOde.Location = new System.Drawing.Point(218, 337);
            this.btnOde.Name = "btnOde";
            this.btnOde.Size = new System.Drawing.Size(260, 68);
            this.btnOde.TabIndex = 1;
            this.btnOde.Text = "Ödeme Yap";
            this.btnOde.UseVisualStyleBackColor = true;
            this.btnOde.Click += new System.EventHandler(this.btnOde_Click);
            // 
            // cmbHesaplar
            // 
            this.cmbHesaplar.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbHesaplar.FormattingEnabled = true;
            this.cmbHesaplar.Location = new System.Drawing.Point(12, 12);
            this.cmbHesaplar.Name = "cmbHesaplar";
            this.cmbHesaplar.Size = new System.Drawing.Size(742, 31);
            this.cmbHesaplar.TabIndex = 2;
            // 
            // Odemeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbHesaplar);
            this.Controls.Add(this.btnOde);
            this.Controls.Add(this.lstbxOdemeler);
            this.Name = "Odemeler";
            this.Text = "Odemeler";
            this.Load += new System.EventHandler(this.Odemeler_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxOdemeler;
        private System.Windows.Forms.Button btnOde;
        private System.Windows.Forms.ComboBox cmbHesaplar;
    }
}