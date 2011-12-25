<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RealEstateBoxControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.RealEstateBoxControl" %>
<style type="text/css">
.box_taisan
{
    width:708px;
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
</style>
<div id="box_taisan" class="box_taisan">
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