using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PixelForgeWebApp.AdminPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sayfa Açılırken Yapılacak olan işlemler bu alanda yer alır
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            //Butona Basılınca Yapılacak işlemler bu alanda yer alır
            if (!string.IsNullOrEmpty(tb_kategoriadi.Text)) //tb kategori adı isimli texbox'ın text'i boş değilse
            {
                Kategori kat = new Kategori();
                kat.Isim = tb_kategoriadi.Text;
                kat.Durum = true;
                if (dm.KategoriEkle(kat))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Kategori eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Kategori adı boş bırakılamaz";
            }
        }
    }
}