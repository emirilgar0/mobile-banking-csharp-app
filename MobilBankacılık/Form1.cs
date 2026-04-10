using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace MobilBankacılık
{
    public partial class Form1 : Form
    {
        public static class KullaniciBilgileri { public static int KullaniciID; }

        public Form1()
        {
            InitializeComponent();
            Tasarim.Uygula(this);
            // GÜVENLİK AYARLARI
            TxtBoxHesapNoGiris.MaxLength = 11; // TC Sınırı
            TxtBoxSifreGiris.UseSystemPasswordChar = true; // Şifre Gizle
        }

        private void Form1_Load(object sender, EventArgs e) { }

        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(bytes);
            }
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string tc = TxtBoxHesapNoGiris.Text.Trim();
            string sifre = TxtBoxSifreGiris.Text;

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT KullanıcıID, SifreHash, SifreSalt FROM Kullanicilar WHERE TC = @TC", conn);
                    cmd.Parameters.AddWithValue("@TC", tc);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedHash = reader["SifreHash"].ToString();
                        string storedSalt = reader["SifreSalt"].ToString();

                        if (HashPassword(sifre, storedSalt) == storedHash)
                        {
                            KullaniciBilgileri.KullaniciID = Convert.ToInt32(reader["KullanıcıID"]);
                            AnaSayfa form = new AnaSayfa();
                            form.Show();
                            this.Hide();
                        }
                        else MessageBox.Show("Hatalı şifre!");
                    }
                    else MessageBox.Show("Kullanıcı bulunamadı!");
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private void btnKayıtOl_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}