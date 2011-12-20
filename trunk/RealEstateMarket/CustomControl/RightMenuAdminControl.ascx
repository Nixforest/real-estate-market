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
            <asp:HyperLink ID="NewsTypeLink" runat="server" NavigateUrl="~/Admin/News/NewsType.aspx"
                Text="Tỉnh / Thành phố" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="AddNewsLink" runat="server" NavigateUrl="~/Admin/News/AddNews.aspx"
                Text="Thêm tin tức mới" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="DistrictLink" runat="server" NavigateUrl="~/Admin/Dashboard/DistrictAdmin.aspx"
                Text="Quận / Huyện" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="WardLink" runat="server" NavigateUrl="~/Admin/Dashboard/WardAdmin.aspx"
                Text="Phường / Xã" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="StreetLink" runat="server" NavigateUrl="~/Admin/Dashboard/StreetAdmin.aspx"
                Text="Đường phố" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="RealEstateTypeLink" runat="server" NavigateUrl="~/Admin/Dashboard/RealEstateTypeAdmin.aspx"
                Text="Loại Địa Ốc" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="UserLink" runat="server" NavigateUrl="~/Admin/Users/UsersManager.aspx"
                Text="Quản lý người dùng" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
</div>