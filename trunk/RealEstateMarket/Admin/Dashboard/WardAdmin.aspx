<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WardAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.WardAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>
        Cập nhật thông tin các Phường, Xã
    </h4>
    <asp:ObjectDataSource ID="WardObjectDataSource" runat="server" DeleteMethod="DeleteWard" 
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

    <asp:ObjectDataSource ID="DistrictObjectDataSource" runat="server" 
        SelectMethod="GetAllDistricts" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="WardGridView" runat="server" AllowPaging="True"
                    DataKeyNames="ID" 
                    AutoGenerateColumns="False" DataSourceID="WardObjectDataSource" BackColor="White" 
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
                                <%# RealEstateMarket._Default.db.GetDistrict(Convert.ToInt32(Eval("DistrictID"))).Name %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl" runat="server"
                                    DataSourceID="DistrictObjectDataSource"
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
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="InsertWardValidationSummary" runat="server"
                                HeaderText="Bạn phải điền vào các phần còn thiếu" 
                                CssClass="failureNotification" ValidationGroup="InsertWardValidationGroup" />
                            <asp:Label ID="ErrorLabel" runat="server" CssClass="failureNotification"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="WardNameLabel" runat="server" AssociatedControlID="WardNameTextBox">Tên Phường/Xã:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="WardNameTextBox" CssClass="textEntry" ToolTip="Nhập Tên Phường/Xã"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="WardNameRequiredFieldValidator" runat="server"
                                ControlToValidate="WardNameTextBox" CssClass="failureNotification"
                                ErrorMessage="Bạn chưa nhập tên Phường/Xã" InitialValue=""
                                ValidationGroup="InsertWardValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="InDistrictLabel" runat="server" AssociatedControlID="InDistrictDropDownList">Quận:</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="InDistrictDropDownList"
					            DataSourceID="DistrictObjectDataSource"
					            DataTextField="Name"
					            DataValueField="ID"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
				<asp:Button ID="InsertButton" runat="server" ValidationGroup="InsertWardValidationGroup" OnClick="InsertButton_Click" Text="Thêm mới" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
