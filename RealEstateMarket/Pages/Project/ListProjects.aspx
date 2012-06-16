<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Project.Master" AutoEventWireup="true" CodeBehind="ListProjects.aspx.cs" Inherits="RealEstateMarket.Pages.Project.ListProjects" %>
<%@ Register TagPrefix="uc" TagName="project" Src="~/CustomControl/ProjectBoxControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="search" Src="~/CustomControl/FilterNewsSale.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
.blockProject {
    width: 300px;
    margin: 0 0 5px 0;
}
</style>
    <uc:project ID="dfsdf" runat="server" NumberRecord="26" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContent" runat="server">
    <uc:search ID="filter" runat="server" />
</asp:Content>
