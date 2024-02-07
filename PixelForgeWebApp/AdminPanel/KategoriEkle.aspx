<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="PixelForgeWebApp.AdminPanel.KategoriEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStil.css" rel="stylesheet" />
  <%--  FormStil.css Dosyası Sadece Kategori Ekle Sayfasında Çalışaçağı için MasterPage'in Head Bloğuna Değil. Sayfanın Content1 Alanına Eklendi--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfabaslik">
        <h2>Kategori Ekle</h2>
    </div>
    <div class="formTasiyici">
        <div class="baslik">
            <h3>Kategori Bilgileri</h3>
        </div>
        <div class="formIcerik">
            <div class="satir">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_kategoriadi" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <a href="#">Kategori Listesine Dön</a>
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="buton"></asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
