<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RightMenuAdminControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.RightMenuAdminControl" %>
<style type="text/css">
    #left ul{
        list-style-type:none;
        padding:0px;
        margin:0px;
    }
    #left ul .linktype{
        text-decoration:none;
        color:white;
        background:#3A4F63 url(../../Image/icon_news.gif) no-repeat 5px 11px;
        display:block;
        width:95%;
        line-height:25px;
        padding-left:10px;
    }

    #left ul .linktype:hover{
        background: #BFCBD6 url(../../Image/icon_news.gif) no-repeat 5px 11px;
        color:#3A4F63;
    }
</style>
<div id="left">
    <ul>
        <li>
            <asp:HyperLink ID="AddNewsLink" runat="server" NavigateUrl="~/Admin/News/AddNews.aspx"
                Text="Thêm tin tức mới" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="ListNewsLink" runat="server" NavigateUrl="~/Admin/News/ListNews.aspx"
                Text="Danh sách tin tức" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="NewsTypeLink" runat="server" NavigateUrl="~/Admin/News/NewsType.aspx"
                Text="Quản lý Loại tin tức" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
</div>