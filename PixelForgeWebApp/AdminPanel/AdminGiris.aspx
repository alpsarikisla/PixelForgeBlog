<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="PixelForgeWebApp.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/AdminGirisStil.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="girisPanel">
            <div class="sol">
                <img src="Resimler/loginimage-01.png" />
            </div>
            <div class="sag">
                <asp:Panel ID="pnl_hata" runat="server" CssClass="panelHata" Visible="false">
                    <asp:Label ID="lbl_hata" runat="server"></asp:Label>
                      <%-- asp:Label C# tarafından(Code Behind) kontrol edilebilen label(span) oluşturur. Label'a uygulanabilen tüm css özellikleri asp:Label'a Uygulanabilir --%>
                </asp:Panel>
                <%-- asp:Panel C# tarafından(Code Behind) kontrol edilebilen div oluşturur. Div'e uygulanabilen tüm css özellikleri asp:Panel'e Uygulanabilir --%>
                <br />
                <h4>Lütfen Giriş Yapmak için bilgilerini giriniz</h4>

                <!-- Yorum Satırı -->
                <!-- TextBox -->
                <!-- Web Sayfasından veri alma araçlarının başında metin kutusu(TextBox Gelir) -->
                <!-- HTML karşılığı input typr=text olan bu kontrol asp de asp:TextBox olarak adlandırılır -->
                <!-- Her Asp Kontrolü ID ve runat attributelarına ihticacı vardır -->
                <!-- ID = codebehind tarafında ulaşılacak ismi belirtir -->
                <!-- r u n a t = s e r v e r kontrole code behind kısmından erişilmesini sağlar -->
                <div class="row">
                    <label>Kullanıcı Adı</label><br />
                    <br />
                    <asp:TextBox ID="tb_kullanici" runat="server" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Şifre</label><br />
                    <br />
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:LinkButton ID="lbtn_giris" runat="server" CssClass="girisButon" OnClick="lbtn_giris_Click">Giriş Yap</asp:LinkButton>
                </div>
            </div>
            <%-- Float Kullanıldıktan sonra oluşan hizalama hatalarını düzeltir --%>
            <div style="clear: both"></div>

        </div>
    </form>
</body>
</html>
