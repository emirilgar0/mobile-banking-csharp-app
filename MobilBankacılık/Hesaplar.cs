using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static MobilBankacılık.Form1;

namespace MobilBankacılık
{
    public partial class Hesaplar : Form
    {
        public Hesaplar()
        {
            InitializeComponent();
            Tasarim.Uygula(this);
            Yukle();
        }

        private void Yukle()
        {
            using (SqlConnection conn = Veritabani.BaglantiGetir())
            {
                try
                {
                    conn.Open();
                    // Tablonun düzgün görünmesi için Join kullanarak daha anlamlı veri çekiyoruz
                    string query = @"SELECT h.IBAN, h.HesapNo, ht.TürAdı, h.Bakiye, h.DövizCinsi 
                                     FROM Hesaplar h
                                     JOIN HesapTürü ht ON h.HesapTürüID = ht.HesapTürüID
                                     WHERE h.KullanıcıID = @id";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@id", KullaniciBilgileri.KullaniciID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHesap.DataSource = dt;
                }
                catch (Exception ex) { MessageBox.Show("Veri hatası: " + ex.Message); }
            }
        }

        private void Hesaplar_Load(object sender, EventArgs e) { }
    }
}