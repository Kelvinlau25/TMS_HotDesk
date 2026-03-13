<%@ Control Language="VB" AutoEventWireup="false" CodeFile="RangeValidator.ascx.vb"
    Inherits="App_Module_RangeValidator" %>
 <%  If cvRange.Type = ValidationDataType.Date Then
         txtbox1.Attributes.Add("ReadOnly", "True")
         txtbox2.Attributes.Add("ReadOnly", "True")
         %>
<script type="text/javascript" language="javascript">
        var baseUrl = "<% Response.Write(ResolveUrl("~/")) %>";
        $(function () {
            $(".txtbox1").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: baseUrl + 'image/icon_cal.png',
                dateFormat: 'dd/mm/yy',
                persist: false,
                onSelect: function(){}

            });
        });
         
        $(function () {
            $(".txtbox2").datepicker({
                showOn: 'button',
                buttonImageOnly: true,
                buttonImage: baseUrl + 'image/icon_cal.png',
                dateFormat: 'dd/mm/yy',
                persist: false,
                onSelect: function(){}

            });
        });
</script>
      <%  End If%> 
<div class="container" id="container" runat="server">
    <asp:Label ID="lblbox1" runat="server" Text="Input 1"></asp:Label>
    <asp:TextBox ID="txtbox1" runat="server" CssClass="txtbox1"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfBox1" ControlToValidate="txtbox1" Display="Dynamic"
        ErrorMessage="Required Field " SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="cvCheckType1" runat="server" ControlToValidate="txtbox1"
        Operator="DataTypeCheck" ErrorMessage="The data type enter is incorrect."></asp:CompareValidator>
    <br />
    <asp:Label ID="lblbox2" runat="server" Text="Input 2"></asp:Label>
    <asp:TextBox ID="txtbox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfbox2" ControlToValidate="txtbox2" Display="Dynamic"
        ErrorMessage="Required Field" SetFocusOnError="true" runat="server"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="cvCheckType2" runat="server" ControlToValidate="txtbox2"
        Operator="DataTypeCheck" ErrorMessage="The data type enter is incorrect."></asp:CompareValidator>
    <asp:CompareValidator ID="cvRange" runat="server" ControlToValidate="txtbox2" ControlToCompare="txtbox1"
        Operator="LessThan" ErrorMessage="Value must be less than text box 1" Display="Dynamic"></asp:CompareValidator>
    <br />
</div>
