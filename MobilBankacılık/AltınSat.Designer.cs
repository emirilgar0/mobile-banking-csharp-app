namespace MobilBankacılık
{
    partial class AltinSat
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
            this.cmbAltinHesap = new System.Windows.Forms.ComboBox();
            this.cmbVadesizHesap = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTutar = new System.Windows.Forms.Label();
            this.txtGramAltin = new System.Windows.Forms.TextBox();
            this.txtTLAltin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbAltinHesap
            // 
            this.cmbAltinHesap.FormattingEnabled = true;
            this.cmbAltinHesap.Location = new System.Drawing.Point(28, 50);
            this.cmbAltinHesap.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cmbAltinHesap.Name = "cmbAltinHesap";
            this.cmbAltinHesap.Size = new System.Drawing.Size(1012, 33);
            this.cmbAltinHesap.TabIndex = 0;
            // 
            // cmbVadesizHesap
            // 
            this.cmbVadesizHesap.FormattingEnabled = true;
            this.cmbVadesizHesap.Location = new System.Drawing.Point(28, 535);
            this.cmbVadesizHesap.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cmbVadesizHesap.Name = "cmbVadesizHesap";
            this.cmbVadesizHesap.Size = new System.Drawing.Size(1012, 33);
            this.cmbVadesizHesap.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(965, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Satılacak TL Tutarı";
            // 
            // labelTutar
            // 
            this.labelTutar.AutoSize = true;
            this.labelTutar.Location = new System.Drawing.Point(965, 162);
            this.labelTutar.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.labelTutar.Name = "labelTutar";
            this.labelTutar.Size = new System.Drawing.Size(243, 25);
            this.labelTutar.TabIndex = 3;
            this.labelTutar.Text = "Satılacak Altın Gramı";
            // 
            // txtGramAltin
            // 
            this.txtGramAltin.Location = new System.Drawing.Point(1259, 162);
            this.txtGramAltin.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtGramAltin.Name = "txtGramAltin";
            this.txtGramAltin.Size = new System.Drawing.Size(228, 31);
            this.txtGramAltin.TabIndex = 4;
            // 
            // txtTLAltin
            // 
            this.txtTLAltin.Location = new System.Drawing.Point(1259, 310);
            this.txtTLAltin.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtTLAltin.Name = "txtTLAltin";
            this.txtTLAltin.Size = new System.Drawing.Size(228, 31);
            this.txtTLAltin.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1275, 353);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Altın Sat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnAltinSat_Click);
            // 
            // AltinSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1867, 865);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTLAltin);
            this.Controls.Add(this.txtGramAltin);
            this.Controls.Add(this.labelTutar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbVadesizHesap);
            this.Controls.Add(this.cmbAltinHesap);
            this.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "AltinSat";
            this.Text = "AltınSat";
            this.Load += new System.EventHandler(this.AltinSat_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAltinHesap;
        private System.Windows.Forms.ComboBox cmbVadesizHesap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTutar;
        private System.Windows.Forms.TextBox txtGramAltin;
        private System.Windows.Forms.TextBox txtTLAltin;
        private System.Windows.Forms.Button button1;
    }
}