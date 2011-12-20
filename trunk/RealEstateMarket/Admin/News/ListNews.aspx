<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNews.Master" AutoEventWireup="true" CodeBehind="ListNews.aspx.cs" Inherits="RealEstateMarket.Admin.News.ListNews1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="DataSourceListNews" 
        PageSize="20">
        <Columns>
            <asp:TemplateField HeaderText="Tiêu Đề">
                <ItemTemplate>
                    <asp:HyperLink ID="TitleLink" NavigateUrl='<%# Eval("ID","EditNews.aspx?id={0}") %>' runat="server">
                        <%# Eval("Title") %>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Chuyên Mục">
                <ItemTemplate>
                    <%# getNewsType(Eval("TypeID"))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Author" HeaderText="Tác Giả" 
                SortExpression="Author" />
            <asp:BoundField DataField="PublishTime" HeaderText="Ngày Đăng" 
                SortExpression="PublishTime" />
            <asp:BoundField DataField="EditTime" HeaderText="Ngày Sửa" 
                SortExpression="EditTime" />
                <asp:TemplateField HeaderText="Duyệt Bài">
                    <ItemTemplate>
                        <asp:CheckBox ID="Check" OnCheckedChanged="Check_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("Check") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quản Lý">
                    <ItemTemplate>
                        <asp:HyperLink ID="EditLink" NavigateUrl='<%# Eval("ID","~/Admin/News/EditNews.aspx?id={0}") %>' runat="server">
                            <asp:Image ID="EditImage" ImageUrl="../../Image/Admin/edit.gif" runat="server" />
                        </asp:HyperLink>
                        <asp:HyperLink ID="DeleteLink" NavigateUrl='<%# Eval("ID","~/Admin/News/DelNews.aspx?id={0}") %>' runat="server">
                            <asp:Image ID="DeleteImage" OnClick="if(!window.confirm('Bạn có chắc chắn muốn xóa tin này không ?')) return false;" ImageUrl="../../Image/Admin/delete.gif" runat="server" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="DataSourceListNews" runat="server" 
        SelectMethod="GetAllNews" 
        TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient">
    </asp:ObjectDataSource>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
