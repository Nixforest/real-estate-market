<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.AddressControl" %>

<asp:ObjectDataSource ID="dataSourceNation" runat="server" 
    SelectMethod="GetAllNations" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="dataSourceCity" runat="server" 
    SelectMethod="GetCitiesByNationID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    <SelectParameters>
        <asp:ControlParameter ControlID="ddlNation" Name="id" PropertyName="SelectedValue" 
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dataSourceDistrict" runat="server" 
    SelectMethod="GetDistrictsByCityID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    <SelectParameters>
        <asp:ControlParameter ControlID="ddlCity" Name="id" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>    
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dataSourceWard" runat="server"
    SelectMethod="GetWardsByDistrictID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" >
    <SelectParameters>
        <asp:ControlParameter ControlID="ddlDistrict" Name="id" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="dataSourceStreet" runat="server" 
    SelectMethod="GetStreetsByDistrictID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    <SelectParameters>
        <asp:ControlParameter ControlID="ddlDistrict" Name="id" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:Panel ID="mainPanel" runat="server"
    BorderStyle="Solid">
            <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="lblNation">Quốc gia</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="lblCity">Tỉnh / Thành phố</asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlNation" runat="server"
                        DataSourceID="dataSourceNation"
                        DataTextField="Name"
                        DataValueField="ID"
                        onselectedindexchanged="ddlNation_SelectedIndexChanged"
                        AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlCity" runat="server"
                        DataSourceID="dataSourceCity"
                        DataTextField="Name"
                        DataValueField="ID"
                        onselectedindexchanged="ddlCity_SelectedIndexChanged"
                        AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="lblDistrict">Quận / Huyện</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="lblWard">Phường / Xã</asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlDistrict" runat="server"
                        DataSourceID="dataSourceDistrict"
                        DataTextField="Name"
                        DataValueField="ID"
                        onselectedindexchanged="ddlDistrict_SelectedIndexChanged"
                        AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlWard" runat="server"
                        DataSourceID="dataSourceWard"
                        DataTextField="Name"
                        DataValueField="ID"
                        onselectedindexchanged="ddlWard_SelectedIndexChanged"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="cbWard" runat="server" Text="Khác" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label ID="lblDetail" runat="server">Số nhà / Số lô</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="lblStreet">Tên Đường / Tên Phố</asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="tbxDetail" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlStreet" runat="server"
                        DataSourceID="dataSourceStreet"
                        DataTextField="Name"
                        DataValueField="ID"
                        onselectedindexchanged="ddlStreet_SelectedIndexChanged"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="cbStreet" runat="server" Text="Khác" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</asp:Panel>
