<%@ Page Language="C#" MasterPageFile="~/master/Main.master" AutoEventWireup="false" CodeFile="Main_MenuNavigation.aspx.cs" Inherits="Acc_Main_MenuNavigation" title="TMS SPICE Hot Desking Home Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.footer {
    width: 100%;
    height: 24px;
    /* background-color: rgb(150,150,150); */
    color: White;
    font-weight: bold;
    background: #2969b0;
    background: -webkit-linear-gradient(#2969b0, rgb(15, 78, 90)); /* For Safari 5.1 to 6.0 */
    background: -o-linear-gradient( #2969b0, rgb(15, 78, 90)); /* For Opera 11.1 to 12.0 */
    background: -moz-linear-gradient( #2969b0, rgb(15, 78, 90)); /* For Firefox 3.6 to 15 */
    background: linear-gradient( #2969b0, rgb(15, 78, 90)); /* Standard syntax #2969b0, rgb(37, 151, 154)*/
}
.footer MARQUEE
{
	padding-top:0px;
	font-size:16px;
    font-family: "Century Gothic", CenturyGothic, AppleGothic, sans-serif;
    text-shadow: 2px 2px 12px #000;
    color: White;
    font-weight:lighter;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <iframe runat="server" src="MenuNavigation.aspx" id="ifrm" height="1150px" width="100%" scrolling="no" />
<div class="footer">
<MARQUEE WIDTH=""100%"">Welcome To TMS</MARQUEE>
</div>
</asp:Content>

