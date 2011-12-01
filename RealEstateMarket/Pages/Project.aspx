<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="RealEstateMarket.Pages.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="ProjectObjectDataSource" runat="server" SelectMethod="GetProject" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
        <SelectParameters>
            <asp:ControlParameter ControlID="ProjectDropDownList" Name="id" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProjectsObjectDataSource" runat="server" 
        SelectMethod="GetAllProjects" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:DropDownList ID="ProjectDropDownList" runat="server" DataSourceID="ProjectsObjectDataSource"
        DataTextField="Name" AutoPostBack="true"
        DataValueField="ID" 
        onselectedindexchanged="ProjectDropDownList_SelectedIndexChanged"></asp:DropDownList>
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
