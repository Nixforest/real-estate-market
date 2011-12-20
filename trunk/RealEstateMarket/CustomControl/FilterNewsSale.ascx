<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterNewsSale.ascx.cs" Inherits="RealEstateMarket.CustomControl.FilterNewsSale" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .cpHeader
    {
        color: white;
        background-color: #719DDB;
        font: bold 11px auto "Trebuchet MS", Verdana;
        font-size: 12px;
        cursor: pointer;
        width:160px;
        height:18px;
        padding: 4px;           
    }
    .cpBody
    {
        background-color: #DCE4F9;
        font: normal 11px auto Verdana, Arial;
        border: 1px gray;               
        width:160px;
        padding: 4px;
        padding-top: 7px;
    }      
</style>
<asp:ObjectDataSource ID="NewsSaleTypeObjectDataSource" runat="server" 
    SelectMethod="GetAllNewsSaleTypes" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="RealEstateTypeObjectDataSource" runat="server" 
    SelectMethod="GetAllRealEstateTypes" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <%--News Sale Type--%>
        <asp:Panel ID="NewsSaleTypeHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="NewsSaleTypeImage" runat="server" />
            <asp:Label ID="NewsSaleTypeLabel" runat="server" Text="Loại tin đăng" />
        </asp:Panel>        
        <asp:Panel ID="NewsSaleTypeBodyPanel" runat="server" CssClass="cpBody">
            <asp:RadioButtonList ID="NewsSaleTypeRadioButtonList"
                runat="server"
                DataSourceID="NewsSaleTypeObjectDataSource"
                DataTextField="Name"
                DataValueField="ID" RepeatDirection="Vertical">
            </asp:RadioButtonList>
            <asp:ImageButton ID="FilterNewsSaleTypeImageButton" runat="server" 
                ImageUrl="~/Images/images/ico_36.gif"
                OnClick="FilterNewsSaleTypeImageButton_Click" />
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="NewsSaleTypeCollapsiblePanelExtender" runat="server"
            TargetControlID="NewsSaleTypeBodyPanel" AutoExpand="true"
            CollapseControlID="NewsSaleTypeHeaderPanel" ExpandControlID="NewsSaleTypeHeaderPanel"
            Collapsed="true" ImageControlID="NewsSaleTypeImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"   
            CollapsedSize="0"></asp:CollapsiblePanelExtender>
        
        <%--Real Estate Type--%>
        <asp:Panel ID="RealEstateTypeHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="RealEstateTypeImage" runat="server" />
            <asp:Label ID="RealEstateTypeLabel" runat="server" Text="Loại địa ốc" />
        </asp:Panel>        
        <asp:Panel ID="RealEstateTypeBodyPanel" runat="server" CssClass="cpBody">
            <asp:RadioButtonList ID="RealEstateTypeRadioButtonList" runat="server"
                DataSourceID="RealEstateTypeObjectDataSource"
                DataTextField="Name"
                DataValueField="ID">
                </asp:RadioButtonList>
            <asp:ImageButton ID="RealEstateTypeImageButton" runat="server" 
                ImageUrl="~/Images/images/ico_36.gif"
                OnClick="FilterRealEstateTypeImageButton_Click" />
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="RealEstateTypeCollapsiblePanelExtender" runat="server"
            TargetControlID="RealEstateTypeBodyPanel" AutoExpand="true"
            CollapseControlID="RealEstateTypeHeaderPanel" ExpandControlID="RealEstateTypeHeaderPanel"
            Collapsed="true" ImageControlID="RealEstateTypeImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"            
            CollapsedSize="0"></asp:CollapsiblePanelExtender>

        <%--Price--%>
        <asp:Panel ID="PriceHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="PriceImage" runat="server" />
            <asp:Label ID="PriceLabel" runat="server" Text="Khoảng giá" />
        </asp:Panel>        
        <asp:Panel ID="PriceBodyPanel" runat="server" CssClass="cpBody">
            <asp:HyperLink ID="AllHyperLink" runat="server" NavigateUrl="~/Pages/NewsSale/NewsSales.aspx">Tất cả</asp:HyperLink><br />
            <asp:HyperLink ID="FiveMillionLowerHyperLink" runat="server" Text="Dưới 5 triệu"
                NavigateUrl="">
                </asp:HyperLink><br />
            <asp:HyperLink ID="FiveToTwentyMillionHyperLink" runat="server" NavigateUrl="">5 triệu - 20 triệu</asp:HyperLink><br />
            <asp:HyperLink ID="TwentyToOneHundredMillionHyperLink" runat="server" NavigateUrl="">20 triệu - 100 triệu</asp:HyperLink><br />
            <asp:HyperLink ID="OneHundredToFiveHundredMillionHyperLink" runat="server" NavigateUrl="">100 triệu - 500 triệu</asp:HyperLink><br />
            <asp:HyperLink ID="FiveHundredMillionToOneBillionHyperLink" runat="server" NavigateUrl="">500 triệu - 1,2 tỷ</asp:HyperLink><br />
            <asp:HyperLink ID="OneBillionToTwoBillionHyperLink" runat="server" NavigateUrl="">1,2 tỷ - 2 tỷ</asp:HyperLink><br />
            <asp:HyperLink ID="TwoBillionToThreeBillionHyperLink" runat="server" NavigateUrl="">2 tỷ - 3 tỷ</asp:HyperLink><br />
            <asp:HyperLink ID="ThreeBillionToFiveBillionHyperLink" runat="server" NavigateUrl="">3 tỷ - 5 tỷ</asp:HyperLink><br />
            <asp:HyperLink ID="FiveBillionHigherHyperLink" runat="server" NavigateUrl="">Trên 5 tỷ</asp:HyperLink><br />
            <asp:DropDownList ID="FromPriceDropDownList" runat="server">
                <asp:ListItem Value="0">Từ</asp:ListItem>
                <asp:ListItem Value="3000000">3 triệu</asp:ListItem>
                <asp:ListItem Value="5000000">5 triệu</asp:ListItem>
                <asp:ListItem Value="10000000">10 triệu</asp:ListItem>
                <asp:ListItem Value="20000000">20 triệu</asp:ListItem>
                <asp:ListItem Value="50000000">50 triệu</asp:ListItem>
                <asp:ListItem Value="100000000">100 triệu</asp:ListItem>
                <asp:ListItem Value="250000000">250 triệu</asp:ListItem>
                <asp:ListItem Value="500000000">500 triệu</asp:ListItem>
                <asp:ListItem Value="1000000000">1 tỷ</asp:ListItem>
                <asp:ListItem Value="1500000000">1,5 tỷ</asp:ListItem>
                <asp:ListItem Value="2000000000">2 tỷ</asp:ListItem>
                <asp:ListItem Value="3000000000">3 tỷ</asp:ListItem>
                <asp:ListItem Value="5000000000">5 tỷ</asp:ListItem>
                <asp:ListItem Value="10000000000">10 tỷ</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ToPriceDropDownList" runat="server">
                <asp:ListItem Value="79228162514264337593543950335">Đến</asp:ListItem>
                <asp:ListItem Value="3000000">3 triệu</asp:ListItem>
                <asp:ListItem Value="5000000">5 triệu</asp:ListItem>
                <asp:ListItem Value="10000000">10 triệu</asp:ListItem>
                <asp:ListItem Value="20000000">20 triệu</asp:ListItem>
                <asp:ListItem Value="50000000">50 triệu</asp:ListItem>
                <asp:ListItem Value="100000000">100 triệu</asp:ListItem>
                <asp:ListItem Value="250000000">250 triệu</asp:ListItem>
                <asp:ListItem Value="500000000">500 triệu</asp:ListItem>
                <asp:ListItem Value="1000000000">1 tỷ</asp:ListItem>
                <asp:ListItem Value="1500000000">1,5 tỷ</asp:ListItem>
                <asp:ListItem Value="2000000000">2 tỷ</asp:ListItem>
                <asp:ListItem Value="3000000000">3 tỷ</asp:ListItem>
                <asp:ListItem Value="5000000000">5 tỷ</asp:ListItem>
                <asp:ListItem Value="10000000000">10 tỷ</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="FilterImageButton" runat="server" 
                ImageUrl="~/Images/images/ico_36.gif" 
                OnClick="FilterImageButton_Click"/>
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="PriceCollapsiblePanelExtender" runat="server"
            TargetControlID="PriceBodyPanel" AutoExpand="true"
            CollapseControlID="PriceHeaderPanel" ExpandControlID="PriceHeaderPanel"
            Collapsed="true" ImageControlID="PriceImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"            
            CollapsedSize="0"></asp:CollapsiblePanelExtender>
            
        <%--Use area--%>
        <asp:Panel ID="AreaHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="AreaImage" runat="server" />
            <asp:Label ID="AreaLabel" runat="server" Text="Diện tích sử dụng" />
        </asp:Panel>        
        <asp:Panel ID="AreaBodyPanel" runat="server" CssClass="cpBody">
            <asp:TextBox ID="FromAreaTextBox" runat="server">Từ</asp:TextBox>
            <asp:RegularExpressionValidator ID="FromAreaRegularExpressionValidator" runat="server"
                ControlToValidate="FromAreaTextBox" CssClass="failureNotification"
                Display="Dynamic" ValidationGroup="AreaValidationGroup"
                ValidationExpression="^[0-9]*\.?[0-9]*$" ErrorMessage="Nhập Diện tích chưa hợp lệ"></asp:RegularExpressionValidator>
            <asp:TextBox ID="ToAreaTextBox" runat="server">Đến</asp:TextBox>
            <asp:RegularExpressionValidator ID="ToAreaRegularExpressionValidator" runat="server"
                ControlToValidate="ToAreaTextBox" CssClass="failureNotification"
                Display="Dynamic" ValidationGroup="AreaValidationGroup"
                ValidationExpression="^[0-9]*\.?[0-9]*$" ErrorMessage="Nhập Diện tích chưa hợp lệ"></asp:RegularExpressionValidator>
            <asp:ImageButton ID="AreaImageButton" runat="server"
                ImageUrl="~/Images/images/ico_36.gif"
                OnClick="AreaImageButton_Click" ValidationGroup="AreaValidationGroup" />
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="AreaCollapsiblePanelExtender" runat="server"
            TargetControlID="AreaBodyPanel" AutoExpand="true"
            CollapseControlID="AreaHeaderPanel" ExpandControlID="AreaHeaderPanel"
            Collapsed="true" ImageControlID="AreaImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"   
            CollapsedSize="0"></asp:CollapsiblePanelExtender>

        <%--Project--%>
        <asp:ObjectDataSource ID="CityObjectDataSource" runat="server" 
            SelectMethod="GetAllCities" 
            TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="DistrictObjectDataSource" runat="server" 
            SelectMethod="GetDistrictsByCityID" 
            TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
            <SelectParameters>
                <asp:ControlParameter ControlID="CityDropDownList" Name="id" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>    
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ProjectObjectDataSource" runat="server" 
            SelectMethod="GetProjectsByDistrictID" 
            TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"> 
            <SelectParameters>
                <asp:ControlParameter ControlID="DistrictDropDownList" Name="districtID" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Panel ID="ProjectHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="ProjectImage" runat="server" />
            <asp:Label ID="ProjectLabel" runat="server" Text="Dự án" />
        </asp:Panel>        
        <asp:Panel ID="ProjectBodyPanel" runat="server" CssClass="cpBody">
            <asp:DropDownList ID="CityDropDownList" runat="server"
                DataSourceID="CityObjectDataSource"
                DataTextField="Name"
                DataValueField="ID"
                onselectedindexchanged="CityDropDownList_SelectedIndexChanged"
                AutoPostBack="true"></asp:DropDownList>
            <asp:DropDownList ID="DistrictDropDownList" runat="server"
                DataSourceID="DistrictObjectDataSource"
                DataTextField="Name"
                DataValueField="ID"
                onselectedindexchanged="DistrictDropDownList_SelectedIndexChanged"
                AutoPostBack="true"></asp:DropDownList>
            <asp:DropDownList ID="ProjectDropDownList" runat="server"
                DataSourceID="ProjectObjectDataSource"
                DataTextField="Name"
                DataValueField="ID"></asp:DropDownList>
            <br />                
            <asp:ImageButton ID="ProjectImageButton" runat="server" 
                ImageUrl="~/Images/images/ico_36.gif" 
                OnClick="ProjectImageButton_Click"/>
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="ProjectCollapsiblePanelExtender" runat="server"
            TargetControlID="ProjectBodyPanel" AutoExpand="true"
            CollapseControlID="ProjectHeaderPanel" ExpandControlID="ProjectHeaderPanel"
            Collapsed="true" ImageControlID="ProjectImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"   
            CollapsedSize="0"></asp:CollapsiblePanelExtender>

        <%--Location--%>
        <asp:ObjectDataSource ID="LocationObjectDataSource" runat="server" 
            SelectMethod="GetFullLocations" 
            TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
        <asp:Panel ID="LocationHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="LocationImage" runat="server" />
            <asp:Label ID="LocationLabel" runat="server" Text="Vị trí Địa ốc" />
        </asp:Panel>        
        <asp:Panel ID="LocationBodyPanel" runat="server" CssClass="cpBody">
            <asp:RadioButtonList ID="LocationRadioButtonList" runat="server"
                DataSourceID="LocationObjectDataSource"
                DataTextField="Name"
                DataValueField="ID">
                </asp:RadioButtonList>
            <asp:ImageButton ID="LocationImageButton" runat="server" 
                ImageUrl="~/Images/images/ico_36.gif" 
                OnClick="LocationImageButton_Click"/>
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
            TargetControlID="LocationBodyPanel" AutoExpand="true"
            CollapseControlID="LocationHeaderPanel" ExpandControlID="LocationHeaderPanel"
            Collapsed="true" ImageControlID="LocationImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"   
            CollapsedSize="0"></asp:CollapsiblePanelExtender>

        <%--Bedroom--%>
        <asp:Panel ID="BedRoomHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="BedRoomImage" runat="server" />
            <asp:Label ID="BedRoomLabel" runat="server" Text="Số phòng ngủ" />
        </asp:Panel>        
        <asp:Panel ID="BedRoomBodyPanel" runat="server" CssClass="cpBody">
            <asp:HyperLink ID="OneLink" runat="server" NavigateUrl="">Lớn hơn 1</asp:HyperLink><br />
            <asp:HyperLink ID="TwoLink" runat="server" NavigateUrl="">Lớn hơn 2</asp:HyperLink><br />
            <asp:HyperLink ID="ThreeLink" runat="server" NavigateUrl="">Lớn hơn 3</asp:HyperLink><br />
            <asp:HyperLink ID="FourLink" runat="server" NavigateUrl="">Lớn hơn 4</asp:HyperLink><br />
            <asp:TextBox ID="FromBedRoomTextBox" runat="server">Từ</asp:TextBox>
            <asp:RegularExpressionValidator ID="FromBedRegularExpressionValidator" runat="server"
                ControlToValidate="FromBedRoomTextBox" CssClass="failureNotification"
                Display="Dynamic" ValidationGroup="BedValidationGroup"
                ValidationExpression="^[0-9]*$" ErrorMessage="Số phòng ngủ chưa hợp lệ"></asp:RegularExpressionValidator>
            <asp:TextBox ID="ToBedRoomTextBox" runat="server">Đến</asp:TextBox>
            <asp:RegularExpressionValidator ID="ToBedRegularExpressionValidator" runat="server"
                ControlToValidate="ToBedRoomTextBox" CssClass="failureNotification"
                Display="Dynamic" ValidationGroup="BedValidationGroup"
                ValidationExpression="^[0-9]*$" ErrorMessage="Số phòng ngủ chưa hợp lệ"></asp:RegularExpressionValidator>
            <asp:ImageButton ID="BedRoomImageButton" runat="server"
                ImageUrl="~/Images/images/ico_36.gif"
                OnClick="BedRoomImageButton_Click" ValidationGroup="BedValidationGroup" />
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="BedRoomCollapsiblePanelExtender" runat="server"
            TargetControlID="BedRoomBodyPanel" AutoExpand="true"
            CollapseControlID="BedRoomHeaderPanel" ExpandControlID="BedRoomHeaderPanel"
            Collapsed="true" ImageControlID="BedRoomImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"            
            CollapsedSize="0"></asp:CollapsiblePanelExtender>

        <%--Direction--%>
        <asp:Panel ID="DirectionHeaderPanel" runat="server" CssClass="cpHeader">
            <asp:Image ID="DirectionImage" runat="server" />
            <asp:Label ID="DirectionLabel" runat="server" Text="Hướng" />
        </asp:Panel>        
        <asp:Panel ID="DirectionBodyPanel" runat="server" CssClass="cpBody">
            <asp:RadioButtonList ID="DirectionRadioButtonList" runat="server">
                <asp:ListItem>Đông</asp:ListItem>
                <asp:ListItem>Tây</asp:ListItem>
                <asp:ListItem>Nam</asp:ListItem>
                <asp:ListItem>Bắc</asp:ListItem>
                <asp:ListItem>Đông Bắc</asp:ListItem>
                <asp:ListItem>Đông Nam</asp:ListItem>
                <asp:ListItem>Tây Bắc</asp:ListItem>
                <asp:ListItem>Tây Nam</asp:ListItem>
                <asp:ListItem>Không xác định</asp:ListItem>
            </asp:RadioButtonList>
            <asp:ImageButton ID="DirectionImageButton" runat="server"
                ImageUrl="~/Images/images/ico_36.gif"
                OnClick="DirectionImageButton_Click"/>            
        </asp:Panel> 
        <asp:CollapsiblePanelExtender ID="DirectionCollapsiblePanelExtender" runat="server"
            TargetControlID="DirectionBodyPanel" AutoExpand="true"
            CollapseControlID="DirectionHeaderPanel" ExpandControlID="DirectionHeaderPanel"
            Collapsed="true" ImageControlID="DirectionImage"
            CollapsedImage="~/Image/icon_down.gif" ExpandedImage="~/Image/icon_up.png"            
            CollapsedSize="0"></asp:CollapsiblePanelExtender>
        <asp:ImageButton ID="NonBrokerImageButton" runat="server"
            ImageUrl="~/Image/btn_taisanchinhchu.gif" 
            OnClick="NonBrokerImageButton_Click" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="CityDropDownList" EventName="selectedindexchanged" />
    </Triggers>
</asp:UpdatePanel>
