<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RealEstateTypeAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.RealEstateTypeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="RealEstateTypeObjectDataSource" runat="server" 
        DeleteMethod="DeleteRealEstateType" InsertMethod="InsertRealEstateType" 
        SelectMethod="GetAllRealEstateTypes" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        UpdateMethod="UpdateRealEstateType">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="description" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="description" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="RealEstateTypeGridView" runat="server" AllowPaging="True" 
                    DataKeyNames="ID"
                    AutoGenerateColumns="False" DataSourceID="RealEstateTypeObjectDataSource">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Tên Loại Địa Ốc" 
                            SortExpression="Name" />
                        <asp:BoundField DataField="Description" HeaderText="Mô tả" 
                            SortExpression="Description" />
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                            SortExpression="ID" />
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
            <asp:TableCell>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="InsertRETypeValidationSummary"
                                runat="server" CssClass="failureNotification" HeaderText="Bạn phải điền vào các phần còn thiếu"
                                ValidationGroup="InsertRETypeValidationGroup" />
                            <asp:Label ID="ErrorLabel" runat="server" CssClass="failureNotification"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="RETypeNameLabel" runat="server"
                                AssociatedControlID="RETypeNameTextBox" Text="Tên Loại Địa Ốc"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="RETypeNameTextBox" runat="server" TabIndex="1" ToolTip="Tên Loại Địa ốc" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RETypeNameRequiredFieldValidator" runat="server"
                                ControlToValidate="RETypeNameTextBox" InitialValue="" CssClass="failureNotification"
                                ErrorMessage="Bạn chưa nhập Tên Loại Địa ốc" ValidationGroup="InsertRETypeValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="DescriptionLabel" runat="server" AssociatedControlID="DescriptionTextBox" Text="Mô tả"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="DescriptionTextBox" runat="server" CssClass="textEntry" ToolTip="Mô tả"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="InsertButton" runat="server" Text="Thêm" onclick="InsertButton_Click" ValidationGroup="InsertRETypeValidationGroup"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    
</asp:Content>
