<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Project.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="RealEstateMarket.Pages.Project.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="ErrorLabel" runat="server" CssClass="failureNotification"></asp:Label>
    </p>
    <asp:Panel ID="MainPanel" runat="server" BorderStyle="Groove">
        <h4>Tổng quan dự án</h4>
        <asp:Label ID="ProjectNameLabel" runat="server" Text='<%# Eval("Name") %>'
            ForeColor="#FF6900" 
            Font-Size="18px" 
            Font-Names="Arial"></asp:Label><br />
        <asp:Label ID="AddressLabel" runat="server">
            Vị trí: 
        </asp:Label><br />
        <b>Ngày khởi công: </b>
        <asp:Label ID="BeginDayLabel" runat="server" Text='<%# Eval("BeginDay") %>'></asp:Label>
        <asp:Label ID="ContentLabel" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
    </asp:Panel>
</asp:Content>
