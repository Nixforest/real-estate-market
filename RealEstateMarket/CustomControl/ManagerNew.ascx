<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerNew.ascx.cs" Inherits="RealEstateMarket.CustomControl.ManagerNew" %>
<asp:HyperLink ID="NewsLink" runat="server">
    <asp:Image ID="NewsImage" ImageUrl="../Image/Admin/news.gif" runat="server" />Tin Tức</asp:HyperLink>
<ul>
    <li>
        <asp:HyperLink ID="AddNewsLink" NavigateUrl="~/Admin/News/AddNews.aspx" runat="server">
            <asp:Image ID="AddImage" ImageUrl="../Image/Admin/add.gif" runat="server" />Thêm Tin Tức</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink ID="ListNewsLink" NavigateUrl="~/Admin/News/ListNews.aspx" runat="server">
            <asp:Image ID="ListNewsImage" ImageUrl="../Image/Admin/list.gif" runat="server" />Quản Lý Tin Tức</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink ID="NewsTypeLink" NavigateUrl="~/Admin/News/NewsType.aspx" runat="server">
            <asp:Image ID="NewsTypeImage" ImageUrl="../Image/Admin/category.gif" runat="server" />Quản Lý Chuyên Mục</asp:HyperLink>
    </li>
</ul>