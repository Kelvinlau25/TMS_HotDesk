<%@ Control Language="C#" AutoEventWireup="false" CodeFile="GSNController.ascx.cs" Inherits="App_Module_Controller_GSN" %>
<asp:Panel ID="pninfo" runat="server">
<div class="createdpanel">
    <table class="loginfo">
        <tr runat="server" id="trcreatecom" visible="false">
            <td class="label">Created Company Code : </td>
            <td class="value"><asp:Label ID="lblcreatedcom" runat="server" Text="[Created Company]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Created By</td>
            <td class="value"><asp:Label ID="lblcreatedby" runat="server" Text="[Created By]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Created Date</td>
            <td class="value"><asp:Label ID="lblcreateddate" runat="server" Text="[Created Date]"></asp:Label></td>
        </tr>
        <tr style="display:none">
            <td class="label">Created Location</td>
            <td class="value"><asp:Label ID="lblcreatedloc" runat="server" Text="[Created Loc]"></asp:Label></td>
        </tr>
        <tr runat="server" id="trupdatecom" visible="false">
            <td class="label">Updated Company Code : </td>
            <td class="value"><asp:Label ID="lblupdatedcom" runat="server" Text="[Updated Company]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Updated By</td>
            <td class="value"><asp:Label ID="lblupdatedby" runat="server" Text="[Updated By]"></asp:Label></td>
        </tr>
        <tr>
            <td class="label">Updated Date</td>
            <td class="value"><asp:Label ID="lblupdateddate" runat="server" Text="[Updated Date]"></asp:Label></td>
        </tr>
        <tr style="display:none">
            <td class="label">Updated Location</td>
            <td class="value"><asp:Label ID="lblUpdatedloc" runat="server" Text="[Updated Loc]"></asp:Label></td>
        </tr>
    </table>
</div>
</asp:Panel>
<asp:Panel ID="pnconfirmation" runat="server">
    <script type="text/javascript">
        function ValidationChecked(sender, args) {
            args.IsValid = $('#<%= rbyes.ClientID %>').is(":checked");
        }
    </script>
    <table class="deleteInfo">
        <tr>
            <td class="label">Delete the record ?</td>
            <td class="value">
                <asp:RadioButton ID="rbyes" Text="Yes" GroupName="confirm" runat="server" />
                <asp:RadioButton ID="rbno" Text="No" GroupName="confirm" Checked runat="server" />
                <asp:CustomValidator ID="cvdeleteyes" EnableClientScript="true" ClientValidationFunction="ValidationChecked" Display="None" runat="server"></asp:CustomValidator>
            </td>
        </tr>
    </table>
</asp:Panel>
<div class="clear"></div>
<%--<asp:Button ID="Button1" CssClass="control" runat="server" OnClientClick="return confirm('Are you sure you want to ?')" Text="Submit" />--%>
<asp:Button ID="btnSubmit" CssClass="control" runat="server" Text="Submit" />
<asp:Button ID="btnDelete" runat="server" Text="Delete" />
<asp:Button ID="btnReset" runat="server" Text="Reset" />
<asp:Button ID="btnPrint" runat="server" Text="Print" Visible="False" />
<asp:Button ID="btnEnterM2" runat="server" Text="Enter Mill 2 Pallet Entry" Visible="False" />
<asp:Button ID="btnclose" runat="server" Text="Cancel" Visible="False" />
<asp:Button ID="btnconfirm" runat="server" Text="Confirm" Visible="False" />
<asp:Button ID="btnreject" runat="server" Text="Reject" Visible="False"/>
<asp:Button ID="btnprintnote" runat="server" Text="Print" Visible="False"/>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
<asp:HyperLink ID="hpLink" Target="_blank" runat="server">View History</asp:HyperLink>