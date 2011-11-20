<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WardAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.WardAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>
        Cập nhật thông tin các Phường, Xã
    </h4>
    <asp:ObjectDataSource ID="dataSource" runat="server" DeleteMethod="DeleteWard" 
        InsertMethod="InsertWard" SelectMethod="GetAllWards" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" UpdateMethod="UpdateWard"
        >
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="districtID" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="districtID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="dataSourceDistrict" runat="server" 
        SelectMethod="GetAllDistricts" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="dataTable" runat="server" AllowPaging="True"
                    DataKeyNames="ID" 
                    AutoGenerateColumns="False" DataSourceID="dataSource" BackColor="White" 
                    BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                    GridLines="Horizontal">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Tên" />
                        <asp:TemplateField HeaderText="Quận">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl" runat="server"
                                    DataSourceID="dataSourceDistrict"
                                    DataTextField="Name"
                                    DataValueField="ID"
                                    Enabled="false"
                                    SelectedValue='<%# Bind("DistrictID") %>'></asp:DropDownList>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl" runat="server"
                                    DataSourceID="dataSourceDistrict"
                                    DataTextField="Name"
                                    DataValueField="ID"
                                    SelectedValue='<%# Bind("DistrictID") %>'></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" 
                            ReadOnly="True" />
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server">Tên Phường/Xã:</asp:Label>
				<br />
				<asp:TextBox runat="server" ID="txtName"></asp:TextBox>
				<br />
				<asp:Label ID="Label2" runat="server">Quận:</asp:Label>
				<br />
				<asp:DropDownList runat="server" ID="ddlDistrict"
					DataSourceID="dataSourceDistrict"
					DataTextField="Name"
					DataValueField="ID"></asp:DropDownList>
				<br />
				<asp:Button ID="Insert" runat="server" OnClick="Insert_Click" Text="Insert" />
				<br />
				<asp:Label ID="error" runat="server" Text="Label"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
