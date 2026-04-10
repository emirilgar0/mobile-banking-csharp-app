namespace MobilBankacılık
{
    partial class KartOlustur
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
            this.cmbKartTürü = new System.Windows.Forms.ComboBox();
            this.btnKartOlustur = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblKartNo = new System.Windows.Forms.Label();
            this.lblKarLimit = new System.Windows.Forms.Label();
            this.lblCVV = new System.Windows.Forms.Label();
            this.lblKartBakiye = new System.Windows.Forms.Label();
            this.txtKartNo = new System.Windows.Forms.TextBox();
            this.txtKartLimit = new System.Windows.Forms.TextBox();
            this.txtKartBakiye = new System.Windows.Forms.TextBox();
            this.txtKartCVV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmbKartTürü
            // 
            this.cmbKartTürü.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbKartTürü.FormattingEnabled = true;
            this.cmbKartTürü.Location = new System.Drawing.Point(345, 86);
            this.cmbKartTürü.Name = "cmbKartTürü";
            this.cmbKartTürü.Size = new System.Drawing.Size(136, 22);
            this.cmbKartTürü.TabIndex = 0;
            // 
            // btnKartOlustur
            // 
            this.btnKartOlustur.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKartOlustur.Location = new System.Drawing.Point(345, 177);
            this.btnKartOlustur.Name = "btnKartOlustur";
            this.btnKartOlustur.Size = new System.Drawing.Size(136, 23);
            this.btnKartOlustur.TabIndex = 1;
            this.btnKartOlustur.Text = "Kart Oluştur";
            this.btnKartOlustur.UseVisualStyleBackColor = true;
            this.btnKartOlustur.Click += new System.EventHandler(this.btnKartOlustur_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kart Tipi Seçiniz:";
            // 
            // lblKartNo
            // 
            this.lblKartNo.AutoSize = true;
            this.lblKartNo.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKartNo.Location = new System.Drawing.Point(40, 254);
            this.lblKartNo.Name = "lblKartNo";
            this.lblKartNo.Size = new System.Drawing.Size(157, 23);
            this.lblKartNo.TabIndex = 4;
            this.lblKartNo.Text = "Kart Numarası";
            // 
            // lblKarLimit
            // 
            this.lblKarLimit.AutoSize = true;
            this.lblKarLimit.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKarLimit.Location = new System.Drawing.Point(40, 288);
            this.lblKarLimit.Name = "lblKarLimit";
            this.lblKarLimit.Size = new System.Drawing.Size(121, 23);
            this.lblKarLimit.TabIndex = 9;
            this.lblKarLimit.Text = "Kart Limiti";
            // 
            // lblCVV
            // 
            this.lblCVV.AutoSize = true;
            this.lblCVV.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCVV.Location = new System.Drawing.Point(40, 357);
            this.lblCVV.Name = "lblCVV";
            this.lblCVV.Size = new System.Drawing.Size(52, 23);
            this.lblCVV.TabIndex = 10;
            this.lblCVV.Text = "CVV";
            // 
            // lblKartBakiye
            // 
            this.lblKartBakiye.AutoSize = true;
            this.lblKartBakiye.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKartBakiye.Location = new System.Drawing.Point(40, 322);
            this.lblKartBakiye.Name = "lblKartBakiye";
            this.lblKartBakiye.Size = new System.Drawing.Size(76, 23);
            this.lblKartBakiye.TabIndex = 11;
            this.lblKartBakiye.Text = "Bakiye";
            // 
            // txtKartNo
            // 
            this.txtKartNo.Location = new System.Drawing.Point(265, 254);
            this.txtKartNo.Name = "txtKartNo";
            this.txtKartNo.Size = new System.Drawing.Size(202, 20);
            this.txtKartNo.TabIndex = 12;
            // 
            // txtKartLimit
            // 
            this.txtKartLimit.Location = new System.Drawing.Point(265, 293);
            this.txtKartLimit.Name = "txtKartLimit";
            this.txtKartLimit.Size = new System.Drawing.Size(202, 20);
            this.txtKartLimit.TabIndex = 13;
            // 
            // txtKartBakiye
            // 
            this.txtKartBakiye.Location = new System.Drawing.Point(265, 325);
            this.txtKartBakiye.Name = "txtKartBakiye";
            this.txtKartBakiye.Size = new System.Drawing.Size(202, 20);
            this.txtKartBakiye.TabIndex = 14;
            // 
            // txtKartCVV
            // 
            this.txtKartCVV.Location = new System.Drawing.Point(265, 362);
            this.txtKartCVV.Name = "txtKartCVV";
            this.txtKartCVV.Size = new System.Drawing.Size(202, 20);
            this.txtKartCVV.TabIndex = 15;
            // 
            // KartOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtKartCVV);
            this.Controls.Add(this.txtKartBakiye);
            this.Controls.Add(this.txtKartLimit);
            this.Controls.Add(this.txtKartNo);
            this.Controls.Add(this.lblKartBakiye);
            this.Controls.Add(this.lblCVV);
            this.Controls.Add(this.lblKarLimit);
            this.Controls.Add(this.lblKartNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKartOlustur);
            this.Controls.Add(this.cmbKartTürü);
            this.Name = "KartOlustur";
            this.Text = "KartOlustur";
            this.Load += new System.EventHandler(this.KartOlustur_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKartTürü;
        private System.Windows.Forms.Button btnKartOlustur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKartNo;
        private System.Windows.Forms.Label lblKarLimit;
        private System.Windows.Forms.Label lblCVV;
        private System.Windows.Forms.Label lblKartBakiye;
        private System.Windows.Forms.TextBox txtKartNo;
        private System.Windows.Forms.TextBox txtKartLimit;
        private System.Windows.Forms.TextBox txtKartBakiye;
        private System.Windows.Forms.TextBox txtKartCVV;
    }
}