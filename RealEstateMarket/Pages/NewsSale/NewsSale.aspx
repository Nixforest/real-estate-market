<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NewsSale.Master" AutoEventWireup="true" CodeBehind="NewsSale.aspx.cs" Inherits="RealEstateMarket.Pages.NewsSale" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<style type="text/css">
.total
{
    background-color:#DFF5FF;
    padding:5px 10px;
}
.total .title_details h1
{
    font:13px Arial;
    font-weight:bold;
}
#listingDetail
{
    width:622px;
    padding:10px;
    overflow:hidden;
}
#listingDetail .listingInfo
{
    overflow:hidden;
    width:622px;
}
#listingDetail .InfoDetail {
    width: 620px;
    margin-top: 10px;
    border: 1px solid #F2F0F1;
    border-image: initial;
}
.clear
{
    display:block;
    position:relative;
}
.MapInfo .msts .mstsL
{
    float:left;
    width:31;
}
.MapInfo p {
    font: 12px Arial;
    color: black;
    font-weight: bold;
    line-height: 18px;
    margin-bottom: 10px;
}
.MapInfo .msts .mstsR
{
    float:left;
    width:206px;
    height:23px;
    background:url("../../Image/bgd_msts.gif") no-repeat 0 0;
    font: 12px Arial;
    color:White;
    padding-left:5px;
}
.MapInfo .msts .mstsR span
{
    font:18px Arial;
    color:White;
    font-weight:bold;
}
.MapInfo h2
{
    font:12px Arial;
    color:Black;
    font-weight:bold;
    padding:3px0 3px 0;
}

.MapInfo .money
{
    width:242px;
    overflow:hidden;
}
.MapInfo .money .mon1
{
    float:left;
    width:59px;
    height:19px;
    overflow:hidden;
}
.MapInfo .money .mon1 .onL
{
    float:left;
    width:30px;
    height:17px;
    padding:2px 0 0 10px;
    background:url("../../Image/bgd_vnd.gif") no-repeat 0 0;
    font:12px Arial;
    color:#3E9CD2;
    font-weight:bold;
}
.MapInfo .money .mon1 .onR {
    float: right;
    width: 19px;
    height: 19px;
    background:url("../../Image/ico_35.gif") no-repeat 0 0;
}
.MapInfo .money .mon2 {
    float: right;
    width: 178px;
    padding-left: 5px;
    font: 16px Arial;
    color: #FA7003;
    font-weight: bold;
}
.tl {
font: 12px Arial;
color: #3E9CD2;
font-weight: bold;
display: inherit!important;
}
.dt {
    height: 53px;
    width: 222px;
    background: url(../../Image/bg_dt.gif) repeat-x 0 0;
    margin-top: 10px;
    padding: 10px;
}
.dtA span {
    display: block;
    width: 47px;
    height: 25px;
    float: left;
    padding-left: 3px;
    margin-right: 3px;
    cursor: pointer;
    font: 12px Arial;
    color: #333;
}
.dtA .phongkhach {
    background: url(../../Image/dt_phongkhach.gif) no-repeat 23px top;
}

.dtA .phongngu {
    background: url(../../Image/dt_phongngu.gif) no-repeat 23px top;
}
.dtA .phongtam {
    background: url(../../Image/dt_phongtam.gif) no-repeat 23px top;
}
.dtA .phongkhac {
    background: url(../../Image/dt_tivi.gif) no-repeat 23px top;
}
.dt span {
    font: 12px Arial;
    color: #333;
}
.contact {
    width: 230px;
    border: 1px solid #FF9303;
    margin-top: 7px;
    padding: 4px 5px 4px 5px;
    background: #FFF3B6 url(../../Image/contact_bg.gif) repeat-x center bottom;
    border-image: initial;
}
.contactT {
    font: 12px Arial;
    color: #FA7003;
    text-transform: uppercase;
    font-weight: bold;
    margin-bottom: 6px;
}
.contact p {
    font: 12px Arial;
    color: #222;
    line-height: 18px;
}
.InfoDetailTitle {
    width: 618px;
    margin: 1px;
    height: 33px;
    background: url(../../Image/bg_title_detail.gif) repeat-x 0 0;
}
.Info1 {
    float: left;
    font: 18px Arial;
    color: #0086C5;
    font-weight: normal;
    padding: 5px 0 0 3px;
}
.InfoDetail p.space {
    font: 12px Arial;
    color: #333;
    line-height: 18px;
    padding: 7px 4px 7px 4px;
}
.Structure {
    width: 610px;
    margin: 15px 4px 5px 4px;
}
.StructureT {
    font: 12px Arial;
    color: #FD7308;
    font-weight: bold;
    text-transform: uppercase;
    border-bottom: 1px solid #C7E3E7;
    padding-bottom: 5px;
}
.StructureC {
    width: 610px;
    font: 12px Arial;
    color: black;
}
table {
    line-height: 1.4em;
    padding: 0;
    margin: 0;
}
.StructureC .bg1 {
    height: 27px;
    background-color: white;
    padding-left: 7px;
}
.StructureC .bg2 {
    height: 27px;
    background-color: #F6F6F6;
    padding-left: 7px;
}
.StructureC .boderleft {
    border-left: 1px solid #C8E2EA;
}
.StructureC .padding25 {
    padding-left: 25px;
}
.AddThis {
    margin-top: 10px;
    width: 622px;
    overflow: hidden;
}
.AddThisL {
    float: left;
    width: 6px;
    background: url(../../Image/cornerL_addthis.gif) no-repeat 0 0;
    height: 31px;
}
.AddThisC {
    float: left;
    width: 610px;
    background: url(../../Image/cornerC_addthis.gif) repeat-x 0 0;
    height: 31px;
}
.addC2 {
    float: right;
    font: 11px Arial;
    color: black;
    font-weight: bold;
    padding-top: 0px;
    width: 386px;
    padding-left: 145px;
    height:50px;
    position:relative;
}
.AddThisR {
    float: right;
    width: 6px;
    background: url(../../Image/cornerR_addthis.gif) no-repeat 0 0;
    height: 31px;
}
.addC2 ul
{
    position:absolute;
    top:-8px;
    right:7px;
 }
.addC2 li {
    display: inline;
    padding: 0 5px 0 5px;
}
.infoMember {
    width: 622px;
    background: url(../../Image/bgd_bottom.gif) 0 100% no-repeat;
    padding: 0 0 9px 0;
    margin-top: 10px;
}
.infoSub {
    width: 602px;
    background: url(../../Image/bgd_top.gif) 0 0 no-repeat;
    padding: 9px 10px 0 10px;
    overflow: hidden;
}
.infoL {
    float: left;
    width: 420px;
    overflow: hidden;
}
.infoL h2 {
    font: 12px Arial;
    color: #FE7100;
    text-transform: uppercase;
    font-weight: bold;
    margin-bottom: 5px;
}
.infoL p {
    color: black;
    font-weight: normal;
    line-height: 17px;
}
#col4 {
    float: left;
    width: 644px;
}
#box_content_st {
    float: left;
}
#box_content_st .title {
    background: url(../../Image/fill_bg_body.gif) repeat-x;
    height: 25px;
}
#box_content_st .title ul {
    background: url(../../Image/fill_bg_body_l.gif) no-repeat left;
    height: 21px;
    float: left;
    padding-top: 4px;
    padding-left: 15px;
}
#box_content_st .title li {
    height: 21px;
    background: url(../../Image/bg_btn_b_r.gif) no-repeat right;
    float: left;
    margin-right: 3px;
}
#box_content_st .title .selected {
    height: 21px;
    background: url(../../Image/fill_bg_body_r_a.gif) no-repeat right;
    float: left;
}
#box_content_st .title .selected span {
    background: url(../../Image/fill_bg_body_l_a.gif) no-repeat left;
    float: left;
    height: 16px;
    font-size: 11px;
    font-weight: bold;
    color: black;
}
#box_content_st .content {
    border-left: 1px solid #3B9DCA;
    border-right: 1px solid #3B9DCA;
    border-bottom: 1px solid #3B9DCA;
}
.clearfix {
display: block;
}
</style>
    <asp:ObjectDataSource ID="UnitObjectDataSource" runat="server" 
        SelectMethod="GetAllUnits" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

        <div class="total">
            <div class="title_details">
                <h1>
                    <asp:Label ID="TitleLabel" runat="server"></asp:Label>
                </h1>
            </div>
            <div id="listingDetail">
                <div class="listingInfo clearfix">
                <table>
                    <tr>
                        <td>
                            <asp:Image ID="SlideShowImage" runat="server" ImageUrl="~/Image/dt_phongkhach.gif"
                                Height="360px" Width="360px"/>
                        </td>
                        <td>
                            <div class="MapInfo">
                            <table>
                                <tr>
                                    <td>
                                        <div class="msts">
                                            <div class="mstsL">
                                                <asp:Image ID="NewsSaleTypeImage" runat="server" />
                                            </div>
                                            <div class="mstsR">
                                                Mã số tài sản:
                                                <asp:Label ID="RealEstateIDLabel" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <h2>
                                            <asp:Label ID="AddressTitle" runat="server"></asp:Label>
                                        </h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="money">
                                            <div style="width:50px;float:left">
                                                <div class="mon1">
                                                    <asp:Label ID="UnitLabel" CssClass="onL" runat="server"></asp:Label>
                                                    <div class="onR"></div>
                                                </div>                                        
                                            </div>     
                                            <div class="mon2">
                                                <asp:Label ID="PriceLabel" runat="server"></asp:Label>
                                                <asp:Label ID="UnitPriceLabel" runat="server"></asp:Label>
                                            </div>                               
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="tl"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="dt">
                                            <div class="dtA">
                                                <asp:Label ID="LivingRoomLabel" ToolTip="Phòng khách" runat="server" CssClass="phongkhach">-</asp:Label>
                                                <asp:Label ID="BedRoomLabel" ToolTip="Phòng ngủ" runat="server" CssClass="phongngu">-</asp:Label>
                                                <asp:Label ID="BathRoomLabel" runat="server" ToolTip="Phòng tắm/WC" CssClass="phongtam">-</asp:Label>
                                                <asp:Label ID="DifferentRoomLabel" runat="server" ToolTip="Phòng khác" CssClass="phongkhac">-</asp:Label>
                                            </div>
                                            <span>
                                                Diện tích khuôn viên:
                                                <strong>
                                                    <asp:Label ID="CampusFrontLabel" runat="server"></asp:Label>m
                                                    X
                                                    <asp:Label ID="CampustLengthLabel" runat="server"></asp:Label>m
                                                </strong>
                                            </span><br />
                                            <span>
                                                Diện tích sử dụng:
                                                <strong>
                                                    <asp:Label ID="TotalUseAreaLabel" runat="server"></asp:Label>
                                                    m<sup>2</sup>
                                                </strong>
                                            </span>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="contact">
                                            <div class="contactT">
                                                LIÊN HỆ
                                            </div>
                                            <p>
                                                    <asp:Image ID="ContactNameImage" ToolTip="Tên" runat="server" ImageUrl="~/Image/ico_user.gif" />
                                                    <asp:Label ID="ContactNameLabel" runat="server" Font-Bold="true"></asp:Label><br />
                                                    <asp:Image ID="AddressContactImage" ToolTip="Địa chỉ" runat="server" ImageUrl="~/Image/ico_add.gif" />
                                                    <asp:Label ID="AddressContactLabel" runat="server"></asp:Label><br />
                                                    <asp:Image ID="ContactHomePhoneImage" runat="server" ImageUrl="~/Image/ico_phone.gif"
                                                        ToolTip="Điện thoại bàn" />
                                                    <asp:Label ID="ContactHomePhoneLabel" runat="server" Font-Bold="true"></asp:Label>                                    
                                                    <asp:Image ID="ContactPhoneImage" runat="server" ImageUrl="~/Image/ico_60.gif"
                                                        ToolTip="Điện thoại di động" />
                                                    <asp:Label ID="ContactPhoneLabel" runat="server" Font-Bold="true"></asp:Label><br />
                                                    <asp:Image ID="ContactNoteImage" ToolTip="Ghi chú" runat="server" ImageUrl="~/Image/ico_note.gif" />
                                                    <asp:Label ID="ContactNoteLabel" runat="server"></asp:Label>
                                            </p>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </td>
                    </tr>                        
                </table>
                </div>
                <div class="InfoDetail">
                    <div class="InfoDetailTitle">
                        <div class="Info1">
                        Thông tin chi tiết
                        </div>
                    </div>
                    <asp:Label ID="ContentLabel" runat="server"></asp:Label>
                    <div class="Structure">
                        <div class="StructureT">
                            CẤU TRÚC VÀ DIỆN TÍCH
                        </div>
                        <div class="StructureC">
                            <asp:Table ID="StructureTable" runat="server" GridLines="Vertical">
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg1" Width="38%">
                                        Tổng diện tích sử dụng:
                                        <asp:Label ID="TotalUseAreaLabel1" runat="server" Font-Bold="true"></asp:Label>
                                        m<sup>2</sup>
                                    </asp:TableCell>
                                    <asp:TableCell Width="37%" CssClass="boderleft" RowSpan="9" VerticalAlign="Top">
                                        <table width="100%">
                                            <tr>
                                                <td class="bg1">
                                                    Loại Địa ốc:
                                                    <asp:Label ID="RETypeLabel" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2">
                                                    Pháp Lý:
                                                    <asp:Label CssClass="bg2" ID="LegalLabel" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1">
                                                    Hướng:
                                                    <asp:Label CssClass="bg1" ID="DirectionLabel" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2">
                                                    Đường trước nhà:
                                                    <asp:Label ID="FrontStreetLabel" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1">
                                                    Vị trí Địa ốc:
                                                    <asp:Label ID="LocationLabel" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2">
                                                    Số lầu:
                                                    <asp:Label ID="StoreyLabel" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1">
                                                    Phòng khách:
                                                    <asp:Label ID="LivingRoomLabel1" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2">
                                                    Phòng ngủ:
                                                    <asp:Label ID="BedRoomLabel1" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1">
                                                    Phòng tắm/WC:
                                                    <asp:Label ID="BathRoomLabel1" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2">
                                                    Phòng khác:
                                                    <asp:Label ID="DifferentRoomLabel1" runat="server" Font-Bold="true">_</asp:Label>
                                                </td>
                                            </tr>
                                        </table>                                
                                    </asp:TableCell>
                                    <asp:TableCell CssClass="boderleft" Width="25%" RowSpan="9" VerticalAlign="Top">
                                        <table width="100%">
                                            <tr>
                                                <td class="bg1" width="83%">
                                                    Đẩy đủ tiện nghi
                                                </td>
                                                <td class="bg1" width="17%">
                                                    <asp:Image ID="FullImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2" width="83%">
                                                    Chỗ đậu xe hơi
                                                </td>
                                                <td class="bg2" width="17%">
                                                    <asp:Image ID="GarageImage" runat="server" ImageUrl="~/Image/ico_check.gif"  Visible="false"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1" width="83%">
                                                    Sân vườn
                                                </td>
                                                <td class="bg1" width="17%">
                                                    <asp:Image ID="GardenImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2" width="83%">
                                                    Hồ bơi
                                                </td>
                                                <td class="bg2" width="17%">
                                                    <asp:Image ID="SwimmingPoolImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1" width="83%">
                                                    Tiện kinh doanh
                                                </td>
                                                <td class="bg1" width="17%">
                                                    <asp:Image ID="ForSaleImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2" width="83%">
                                                    Tiện để ở
                                                </td>
                                                <td class="bg2" width="17%">
                                                    <asp:Image ID="ForStayImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1" width="83%">
                                                    Tiện làm văn phòng
                                                </td>
                                                <td class="bg1" width="17%">
                                                    <asp:Image ID="ForOfficeImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg2" width="83%">
                                                    Tiện cho sản xuất
                                                </td>
                                                <td class="bg2" width="17%">
                                                    <asp:Image ID="ForProduceImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bg1" width="83%">
                                                    Cho sinh viên thuê
                                                </td>
                                                <td class="bg1" width="17%">
                                                    <asp:Image ID="ForRentImage" runat="server" ImageUrl="~/Image/ico_check.gif" Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg2">
                                        <b>Diện tích khuôn viên</b>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg1 padding25">
                                        -Chiều ngang trước:
                                        <strong>
                                            <asp:Label ID="CampusFrontLabel1" runat="server"></asp:Label>m
                                        </strong>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg2 padding25">
                                        -Chiều ngang sau:
                                        <strong>
                                            <asp:Label ID="CampusBehindLabel" runat="server"></asp:Label>m
                                        </strong>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg1 padding25">
                                        -Chiều dài:
                                        <strong>
                                            <asp:Label ID="CampusLengthLabel1" runat="server"></asp:Label>m
                                        </strong>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg2">
                                        <b>Diện tích xây dựng</b>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg1 padding25">
                                        -Chiều ngang trước:
                                        <strong>
                                            <asp:Label ID="BuildFrontLabel" runat="server"></asp:Label>m
                                        </strong>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg2 padding25">
                                        -Chiều ngang sau:
                                        <strong>
                                            <asp:Label ID="BuildBedindLabel" runat="server"></asp:Label>m
                                        </strong>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell CssClass="bg1 padding25">
                                        Chiều dài:
                                        <strong>
                                        <asp:Label ID="BuildLengthLabel" runat="server"></asp:Label>m
                                        </strong>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </div>
                    </div>
                </div>

            <div class="AddThis">
                <div class="AddThisL"></div>
                <div class="AddThisC">
                    <div class="addC2">
                        <ul>
                            <li>
                                <asp:Image ID="SendImage" runat="server" ImageUrl="~/Image/ico_send.gif" />
                                <asp:HyperLink ID="SendHyperLink" runat="server" NavigateUrl="~/Pages/TempPage.aspx">Gửi cho bạn bè</asp:HyperLink>
                            </li>
                            <li>
                                <asp:Image ID="PrintImage" runat="server" ImageUrl="~/Image/ico_print.gif" />
                                <asp:HyperLink ID="PrintHyperLink" runat="server" NavigateUrl="javascript:window.print();">Bản in</asp:HyperLink>
                            </li>
                            <li>
                                <asp:Image ID="SaveImage" runat="server" ImageUrl="~/Image/ico_save.gif" />
                                <asp:HyperLink ID="SaveHyperLink" runat="server" NavigateUrl="~/Pages/TempPage.aspx/">Lưu tin</asp:HyperLink>
                            </li>
                            <li>
                                <asp:Image ID="BackImage" runat="server" ImageUrl="~/Image/ico_back.gif" />
                                <asp:HyperLink ID="BackHyperLink" runat="server" NavigateUrl="~/Pages/TempPage.aspx">Quay lại</asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="AddThisR">
                </div>
            </div>
            <div class="infoMember">
                <div class="infoSub">
                    <div class="infoL">
                        <h2>Thông tin thành viên</h2>
                        <p>
                            <asp:Image ID="MemberNameImage" runat="server" ImageUrl="~/Image/ico_user.gif" />
                            <asp:Label ID="MemberNameLabel" runat="server" Font-Bold="true"></asp:Label><br />
                            <asp:Image ID="AddressMemberImage" runat="server" ImageUrl="~/Image/ico_add.gif" />
                            <asp:Label ID="AddressMemberLabel" runat="server"></asp:Label><br />
                            <asp:Image ID="MemberHomePhoneImage" runat="server" ImageUrl="~/Image/ico_phone.gif"
                                ToolTip="Điện thoại bàn" />
                            <asp:Label ID="MemberHomePhoneLabel" runat="server" Font-Bold="true"></asp:Label>
                            <asp:Image ID="MemberPhoneImage" runat="server" ImageUrl="~/Image/ico_60.gif"
                                ToolTip="Điện thoại di động" />
                            <asp:Label ID="MemberPhoneLabel" runat="server" Font-Bold="true"></asp:Label><br />
                        </p>
                    </div>
                </div>
            </div>
            </div>
            </div>
        

    
</asp:Content>
