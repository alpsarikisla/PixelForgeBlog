<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="PixelForgeWebApp.AdminPanel.MakaleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formSayfabaslik">
        <h2>Makale Ekle</h2>
    </div>
    <div class="formTasiyici">
        <div class="baslik">
            <h3>Makale Bilgileri</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliPanel" Visible="false">
                Makale başarı ile Eklenmiştir
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizPanel" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>

            <div class="solIcerik">

                <div class="row">
                    <label>Makale Başlık</label>
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Makale Kategorisi</label>
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="metinKutu" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label>Kapak Resmi</label>
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinKutu" />
                </div>
                <div class="row">
                    <div class="satir">
                        <asp:CheckBox ID="cb_durum" runat="server" Text=" Yayınla" /><br />
                        <label>Aktif işaretli ise makale yayınlanır</label><br />
                    </div>
                </div>
            </div>
            <div class="sagIcerik">
                <div class="row">
                    <label>Özet</label>
                    <asp:TextBox ID="tb_ozet" runat="server" TextMode="MultiLine" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Makale İçeriği</label>
                    <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine" CssClass="metinKutu" Height="150"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="buton" OnClick="lbtn_ekle_Click">Makale Ekle</asp:LinkButton>
                    <a href="#">Makaleler Listesine Dön</a>
                </div>
            </div>
            <div style="clear: both"></div>

        </div>
    </div>
</asp:Content>
