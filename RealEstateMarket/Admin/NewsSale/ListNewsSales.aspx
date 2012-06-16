<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="ListNewsSales.aspx.cs" Inherits="RealEstateMarket.Admin.NewsSale.ListNewsSales" %>
<%@ Register TagPrefix="Admin" TagName="Menu" Src="~/CustomControl/MenuAdminControl.ascx" %>
<%@ Register TagPrefix="Admin" TagName="RightMenu" Src="~/CustomControl/RightMenuAdminControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<asp:GridView ID="ListGridView" runat="server" AllowPaging="true"
    AutoGenerateColumns="false" DataKeyNames="ID" DataSourceID="NewsSaleObjectDataSource" PageSize="20">
    <Columns>
        <asp:TemplateField HeaderText="Tiêu đề">
            <ItemTemplate>
                <asp:HyperLink ID="TitleLink" runat="server"
                    NavigateUrl='<%# Eval("ID","~/Member/EditNewsSale.aspx?editId={0}") %>'>
                    <%# Eval("Title") %>
                </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Loại tin rao bán">
            <ItemTemplate>
                <%# RealEstateMarket._Default.db.GetNewsSaleType(Convert.ToInt32(Eval("TypeID"))).Name %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Trạng thái">
            <ItemTemplate>
                <asp:DropDownList ID="StatusDropDownList" runat="server" AutoPostBack="true"
                    SelectedIndex='<%# Convert.ToInt32(Eval("Status")) - 1 %>'
                    OnSelectedIndexChanged="StatusDropDownList_SelectedIndexChanged">
                    <asp:ListItem Value="1">Chưa duyệt</asp:ListItem>
                    <asp:ListItem Value="2">Đã đăng</asp:ListItem>
                    <asp:ListItem Value="3">Đã lưu</asp:ListItem>
                    <asp:ListItem Value="4">Đã bán</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Trung gian">
            <ItemTemplate>
                <asp:DropDownList ID="BrokerDropDownList" runat="server">
                    <asp:ListItem Value="False">Miễn trung gian</asp:ListItem>                    
                    <asp:ListItem Value="True">Ký gởi môi giới</asp:ListItem>
                </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quản Lý">
            <ItemTemplate>
                <asp:HyperLink ID="EditLink" NavigateUrl='<%# Eval("ID","~/Member/EditNewsSale.aspx?editId={0}") %>' runat="server">
                    <asp:Image ID="EditImage" ImageUrl="../../Image/Admin/edit.gif" runat="server" />
                </asp:HyperLink>
                <asp:HyperLink ID="DeleteLink" NavigateUrl='<%# Eval("ID","~/Member/DeleteNewsSale.aspx?id={0}") %>' runat="server">
                    <asp:Image ID="DeleteImage" OnClick="if(!window.confirm('Bạn có chắc chắn muốn xóa tin này không ?')) return false;" ImageUrl="../../Image/Admin/delete.gif" runat="server" />
                </asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="NewsSaleObjectDataSource" runat="server" 
        SelectMethod="GetAllNewsSales" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    </asp:ObjectDataSource>
</asp:Content>
