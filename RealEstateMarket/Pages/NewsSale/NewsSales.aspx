<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NewsSale.Master" AutoEventWireup="true" CodeBehind="NewsSales.aspx.cs" Inherits="RealEstateMarket.Pages.NewsSales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function displayPriceVND(ID, price) {
            document.getElementById("price" + ID).innerHTML = ConvertPriceTextVND(price);            
        }
        function ConvertPriceTextVND(price) {
        
            var priceBillion = parseInt(price / 1000000000.0);
            var priceMillion = parseInt((price % 1000000000) / 1000000.0);
            var priceThousand = parseInt(((price % 1000000000) % 1000000) / 1000.0);
            //int priceDong     = Int32.Parse((((price % 1000000000) % 1000000) % 1000.0).ToString());
            var strTextPrice = "";
            if (price == 0) {
                return "Thương lượng";
            }
            if (priceBillion > 0 && price > 900000000) {
                strTextPrice = strTextPrice + "<b>" + priceBillion + "</b> tỷ ";
            }
            if (priceMillion > 0) {
                strTextPrice = strTextPrice + "<b>" + priceMillion + "</b> triệu ";
            }
            if (priceThousand > 0) {
                strTextPrice = strTextPrice + "<b>" + priceThousand + "</b> ngàn ";
            }

            return strTextPrice + " đồng";
        }
        function displayPriceSJC(ID, price) {
            document.getElementById("price" + ID).innerHTML = ConvertPriceTextSJC(price);
        }
        function ConvertPriceTextSJC(price) {
            if (price == 0) {
                return "Thương lượng";
            }
            return "<b>" + chuanHoaGia(price) + "</b> lượng";
        }
        function displayPriceUSD(ID, price){
            document.getElementById("price" + ID).innerHTML = ConvertPriceTextUSD(price);
        }
        function chuanHoaGia(price) {
            var pos = price.toString().indexOf(".");
            var nguyen = "";
            var thapphan = "0";
            if (pos != -1) {
                nguyen = price.toString().substring(0, pos);
                thapphan = price.toString().substr(pos + 1, 2);
            } else {
                nguyen = price;
            }
            var donvi = "";
            var ngan = "";
            var trieu = "";
            var ty = "";
            var strPrice = "";
            if (nguyen.toString().length > 3) {
                if (nguyen.toString().length > 6) {
                    if (nguyen.toString().length > 9) {
                        ty = nguyen.toString().substring(0, nguyen.toString().length - 9);
                        trieu = nguyen.toString().substr(nguyen.toString().length - 9, 3);
                        strPrice += ty + ",";
                    } else {
                        trieu = nguyen.toString().substr(0, nguyen.toString().length - 6);
                    }
                    strPrice += trieu + ",";
                    ngan = nguyen.substr(nguyen.toString().length - 6, 3);
                } else {
                    ngan = nguyen.toString().substr(0, nguyen.toString().length - 3);
                }
                strPrice += ngan + ",";
                donvi = nguyen.toString().substr(nguyen.toString().length - 3, 3);
            } else {
                donvi = nguyen;
            }
            strPrice += donvi + ".";
//            if (nguyen.toString().length > 9) {
//                ty = nguyen.substr(nguyen.toString().length - 9, 3);
//                strPrice += ty + ",";
//            } else if (nguyen.toString().length > 6) {
//                trieu = nguyen.substr(nguyen.toString().length - 6, 3);
//                strPrice += trieu + ",";
//            } else if (nguyen.toString().length > 3) {
//                ngan = nguyen.substr(nguyen.toString().length - 3, 3);
//                strPrice += ngan + ",";
//            } else {
//                strPrice += nguyen + ".";
//            }
            return strPrice + thapphan;
        }
        function ConvertPriceTextUSD(price) {
            if (price == 0) {
                return "Thương lượng";
            }
            return "<b>" + chuanHoaGia(price) + "</b> USD";
        }
        function getPriceVND(price, unit) {
            if (unit == 2) {
                return price * (vGoldSjcBuy.replace(",", ".") * 1000000);
            }
            if (unit == 3) {
                return price * (vCosts[0] * 1000);
            }
            return price;
        }

        function getPriceSJC(price, unit) {
            if (unit == 1) {
                return price / (vGoldSjcBuy.replace(",", ".") * 1000000);
            }
            if(unit == 3) {
                return price * (vCosts[0] * 1000) / (vGoldSjcBuy.replace(",", ".") * 1000000);
            }
            return price;
        }

        function getPriceUSD(price, unit) {
            if (unit == 1) {
                return price / (vCosts[0] * 1000);
            }
            if (unit == 2) {
                return price * (vGoldSjcBuy.replace(",", ".") * 1000000) / (vCosts[0] * 1000);
            }
            return price;
        }
    </script>
<style type="text/css">
.listNewsSale
{
    width:628px;
}
.newssaleimage
{
    float:left;
    height:130px;
    padding:3px;
    border-bottom:1px solid gray;   
}
.newssaleimage img
{
    width:104px;
    height:124px;
    border:1px solid gray;
    padding:3px;
    }
.newssalecontent
{
    float:left;
    width:350px;
    padding:3px;
    height:130px;
    border-bottom:1px solid gray; 
}
.newssaleprice
{
    float:left;
    width:150px;
    padding:3px;
    height:130px;
    border-bottom:1px solid gray; 
}
.newssaleitem
{
    margin-bottom:20px;
}
</style>
    <asp:ObjectDataSource ID="NewsSaleObjectDataSource" runat="server"
        SelectMethod="GetAllNewsSales"        
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
        </asp:ObjectDataSource>
    <div class="total">
        <asp:Label ID="TotalLabel" runat="server"></asp:Label>
    </div>
    <asp:Panel ID="NoteLabel" Visible="false" runat="server" BorderStyle="Groove" HorizontalAlign="Center">
        Hệ thống chúng tôi không tìm thấy tài sản bạn muốn tìm
    </asp:Panel>
<div id="listNewsSale">
    <asp:DataList ID="NewsSaleDataList" runat="server" BorderStyle="Solid" BorderWidth="1px">
        <ItemTemplate>
            <table>
                <tr class="newssaleitem">
                    <td class="newssaleimage">
                            <asp:HyperLink ID="ItemHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/NewsSale/NewsSale.aspx?id={0}",Eval("ID")) %>'>
                                <asp:Image ID="ItemImage" runat="server"
                                    ImageUrl='<%# RealEstateMarket._Default.db.GetImagesByRealEstateID(RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).RealEstateID)[0].Path %>'/>
                            </asp:HyperLink>
                    </td>
                    <td class="newssalecontent">
                                <asp:HyperLink ID="TitleHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/NewsSale/NewsSale.aspx?id={0}",Eval("ID")) %>'>
                                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                </asp:HyperLink><br />
                                <asp:Label ID="UpdateTimeLabel" runat="server" Font-Size="Smaller">
                                    <%# String.Format("Cập nhật lúc {0}", Eval("UpdateTime")) %>
                                </asp:Label><br />
                                <b>Vị trí:</b>
                                <asp:Label ID="AddressLabel" runat="server">
                                    <%# RealEstateMarket.Pages.Project.Project.GetAddressString(RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.AddressID) %>
                                </asp:Label><br />
                                <b>Cấu trúc:</b>
                                <b>DTKV:</b>
                                <asp:Label ID="CampusAreaLabel" runat="server">
                                    <%# String.Format("{0}m X {1}m", 
                                    (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.CampusFront != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.CampusFront:0,
                                    (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.CampusLength != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.CampusLength:0) %>
                                </asp:Label>
                                - <b>DTSD</b>
                                <asp:Label ID="TotalUseAreaLabel" runat="server">
                                    <%# String.Format("{0} m<sup>2</sup>",
                                    (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.TotalUseArea != null) ? RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.TotalUseArea : 0)%>
                                </asp:Label>
                                <br />
                                <asp:Label ID="StructureLabel" runat="server">
                                    <%# String.Format("{0} phòng khách, {1} phòng ngủ, {2} phòng tắm/WC và {3} tầng",
                                    (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.LivingRoom != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.LivingRoom:0,
                                    (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BedRoom != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BedRoom:0,
                                    (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BathRoom != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BathRoom:0,
                                    (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.Storey != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.Storey:0) %>
                                </asp:Label>
                                <br />
                                <asp:Label ID="BrokerLabel" runat="server" Font-Italic="true">
                                    <%# String.Format("{0}", (Convert.ToBoolean(Eval("Broker")) == true)?("Môi giới"):("Miễn trung gian/QC khác")) %>
                                </asp:Label>
                    </td>
                    <td class="newssaleprice">
                            <asp:UpdatePanel ID="PriceUpdatePanel" runat="server">
                                <ContentTemplate>
                                    <button type="button" onclick='displayPriceVND(<%# Eval("ID") %>, getPriceVND(<%# Convert.ToDouble(Eval("REAL_ESTATE.Price"))%>, <%# Eval("REAL_ESTATE.UnitID") %>))'>VND</button>                                        
                                    <button type="button" onclick='displayPriceSJC(<%# Eval("ID") %>, getPriceSJC(<%# Convert.ToDouble(Eval("REAL_ESTATE.Price"))%>, <%# Eval("REAL_ESTATE.UnitID") %>))'>SJC</button>
                                    <button type="button" onclick='displayPriceUSD(<%# Eval("ID") %>, getPriceUSD(<%# Convert.ToDouble(Eval("REAL_ESTATE.Price"))%>, <%# Eval("REAL_ESTATE.UnitID") %>))'>USD</button>
                                    <br />
                                    <p id='<%# String.Format("price"+Eval("ID")) %>'>
                                        <%# RealEstateMarket.Utility.ConvertPriceText(Convert.ToInt32(Eval("ID"))) %>
                                    </p>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <asp:Image ID="NewsSaleTypeImage" runat="server"
                                ImageUrl='<%# (Convert.ToInt32(Eval("TypeID")) == 1)? (String.Format("~/Image/ico_canban1.gif")):(
                                (Convert.ToInt32(Eval("TypeID")) == 2)?(String.Format("~/Image/ico_canmua1.gif")):(
                                (Convert.ToInt32(Eval("TypeID")) == 3)?(String.Format("~/Image/ico_canthue1.gif")):(String.Format("~/Image/ico_chothue1.gif")))) %>' 
                                ToolTip='<%# RealEstateMarket._Default.db.GetNewsSaleType(Convert.ToInt32(Eval("TypeID"))).Name %>'/>
                                |
                            <asp:Image ID="SaveNewsSale" runat="server" ImageUrl="~/Image/ico_59.gif" />
                            Lưu tin
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</div>
    
</asp:Content>
