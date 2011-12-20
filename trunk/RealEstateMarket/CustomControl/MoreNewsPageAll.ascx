<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoreNewsPageAll.ascx.cs" Inherits="RealEstateMarket.CustomControl.MoreNews" %>
<style type="text/css">
    li a
    {
        color:Black;
        text-decoration:none;
    }
    li a:hover
    {
        text-decoration:underline;
    }
    .note
    {
        color:#8A0000;
        font-size:14px;
        font-weight:bold;
        font-family:Arial;
    }
</style>
<asp:Label ID="NoteLabel" CssClass="note" runat="server" Text="CÁC TIN KHÁC"></asp:Label>
<ul>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="MoreNewsDataSource">
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="MoreNewsLink" NavigateUrl='<%# String.Format("~/Pages/News/ReadNews.aspx?id={0}&cid={1}", Eval("ID"), Eval("TypeID")) %>' runat="server">
                        <asp:Label ID="MoreNewsLabel" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="  ("></asp:Label>
                    <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("EditTime", "{0:d}") %>'></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text=")"></asp:Label>
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
    </asp:DataList>
</ul>
<asp:ObjectDataSource ID="MoreNewsDataSource" runat="server" 
    SelectMethod="GetMoreNews" 
    
    
    TypeName="RealEstateMarket.RealEstateServiceReference.RealEstateWebServiceSoapClient" 
    OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="oldID" Type="Int32" />
        <asp:Parameter DefaultValue="11" Name="from" Type="Int32" />
        <asp:Parameter Name="number" Type="Int32" DefaultValue="10" />
        <asp:Parameter DefaultValue="" Name="typeID" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
