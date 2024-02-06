using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
    }
}
