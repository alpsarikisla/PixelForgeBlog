using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class AdminGiris : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sayfa Açılırken yapılacak olan işlemler bu alana yazılır
        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            DataModel dm = new DataModel();
            //lbtn_Giris isimli butona tıklandığı zaman yapılacak işlemler bu alana yazılır
            if (!string.IsNullOrEmpty(tb_kullanici.Text))
            {
                if (!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    //Nesne Sadece Admin giriş sayfası içerisinden ulaşılabilir.
                    Yonetici yon = dm.YoneticiGiris(tb_kullanici.Text, tb_sifre.Text);
                    if (yon != null)
                    {
                        //Yönetici nesnesini Masterpage ve diğer sayfalardan erişilebilir olarak tanımlamak için
                        //ClientSite(Browser'ın ram'i) üzerinde veriyi tutmam gerekir. Bu işlem için session kullanılır.
                        //Session= Browser ram'i üzerinde veri tutmaya yarayan araçtır. Browser kapatılınca nesne de yok olur.
                        Session["girisyapanyonetici"] = yon;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_hata.Visible = true;
                        lbl_hata.Text = "Kullanıcı Bulunamadı";
                    }
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hata.Text = "Şifre boş bırakılamaz";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hata.Text = "Kullanıcı Adı Boş Bırakılamaz";
            }
        }
    }
}