using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel db = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_makaleler.DataSource = db.MakaleListele();
            rp_makaleler.DataBind();
        }
    }
}