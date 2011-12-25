<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.AddressControl"%>

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
<style type="text/css">
.kc
{
    height:25px;
}
.kc1
{
    height:30px;
}
input {
    font-family: arial;
    font-size: 12px;
    color: #333;
    padding: 1px;
}
select {
    font-family: arial;
    font-size: 12px;
    color: #333;
    padding: 1px;
}
.input163 {
    width: 163px;
    border: 1px solid #7F9DB9;
    border-image: initial;
}
.input233 {
    width: 233px;
    border: 1px solid #7F9DB9;
    border-image: initial;
}
.input163_a {
    width: 163px;
    border: 1px solid #7F9DB9;
    height: 17px;
    border-image: initial;
}
</style>
<asp:UpdatePanel ID="CityUpdatePanel" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td class="kc">
                    <asp:Label runat="server" ID="NationLabel" AssociatedControlID="NationDropDownList" Font-Bold="true">Quốc gia</asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="CityLabel" AssociatedControlID="CityDropDownList" Font-Bold="true">Tỉnh / Thành phố</asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td height="30" class="kc1">
                    <asp:DropDownList ID="NationDropDownList" runat="server"
                        DataSourceID="NationObjectDataSource"
                        DataTextField="Name" CssClass="input163"
                        DataValueField="ID"
                        onselectedindexchanged="NationDropDownList_SelectedIndexChanged"
                        AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                    <%--<asp:UpdatePanel ID="CityUpdatePanel" runat="server">
                        <ContentTemplate>--%>
                            <asp:DropDownList ID="CityDropDownList" runat="server"
                                DataSourceID="CityObjectDataSource"
                                DataTextField="Name"
                                DataValueField="ID" CssClass="input233"
                                onselectedindexchanged="CityDropDownList_SelectedIndexChanged"
                                AutoPostBack="true"></asp:DropDownList>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="NationDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>       --%>             
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="kc1">
                    <asp:Label runat="server" ID="DistrictLabel" Font-Bold="true" AssociatedControlID="DistrictDropDownList">Quận / Huyện</asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="WardLabel" Font-Bold="true" AssociatedControlID="WardDropDownList">Phường / Xã</asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="kc1" id="idDistrict">
                    <%--<asp:UpdatePanel ID="DistrictUpdatePanel" runat="server">
                        <ContentTemplate>--%>
                            <asp:DropDownList ID="DistrictDropDownList" runat="server"
                                DataSourceID="DistrictObjectDataSource"
                                DataTextField="Name" CssClass="input163"
                                DataValueField="ID"
                                onselectedindexchanged="DistrictDropDownList_SelectedIndexChanged"
                                AutoPostBack="true">
                                </asp:DropDownList>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="CityDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>   --%>                 
                </td>
                <td id="idWard">
                    <%--<asp:UpdatePanel ID="WardUpdatePanel" runat="server">
                        <ContentTemplate>--%>
                            <asp:DropDownList ID="WardDropDownList" runat="server"
                                DataSourceID="WardObjectDataSource"
                                DataTextField="Name"
                                DataValueField="ID" CssClass="input233"
                                onselectedindexchanged="WardDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>   --%>                 
                </td>
                <td>
                    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                            <asp:CheckBox ID="DifferentCheckBox" runat="server" Enabled="true" OnCheckedChanged="DifferentCheckBox_CheckedChanged"
                                ToolTip="Không cập nhật vị trí Quận, Huyện, Đường phố, bạn có thể nhập Chi tiết Địa chỉ" Text="Khác"
                                AutoPostBack="true" Font-Bold="true"/>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DifferentCheckBox" EventName="CheckedChanged" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td class="kc1">
                    <asp:Label ID="DetailLabel" runat="server" Font-Bold="true" AssociatedControlID="DetailTextBox">Số nhà / Số lô</asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="StreetLabel" Font-Bold="true" AssociatedControlID="StreetDropDownList">Tên Đường / Tên Phố</asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td class="kc1">
                    <asp:TextBox ID="DetailTextBox" CssClass="input163_a" runat="server"></asp:TextBox>
                </td>
                <td>
                    <%--<asp:UpdatePanel runat="server">
                        <ContentTemplate>--%>
                            <asp:DropDownList ID="StreetDropDownList" runat="server"
                                DataSourceID="StreetObjectDataSource"
                                DataTextField="Name"
                                DataValueField="ID" CssClass="input233"
                                onselectedindexchanged="StreetDropDownList_SelectedIndexChanged"></asp:DropDownList>        
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
                        </Triggers>
                    </asp:UpdatePanel>     --%>               
                </td>
                <td>
                    <%--<asp:CheckBox ID="StreetCheckBox" runat="server" Text="Khác" />--%>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="NationDropDownList" EventName="selectedindexchanged" />
        <asp:AsyncPostBackTrigger ControlID="CityDropDownList" EventName="selectedindexchanged" />
        <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
        <asp:AsyncPostBackTrigger ControlID="DifferentCheckBox" EventName="CheckedChanged" />
    </Triggers>
</asp:UpdatePanel>
