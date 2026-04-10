using System;
using System.Windows.Forms;

namespace MobilBankacılık
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
            Tasarim.Uygula(this); // Modern tasarım uygulandı
        }

        private void AnaSayfa_Load(object sender, EventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secim = listBox1.SelectedItem?.ToString();
            if (secim == null) return;

            Form form = null;

            switch (secim)
            {
                case "Hesap Oluştur": form = new HesapOluştur(); break;
                case "Hesaplar": form = new Hesaplar(); break;
                case "Para Transferi": form = new ParaTransferi(); break;
                case "Kartlar": form = new KartOlustur(); break;
                case "Döviz": form = new Doviz(); break; // DÖVİZ EKLENDİ
                case "Ödeme Yap": form = new Odemeler(); break;
                case "Hesap Özeti": form = new HesapOzeti(); break;
                case "Altın Al": form = new AltınAl(); break;
                case "Altın Sat": form = new AltinSat(); break;
            }

            if (form != null)
            {
                form.ShowDialog();
            }
        }
    }
}