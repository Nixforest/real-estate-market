<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Master/Home.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.cs" Inherits="RealEstateMarket._Default" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>
<%@ Register TagPrefix="SearchControl" TagName="RealEstate" Src="~/CustomControl/SearchRealEstateControl.ascx" %>
<%@ Register TagPrefix="TopNewsControl" TagName="TopNews" Src="~/CustomControl/TopNewsControl.ascx" %>
<%@ Register TagPrefix="NewsSaleBoxControl" TagName="NewsSaleBox" Src="~/CustomControl/RealEstateBoxControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="project" Src="~/CustomControl/ProjectBoxControl.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td><TopNewsControl:TopNews ID="TopNews" runat="server"></TopNewsControl:TopNews></td>
            <td><SearchControl:RealEstate id="search" runat="server"></SearchControl:RealEstate></td>
        </tr>
        <tr>
            <td colspan="2"><NewsSaleBoxControl:NewsSaleBox ID="NewsSaleBox" runat="server" /></td>
        </tr>
    </table>
    
    <uc:project ID="dfsdf" runat="server" NumberRecord="10" />
</asp:Content>
