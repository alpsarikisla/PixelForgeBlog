using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Adres çubuğunda taşınan verilerin sayısı 0 değilse sayfayı aç, 0 ise kategori listele sayfasına gönder
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)//Sayfa İlk kez açılıyorsa
                {
                    //Butona basıldığında veritabanından veri çekmesini istemiyoruz
                    int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
                    Kategori kat = dm.TekKategoriGetir(id);
                    tb_kategoriadi.Text = kat.Isim;
                    cb_durum.Checked = kat.Durum;
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            if (tb_kategoriadi.Text.Length != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
                Kategori kat = dm.TekKategoriGetir(id);
                kat.Isim = tb_kategoriadi.Text;
                kat.Durum = cb_durum.Checked;
                if (dm.KategoriGuncelle(kat))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori eklenirken bir hata ile karşılaşıldı";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Kategori Adı boş bırakılamaz";
            }
        }
    }
}