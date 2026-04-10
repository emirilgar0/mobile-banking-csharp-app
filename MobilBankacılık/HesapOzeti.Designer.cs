namespace MobilBankacılık
{
    partial class HesapOzeti
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
            this.cmbHesaplar = new System.Windows.Forms.ComboBox();
            this.dgvOdemeler = new System.Windows.Forms.DataGridView();
            this.dgvGonderilenTransferler = new System.Windows.Forms.DataGridView();
            this.dgvGelenTransferler = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAltin = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdemeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGonderilenTransferler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGelenTransferler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltin)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbHesaplar
            // 
            this.cmbHesaplar.FormattingEnabled = true;
            this.cmbHesaplar.Location = new System.Drawing.Point(12, 22);
            this.cmbHesaplar.Name = "cmbHesaplar";
            this.cmbHesaplar.Size = new System.Drawing.Size(322, 21);
            this.cmbHesaplar.TabIndex = 0;
            this.cmbHesaplar.SelectedIndexChanged += new System.EventHandler(this.cmbHesaplar_SelectedIndexChanged);
            // 
            // dgvOdemeler
            // 
            this.dgvOdemeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOdemeler.Location = new System.Drawing.Point(628, 12);
            this.dgvOdemeler.Name = "dgvOdemeler";
            this.dgvOdemeler.Size = new System.Drawing.Size(672, 133);
            this.dgvOdemeler.TabIndex = 1;
            // 
            // dgvGonderilenTransferler
            // 
            this.dgvGonderilenTransferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGonderilenTransferler.Location = new System.Drawing.Point(628, 297);
            this.dgvGonderilenTransferler.Name = "dgvGonderilenTransferler";
            this.dgvGonderilenTransferler.Size = new System.Drawing.Size(672, 138);
            this.dgvGonderilenTransferler.TabIndex = 2;
            // 
            // dgvGelenTransferler
            // 
            this.dgvGelenTransferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGelenTransferler.Location = new System.Drawing.Point(628, 151);
            this.dgvGelenTransferler.Name = "dgvGelenTransferler";
            this.dgvGelenTransferler.Size = new System.Drawing.Size(672, 140);
            this.dgvGelenTransferler.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(340, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Yapılan Ödemeler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(263, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Alınan Para Transferleri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(202, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(383, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Gönderilen Para Transferleri";
            // 
            // dgvAltin
            // 
            this.dgvAltin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAltin.Location = new System.Drawing.Point(628, 441);
            this.dgvAltin.Name = "dgvAltin";
            this.dgvAltin.Size = new System.Drawing.Size(672, 130);
            this.dgvAltin.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(395, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 31);
            this.label4.TabIndex = 8;
            this.label4.Text = "Altın İşlemleri";
            // 
            // HesapOzeti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 583);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvAltin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGelenTransferler);
            this.Controls.Add(this.dgvGonderilenTransferler);
            this.Controls.Add(this.dgvOdemeler);
            this.Controls.Add(this.cmbHesaplar);
            this.Name = "HesapOzeti";
            this.Text = "HesapOzeti";
            this.Load += new System.EventHandler(this.HesapOzeti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOdemeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGonderilenTransferler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGelenTransferler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAltin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHesaplar;
        private System.Windows.Forms.DataGridView dgvOdemeler;
        private System.Windows.Forms.DataGridView dgvGonderilenTransferler;
        private System.Windows.Forms.DataGridView dgvGelenTransferler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAltin;
        private System.Windows.Forms.Label label4;
    }
}