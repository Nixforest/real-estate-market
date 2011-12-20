<%@ Page Title="" Language="C#" MasterPageFile="~/Master/User.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="RealEstateMarket.Admin.Project.NewProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;<asp:ValidationSummary ID="ProjectValidationSummary" runat="server" CssClass="failureNotification"
            HeaderText="Bạn phải điền vào các phần còn thiếu" ValidationGroup="ProjectValidationGroup"
            ShowMessageBox="false" /></p>
    <p>
        <asp:Label ID="ErrorLabel" runat="server" Text="" CssClass="failureNotification"></asp:Label>
    </p>
    <asp:ObjectDataSource ID="ProjectTypeObjectDataSource" runat="server" 
        SelectMethod="GetAllProjectTypes" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ProjectTypeLabel" runat="server" AssociatedControlID="ProjectTypeDropDownList" Text="Loại dự án:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ProjectTypeDropDownList" runat="server"
                    DataSourceID="ProjectTypeObjectDataSource"
                    DataTextField="Name"
                    DataValueField="ID"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="ProjectNameLabel" runat="server" AssociatedControlID="ProjectNameTextBox" Text="Tên dự án:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="ProjectNameTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ProjectNameRequiredFieldValidator" runat="server"
                    ControlToValidate="ProjectNameTextBox" ValidationGroup="ProjectValidationGroup"
                    ErrorMessage="Tên dự án không được rỗng" InitialValue=""
                    CssClass="failureNotification" Display="Dynamic">*</asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="AddressCustomControl" Text="Địa chỉ:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <nixforest:address ID="AddressCustomControl" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="BeginDayLabel" runat="server" AssociatedControlID="BeginDayTextBox" Text="Ngày bắt đầu:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="BeginDayTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:CalendarExtender ID="BeginDayCalendarExtender" Format="dd/MM/yyyy" runat="server" TargetControlID="BeginDayTextBox">
                </asp:CalendarExtender>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="DescriptionLabel" runat="server" AssociatedControlID="DescriptionCKEditor" Text="Mô tả"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>            
            <asp:TableCell ColumnSpan="2">
                <CKEditor:CKEditorControl ID="DescriptionCKEditor" runat="server"></CKEditor:CKEditorControl>
            </asp:TableCell>            
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Button ID="PostButton" runat="server" Text="Đăng dự án" OnClick="PostButton_Click" ValidationGroup="ProjectValidationGroup"/>
    <asp:Button ID="PreviewButton" runat="server" Text="Xem trước" OnClick="PreviewButton_Click" />
</asp:Content>
