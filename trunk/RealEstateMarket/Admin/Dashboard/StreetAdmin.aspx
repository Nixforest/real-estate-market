<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StreetAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.StreetAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>
        Cập nhật thông tin các con đường chính
    </h4>
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
                    AutoGenerateColumns="False" DataSourceID="StreetObjectDataSource" 
                    BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
                    CellPadding="4" GridLines="Horizontal">
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
