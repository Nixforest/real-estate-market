<%@ Page Title="" Language="C#" MasterPageFile="~/Master/News.Master" AutoEventWireup="true" CodeBehind="AllNews.aspx.cs" Inherits="RealEstateMarket.Admin.News.News" %>
<%@ Register TagPrefix="News" TagName="MoreNews" Src="~/CustomControl/MoreNewsPageAll.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ListNewsDataSource">
        <ItemTemplate>
            <asp:Image ID="Image" runat="server"  CssClass="listimage" 
                Width="130px" Height="100px"
                ImageUrl='<%# getImageUrl(Eval("ImageID")) %>' ImageAlign="Left" />
            <asp:HyperLink ID="TitleLink" runat="server" 
                 NavigateUrl='<%# String.Format("~/Pages/News/ReadNews.aspx?id={0}&cid={1}", Eval("ID"), Eval("TypeID")) %>' 
                Text='<%# Eval("Title") %>' Font-Bold="True" Font-Size="Medium"></asp:HyperLink>
            <br />
            <asp:Image ID="DateImage" ImageUrl="../../Image/Admin/date.gif" runat="server" />
            <asp:Label ID="DateLabel" runat="server" 
                Text='<%# Eval("PublishTime", "{0:g}") %>'></asp:Label>
            <br />
            <asp:Label ID="DescriptLabel" runat="server" Text='<%# Eval("Descript") %>'></asp:Label>
            <br />
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="ListNewsDataSource" runat="server" 
        SelectMethod="GetAllNewsCheck" 
        
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="from" Type="Int32" />
            <asp:Parameter DefaultValue="10" Name="number" Type="Int32" />
            <asp:Parameter DefaultValue="True" Name="check" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <News:MoreNews ID="MoreNewsAll" runat="server"></News:MoreNews>
</asp:Content>
