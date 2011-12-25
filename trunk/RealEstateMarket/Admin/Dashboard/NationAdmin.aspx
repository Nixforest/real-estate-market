﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="NationAdmin.aspx.cs" Inherits="RealEstateMarket.Admin.Dashboard.NationAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:GridView 
                    runat="server" 
                    ID="NationGridView"
                    DataSourceID="NationObjectDataSource"
                    DataKeyNames="ID"
                    AllowPaging="True" 
                    AutoGenerateDeleteButton="True"
                    AutoGenerateEditButton="True" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="STT">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Tên Quốc Gia" />
                        <asp:BoundField DataField="NationCode" HeaderText="Mã Quốc Gia" />
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
            </asp:TableCell>
            <asp:TableCell>
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary ID="InsertNationValidationSummary" runat="server" CssClass="failureNotification"
                                ValidationGroup="InsertNationValidationGroup" HeaderText="Bạn phải điền vào các phần còn thiếu" /><br />
                            <asp:Label ID="ErrorLabel" runat="server" Text="" CssClass="failureNotification"></asp:Label>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="NationNameLabel" runat="server" Text="Nation's name:"
                                AssociatedControlID="NationNameTextBox"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="NationNameTextBox" runat="server" ToolTip="Nhập Tên Quốc Gia"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NationNameTextBoxRequiredFieldValidator" runat="server"
                                ControlToValidate="NationNameTextBox" InitialValue=""
                                CssClass="failureNotification" ErrorMessage="Bạn chưa nhập Tên Quốc Gia"
                                ValidationGroup="InsertNationValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="NationCodeLabel" runat="server" Text="Nation Code:"
                                AssociatedControlID="NationCodeTextBox"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="NationCodeTextBox" runat="server" ToolTip="Nhập Mã Quốc gia"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="InsertNationButton" runat="server" Text="Insert" onclick="InsertNationButton_Click" ValidationGroup="InsertNationValidationGroup" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:ObjectDataSource ID="NationObjectDataSource" runat="server" DeleteMethod="DeleteNation" 
        InsertMethod="InsertNation" SelectMethod="GetAllNations"
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
        UpdateMethod="UpdateNation">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="nationCode" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="nationCode" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>