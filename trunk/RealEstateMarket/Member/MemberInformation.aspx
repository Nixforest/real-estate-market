<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberInformation.aspx.cs" Inherits="RealEstateMarket.Member.MemberInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:HyperLink ID="registration" runat="server" NavigateUrl="~/Member/NewsSaleRegistration.aspx">Đăng tài sản mới</asp:HyperLink>
    
    <br />
    <asp:HyperLink ID="HyperLink7" runat="server" 
        NavigateUrl="~/Admin/Project/NewProject.aspx">Đăng dự án</asp:HyperLink>
</asp:Content>
