namespace MobilBankacılık
{
    partial class ParaTransferi
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
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.txtAliciIBAN = new System.Windows.Forms.TextBox();
            this.BtnTransfer = new System.Windows.Forms.Button();
            this.cmbGonderenHesap = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAliciIsim = new System.Windows.Forms.TextBox();
            this.txtAliciSoyisim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(353, 49);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Size = new System.Drawing.Size(416, 20);
            this.txtMiktar.TabIndex = 1;
            // 
            // txtAliciIBAN
            // 
            this.txtAliciIBAN.Location = new System.Drawing.Point(353, 9);
            this.txtAliciIBAN.Name = "txtAliciIBAN";
            this.txtAliciIBAN.Size = new System.Drawing.Size(416, 20);
            this.txtAliciIBAN.TabIndex = 2;
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTransfer.Location = new System.Drawing.Point(353, 252);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(416, 42);
            this.BtnTransfer.TabIndex = 3;
            this.BtnTransfer.Text = "Gönder";
            this.BtnTransfer.UseVisualStyleBackColor = true;
            this.BtnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // cmbGonderenHesap
            // 
            this.cmbGonderenHesap.FormattingEnabled = true;
            this.cmbGonderenHesap.Location = new System.Drawing.Point(353, 103);
            this.cmbGonderenHesap.Name = "cmbGonderenHesap";
            this.cmbGonderenHesap.Size = new System.Drawing.Size(416, 21);
            this.cmbGonderenHesap.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alıcı İbanı Giriniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tutarı Giriniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gönderen Hesabı Seçin";
            // 
            // txtAliciIsim
            // 
            this.txtAliciIsim.Location = new System.Drawing.Point(353, 151);
            this.txtAliciIsim.Name = "txtAliciIsim";
            this.txtAliciIsim.Size = new System.Drawing.Size(416, 20);
            this.txtAliciIsim.TabIndex = 8;
            // 
            // txtAliciSoyisim
            // 
            this.txtAliciSoyisim.Location = new System.Drawing.Point(353, 208);
            this.txtAliciSoyisim.Name = "txtAliciSoyisim";
            this.txtAliciSoyisim.Size = new System.Drawing.Size(416, 20);
            this.txtAliciSoyisim.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(1, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "Soyad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(1, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 31);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ad";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(353, 300);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(416, 118);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(1, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 31);
            this.label6.TabIndex = 13;
            this.label6.Text = "Açıklama";
            // 
            // ParaTransferi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAliciSoyisim);
            this.Controls.Add(this.txtAliciIsim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbGonderenHesap);
            this.Controls.Add(this.BtnTransfer);
            this.Controls.Add(this.txtAliciIBAN);
            this.Controls.Add(this.txtMiktar);
            this.Name = "ParaTransferi";
            this.Text = "ParaTransferi";
            this.Load += new System.EventHandler(this.ParaTransferi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.TextBox txtAliciIBAN;
        private System.Windows.Forms.Button BtnTransfer;
        private System.Windows.Forms.ComboBox cmbGonderenHesap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAliciIsim;
        private System.Windows.Forms.TextBox txtAliciSoyisim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label6;
    }
}