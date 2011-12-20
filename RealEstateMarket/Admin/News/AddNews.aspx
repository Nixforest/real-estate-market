<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Home.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="RealEstateMarket.Admin.News.AddNews" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ObjectDataSource ID="dataSourceType" runat="server" 
        SelectMethod="GetAllNewsTypes"         
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient"></asp:ObjectDataSource>
    <asp:HiddenField ID="IdImageHidden" runat="server" />
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="NewsTypeLabel" runat="server" Text="Loại Tin Tức"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="NewsType" runat="server" DataSourceID="dataSourceType" 
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
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <asp:FileUpload ID="ImageUpload" runat="server" />
                        <asp:Button ID="Upload" runat="server" Text="Upload" onclick="Upload_Click" />
                        <asp:Image ID="Image" runat="server" Height="100px" Width="130px" 
                            BorderStyle="None" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Upload" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="ErrorImageUploadLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Submit" runat="server" Text="Đăng Bài" 
                    onclick="Submit_Click" />
                <asp:Button ID="Cancel" runat="server" Text="Quay Lại" />
            </td>
        </tr>
    </table>
</asp:Content>
