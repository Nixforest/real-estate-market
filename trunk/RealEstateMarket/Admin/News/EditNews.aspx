<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="EditNews.aspx.cs" Inherits="RealEstateMarket.Admin.News.EditNews" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="IdImageHidden" runat="server" />
    <asp:ObjectDataSource ID="NewsTypeDataSource" runat="server" 
        SelectMethod="GetAllNewsTypes" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
        <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="NewsTypeLabel" runat="server" Text="Loại Tin Tức"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="NewsType" runat="server" DataSourceID="NewsTypeDataSource" 
                    DataTextField="Name" DataValueField="ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="TitleNewsLabel" runat="server" Text="Tiêu Đề"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TitleNews" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="ErrorTitleNewsLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="DescriptLabel" runat="server" Text="Nội Dung Tóm Tắt"></asp:Label>
            </td>
            <td>
                <CKEditor:CKEditorControl ID="Descript" runat="server"></CKEditor:CKEditorControl>
            </td>
            <td>
                <asp:Label ID="ErrorDescriptLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ContentLabel" runat="server" Text="Nội Dung"></asp:Label>
            </td>
            <td>
                <CKEditor:CKEditorControl ID="Content" runat="server"></CKEditor:CKEditorControl>
            </td>
            <td>
                <asp:Label ID="ErrorContentLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="AuthorLabel" runat="server" Text="Tác Giả"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Author" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="ErrorAuthorLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="CheckLabel" runat="server" Text="Duyệt Bài"></asp:Label>
            </td>
            <td colspan="2">
                <asp:CheckBox ID="Check" runat="server" Text="Chưa Duyệt" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ImageUploadLabel" runat="server" Text="Hình Ảnh"></asp:Label>
            </td>
            <td>
                <asp:ScriptManager ID="ScriptManager" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:FileUpload ID="ImageUpload" runat="server" />
                    <asp:Button ID="Upload" runat="server" Text="Upload" onclick="Upload_Click" />
                    <asp:Button ID="CancelUpload" runat="server" Text="Hủy UpLoad" Enabled="False" 
                        onclick="CancelUpload_Click" />
                    <asp:Image ID="ImageOld" runat="server" CssClass="listimage" />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Upload" />
                    <asp:PostBackTrigger ControlID="CancelUpload" />
                </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="ErrorImageUploadLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Submit" runat="server" Text="Cập Nhật" 
                    onclick="Submit_Click" />
                <asp:Button ID="Cancel" runat="server" Text="Quay Lại" />
            </td>
        </tr>
    </table>
</asp:Content>
