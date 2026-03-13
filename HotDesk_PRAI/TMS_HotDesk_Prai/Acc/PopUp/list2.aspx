<%@ Page Language="VB" AutoEventWireup="false" CodeFile="list2.aspx.vb" Inherits="Acc_PopUp_list2" %>

<!DOCTYPE html>

<html>
<head runat="server"> 


<link href="../../css_new/TMSAccess.css" rel="stylesheet" type="text/css" />
   
</head>
<body class="framebody">
    <form id="form1" runat="server" >
    <br /><br />
    <%--<table width="100%" class="OutTable" >
                    <tr style="text-align:left;font-size:20px;text-decoration:underline;">
                        <th>STAFF ID</th>
                        <th>STAFF NAME</th>
                        <th>LAST SCAN</th>
                    </tr>
                    <tr>
                        <td>99000001</td>
                        <td>Hong Chin Sheng</td>
                        <td>12:00</td>
                    </tr>
                    <tr>
                        <td>99000002</td>
                        <td>Beh Poh Hock</td>
                        <td>13:00</td>
                    </tr>
                    <tr>
                        <td>99000003</td>
                        <td>Cheah Tian Asi</td>
                        <td>14:00</td>
                    </tr>
                </table>--%>
          <asp:GridView ID="grdResult"  EnableViewState="true" HeaderStyle-CssClass="OutTable" RowStyle-CssClass="OutTable" AlternatingRowStyle-CssClass="OutTable1" PagerStyle-CssClass="OutTableFooter" Width="100%"   runat="server" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="12" OnPageIndexChanging="OnPageIndexChanging">
                <PagerSettings Visible="true" />
                    <Columns>
                    
                    
			
		            	<asp:BoundField  HeaderText="STAFF ID" DataField="STAFF_ID"> 
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:BoundField>
			
		            	<asp:BoundField  HeaderText="STAFF NAME" DataField="STAFF_NAME"> 
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:BoundField>
			
		            	<asp:BoundField  HeaderText="LAST SCAN" DataField="TRANSTIME"> 
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:BoundField>

		            	<asp:BoundField  HeaderText="DOOR" DataField="DOOR">
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </asp:BoundField>

		            	<asp:BoundField  HeaderText="SEAT STATUS" DataField="SEAT"> 
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
