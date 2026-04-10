namespace MobilBankacılık
{
    partial class HesapOluştur
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
            this.listboxHesap = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnHesapOlustur = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // listboxHesap
            // 
            this.listboxHesap.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listboxHesap.FormattingEnabled = true;
            this.listboxHesap.ItemHeight = 39;
            this.listboxHesap.Location = new System.Drawing.Point(295, 53);
            this.listboxHesap.Name = "listboxHesap";
            this.listboxHesap.Size = new System.Drawing.Size(307, 199);
            this.listboxHesap.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(288, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hesap Türü Seçiniz";
            // 
            // BtnHesapOlustur
            // 
            this.BtnHesapOlustur.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.BtnHesapOlustur.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnHesapOlustur.Location = new System.Drawing.Point(344, 258);
            this.BtnHesapOlustur.Name = "BtnHesapOlustur";
            this.BtnHesapOlustur.Size = new System.Drawing.Size(179, 53);
            this.BtnHesapOlustur.TabIndex = 3;
            this.BtnHesapOlustur.Text = "Hesap Oluştur";
            this.BtnHesapOlustur.UseVisualStyleBackColor = true;
            this.BtnHesapOlustur.Click += new System.EventHandler(this.BtnHesapOlustur_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HesapOluştur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnHesapOlustur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listboxHesap);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HesapOluştur";
            this.Text = "HesapOluştur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listboxHesap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnHesapOlustur;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}