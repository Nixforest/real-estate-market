<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Home.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="RealEstateMarket.Pages.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="ErrorLabel" Text="Đã xảy ra lỗi!" runat="server" CssClass="failureNotification"></asp:Label>
</asp:Content>
