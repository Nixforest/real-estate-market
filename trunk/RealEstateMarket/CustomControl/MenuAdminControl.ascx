<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdminControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.MenuAdminControl" %>
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
            <asp:HyperLink ID="NationLink" runat="server" NavigateUrl="~/Admin/Dashboard/NationAdmin.aspx"
                Text="Quốc gia" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="CityLink" runat="server" NavigateUrl="~/Admin/Dashboard/CityAdmin.aspx"
                Text="Tỉnh / Thành phố" CssClass="linktype"></asp:HyperLink>
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