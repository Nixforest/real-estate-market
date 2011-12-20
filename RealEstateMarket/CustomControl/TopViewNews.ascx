<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopViewNews.ascx.cs" Inherits="RealEstateMarket.CustomControl.TopViewNews" %>
<style type="text/css">
    .textnews
    {
        background:orange;
        text-align:center;
        line-height:30px;
    }
    .textnews a
    {
        color:White;
        font-weight:bold;
        font-size:11px;
        font-family:Arial;
        text-decoration:none;
    }
    .info
    {
        padding:5px 0px 24px;
        border-bottom:1px dotted orange;
    }
    .info a
    {
        text-decoration:none;
        color:black;
    }
    .info a:hover
    {
        text-decoration:underline;
    }
    .info img
    {
        width:50px;
        height:50px;
        border:1px solid gray;
    }
    .cover
    {
        border:1px solid orange;
        padding:1px;
    }
</style>
<div class="cover">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="TopViewDataSource">
        <HeaderTemplate>
            <div class="textnews"><a href="#">TIN NHIỀU NGƯỜI XEM</a></div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="info">
                <asp:HyperLink ID="TopNewsLink1" NavigateUrl='<%# String.Format("~/Pages/News/ReadNews.aspx?id={0}&cid={1}", Eval("ID"), Eval("TypeID")) %>' runat="server">
                    <asp:Image ID="TopNewsImage" ImageUrl='<%# getImageUrl(Eval("ImageID")) %>' ImageAlign="Left" runat="server" />
                    <asp:Label ID="TopNewsLabel" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource ID="TopViewDataSource" runat="server" 
        SelectMethod="GetNewsTopView" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
        <SelectParameters>
            <asp:Parameter DefaultValue="10" Name="number" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>

