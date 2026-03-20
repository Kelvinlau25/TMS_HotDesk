<%@ Page Language="C#" AutoEventWireup="false" CodeFile="FirstArmSpice.aspx.cs" Inherits="Acc_PopUp_FirstArmSpice" %>

<!DOCTYPE html>

<html>
<head runat="server"> 


<link href="../../css_new/TMSAccess.css" rel="stylesheet" type="text/css" />
   
</head>
<body class="framebody">
    <form id="form1" runat="server" >
    <br /><br />
          <asp:GridView ID="grdResult"  EnableViewState="true" HeaderStyle-CssClass="OutTable" RowStyle-CssClass="OutTable" AlternatingRowStyle-CssClass="OutTable1" PagerStyle-CssClass="OutTableFooter" Width="100%"   runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="12" OnPageIndexChanging="OnPageIndexChanging">
                <PagerSettings Visible="true" />
                    <Columns>
			
		            	<asp:BoundField  HeaderText="STAFF NAME" DataField="Staffname"> 
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:BoundField>
			
		            	<asp:BoundField  HeaderText="FIRST SCAN" DataField="Transtime"> 
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:BoundField>

		            	<asp:BoundField  HeaderText="DATE" DataField="Transdate">
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:BoundField>
                        
                    </Columns>
                    <EmptyDataRowStyle VerticalAlign="Middle" HorizontalAlign="Center" Font-Bold="true" ForeColor="white" />
                    <EmptyDataTemplate>Record Not Found</EmptyDataTemplate>
                    <PagerStyle HorizontalAlign="Right" CssClass="OutTableFooter"  />
            </asp:GridView>
    </form>
</body>
</html>
