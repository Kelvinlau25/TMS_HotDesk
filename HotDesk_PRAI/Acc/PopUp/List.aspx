<%@ Page Language="C#" MasterPageFile="~/master/Main.master" AutoEventWireup="false" CodeFile="List.aspx.cs" Inherits="Acc_PopUp_List" title="Check In List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../css_new/TMSAccessList2.css" rel="stylesheet" type="text/css" />
<link href="../../css_new/TMSAccess.css" rel="stylesheet" type="text/css" />

<script>

document.title = 'Desk Check In Page';

function closeWin() {
   window.close();
}
</script>

<script type="text/javascript">
  function popupwindow(ID, Name) {
     var w = 800;
     var h = 600;
     var left = (screen.width/2)-(w/2);
     var top = (screen.height/2)-(h/2);
        window.open('<%= ResolveUrl("~/acc/PopUp/List.aspx") %>?itm1=' + ID + '&itm2=' + Name,'PopUp', 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=800,height=600,top='+top+', left='+left +'');
    };
</script>

<script type="text/javascript">
    function passvalue(staffID,staffName) {
        window.opener.$('.<%= me._staffID %>').val(staffID);
        window.opener.$('.<%= me._staffName %>').val(staffName);   
        // Close the popup
        window.close();
    }
    
  
    
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <table width="100%">
    <tr>
        <td>
          <asp:GridView ID="grdResult" DataKeyNames="STAFF_ID" EnableViewState="false"   RowStyle-CssClass="OutTable" AlternatingRowStyle-CssClass="OutTable1" PagerStyle-CssClass="OutTableFooter" Width="100%" runat="server" PageSize="20"
          AutoGenerateColumns="False" AllowPaging="True">
                <PagerSettings Visible="False" />
                    <Columns>
                        
                        <asp:BoundField  HeaderText="STAFF ID" DataField="STAFF_ID"  HeaderStyle-CssClass="OutTableHeader"> 
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="LEFT" VerticalAlign="Middle" />
                        </asp:BoundField>
                        
			            <asp:BoundField  HeaderText="STAFF NAME" DataField="STAFF_NAME"  HeaderStyle-CssClass="OutTableHeader"> 
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="LEFT" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-CssClass="OutTableHeader"  HeaderText="ACTION">
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <button class="dropbtn1" type="button" onclick="javascript:passvalue('<%#Eval("STAFF_ID")%>','<%#Eval("STAFF_NAME")%>');">Check In</button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle VerticalAlign="Middle" HorizontalAlign="Center" Font-Bold="true" ForeColor="Red" />
                    <EmptyDataTemplate>Record Not Found</EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" />
            </asp:GridView>
        </td>
    </tr>
</table> 
    <control:Footer ID="UCFooter" runat="server" />
        <br />
        &nbsp;
        <button onclick="closeWin()" class="dropbtn1 dropbtn2">Back</button>
</asp:Content>



