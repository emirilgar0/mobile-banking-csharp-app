using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static MobilBankacılık.Form1;

namespace MobilBankacılık
{
    public partial class Odemeler : Form
    {
        public Odemeler()
        {
            InitializeComponent();
            Tasarim.Uygula(this);
        }

        private void Odemeler_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void VerileriYukle()
        {
            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    // Hesaplar
                    SqlCommand cmd1 = new SqlCommand("SELECT IBAN, Bakiye FROM Hesaplar WHERE KullanıcıID=@id AND HesapTürüID=1", conn);
                    cmd1.Parameters.AddWithValue("@id", KullaniciBilgileri.KullaniciID);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read()) cmbHesaplar.Items.Add($"{dr1["IBAN"]} - {dr1["Bakiye"]} TL");
                    dr1.Close();

                    // Ödeme Türleri
                    SqlCommand cmd2 = new SqlCommand("SELECT OdemeTuru, Fiyat FROM OdemeTurleri", conn);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read()) lstbxOdemeler.Items.Add($"{dr2["OdemeTuru"]} - {dr2["Fiyat"]} TL");
                }
                catch { }
            }
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            if (cmbHesaplar.SelectedItem == null || lstbxOdemeler.SelectedItem == null) return;

            string iban = cmbHesaplar.SelectedItem.ToString().Split('-')[0].Trim();
            string odemeSatir = lstbxOdemeler.SelectedItem.ToString();
            decimal fiyat = decimal.Parse(odemeSatir.Split('-')[1].Replace("TL", "").Trim());
            string tur = odemeSatir.Split('-')[0].Trim();

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    // Bakiye Kontrol
                    SqlCommand cmdBak = new SqlCommand("SELECT Bakiye FROM Hesaplar WHERE IBAN=@iban", conn);
                    cmdBak.Parameters.AddWithValue("@iban", iban);
                    decimal bakiye = Convert.ToDecimal(cmdBak.ExecuteScalar());

                    if (bakiye < fiyat) { MessageBox.Show("Yetersiz Bakiye"); return; }

                    // Düş
                    SqlCommand cmdDus = new SqlCommand("UPDATE Hesaplar SET Bakiye=Bakiye-@fiyat WHERE IBAN=@iban", conn);
                    cmdDus.Parameters.AddWithValue("@fiyat", fiyat);
                    cmdDus.Parameters.AddWithValue("@iban", iban);
                    cmdDus.ExecuteNonQuery();

                    // Kaydet
                    SqlCommand cmdLog = new SqlCommand("INSERT INTO Odemeler (HesapID, Tutar, OdemeTuruID) VALUES ((SELECT HesapID FROM Hesaplar WHERE IBAN=@iban), @tutar, (SELECT OdemeTuruID FROM OdemeTurleri WHERE OdemeTuru=@tur))", conn);
                    cmdLog.Parameters.AddWithValue("@iban", iban);
                    cmdLog.Parameters.AddWithValue("@tutar", fiyat);
                    cmdLog.Parameters.AddWithValue("@tur", tur);
                    cmdLog.ExecuteNonQuery();

                    MessageBox.Show("Ödendi!");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}