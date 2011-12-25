<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerCompany.ascx.cs" Inherits="RealEstateMarket.CustomControl.ManagerCompany" %>
<asp:HyperLink ID="CompanyLink" runat="server">
    <asp:Image ID="CompanyImage" ImageUrl="../Image/Admin/news.gif" runat="server" />Doanh nghiệp</asp:HyperLink>
<ul>
    <li>
        <asp:HyperLink ID="AddCompanyLink" NavigateUrl="~/Admin/Company/NewCompany.aspx" runat="server">
            <asp:Image ID="AddImage" ImageUrl="../Image/Admin/add.gif" runat="server" />Đăng doanh nghiệp</asp:HyperLink>
    </li>
    <li>
        <asp:HyperLink ID="ListCompanyLink" NavigateUrl="~/Admin/Company/ListCompanies.aspx" runat="server">
            <asp:Image ID="ListNewsImage" ImageUrl="../Image/Admin/list.gif" runat="server" />Quản lý doanh nghiệp</asp:HyperLink>
    </li>
</ul>