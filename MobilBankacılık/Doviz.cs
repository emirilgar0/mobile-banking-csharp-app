using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using static MobilBankacılık.Form1;

namespace MobilBankacılık
{
    public partial class Doviz : Form
    {
        decimal dolarKuru = 35.50m;

        // UI Elemanları
        private ComboBox boxTLHesap, boxDolarHesap;
        private TextBox txtMiktar;
        private Label lblTutar;

        public Doviz()
        {
            // InitializeComponent(); // KAPALI
            ArayuzuOlustur();
            Tasarim.Uygula(this);
            HesaplariYukle(); // Form açılır açılmaz veriyi çekmeye zorluyoruz
        }

        private void HesaplariYukle()
        {
            boxTLHesap.Items.Clear();
            boxDolarHesap.Items.Clear();

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();

                    // 1. TL Hesapları
                    SqlCommand cmdTL = new SqlCommand("SELECT HesapNo, HesapID, Bakiye FROM Hesaplar WHERE KullanıcıID=@id AND HesapTürüID=1", conn);
                    cmdTL.Parameters.AddWithValue("@id", KullaniciBilgileri.KullaniciID);
                    SqlDataReader drTL = cmdTL.ExecuteReader();
                    while (drTL.Read())
                    {
                        // ComboItem sınıfı sayesinde ToString() çalışacak ve metin görünecek
                        boxTLHesap.Items.Add(new ComboItem
                        {
                            Text = $"{drTL["HesapNo"]} - {drTL["Bakiye"]} TL",
                            ID = Convert.ToInt32(drTL["HesapID"])
                        });
                    }
                    drTL.Close();

                    // 2. Dolar Hesapları
                    SqlCommand cmdUSD = new SqlCommand("SELECT HesapNo, HesapID, Bakiye FROM Hesaplar WHERE KullanıcıID=@id AND HesapTürüID=3", conn);
                    cmdUSD.Parameters.AddWithValue("@id", KullaniciBilgileri.KullaniciID);
                    SqlDataReader drUSD = cmdUSD.ExecuteReader();
                    while (drUSD.Read())
                    {
                        boxDolarHesap.Items.Add(new ComboItem
                        {
                            Text = $"{drUSD["HesapNo"]} - {drUSD["Bakiye"]} USD",
                            ID = Convert.ToInt32(drUSD["HesapID"])
                        });
                    }
                    drUSD.Close();
                }
                catch (Exception ex) { MessageBox.Show("Veri hatası: " + ex.Message); }
            }
        }

        private void btnIslemYap_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            bool alisMi = btn.Text == "DOLAR AL";

            if (boxTLHesap.SelectedItem == null || boxDolarHesap.SelectedItem == null)
            { MessageBox.Show("Lütfen hesapları seçiniz."); return; }

            if (!decimal.TryParse(txtMiktar.Text, out decimal miktar) || miktar <= 0)
            { MessageBox.Show("Geçerli bir miktar giriniz."); return; }

            int tlHesapID = (boxTLHesap.SelectedItem as ComboItem).ID;
            int dolarHesapID = (boxDolarHesap.SelectedItem as ComboItem).ID;
            decimal islemTutariTL = miktar * dolarKuru;

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    if (alisMi)
                    {
                        SqlCommand cmdBak = new SqlCommand("SELECT Bakiye FROM Hesaplar WHERE HesapID=@id", conn);
                        cmdBak.Parameters.AddWithValue("@id", tlHesapID);
                        decimal mevcutTL = Convert.ToDecimal(cmdBak.ExecuteScalar());

                        if (mevcutTL < islemTutariTL) { MessageBox.Show($"Yetersiz TL Bakiyesi."); return; }

                        SqlCommand cmdDus = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye - @tl WHERE HesapID = @idTL", conn);
                        cmdDus.Parameters.AddWithValue("@tl", islemTutariTL);
                        cmdDus.Parameters.AddWithValue("@idTL", tlHesapID);
                        cmdDus.ExecuteNonQuery();

                        SqlCommand cmdEkle = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye + @usd WHERE HesapID = @idUSD", conn);
                        cmdEkle.Parameters.AddWithValue("@usd", miktar);
                        cmdEkle.Parameters.AddWithValue("@idUSD", dolarHesapID);
                        cmdEkle.ExecuteNonQuery();

                        LogEkle(conn, tlHesapID, $"Döviz Alış (-{islemTutariTL:C2})", islemTutariTL * -1);
                        LogEkle(conn, dolarHesapID, $"Döviz Alış (+{miktar} USD)", miktar);
                    }
                    else
                    {
                        SqlCommand cmdBak = new SqlCommand("SELECT Bakiye FROM Hesaplar WHERE HesapID=@id", conn);
                        cmdBak.Parameters.AddWithValue("@id", dolarHesapID);
                        decimal mevcutUSD = Convert.ToDecimal(cmdBak.ExecuteScalar());

                        if (mevcutUSD < miktar) { MessageBox.Show("Yetersiz Dolar Bakiyesi."); return; }

                        SqlCommand cmdDus = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye - @usd WHERE HesapID = @idUSD", conn);
                        cmdDus.Parameters.AddWithValue("@usd", miktar);
                        cmdDus.Parameters.AddWithValue("@idUSD", dolarHesapID);
                        cmdDus.ExecuteNonQuery();

                        SqlCommand cmdEkle = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye + @tl WHERE HesapID = @idTL", conn);
                        cmdEkle.Parameters.AddWithValue("@tl", islemTutariTL);
                        cmdEkle.Parameters.AddWithValue("@idTL", tlHesapID);
                        cmdEkle.ExecuteNonQuery();

                        LogEkle(conn, dolarHesapID, $"Döviz Satış (-{miktar} USD)", miktar * -1);
                        LogEkle(conn, tlHesapID, $"Döviz Satış (+{islemTutariTL:C2})", islemTutariTL);
                    }

                    MessageBox.Show("İşlem Başarılı!");
                    HesaplariYukle();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void LogEkle(SqlConnection conn, int hesapID, string aciklama, decimal tutar)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO HesapÖzeti (HesapID, İşlemTürü, İşlemTarihi, Tutar, Açıklama) VALUES (@hid, 'Döviz', GETDATE(), @tutar, @acik)", conn);
            cmd.Parameters.AddWithValue("@hid", hesapID);
            cmd.Parameters.AddWithValue("@tutar", tutar);
            cmd.Parameters.AddWithValue("@acik", aciklama);
            cmd.ExecuteNonQuery();
        }

        private void TxtMiktar_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMiktar.Text, out decimal miktar))
                lblTutar.Text = $"Karşılığı: {miktar * dolarKuru:C2} TL";
            else lblTutar.Text = "Karşılığı: 0.00 TL";
        }

        private void ArayuzuOlustur()
        {
            this.Size = new Size(400, 500);
            this.Text = "Döviz İşlemleri";

            Label lblBaslik = new Label() { Text = $"GÜNCEL KUR: {dolarKuru} TL", Location = new Point(50, 20), AutoSize = true, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.Yellow };

            Label lbl1 = new Label() { Text = "TL Hesabınız:", Location = new Point(50, 70), AutoSize = true, ForeColor = Color.White };
            boxTLHesap = new ComboBox() { Location = new Point(50, 95), Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lbl2 = new Label() { Text = "Dolar Hesabınız:", Location = new Point(50, 135), AutoSize = true, ForeColor = Color.White };
            boxDolarHesap = new ComboBox() { Location = new Point(50, 160), Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lbl3 = new Label() { Text = "Miktar (USD):", Location = new Point(50, 200), AutoSize = true, ForeColor = Color.White };
            txtMiktar = new TextBox() { Location = new Point(50, 225), Width = 280 };
            txtMiktar.TextChanged += TxtMiktar_TextChanged;

            lblTutar = new Label() { Text = "Karşılığı: 0.00 TL", Location = new Point(50, 260), AutoSize = true, Font = new Font("Segoe UI", 12), ForeColor = Color.Cyan };

            Button btnAl = new Button() { Text = "DOLAR AL", Location = new Point(50, 300), Width = 135, Height = 50, BackColor = Color.Green, ForeColor = Color.White };
            btnAl.Click += btnIslemYap_Click;

            Button btnSat = new Button() { Text = "DOLAR SAT", Location = new Point(195, 300), Width = 135, Height = 50, BackColor = Color.Red, ForeColor = Color.White };
            btnSat.Click += btnIslemYap_Click;

            this.Controls.Add(lblBaslik);
            this.Controls.Add(lbl1); this.Controls.Add(boxTLHesap);
            this.Controls.Add(lbl2); this.Controls.Add(boxDolarHesap);
            this.Controls.Add(lbl3); this.Controls.Add(txtMiktar);
            this.Controls.Add(lblTutar);
            this.Controls.Add(btnAl); this.Controls.Add(btnSat);
        }

        // --- SİHİRLİ DEĞNEK: Bu sınıf sayesinde ComboBox içinde metin görünür ---
        public class ComboItem
        {
            public string Text { get; set; }
            public int ID { get; set; }
            // BU METOT ÇOK ÖNEMLİ: Ekrana Text basılmasını sağlar
            public override string ToString() { return Text; }
        }
    }
}