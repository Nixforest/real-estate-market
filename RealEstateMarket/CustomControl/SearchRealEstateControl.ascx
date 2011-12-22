<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchRealEstateControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.SearchRealEstateControl" %>
<style type="text/css">

/* ********** */
.searchHome
{ 
    float:left; 
    width:174px; 
    background:url("../../Image/bgd_bottom_searchHome.gif") no-repeat 0 100%;
    padding:0 0 10px 0;
}
.infoSearchHome 
{ 
    width:154px; 
    background:url("../../Image/bgd_top_searchHome.gif") no-repeat 0 0; 
    padding:10px 10px 0 10px;
}
.infoSearchHome h3 
{ 
    font:18px Arial; 
    color:#0086c5; 
    padding:0 0 7px 0; 
}
.infoSearchHome p 
{ 
    padding:0 0 7px 0;
}
.buttonHome 
{ 
    width:154px; 
    height:36px; 
    background: url("../../Image/btn_home.gif") no-repeat 0 0; 
    font:18px Arial; 
    color:#88370a; 
    font-weight:normal; 
    cursor:pointer; 
    border:none;
}
.input150 
{ 
    width:150px; 
    border:1px solid #8098ba;
}

</style>
<div class="searchHome">
    <div class="infoSearchHome">
        <h3>Tìm kiếm địa ốc</h3>
            <asp:TextBox ID="KeyTextBox" CssClass="input150" runat="server">Từ khóa tìm kiếm</asp:TextBox>
            <asp:DropDownList ID="CityDropDownList" runat="server" CssClass="input150"></asp:DropDownList>
            <asp:DropDownList ID="NewsSaleTypeDropDownList" runat="server" CssClass="input150"></asp:DropDownList>
            <asp:DropDownList ID="RealEstateTypeDropDownList" runat="server" CssClass="input150"></asp:DropDownList>
            <asp:DropDownList ID="PriceDropDownList" runat="server" CssClass="input150">
                <asp:ListItem Value="0#0">Chọn khoảng giá</asp:ListItem>
                <asp:ListItem Value="0#5000000">Dưới 5 triệu</asp:ListItem>
                <asp:ListItem Value="5000000#20000000">5 triệu - 20 triệu</asp:ListItem>
                <asp:ListItem Value="20000000#100000000">20 triệu - 100 triệu</asp:ListItem>
                <asp:ListItem Value="100000000#500000000">100 triệu - 500 triệu</asp:ListItem>
                <asp:ListItem Value="500000000#1200000000">500 triệu - 1,2 tỷ</asp:ListItem>
                <asp:ListItem Value="1200000000#2000000000">1,2 tỷ - 2 tỷ</asp:ListItem>
                <asp:ListItem Value="2000000000#3000000000">2 tỷ - 3 tỷ</asp:ListItem>
                <asp:ListItem Value="3000000000#5000000000">3 tỷ - 5 tỷ</asp:ListItem>
                <asp:ListItem Value="5000000000#79228162514264337593543950335">Trên 5 tỷ</asp:ListItem>
            </asp:DropDownList>
        <div id="tbButton">
            <asp:Button ID="SearchButton" runat="server" CssClass="buttonHome"
                OnClick="SearchButton_Click"/>
        </div>
    </div>
</div>
<script type="text/javascript">
    function clear(a) {
        document.getElementById(a).value = "";
    }
</script>