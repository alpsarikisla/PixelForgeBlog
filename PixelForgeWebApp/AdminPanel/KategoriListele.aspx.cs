using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = dm.KategorileriGetir();
            lv_kategoriler.DataBind();
        }

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //ListViewCommandEventArgs e ile belirtilen e değişkeni listede basılan butonun tüm özelliklerini getirir
            //Böylece tıklanan butonun commentargument alanına attığımız ID bilgisini buradan alabildik
            int id = Convert.ToInt32(e.CommandArgument);
            dm.KategoriSil(id);
            lv_kategoriler.DataSource = dm.KategorileriGetir();
            lv_kategoriler.DataBind();
        }
    }
}