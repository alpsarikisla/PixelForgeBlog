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
            Makale makale = new Makale();
            makale.Baslik = tb_baslik.Text;
            makale.BegeniOrani = 0;
            makale.BegeniSayi = 0;
            makale.Durum = cb_durum.Checked;
            makale.EklemeTarihi = DateTime.Now;
            makale.GoruntulemeSayi = 0;
            makale.Icerik = tb_icerik.Text;
            makale.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            makale.Ozet = tb_ozet.Text;
            makale.Yazar_ID = (Session["girisyapanyonetici"] as Yonetici).ID;
            if (fu_resim.HasFile)//File Upload'da resim seçilmiş ise
            {
                //Resim için eşsiz bir isim üretmek zorundayız.
                FileInfo fi = new FileInfo(fu_resim.FileName);

                //resmin uzantısı alıyoruz(resim jpeg olabilir png olabilir)
                string resimuzanti = fi.Extension;

                string essizisim = Guid.NewGuid().ToString() + resimuzanti;

                makale.KapakResim = essizisim;

                //Henüz upload gerçekleşmedi sadece isim ürettik
                //Resim upload etme
                fu_resim.SaveAs(Server.MapPath("../MakaleResimleri/" + essizisim));
            }
            else
            {
                makale.KapakResim = "none.png";
            }

            if (dm.MakaleEkle(makale))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Makale eklenirken bir hata oluştu";
            }
        }
    }
}