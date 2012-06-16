<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RealEstateBoxControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.RealEstateBoxControl" %>
<style type="text/css">
.box_taisan
{
    width:710px;
    float:left;
}
.boxtaisan1
{
    border-bottom:1px dashed blue;
    float:left;
    height:70px;
}
.boxtaisan1 img
{
    width:52px;
    height:52px;
    border:1px solid gray;
    padding:3px;    
}
.boxtaisan2
{
    border-bottom:1px dashed blue;
    float:left;
    width:280px;
    height:70px;
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
.box_taisan .tsmCcon {
    width: 708px;
    border-bottom: 1px solid #41A0CC;
    border-left: 1px solid #41A0CC;
    border-right: 1px solid #41A0CC;
}
</style>
<div id="box_taisan" class="box_taisan">
    <div class="tsmCtit">
        <div class="tsmCtit1"></div>
        <div class="tsmCtit2">
            Tài sản mới
        </div>
        <div class="tsmCtit3"></div>
    </div>
    <div class="tsmCcon">
    <table>
        <tr>
            <td>
                <asp:DataList ID="LeftDataList" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BorderStyle="Solid" BorderWidth="1px">
                    <ItemTemplate>
                        <table runat="server">
                                <tr>
                                    <td class="boxtaisan1">
                                        <asp:HyperLink ID="ItemHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/NewsSale/NewsSale.aspx?id={0}",Eval("ID")) %>'>
                                            <asp:Image ID="ItemImage" runat="server"
                                                 ImageUrl='<%# RealEstateMarket._Default.db.GetImagesByRealEstateID(RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).RealEstateID)[0].Path %>'
                                                />
                                        </asp:HyperLink>
                                    </td>
                                    <td class="boxtaisan2">
                                         <asp:HyperLink ID="TitleHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/NewsSale/NewsSale.aspx?id={0}",Eval("ID")) %>'>
                                            <asp:Label ID="TitleLabel" runat="server">
                                                <%# RealEstateMarket.Utility.GetSummary(Eval("Title").ToString(), 80) %>
                                            </asp:Label>
                                        </asp:HyperLink><br />
                                        <asp:HyperLink ID="CityHyperLink" runat="server" 
                                            NavigateUrl='<%# String.Format("~/Pages/NewsSale/NewsSales.aspx?search=1&cityId={0}", Eval("REAL_ESTATE.ADDRESS.CityID")) %>'>
                                            <%# RealEstateMarket._Default.db.GetCity(RealEstateMarket._Default.db.GetAddress(RealEstateMarket._Default.db.GetRealEstate(Convert.ToInt32(Eval("RealEstateID"))).AddressID).CityID).Name%>
                                        </asp:HyperLink>
                                        <asp:Label ID="PriceLabel" runat="server">
                                            - <%# RealEstateMarket.Utility.ConvertPriceText(Convert.ToInt32(Eval("ID"))) %>
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