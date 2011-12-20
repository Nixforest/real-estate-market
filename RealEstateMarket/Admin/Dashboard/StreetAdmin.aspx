<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="StreetAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.StreetAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="StreetObjectDataSource" runat="server" 
        DeleteMethod="DeleteStreet" InsertMethod="InsertStreet" 
        SelectMethod="GetAllStreets" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        UpdateMethod="UpdateStreet">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView ID="StreetGridView" DataKeyNames="ID" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" ToolTip="Danh sách các đường phố chính"
                    DataSourceID="StreetObjectDataSource">
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Tên đường" />
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
            <asp:TableCell>
                <table>
                    <tr>
                        <p>
                            <asp:ValidationSummary ID="InsertStreetValidationSummary" runat="server" HeaderText="Bạn phải điền vào các phần còn thiếu"
                                CssClass="failureNotification" ValidationGroup="InsertStreetValidationGroup" />
                        </p>
                        <p>
                            <asp:Label ID="ErrorLabel" runat="server" CssClass="failureNotification"></asp:Label>
                        </p>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="StreetNameLabel" runat="server" AssociatedControlID="StreetNameTextBox" Text="Tên đường:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="StreetNameTextBox" TabIndex="1" ToolTip="Nhập tên đường" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="StreetNameRequiredFieldValidator" runat="server"
                                CssClass="failureNotification" InitialValue=""
                                ValidationGroup="InsertStreetValidationGroup" ControlToValidate="StreetNameTextBox"
                                ErrorMessage="Bạn chưa nhập tên đường">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="InsertButton" runat="server"
                            ValidationGroup="InsertStreetValidationGroup" OnClick="InsertButton_Click" Text="Thêm mới" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
