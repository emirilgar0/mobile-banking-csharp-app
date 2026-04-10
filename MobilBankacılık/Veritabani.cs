using System.Data.SqlClient;

namespace MobilBankacılık
{
    public static class Veritabani
    {
        // MSI\SQLEXPRESS için doğru bağlantı
        private static string connectionString =
            "Data Source=MSI\\SQLEXPRESS;Initial Catalog=Banka;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection BaglantiGetir()
        {
            return new SqlConnection(connectionString);
        }
    }
}
