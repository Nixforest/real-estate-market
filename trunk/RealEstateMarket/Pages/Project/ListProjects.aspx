<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Project.Master" AutoEventWireup="true" CodeBehind="ListProjects.aspx.cs" Inherits="RealEstateMarket.Pages.Project.ListProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
.listProject
{
    width:708px;
    float:left;    
}
.listProjectimage
{
    border-bottom:1px dashed blue;
    float:left;
    height:70px;
    }
.listProjectimage img
{
    width:52px;
    height:52px;
    border:1px solid gray;
    padding:3px;
    }
.listProjectcontent
{
    border-bottom:1px dashed blue;
    float:left;
    width:280px;
    height:70px;
    }   

.listProjectcontent a span
{
    color:#0086C5;
    text-decoration:none;    
    font-weight:900;
}   
.listProjectcontent a:hover
{
    text-decoration:underline;
}
.listProjectcontent span
{
    color:black;
}   

</style>
<div id="listProject" class="listProject">
    <table>
        <tr>
            <td>
    <asp:DataList ID="ProjectsDataList" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BorderStyle="Solid" BorderWidth="1px" >
        <ItemTemplate>
            <table runat="server">
                <tr>
                    <td class="listProjectimage">
                        <asp:HyperLink ID="ItemHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/Project/Project.aspx?id={0}",Eval("ID")) %>'>
                            <asp:Image ID="ItemImage" runat="server"
                                ImageUrl='<%# RealEstateMarket._Default.db.GetImage(Convert.ToInt32(Eval("ImageID"))).Path %>'/>
                        </asp:HyperLink>
                    </td>
                    <td class="listProjectcontent">
                        <asp:HyperLink ID="NameHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/Project/Project.aspx?id={0}",Eval("ID")) %>'>
                            <asp:Label ID="NameLabel" runat="server">
                                <%# String.Format("{0}", (Eval("Name").ToString().Length >= 50) ? (Eval("Name").ToString().Substring(0, 50) + "...") : (Eval("Name")))%>
                            </asp:Label>
                        </asp:HyperLink><br />
                        <asp:Label ID="SummaryLabel" runat="server">
                            <%# RealEstateMarket.Utility.GetSummary(Eval("Summary").ToString(), 100)%>
                        </asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
            </td>
        </tr>
    </table>
</div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
