<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="RealEstateMarket.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="nationGridView" runat="server" AutoGenerateColumns="true">
    </asp:GridView>
    <asp:Label ID="lblName" runat="server" Text="Nation's name:"></asp:Label>
    <asp:TextBox ID="textboxName" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="lblNationCode" runat="server" Text="Nation Code:"></asp:Label>
    <asp:TextBox ID="textboxNationCode" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Insert" runat="server" Text="Update" onclick="Insert_Click" />
    <asp:Label ID="error" runat="server" Text="Label"></asp:Label>
</asp:Content>


