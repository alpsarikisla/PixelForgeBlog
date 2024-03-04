﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="PixelForgeWebApp.AdminPanel.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStil.css" rel="stylesheet" />
    <%--  FormStil.css Dosyası Sadece Kategori Ekle Sayfasında Çalışaçağı için MasterPage'in Head Bloğuna Değil. Sayfanın Content1 Alanına Eklendi--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formSayfabaslik">
        <h2>Kategori Ekle</h2>
    </div>
    <div class="formTasiyici">
        <div class="baslik">
            <h3>Kategori Bilgileri</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                Kategori başarı ile eklenmiştir.
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server">Kategori eklerken bir hata oluştu</asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_kategoriadi" runat="server" CssClass="metinKutu" placeholder="Kategori Adı Giriniz"></asp:TextBox>
            </div>
            <div class="satir" style="margin-top: 10px;">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="buton" OnClick="lbtn_ekle_Click">
                    Kategori Ekle
                </asp:LinkButton>
                <a href="#">Kategori Listesine Dön</a>
            </div>
        </div>
    </div>
</asp:Content>
