<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PixelForgeWebApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_makaleler" runat="server">
        <ItemTemplate>
            <div class="article">
                <div class="title">
                    <h2><%# Eval("Baslik") %></h2>
                </div>
                <img src='MakaleResimleri/<%# Eval("KapakResim") %>' />
                <div class="infocontainer">
                    Kategori : <%# Eval("Kategori") %> | Yazar : <%# Eval("Yazar") %> | Görüntüleme : <%# Eval("GoruntulemeSayi") %> | Beğeni Sayı: <%# Eval("BegeniSayi") %>
                </div>
                <div style="margin-top:10px">
                    <%# Eval("Ozet") %>
                    <br /> <br />
                    <a href="#">Makalenin Devamı...</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
