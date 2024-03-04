using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_kategoriler.DataSource = dm.KategorileriGetir();
            ddl_kategoriler.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {

        }
    }
}