<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Master/Home.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.cs" Inherits="RealEstateMarket._Default" %>
<%@ Register TagPrefix="nixforest" TagName="address" Src="~/CustomControl/AddressControl.ascx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
    <br />
</asp:Content>
