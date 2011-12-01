<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.AddressControl" %>

<asp:ObjectDataSource ID="NationObjectDataSource" runat="server" 
    SelectMethod="GetAllNations" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

<asp:ObjectDataSource ID="CityObjectDataSource" runat="server" 
    SelectMethod="GetCitiesByNationID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    <SelectParameters>
        <asp:ControlParameter ControlID="NationDropDownList" Name="id" PropertyName="SelectedValue" 
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="DistrictObjectDataSource" runat="server" 
    SelectMethod="GetDistrictsByCityID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    <SelectParameters>
        <asp:ControlParameter ControlID="CityDropDownList" Name="id" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>    
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="WardObjectDataSource" runat="server"
    SelectMethod="GetWardsByDistrictID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" >
    <SelectParameters>
        <asp:ControlParameter ControlID="DistrictDropDownList" Name="id" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:ObjectDataSource ID="StreetObjectDataSource" runat="server" 
    SelectMethod="GetStreetsByDistrictID" 
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    <SelectParameters>
        <asp:ControlParameter ControlID="DistrictDropDownList" Name="id" 
            PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:Panel ID="mainPanel" runat="server"
    BorderStyle="None">
            <asp:Table ID="AddressTable" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="NationLabel" AssociatedControlID="NationDropDownList">Quốc gia</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="CityLabel" AssociatedControlID="CityDropDownList">Tỉnh / Thành phố</asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList ID="NationDropDownList" runat="server"
                        DataSourceID="NationObjectDataSource"
                        DataTextField="Name"
                        DataValueField="ID"
                        onselectedindexchanged="NationDropDownList_SelectedIndexChanged"
                        AutoPostBack="true"></asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>                    
                    <asp:UpdatePanel ID="CityUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="CityDropDownList" runat="server"
                                DataSourceID="CityObjectDataSource"
                                DataTextField="Name"
                                DataValueField="ID"
                                onselectedindexchanged="CityDropDownList_SelectedIndexChanged"
                                AutoPostBack="true"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="NationDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="DistrictLabel" AssociatedControlID="DistrictDropDownList">Quận / Huyện</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="WardLabel" AssociatedControlID="WardDropDownList">Phường / Xã</asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:UpdatePanel ID="DistrictUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="DistrictDropDownList" runat="server"
                                DataSourceID="DistrictObjectDataSource"
                                DataTextField="Name"
                                DataValueField="ID"
                                onselectedindexchanged="DistrictDropDownList_SelectedIndexChanged"
                                AutoPostBack="true"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="CityDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:UpdatePanel ID="WardUpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="WardDropDownList" runat="server"
                                DataSourceID="WardObjectDataSource"
                                DataTextField="Name"
                                DataValueField="ID"
                                onselectedindexchanged="WardDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="WardCheckBox" runat="server" Text="Khác" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>
                    <asp:Label ID="DetailLabel" runat="server" AssociatedControlID="DetailTextBox">Số nhà / Số lô</asp:Label>
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    <asp:Label runat="server" ID="StreetLabel" AssociatedControlID="StreetDropDownList">Tên Đường / Tên Phố</asp:Label>
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox ID="DetailTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="StreetDropDownList" runat="server"
                                DataSourceID="StreetObjectDataSource"
                                DataTextField="Name"
                                DataValueField="ID"
                                onselectedindexchanged="StreetDropDownList_SelectedIndexChanged"></asp:DropDownList>        
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>                    
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="StreetCheckBox" runat="server" Text="Khác" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
</asp:Panel>
