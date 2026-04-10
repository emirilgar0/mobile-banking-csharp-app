namespace MobilBankacılık
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblHesapNo = new System.Windows.Forms.Label();
            this.TxtBoxHesapNoGiris = new System.Windows.Forms.TextBox();
            this.BtnGiris = new System.Windows.Forms.Button();
            this.LblSifre = new System.Windows.Forms.Label();
            this.TxtBoxSifreGiris = new System.Windows.Forms.TextBox();
            this.btnKayıtOl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblHesapNo
            // 
            this.LblHesapNo.AutoSize = true;
            this.LblHesapNo.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblHesapNo.Location = new System.Drawing.Point(111, 42);
            this.LblHesapNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblHesapNo.Name = "LblHesapNo";
            this.LblHesapNo.Size = new System.Drawing.Size(89, 25);
            this.LblHesapNo.TabIndex = 0;
            this.LblHesapNo.Text = "TC NO:";
            // 
            // TxtBoxHesapNoGiris
            // 
            this.TxtBoxHesapNoGiris.Location = new System.Drawing.Point(261, 42);
            this.TxtBoxHesapNoGiris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtBoxHesapNoGiris.Name = "TxtBoxHesapNoGiris";
            this.TxtBoxHesapNoGiris.Size = new System.Drawing.Size(158, 20);
            this.TxtBoxHesapNoGiris.TabIndex = 1;
            // 
            // BtnGiris
            // 
            this.BtnGiris.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGiris.Location = new System.Drawing.Point(261, 159);
            this.BtnGiris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnGiris.Name = "BtnGiris";
            this.BtnGiris.Size = new System.Drawing.Size(158, 35);
            this.BtnGiris.TabIndex = 2;
            this.BtnGiris.Text = "Giriş Yap";
            this.BtnGiris.UseVisualStyleBackColor = true;
            this.BtnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // LblSifre
            // 
            this.LblSifre.AutoSize = true;
            this.LblSifre.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSifre.Location = new System.Drawing.Point(111, 105);
            this.LblSifre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblSifre.Name = "LblSifre";
            this.LblSifre.Size = new System.Drawing.Size(72, 25);
            this.LblSifre.TabIndex = 3;
            this.LblSifre.Text = "Şifre:";
            // 
            // TxtBoxSifreGiris
            // 
            this.TxtBoxSifreGiris.Location = new System.Drawing.Point(261, 105);
            this.TxtBoxSifreGiris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtBoxSifreGiris.Name = "TxtBoxSifreGiris";
            this.TxtBoxSifreGiris.Size = new System.Drawing.Size(158, 20);
            this.TxtBoxSifreGiris.TabIndex = 4;
            // 
            // btnKayıtOl
            // 
            this.btnKayıtOl.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayıtOl.Location = new System.Drawing.Point(261, 206);
            this.btnKayıtOl.Name = "btnKayıtOl";
            this.btnKayıtOl.Size = new System.Drawing.Size(158, 36);
            this.btnKayıtOl.TabIndex = 5;
            this.btnKayıtOl.Text = "Kayıt Ol";
            this.btnKayıtOl.UseVisualStyleBackColor = true;
            this.btnKayıtOl.Click += new System.EventHandler(this.btnKayıtOl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(713, 471);
            this.Controls.Add(this.btnKayıtOl);
            this.Controls.Add(this.TxtBoxSifreGiris);
            this.Controls.Add(this.LblSifre);
            this.Controls.Add(this.BtnGiris);
            this.Controls.Add(this.TxtBoxHesapNoGiris);
            this.Controls.Add(this.LblHesapNo);
            this.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHesapNo;
        private System.Windows.Forms.TextBox TxtBoxHesapNoGiris;
        private System.Windows.Forms.Button BtnGiris;
        private System.Windows.Forms.Label LblSifre;
        private System.Windows.Forms.TextBox TxtBoxSifreGiris;
        private System.Windows.Forms.Button btnKayıtOl;
    }
}

