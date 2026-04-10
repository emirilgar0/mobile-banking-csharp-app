namespace MobilBankacılık
{
    partial class Form2
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
            this.TxtBoxIsim = new System.Windows.Forms.TextBox();
            this.BtnKayit = new System.Windows.Forms.Button();
            this.lblIsim = new System.Windows.Forms.Label();
            this.lblSoyisim = new System.Windows.Forms.Label();
            this.lblTelNo = new System.Windows.Forms.Label();
            this.lblSifreKayit = new System.Windows.Forms.Label();
            this.lblTC = new System.Windows.Forms.Label();
            this.MskdTxtTel = new System.Windows.Forms.MaskedTextBox();
            this.MskdTxtTC = new System.Windows.Forms.MaskedTextBox();
            this.txtBoxSoyisim = new System.Windows.Forms.TextBox();
            this.TxtBoxSifreKayit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtBoxIsim
            // 
            this.TxtBoxIsim.Location = new System.Drawing.Point(403, 33);
            this.TxtBoxIsim.Name = "TxtBoxIsim";
            this.TxtBoxIsim.Size = new System.Drawing.Size(137, 20);
            this.TxtBoxIsim.TabIndex = 0;
            // 
            // BtnKayit
            // 
            this.BtnKayit.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKayit.Location = new System.Drawing.Point(403, 229);
            this.BtnKayit.Name = "BtnKayit";
            this.BtnKayit.Size = new System.Drawing.Size(137, 37);
            this.BtnKayit.TabIndex = 2;
            this.BtnKayit.Text = "Kayıt Ol";
            this.BtnKayit.UseVisualStyleBackColor = true;
            this.BtnKayit.Click += new System.EventHandler(this.BtnKayit_Click);
            // 
            // lblIsim
            // 
            this.lblIsim.AutoSize = true;
            this.lblIsim.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIsim.Location = new System.Drawing.Point(154, 27);
            this.lblIsim.Name = "lblIsim";
            this.lblIsim.Size = new System.Drawing.Size(68, 25);
            this.lblIsim.TabIndex = 3;
            this.lblIsim.Text = "İsim:";
            // 
            // lblSoyisim
            // 
            this.lblSoyisim.AutoSize = true;
            this.lblSoyisim.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyisim.Location = new System.Drawing.Point(154, 66);
            this.lblSoyisim.Name = "lblSoyisim";
            this.lblSoyisim.Size = new System.Drawing.Size(105, 25);
            this.lblSoyisim.TabIndex = 4;
            this.lblSoyisim.Text = "Soyisim:";
            // 
            // lblTelNo
            // 
            this.lblTelNo.AutoSize = true;
            this.lblTelNo.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTelNo.Location = new System.Drawing.Point(154, 106);
            this.lblTelNo.Name = "lblTelNo";
            this.lblTelNo.Size = new System.Drawing.Size(137, 25);
            this.lblTelNo.TabIndex = 5;
            this.lblTelNo.Text = "Telefon No:";
            // 
            // lblSifreKayit
            // 
            this.lblSifreKayit.AutoSize = true;
            this.lblSifreKayit.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSifreKayit.Location = new System.Drawing.Point(154, 185);
            this.lblSifreKayit.Name = "lblSifreKayit";
            this.lblSifreKayit.Size = new System.Drawing.Size(72, 25);
            this.lblSifreKayit.TabIndex = 6;
            this.lblSifreKayit.Text = "Şifre:";
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTC.Location = new System.Drawing.Point(154, 144);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(162, 25);
            this.lblTC.TabIndex = 7;
            this.lblTC.Text = "TC Numarası:";
            // 
            // MskdTxtTel
            // 
            this.MskdTxtTel.Location = new System.Drawing.Point(403, 106);
            this.MskdTxtTel.Name = "MskdTxtTel";
            this.MskdTxtTel.Size = new System.Drawing.Size(137, 20);
            this.MskdTxtTel.TabIndex = 8;
            // 
            // MskdTxtTC
            // 
            this.MskdTxtTC.Location = new System.Drawing.Point(403, 144);
            this.MskdTxtTC.Mask = "00000000000";
            this.MskdTxtTC.Name = "MskdTxtTC";
            this.MskdTxtTC.Size = new System.Drawing.Size(137, 20);
            this.MskdTxtTC.TabIndex = 9;
            // 
            // txtBoxSoyisim
            // 
            this.txtBoxSoyisim.Location = new System.Drawing.Point(403, 71);
            this.txtBoxSoyisim.Name = "txtBoxSoyisim";
            this.txtBoxSoyisim.Size = new System.Drawing.Size(137, 20);
            this.txtBoxSoyisim.TabIndex = 12;
            // 
            // TxtBoxSifreKayit
            // 
            this.TxtBoxSifreKayit.Location = new System.Drawing.Point(403, 185);
            this.TxtBoxSifreKayit.Name = "TxtBoxSifreKayit";
            this.TxtBoxSifreKayit.Size = new System.Drawing.Size(137, 20);
            this.TxtBoxSifreKayit.TabIndex = 13;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtBoxSifreKayit);
            this.Controls.Add(this.txtBoxSoyisim);
            this.Controls.Add(this.MskdTxtTC);
            this.Controls.Add(this.MskdTxtTel);
            this.Controls.Add(this.lblTC);
            this.Controls.Add(this.lblSifreKayit);
            this.Controls.Add(this.lblTelNo);
            this.Controls.Add(this.lblSoyisim);
            this.Controls.Add(this.lblIsim);
            this.Controls.Add(this.BtnKayit);
            this.Controls.Add(this.TxtBoxIsim);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBoxIsim;
        private System.Windows.Forms.Button BtnKayit;
        private System.Windows.Forms.Label lblIsim;
        private System.Windows.Forms.Label lblSoyisim;
        private System.Windows.Forms.Label lblTelNo;
        private System.Windows.Forms.Label lblSifreKayit;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.MaskedTextBox MskdTxtTel;
        private System.Windows.Forms.MaskedTextBox MskdTxtTC;
        private System.Windows.Forms.TextBox txtBoxSoyisim;
        private System.Windows.Forms.TextBox TxtBoxSifreKayit;
    }
}