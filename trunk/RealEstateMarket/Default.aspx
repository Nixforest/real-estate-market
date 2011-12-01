<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="RealEstateMarket._Default" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <asp:HyperLink ID="adad" runat="server" NavigateUrl="~/Pages/Project.aspx">Dự án</asp:HyperLink>
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            OMG, you are, like so not logged in!
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Administrator">
                <ContentTemplate>
                    Wellcome back! You are a Administrator, I can
                    tell by your roles!
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Moderator">
                <ContentTemplate>
                    Wellcome back! You are a Moderator, I can
                    tell by your roles!
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Author">
                <ContentTemplate>
                    Wellcome back! You are a Author, I can
                    tell by your roles!
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Customer">
                <ContentTemplate>
                    Wellcome back! You are a Customer, I can
                    tell by your roles!
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
        <LoggedInTemplate>
        You are logged in!! But, wait, you are not a member of any roles.
        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>
