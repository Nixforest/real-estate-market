<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="RealEstateMarket.TestPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register TagPrefix="nixforest" TagName="newsSale" Src="~/CustomControl/NewsSaleControl.ascx" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-1.7.1.min.js">
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
    <span id="text">This paragraph will be copyed ten times</span>
    <input id="btnClone" type="button" value="Clone" />
    <div id="container"></div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnClone').click(function () {
                $('#container').html('');
                for (var i = 0; i < 10; i++) {
                    $('#container').append(i + '. ');
                    $('#container').append($('#text').html());
                    $('#container').append('</br>');
                }
            });
        });
    </script>
    <asp:TextBox ID="editor" runat="server" TextMode="MultiLine"></asp:TextBox>
    
    <CKEditor:CKEditorControl ID="DescriptionCKEditor" runat="server"></CKEditor:CKEditorControl>
</asp:Content>


