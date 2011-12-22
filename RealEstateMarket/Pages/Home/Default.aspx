<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Master/Home.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.cs" Inherits="RealEstateMarket._Default" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>
<%@ Register TagPrefix="SearchControl" TagName="RealEstate" Src="~/CustomControl/SearchRealEstateControl.ascx" %>
<%@ Register TagPrefix="TopNewsControl" TagName="TopNews" Src="~/CustomControl/TopNewsControl.ascx" %>
<%@ Register TagPrefix="NewsSaleBoxControl" TagName="NewsSaleBox" Src="~/CustomControl/RealEstateBoxControl.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td><TopNewsControl:TopNews ID="TopNews" runat="server"></TopNewsControl:TopNews></td>
            <td><SearchControl:RealEstate id="search" runat="server"></SearchControl:RealEstate></td>
        </tr>
    </table>
    <NewsSaleBoxControl:NewsSaleBox ID="NewsSaleBox" runat="server" />
</asp:Content>
