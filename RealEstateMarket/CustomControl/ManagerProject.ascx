<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerProject.ascx.cs" Inherits="RealEstateMarket.CustomControl.ManagerProject" %>
<asp:HyperLink ID="ProjectLink" runat="server">
    <asp:Image ID="NewsImage" ImageUrl="../Image/Admin/news.gif" runat="server" />Dự án</asp:HyperLink>
<ul>
    <li>
        <asp:HyperLink ID="AddProjectLink" NavigateUrl="~/Admin/Project/NewProject.aspx" runat="server">
            <asp:Image ID="AddImage" ImageUrl="../Image/Admin/add.gif" runat="server" />Đăng dự án</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink ID="ListNewsLink" NavigateUrl="~/Admin/Project/ListProjects.aspx" runat="server">
            <asp:Image ID="ListNewsImage" ImageUrl="../Image/Admin/list.gif" runat="server" />Quản lý dự án</asp:HyperLink>
    </li>
</ul>