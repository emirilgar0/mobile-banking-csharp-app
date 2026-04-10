using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static MobilBankacılık.Form1;

namespace MobilBankacılık
{
    public partial class ParaTransferi : Form
    {
        public ParaTransferi()
        {
            InitializeComponent();
            Tasarim.Uygula(this);
            HesaplariYukle();
        }

        private void HesaplariYukle()
        {
            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IBAN, Bakiye FROM Hesaplar WHERE KullanıcıID=@id AND HesapTürüID=1", conn);
                    cmd.Parameters.AddWithValue("@id", KullaniciBilgileri.KullaniciID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) cmbGonderenHesap.Items.Add($"{dr["IBAN"]} - {dr["Bakiye"]} TL");
                }
                catch { }
            }
        }

        private void BtnTransfer_Click(object sender, EventArgs e)
        {
            if (cmbGonderenHesap.SelectedItem == null) return;
            string gonderenIban = cmbGonderenHesap.SelectedItem.ToString().Split('-')[0].Trim();
            string aliciIban = txtAliciIBAN.Text.Trim();

            if (!decimal.TryParse(txtMiktar.Text, out decimal miktar) || miktar <= 0) { MessageBox.Show("Miktar Giriniz"); return; }

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    // Alıcı Var mı?
                    SqlCommand cmdAlici = new SqlCommand("SELECT HesapID, KullanıcıID FROM Hesaplar WHERE IBAN=@iban", conn);
                    cmdAlici.Parameters.AddWithValue("@iban", aliciIban);
                    SqlDataReader dr = cmdAlici.ExecuteReader();
                    if (!dr.Read()) { MessageBox.Show("Alıcı Bulunamadı"); return; }
                    int aliciHesapID = Convert.ToInt32(dr["HesapID"]);
                    dr.Close();

                    // Bakiye Yeterli mi?
                    SqlCommand cmdBak = new SqlCommand("SELECT Bakiye, HesapID FROM Hesaplar WHERE IBAN=@iban", conn);
                    cmdBak.Parameters.AddWithValue("@iban", gonderenIban);
                    SqlDataReader dr2 = cmdBak.ExecuteReader();
                    dr2.Read();
                    decimal bakiye = Convert.ToDecimal(dr2["Bakiye"]);
                    int gonderenHesapID = Convert.ToInt32(dr2["HesapID"]);
                    dr2.Close();

                    if (bakiye < miktar) { MessageBox.Show("Yetersiz Bakiye"); return; }

                    // Transfer
                    // 1. Düş
                    SqlCommand cmdDus = new SqlCommand("UPDATE Hesaplar SET Bakiye=Bakiye-@m WHERE IBAN=@iban", conn);
                    cmdDus.Parameters.AddWithValue("@m", miktar);
                    cmdDus.Parameters.AddWithValue("@iban", gonderenIban);
                    cmdDus.ExecuteNonQuery();

                    // 2. Ekle
                    SqlCommand cmdEkle = new SqlCommand("UPDATE Hesaplar SET Bakiye=Bakiye+@m WHERE IBAN=@iban", conn);
                    cmdEkle.Parameters.AddWithValue("@m", miktar);
                    cmdEkle.Parameters.AddWithValue("@iban", aliciIban);
                    cmdEkle.ExecuteNonQuery();

                    // 3. Log
                    SqlCommand cmdLog = new SqlCommand("INSERT INTO ParaTransferleri (AlanHesapID, GonderenHesapID, Miktar, Aciklama) VALUES (@alan, @gon, @mik, @acik)", conn);
                    cmdLog.Parameters.AddWithValue("@alan", aliciHesapID);
                    cmdLog.Parameters.AddWithValue("@gon", gonderenHesapID);
                    cmdLog.Parameters.AddWithValue("@mik", miktar);
                    cmdLog.Parameters.AddWithValue("@acik", richTextBox1.Text);
                    cmdLog.ExecuteNonQuery();

                    MessageBox.Show("Transfer Başarılı");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        private void ParaTransferi_Load(object sender, EventArgs e) { }
    }
}