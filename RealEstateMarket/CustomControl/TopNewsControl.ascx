<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNewsControl.ascx.cs" Inherits="RealEstateMarket.CustomControl.TopNewsControl" %>
<style type="text/css">

.gallerycontainer{
position: relative;
/*Add a height attribute and set to largest image's height to prevent overlaying*/
 background:white;
 border:1px dotted gray;
 padding:12px 5px;
 text-align:center;
}
.gallerycontainer a
{
    color:#0086C5;
    text-decoration:none;    
    font-weight:900;
}
.gallerycontainer a:hover
{
    text-decoration:underline;
}
.thumbnail img{
border: 1px solid white;
margin: 0 5px 5px 0;
}

.thumbnail:hover{
background-color: transparent;
}

.thumbnail:hover img{
border: 1px solid blue;
}

.thumbnail span{ /*CSS for enlarged image*/
position: absolute;
background-color: lightyellow;
padding: 5px;
left: -1000px;
border: 1px dashed gray;
visibility: hidden;
color: black;
text-decoration: none;
}

.thumbnail span img{ /*CSS for enlarged image*/
border-width: 0;
padding: 2px;
}

.thumbnail:hover span{ /*CSS for enlarged image*/
visibility: visible;
top: 0;
left: 480px; /*position where enlarged image should offset horizontally */
z-index: 50;
}

</style>

<div class="gallerycontainer">
<a class="thumbnail" runat="server" id="atag1" href="">
    <img id="img1" runat="server" src="" width="100" height="66" border="0" />
    <span>
        <img id="spanimg1" runat="server" src="" />
        <br />
        <label id="label1" runat="server"></label>
    </span>
</a>

<a class="thumbnail" runat="server" id="atag2" href="">
    <img id="img2" runat="server" src="" width="100" height="66" border="0" />
    <span>
        <img id="spanimg2" runat="server" src="" />
        <br />
        <label id="label2" runat="server"></label>
    </span>
</a>

<a class="thumbnail" runat="server" id="atag3" href="">
    <img id="img3" runat="server" src="" width="100" height="66" border="0" />
    <span>
        <img id="spanimg3" runat="server" src="" />
        <br />
        <label id="label3" runat="server"></label>
    </span>
</a>

<a class="thumbnail" runat="server" id="atag4" href="">
    <img id="img4" runat="server" src="" width="100" height="66" border="0" />
    <span>
        <img id="spanimg4" runat="server" src="" />
        <br />
        <label id="label4" runat="server"></label>
    </span>
</a>

<br />

<a class="thumbnail" runat="server" id="atag5" href="">
    <img id="img5" runat="server" src="" width="100" height="75" border="0" />
    <span>
        <img id="spanimg5" runat="server" src="" />
        <br />
        <label id="label5" runat="server"></label>
    </span>
</a> 

<a class="thumbnail" runat="server" id="atag6" href="">
    <img id="img6" runat="server" src="" width="100" height="70" border="0" />
    <span>
        <img id="spanimg6" runat="server" src="" />
        <br />
        <label id="label6" runat="server"></label>
    </span>
</a>

<a class="thumbnail" runat="server" id="atag7" href="">
    <img id="img7" runat="server" src="" width="100" height="66" border="0" />
    <span>
        <img id="spanimg7" runat="server" src="" />
        <br />
        <label id="label7" runat="server"></label>
    </span>
</a>

<a class="thumbnail" runat="server" id="atag8" href="">
    <img id="img8" runat="server" src="" width="100" height="66" border="0" />
    <span>
        <img id="spanimg8" runat="server" src="" />
        <br />
        <label id="label8" runat="server"></label>
    </span>
</a>



<br />

<a class="thumbnail" runat="server" id="atag9" href="">
    <label id="label9" runat="server"></label>
    <span>
        <img runat="server" id="spanimg9" src="" />
    </span>
</a>

<br />

<a class="thumbnail" runat="server" id="atag10" href="">
    <label id="label10" runat="server"></label>
    <span>
        <img runat="server" id="spanimg10" src="" />
    </span>
</a>

</div>