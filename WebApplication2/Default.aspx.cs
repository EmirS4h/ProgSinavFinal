using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EkleBtn_Click(object sender, EventArgs e)
        {
            // StreanWriter dosya yoksa Dosyayı oluşturur
            // Server.MapPath dosyayı bulur
            StreamWriter dosya = new StreamWriter(Server.MapPath("ogrenci.txt"), true); // Eger true varsa dosyanın üzerine yazar, önceki yazılanları silmez
            string line = Numara.Text; // yazılacak satır
            dosya.WriteLine(line); // dosyaya yaz
            dosya.Close(); // dosyayı kapat
        }

        protected void OkuBtn_Click(object sender, EventArgs e)
        {
            // StreamReader Dosya okur
            StreamReader dosya = new StreamReader(Server.MapPath("ogrenci.txt"));
            string satir; // Okunan satırları tutar

            // okunacak satır kalmayana kadar devam eder ve her satırı 'satir' degiskenine ekler
            while ((satir = dosya.ReadLine()) != null)
            {
                Response.Write(satir + "</br>"); // Her satır okunusunda Ekrana yazdırır
            }
            dosya.Close(); // Dosyayı kapatır
        }

        protected void DegistirBtn_Click(object sender, EventArgs e)
        {
            // Okunacak dosya
            StreamReader dosya1 = new StreamReader(Server.MapPath("ogrenci.txt"));

            // Üsteki dosyanın yerini alacak dosya
            StreamWriter dosya2 = new StreamWriter(Server.MapPath("b.txt"));

            string satir;

            // yine okunacak satır kalmayana kadar devam
            while ((satir = dosya1.ReadLine()) != null)
            {
                if (satir != Numara.Text) // eger satır silinecek değil ise o satırı dosya2 ye yaz
                {
                    dosya2.WriteLine(satir);
                }
                else // eger satır silinmesini istediğimiz satır ise bir şey yapma
                {
                    continue; // bir şey yapmadığımız için o satırı yeni dosyaya yazmayacak ve silinmiş gibi olucak
                }
            }

            // Dosyaları kapat
            dosya1.Close();
            dosya2.Close();

            // Eski dosyayı sil
            File.Delete(Server.MapPath("ogrenci.txt"));

            // Yeni dosyaya eskisinin adını ver
            File.Move(Server.MapPath("b.txt"), Server.MapPath("ogrenci.txt"));

        }

        protected void ListeleBtn_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("ogrenciler.db");
            String connection = "Data Source="+path+";Version=3;";
            String command = "SELECT * FROM tbl_ogrenciler;";

            SQLiteConnection conn = new SQLiteConnection(connection);

            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(command, conn);

                // geriye bir şey dönüyorsa
                // bu durumda numaralar dönüyor
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Response.Write(
                        reader["numara"].ToString() + "</br>");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void EkleBtnSql_Click(object sender, EventArgs e)
        {
            String path = Server.MapPath("ogrenciler.db");
            String connection = "Data Source="+path+";Version=3;";
            String command = "INSERT INTO tbl_ogrenciler (numara) VALUES("+Numara.Text+");";

            SQLiteConnection conn = new SQLiteConnection(connection);

            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(command, conn);

                //SQLiteDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();

                //while (reader.Read())
                //{
                //    Response.Write(
                //        reader["numara"].ToString() + "</br>");
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}