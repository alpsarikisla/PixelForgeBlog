﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_makaleler.DataSource = dm.MakaleListele();
            lv_makaleler.DataBind();
        }
    }
}