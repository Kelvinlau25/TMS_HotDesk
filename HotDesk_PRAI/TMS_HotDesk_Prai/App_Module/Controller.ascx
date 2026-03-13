<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Controller.ascx.vb" Inherits="App_Module_Controller" %>
<asp:Panel ID="pninfo" runat="server">
<div class="createdpanel">
    <table class="loginfo">
        <tr runat="server" id="trcreatecom" visible="false">
            <td class="label2">Created Company Code : </td>
            <td class="value"><asp:Label ID="lblcreatedcom" runat="server" Text="[Created Company]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label2">Created By</td>
            <td class="value"><asp:Label ID="lblcreatedby" runat="server" Text="[Created By]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label2">Created Date</td>
            <td class="value"><asp:Label ID="lblcreateddate" runat="server" Text="[Created Date]"></asp:Label></td>
        </tr>
        <tr style="display:none">
            <td class="label2">Created Location</td>
            <td class="value"><asp:Label ID="lblcreatedloc" runat="server" Text="[Created Loc]"></asp:Label></td>
        </tr>
        <tr runat="server" id="trupdatecom" visible="false">
            <td class="label2">Updated Company Code : </td>
            <td class="value"><asp:Label ID="lblupdatedcom" runat="server" Text="[Updated Company]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label2">Updated By</td>
            <td class="value"><asp:Label ID="lblupdatedby" runat="server" Text="[Updated By]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label2">Updated Date</td>
            <td class="value"><asp:Label ID="lblupdateddate" runat="server" Text="[Updated Date]"></asp:Label></td>
        </tr>
        <tr style="display:none">
            <td class="label2">Updated Location</td>
            <td class="value"><asp:Label ID="lblUpdatedloc" runat="server" Text="[Updated Loc]"></asp:Label></td>
        </tr>
    </table>
</div>
</asp:Panel>
<asp:Panel ID="pnconfirmation" runat="server">
    <script type="text/javascript">
        function ValidationChecked(sender, args) {
            args.IsValid = $('#<%= rbyes.clientid() %>').is(":checked");
        }
    </script>
    <table class="deleteInfo">
        <tr>
            <td class="label2">Delete the record ?</td>
            <td class="value">
                <asp:RadioButton ID="rbyes" Text="Yes" GroupName="confirm" runat="server" />
                <asp:RadioButton ID="rbno" Text="No" GroupName="confirm" Checked runat="server" />
                <asp:CustomValidator ID="cvdeleteyes" EnableClientScript="true" ClientValidationFunction="ValidationChecked" Display="None" runat="server"></asp:CustomValidator>
            </td>
        </tr>
    </table>
</asp:Panel>
<div class="clear"></div>
<asp:Button ID="btnSubmit" CssClass="control" runat="server" Text="Submit" />
<asp:Button ID="btnDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete the record?')" Text="Delete" />
<asp:Button ID="btnReset" runat="server" Text="Reset" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
<asp:HyperLink ID="hpLink" Target="_blank" runat="server">View History</asp:HyperLink>