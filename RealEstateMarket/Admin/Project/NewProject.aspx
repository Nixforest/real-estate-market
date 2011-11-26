<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="RealEstateMarket.Admin.Project.NewProject" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Đăng tin Dự án</h4>
    <asp:Label ID="error" runat="server" Text="Error" ForeColor="Red"></asp:Label>
    <br />
    <asp:ObjectDataSource ID="dataSourceProjectType" runat="server" 
        SelectMethod="GetAllProjectTypes" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:ValidationSummary ID="validationSum" runat="server" ForeColor="Red"
        HeaderText="Bạn phải điền vào các phần còn thiếu"
        ShowMessageBox="false" />
    <asp:Table runat="server" GridLines="Both">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblProjectType" runat="server" Text="Loại dự án:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlProjectType" runat="server"
                    DataSourceID="dataSourceProjectType"
                    DataTextField="Name"
                    DataValueField="ID"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblName" runat="server" Text="Tên dự án:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                    ErrorMessage="Tên dự án không được rỗng" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <nixforest:address ID="address" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblBeginDay" runat="server" Text="Ngày bắt đầu:"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Calendar ID="cldBeginDay" runat="server"></asp:Calendar>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDescription" runat="server" Text="Mô tả"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>            
            <asp:TableCell ColumnSpan="2">
                <CKEditor:CKEditorControl ID="editor" runat="server"></CKEditor:CKEditorControl>
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
    
                <asp:Button ID="btnPost" runat="server" Text="Đăng" OnClick="btnPost_Click" />
                <asp:Button ID="Button1" runat="server" Text="Xem trước" OnClick="btnPreview_Click" />
</asp:Content>
