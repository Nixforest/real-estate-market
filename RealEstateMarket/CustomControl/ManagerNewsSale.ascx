<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerNewsSale.ascx.cs" Inherits="RealEstateMarket.CustomControl.ManagerNewsSale" %>
<asp:HyperLink ID="NewsSaleLink" runat="server">
    <asp:Image ID="NewsImage" ImageUrl="../Image/Admin/news.gif" runat="server" />Tin rao bán</asp:HyperLink>
<ul>
    <li>
        <asp:HyperLink ID="AddNewsLink" NavigateUrl="~/Member/NewsSaleRegistration.aspx" runat="server">
            <asp:Image ID="AddImage" ImageUrl="../Image/Admin/add.gif" runat="server" />Đăng tài sản</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink ID="ListNewsLink" NavigateUrl="~/Admin/NewsSale/ListNewsSales.aspx" runat="server">
            <asp:Image ID="ListNewsImage" ImageUrl="../Image/Admin/list.gif" runat="server" />Quản Lý tin rao bán</asp:HyperLink>
    </li>
</ul>
