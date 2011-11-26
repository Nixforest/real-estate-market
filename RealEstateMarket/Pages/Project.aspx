<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="RealEstateMarket.Pages.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="dataSource" runat="server" SelectMethod="GetProject" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlProject" Name="id" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dataSourceProject" runat="server" 
        SelectMethod="GetAllProjects" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:DropDownList ID="ddlProject" runat="server" DataSourceID="dataSourceProject"
        DataTextField="Name" AutoPostBack="true"
        DataValueField="ID" 
        onselectedindexchanged="ddlProject_SelectedIndexChanged"></asp:DropDownList>
    <asp:Panel ID="pnlMain" runat="server" BorderStyle="Groove">
        <h4>Tổng quan dự án</h4>
        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'
            ForeColor="#FF6900" 
            Font-Size="18px" 
            Font-Names="Arial"></asp:Label><br />
        <asp:Label ID="lblAddress" runat="server"></asp:Label><br />
        <b>Ngày khởi công: </b>
        <asp:Label ID="lblBeginDay" runat="server" Text='<%# Bind("BeginDay") %>'></asp:Label>
        <asp:Label ID="lblContent" runat="server" Text='<%# Bind("Content") %>'></asp:Label>
    </asp:Panel>
</asp:Content>
