<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DistrictAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.DistrictAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h4>
		Cập nhật thông tin các Quận/Huyện
	</h4>
	<asp:ObjectDataSource ID="DistrictObjectDataSource" runat="server" 
		DeleteMethod="DeleteDistrict" InsertMethod="InsertDistrict" 
		SelectMethod="GetAllDistricts" 
		TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
		UpdateMethod="UpdateDistrict">
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

	<asp:ObjectDataSource ID="CityObjectDataSource" runat="server" 
		SelectMethod="GetAllCities" 
		TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="StreetObjectDataSource" runat="server" 
        SelectMethod="GetStreetsNotInDistrict"
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="DistrictDropDownList" Name="id" 
                    PropertyName="SelectedValue"/>
            </SelectParameters>
    </asp:ObjectDataSource>

	<asp:Table runat="server">
		<asp:TableRow>
			<asp:TableCell>
				<asp:GridView ID="DistrictGridView" runat="server" AllowPaging="True" 
					AutoGenerateColumns="False" DataSourceID="DistrictObjectDataSource" 
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
								<%# RealEstateMarket._Default.db.GetCity(Convert.ToInt32(Eval("CityID"))).Name %>
							</ItemTemplate>
							<EditItemTemplate>
								<asp:DropDownList ID="CityDistrictDropDownList" runat="server" DataSourceID="CityObjectDataSource"
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
                            <table>
                                <tr>
                                    <p>
                                        Cập nhật thông tin cho các quận
                                    </p>
                                    <p>
                                        <asp:ValidationSummary ID="InsertDistrictValidationSummary" runat="server"
                                            CssClass="failureNotification"
                                            HeaderText="Bạn phải điền vào các phần còn thiếu"
                                            ValidationGroup="InsertDistrictValidationGroup" />
                                    </p>
                                    <p>
                                        <asp:Label ID="ErrorLabel" runat="server" CssClass="failureNotification"></asp:Label>
                                    </p>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="DistrictNameLabel" AssociatedControlID="DistrictNameTextBox" runat="server">District Name</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="DistrictNameTextBox" ToolTip="Nhập Tên Quận"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="DistrictNameRequiredFieldValidator" runat="server"
                                            ControlToValidate="DistrictNameTextBox" InitialValue=""
                                            ErrorMessage="Bạn chưa nhập tên Quận" CssClass="failureNotification"
                                            ValidationGroup="InsertDistrictValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="CityLabel" runat="server" AssociatedControlID="CityDropDownList">City</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="CityDropDownList"
					                        DataSourceID="CityObjectDataSource"
					                        DataTextField="Name"
					                        DataValueField="ID"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="InsertDistrictButton" runat="server" OnClick="InsertDistrictButton_Click" Text="Thêm mới Quận" 
                                            ValidationGroup="InsertDistrictValidationGroup" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList runat="server" ID="DistrictDropDownList"
					                        DataSourceID="DistrictObjectDataSource"
					                        DataTextField="Name"
					                        DataValueField="ID"  AutoPostBack="true"
                                            onselectedindexchanged="DistrictDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>				            
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>				
			</asp:TableCell>
            <asp:TableCell>
                <asp:UpdatePanel ID="StreetUpdatePanel" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="StreetGridView" runat="server" PageSize="20"
                            AutoGenerateColumns="False"  DataSourceID="StreetObjectDataSource"
                            AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="None" 
                            BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
                            onselectedindexchanged="StreetGridView_SelectedIndexChanged">
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
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DistrictDropDownList" EventName="selectedindexchanged" />
                    </Triggers>
                </asp:UpdatePanel>
                    
            </asp:TableCell>
		</asp:TableRow>
	</asp:Table>
	
</asp:Content>
