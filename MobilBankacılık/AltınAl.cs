using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static MobilBankacılık.Form1;

namespace MobilBankacılık
{
    public partial class AltınAl : Form
    {
        private const decimal ALTIN_KURU = 6250.00m;

        private ComboBox boxAltinHesap, boxTLHesap;
        private RadioButton optGram, optTL;
        private TextBox inputGram, inputTL;
        private Label lblBilgi;

        public AltınAl()
        {
            // InitializeComponent(); // KAPALI
            ArayuzuOlustur();
            Tasarim.Uygula(this);
            HesaplariYukle(); // Load yerine burada yüklüyoruz ki garanti olsun
        }

        // --- HATA SUSTURUCULAR ---
        public void txtGramAltin_TextChanged(object sender, EventArgs e) { }
        public void txtTLAltin_TextChanged(object sender, EventArgs e) { }
        public void BtnAltinAl_Click(object sender, EventArgs e) { }
        // -------------------------

        private void AltınAl_Load(object sender, EventArgs e)
        {
            if (optGram != null) optGram.Checked = true;
        }

        private void Hesapla(object sender, EventArgs e)
        {
            if (optGram.Checked)
            {
                if (decimal.TryParse(inputGram.Text, out decimal gram) && gram > 0)
                {
                    inputTL.Text = (gram * ALTIN_KURU).ToString("N2");
                    lblBilgi.Text = $"{gram} Gram = {inputTL.Text} TL";
                    lblBilgi.ForeColor = Color.Cyan;
                }
                else { inputTL.Text = "0.00"; lblBilgi.Text = "..."; }
            }
            else
            {
                if (decimal.TryParse(inputTL.Text, out decimal tl) && tl > 0)
                {
                    inputGram.Text = (tl / ALTIN_KURU).ToString("N2");
                    lblBilgi.Text = $"{tl:C2} TL = {inputGram.Text} Gram";
                    lblBilgi.ForeColor = Color.Cyan;
                }
                else { inputGram.Text = "0.00"; lblBilgi.Text = "..."; }
            }
        }

        private void ModDegisti(object sender, EventArgs e)
        {
            inputGram.Clear(); inputTL.Clear(); lblBilgi.Text = "...";

            if (optGram.Checked)
            {
                inputGram.Enabled = true; inputGram.BackColor = Color.FromArgb(40, 45, 65);
                inputTL.Enabled = false; inputTL.BackColor = Color.FromArgb(30, 30, 40);
                inputGram.Focus();
            }
            else
            {
                inputGram.Enabled = false; inputGram.BackColor = Color.FromArgb(30, 30, 40);
                inputTL.Enabled = true; inputTL.BackColor = Color.FromArgb(40, 45, 65);
                inputTL.Focus();
            }
        }

        private void BtnAl_Click(object sender, EventArgs e)
        {
            if (boxAltinHesap.SelectedItem == null || boxTLHesap.SelectedItem == null)
            { MessageBox.Show("Lütfen hesapları seçiniz."); return; }

            decimal islemGrami = 0; decimal islemTutari = 0;
            decimal.TryParse(inputGram.Text, out islemGrami);
            decimal.TryParse(inputTL.Text, out islemTutari);

            if (islemGrami <= 0 || islemTutari <= 0) { MessageBox.Show("Geçerli bir miktar giriniz."); return; }

            int altinID = (boxAltinHesap.SelectedItem as ComboItem).ID;
            int tlID = (boxTLHesap.SelectedItem as ComboItem).ID;

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmdBak = new SqlCommand("SELECT Bakiye FROM Hesaplar WHERE HesapID=@id", conn);
                    cmdBak.Parameters.AddWithValue("@id", tlID);
                    decimal mevcutTL = Convert.ToDecimal(cmdBak.ExecuteScalar());

                    if (mevcutTL < islemTutari) { MessageBox.Show("Yetersiz TL Bakiyesi."); return; }

                    SqlCommand cmdDus = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye - @tl WHERE HesapID = @idTL", conn);
                    cmdDus.Parameters.AddWithValue("@tl", islemTutari);
                    cmdDus.Parameters.AddWithValue("@idTL", tlID);
                    cmdDus.ExecuteNonQuery();

                    SqlCommand cmdEkle = new SqlCommand("UPDATE Hesaplar SET Bakiye = Bakiye + @gr WHERE HesapID = @idAltin", conn);
                    cmdEkle.Parameters.AddWithValue("@gr", islemGrami);
                    cmdEkle.Parameters.AddWithValue("@idAltin", altinID);
                    cmdEkle.ExecuteNonQuery();

                    Logla(conn, altinID, islemGrami, islemTutari, "Alış");
                    OzetEkle(conn, tlID, $"Altın Alımı (-{islemTutari:C2})", islemTutari * -1);
                    OzetEkle(conn, altinID, $"Altın Alımı (+{islemGrami} gr)", islemGrami);

                    MessageBox.Show($"{islemGrami} Gram Altın başarıyla alındı.");
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
            boxAltinHesap.Items.Clear();
            boxTLHesap.Items.Clear();

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
                        boxAltinHesap.Items.Add(new ComboItem
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
                        boxTLHesap.Items.Add(new ComboItem
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
            this.Text = "Altın Alım İşlemi";
            int x = 40, y = 30, w = 350, gap = 40;
            Font baslikFont = new Font("Segoe UI", 14, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 11);

            Label lblBaslik = new Label() { Text = $"GÜNCEL KUR: {ALTIN_KURU:C2} / gr", Location = new Point(x, y), AutoSize = true, Font = baslikFont, ForeColor = Color.Gold };
            y += gap + 10;

            Label lbl1 = new Label() { Text = "Altın Eklenecek Hesap:", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            boxAltinHesap = new ComboBox() { Location = new Point(x, y), Width = w, DropDownStyle = ComboBoxStyle.DropDownList, Font = normalFont }; y += gap;

            Label lbl2 = new Label() { Text = "Ödeme Yapılacak TL Hesap:", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            boxTLHesap = new ComboBox() { Location = new Point(x, y), Width = w, DropDownStyle = ComboBoxStyle.DropDownList, Font = normalFont }; y += gap + 10;

            GroupBox gb = new GroupBox() { Text = "İşlem Türü Seçiniz", Location = new Point(x, y), Size = new Size(w, 80), ForeColor = Color.Cyan };
            optGram = new RadioButton() { Text = "Gram Girerek Al", Location = new Point(20, 30), AutoSize = true, Checked = true, Font = normalFont };
            optTL = new RadioButton() { Text = "TL Tutarı Girerek Al", Location = new Point(180, 30), AutoSize = true, Font = normalFont };
            gb.Controls.Add(optGram); gb.Controls.Add(optTL);
            optGram.CheckedChanged += ModDegisti; optTL.CheckedChanged += ModDegisti;
            this.Controls.Add(gb); y += gb.Height + 20;

            Label lbl3 = new Label() { Text = "Gram Miktarı:", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            inputGram = new TextBox() { Location = new Point(x, y), Width = w, Font = normalFont }; y += gap;
            inputGram.TextChanged += Hesapla;

            Label lbl4 = new Label() { Text = "Toplam Tutar (TL):", Location = new Point(x, y), AutoSize = true, ForeColor = Color.White }; y += 25;
            inputTL = new TextBox() { Location = new Point(x, y), Width = w, Font = normalFont, Enabled = false }; y += gap;
            inputTL.TextChanged += Hesapla;

            lblBilgi = new Label() { Text = "...", Location = new Point(x, y), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Italic), ForeColor = Color.Gray }; y += gap;

            Button btnAl = new Button() { Text = "ALTIN AL", Location = new Point(x, y), Width = w, Height = 50, BackColor = Color.Gold, ForeColor = Color.Black, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            btnAl.Click += BtnAl_Click;

            this.Controls.Add(lblBaslik); this.Controls.Add(lbl1); this.Controls.Add(boxAltinHesap);
            this.Controls.Add(lbl2); this.Controls.Add(boxTLHesap); this.Controls.Add(lbl3); this.Controls.Add(inputGram);
            this.Controls.Add(lbl4); this.Controls.Add(inputTL); this.Controls.Add(lblBilgi); this.Controls.Add(btnAl);
        }

        public class ComboItem
        {
            public string Text { get; set; }
            public int ID { get; set; }
            public override string ToString() { return Text; }
        }
    }
}