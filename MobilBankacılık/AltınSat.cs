using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static MobilBankacılık.Form1;

namespace MobilBankacılık
{
    public partial class AltinSat : Form
    {
        private const decimal ALTIN_SATIS_KURU = 6250.00m;

        // UI Elemanları
        private ComboBox uiAltinHesap, uiTLHesap;
        private RadioButton uiOptGram, uiOptTL;
        private TextBox uiInputGram, uiInputTL;
        private Label uiLblBilgi;

        public AltinSat()
        {
            // InitializeComponent(); // KAPALI
            ArayuzuOlustur();
            Tasarim.Uygula(this);
            HesaplariYukle(); // Form açılır açılmaz veriyi çekmeye zorluyoruz
        }

        // --- HATA SUSTURUCULAR ---
        public void txtGramAltin_TextChanged(object sender, EventArgs e) { }
        public void txtTLAltin_TextChanged(object sender, EventArgs e) { }
        public void BtnAltinSat_Click(object sender, EventArgs e) { }
        public void BtnAltinAl_Click(object sender, EventArgs e) { }
        // -------------------------

        private void AltinSat_Load_1(object sender, EventArgs e)
        {
            if (uiOptGram != null) uiOptGram.Checked = true;
        }

        private void Hesapla(object sender, EventArgs e)
        {
            if (uiOptGram.Checked)
            {
                if (decimal.TryParse(uiInputGram.Text, out decimal gram) && gram > 0)
                {
                    uiInputTL.Text = (gram * ALTIN_SATIS_KURU).ToString("N2");
                    uiLblBilgi.Text = $"{gram} Gram = {uiInputTL.Text} TL";
                    uiLblBilgi.ForeColor = Color.Cyan;
                }
                else { uiInputTL.Text = "0.00"; uiLblBilgi.Text = "..."; }
            }
            else
            {
                if (decimal.TryParse(uiInputTL.Text, out decimal tl) && tl > 0)
                {
                    uiInputGram.Text = (tl / ALTIN_SATIS_KURU).ToString("N2");
                    uiLblBilgi.Text = $"{tl:C2} TL = {uiInputGram.Text} Gram";
                    uiLblBilgi.ForeColor = Color.Cyan;
                }
                else { uiInputGram.Text = "0.00"; uiLblBilgi.Text = "..."; }
            }
        }

        private void ModDegisti(object sender, EventArgs e)
        {
            uiInputGram.Clear(); uiInputTL.Clear(); uiLblBilgi.Text = "...";

            if (uiOptGram.Checked)
            {
                uiInputGram.Enabled = true; uiInputGram.BackColor = Color.FromArgb(40, 45, 65);
                uiInputTL.Enabled = false; uiInputTL.BackColor = Color.FromArgb(30, 30, 40);
                uiInputGram.Focus();
            }
            else
            {
                uiInputGram.Enabled = false; uiInputGram.BackColor = Color.FromArgb(30, 30, 40);
                uiInputTL.Enabled = true; uiInputTL.BackColor = Color.FromArgb(40, 45, 65);
                uiInputTL.Focus();
            }
        }

        private void BtnSat_Click(object sender, EventArgs e)
        {
            if (uiAltinHesap.SelectedItem == null || uiTLHesap.SelectedItem == null)
            { MessageBox.Show("Lütfen hesapları seçiniz."); return; }

            decimal islemGrami = 0; decimal islemTutari = 0;
            decimal.TryParse(uiInputGram.Text, out islemGrami);
            decimal.TryParse(uiInputTL.Text, out islemTutari);

            if (islemGrami <= 0 || islemTutari <= 0) { MessageBox.Show("Geçerli bir miktar giriniz."); return; }

            // ComboItem kullanımı
            int altinID = (uiAltinHesap.SelectedItem as ComboItem).ID;
            int tlID = (uiTLHesap.SelectedItem as ComboItem).ID;

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdBak = new SqlCommand("SELECT Bakiye FROM Hesaplar WHERE HesapID=@id", conn);
                    cmdBak.Parameters.AddWithValue("@id", altinID);
                    decimal mevcutAltin = Convert.ToDecimal(cmdBak.ExecuteScalar());

                    if (mevcutAltin < islemGrami) { MessageBox.Show("Yetersiz Altın Bakiyesi."); return; }

                    SqlCommand cmdDus = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye - @gr WHERE HesapID = @idAltin", conn);
                    cmdDus.Parameters.AddWithValue("@gr", islemGrami);
                    cmdDus.Parameters.AddWithValue("@idAltin", altinID);
                    cmdDus.ExecuteNonQuery();

                    SqlCommand cmdEkle = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye + @tl WHERE HesapID = @idTL", conn);
                    cmdEkle.Parameters.AddWithValue("@tl", islemTutari);
                    cmdEkle.Parameters.AddWithValue("@idTL", tlID);
                    cmdEkle.ExecuteNonQuery();

                    Logla(conn, altinID, islemGrami, islemTutari, "Satış");
                    OzetEkle(conn, altinID, $"Altın Satışı (-{islemGrami} gr)", islemGrami * -1);
                    OzetEkle(conn, tlID, $"Altın Satışı (+{islemTutari:C2})", islemTutari);

                    MessageBox.Show($"{islemGrami} Gram Altın satıldı. {islemTutari:C2} hesabınıza yattı.");
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private void Logla(SqlConnection conn, int hid, decimal gr, decimal tutar, string tur)
        {
            string sql = "INSERT INTO AltinHesabi (HesapID, KullaniciID, AltinMiktari, Tutar, IslemTuru) VALUES (@h, @k, @g, @t, @tur)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@h", hid); cmd.Parameters.AddWithValue("@k", KullaniciBilgileri.KullaniciID);
            cmd.Parameters.AddWithValue("@g", gr); cmd.Parameters.AddWithValue("@t", tutar); cmd.Parameters.AddWithValue("@tur", tur);
            cmd.ExecuteNonQuery();
        }

        private void OzetEkle(SqlConnection conn, int hid, string acik, decimal miktar)
        {
            string sql = "INSERT INTO HesapÖzeti (HesapID, İşlemTürü, İşlemTarihi, Tutar, Açıklama) VALUES (@h, 'Altın', GETDATE(), @m, @a)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@h", hid); cmd.Parameters.AddWithValue("@m", miktar); cmd.Parameters.AddWithValue("@a", acik);
            cmd.ExecuteNonQuery();
        }

        private void HesaplariYukle()
        {
            uiAltinHesap.Items.Clear();
            uiTLHesap.Items.Clear();

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("SELECT HesapNo, HesapID, Bakiye FROM Hesaplar WHERE KullanıcıID=@id AND HesapTürüID=4", conn);
                    cmd1.Parameters.AddWithValue("@id", KullaniciBilgileri.KullaniciID);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    while (dr1.Read())
                    {
                        uiAltinHesap.Items.Add(new ComboItem
                        {
                            Text = $"{dr1["HesapNo"]} - {dr1["Bakiye"]} GR",
                            ID = Convert.ToInt32(dr1["HesapID"])
                        });
                    }
                    dr1.Close();

                    SqlCommand cmd2 = new SqlCommand("SELECT HesapNo, HesapID, Bakiye FROM Hesaplar WHERE KullanıcıID=@id AND HesapTürüID=1", conn);
                    cmd2.Parameters.AddWithValue("@id", KullaniciBilgileri.KullaniciID);
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        uiTLHesap.Items.Add(new ComboItem
                        {
                            Text = $"{dr2["HesapNo"]} - {dr2["Bakiye"]:C2}",
                            ID = Convert.ToInt32(dr2["HesapID"])
                        });
                    }
                    dr2.Close();
                }
                catch { }
            }
        }

        private void ArayuzuOlustur()
        {
            this.Size = new Size(450, 550);
            this.Text = "Altın Satış İşlemi";
            int x = 40, y = 30, w = 350, gap = 40;
            Font baslikFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 11);

            Label lblBaslik = new Label() { Text = $"SATIŞ KURU: {ALTIN_SATIS_KURU:C2} / gr", Location = new Point(x, y), AutoSize = true, Font = baslikFont, ForeColor = Color.Red };
            y += gap + 10;

            Label lbl1 = new Label() { Text = "Bozdurulacak Altın Hesabı:", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            uiAltinHesap = new ComboBox() { Location = new Point(x, y), Width = w, DropDownStyle = ComboBoxStyle.DropDownList, Font = normalFont }; y += gap;

            Label lbl2 = new Label() { Text = "Paranın Yatacağı TL Hesabı:", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            uiTLHesap = new ComboBox() { Location = new Point(x, y), Width = w, DropDownStyle = ComboBoxStyle.DropDownList, Font = normalFont }; y += gap + 10;

            GroupBox gb = new GroupBox() { Text = "İşlem Türü Seçiniz", Location = new Point(x, y), Size = new Size(w, 80), ForeColor = Color.Orange };
            uiOptGram = new RadioButton() { Text = "Gram Olarak Sat", Location = new Point(20, 30), AutoSize = true, Checked = true, Font = normalFont };
            uiOptTL = new RadioButton() { Text = "TL Karşılığı Sat", Location = new Point(180, 30), AutoSize = true, Font = normalFont };
            gb.Controls.Add(uiOptGram); gb.Controls.Add(uiOptTL);
            uiOptGram.CheckedChanged += ModDegisti; uiOptTL.CheckedChanged += ModDegisti;
            this.Controls.Add(gb); y += gb.Height + 20;

            Label lbl3 = new Label() { Text = "Gram Miktarı:", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            uiInputGram = new TextBox() { Location = new Point(x, y), Width = w, Font = normalFont }; y += gap;
            uiInputGram.TextChanged += Hesapla;

            Label lbl4 = new Label() { Text = "Toplam Tutar (TL):", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            uiInputTL = new TextBox() { Location = new Point(x, y), Width = w, Font = normalFont, Enabled = false }; y += gap;
            uiInputTL.TextChanged += Hesapla;

            uiLblBilgi = new Label() { Text = "...", Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Italic), ForeColor = Color.Gray }; y += gap;

            Button btnSat = new Button() { Text = "ALTIN SAT", Location = new Point(x, y), Width = w, Height = 50, BackColor = Color.Red, ForeColor = Color.White, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            btnSat.Click += BtnSat_Click;

            this.Controls.Add(lblBaslik); this.Controls.Add(lbl1); this.Controls.Add(uiAltinHesap);
            this.Controls.Add(lbl2); this.Controls.Add(uiTLHesap); this.Controls.Add(lbl3); this.Controls.Add(uiInputGram);
            this.Controls.Add(lbl4); this.Controls.Add(uiInputTL); this.Controls.Add(uiLblBilgi); this.Controls.Add(btnSat);
        }

        // --- SİHİRLİ DEĞNEK: ComboItem Sınıfı ---
        public class ComboItem
        {
            public string Text { get; set; }
            public int ID { get; set; }
            public override string ToString() { return Text; }
        }
    }
}