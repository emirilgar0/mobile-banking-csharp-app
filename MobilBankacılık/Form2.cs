using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace MobilBankacılık
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Tasarim.Uygula(this);

            // TextBox ayarları
            MskdTxtTC.MaxLength = 11;
            MskdTxtTel.MaxLength = 10;
            TxtBoxSifreKayit.UseSystemPasswordChar = true;

            // KeyPress event'leri
            MskdTxtTC.KeyPress += SadeceRakam_KeyPress;
            MskdTxtTel.KeyPress += SadeceRakam_KeyPress;
            TxtBoxIsim.KeyPress += SadeceHarf_KeyPress;
            txtBoxSoyisim.KeyPress += SadeceHarf_KeyPress;
        }

        // Sadece rakam girişine izin ver
        private void SadeceRakam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Sadece harf ve boşluk girişine izin ver
        private void SadeceHarf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            // 1. İsim kontrolü
            if (string.IsNullOrWhiteSpace(TxtBoxIsim.Text))
            {
                MessageBox.Show("İsim alanı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtBoxIsim.Focus();
                return;
            }
            if (TxtBoxIsim.Text.Trim().Length < 2)
            {
                MessageBox.Show("İsim en az 2 karakter olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtBoxIsim.Focus();
                return;
            }

            // 2. Soyisim kontrolü
            if (string.IsNullOrWhiteSpace(txtBoxSoyisim.Text))
            {
                MessageBox.Show("Soyisim alanı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxSoyisim.Focus();
                return;
            }
            if (txtBoxSoyisim.Text.Trim().Length < 2)
            {
                MessageBox.Show("Soyisim en az 2 karakter olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoxSoyisim.Focus();
                return;
            }

            // 3. TC Kimlik kontrolü
            string tc = MskdTxtTC.Text.Replace(" ", "").Replace("_", "").Trim();

            if (string.IsNullOrWhiteSpace(tc) || tc.Length != 11)
            {
                MessageBox.Show("TC Kimlik numarası 11 haneli olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MskdTxtTC.Focus();
                return;
            }
            if (!tc.All(char.IsDigit))
            {
                MessageBox.Show("TC Kimlik numarası sadece rakamlardan oluşmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MskdTxtTC.Focus();
                return;
            }
            if (tc[0] == '0')
            {
                MessageBox.Show("TC Kimlik numarası 0 ile başlayamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MskdTxtTC.Focus();
                return;
            }

            // 4. Telefon kontrolü
            string telefon = MskdTxtTel.Text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace("_", "").Trim();

            if (string.IsNullOrWhiteSpace(telefon) || telefon.Length != 10)
            {
                MessageBox.Show("Telefon numarası 10 haneli olmalıdır! (örn: 5321234567)", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MskdTxtTel.Focus();
                return;
            }
            if (!telefon.All(char.IsDigit))
            {
                MessageBox.Show("Telefon numarası sadece rakamlardan oluşmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MskdTxtTel.Focus();
                return;
            }
            if (!telefon.StartsWith("5"))
            {
                MessageBox.Show("Telefon numarası 5 ile başlamalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MskdTxtTel.Focus();
                return;
            }

            // 5. Şifre kontrolü
            if (string.IsNullOrWhiteSpace(TxtBoxSifreKayit.Text))
            {
                MessageBox.Show("Şifre alanı boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtBoxSifreKayit.Focus();
                return;
            }
            if (TxtBoxSifreKayit.Text.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtBoxSifreKayit.Focus();
                return;
            }

            // Validasyonlar geçti, kayıt işlemine devam et
            string salt = GenerateSalt();
            string hashed = Form1.HashPassword(TxtBoxSifreKayit.Text, salt);

            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();

                    // TC zaten kayıtlı mı kontrol et
                    string checkQuery = "SELECT COUNT(*) FROM Kullanicilar WHERE TC = @tc";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@tc", tc);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu TC kimlik numarası ile zaten kayıt yapılmış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Kayıt işlemi
                    string query = @"INSERT INTO Kullanicilar (Isim, Soyad, Telefon, SifreHash, SifreSalt, TC) 
                                   VALUES (@p1, @p2, @p3, @p4, @p5, @p6)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@p1", TxtBoxIsim.Text.Trim());
                        cmd.Parameters.AddWithValue("@p2", txtBoxSoyisim.Text.Trim());
                        cmd.Parameters.AddWithValue("@p3", telefon);
                        cmd.Parameters.AddWithValue("@p4", hashed);
                        cmd.Parameters.AddWithValue("@p5", salt);
                        cmd.Parameters.AddWithValue("@p6", tc);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kayıt başarılı! Giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Formu temizle
                    TxtBoxIsim.Clear();
                    txtBoxSoyisim.Clear();
                    MskdTxtTC.Clear();
                    MskdTxtTel.Clear();
                    TxtBoxSifreKayit.Clear();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}