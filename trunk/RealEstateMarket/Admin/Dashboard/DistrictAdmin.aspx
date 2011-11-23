<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DistrictAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.DistrictAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h4>
		Cập nhật thông tin các Quận/Huyện
	</h4>
	<asp:ObjectDataSource ID="dataSource" runat="server" 
		DeleteMethod="DeleteDistrict" InsertMethod="InsertDistrict" 
		SelectMethod="GetAllDistricts" 
		TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
		UpdateMethod="UpdateDistrict" OldValuesParameterFormatString="original_{0}">
		<DeleteParameters>
			<asp:Parameter Name="id" Type="Int32" />
		</DeleteParameters>
		<InsertParameters>
			<asp:Parameter Name="name" Type="String" />
			<asp:Parameter Name="cityID" Type="Int32" />
		</InsertParameters>
		<UpdateParameters>
			<asp:Parameter Name="id" Type="Int32" />
			<asp:Parameter Name="name" Type="String" />
			<asp:Parameter Name="cityID" Type="Int32" />
		</UpdateParameters>
	</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="dataSourceCity" runat="server" 
		SelectMethod="GetAllCities" 
		TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="dataSourceStreet" runat="server" 
        SelectMethod="GetStreetsNotInDistrict"
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlDistrict" Name="id" 
                    PropertyName="SelectedValue"/>
            </SelectParameters>
    </asp:ObjectDataSource>
    
    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="GetStreetsNotInDistrict"         
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlDistrict" Name="id" 
                    PropertyName="SelectedValue"/>
            </SelectParameters>
    </asp:ObjectDataSource>--%>

	<asp:Table runat="server">
		<asp:TableRow>
			<asp:TableCell>
				<asp:GridView ID="dataTable" runat="server" AllowPaging="True" 
					AutoGenerateColumns="False" DataSourceID="dataSource" 
		            DataKeyNames="ID" BackColor="White" BorderColor="#336666" BorderStyle="Double" 
		            BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
					<Columns>
						<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
						<asp:TemplateField HeaderText="STT">
							<ItemTemplate>
								<%# Container.DataItemIndex + 1 %>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField="Name" HeaderText="Quận" SortExpression="Name" />
						<asp:TemplateField HeaderText="Thành Phố">
							<ItemTemplate>
								<asp:DropDownList ID="DropDownList1" runat="server" 
                                    DataSourceID="dataSourceCity"
									DataTextField="Name"
									DataValueField="ID"
									Enabled="false"
									SelectedValue='<%# Bind("CityID") %>'>
								</asp:DropDownList>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="dataSourceCity"
									DataTextField="Name"
									DataValueField="ID"
									SelectedValue='<%# Bind("CityID") %>'>
								</asp:DropDownList>
							</EditItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
							SortExpression="ID" />
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
                <asp:Table runat="server" BorderColor="AliceBlue">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label1" runat="server">District Name</asp:Label>
				            <br />
				            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
				            <br />
				            <asp:Label ID="Label2" runat="server">City</asp:Label>
				            <br />
				            <asp:DropDownList runat="server" ID="ddlCity"
					            DataSourceID="dataSourceCity"
					            DataTextField="Name"
					            DataValueField="ID" AutoPostBack="true"></asp:DropDownList>
				            <br />
				            <asp:Button ID="Insert" runat="server" OnClick="Insert_Click" Text="Insert" />
				            <br />
				            <asp:Label ID="error" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:DropDownList runat="server" ID="ddlDistrict"
					            DataSourceID="dataSource"
					            DataTextField="Name"
					            DataValueField="ID" 
                                onselectedindexchanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>				
			</asp:TableCell>
            <asp:TableCell>
                <asp:GridView ID="dataTableStreet" runat="server" PageSize="20"
                    DataSourceID="dataSourceStreet" AutoGenerateColumns="False" 
                    AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" 
                    BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
                    onselectedindexchanged="dataTableStreet_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
			            <asp:TemplateField HeaderText="STT">
				            <ItemTemplate>
					            <%# Container.DataItemIndex + 1 %>
				            </ItemTemplate>
			            </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Tên Đường Phố" SortExpression="Name" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="#0066FF" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>     
            </asp:TableCell>
		</asp:TableRow>
	</asp:Table>
	
</asp:Content>
