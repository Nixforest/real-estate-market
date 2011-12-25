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
    <%--Tin rao bán--%>
    <ul>
        <li>
            <asp:HyperLink ID="RegistrationLink" runat="server" NavigateUrl="~/Member/NewsSaleRegistration.aspx"
                Text="Đăng tài sản mới" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="ListNewsSaleLink" runat="server" NavigateUrl="~/Admin/NewsSale/ListNewsSales.aspx"
                Text="Quản lý tin rao bán" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <%--Dự án--%>
    <ul>
        <li>
            <asp:HyperLink ID="NewProjectLink" runat="server" NavigateUrl="~/Admin/Project/NewProject.aspx"
                Text="Đăng dự án mới" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
    <ul>
        <li>
            <asp:HyperLink ID="ListProjectLink" runat="server" NavigateUrl=""
                Text="Quản lý dự án" CssClass="linktype"></asp:HyperLink>
        </li>
    </ul>
</div>