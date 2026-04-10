namespace MobilBankacılık
{
    partial class AltınAl
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
            this.txtGramAltin = new System.Windows.Forms.TextBox();
            this.txtTLAltin = new System.Windows.Forms.TextBox();
            this.BtnAltinAl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbHesaplar = new System.Windows.Forms.ComboBox();
            this.cmbHesaplar2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtGramAltin
            // 
            this.txtGramAltin.Location = new System.Drawing.Point(403, 47);
            this.txtGramAltin.Name = "txtGramAltin";
            this.txtGramAltin.Size = new System.Drawing.Size(100, 20);
            this.txtGramAltin.TabIndex = 0;
            this.txtGramAltin.TextChanged += new System.EventHandler(this.txtGramAltin_TextChanged);
            // 
            // txtTLAltin
            // 
            this.txtTLAltin.Location = new System.Drawing.Point(403, 102);
            this.txtTLAltin.Name = "txtTLAltin";
            this.txtTLAltin.Size = new System.Drawing.Size(100, 20);
            this.txtTLAltin.TabIndex = 1;
            this.txtTLAltin.TextChanged += new System.EventHandler(this.txtTLAltin_TextChanged);
            // 
            // BtnAltinAl
            // 
            this.BtnAltinAl.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAltinAl.Location = new System.Drawing.Point(330, 182);
            this.BtnAltinAl.Name = "BtnAltinAl";
            this.BtnAltinAl.Size = new System.Drawing.Size(332, 49);
            this.BtnAltinAl.TabIndex = 2;
            this.BtnAltinAl.Text = "İşlemi Tamamla";
            this.BtnAltinAl.UseVisualStyleBackColor = true;
            this.BtnAltinAl.Click += new System.EventHandler(this.BtnAltinAl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(325, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Altın";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(350, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "TL";
            // 
            // cmbHesaplar
            // 
            this.cmbHesaplar.FormattingEnabled = true;
            this.cmbHesaplar.Location = new System.Drawing.Point(1, 47);
            this.cmbHesaplar.Name = "cmbHesaplar";
            this.cmbHesaplar.Size = new System.Drawing.Size(306, 21);
            this.cmbHesaplar.TabIndex = 5;
            // 
            // cmbHesaplar2
            // 
            this.cmbHesaplar2.FormattingEnabled = true;
            this.cmbHesaplar2.Location = new System.Drawing.Point(1, 257);
            this.cmbHesaplar2.Name = "cmbHesaplar2";
            this.cmbHesaplar2.Size = new System.Drawing.Size(306, 21);
            this.cmbHesaplar2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(580, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tutar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(580, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gram:";
            // 
            // AltınAl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbHesaplar2);
            this.Controls.Add(this.cmbHesaplar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAltinAl);
            this.Controls.Add(this.txtTLAltin);
            this.Controls.Add(this.txtGramAltin);
            this.Name = "AltınAl";
            this.Text = "AltınAl";
            this.Load += new System.EventHandler(this.AltınAl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGramAltin;
        private System.Windows.Forms.TextBox txtTLAltin;
        private System.Windows.Forms.Button BtnAltinAl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHesaplar;
        private System.Windows.Forms.ComboBox cmbHesaplar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}