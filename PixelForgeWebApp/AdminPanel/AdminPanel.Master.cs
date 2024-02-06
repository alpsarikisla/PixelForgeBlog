using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class AdminPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["girisyapanyonetici"] != null)
            {
                //Giriş işlemi gerçekleşmiş ve Session dolu ise Session içerisinde bu sayfaya taşınan bilgileri al
                Yonetici yon = Session["girisyapanyonetici"] as Yonetici;//Unboxing
                //Unboxing Object türünde bir değişkene atılmış olan olan herhangi türdeki verinin kendi türüne döndürülmesi olayıdır
                lbl_kullanici.Text = yon.KullaniciAdi;
            }
            else
            {
                //Giriş işlemi gerçekleşmemiş ise Giriş sayfasına yönlendir
                Response.Redirect("AdminGiris.aspx");
            }
        }
    }
}