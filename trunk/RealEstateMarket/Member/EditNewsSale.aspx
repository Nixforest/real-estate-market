﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.Master" AutoEventWireup="true" CodeBehind="EditNewsSale.aspx.cs" Inherits="RealEstateMarket.Member.EditNewsSale" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">
    function FormatNumber(str) {
        var strTemp = GetNumber(str);
        if (strTemp.length <= 3) {
            return strTemp;
        }
        strResult = "";
        for (var i = 0; i < strTemp.length; i++) {
            strTemp = strTemp.replace(",", "");
            var m = strTemp.lastIndexOf(".");
            if (m == -1) {
                for (var i = strTemp.length; i >= 0; i--) {
                    if (strResult.length > 0 && (strTemp.length - i - 1) % 3 == 0)
                        strResult = "," + strResult;
                    strResult = strTemp.substring(i, i + 1) + strResult;
                }
            } else {
                // phần nguyên
                var strphannguyen = strTemp.substring(0, strTemp.lastIndexOf("."));
                var strphanthapphan = strTemp.substring(strTemp.lastIndexOf("."), strTemp.length);
                // phần thập phân
                var tam = 0;
                for (var i = strphannguyen.length; i >= 0; i--) {
                    if (strResult.length > 0 && tam == 4) {
                        strResult = "," + strResult;
                        tam = 1;
                    }
                    strResult = strphannguyen.substring(i, i + 1) + strResult;
                    tam = tam + 1;
                }
                strResult = strResult + strphanthapphan;
            }
            return strResult;
        }
    }
    function GetNumber(str) {
        var count = 0;
        for (var i = 0; i < str.length; i++) {
            var temp = str.substring(i, i + 1);
            if (!(temp == "," || temp == "." || (temp >= 0 && temp <= 9))) {
                alert("Vui lòng nhập số (0-9)!");
                return str.substring(0, i);
            }
            if (temp == " ") {
                return str.substring(0, i);
            }
            if (temp == ".") {
                if (count > 0)
                    return str.substring(0, i);
                count++;
            }
        }
        return str;
    }
</script>   
    <asp:ObjectDataSource ID="RETypeObjectDataSource" runat="server" 
        SelectMethod="GetAllRealEstateTypes" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="NewsSaleTypeObjectDataSource" runat="server"
        SelectMethod="GetAllNewsSaleTypes"         
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="ProjectsObjectDataSource" runat="server" 
        SelectMethod="GetAllProjects" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="UnitObjectDataSource" runat="server" 
        SelectMethod="GetAllUnits" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="UnitPriceObjectDataSource" runat="server" 
        SelectMethod="GetAllUnitPrices" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="LocationObjectDataSource" runat="server" 
        SelectMethod="GetAllLocations" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    
    <p>
        &nbsp;<asp:ValidationSummary ID="NewsSaleValidationSummary" runat="server"
            DisplayMode="BulletList" HeaderText="Vui lòng cập nhật các thông tin tài sản còn thiếu:"
            CssClass="failureNotification" ValidationGroup="NewsSaleValidationGroup" />
            </p>
    <p>
        <asp:Label ID="ErrorLabel" runat="server" CssClass="failureNotification"></asp:Label><br />
    </p>
    <asp:Panel ID="BasicInfoPanel" runat="server" BorderStyle="Groove">
        <h4>
            Thông tin cơ bản
        </h4>
        <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="true">Điền chính xác các thông tin dưới đây giúp cho 
                tài sản của bạn xuất hiện chính xác và đầy đủ trong các kết quả theo nhu cầu của người dùng, 
                việc này giúp cho giao dịch của bạn sẽ nhanh hơn.</asp:Label>
        </p>
        <asp:Table ID="InfoTable" runat="server" GridLines="None">
            <asp:TableRow>
                <asp:TableCell>
                    <b>Loại tin rao:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <asp:RadioButtonList ID="NewsSaleTypeRadioButtonList"
                        runat="server" 
                        DataSourceID="NewsSaleTypeObjectDataSource"
                        DataTextField="Name"
                        DataValueField="ID" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Loại Địa ốc:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="RealEstateTypeDropDownList" runat="server"
                        DataSourceID="RETypeObjectDataSource"
                        DataTextField="Name"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:DropDownList ID="LocationDropDownList" runat="server"
                        DataSourceID="LocationObjectDataSource"
                        DataTextField="Name" ToolTip="Vị trí mặt tiền?"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Vị trí:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="NationLabel" AssociatedControlID="NationDropDownList">Quốc gia</asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="CityLabel" AssociatedControlID="CityDropDownList">Tỉnh / Thành phố</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="NationDropDownList" runat="server"
                        onselectedindexchanged="NationDropDownList_SelectedIndexChanged"
                        AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                    <asp:UpdatePanel ID="CityUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="CityDropDownList" runat="server"
                                onselectedindexchanged="CityDropDownList_SelectedIndexChanged"
                                AutoPostBack="true"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="NationDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="DistrictLabel" AssociatedControlID="DistrictDropDownList">Quận / Huyện</asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="WardLabel" AssociatedControlID="WardDropDownList">Phường / Xã</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="DistrictUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DistrictDropDownList" runat="server"
                                onselectedindexchanged="DistrictDropDownList_SelectedIndexChanged"
                                AutoPostBack="true">
                                </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="CityDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </td>
                <td>
                    <asp:UpdatePanel ID="WardUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="WardDropDownList" runat="server"
                                onselectedindexchanged="WardDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="DifferentCheckBox" runat="server" Enabled="true" OnCheckedChanged="DifferentCheckBox_CheckedChanged"
                                ToolTip="Không cập nhật vị trí Quận, Huyện, Đường phố, bạn có thể nhập Chi tiết Địa chỉ" Text="Khác"
                                AutoPostBack="true"/>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DifferentCheckBox" EventName="CheckedChanged" />
                        </Triggers>
                    </asp:UpdatePanel>  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="DetailLabel" runat="server" AssociatedControlID="DetailTextBox">Số nhà / Số lô</asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="StreetLabel" AssociatedControlID="StreetDropDownList">Tên Đường / Tên Phố</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="DetailTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="StreetDropDownList" runat="server"
                                onselectedindexchanged="StreetDropDownList_SelectedIndexChanged"></asp:DropDownList>        
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </td>
                <td>
                    <%--<asp:CheckBox ID="StreetCheckBox" runat="server" Text="Khác" />--%>
                </td>
            </tr>
        </table>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Tên dự án:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2">
                    <asp:UpdatePanel ID="ProjectUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ProjectDropDownList" runat="server"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ProjectCheckBox" EventName="CheckedChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:CheckBox ID="ProjectCheckBox" runat="server" Text="Khác"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Giá:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="PriceTextBox" runat="server"
                        Text=""
                        ToolTip="Giá trị tài sản"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="PriceRegularExpressionValidator" runat="server"
                        ControlToValidate="PriceTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ValidationExpression="^[0-9]*\.?[0-9]*$" ErrorMessage="Giá chưa hợp lệ"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="PriceRequiredFieldValidator" runat="server"
                        ControlToValidate="PriceTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ErrorMessage="Giá" InitialValue=""></asp:RequiredFieldValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="UnitDropDownList" runat="server"
                        DataSourceID="UnitObjectDataSource"
                        DataTextField="Name"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="UnitPriceDropDownList" runat="server"
                        DataSourceID="UnitPriceObjectDataSource"
                        DataTextField="Name"
                        DataValueField="ID"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Môi giới:</b>
                </asp:TableCell>
                <asp:TableCell ColumnSpan="3">
                    <asp:RadioButtonList ID="BrokerRadioButtonList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Miễn trung gian</asp:ListItem>
                        <asp:ListItem>Ký gởi môi giới</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Diện tích sử dụng:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TotalUseAreaTextBox" runat="server" ToolTip="Tổng diện tích sử dụng"
                        Text=""></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="TotalUseAreaRegularExpressionValidator" runat="server"
                        ControlToValidate="TotalUseAreaTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ValidationExpression="^[0-9]*\.?[0-9]*$" ErrorMessage="Diện tích sử dụng chưa hợp lệ"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="TotalUseAreaRequiredFieldValidator" runat="server"
                        ControlToValidate="TotalUseAreaTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ErrorMessage="Tổng diện tích sử dụng" InitialValue=""></asp:RequiredFieldValidator>m<sup>2</sup>
                </asp:TableCell>
                <asp:TableCell>
                    
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Diện tích khuôn viên:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="CampusFrontTextBox" runat="server" Text="0" ToolTip="Chiều ngang"></asp:TextBox>
                    m <b>X</b><br />
                    <asp:RegularExpressionValidator ID="CampusFrontRegularExpressionValidator" runat="server"
                        ControlToValidate="CampusFrontTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ValidationExpression="^[0-9]*\.?[0-9]*\.?[0-9]*$"
                        ErrorMessage="Chiều ngang Diện tích khuôn viên không hợp lệ"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="CampusLengthTextBox" runat="server" Text="0" ToolTip="Chiều dài"></asp:TextBox>
                    m<br />
                    <asp:RegularExpressionValidator ID="CampusLengthRegularExpressionValidator" runat="server"
                        ControlToValidate="CampusLengthTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ValidationExpression="^[0-9]*\.?[0-9]*$"
                        ErrorMessage="Chiều dài Diện tích khuôn viên không hợp lệ"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>                    
                    <asp:UpdatePanel ID="CampusOpenBehindUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="CampusOpenBehindCheckBox" runat="server"
                                Text="Nở hậu" Font-Bold="true" AutoPostBack="true"
                                oncheckedchanged="CampusOpenBehindCheckBox_CheckedChanged" />
                            <asp:TextBox ID="CampusBehindTextBox" runat="server"
                                Text="0" ToolTip="Chiều ngang sau" Visible="false"></asp:TextBox>
                            <asp:Label ID="CampusMLabel" runat="server" Visible="false">m</asp:Label><br />
                            <asp:RegularExpressionValidator ID="CampusOpenBehindRegularExpressionValidator" runat="server"
                                ControlToValidate="CampusBehindTextBox" Enabled="false" CssClass="failureNotification"
                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                ValidationExpression="^[0-9]*$\.?[0-9]*"
                                ErrorMessage="Chiều ngang sau Diện tích khuôn viên không hợp lệ"></asp:RegularExpressionValidator>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="CampusOpenBehindCheckBox" EventName="checkedchanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Diện tích xây dựng:</b>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="BuildFrontTextBox" runat="server" Text="0" ToolTip="Chiều ngang"></asp:TextBox>
                    m <b>X</b><br />
                    <asp:RegularExpressionValidator ID="BuildFrontRegularExpressionValidator" runat="server"
                        ControlToValidate="BuildFrontTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ValidationExpression="^[0-9]*\.?[0-9]*$"
                        ErrorMessage="Chiều ngang Diện tích xây dựng không hợp lệ"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="BuildLengthTextBox" runat="server" Text="0" ToolTip="Chiều dài"></asp:TextBox>
                    m<br />
                    <asp:RegularExpressionValidator ID="BuildLengthRegularExpressionValidator" runat="server"
                        ControlToValidate="BuildLengthTextBox" CssClass="failureNotification"
                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                        ValidationExpression="^[0-9]*\.?[0-9]*$"
                        ErrorMessage="Chiều dài Diện tích xây dựng không hợp lệ"></asp:RegularExpressionValidator>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:UpdatePanel ID="BuildOpenBehindUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="BuildOpenBehindCheckBox" runat="server" Text="Nở hậu" Font-Bold="true" 
                                AutoPostBack="true"
                                OnCheckedChanged="BuildOpenBehindCheckBox_CheckedChanged"/>
                            <asp:TextBox ID="BuildBehindTextBox" runat="server" Text="0" ToolTip="Chiều ngang sau" Visible="false"></asp:TextBox>
                            <asp:Label ID="BuildMLabel" runat="server" Visible="false">m</asp:Label><br />
                            <asp:RegularExpressionValidator ID="BuildOpenBehindRegularExpressionValidator" runat="server"
                                ControlToValidate="BuildBehindTextBox" Enabled="false" CssClass="failureNotification"
                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                ValidationExpression="^[0-9]*\.?[0-9]*$"
                                ErrorMessage="Chiều ngang sau Diện tích xây dựng không hợp lệ"></asp:RegularExpressionValidator>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BuildOpenBehindCheckBox" EventName="checkedchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:ObjectDataSource ID="UtilityObjectDataSource" runat="server" 
        SelectMethod="GetAllUtilities" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LegalObjectDataSource" runat="server"
        SelectMethod="GetAllLegals"
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:Panel ID="UtilityPanel" runat="server" BorderStyle="Groove">
        <h4>
            Đặc điểm & Tiện ích
        </h4>
        <asp:Table ID="UtilityTable" runat="server" GridLines="Both">
            <asp:TableRow>
                <asp:TableCell>
                    <b>Tình trạng pháp lý:</b><br />
                    <asp:DropDownList ID="LegalDropDownList" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng khách:</b><br />
                    <asp:DropDownList ID="LivingRoomDropDownList" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell RowSpan="4">
                    <b>Các tiện ích:</b><br />                    
                        <asp:CheckBox ID="FullCheckBox" runat="server" Text="Đầy đủ tiện nghi"/><br />
                        <asp:CheckBox ID="GarageCheckBox" runat="server" Text="Chỗ đậu xe hơi"/><br />
                        <asp:CheckBox ID="GardenCheckBox" runat="server" Text="Sân vườn"/><br />
                        <asp:CheckBox ID="SwimmingPoolCheckBox" runat="server" Text="Hồ bơi"/><br />
                        <asp:CheckBox ID="ForSaleCheckBox" runat="server" Text="Tiện kinh doanh"/><br />
                        <asp:CheckBox ID="ForStayCheckBox" runat="server" Text="Tiện để ở"/><br />
                        <asp:CheckBox ID="ForOfficeCheckBox" runat="server" Text="Tiện làm văn phòng"/><br />
                        <asp:CheckBox ID="ForProduceCheckBox" runat="server" Text="Tiện cho sản xuất"/><br />
                        <asp:CheckBox ID="ForRentCheckBox" runat="server" Text="Cho sinh viên thuê" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Hướng tài sản:</b><br />
                    <asp:DropDownList ID="DirectionDropDownList" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>Đông</asp:ListItem>
                        <asp:ListItem>Tây</asp:ListItem>
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Bắc</asp:ListItem>
                        <asp:ListItem>Đông Bắc</asp:ListItem>
                        <asp:ListItem>Đông Nam</asp:ListItem>
                        <asp:ListItem>Tây Bắc</asp:ListItem>
                        <asp:ListItem>Tây Nam</asp:ListItem>
                        <asp:ListItem>Không xác định</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng ngủ:</b><br />
                    <asp:DropDownList ID="BedRoomDropDownList" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>61</asp:ListItem>
                        <asp:ListItem>62</asp:ListItem>
                        <asp:ListItem>63</asp:ListItem>
                        <asp:ListItem>64</asp:ListItem>
                        <asp:ListItem>65</asp:ListItem>
                        <asp:ListItem>66</asp:ListItem>
                        <asp:ListItem>67</asp:ListItem>
                        <asp:ListItem>68</asp:ListItem>
                        <asp:ListItem>69</asp:ListItem>
                        <asp:ListItem>70</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Đường trước nhà:</b><br />
                    <asp:DropDownList ID="FrontStreetDropDownList" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>< 3m</asp:ListItem>
                        <asp:ListItem>> 3m</asp:ListItem>
                        <asp:ListItem>> 4m</asp:ListItem>
                        <asp:ListItem>> 5m</asp:ListItem>
                        <asp:ListItem>> 6m</asp:ListItem>
                        <asp:ListItem>> 7m</asp:ListItem>
                        <asp:ListItem>> 8m</asp:ListItem>
                        <asp:ListItem>> 9m</asp:ListItem>
                        <asp:ListItem>> 10m</asp:ListItem>
                        <asp:ListItem>> 15m</asp:ListItem>
                        <asp:ListItem>> 20m</asp:ListItem>
                        <asp:ListItem>> 40m</asp:ListItem>
                        <asp:ListItem>> 60m</asp:ListItem>
                        <asp:ListItem>> 80m</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng tắm/vệ sinh:</b><br />
                    <asp:DropDownList ID="BathRoomDropDownList" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>61</asp:ListItem>
                        <asp:ListItem>62</asp:ListItem>
                        <asp:ListItem>63</asp:ListItem>
                        <asp:ListItem>64</asp:ListItem>
                        <asp:ListItem>65</asp:ListItem>
                        <asp:ListItem>66</asp:ListItem>
                        <asp:ListItem>67</asp:ListItem>
                        <asp:ListItem>68</asp:ListItem>
                        <asp:ListItem>69</asp:ListItem>
                        <asp:ListItem>70</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <b>Số lầu:</b><br />
                    <asp:DropDownList ID="StoreyDropDownList" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>
                        <asp:ListItem>35</asp:ListItem>
                        <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>
                        <asp:ListItem>40</asp:ListItem>
                        <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                        <asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>
                        <asp:ListItem>55</asp:ListItem>
                        <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>60</asp:ListItem>
                        <asp:ListItem>61</asp:ListItem>
                        <asp:ListItem>62</asp:ListItem>
                        <asp:ListItem>63</asp:ListItem>
                        <asp:ListItem>64</asp:ListItem>
                        <asp:ListItem>65</asp:ListItem>
                        <asp:ListItem>66</asp:ListItem>
                        <asp:ListItem>67</asp:ListItem>
                        <asp:ListItem>68</asp:ListItem>
                        <asp:ListItem>69</asp:ListItem>
                        <asp:ListItem>70</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <b>Số phòng khác:</b><br />
                    <asp:DropDownList ID="DifferentRoomDropDownList" runat="server">
                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="DescriptionPanel" runat="server" BorderStyle="Groove">
        <h4>Mô tả chi tiết tài sản</h4>
        <asp:Label ID="Label2" runat="server" ForeColor="Red">
            Vùng nội dung mô tả này sẽ được kiểm duyệt thông tin trước khi cho phép hiển thị trên RealEstateMarket.vn 
        </asp:Label>
        <br />
        Tin đăng nhập nội dung theo đúng quy định sẽ được ưu tiên duyệt hiển thị nhanh hơn.
        Vui lòng nhập tiếng Việt có dấu. Nếu bạn không nhập mô tả, hệ thống sẽ lấy mô tả tự động.
        <br />
        <asp:Table ID="DescriptionTable" runat="server" GridLines="Both">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right"><b>Tiêu đề:</b></asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right"><b>Nội dung mô tả:</b></asp:TableCell>
                <asp:TableCell>
                    <CKEditor:CKEditorControl ID="ContentCKEditor" runat="server"></CKEditor:CKEditorControl>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    <asp:Panel ID="ImagePanel" runat="server" BorderStyle="Groove">
        <h4>Cập nhật hình ảnh</h4>
        <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text="Cập nhật hình ảnh tài sản: (Tối đa 10 hình)"></asp:Label><br />
        <asp:Table ID="ImageTable" runat="server" GridLines="Both">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload0" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload1" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload2" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload3" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload4" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload5" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload6" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload7" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload8" runat="server" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="ImageFileUpload9" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        - Không đăng các hình ảnh mờ hoặc hình có kích thước nhỏ hơn 360x360 pixel.<br />
        - Không đăng các hình ảnh có gắn kèm logo hoặc thông điệp quảng cáo.<br />
        - Nếu bạn không tải hình ảnh, hệ thống sẽ lấy hình minh hoạ tự động tương ứng với loại địa ốc mà bạn chọn.
    </asp:Panel>
    <asp:Panel ID="MapPanel" runat="server" BorderStyle="Groove">
        <h4>Cập nhật vị trí Địa ốc trên bản đồ</h4>
        <asp:ImageButton ID="imgButtonMap" runat="server" />
        Click vào đây để tiến hành cập nhật vị trí tài sản trên bản đồ
        Tài sản của quý vị sẽ được giao dịch nhanh hơn khi cập nhật vị trí chính xác của tài sản
    </asp:Panel>
    <asp:Panel ID="ContactPanel" runat="server" BorderStyle="Groove">
        <asp:Table runat="server" ID="ContactTable">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="ContactNameLabel" runat="server" AssociatedControlID="ContactNameTextBox" Text="Người liên hệ:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ContactNameTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="ContactHomePhoneLabel" runat="server" AssociatedControlID="ContactHomePhoneTextBox" Text="Điện thoại:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ContactHomePhoneTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="ContactPhoneLabel" runat="server" AssociatedControlID="ContactPhoneTextBox" Text="Di động:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ContactPhoneTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="ContactAddressLabel" runat="server" AssociatedControlID="ContactAddressTextBox" Text="Địa chỉ:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ContactAddressTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="ContactNoteLabel" runat="server" AssociatedControlID="ContactNoteTextBox" Text="Ghi chú:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ContactNoteTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="NotePanel" runat="server" BorderStyle="Groove" HorizontalAlign="Center">
        Những mục có dấu * là thông tin phải điền đầy đủ. Chỉ khi bạn hoàn tất những thông tin được yêu cầu 
        điền đầy đủ thì các chức năng Xem trước hay Đăng tài sản mới được kích hoạt
        RealEstateMarket không chịu trách nhiệm về những nội dung (chữ/ hình ảnh/ Video) do bạn đăng tải
        Khi nhấn nút đăng tài sản, bạn đã xác nhận hoàn toàn đồng ý với những Điều khoản đăng tin.
        <br />
    </asp:Panel>
    <asp:Button ID="PreviewButton" runat="server" Text="Xem trước" ValidationGroup="NewsSaleValidationGroup" />
    <asp:Button ID="SaveButton" runat="server" Text="Lưu lại" />
    <asp:Button ID="PostButton" runat="server" Text="Cập nhật tài sản"
        OnClick="PostButton_Click"
        ValidationGroup="NewsSaleValidationGroup"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>