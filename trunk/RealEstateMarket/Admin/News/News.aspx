<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNews.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="RealEstateMarket.Admin.News.News1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 40%;
        }
        .style2 .style3
        {
            width: 15%;
        }
        .style2 .style4
        {
            width: 15%;
        }
        .style2 .style5
        {
            width: 15%;
        }
        .style2 .style6
        {
            width: 15%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ListNewsDataSource">
        
        <HeaderTemplate>
            <table class="style1" border="1">
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label1" runat="server" Text="Tiêu Đề"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label2" runat="server" Text="Tác Giả"></asp:Label>
                    </td>
                    <td class="style4">
                        <asp:Label ID="Label3" runat="server" Text="Chuyển Mục"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:Label ID="Label4" runat="server" Text="Ngày Sửa"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:Label ID="Label5" runat="server" Text="Quản Lý"></asp:Label>
                    </td>
                </tr>
            </table>
        </HeaderTemplate>
        
        <ItemTemplate>
        <asp:HyperLink ID="TitleLink" runat="server" 
                NavigateUrl='<%# "EditNews.aspx?id="+Eval("ID") %>' Text='<%# Eval("Title") %>'></asp:HyperLink>
            <asp:Label ID="AuthorLabel" runat="server" Text='<%# Eval("Author") %>'></asp:Label>
            <asp:Label ID="NewsTypeLabel" runat="server" Text='<%# getNewsType(Eval("TypeID")) %>'></asp:Label>
            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("PublishTime", "{0:G}") %>'></asp:Label>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "EditNews.aspx?id="+Eval("ID") %>'>
                <asp:Image ID="EditImage" ImageUrl="../../Image/Admin/edit.gif" runat="server" />
            </asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "DelNews.aspx?id="+Eval("ID") %>'>
                <asp:Image ID="DelImage" ImageUrl="../../Image/Admin/delete.gif" runat="server" OnClick="if(!window.confirm('Bạn có chắc chắn muốn xóa tin này không ?')) return false;" />
            </asp:HyperLink>
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ListNewsDataSource" runat="server" 
        SelectMethod="GetAllNews" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
