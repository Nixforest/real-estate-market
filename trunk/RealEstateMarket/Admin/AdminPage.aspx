<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="RealEstateMarket.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Admin/Dashboard/NationAdmin.aspx">Nation</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/Admin/Dashboard/CityAdmin.aspx">City</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink3" runat="server" 
        NavigateUrl="~/Admin/Dashboard/DistrictAdmin.aspx">District</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink4" runat="server" 
        NavigateUrl="~/Admin/Dashboard/WardAdmin.aspx">Ward</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink5" runat="server" 
        NavigateUrl="~/Admin/Dashboard/StreetAdmin.aspx">Street</asp:HyperLink>
</asp:Content>
