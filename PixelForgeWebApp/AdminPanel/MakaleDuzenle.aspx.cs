using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class MakaleDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_kategoriler.DataSource = dm.KategorileriGetir();
                    ddl_kategoriler.DataBind();
                    int makid = Convert.ToInt32(Request.QueryString["MakaleID"]);
                    Makale mak = dm.MakaleGetir(makid);

                    ddl_kategoriler.SelectedValue = Convert.ToString(mak.Kategori_ID);
                    tb_baslik.Text = mak.Baslik;
                    tb_icerik.Text = mak.Icerik;
                    tb_ozet.Text = mak.Ozet;
                    cb_durum.Checked = mak.Durum;
                    img_resim.ImageUrl = "../MakaleResimleri/" + mak.KapakResim;
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
            
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int makid = Convert.ToInt32(Request.QueryString["MakaleID"]);
            Makale mak = dm.MakaleGetir(makid);

            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            mak.Baslik = tb_baslik.Text;
            mak.Durum = cb_durum.Checked;
            mak.Icerik = tb_icerik.Text;
            mak.Ozet = tb_ozet.Text;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string resimuzanti = fi.Extension;
                string essizisim = Guid.NewGuid().ToString() + resimuzanti;
                mak.KapakResim = essizisim;
                fu_resim.SaveAs(Server.MapPath("../MakaleResimleri/" + essizisim));
            }
            if (dm.MakaleDuzenle(mak))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Makale düzenlenirken bir hata oluştu";
            }
        }
    }
}