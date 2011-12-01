<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="RealEstateMarket.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" 
        NavigateUrl="~/Admin/Dashboard/NationAdmin.aspx">Quốc gia</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" 
        NavigateUrl="~/Admin/Dashboard/CityAdmin.aspx">Tỉnh / Thành phố</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink3" runat="server" 
        NavigateUrl="~/Admin/Dashboard/DistrictAdmin.aspx">Quận / Huyện</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink4" runat="server" 
        NavigateUrl="~/Admin/Dashboard/WardAdmin.aspx">Phường / Xã</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink5" runat="server" 
        NavigateUrl="~/Admin/Dashboard/StreetAdmin.aspx">Đường Phố</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink6" runat="server" 
        NavigateUrl="~/Admin/Dashboard/RealEstateTypeAdmin.aspx">Loại Địa Ốc</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink7" runat="server" 
        NavigateUrl="~/Admin/Project/NewProject.aspx">Đăng dự án</asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyperLink8" runat="server" 
        NavigateUrl="~/Admin/Users/UsersManager.aspx">Quản lý người dùng</asp:HyperLink>
</asp:Content>
