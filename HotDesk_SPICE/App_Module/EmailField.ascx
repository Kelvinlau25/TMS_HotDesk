<%@ Control Language="C#" AutoEventWireup="false" CodeFile="EmailField.ascx.cs" Inherits="App_Module_EmailField" %>
<div class="row <%= IIf(Not String.IsNullOrEmpty(Me.CssClass), " " & Me.CssClass, String.Empty) %> ">
    <div class="label" id="pnlEmail" runat="server"><asp:label ID="lblEmail" runat="server" Text="Email Address"></asp:label> </div>
    <div class="input">
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Required Field"></asp:RequiredFieldValidator>  
        <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" SetFocusOnError="true" ErrorMessage="Invalid Email Address, Format: exmaple@mail.com" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z-]{2,3}$"></asp:RegularExpressionValidator>
    </div>
</div>


