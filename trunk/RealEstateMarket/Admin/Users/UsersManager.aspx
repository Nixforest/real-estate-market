<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="UsersManager.aspx.cs" Inherits="RealEstateMarket.Admin.Users.UsersManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="UsersObjectDataSource" runat="server"
        TypeName="System.Web.Security.Membership"
        SelectMethod="GetAllUsers"
        DeleteMethod="DeleteUser" 
        InsertMethod="CreateUser" OldValuesParameterFormatString="original_{0}" >
        <DeleteParameters>
            <asp:Parameter Name="username" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="email" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="RolesObjectDataSource" runat="server" 
        TypeName="System.Web.Security.Roles" DeleteMethod="DeleteRole" 
        InsertMethod="CreateRole" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetAllRoles">
        <DeleteParameters>
            <asp:Parameter Name="roleName" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="roleName" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:Panel ID="UsersPanel" runat="server" BorderStyle="Groove">
        - Quản lý người dùng:
        <asp:GridView ID="UserGridView" runat="server" AllowPaging="True" 
            DataKeyNames="UserName"
            AutoGenerateColumns="False" DataSourceID="UsersObjectDataSource">
            <Columns>
                <asp:TemplateField HeaderText="STT">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="Username" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="IsApproved" HeaderText="Phê duyệt" />
                <asp:BoundField DataField="IsLockedOut" HeaderText="Khóa" />
                <%--<asp:BoundField DataField="CreationDate" HeaderText="Ngày tham gia" 
                    ReadOnly="True" />--%>
                <asp:TemplateField HeaderText="Ngày tham gia">
                    <ItemTemplate>
                        <%# Convert.ToDateTime(Eval("CreationDate")).ToShortDateString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="IsOnline" HeaderText="Online" ReadOnly="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Table ID="AddUserTable" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="UserNameLabel" runat="server" Text="User name:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="UserNameTextBox" runat="server" ToolTip="Nhập user name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequiredFieldValidator"
                        runat="server" ValidationGroup="UserValidation"
                        ControlToValidate="UserNameTextBox"
                        ErrorMessage="Bạn chưa nhập Username"
                        Display="Dynamic" ForeColor="Red"
                        InitialValue=""></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="PasswordTextBox" runat="server" ToolTip="Nhập mật khẩu" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator"
                        runat="server" ValidationGroup="UserValidation"
                        ControlToValidate="PasswordTextBox"
                        Display="Dynamic"
                        ErrorMessage="Bạn chưa nhập mật khẩu"
                        ForeColor="Red"
                        InitialValue=""></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="RetypePasswordLabel" runat="server" Text="Nhập lại mật khẩu:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="RetypePasswordTextBox" runat="server" ToolTip="Nhập lại mật khẩu" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RetypePasswordRequiredFieldValidator"
                        runat="server" ValidationGroup="UserValidation"
                        ControlToValidate="RetypePasswordTextBox"
                        Display="Dynamic"
                        ErrorMessage="Bạn chưa nhập lại mật khẩu"
                        ForeColor="Red"
                        InitialValue=""></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompareValidator" runat="server"
                        ControlToCompare="PasswordTextBox"
                        ControlToValidate="RetypePasswordTextBox"
                        Display="Dynamic"
                        ErrorMessage="Gõ lại mật khẩu chưa đúng"
                        ForeColor="Red"></asp:CompareValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="EmailLabel" runat="server" Text="Email:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="EmailTextBox" runat="server" ToolTip="Nhập Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="EmailRegularExpressionValidator"
                        runat="server" ValidationGroup="UserValidation"
                        ControlToValidate="EmailTextBox"
                        Display="Dynamic" ForeColor="Red"
                        ErrorMessage="Bạn chưa nhập đúng định dạng Email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator"
                        runat="server" ValidationGroup="UserValidation"
                        ControlToValidate="EmailTextBox"
                        Display="Dynamic"
                        ErrorMessage="Bạn chưa nhập email"
                        ForeColor="Red"
                        InitialValue=""></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="InRoleLabel" runat="server" Text="Nhóm người dùng:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="InRoleDropDownList" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="AddUserButton" runat="server"
            ValidationGroup="UserValidation" Text="Thêm người dùng mới" OnClick="AddUserButton_Click" />
    </asp:Panel>
    
    <br />
    <asp:Panel ID="RolesPanel" runat="server" BorderStyle="Groove">
        <asp:Table ID="RolesTable" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    - Quản lý nhóm người dùng:
                    <asp:GridView ID="RolesGridView" runat="server" AutoGenerateColumns="True" 
                        DataSourceID="RolesObjectDataSource">
                        <Columns>
                            <asp:TemplateField HeaderText="STT">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <%--<asp:GridView ID="Administrator"--%>
                    <asp:Label ID="RoleNameLabel" runat="server" Text="Tên nhóm:"></asp:Label>
                    <asp:TextBox ID="RoleNameTextBox" runat="server" ToolTip="Tên nhóm"></asp:TextBox><br />
                    <asp:Button ID="AddRoleButton" runat="server" Text="Thêm nhóm mới" OnClick="AddRoleButton_Click" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="UserInRoleLabel" runat="server" Text="Người dùng:"></asp:Label><br />
                    <asp:DropDownList ID="UserDropDownList" runat="server"
                        DataSourceID="UsersObjectDataSource"
                        DataTextField="UserName"
                        DataValueField="UserName"></asp:DropDownList>
                    <asp:Button ID="DeleteUserButton" runat="server" Text="Xóa người dùng này"
                        OnClick="DeleteUserButton_Click" />
                    <br />
                    <asp:Label ID="RoleUserLable" runat="server" Text="Nhóm người dùng:"></asp:Label><br />
                    <asp:DropDownList ID="InRoleAddUserDropDownList" runat="server"></asp:DropDownList>
                    <br />
                    <asp:Button ID="AddUserInRoleButton" runat="server" Text="Thêm người dùng vào nhóm"
                        OnClick="AddUserInRoleButton_Click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
                    
    </asp:Panel>
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
