using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Giriş Metotları

        public Yonetici YoneticiGiris(string kullaniciAdi, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.YoneticiTur_ID, YT.Isim, Y.Isim,Y.Soyisim,Y.KullaniciAdi,Y.Mail,Y.Sifre,Y.Durum FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTur_ID = YT.ID WHERE Y.KullaniciAdi =@ka AND Y.Sifre = @sf";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ka", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sf", sifre);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Yonetici y = null;
                while (reader.Read())
                {
                    y = new Yonetici();
                    y.ID = reader.GetInt32(0);
                    y.YoneticiTurID = reader.GetInt32(1);
                    y.YoneticiTur = reader.GetString(2);
                    y.Isim = reader.GetString(3);
                    y.Soyisim = reader.GetString(4);
                    y.KullaniciAdi = reader.GetString(5);
                    y.Mail = reader.GetString(6);
                    y.Sifre = reader.GetString(7);
                    y.Durum = reader.GetBoolean(8);
                }
                return y;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        //oluşturduğumuz kategori nesnesi içindeki verileri, veri tabanına ekleyecek metot
        //Metoda kategori nesnesi parametre olarak alınmalıdır
        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim, Durum) VALUES(@i,@d)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", kat.Isim);
                cmd.Parameters.AddWithValue("@d", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();//Sorgu geriye veri döndürmeyecek bu yüzden ExecuteNonQuery() Kullanılır
                return true;//Eğer hata oluşmaz ise metodum çalıştırıldığı yere true sonucu döndürsün
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategorileriGetir()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                //Veritabanından gelen kategori bilgilerini nesneye döndürdükten sonra bu koleksiyona olduracağız.
                //Böylece Veriler c# tarafından yönetilebilir ve filtrelenebilir olacak
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategoriler";
                //Veritanındaki kategoriler tablosunun içinde bulunan ID,Isim,Durum kolonlarının verisini çekebilecek Query Yazıldı.
                cmd.Parameters.Clear();//Yazılan sorgu parametre almasa bile bile hata oluşmaması için parametreleri temizliyoruz
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //Yazılan sorgudan bir tablo verisi dönüyor ise Sorgu ExecuteReader ile çalıştırılmalıdır.
                //SqlDataReader Sorgudan gelen tablo verilerini tutabilecek sınıftır. Ancak içindeki verilerin uygun türlere göre ayıklanması gerekir
                while (reader.Read())//Read komutu SqlDataReader içerisinde okunmamış satır var ise true sonuç döndürür
                {
                    Kategori kat = new Kategori();
                    //Veritabanından gelen her satır veriyi c# kısmında kategori nesnesine dönüştürüyoruz
                    kat.ID = reader.GetInt32(0);//Yukarıdaki cmd.CommandText içerisine yazdığımız sorgudaki ID,Isim,Durum .kolonlarının "SORGU İÇERİSİNDEKİ" sırasına göre verileri 0. index,1. index,2. index olacak şekilde reader'dan ayıklıyoruz
                    kat.Isim = reader.GetString(1);//Veritabanında isim kolonunun türü nvarchar(string) olduğu için Getstring komutu ile String türünde okuma gerleştiriyoruz
                    kat.Durum = reader.GetBoolean(2);//Veritabanında kolon türü bit(bool) olduğu için getBoolean ile okuma gerçeştirdik
                    kategoriler.Add(kat);//Oluşturulan kategori nesnesini kategoriler ismindeki koleksiyona ekledik. böylece kategori nesneleri bir arada ve düzenli olarak depolandı 
                }
                return kategoriler;
                //Veritabanından gelen tüm kategori bilgileri ayıklanıp, nesneye dönüştürülüp, koleksiyona eklendikten sonra metodumuz çağırıldığı anda gönderilmek üzere return ile belirlendi
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori TekKategoriGetir(int id)
        {
            Kategori kat = new Kategori();
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Durum FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriGuncelle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @isim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                cmd.Parameters.AddWithValue("@id", kat.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(Kategori_ID, Yazar_ID, Baslik, Ozet, Icerik, KapakResim, EklemeTarih, GoruntulemeSayi, BegeniSayi, BegeniOrani, Durum) VALUES(@kategori_ID, @yazar_ID, @baslik, @ozet, @icerik, @kapakResim, @eklemeTarih, @goruntulemeSayi, @begeniSayi, @begeniOrani, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategori_ID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazar_ID", mak.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@eklemeTarih", mak.EklemeTarihi);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@begeniSayi", mak.BegeniSayi);
                cmd.Parameters.AddWithValue("@begeniOrani", mak.BegeniOrani);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        
        public List<Makale> MakaleListele()
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, M.Yazar_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.EklemeTarih, M.GoruntulemeSayi,m.BegeniSayi, M.BegeniOrani, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yazar_ID = Y.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yazar_ID = reader.GetInt32(3);
                    mak.Yazar = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.EklemeTarihi = reader.GetDateTime(9);
                    mak.GoruntulemeSayi = reader.GetInt32(10);
                    mak.BegeniSayi = reader.GetInt32(11);
                    mak.BegeniOrani = reader.GetDecimal(12);
                    mak.Durum = reader.GetBoolean(13);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
