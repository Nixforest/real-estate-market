<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RealEstateTypeAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.RealEstateTypeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="dataSource" runat="server" 
        DeleteMethod="DeleteRealEstateType" InsertMethod="InsertRealEstateType" 
        SelectMethod="GetAllRealEstateTypes" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        UpdateMethod="UpdateRealEstateType" 
        OldValuesParameterFormatString="original_{0}">
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
                <asp:GridView ID="dataTable" runat="server" AllowPaging="True" 
                    DataKeyNames="ID"
                    AutoGenerateColumns="False" DataSourceID="dataSource">
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
                <asp:Label ID="lblName" runat="server" Text="Tên Loại Địa Ốc"></asp:Label><br />
                <asp:TextBox ID="txtName" runat="server" TabIndex="1" ></asp:TextBox><br />
                <asp:Label ID="lblDescription" runat="server" Text="Mô tả"></asp:Label><br />
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox><br />
                <asp:Button ID="Insert" runat="server" Text="Thêm" onclick="Insert_Click"/><br />
                <asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    
</asp:Content>
