using System.Drawing;
using System.Windows.Forms;

namespace MobilBankacılık
{
    public static class Tasarim
    {
        // PREMIUM RENK PALETİ
        public static Color ArkaPlan = Color.FromArgb(20, 25, 40);         // Çok Koyu Gece Mavisi
        public static Color PanelRenk = Color.FromArgb(30, 35, 55);        // Biraz daha açık alanlar
        public static Color VurguRenk = Color.FromArgb(0, 200, 255);       // Neon Mavi (Cyan)
        public static Color YaziRenk = Color.FromArgb(230, 230, 240);      // Kırık Beyaz
        public static Color KutuRenk = Color.FromArgb(40, 45, 65);         // TextBox Arkası
        public static Font AnaFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public static Font BaslikFont = new Font("Segoe UI", 12, FontStyle.Bold);

        public static void Uygula(Form form)
        {
            form.BackColor = ArkaPlan;
            form.ForeColor = YaziRenk;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;

            foreach (Control c in form.Controls)
            {
                StilVer(c);
            }
        }

        private static void StilVer(Control c)
        {
            if (c.HasChildren)
            {
                foreach (Control child in c.Controls) StilVer(child);
            }

            if (c is Button btn)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = VurguRenk;
                btn.ForeColor = Color.FromArgb(10, 10, 20); // Buton yazısı koyu
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 10, 10)); // Yuvarlak köşe
            }
            else if (c is TextBox txt)
            {
                txt.BackColor = KutuRenk;
                txt.ForeColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 11);
                // Şifre alanı veya TC alanı kontrolü Form yüklenirken ayrıca yapılacak
            }
            else if (c is ComboBox cmb)
            {
                cmb.BackColor = KutuRenk;
                cmb.ForeColor = Color.White;
                cmb.FlatStyle = FlatStyle.Flat;
            }
            else if (c is ListBox lst)
            {
                lst.BackColor = PanelRenk;
                lst.ForeColor = VurguRenk;
                lst.BorderStyle = BorderStyle.None;
                lst.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lst.ItemHeight = 30;
            }
            else if (c is DataGridView dgv)
            {
                dgv.BackgroundColor = PanelRenk;
                dgv.BorderStyle = BorderStyle.None;
                dgv.GridColor = Color.FromArgb(50, 50, 70);
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 60);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = VurguRenk;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dgv.DefaultCellStyle.BackColor = PanelRenk;
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = VurguRenk;
                dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgv.RowHeadersVisible = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowTemplate.Height = 30;
            }
            else if (c is GroupBox gb)
            {
                gb.ForeColor = VurguRenk; // Başlık rengi
            }
            else if (c is Label lbl)
            {
                lbl.ForeColor = YaziRenk;
                if (lbl.Font.Size > 12) lbl.ForeColor = VurguRenk; // Büyük başlıklar renkli olsun
            }
        }

        // Yuvarlak Köşeler İçin Windows API (DLL Import)
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}