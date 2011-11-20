<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StreetAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.StreetAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>
        Cập nhật thông tin các con đường chính
    </h4>
    <asp:ObjectDataSource ID="dataSource" runat="server" 
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
                <asp:GridView ID="dataTable" DataKeyNames="ID" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataSourceID="dataSource" 
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
                <asp:Label ID="lblName" runat="server" Text="Tên đường:"></asp:Label>
                <br />
                <asp:TextBox ID="txbName" TabIndex="1" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Insert" runat="server" OnClick="Insert_Click" Text="Insert" />
                <br />
                <asp:Label ID="error" runat="server" ForeColor="Red"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
