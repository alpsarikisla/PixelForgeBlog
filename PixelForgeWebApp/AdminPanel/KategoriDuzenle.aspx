<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="PixelForgeWebApp.AdminPanel.KategoriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formSayfabaslik">
        <h2>Kategori Düzenle</h2>
    </div>
    <div class="formTasiyici">
        <div class="baslik">
            <h3>Kategori Bilgileri</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                Kategori başarı ile düzenlenmistir.
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server">Kategori düzenlerken bir hata oluştu</asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_kategoriadi" runat="server" CssClass="metinKutu" placeholder="Kategori Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" Text=" Aktif Kategori" /><br /><br />
                <label>Aktif işaretli ise kategori yayınlanır</label><br />
            </div>
            <div class="satir" style="margin-top: 10px;">
                <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="buton" OnClick="lbtn_duzenle_Click">
                    Kategori Düzenle
                </asp:LinkButton>
                <a href="KategoriListele.aspx">Kategori Listesine Dön</a>
            </div>
        </div>
    </div>
</asp:Content>
