<%@ Control Language="C#" AutoEventWireup="false" CodeFile="ConfirmPassword.ascx.cs" Inherits="App_Module_ConfirmPassword" %>
<div class="container">
<asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server">
    </asp:TextBox>
    <asp:RequiredFieldValidator ID="rfPassword" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true"  runat="server" ></asp:RequiredFieldValidator><br />
    <asp:Label ID="lblConPassword" runat="server" Text=" Confirm Password: "></asp:Label>
    <asp:TextBox ID="txtConPassword" runat ="server">
    </asp:TextBox>
    <asp:RequiredFieldValidator ID="rfConPassword" ControlToValidate="txtConPassword" Display="Dynamic" ErrorMessage="Required Field" SetFocusOnError="true"  runat="server" ></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="cvPassword" ControlToCompare="txtPassword" ControlToValidate="txtConPassword" runat="server" ErrorMessage="Password Not Match" Display="Dynamic" SetFocusOnError="true" ></asp:CompareValidator>
</div>