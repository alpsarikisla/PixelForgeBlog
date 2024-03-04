<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanel.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="PixelForgeWebApp.AdminPanel.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/FormStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formSayfabaslik">
        <h2>Kategori Listesi</h2>
    </div>
    <div class="formTasiyici">
        <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellspacing="0">
                    <tr>
                        <th>ID</th>
                        <th>Isim</th>
                        <th>Durum</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <%-- Eval Koleksiyon içerisindeki nesnelerin içinden veri almaya yarar --%>
                    <td> <%# Eval("ID") %> </td>
                    <td> <%# Eval("Isim") %> </td>
                    <td> <%# Eval("Durum") %> </td>
                    <td>
                        <%-- CommandArgument= Butona basıldığında hangi butona basıldıysa ait olduğu verinin ID bilgisini getirsin --%>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="secenekbuton sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        <a href='KategoriDuzenle.aspx?kategoriID=<%#Eval("ID") %>' class="secenekbuton duzenle">Düzenle</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
