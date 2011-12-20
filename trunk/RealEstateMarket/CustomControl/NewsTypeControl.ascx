<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsTypeControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.NewsType" %>
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
<asp:DataList ID="DataList1" runat="server" DataSourceID="NewsTypeDataSource">
    <ItemTemplate>
        <div id="left">
        <ul>
            <li>
                <asp:HyperLink ID="NameLink" runat="server" NavigateUrl='<%# "~/Pages/News/ListNews.aspx?id="+Eval("ID") %>' 
                    Text='<%# Eval("Name") %>' CssClass="linktype"></asp:HyperLink>
            </li>
        </ul>
        </div>
    </ItemTemplate>
</asp:DataList>
<asp:ObjectDataSource ID="NewsTypeDataSource" runat="server" 
    SelectMethod="GetAllNewsTypes" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
</asp:ObjectDataSource>
