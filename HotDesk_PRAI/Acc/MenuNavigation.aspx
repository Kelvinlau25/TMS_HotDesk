<%@ Page Language="C#" MasterPageFile="~/master/Main.master" AutoEventWireup="false" CodeFile="MenuNavigation.aspx.cs" Inherits="Acc_MenuNavigation" title="TMS Check In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">

    var popupWindow=null;

  function popupwindow(ID, Name) {
     if( document.getElementById('<%=txtStaffName.ClientID%>').value == "")
     {
        var w = 800;
        var h = 600;
        var left = (screen.width/2)-(w/2);
        var top = (screen.height/2)-(h/2);
        popupWindow = window.open('<%= ResolveUrl("~/acc/PopUp/List.aspx") %>?itm1=' + ID + '&itm2=' + Name,'PopUp', 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=800,height=600,top='+top+', left='+left +'');
    
     }
     
     else
     {  
        document.getElementById('<%=txtStaffName.ClientID%>').value = "";
        document.getElementById('<%=txtStaffID.ClientID%>').value = "";
      }
   };
   
function parent_disable() {
if(popupWindow && !popupWindow.closed)
popupWindow.focus();
}
</script>
  
<script src="../jss/jquery.1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../jss/jquery.maphilight.js"></script>

<script type="text/javascript">
$(document).ready(function(){
$("#dropdowncontent1").show();
document.getElementById("warehouse1").style.backgroundColor = "BLUE";
      $("#dropdowncontent2").show();
       $("#dropdowncontent3").show();
       
        $(".pnlhd2").hide();
        $(".pnlhd3").hide();
  
    $("#warehouse1").click(function(){
        document.getElementById("warehouse1").style.backgroundColor = "BLUE";
        document.getElementById("warehouse2").style.backgroundColor = "BLACK"; 
        document.getElementById("warehouse3").style.backgroundColor = "BLACK";     
        document.getElementById("checkInList").style.backgroundColor = "BLACK"; 
        document.getElementById("checkInList2").style.backgroundColor = "BLACK";  
        $("#dropdowncontent1").show();
        $("#dropdowncontent2").hide();
        $("#dropdowncontent3").hide();
        $("#dropdowncontent5").hide();
           $("#dropdowncontent4").hide();
         $(".pnlhd2").hide();
          $(".pnlhd3").hide();
    });
    $("#warehouse2").click(function(){
        document.getElementById("warehouse1").style.backgroundColor = "BLACK";
        document.getElementById("warehouse2").style.backgroundColor = "BLUE";  
        document.getElementById("warehouse3").style.backgroundColor = "BLACK";   
        document.getElementById("checkInList").style.backgroundColor = "BLACK";
        document.getElementById("checkInList2").style.backgroundColor = "BLACK";  
        $("#dropdowncontent1").hide();
        $("#dropdowncontent2").show();
        $("#dropdowncontent3").hide();
        $("#dropdowncontent5").hide();
           $("#dropdowncontent4").hide();
         $(".pnlhd2").show();
          $(".pnlhd3").hide();
    });
    $("#warehouse3").click(function(){
        document.getElementById("warehouse1").style.backgroundColor = "BLACK";
        document.getElementById("warehouse2").style.backgroundColor = "BLACK"; 
        document.getElementById("warehouse3").style.backgroundColor = "BLUE";    
        document.getElementById("checkInList").style.backgroundColor = "BLACK";
        document.getElementById("checkInList2").style.backgroundColor = "BLACK";  
        $("#dropdowncontent1").hide();
        $("#dropdowncontent2").hide();
        $("#dropdowncontent3").show();
        $("#dropdowncontent5").hide();
           $("#dropdowncontent4").hide();
         $(".pnlhd2").hide();
          $(".pnlhd3").show();
    });
    $("#checkInList").click(function(){
	document.getElementById("<%= frame1.ClientID %>").src = 'PopUp/list2.aspx';
        document.getElementById("warehouse1").style.backgroundColor = "BLACK";
        document.getElementById("warehouse2").style.backgroundColor = "BLACK"; 
        document.getElementById("warehouse3").style.backgroundColor = "BLACK";  
        document.getElementById("checkInList").style.backgroundColor = "BLUE";  
        document.getElementById("checkInList2").style.backgroundColor = "BLACK";     
        $("#dropdowncontent1").hide();
        $("#dropdowncontent2").hide();
        $("#dropdowncontent3").hide();
        $("#dropdowncontent5").hide();
      $("#dropdowncontent5").hide();
           $("#dropdowncontent4").show();
         $(".pnlhd2").hide();
          $(".pnlhd3").hide();
    });
    
    $("#checkInList2").click(function(){
	document.getElementById("<%= Iframe2.ClientID %>").src = 'PopUp/list3.aspx';
        document.getElementById("warehouse1").style.backgroundColor = "BLACK";
        document.getElementById("warehouse2").style.backgroundColor = "BLACK"; 
        document.getElementById("warehouse3").style.backgroundColor = "BLACK";  
        document.getElementById("checkInList").style.backgroundColor = "BLACK";  
        document.getElementById("checkInList2").style.backgroundColor = "BLUE";      
        $("#dropdowncontent1").hide();
        $("#dropdowncontent2").hide();
        $("#dropdowncontent3").hide();
        $("#dropdowncontent5").show();
           $("#dropdowncontent4").hide();

         $(".pnlhd2").hide();
          $(".pnlhd3").hide();
    });

});

window.onload = function(){
  
       $(".wrapdrop").hide();
       ShowCurrentTime() ;
       
};

function ShowCurrentTime() {
var dt = new Date();
document.getElementById("lblTime").innerHTML = dt.format("dd/MM/yyyy hh:mm:ss");;
window.setTimeout("ShowCurrentTime()", 1000); // Here 1000(milliseconds) means one 1 Sec  
}
</script>

<script type ="text/javascript" src="../js/jquery.colorbox.js"></script>
<link rel="stylesheet" href ="../css/colorbox.css" />
<link href="../css_new/TMSAccess.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" >

function testing(checktype,staffName,seatName)
{PageMethods.testing(checktype,staffName,seatName,OnSuccess);}

function OnSuccess(response, userContext, methodName) 
{setTimeout(location.reload(), 50000);alert(response);}
			$(document).ready(function(){
                var disable = ['2', '3', '6','11', '20', '22']
                //var disable = ['2', '3', '6','11', '20', '22', '46', '53']
				//[2, 3, 6, 7, 9, 11, 14, 16, 18, 20, 22, 31, 32, 35, 37, 38, 41, 43, 45, 48, 50, 52, 64, 65]
				//$(".youtube").colorbox({iframe:true, innerWidth:900, innerHeight:500});
			    $('.dc input').click(function(){ 
			    var classname = this.className ;
			    var str =classname.substring(5);
		        var mapclass = "map" + str;
		 
			                    if( document.getElementById('<%=txtStaffName.ClientID%>').value == "")
                                {
                                          //map52 no more JJ 20190117
                                         // if( mapclass == "map24" ||  mapclass == "map27" ||  mapclass == "map46"||  mapclass == "map53" ||  mapclass == "map51"||  mapclass == "map52"  ){
                                         //map51 no more yeow 20190308
                                         // if( mapclass == "map24" ||  mapclass == "map27" ||  mapclass == "map46"||  mapclass == "map53" ||  mapclass == "map51"  ){
                                    //if (mapclass == "map24" || mapclass == "map27") {// ||  mapclass == "map46"||  mapclass == "map53"  ){
                                    //      return false;
                                          
                                    //}
                                    /*christopher leong_28 April 2020 - disable certain desk check in
                                    refer to disable1 list, if inside list means it is disabled
                                    this.id.substring(3, 5) --> get last 2 digit of the area id*/
                                    var num1 = this.id.substring(3, 5);

                                    if (disable.indexOf(num1) != -1) {
                                   
                                       return false;
                                    }
                                    else {
                                           if (confirm('Are you sure you want to check out from this desk?')) {
                                              
                                                testing("OUT","",mapclass);
                                                return false;
                                           } else {
                                                return false;
                                           }
                                    }
                                       
                                           
                                       }
                                else
                                {
                                    return false;
                                }
			    });
			    
			    if ($('#<%= btnCheck.ClientID %>').val()=="Check In/Out"){
			        
			              
                    $('.tabs area').click(function () { 
                              if ($(this ).hasClass( "red" )){
                         

                             }else{
                            
                                  var x = $.trim(document.getElementById('<%=txtStaffName.ClientID%>').value);
                                  console.log(x)
                                       if( document.getElementById('<%=txtStaffID.ClientID%>').value == "" )
                                       {
                                           alert(document.getElementById('<%=txtStaffID.ClientID%>').value);
                                             return false;
                                       }
                                       else
                                       {  
                                            //if( this.id == "map12")
                                           // if( this.id == "map24" ||  this.id == "map27" ||  this.id == "map51"||  this.id == "map53" ||  this.id == "map52"||  this.id == "map46" ){
                                           //map52 no more JJ 20190117
                                            //map51 no more yeow 20190308
                                            // if( this.id == "map24" ||  this.id == "map27" ||  this.id == "map51"||  this.id == "map53" ||  this.id == "map46" ){
                                          //  if( this.id == "map24" ||  this.id == "map27" ||  this.id == "map53" ||  this.id == "map46" ){
                                          //return false;
                                          
                                          //}
                                          /*christopher leong_28 April 2020 - disable certain desk check in
                                          refer to disable1 list, if inside list means it is disabled
                                          this.id.substring(3, 5) --> get last 2 digit of the area id*/
                                            var num = this.id.substring(3, 5);
                                            console.log(num);
                                            console.log(this.id);
                                           if (disable.indexOf(num) != -1) {

                                                return false;
                                            }
                                            else if( this.id == "map25"){
                                                if( x == "LIM POH HIANG" ) //
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('frame1.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                    return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                            }
                                            else if( this.id == "map28"){
                                                if( x == "OOI YINN LING" ) //
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                            }
                                            else if( this.id == "map13"){
                                                 if( x == "CHEAH SIANG FERN" ) //
                                                 {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {
                                                      
                                                        testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                    return false;
                                                    
                                                    }
                                                 }
                                                 else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                 }
                                            }

                                            else if( this.id == "map24"){
                                                 if( x == "CHAN KIEN WAH" ) //
                                                 {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {
                                                      
                                                        testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                    return false;
                                                    
                                                    }
                                                 }
                                                 else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                 }
                                            }

                                            else if( this.id == "map27"){
                                                 if( x == "KATSUHIKO DAIDO" ) //
                                                 {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {
                                                      
                                                        testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                    return false;
                                                    
                                                    }
                                                 }
                                                 else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                 }
                                           }
                                         

                                                 else if( this.id == "map5"){
                                                if( x == "CATHERINE SAW" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                 else if( this.id == "map7"){
                                                if( x == "NG WEI KEE" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                 else if( this.id == "map8"){
                                                if( x == "KHNG JIA SHAN" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                        testing("IN", document.getElementById('<%=txtStaffName.ClientID%>').value, this.id);
                                                        
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                   else if( this.id == "map15"){
                                                if( x == "TAN SIEW YONG" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                   else if( this.id == "map9"){
                                                if( x == "TAN SHI YIN" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                   else if( this.id == "map15"){
                                                if( x == "TAN YIN LING" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                 <%--else if( this.id == "map39"){
                                                     if( x == "ONG KHAI JOON" ) 
                                                     {
                                                         if (confirm('Are you sure you want to check in this desk?' )) {

                                                         //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                         testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                         } else {
                                                             return false;
                                                    
                                                         }
                                                     }
                                                     else{
                                               
                                                         // return false;
                                                          alert("Sorry, you are not allowed to check in this desk.");
                                                     }
                                           }--%>
                                                 else if( this.id == "map36"){
                                                if( x == "LUM KAH WEI" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                 else if( this.id == "map74"){
                                                if( x == "LOKMAN HARITH BIN ZUKIFLI" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                 else if( this.id == "map41"){
                                                if( x == "PAVITHIRA KRISNADAS" ) 
                                                {
                                                    if (confirm('Are you sure you want to check in this desk?' )) {

                                                    //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                    } else {
                                                        return false;
                                                    
                                                    }
                                                }
                                                else{
                                               
                                                    // return false;
                                                     alert("Sorry, you are not allowed to check in this desk.");
                                                }
                                           }
                                                 <%--else if( this.id == "map26"){
                                                     if( x == "SIVANESWARAN" ) 
                                                     {
                                                         if (confirm('Are you sure you want to check in this desk?' )) {

                                                        //testing("IN",document.getElementById('Iframe2.ClientID').value,this.id);
                                                         testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                         } else {
                                                             return false;
                                                    
                                                         }
                                                     }
                                                     else{
                                               
                                                         // return false;
                                                          alert("Sorry, you are not allowed to check in this desk.");
                                                     }
                                           }--%>
                                           
                                            <%--else if (this.id = "map38")
                                            {
                                                if (x == "CHARLENE CHONG SEOK YUN")
                                                {
                                                   if (confirm('Are you sure you want to check in this desk?' )) {
                                                      
                                                        testing("IN",document.getElementById('<%=btnCheck.ClientID%>').value,this.id);
                                                   }                                            
                                                }
                                                   
                                            }--%>

                                            

                                            else {
                                                if (confirm('Are you sure you want to check in this desk?' )) {
                                              
                                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                                } else {
                                                    return false;
                                                }
                                            }
                                         
                                      
                                            
                                       }
                              };
                            
                    });
                };
			});
		</script>

<script type="text/javascript">


    $(function() {
      $(".map").maphilight({fillOpacity:1,fillColor:'0ef748'})
    });
 
 $(document).ready(function(){  
 
 
 
var chk;

var i=1;

for (i; i <80; i++) { //for (i; i <54; i++)
    var disableColor = [2, 3, 5, 6, 7, 8, 9, 11, 15, 16, 20, 22, 26, 36, 41, 67];
    var a;
if (chk==i){
alert("ERROR occur");
location.reload;
}
else{
chk=i;
    }
    //alert(i);
    
  
    if (document.querySelector('.hi' + i).value[0] == 1) {
                  
        var abc = 'map' + i;
                   var cur = $('#'+abc);
                   var data = cur.data('maphilight') || {};
        data.alwaysOn = !data.alwaysOn;
     
                      data.fillColor = 'ffcccc'; //red
                      data.strokeColor = 'f84c24';
                      cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                      cur.addClass('red');
                  
              }

          
              
        
             //added by Christopher Leong_29 April 2020
             //add condition to filter out map8(helpdesk desk)
             //else if (document.querySelector('.hi' + i).value[0]==2) {
              else if (document.querySelector('.hi' + i).value[0] == 2) {
                   
                   var abc = 'map'+ i;
                   var cur = $('#'+abc);
                   var data = cur.data('maphilight') || {};
                   
                   data.alwaysOn = !data.alwaysOn;
                   data.fillColor = '7b7b7b';//grey
                   data.strokeColor = '7b7b7b';
                   cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                    cur.addClass('black');
             }
             else{
            // alert('map'+ i);
//refer to var disable
            a = disableColor.indexOf(i);
            
            if (a == -1) {
                var abc = 'map' + i;
                var cur = $('#'+abc);
                var data = cur.data('maphilight') || {};
                data.fillColor = 'b3ffcc'; //green
                data.strokeColor = 'b3ffcc';
                data.alwaysOn = !data.alwaysOn;
                cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                cur.addClass('green');
            }
            else {
                var abc = 'map' + i;
                var cur = $('#'+abc);
                var data = cur.data('maphilight') || {};
                data.fillColor = '414141'; //gray
                data.strokeColor = '414141';
                data.alwaysOn = !data.alwaysOn;
                cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                cur.addClass('gray');
            }
             }
             

          }
          
        });
        
       
        
 </script>
		
<style>

.dropbtn
{
	-webkit-appearance: none;
	width:140px;
	font-size:18px;
	padding: 16px 0;
	}
.lbldate
{
	position:absolute;
	z-index:100px;
	color:White;
	top:15px;
	right:20px;
	height:20px;
	}
</style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>

<asp:Panel runat="server" ID="pnlhd" CssClass="pnlhd">
<%--<asp:HiddenField ID="hi2" runat="server" />--%>
</asp:Panel>

<%--<input type="hidden" id="hdid1" value="1" runat="server" class="txtTest" />--%>
<label id="lblTime" style=" font-weight:bold" class="lbldate" ></label>
<div class="header">
<h2>TMS PRAI Hot Desking System</h2>
</div>
<div class="wrap">
    <div class="mtest center">
        <div class="btnlist">
<%--
           <asp:TextBox ID="TextBox1" runat="server" Text=""  Width="350px"  onchange="changeBtnValue(this);"  ></asp:TextBox>--%>
          <input type='button' id='warehouse1' value='West Wing' class="dropbtn" />
          <input type='button' id='warehouse2' value='East Wing' class="dropbtn" />
          <input type='button' id='warehouse3' value='Ai Home' class="dropbtn" />
          <input type='button' id='checkInList' value='Last Person' class="dropbtn" />
          <input type='button' id='checkInList2' value='Arm Record' class="dropbtn" />
          <%--<asp:Button id="checkInList" runat="server" Text="In Office" CssClass="dropbtn" />--%>
        </div>
        
        <div class="btnlist right absolute"> 
         <asp:Button ID="btnCheck" ValidationGroup="ID" runat="server" Text="Check In/Out" class="dropbtn " UseSubmitBehavior ="false"  onclientclick="popupwindow('txtStaffID','txtStaffName'); return false;" />
           <%-- <asp:Button ID="btnCheck" ValidationGroup="ID" runat="server" Text="Check" class="dropbtn youtube" href="Popup/PopUp.aspx" target="_blank"/>--%>
        </div>
    </div>
   <div class="wrapdrop"><h2></h2> </div>
    <div class="wrap hidedrop">
         
        <div class="dropdown">
          <div style="background:white; width:727px; z-index:100; position:absolute; top:130px;">&nbsp; 
           <asp:TextBox ID="txtStaffID" runat="server"  CssClass="txtReadOnly txtStaffID txt"  STYLE="BORDER-WIDTH:0PX;COLOR:black;BACKGROUND-COLOR:Transparent; font-size:22PX; width:200px;font-weight:bold;" Text=""  Enabled="false"></asp:TextBox>&nbsp; &nbsp; 
           <asp:TextBox ID="txtStaffName" runat="server"  CssClass="txtReadOnly txtStaffName txt" STYLE="BORDER-WIDTH:0PX;COLOR:black;BACKGROUND-COLOR:Transparent; font-size:22PX; font-weight:bold;" Text="" Enabled="false" Width="350px"  onkeyup="keyUP(this);" ></asp:TextBox>
           <asp:label ID="userID" CssClass="LabelChange" style=" color:white;font-size:18px;  padding-left:100px;" Text="" runat="server" />
          </div>
         
          <div id="dropdowncontent1" class="dropdown-content dc" >
            
              <asp:Panel runat="server" ID="pnlhd1" CssClass="pnlhd"><div class="label8a"></div><%--<div class="label5a">Biz Dev.</div><div class="label15a">Finance</div><div class="label9a">Reserved</div><div class="label17a">Reserved</div><div class="label14a">Finance</div><div class="label18a">Reserved</div><div class="label69a">Reserved</div>--%></asp:Panel>
           <asp:Image ID="Image1" runat="server" Height="" Width="" ImageUrl="../Acc/left.png" usemap="#simple" CssClass="map" />
                <map  id="tabs" class="tabs" name="simple">
                    <!--left top-->
<%--<area alt="" title=""  shape="poly" id="map1"  coords="244,74,327,74,327,141,244,141,244,74"  />
<area alt="" title=""  shape="poly" id="map2"  coords="330,74,413,74,413,141,330,141,330,141" />--%>
<%--<area alt="" title=""  shape="poly" id="map3"  coords="244,144,327,144,327,212,244,212" />
<area alt="" title=""  shape="poly" id="map4"  coords="330,144,413,144,413,212,330,212"  />
<area alt="" title=""  shape="poly" id="map5"  coords="244,215,327,215,327,285,244,285,244,215" />
<area alt="" title=""  shape="poly" id="map6"  coords="330,215,413,215,413,285,330,285,330,215"  />--%>
                    <%--[2, 3, 6, 7, 9, 11, 14, 16, 18, 20, 22, 26, 31, 32, 35, 37, 39, 41, 43, 45, 48, 50, 52];--%>
                    <!--left center-->
<%--<area alt="" title=""  shape="poly" id="map7"  coords="66,400,198,400,198,444,66,444,66,400"  /><%--coords(x1,y1,x2,y2,x3,y3,x4,y4,x5,y5) ylength:+-136 xlength +- 134(for rectangle) --%>
<%--<area alt="" title=""  shape="poly" id="map8"  coords="199,400,331,400,331,444,199,444,199,400"  /><%--HR and ADMIN--%>
<%--<area alt="" title=""  shape="poly" id="map5"  coords="84,446,220,446,220,490,84,490,84,446"  />
<area alt="" title=""  shape="poly" id="map9"  coords="221,446,357,446,357,490,221,490,221,446"  />--%>

<!--new left center-->
<area alt="" title="" shape="rect" id="map5" coords="66,403,147,443" /><%--c--%>
<area alt="" title="" shape="rect" id="map7" coords="153,403,241,441" />
<area alt="" title="" shape="rect" id="map8" coords="246,403,329,442" /> <%--HR and ADMIN--%>
<area alt="" title="" shape="rect" id="map15" coords="87,448,168,487" /><%--c--%>
<area alt="" title="" shape="rect" id="map9" coords="174,448,266,487" />
<area alt="" title="" shape="rect" id="map17" coords="271,448,350,487" /><%--c--%>

<%--<area alt="" title=""  shape="poly" id="map10"  coords="99,432,184,432,183,502,99,502,99,432"  />
<area alt="" title=""  shape="poly" id="map11"  coords="186,432,271,432,271,502,186,502,186,432"  />
<area alt="" title=""  shape="poly" id="map12"  coords="274,432,358,432,358,502,274,502,274,432"  />
<area alt="" title=""  shape="poly" id="map13"  coords="360,432,448,432,448,502,360,502,360,432"  />--%>

                    <!--left bottom-->
<%--<area alt="" title=""  shape="poly" id="map14"  coords="16,666,148,666,148,710,16,710,16,666"  />
<area alt="" title=""  shape="poly" id="map15"  coords="150,666,282,666,282,710,150,710,150,666"  />
<area alt="" title=""  shape="poly" id="map16"  coords="284,666,416,666,416,710,284,710,284,666"  />

<area alt="" title=""  shape="poly" id="map17"  coords="36,712,168,712,168,753,36,753,36,712"  />
<area alt="" title=""  shape="poly" id="map18"  coords="170,712,302,712,302,753,170,753,170,712"  />
<area alt="" title=""  shape="poly" id="map19"  coords="304,712,438,712,438,753,304,753,304,712"  />--%>

<!--new left bottom-->
<area alt="" title="" shape="rect" id="map66" coords="19,668,95,706" /><%--c--%>
<area alt="" title="" shape="rect" id="map14" coords="99,668,182,706" />
<area alt="" title="" shape="rect" id="map19" coords="187,668,267,707" /><%--c--%>
<area alt="" title="" shape="rect" id="map70" coords="271,668,349,707" /><%--New--%>
<area alt="" title="" shape="rect" id="map71" coords="353,668,426,707" /><%--New--%>
<area alt="" title="" shape="rect" id="map67" coords="31,713,107,752" /><%--c--%>
<area alt="" title="" shape="rect" id="map16" coords="111,713,187,753" />
<area alt="" title="" shape="rect" id="map68" coords="191,713,269,753" /><%--c--%>
<area alt="" title="" shape="rect" id="map18" coords="273,713,352,753" />
<area alt="" title="" shape="rect" id="map69" coords="356,713,436,753" /><%--c--%>

<%--<area alt="" title=""  shape="poly" id="map20"  coords="99,698,184,698,183,767,99,767,99,698"  />
<area alt="" title=""  shape="poly" id="map21"  coords="186,698,271,698,271,767,186,767,186,698"  />
<area alt="" title=""  shape="poly" id="map22"  coords="274,698,358,698,358,767,274,767,274,698"  />
<area alt="" title=""  shape="poly" id="map23"  coords="360,698,448,698,448,767,360,767,360,698"  />--%>
    
                     <!--right -->
<area alt="" title=""  shape="poly" id="map24"  coords="595,130,651,130,651,180,649,183,647,200,649,220,651,225,651,265,593,265,589,255,583,220,583,180,590,140"  /><%--PETER--%>
<area alt="" title=""  shape="poly" id="map23"  coords="583,275,625,275,625,385,583,385,583,275"  /><%--No one--%>
<area alt="" title=""  shape="poly" id="map25"  coords="595,475,650,475,650,520,643,535,643,550,647,560,651,570,651,612,595,612,590,595,583,550,585,520"  /><%--Poh Hiang--%>
<area alt="" title=""  shape="poly" id="map27"  coords="595,670,652,670,652,710,642,735,643,743,646,755,651,765,652,804,595,804,584,755,586,710,593,670"  /><%--JP MANAGER--%>
<area alt="" title=""  shape="poly" id="map28"  coords="595,806,650,806,650,847,645,860,643,875,645,885,646,890,649,897,652,900,650,940,593,940,583,890,585,850,593,806"  /><%--Miss OOI--%> 

                    </map>
                      <div class="desc"><a href="#"></a></div>
          </div>
            <%--east wing--%>
          <div id="dropdowncontent2" class="dropdown-content2 dc">
           <asp:Panel runat="server" ID="pnlhd2" CssClass="pnlhd pnlhd2"><div class="label41a">Help Desk</div><%--<div class="label39a">Tech Support</div><div class="label36a">Tech Support</div><div class="label74a">Tech Support</div><div class="label37a">Tech Support</div>--%></asp:Panel>
            <asp:Image ID="Image2" runat="server" ImageUrl="../Acc/right.png" usemap="#Image2" CssClass="map" />
              <map  id="tabs2" class="tabs" name="Image2">

                <!-- left -->
             <%--<area alt = "" title=""  shape="poly" id="map29" coords="195,90,241,90,241,235,195,235,195,235" />
            <area alt="" title=""  shape="poly" id="map30" coords="200,216,193,216,193,362,146,362,200,216" />

              <area alt="" title=""  shape="poly" id="map31" coords="195,237,241,237,241,382,195,382,195,237" />
             <area alt="" title=""  shape="poly" id="map32" coords="146,362,193,362,193,508,146,508,146,362" />
             <area alt="" title=""  shape="poly" id="map33" coords="195,384,241,384,241,532,195,532,195,384" />
             <area alt="" title=""  shape="poly" id="map34" coords="146,510,192,510,192,659,146,659,146,510" />
             <area alt="" title=""  shape="poly" id="map35" coords="195,534,241,534,241,684,195,684,195,534" />

              <area alt="" title=""  shape="poly" id="map37" coords="146,661,192,661,192,810,146,810,146,661" />
             <area alt="" title=""  shape="poly" id="map38" coords="195,686,241,686,241,830,195,830,195,686" /><%--Network Monitoring--%>
             <%--<area alt="" title=""  shape="poly" id="map40" coords="146,812,192,812,192,955,146,955,146,812" />--%>

            <%--new east wing (left)--%>
            <area alt="" title="" shape="rect" id="map29" coords="195,91,261,217" /> <%--1c--%>
            <area alt="" title="" shape="rect" id="map30" coords="129,66,191,176" /> <%--2c--%>
            <area alt="" title="" shape="rect" id="map31" coords="196,220,258,312" /> <%--3--%>
            <area alt="" title="" shape="rect" id="map32" coords="129,183,189,289" /> <%--4--%>
            <area alt="" title="" shape="rect" id="map33" coords="196,319,257,410" /> <%--5c--%>
            <area alt="" title="" shape="rect" id="map34" coords="129,297,191,385" /> <%--6c--%>
            <area alt="" title="" shape="rect" id="map35" coords="195,415,258,523" /> <%--7--%>
            <area alt="" title="" shape="rect" id="map37" coords="127,505,191,615" /> <%--8--%>
            <area alt="" title="" shape="rect" id="map62" coords="196,529,258,639" /> <%--9c--%>
            <area alt="" title="" shape="rect" id="map63" coords="130,392,190,500" /> <%--10c--%>
            <area alt="" title="" shape="rect" id="map64" coords="195,646,258,749" /> <%--11--%>
            <area alt="" title="" shape="rect" id="map65" coords="127,620,189,725" /> <%--12--%>
            <area alt="" title="" shape="rect" id="map38" coords="198,755,258,860" /> <%--13c--%> <%--Network Monitoring--%>
            <area alt="" title="" shape="rect" id="map40" coords="127,730,191,831" /> <%--14c--%><%--New--%>
            <area alt="" title="" shape="rect" id="map72" coords="127,834,191,952" /> <%--14c--%><%--New--%>
            <area alt="" title="" shape="rect" id="map73" coords="195,865,258,975" /> <%--14c--%><%--New--%>
            <area alt="" title="" shape="rect" id="map74" coords="458,816,575,857" /> <%--14c--%><%--New--%>
                <%--  New desks--%>
            <area alt="" title="" shape="rect" id="map75" coords="577,649,459,605" /> <%--14c--%><%--New--%>
<area alt="" title="" shape="rect" id="map77" coords="658,510,595,402" /> <%--14c--%><%--New--%>

<area alt="" title="" shape="rect" id="map76" coords="592,510,528,402" /> <%--14c--%><%--New--%>

             <area alt="" title=""  shape="poly" id="map36" coords="459,653,605,653,605,700,459,700,459,653" />
                  <area alt="" title=""  shape="poly" id="map39" coords="580,604,718,604,718,651,580,651,580,604" />
                  <area alt="" title=""  shape="poly" id="map41" coords="580,813,718,813,718,861,580,861,580,813" /><%--helpdesk--%>
           <area alt="" title=""  shape="poly" id="map26" coords="459,863,605,863,605,911,459,911,459,863" />
             <%--  <area alt="" title=""  shape="poly" id="map41" coords="407,883,270,883,270,815,336,815,336,834,351,850,407,850,407,883" />
             --%>
            <%-- <area alt="" title=""  shape="poly" id="" coords="588,354,724,354,724,430,660,430,660,404,644,387,588,387,588,354" />--%>
             <%--<area alt="" title=""  shape="poly" id="map35" coords="588,433,724,433,724,512,660,512,660,484,644,470,588,470,588,433" />
             <area alt="" title=""  shape="poly" id="map40" coords="588,581,724,581,724,517,660,517,660,530,644,544,588,544,588,581" />
             <area alt="" title=""  shape="poly" id="map41" coords="588,584,724,584,724,661,660,661,660,635,644,618,588,618,588,584" />
             <area alt="" title=""  shape="poly" id="map34" coords="588,733,724,733,724,665,660,665,660,680,644,697,588,697,588,733" />--%>
             <%--<area alt="" title=""  shape="poly" id="map47" coords="588,736,724,736,724,834,660,834,660,788,644,771,588,771,588,736" />--%>
              </map>
            <div class="desc"><a href="#"></a></div>
          </div>
          
           <div id="dropdowncontent3" class="dropdown-content3 dc">
           <asp:Panel runat="server" ID="pnlhd3" CssClass="pnlhd pnlhd3"></asp:Panel>
            <asp:Image ID="Image3" runat="server" ImageUrl="../Acc/last.png" usemap="#Image3" CssClass="map" />
              <map  id="tabs3" class="tabs" name="Image3">

                <!-- left -->
                 
            <area alt="" title="" shape="poly" id="map46" coords="109,213,131,206,148,198,164,184,175,167,183,147,238,160,214,239,111,267" />
            <area alt="" title="" shape="poly" id="map47" coords="246,162,308,172,304,193,304,217,314,240,327,257,344,272,297,318,220,244" />
            <area alt="" title="" shape="poly" id="map48" coords="460,363,441,296,420,305,398,305,371,295,356,286,344,275,298,322,378,391" />
            <area alt="" title="" shape="poly" id="map49" coords="476,423,456,431,442,443,427,466,415,501,363,493,384,398,460,370" />
            <area alt="" title="" shape="poly" id="map50" coords="414,504,414,528,422,559,436,582,454,596,426,644,358,598,363,495" />
            <area alt="" title="" shape="poly" id="map51" coords="389,706,365,695,341,692,319,698,290,712,258,657,350,605,424,653" />
            <area alt="" title="" shape="poly" id="map52" coords="286,713,266,726,244,751,233,774,230,800,169,798,163,714,255,657" />
            <area alt="" title="" shape="poly" id="map53" coords="103,794,102,776,95,758,88,744,69,726,47,714,66,667,154,714,162,796" />

            <area alt="" title="" shape="poly" id="map42" coords="99,591,125,603,147,607,176,605,194,598,215,585,252,649,163,703,72,655" />
            <area alt="" title="" shape="poly" id="map43" coords="218,584,247,568,262,553,274,531,283,490,351,497,345,597,254,648" />
            <area alt="" title="" shape="poly" id="map44" coords="284,488,288,451,282,426,272,407,246,381,244,379,292,325,369,397,352,495" />
            <area alt="" title="" shape="poly" id="map45" coords="130,347,164,338,195,343,220,359,242,378,290,325,215,253,118,277" />
              </map>
            <div class="desc"><a href="#"></a></div>
          </div>
          
          <div id="dropdowncontent4" class="dropdown-content4 dc" >
            <div style="" >
                    <iframe src="PopUp/list2.aspx"  clASS="map1" id="frame1" runat="server"></iframe>
                    <div class="desc"><a href="#"></a></div>
            </div>
          </div>
   
            <div id="dropdowncontent5" class="dropdown-content5 dc" >
            <div style="" >
                    <iframe src="PopUp/list3.aspx"  clASS="map1" id="Iframe2" runat="server"></iframe>
                    <div class="desc"><a href="#"></a></div>
            </div>
          </div>
        </div>
    </div>
    

</div>
<%--<div class="footer">
<MARQUEE WIDTH=""100%"">Welcome To TMS</MARQUEE>
</div>--%>
</asp:Content>
