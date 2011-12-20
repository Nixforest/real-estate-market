<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NewsSale.Master" AutoEventWireup="true" CodeBehind="NewsSale.aspx.cs" Inherits="RealEstateMarket.Pages.NewsSale" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="UnitObjectDataSource" runat="server" 
        SelectMethod="GetAllUnits" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    
    <asp:Panel ID="NewsSalePanel" runat="server" BorderStyle="Groove">
        <asp:Label ID="TitleLabel" runat="server"></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:Image ID="SlideShowImage" runat="server"
                        Height="360px" Width="360px"/>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="NewsSaleTypeImage" runat="server" />
                                Mã số tài sản:
                                <asp:Label ID="RealEstateIDLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="AddressTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="PriceUpdatePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="UnitDropDownList" runat="server"
                                            DataSourceID="UnitObjectDataSource"
                                            DataTextField="Name" Enabled="false"
                                            DataValueField="ID" AutoPostBack="true"
                                            OnSelectedIndexChanged="UnitDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="PriceLabel" runat="server"></asp:Label>
                                        <asp:Label ID="UnitPriceLabel" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="UnitDropDownList"  EventName="SelectedIndexChanged"/>
                                    </Triggers>
                                </asp:UpdatePanel>                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LivingRoomLabel" runat="server">-</asp:Label>
                                <asp:Image ID="LivingRoomImage" runat="server" ImageUrl="~/Image/dt_phongkhach.gif"
                                    ToolTip="Phòng khách" />
                                <asp:Label ID="BedRoomLabel" runat="server">-</asp:Label>
                                <asp:Image ID="BedRoomImage" runat="server" ImageUrl="~/Image/dt_phongngu.gif"
                                    ToolTip="Phòng ngủ"  />
                                <asp:Label ID="BathRoomLabel" runat="server">-</asp:Label>
                                <asp:Image ID="BathRoomLImage" runat="server" ImageUrl="~/Image/dt_phongtam.gif" 
                                    ToolTip="Phòng tắm/WC" />
                                <asp:Label ID="DifferentRoomLabel" runat="server">-</asp:Label>
                                <asp:Image ID="DifferentRoomImage" runat="server" ImageUrl="~/Image/dt_tivi.gif" 
                                    ToolTip="Phòng khác" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    Diện tích khuôn viên:
                                    <asp:Label ID="CampusFrontLabel" runat="server"></asp:Label>m
                                    X
                                    <asp:Label ID="CampustLengthLabel" runat="server"></asp:Label>m
                                </p>
                                <p>
                                    Diện tích sử dụng:
                                    <asp:Label ID="TotalUseAreaLabel" runat="server"></asp:Label>
                                    m<sup>2</sup>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="ContactPanel" runat="server">
                                    LIÊN HỆ<br />
                                        <asp:Image ID="ContactNameImage" ToolTip="Tên" runat="server" ImageUrl="~/Image/ico_user.gif" />
                                        <asp:Label ID="ContactNameLabel" runat="server"></asp:Label><br />
                                        <asp:Image ID="AddressContactImage" ToolTip="Địa chỉ" runat="server" ImageUrl="~/Image/ico_add.gif" />
                                        <asp:Label ID="AddressContactLabel" runat="server"></asp:Label><br />
                                        <asp:Image ID="ContactHomePhoneImage" runat="server" ImageUrl="~/Image/ico_phone.gif"
                                            ToolTip="Điện thoại bàn" />
                                        <asp:Label ID="ContactHomePhoneLabel" runat="server"></asp:Label>                                    
                                        <asp:Image ID="ContactPhoneImage" runat="server" ImageUrl="~/Image/ico_60.gif"
                                            ToolTip="Điện thoại di động" />
                                        <asp:Label ID="ContactPhoneLabel" runat="server"></asp:Label><br />
                                        <asp:Image ID="ContactNoteImage" ToolTip="Ghi chú" runat="server" ImageUrl="~/Image/ico_note.gif" />
                                        <asp:Label ID="ContactNoteLabel" runat="server"></asp:Label>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>                        
        </table>
    </asp:Panel>
    <asp:Panel ID="InfoPanel" runat="server" BorderStyle="Groove">
        <h3>Thông tin chi tiết</h3>
        <p>
            <asp:Label ID="ContentLabel" runat="server"></asp:Label>
        </p>
        <p>
            CẤU TRÚC VÀ DIỆN TÍCH
        </p>
        <p>
            <asp:Table ID="StructureTable" runat="server" GridLines="Vertical">
                <asp:TableRow>
                    <asp:TableCell>
                        Tổng diện tích sử dụng:
                        <asp:Label ID="TotalUseAreaLabel1" runat="server" Font-Bold="true"></asp:Label>
                        m<sup>2</sup>
                    </asp:TableCell>
                    <asp:TableCell>
                        Loại Địa ốc:
                        <asp:Label ID="RETypeLabel" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Đẩy đủ tiện nghi
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="FullCheckBox" runat="server" Enabled="false"/>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <b>Diện tích khuôn viên</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        Pháp Lý:
                        <asp:Label ID="LegalLabel" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Chỗ đậu xe hơi
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="GarageCheckBox" runat="server" Enabled="false"/>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        -Chiều ngang trước:
                        <asp:Label ID="CampusFrontLabel1" runat="server" Font-Bold="true"></asp:Label>m
                    </asp:TableCell>
                    <asp:TableCell>
                        Hướng:
                        <asp:Label ID="DirectionLabel" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Sân vườn
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="GardenCheckBox" runat="server" Enabled="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        -Chiều ngang sau:
                        <asp:Label ID="CampusBehindLabel" runat="server" Font-Bold="true"></asp:Label>m
                    </asp:TableCell>
                    <asp:TableCell>
                        Đường trước nhà:
                        <asp:Label ID="FrontStreetLabel" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Hồ bơi
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="SwimmingPoolCheckBox" runat="server" Enabled="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        -Chiều dài:
                        <asp:Label ID="CampusLengthLabel1" runat="server" Font-Bold="true"></asp:Label>m
                    </asp:TableCell>
                    <asp:TableCell>
                        Vị trí Địa ốc:
                        <asp:Label ID="LocationLabel" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Tiện kinh doanh
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ForSaleCheckBox" runat="server" Enabled="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <b>Diện tích xây dựng</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        Số lầu:
                        <asp:Label ID="StoreyLabel" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Tiện để ở
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ForStayCheckBox" runat="server" Enabled="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        -Chiều ngang trước:
                        <asp:Label ID="BuildFrontLabel" runat="server" Font-Bold="true"></asp:Label>m
                    </asp:TableCell>
                    <asp:TableCell>
                        Phòng khách:
                        <asp:Label ID="LivingRoomLabel1" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Tiện làm văn phòng
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ForOfficeCheckBox" runat="server" Enabled="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        -Chiều ngang sau:
                        <asp:Label ID="BuildBedindLabel" runat="server" Font-Bold="true"></asp:Label>m
                    </asp:TableCell>
                    <asp:TableCell>
                        Phòng ngủ:
                        <asp:Label ID="BedRoomLabel1" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Tiện cho sản xuất
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ForProduceCheckBox" runat="server" Enabled="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        -Chiều dài:
                        <asp:Label ID="BuildLengthLabel" runat="server" Font-Bold="true"></asp:Label>m
                    </asp:TableCell>
                    <asp:TableCell>
                        Phòng tắm/WC:
                        <asp:Label ID="BathRoomLabel1" runat="server" Font-Bold="true"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        Cho sinh viên thuê
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ForRentCheckBox" runat="server" Enabled="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        
                    </asp:TableCell>
                    <asp:TableCell>
                        Phòng khác:
                        <asp:Label ID="DifferentRoomLabel1" runat="server" Font-Bold="true">_</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                       
                    </asp:TableCell>
                    <asp:TableCell>
                        
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </p>
    </asp:Panel>
    <asp:Panel ID="DetailPanel" runat="server" HorizontalAlign="Right">
        <asp:Image ID="SendImage" runat="server" ImageUrl="~/Image/ico_send.gif" />
        <asp:HyperLink ID="SendHyperLink" runat="server" NavigateUrl="http://margnet11191.tumblr.com/">Gửi cho bạn bè</asp:HyperLink>
        <asp:Image ID="PrintImage" runat="server" ImageUrl="~/Image/ico_print.gif" />
        <asp:HyperLink ID="PrintHyperLink" runat="server" NavigateUrl="http://margnet11191.tumblr.com/">Bản in</asp:HyperLink>
        <asp:Image ID="SaveImage" runat="server" ImageUrl="~/Image/ico_save.gif" />
        <asp:HyperLink ID="SaveHyperLink" runat="server" NavigateUrl="http://margnet11191.tumblr.com/">Lưu tin</asp:HyperLink>
        <asp:Image ID="BackImage" runat="server" ImageUrl="~/Image/ico_back.gif" />
        <asp:HyperLink ID="BackHyperLink" runat="server" NavigateUrl="http://margnet11191.tumblr.com/">Quay lại</asp:HyperLink>
    </asp:Panel>
    <asp:Panel ID="MemberPanel" runat="server" HorizontalAlign="Left">
        <h3>
            Thông tin thành viên
        </h3>
        <br />
            <asp:Image ID="MemberNameImage" runat="server" ImageUrl="~/Image/ico_user.gif" />
            <asp:Label ID="MemberNameLabel" runat="server"></asp:Label><br />
            <asp:Image ID="AddressMemberImage" runat="server" ImageUrl="~/Image/ico_add.gif" />
            <asp:Label ID="AddressMemberLabel" runat="server"></asp:Label><br />
            <asp:Image ID="MemberHomePhoneImage" runat="server" ImageUrl="~/Image/ico_phone.gif"
                ToolTip="Điện thoại bàn" />
            <asp:Label ID="MemberHomePhoneLabel" runat="server"></asp:Label>
            <asp:Image ID="MemberPhoneImage" runat="server" ImageUrl="~/Image/ico_60.gif"
                ToolTip="Điện thoại di động" />
            <asp:Label ID="MemberPhoneLabel" runat="server"></asp:Label><br />
    </asp:Panel>
</asp:Content>
