<%@ Page Title="" Language="C#" MasterPageFile="~/Master/News.Master" AutoEventWireup="true" CodeBehind="ReadNews.aspx.cs" Inherits="RealEstateMarket.Admin.News.ReadNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="News" TagName="MoreNews" Src="~/CustomControl/MoreNewsPageRead.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .newstitle
    {
        font:18px tahoma;
        font-weight:900;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataList1" runat="server" 
    DataSourceID="ReadNewsDataSource">
        <ItemTemplate>
            <table>
                <tr>
                    <td class="newstitle">
                        <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="DateImage" ImageUrl="../../Image/Admin/date.gif" runat="server" />
                        <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("EditTime") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="DescriptLabel" runat="server" Text='<%# Eval("Descript") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="ContentLabel" runat="server" Text='<%# Eval("Content") %>'></asp:Label>
                        <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>'></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
<asp:ObjectDataSource ID="ReadNewsDataSource" runat="server" 
    SelectMethod="GetNews" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    <SelectParameters>
        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<News:MoreNews ID="MoreNewsRead" runat="server"></News:MoreNews>
</asp:Content>
