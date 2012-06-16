<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectBoxControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.ProjectBoxControl" %>
<style type="text/css">
.listProject
{
    width:710px;
    float:left;
    margin: 0 0 5px 0;
    margin-left: 2px;
    overflow: hidden;
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
.proHomeT {
    width: 290px;
    height: 25px;
    padding: 6px 0 0 10px;
    background: url(../images/bgd_proHomeT.gif) no-repeat left bottom;
    font: 12px Arial;
    color: white;
    font-weight: bold;
    text-transform: uppercase;
}
.tsmC {
    float: left;
    width: 708px;
    margin-left: 10px;
    overflow: hidden;
}
.tsmCtit {
    width: 710px;
    height: 25px;
    overflow: hidden;
}
.tsmCtit .tsmCtit1 {
    float: left;
    width: 8px;
    height: 25px;
    background: url(../../Image/bgd_bdL.gif) no-repeat 0 0;
}
.tsmCtit .tsmCtit2 {
    float: left;
    width: 694px;
    height: 19px;
    padding-top: 6px;
    background: url(../../Image/bgd_bdC.gif) repeat-x 0 0;
    font: 11px Arial;
    color: white;
    font-weight: bold;
    text-transform: uppercase;
}
.tsmCtit .tsmCtit3 {
    float: right;
    width: 8px;
    height: 25px;
    background: url(../../Image/bgd_bdR.gif) no-repeat 0 0;
}
.listProject .tsmCcon {
    width: 708px;
    border-bottom: 1px solid #41A0CC;
    border-left: 1px solid #41A0CC;
    border-right: 1px solid #41A0CC;
}
</style>
<div id="listProject" class="listProject">
    <div class="tsmCtit">
        <div class="tsmCtit1"></div>
        <div class="tsmCtit2">
            Thông tin dự án
        </div>
        <div class="tsmCtit3"></div>
    </div>
    <div class="tsmCcon">
        <table>
            <tr>
                <td>
        <asp:DataList ID="ProjectsDataList" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BorderStyle="Solid" BorderWidth="1px" >
            <ItemTemplate>
                <table id="Table1" runat="server">
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
                                <%# RealEstateMarket.Utility.GetSummary(Eval("Summary").ToString(), 80)%>
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
</div>