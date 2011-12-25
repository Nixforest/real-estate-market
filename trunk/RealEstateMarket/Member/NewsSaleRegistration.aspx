<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.Master" AutoEventWireup="true" CodeBehind="NewsSaleRegistration.aspx.cs" Inherits="RealEstateMarket.Member.NewsSaleRegistration" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
<style type="text/css">
#tsmStep1B {
    overflow: hidden;
}
#tsmStep1B .tsmC {
    float: left;
    width: 644px;
    margin-left: 10px;
    overflow: hidden;
}
#tsmStep1B .tsmC .tsmCtit {
    width: 644px;
    height: 25px;
    overflow: hidden;
}
#tsmStep1B .tsmC .tsmCtit .tsmCtit1 {
    float: left;
    width: 8px;
    height: 25px;
    background: url(../../Image/bgd_bdL.gif) no-repeat 0 0;
}
#tsmStep1B .tsmC .tsmCtit .tsmCtit2 {
    float: left;
    width: 628px;
    height: 19px;
    padding-top: 6px;
    background: url(../../Image/bgd_bdC.gif) repeat-x 0 0;
    font: 11px Arial;
    color: white;
    font-weight: bold;
    text-transform: uppercase;
}
#tsmStep1B .tsmC .tsmCtit .tsmCtit3 {
    float: right;
    width: 8px;
    height: 25px;
    background: url(../../Image/bgd_bdR.gif) no-repeat 0 0;
}
#tsmStep1B .tsmC .tsmCcon {
    width: 642px;
    border-bottom: 1px solid #41A0CC;
    border-left: 1px solid #41A0CC;
    border-right: 1px solid #41A0CC;
}
#tsmStep1B .tsmC .tsmCcon ul {
    overflow: hidden;
    list-style: none;
    margin:0;
    padding:0;
}
#tsmStep1B .tsmC .tsmCcon li {
    display: block;
}
#tsmStep1B .tsmC .tsmCcon li .TitleStep1 {
    width: 642px;
    height: 30px;
    overflow: hidden;
}
#tsmStep1B .tsmC .tsmCcon li .TitleStep1 .titL {
    float: left;
    width: 602px;
    height: 25px;
    padding: 5px 0 0 10px;
    background: url(../../Image/bgd7.gif) repeat-x 0 0;
    font: 18px Arial;
    color: #0486C2;
    font-weight: normal;
}
#tsmStep1B .tsmC .tsmCcon li .TitleStep1 .icoR {
    float: right;
    width: 25px;
    height: 20px;
    padding: 10px 5px 0 0;
    background: url(../../Image/bgd_stepR.gif) no-repeat 0 0;
    text-align: right;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan {
    width: 622px;
    padding: 10px 10px 20px 10px;
    font: 12px Arial;
    color: black;
    overflow: hidden;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan p {
    font: 12px Arial, Helvetica, sans-serif;
    color: black;
    line-height: 18px;
    padding: 0 0 15px 0;
}
.alert_error {
    margin: 7px;
    padding: 7px;
    border: 2px solid #F48D00;
    background-color: white;
    color: #333;
    border-image: initial;
}
.alert_error .alert_title {
    font-weight: bold;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb {
    width: 622px;
    overflow: hidden;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb .kc {
    height: 25px;
}

#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb .kcda {
    height: 25px;
    margin-bottom:1px;
    position:relative;
    top:84px;
}

#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb .kcvtr {
    height: 25px;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb .kcldo {
    height: 25px;
}

#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb .kcltr {
    height: 37px;
}

table {
    line-height: 1.4em;
    padding: 0;
    margin: 0;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb .kc1 {
    height: 30px;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ttcb .kc1 {
    height: 30px;
}
select {
    font-family: arial;
    font-size: 12px;
    color: #333;
    padding: 1px;
}
input {
    font-family: arial;
    font-size: 12px;
    color: #333;
    padding: 1px;
}
.input63 {
    width: 63px;
    border: 1px solid #7F9DB9;
    border-image: initial;
}
.input163 {
    width: 163px;
    border: 1px solid #7F9DB9;
    border-image: initial;
}
.input133 {
    width: 133px;
    border: 1px solid #7F9DB9;
    height: 17px;
    border-image: initial;
}
.input113 {
    width: 113px;
    border: 1px solid #7F9DB9;
    border-image: initial;
}
.input102 {
    width: 102px;
    border: 1px solid #7F9DB9;
    border-image: initial;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ddti {
    width: 622px;
    overflow: hidden;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ddti .kc2 {
    height: 25px;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .ddti p.ti {
    padding: 3px 0 0 0;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan p {
    font: 12px Arial, Helvetica, sans-serif;
    color: black;
    line-height: 18px;
    padding: 0 0 15px 0;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan p span.t1 {
    font: 12px Arial;
    color: red;
    font-weight: bold;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan p span.t2 {
    font: 11px Arial;
    color: black;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan p.cen {
    text-align: center;
}
#tsmStep1B .tsmC .tsmCcon li .stepsDangTaiSan .note {
    text-align: center;
}
.button {
    width: 132px;
    height: 39px;
    background: url(../../Image/bgd_button.gif) no-repeat 0 0;
    font: 18px Arial;
    color: black;
    font-weight: normal;
    cursor: pointer;
    border: none;
    border-image: initial;
}
</style>

<div id="tsmStep1B">
    <div class="tsmC">
        <div class="tsmCtit">
            <div class="tsmCtit1"></div>
            <div class="tsmCtit2">
                Đăng tài sản mới
            </div>
            <div class="tsmCtit3"></div>
        </div>
        <div class="tsmCcon">
            <ul>
                <li>
                    <div class="TitleStep1">
                        <div class="titL">
                            Thông tin cơ bản
                        </div>
                        <div class="icoR"></div>
                    </div>
                    <div class="stepsDangTaiSan">
                        <asp:UpdatePanel ID="MyUpdatePanel" runat="server">
                            <ContentTemplate>
                                <p>
                                <strong>
                                    Điền chính xác các thông tin dưới đây giúp cho 
                                    tài sản của bạn xuất hiện chính xác và đầy đủ trong các kết quả theo nhu cầu của người dùng, 
                                    việc này giúp cho giao dịch của bạn sẽ nhanh hơn.
                                </strong>
                            </p>
                                <div class="alert_error" id="idError"
                                style="display:none">
                                <div class="alert_title">
                                    Vui lòng cập nhật các thông tin tài sản còn thiếu ( <span class="red">*</span> )
                                </div>
                                <ul>
                                    <li id="idLoaiTaiSan" style="display: none">Tuyến đường</li>
                                    <li id="idPhanLoaiTaiSan" style="display: none">Loại địa ốc</li>
                                    <li id="idQuanHuyen" style="display: none">Quận/huyện</li>
                                    <li id="idMota" style="display: none">Tổng diện tích sử dụng</li>
                                    <li id="idTenLienHe" style="display: none">Người liên hệ</li>
                                    <li id="idPhone" style="display: none">Số điện thoại bàn hoặc di động</li>
                                    <li id="idTieuDe" style="display: none">Vui lòng nhập tiêu đề hoặc chọn lấy tiêu đề
                                        tự động</li>
                                </ul>
                                <div class="alert_title">
                                    <asp:ValidationSummary ID="NewsSaleValidationSummary" runat="server"
                                        DisplayMode="BulletList" HeaderText="Vui lòng cập nhật các thông tin tài sản còn thiếu:"
                                        CssClass="failureNotification" ValidationGroup="NewsSaleValidationGroup" />
                                </div>
                            </div>
                                <div class="ttcb">
                                <asp:Table ID="Table1" runat="server" Width="100%">
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kcltr" HorizontalAlign="Right">
                                            <b>Loại tin rao:</b>
                                        </asp:TableCell>                                    
                                        <asp:TableCell RowSpan="4" VerticalAlign="Top">
                                            <table>
                                                <tr>
                                                    <td colspan="3" class="kc1">
                                                        <asp:RadioButtonList ID="NewsSaleTypeRadioButtonList"
                                                            runat="server" 
                                                            DataSourceID="NewsSaleTypeObjectDataSource"
                                                            DataTextField="Name"
                                                            DataValueField="ID" RepeatDirection="Horizontal">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="idDioGroup" width="36%" class="kc1">
                                                        <asp:DropDownList ID="RealEstateTypeDropDownList" runat="server"
                                                            DataSourceID="RETypeObjectDataSource"
                                                            DataTextField="Name" CssClass="input163"
                                                            DataValueField="ID"></asp:DropDownList>
                                                    </td>
                                                    <td width="46%" id="idDionewsLine">
                                                        <asp:DropDownList ID="LocationDropDownList" runat="server"
                                                            DataSourceID="LocationObjectDataSource" CssClass="input163"
                                                            DataTextField="Name" ToolTip="Vị trí mặt tiền?"
                                                            DataValueField="ID"></asp:DropDownList>
                                                    </td>
                                                    <td width="18%"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <nixforest:address ID="AddressCustomControl" DistrictID="2" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="kc1">
                                                        <asp:DropDownList ID="ProjectDropDownList" runat="server"
                                                            DataSourceID="ProjectsObjectDataSource"
                                                            DataTextField="Name"
                                                            DataValueField="ID"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="ProjectCheckBox" runat="server"
                                                            AutoPostBack="true"
                                                            OnCheckedChanged="ProjectCheckBox_CheckedChanged" Text="Khác"/>
                                                    </td>
                                                </tr>
                                            </table>
                                        
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kcldo" HorizontalAlign="Right">
                                            <b>Loại Địa ốc:</b>
                                            <span class="red">*</span>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kc1" HorizontalAlign="Right">
                                            <b>Vị trí:</b>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kcda" HorizontalAlign="Right">
                                            <b>Tên dự án:</b>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kc" HorizontalAlign="Right">
                                            <b>Giá:</b>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox ID="PriceTextBox" runat="server" CssClass="input133"
                                                Text=""
                                                ToolTip="Giá trị tài sản"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="KeyTextBox_TextBoxWatermarkExtender" 
                                                runat="server" Enabled="True" TargetControlID="PriceTextBox"
                                                WatermarkText="0">
                                            </asp:TextBoxWatermarkExtender>
                                            <asp:RegularExpressionValidator ID="PriceRegularExpressionValidator" runat="server"
                                                ControlToValidate="PriceTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ValidationExpression="^[0-9]*\.?[0-9]*$" ErrorMessage="*"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="PriceRequiredFieldValidator" runat="server"
                                                ControlToValidate="PriceTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ErrorMessage="*" InitialValue=""></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="UnitDropDownList" runat="server"
                                                DataSourceID="UnitObjectDataSource" CssClass="input63"
                                                DataTextField="Name"
                                                DataValueField="ID"></asp:DropDownList>
                                            <asp:DropDownList ID="UnitPriceDropDownList" runat="server"
                                                DataSourceID="UnitPriceObjectDataSource"
                                                DataTextField="Name" CssClass="input113"
                                                DataValueField="ID"></asp:DropDownList>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kc" HorizontalAlign="Right">
                                            <b>Môi giới:</b>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:RadioButtonList ID="BrokerRadioButtonList" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Miễn trung gian</asp:ListItem>
                                                <asp:ListItem>Ký gởi môi giới</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kc" HorizontalAlign="Right">
                                            <b>Diện tích sử dụng:</b>
                                            <span class="red">*</span>
                                        </asp:TableCell>
                                        <asp:TableCell ID="idDes">
                                            <asp:TextBox ID="TotalUseAreaTextBox" runat="server" ToolTip="Tổng diện tích sử dụng"
                                                Text="" CssClass="input102"></asp:TextBox>
                                                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                                                    runat="server" Enabled="True" TargetControlID="TotalUseAreaTextBox"
                                                    WatermarkText="0">
                                                </asp:TextBoxWatermarkExtender>
                                            <asp:RegularExpressionValidator ID="TotalUseAreaRegularExpressionValidator" runat="server"
                                                ControlToValidate="TotalUseAreaTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ValidationExpression="^[0-9]*\.?[0-9]*$" ErrorMessage="*"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="TotalUseAreaRequiredFieldValidator" runat="server"
                                                ControlToValidate="TotalUseAreaTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ErrorMessage="*" InitialValue=""></asp:RequiredFieldValidator>m<sup>2</sup>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell CssClass="kc" HorizontalAlign="Right">
                                            <b>Diện tích khuôn viên:</b>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox ID="CampusFrontTextBox" runat="server" Text="0" CssClass="input102" ToolTip="Chiều ngang"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                                                    runat="server" Enabled="True" TargetControlID="CampusFrontTextBox"
                                                    WatermarkText="0">
                                                </asp:TextBoxWatermarkExtender>
                                            m <b>X</b>
                                            <asp:RegularExpressionValidator ID="CampusFrontRegularExpressionValidator" runat="server"
                                                ControlToValidate="CampusFrontTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ValidationExpression="^[0-9]*\.?[0-9]*\.?[0-9]*$"
                                                ErrorMessage="*"></asp:RegularExpressionValidator>
                                            <asp:TextBox ID="CampusLengthTextBox" runat="server" Text="0" CssClass="input102" ToolTip="Chiều dài"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" 
                                                    runat="server" Enabled="True" TargetControlID="CampusLengthTextBox"
                                                    WatermarkText="0">
                                                </asp:TextBoxWatermarkExtender>
                                            m
                                            <asp:RegularExpressionValidator ID="CampusLengthRegularExpressionValidator" runat="server"
                                                ControlToValidate="CampusLengthTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ValidationExpression="^[0-9]*\.?[0-9]*$"
                                                ErrorMessage="*"></asp:RegularExpressionValidator>

                                           <%-- <asp:UpdatePanel ID="CampusOpenBehindUpdatePanel" runat="server">
                                                <ContentTemplate>--%>
                                                    <asp:CheckBox ID="CampusOpenBehindCheckBox" runat="server"
                                                        Text="Nở hậu" Font-Bold="true" AutoPostBack="true"
                                                        oncheckedchanged="CampusOpenBehindCheckBox_CheckedChanged" />
                                                    <asp:TextBox ID="CampusBehindTextBox" runat="server" CssClass="input102"
                                                        Text="0" ToolTip="Chiều ngang sau" Visible="false"></asp:TextBox>
                                                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" 
                                                            runat="server" Enabled="True" TargetControlID="CampusBehindTextBox"
                                                            WatermarkText="0">
                                                        </asp:TextBoxWatermarkExtender>
                                                    <asp:Label ID="CampusMLabel" runat="server" Visible="false">m</asp:Label>
                                                    <asp:RegularExpressionValidator ID="CampusOpenBehindRegularExpressionValidator" runat="server"
                                                        ControlToValidate="CampusBehindTextBox" Enabled="false" CssClass="failureNotification"
                                                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                        ValidationExpression="^[0-9]*$\.?[0-9]*"
                                                        ErrorMessage="*"></asp:RegularExpressionValidator>
                                                <%--</ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="CampusOpenBehindCheckBox" EventName="checkedchanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>--%>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow ID="id1">
                                        <asp:TableCell CssClass="kc" HorizontalAlign="Right">
                                            <b>Diện tích xây dựng:</b>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox ID="BuildFrontTextBox" runat="server" Text="0" CssClass="input102" ToolTip="Chiều ngang"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" 
                                                runat="server" Enabled="True" TargetControlID="BuildFrontTextBox"
                                                WatermarkText="0">
                                            </asp:TextBoxWatermarkExtender>
                                            m <b>X</b>
                                            <asp:RegularExpressionValidator ID="BuildFrontRegularExpressionValidator" runat="server"
                                                ControlToValidate="BuildFrontTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ValidationExpression="^[0-9]*\.?[0-9]*$"
                                                ErrorMessage="*"></asp:RegularExpressionValidator>
                                            <asp:TextBox ID="BuildLengthTextBox" runat="server" Text="0" CssClass="input102" ToolTip="Chiều dài"></asp:TextBox>
                                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" 
                                                runat="server" Enabled="True" TargetControlID="BuildLengthTextBox"
                                                WatermarkText="0">
                                            </asp:TextBoxWatermarkExtender>
                                            m
                                            <asp:RegularExpressionValidator ID="BuildLengthRegularExpressionValidator" runat="server"
                                                ControlToValidate="BuildLengthTextBox" CssClass="failureNotification"
                                                Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                ValidationExpression="^[0-9]*\.?[0-9]*$"
                                                ErrorMessage="*"></asp:RegularExpressionValidator>
                                            <%--<asp:UpdatePanel ID="BuildOpenBehindUpdatePanel" runat="server">
                                                <ContentTemplate>--%>
                                                    <asp:CheckBox ID="BuildOpenBehindCheckBox" runat="server" Text="Nở hậu" Font-Bold="true" 
                                                        AutoPostBack="true"
                                                        OnCheckedChanged="BuildOpenBehindCheckBox_CheckedChanged"/>
                                                    <asp:TextBox ID="BuildBehindTextBox" runat="server" Text="0" CssClass="input102" ToolTip="Chiều ngang sau" Visible="false"></asp:TextBox>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" 
                                                        runat="server" Enabled="True" TargetControlID="BuildBehindTextBox"
                                                        WatermarkText="0">
                                                    </asp:TextBoxWatermarkExtender>
                                                    <asp:Label ID="BuildMLabel" runat="server" Visible="false">m</asp:Label>
                                                    <asp:RegularExpressionValidator ID="BuildOpenBehindRegularExpressionValidator" runat="server"
                                                        ControlToValidate="BuildBehindTextBox" Enabled="false" CssClass="failureNotification"
                                                        Display="Dynamic" ValidationGroup="NewsSaleValidationGroup"
                                                        ValidationExpression="^[0-9]*\.?[0-9]*$"
                                                        ErrorMessage="*"></asp:RegularExpressionValidator>
                                                <%--</ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="BuildOpenBehindCheckBox" EventName="checkedchanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>   --%>                 
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ProjectCheckBox" EventName="CheckedChanged" />
                                <asp:AsyncPostBackTrigger ControlID="BuildOpenBehindCheckBox" EventName="checkedchanged" />
                                <asp:AsyncPostBackTrigger ControlID="CampusOpenBehindCheckBox" EventName="checkedchanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </li>
                <li>
                    <div class="TitleStep1">
                        <div class="titL">
                            Đặc điểm & tiện ích
                        </div>
                        <div class="icoR"></div>
                    </div>
                    <div class="stepsDangTaiSan">
                        <div class="ddti">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="69%" valign="top">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td width="48%" class="kc2">
                                                    <b>Tình trạng pháp lý:</b>
                                                </td>
                                                <td width="52%">
                                                    <b>Số phòng khách:</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="kc2">
                                                    <asp:DropDownList ID="LegalDropDownList" runat="server"
                                                        DataSourceID="LegalObjectDataSource"
                                                        DataTextField="Name" CssClass="input163"
                                                        DataValueField="ID">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="LivingRoomDropDownList" CssClass="input163" runat="server">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="kc2"><b>Hướng tài sản:</b></td>
                                                <td><b>Số phòng ngủ:</b></td>
                                            </tr>
                                            <tr>
                                                <td class="kc2">
                                                    <asp:DropDownList ID="DirectionDropDownList" CssClass="input163" runat="server">
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
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="BedRoomDropDownList" CssClass="input163" runat="server">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="kc2"><b>Đường trước nhà:</b></td>
                                                <td><b>Số phòng tắm / vệ sinh:</b></td>
                                            </tr>
                                            <tr>
                                                <td class="kc2">
                                                    <asp:DropDownList ID="FrontStreetDropDownList" CssClass="input163" runat="server">
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
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="BathRoomDropDownList" runat="server" CssClass="input163">
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
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="kc2"><b>Số lầu:</b></td>
                                                <td><b>Số phòng khác:</b></td>
                                            </tr>
                                            <tr>
                                                <td class="kc2">
                                                    <asp:DropDownList ID="StoreyDropDownList" CssClass="input163" runat="server">
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
                                                </td>
                                                <td>
                                                    <asp:DropDownList CssClass="input163" ID="DifferentRoomDropDownList" runat="server">
                                                        <asp:ListItem>Vui lòng chọn...</asp:ListItem>
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="31%" valign="top">
                                        <p class="ti">
                                            <b>Các tiện ích:</b>
                                        </p>
                                        <asp:CheckBoxList ID="UtilityCheckBoxList" runat="server"
                                            DataSourceID="UtilityObjectDataSource"
                                            DataTextField="Name"
                                            DataValueField="ID">
                                            </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="TitleStep1">
                        <div class="titL">Mô tả chi tiết tài sản</div>
                        <div class="icoR"></div>
                    </div>
                    <div class="stepsDangTaiSan">
                        <p>
                            <asp:Label ID="Label2" CssClass="t1" runat="server" ForeColor="Red">
                                Vùng nội dung mô tả này sẽ được kiểm duyệt thông tin trước khi cho phép hiển thị trên RealEstateMarket.vn 
                            </asp:Label>
                            <br />
                            <span class="t2">
                            Tin đăng nhập nội dung theo đúng quy định sẽ được ưu tiên duyệt hiển thị nhanh hơn.
                            Vui lòng nhập tiếng Việt có dấu. Nếu bạn không nhập mô tả, hệ thống sẽ lấy mô tả tự động.
                            </span>
                        </p>
                        <asp:Table ID="DescriptionTable" runat="server">
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
                    </div>
                </li>
                <li>
                    <div class="TitleStep1">
                        <div class="titL">Cập nhật hình ảnh</div>
                        <div class="icoR"></div>
                    </div>
                    <div class="box upload_images">
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
                    </div>
                </li>
                <li>
                    <div class="TitleStep1">
                        <div class="titL">Cập nhật vị trí tài sản trên bản đồ</div>
                        <div class="icoR"></div>
                    </div>
                    <div class="stepsDangTaiSan">
                        Chức năng hiện đang được cập nhật
                    </div>
                </li>
                <li>
                    <div class="TitleStep1">
                        <div class="titL">Liên hệ</div>
                        <div class="icoR"></div>
                    </div>
                    <div class="stepsDangTaiSan">
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
                    </div>
                </li>
                <li>
                    <div class="TitleStep1">
                        <div class="titL">Lưu ý</div>
                        <div class="icoR"></div>
                    </div>
                    <div class="stepsDangTaiSan">
                        <p class="cen">
                        Những mục có dấu <span class="red">*</span> là thông tin phải điền đầy đủ. Chỉ khi
                        bạn hoàn tất những thông tin được yêu cầu điền đầy đủ thì các chức năng <strong>Xem
                            trước</strong> hay <strong>Đăng tài sản</strong> mới được kích hoạt</p>
                        <p class="cen">
                        RealEstateMarket không chịu trách nhiệm về những nội dung (chữ/ hình ảnh/ Video) do bạn
                        đăng tải</p>
                        <p class="cen">Giá tài sản sẽ mặc định thể hiện theo giá VNĐ và quy đổi theo ngân hàng nhà nước tại thời điểm xem tài sản</p>
                        <p class="cen">
                       
                             Khi nhấn nút đăng tài sản, bạn đã xác nhận hoàn toàn đồng ý với những <a href="http://www.diaoconline.vn/quydinhsudung/" target="_blank">Điều
                            khoản đăng tin</a>
                            </p>
                        <div class="note">
                            <asp:Button ID="PreviewButton" CssClass="button" runat="server" Text="Xem trước" OnClick="PreviewButton_Click" />
                            <asp:Button ID="SaveButton" CssClass="button" runat="server" Text="Lưu lại" OnClick="SaveButton_Click" />
                            <asp:Button ID="PostButton" CssClass="button" runat="server" Text="Đăng tài sản" OnClick="PostButton_Click" ValidationGroup="NewsSaleValidationGroup"/>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</div>
        <asp:Label ID="ErrorLabel" runat="server" CssClass="failureNotification"></asp:Label>

    <asp:ObjectDataSource ID="UtilityObjectDataSource" runat="server" 
        SelectMethod="GetAllUtilities" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LegalObjectDataSource" runat="server"
        SelectMethod="GetAllLegals"
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
</asp:Content>
