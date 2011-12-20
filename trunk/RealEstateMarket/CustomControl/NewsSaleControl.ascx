<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsSaleControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.NewsSaleControl" %>
    <asp:Panel ID="mainPanel" runat="server" BorderStyle="Groove">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                        <asp:HyperLink ID="ItemHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/NewsSale.aspx?id={0}", 1) %>'>
                            <asp:Image ID="ItemImage" runat="server"
                                Width="104px" ImageUrl='<%# RealEstateMarket._Default.db.GetImagesByRealEstateID(RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).RealEstateID)[0].Path %>'
                                Height="124px" />
                        </asp:HyperLink>
                </asp:TableCell>
                <asp:TableCell>
                        <p>
                            <asp:HyperLink ID="TitleHyperLink" runat="server" NavigateUrl='<%# String.Format("~/Pages/NewsSale.aspx?id={0}",ID) %>'>
                                <%--<asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>'></asp:Label>--%>
                            </asp:HyperLink><br />
                            <asp:Label ID="UpdateTimeLabel" runat="server" Font-Size="Smaller">
                                <%--<%# String.Format("Cập nhật lúc {0}", Eval("UpdateTime")) %>--%>
                            </asp:Label><br />
                            <b>Vị trí:</b>
                            <asp:Label ID="AddressLabel" runat="server">
                                <%# RealEstateMarket.Pages.Project.GetAddressString(RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).REAL_ESTATE.AddressID) %>
                            </asp:Label><br />
                            <b>Cấu trúc:</b>
                            <b>DTKV:</b>
                            <asp:Label ID="CampusAreaLabel" runat="server">
                                <%# String.Format("{0}m X {1}m",
                                (RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).REAL_ESTATE.CampusFront != null) ? RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).REAL_ESTATE.CampusFront : 0,
                                (RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).REAL_ESTATE.CampusLength != null) ? RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).REAL_ESTATE.CampusLength : 0)%>
                            </asp:Label>
                            - <b>DTSD</b>
                            <asp:Label ID="TotalUseAreaLabel" runat="server">
                                <%# String.Format("{0} m<sup>2</sup>",
                                (RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).REAL_ESTATE.TotalUseArea != null) ? RealEstateMarket._Default.db.GetNewsSale(NewsSaleID).REAL_ESTATE.TotalUseArea : 0)%>
                            </asp:Label>
                            <br />
                           <%-- <asp:Label ID="StructureLabel" runat="server">
                                <%# String.Format("{0} phòng khách, {1} phòng ngủ, {2} phòng tắm/WC và {3} tầng", 
                                (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.LivingRoom != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.LivingRoom:0,
                                (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BedRoom != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BedRoom:0,
                                (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BathRoom != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.BathRoom:0,
                                (RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.Storey != null)?RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.Storey:0) %>
                            </asp:Label>--%>
                        </p>
                </asp:TableCell>
                <asp:TableCell>
                        <asp:UpdatePanel ID="PriceUpdatePanel" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="VNDButton" runat="server"/>
                                <asp:Button ID="SJCButton" runat="server"/>
                                <asp:Button ID="USDButton" runat="server"/>
                                <br />
                                <button type="button" onclick="displayPriceVND()">Display Price</button>
                                <p id="price">Price</p>
                                <%--<asp:Label ID="PriceLabel" runat="server">
                                    <%# RealEstateMarket.Utility.ConvertPriceText(Convert.ToDouble(RealEstateMarket._Default.db.GetNewsSale(Convert.ToInt32(Eval("ID"))).REAL_ESTATE.Price)) %>                                        
                                </asp:Label>--%>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="VNDButton" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="SJCButton" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="USDButton" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <%--<asp:Image ID="NewsSaleTypeImage" runat="server"
                            ImageUrl='<%# (Convert.ToInt32(Eval("TypeID")) == 1)? (String.Format("~/Image/ico_canban1.gif")):(
                            (Convert.ToInt32(Eval("TypeID")) == 2)?(String.Format("~/Image/ico_canmua1.gif")):(String.Format("~/Image/ico_chothue1.gif"))) %>' 
                            ToolTip='<%# RealEstateMarket._Default.db.GetNewsSaleType(Convert.ToInt32(Eval("TypeID"))).Name %>'/>--%>
                            |
                        <asp:Image ID="SaveNewsSale" runat="server" ImageUrl="~/Image/ico_59.gif" />
                        Lưu tin
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>