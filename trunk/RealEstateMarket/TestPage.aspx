<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="RealEstateMarket.TestPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script>
    function IsNumeric(sText) {
        var ValidChars = "0123456789.,";
        var IsNumber = true;
        var Char;

        for (i = 0; i < sText.length && IsNumber == true; i++) {
            Char = sText.charAt(i);
            if (ValidChars.indexOf(Char) == -1) {
                alert('Giá tiền ko hợp lệ');
                IsNumber = false;
            }
        }
        return IsNumber;
    }
</script>
    <asp:TextBox ID="UsernameTextBox" runat="server">User Name</asp:TextBox><br />
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password">***</asp:TextBox>
    <asp:Button ID="LoginButotn" runat="server" OnClick="LoginButton_Click" Text="Login" />
    <asp:TextBox ID="tbxTest" runat="server" Text="0" 
        ontextchanged="tbxTest_TextChanged"
        onblur="IsNumeric(this.value)"></asp:TextBox>
    <asp:GridView ID="nationGridView" runat="server" AutoGenerateColumns="true">
    </asp:GridView>
    <asp:Label ID="lblName" runat="server" Text="Nation's name:"></asp:Label>
    <asp:TextBox ID="textboxName" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="lblNationCode" runat="server" Text="Nation Code:"></asp:Label>
    <asp:TextBox ID="textboxNationCode" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Insert" runat="server" Text="Update" onclick="Insert_Click" />
    <asp:Label ID="error" runat="server" Text="Label"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
</asp:Content>


