<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuNavigation1.aspx.vb" Inherits="Acc_MenuNavigation1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>

<script type="text/javascript">

//    var popupWindow=null; popupWindow = 

  function popupwindow(ID, Name) {
     if( document.getElementById('<%=txtStaffName.ClientID%>').value == "")
     {
        var w = 800;
        var h = 600;
        var left = (screen.width/2)-(w/2);
        var top = (screen.height/2)-(h/2);
        window.open('<%= ResolveUrl("~/acc/PopUp/List.aspx") %>?itm1=' + ID + '&itm2=' + Name,'PopUp', 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=800,height=600,top='+top+', left='+left +'');
    
     }
     
     else
     {  
        document.getElementById('<%=txtStaffName.ClientID%>').value = "";
        document.getElementById('<%=txtStaffID.ClientID%>').value = "";
      }
   };
   
//function parent_disable() {
//if(popupWindow && !popupWindow.closed)
//popupWindow.focus();
//}
</script>


  
<script src="../jss/jquery.1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../jss/jquery.maphilight.js"></script>

<script type="text/javascript">
    $(function() {
      $(".map").maphilight({fillOpacity:1,fillColor:'0ef748'})
    });
 
 $(document).ready(function(){  

for (i = 1; i < 51; i++) {

              if (document.querySelector('.hi' + i).value[0]==1) {
                   
                   var abc = 'map'+ i;
                   var cur = $('#'+abc);
                   var data = cur.data('maphilight') || {};
                   
                   data.alwaysOn = !data.alwaysOn;
                   data.fillColor = 'f84c24';//green
                   data.strokeColor = 'f84c24';
                   cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                    cur.addClass('red');
                  
                   if (cur.hasClass("current") == false)
                   {
                       var thisTarget = cur.attr("href");
                       cur.parents(".tabs").find('area.current').removeClass('current');
                       cur.addClass('current');

                       cur.parents(".tabs").nextAll(".tab-content").children(":visible").fadeOut(1, function() {
                           $(thisTarget).fadeIn("fast");
                       });
                  }
                 
             }
             else{
             
                 var abc = 'map'+ i;
                 var cur = $('#'+abc);
                 var data = cur.data('maphilight') || {};
                   data.fillColor = '0ef748'; //red
                   data.strokeColor = '0ef748';
                 data.alwaysOn = !data.alwaysOn;
                 cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                  cur.addClass('green');
             }

          }
        });
        
        
 </script>
	
<script type="text/javascript">
$(document).ready(function(){

$("#dropdowncontent1").show();
document.getElementById("warehouse1").style.backgroundColor = "BLUE";
        $("#dropdowncontent2").hide();
        $("#dropdowncontent3").hide();
  
    $("#warehouse1").click(function(){
        document.getElementById("warehouse1").style.backgroundColor = "BLUE";
        document.getElementById("warehouse2").style.backgroundColor = "BLACK";   
        document.getElementById("checkInList").style.backgroundColor = "BLACK"; 
        $("#dropdowncontent1").show();
        $("#dropdowncontent2").hide();
        $("#dropdowncontent3").hide();
    });
    $("#warehouse2").click(function(){
        document.getElementById("warehouse1").style.backgroundColor = "BLACK";
        document.getElementById("warehouse2").style.backgroundColor = "BLUE";   
        document.getElementById("checkInList").style.backgroundColor = "BLACK";
        $("#dropdowncontent1").hide();
        $("#dropdowncontent2").show();
        $("#dropdowncontent3").hide();
    });
    $("#checkInList").click(function(){
        document.getElementById("warehouse1").style.backgroundColor = "BLACK";
        document.getElementById("warehouse2").style.backgroundColor = "BLACK"; 
        document.getElementById("checkInList").style.backgroundColor = "BLUE";      
        $("#dropdowncontent1").hide();
        $("#dropdowncontent2").hide();
        $("#dropdowncontent3").show();
    });

});
</script>

 
<script type ="text/javascript" src="../js/jquery.colorbox.js"></script>
<link rel="stylesheet" href ="../css/colorbox.css" />

<link href="../css_new/TMSAccess.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" >

function testing(checktype,staffName,seatName)
{PageMethods.testing(checktype,staffName,seatName,OnSuccess);}

function OnSuccess(response, userContext, methodName) 
{location.reload();alert(response);}

			$(document).ready(function(){
				//$(".youtube").colorbox({iframe:true, innerWidth:900, innerHeight:500});
			    if ($('#<%= btnCheck.ClientID %>').val()=="Check In/Out"){
			       
			              
                     $('.tabs area').click(function(){ 
                              if ($(this ).hasClass( "red" )){
                              
                                       if( document.getElementById('<%=txtStaffName.ClientID%>').value == "")
                                       {
//                                            if (confirm('Are you sure you want to check out from this desk?')) {
//                                              
                                            testing("OUT","",this.id);
//                                           } else {
//                                            return false;
//                                            }
                                       }
                                       else
                                       {
                                            testing("CHECK","",this.id);
                                       }

                             }else{
                                       if( document.getElementById('<%=txtStaffName.ClientID%>').value == "" )
                                       {
                                             return false;
                                       }
                                       else
                                       {    
//                                       if (confirm('Are you sure you want to check in this desk?')) {
                                              
                                            testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
//                                           } else {
//                                            return false;
//                                            }
                                            
                                       }
                              };
                            
                          });
                 };
			});
		</script>

<form runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>

<asp:Panel runat="server" ID="pnlhd" CssClass="pnlhd">
<%--<asp:HiddenField ID="hi2" runat="server" />--%>
</asp:Panel>

<%--<input type="hidden" id="hdid1" value="1" runat="server" class="txtTest" />--%>
<div class="header">
<h2>TMS Check In</h2>
</div>
<div class="wrap">
     <div class="mtest">
        <div class="btnlist">
<%--
           <asp:TextBox ID="TextBox1" runat="server" Text=""  Width="350px"  onchange="changeBtnValue(this);"  ></asp:TextBox>--%>
          <input type='button' id='warehouse1' value='Center' class="dropbtn" />
          <input type='button' id='warehouse2' value='IToT Hall' class="dropbtn" />
          <input type='button' id='checkInList' value='Last Person' class="dropbtn" />
          <%--<asp:Button id="checkInList" runat="server" Text="In Office" CssClass="dropbtn" />--%>
        </div>
        
        <div class="btnlist right"> 
         <asp:Button ID="btnCheck" ValidationGroup="ID" runat="server" Text="Check In/Out" class="dropbtn " UseSubmitBehavior ="false"  onclientclick="popupwindow('txtStaffID','txtStaffName'); return false;" />
           <%-- <asp:Button ID="btnCheck" ValidationGroup="ID" runat="server" Text="Check" class="dropbtn youtube" href="Popup/PopUp.aspx" target="_blank"/>--%>
        </div>
    </div>
    <div class="wrap">
      
        <div class="dropdown">
          <div style="background:blue; width:727px; z-index:100; position:absolute; top:132px;">&nbsp; 
           <asp:TextBox ID="txtStaffID" runat="server"  CssClass="txtReadOnly txtStaffID"  STYLE="BORDER-WIDTH:0PX;COLOR:White;BACKGROUND-COLOR:Transparent; font-size:15PX; font-weight:bold;" Text=""  Enabled="false"></asp:TextBox>&nbsp; &nbsp; 
           <asp:TextBox ID="txtStaffName" runat="server"  CssClass="txtReadOnly txtStaffName" STYLE="BORDER-WIDTH:0PX;COLOR:White;BACKGROUND-COLOR:Transparent; font-size:15PX; font-weight:bold;" Text="" Enabled="false" Width="350px"  onkeyup="keyUP(this);" ></asp:TextBox>
           <asp:label ID="userID" CssClass="LabelChange" style=" color:white;font-size:18px;  padding-left:100px;" Text="" runat="server" />
          </div>
         
          <div id="dropdowncontent1" class="dropdown-content dc" >
          
           <asp:Image ID="Image1" runat="server" Height="" Width="" ImageUrl="../Acc/left.png" usemap="#simple" CssClass="map" />
                <map  id="tabs" class="tabs" name="simple">
                    <!--left-->
<area alt="" title=""  shape="poly" id="map1"  coords="143,75,189,75,189,165,99,165,99,120,132,120,143,110,143,75"  />
<area alt="" title=""  shape="poly" id="map2"  coords="192,75,237,75,238,110,248,121,282,121,282,165,192,165, 192,75 " />
<area alt="" title=""  shape="poly" id="map3"  coords="143,257,189,257,189,167,99,168,99,210,132,210,143,223,143,257" />
<area alt="" title=""  shape="poly" id="map4"  coords="192,257,237,257,238,223,248,210,282,210,282,167,192,167, 192,257 " />

<area alt="" title=""  shape="poly" id="map5"  coords="143,315,189,315,189,406,99,406,99,362,132,362,143,349,143,315" />
<area alt="" title=""  shape="poly" id="map6"  coords="192,316,237,315,238,347,248,361,282,361,282,406,192,405, 192,316 " />
<area alt="" title=""  shape="poly" id="map7"  coords="143,498,189,498,189,408,99,408,99,451,132,451,143,464,143,498" />
<area alt="" title=""  shape="poly" id="map8"  coords="192,498,237,498,238,464,248,451,282,451,282,408,192,408, 192,498 " />

<area alt="" title=""  shape="poly" id="map9"  coords="143,500,189,500,189,590,99,590,99,547,132,547,143,534,143,500" />
<area alt="" title=""  shape="poly" id="map10"  coords="192,500,237,500,238,535,248,547,282,547,282,590,192,590, 192,500 " />
<area alt="" title=""  shape="poly" id="map11"  coords="143,682,189,682,189,593,99,593,99,635,132,635,143,648,143,682" />
<area alt="" title=""  shape="poly" id="map12"  coords="192,682,237,682,238,652,248,635,282,635,282,593,192,593, 192,682 " />
                  
                    <!--middle-->
                    <area alt="" title=""  shape="poly" id="map13"  coords="402,75,447,75,447,165,357,165,357,120,389,120,402,110,402,75" />
<area alt="" title=""  shape="poly" id="map14"  coords="450,75,495,75,495,110,507,121,539,121,539,165,450,165, 450,75 " />
<area alt="" title=""  shape="poly" id="map15"  coords="402,257,447,257,447,167,357,168,357,210,389,210,402,223,402,257" />
<area alt="" title=""  shape="poly" id="map16"  coords="450,257,495,257,495,223,507,210,539,210,539,167,450,167, 450,257 " />
<area alt="" title=""  shape="poly" id="map17"  coords="402,315,446,315,446,405,357,405,357,362,390,362,402,349,402,315" />
<area alt="" title=""  shape="poly" id="map18"  coords="450,316,494,315,494,347,507,361,539,361,539,405,450,405, 450,316 " />
<area alt="" title=""  shape="poly" id="map19"  coords="402,498,446,498,446,408,357,408,357,451,389,451,402,464,402,498" />
<area alt="" title=""  shape="poly" id="map20"  coords="450,498,494,498,494,464,507,451,539,451,539,408,450,408, 450,498 " />
<area alt="" title=""  shape="poly" id="map21"  coords="402,500,446,500,446,590,357,590,357,547,390,547,402,534,402,500" />
<area alt="" title=""  shape="poly" id="map22"  coords="450,500,494,500,494,535,507,547,539,547,539,590,450,590, 450,500 " />
<area alt="" title=""  shape="poly" id="map23"  coords="402,682,446,682,446,593,357,593,357,635,390,635,402,648,402,682" />
<area alt="" title=""  shape="poly" id="map24"  coords="450,682,494,682,494,652,507,635,539,635,539,593,450,593, 450,682 " />

 <!--right-->
<area alt="" title=""  shape="poly" id="map25"  coords="614,107,704,107,704,197,659,197,659,165,648,150,614,150,614,107" />
<area alt="" title=""  shape="poly" id="map26"  coords="614,290,704,290,704,200,659,200,659,231,646,247,614,247,614,290" />

<area alt="" title=""  shape="poly" id="map27"  coords="614,293,704,293,704,382,659,382,659,350,645,335,614,335,614,293" />
<area alt="" title=""  shape="poly" id="map28"  coords="614,474,704,474,704,385,659,385,659,416,647,432,614,432,614,474" />

<area alt="" title=""  shape="poly" id="map29"  coords="614,477,704,477,704,566,659,566,659,532,649,520,614,520,614,477" />
<area alt="" title=""  shape="poly" id="map30"  coords="614,659,704,659,704,570,659,570,659,605,647,617,614,617,614,659" />


                   
                    </map>
            <div class="desc"><a href="#"></a></div>
          </div>
          <div id="dropdowncontent2" class="dropdown-content2 dc">
            <asp:Image ID="Image2" runat="server" ImageUrl="../Acc/right.png" Height="725px" Width="850px" usemap="#Image2" CssClass="map" />
              <map  id="Map1" class="tabs" name="Image2">

                <!-- left -->
                <area alt="" title=""  shape="poly" id="map31" coords="325,222,360,222,360,273,325,273,325,222" />
                <area alt="" title=""  shape="poly" id="map32" coords="362,222,397,222,397,273,362,273,362,222" />
                <area alt="" title=""  shape="poly" id="map33" coords="325,276,360,276,360,326,325,326,325,276" />
                <area alt="" title=""  shape="poly" id="map34" coords="362,276,397,276,397,326,362,326,362,276" />

                <area alt="" title=""  shape="poly" id="map35" coords="325,390,360,390,360,442,325,442,325,390" />
                <area alt="" title=""  shape="poly" id="map36" coords="325,445,360,445,360,495,325,495,325,445" />
                <area alt="" title=""  shape="poly" id="map37" coords="363,390,397,390,397,442,363,442,363,390" />
                <area alt="" title=""  shape="poly" id="map38" coords="363,445,397,445,397,495,363,495,363,445" />


                <!--right-->
                <area alt="" title=""  shape="poly" id="map39" coords="502,222,537,222,537,274,502,274,502,222" />
                <area alt="" title=""  shape="poly" id="map40" coords="502,276,537,276,537,325,502,325,502,276" />
               <area alt="" title=""  shape="poly" id="map41" coords="539,222,573,222,573,274,539,274,539,222" />
                <area alt="" title=""  shape="poly" id="map42" coords="539,276,573,276,573,325,539,325,539,276" />

<area alt="" title=""  shape="poly" id="map43" coords="502,391,536,391,536,441,502,441,502,391" />
<area alt="" title=""  shape="poly" id="map44" coords="502,443,536,443,536,495,502,495,502,443" />
<area alt="" title=""  shape="poly" id="map45" coords="539,391,574,391,574,441,539,441,539,391" />
<area alt="" title=""  shape="poly" id="map46" coords="539,443,574,443,574,495,539,495,539,443" />


<area alt="" title=""  shape="poly" id="map47" coords="502,525,537,525,537,576,502,576,502,525" />
<area alt="" title=""  shape="poly" id="map48" coords="502,578,537,578,537,628,502,628,502,603" />
<area alt="" title=""  shape="poly" id="map49" coords="540,525,574,525,574,576,540,576,540,525" />
<area alt="" title=""  shape="poly" id="map50" coords="540,578,574,578,574,628,540,628,540,603" />


                <!-- right  -->
                 
              
               
              </map>
            <div class="desc"><a href="#"></a></div>
          </div>
          
          <div id="dropdowncontent3" class="dropdown-content3 dc" >
    
           
            <div style="" >
            <iframe src="PopUp/list2.aspx"  clASS="map1">
            
            </iframe>
            
        
            
            </div>

            
    
          </div>
   
        </div>
    </div>
    

</div>
<div class="footer">
<MARQUEE WIDTH=""100%"">Welcome To TMS</MARQUEE>
</div>
</form>
</body>
</html>
