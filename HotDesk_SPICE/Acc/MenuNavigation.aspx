<%@ Page Language="C#" MasterPageFile="~/master/Main.master" AutoEventWireup="false" CodeFile="MenuNavigation.aspx.cs" Inherits="Acc_MenuNavigation" title="TMS Check In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        var popupWindow=null;

        function popupwindow(ID, Name) {
            if( document.getElementById('<%=txtStaffName.ClientID%>').value == "") {
                var w = 800;
                var h = 600;
                var left = (screen.width/2)-(w/2);
                var top = (screen.height/2)-(h/2);
                popupWindow = window.open('<%= ResolveUrl("~/acc/PopUp/List.aspx") %>?itm1=' + ID + '&itm2=' + Name,'PopUp', 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=yes,resizable=no,width=800,height=600,top='+top+', left='+left +'');
            }
            else {  
                document.getElementById('<%=txtStaffName.ClientID%>').value = "";
                document.getElementById('<%=txtStaffID.ClientID%>').value = "";
            }
        };

        function parent_disable() {
            if(popupWindow && !popupWindow.closed)
            popupWindow.focus();
        };
    </script>
  
    <script src="../jss/jquery.1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../jss/jquery.maphilight.js"></script>

    <script type="text/javascript">
        $(document).ready(function() {
            $("#dropdowncontent1").show();
            document.getElementById("warehouse1").style.backgroundColor = "BLUE";
            $("#dropdowncontent2").show();
            $("#dropdowncontent3").show();
       
            $(".pnlhd2").hide();
  
            $("#warehouse1").click(function() {
                document.getElementById("warehouse1").style.backgroundColor = "BLUE";
                document.getElementById("warehouse2").style.backgroundColor = "BLACK";   
                document.getElementById("checkInList").style.backgroundColor = "BLACK"; 
                document.getElementById("checkInList2").style.backgroundColor = "BLACK";   
                $("#dropdowncontent1").show();
                $("#dropdowncontent2").hide();
                $("#dropdowncontent3").hide();
                $("#dropdowncontent4").hide();
                $(".pnlhd2").hide();
            });

            $("#warehouse2").click(function() {
                document.getElementById("warehouse1").style.backgroundColor = "BLACK";
                document.getElementById("warehouse2").style.backgroundColor = "BLUE";   
                document.getElementById("checkInList").style.backgroundColor = "BLACK";
                document.getElementById("checkInList2").style.backgroundColor = "BLACK";   
                $("#dropdowncontent1").hide();
                $("#dropdowncontent2").show();
                $("#dropdowncontent3").hide();
                $("#dropdowncontent4").hide();
                $(".pnlhd2").show();
            });

            $("#checkInList").click(function() {
                document.getElementById("<%= frame1.ClientID %>").src = 'PopUp/list2.aspx';
                document.getElementById("warehouse1").style.backgroundColor = "BLACK";
                document.getElementById("warehouse2").style.backgroundColor = "BLACK"; 
                document.getElementById("checkInList").style.backgroundColor = "BLUE"; 
                document.getElementById("checkInList2").style.backgroundColor = "BLACK";       
                $("#dropdowncontent1").hide();
                $("#dropdowncontent2").hide();
                $("#dropdowncontent3").show();
                $("#dropdowncontent4").hide();
                $(".pnlhd2").hide();
            }); 

            $("#checkInList2").click(function() {
                document.getElementById("<%= Iframe2.ClientID %>").src = 'PopUp/list3.aspx';
                document.getElementById("warehouse1").style.backgroundColor = "BLACK";
                document.getElementById("warehouse2").style.backgroundColor = "BLACK"; 
                document.getElementById("checkInList").style.backgroundColor = "BLACK";   
                document.getElementById("checkInList2").style.backgroundColor = "BLUE";      
                $("#dropdowncontent1").hide();
                $("#dropdowncontent2").hide();
                $("#dropdowncontent3").hide();
                $("#dropdowncontent4").show();
                $(".pnlhd2").hide();
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
        function testing(checktype, staffName, seatName)
        { PageMethods.testing(checktype, staffName, seatName, OnSuccess); }

        function OnSuccess(response, userContext, methodName)
        { setTimeout(location.reload(), 60000); alert(response); }

        $(document).ready(function () {
            //var disable = ['1', '8', '9', '20', '21', '25', '27', '29', '32', '38', '39', '42', '43', '46', '47', '50', '51', '54', '55', '56', '59', '60', '63'];
            var disable=['43','44','45','46']
		    //$(".youtube").colorbox({iframe:true, innerWidth:900, innerHeight:600});
		    $('.dc input').click(function(){ 
		        var classname = this.className ;
		        var str =classname.substring(5);
		        var mapclass = "map" + str;
		 
			    if( document.getElementById('<%=txtStaffName.ClientID%>').value == "")
                {
                    //if(mapclass == "map25" || mapclass == "map26" || mapclass == "map27" || mapclass == "map28" 
                    //|| mapclass == "map29" || mapclass == "map30" || mapclass == "map51" || mapclass == "map52" || mapclass == "map53" || mapclass == "map54" 
                    // )
                    //  if( mapclass == "map12" ||mapclass == "map34"||mapclass== "map35")
                    // {
                    //return false;
                                          
                    //}else {
                    /*christopher leong_28 April 2020 - disable certain desk check in
                    refer to disable1 list, if inside list means it is disabled
                    this.id.substring(3, 5) --> get last 2 digit of the area id*/
                    var num1 = this.id.substring(3, 5);
                    if (disable.indexOf(num1) != -1) {
                        alert('false');
                        //return false;
                    }
                    else {
                        if (confirm('Are you sure you want to check out from this desk?')) {
                            testing("OUT","",mapclass);
                            return false;
                        }
                        else {
                            return false;
                        }
                    }
                }
                else {
                    return false;
                }
            });

            if ($('#<%= btnCheck.ClientID %>').val() == "Check In/Out") {
                $('.tabs area').click(function () {
                    if ($(this).hasClass("red")) { }
                    else {
                        var x = $.trim(document.getElementById('<%=txtStaffName.ClientID%>').value);
                        if( document.getElementById('<%=txtStaffName.ClientID%>').value == "" ) {
                                return false;
                        }
                        else
                        {  
                            //if( this.id == "map12"||this.id == "map34"||this.id == "map35"){
                            //return false;
                                          
                            //}
                            /*christopher leong_28 April 2020 - disable certain desk check in
                            refer to disable1 list, if inside list means it is disabled
                            this.id.substring(3, 5) --> get last 2 digit of the area id*/
                            var num = this.id.substring(3, 5);
                            if (disable.indexOf(num) != -1) {
                                return false;
                            }
                            else if( this.id == "map31"){
                                if( x == "LIM POH HIANG" ) {
                                    if (confirm('Are you sure you want to check in this desk?' )) {
                                                      
                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                    }
                                    else {
                                        return false;
                                    }
                                }
                                else {
                                    alert("Sorry, you are not allowed to check in this desk.");
                                }
                            }
                            else if( this.id == "map32") {
                                if( x == "NG SAI HWA" ) 
                                {
                                    if (confirm('Are you sure you want to check in this desk?' )) {
                                                      
                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                    }
                                    else {
                                        return false;
                                    }
                                }
                                else {
                                    alert("Sorry, you are not allowed to check in this desk.");
                                }
                            }
                            else if (this.id == "map33") {
                                if( x == "OOI YINN LING" ) //
                                {
                                    if (confirm('Are you sure you want to check in this desk?' )) {
                                                      
                                    testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                    }
                                    else {
                                        return false;
                                    }
                                }
                                else {
                                    alert("Sorry, you are not allowed to check in this desk.");
                                }
                            }
                            else {
                                if (confirm('Are you sure you want to check in this desk?' )) {
                                                  
                                testing("IN",document.getElementById('<%=txtStaffName.ClientID%>').value,this.id);
                                }
                                else {
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

        $(function () {
          $(".map").maphilight({fillOpacity:1,fillColor:'0ef748'})
        });

        $(document).ready(function () {  

            var chk;
            //list of desk to disable the color
            //var disable = [1, 8, 9, 20, 21, 25, 27, 29, 32, 38, 39, 42, 43, 46, 47, 50, 51, 54, 55, 56, 59, 60, 63];
            /*Teh Hui Ying 17th March 2023 - Add 4 desk which are desks infront MD's Room to change the default color from green to black*/
            var disable =[25, 26, 27, 28, 43, 44, 45, 46]
            var a;
            var i = 1;

            //modified by Christopher Leong 20200505 - added 2 new desk
            for (i; i < 72; i++) {
                if (chk == i) {
                    alert("ERROR occur");
                    location.reload;
                }
                else {
                    chk = i;
                }

                //alert(document.querySelector('.hi10').value[0]+"Y"+document.querySelector('.hi65').value[0]);

                //seat occupied
                if (document.querySelector('.hi' + i).value[0] == 1) {
                    var abc = 'map' + i;
                    var cur = $('#' + abc);
                    var data = cur.data('maphilight') || {};

                    data.alwaysOn = !data.alwaysOn;
                    data.fillColor = 'f84c24';//green
                    data.strokeColor = 'f84c24';
                    cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                    cur.addClass('red');

                    //if (cur.hasClass("current") == false)
                    //{
                    //    var thisTarget = cur.attr("href");
                    //    cur.parents(".tabs").find('area.current').removeClass('current');
                    //    cur.addClass('current');
                    //    cur.parents(".tabs").nextAll(".tab-content").children(":visible").fadeOut(1, function () {
                    //        $(thisTarget).fadeIn("fast");
                    //    });
                    //}
                }
                else {
                    //refer to var disable
                    a = disable.indexOf(i);

                    if (a == -1) {
                        var abc = 'map' + i;
                        var cur = $('#' + abc);
                        var data = cur.data('maphilight') || {};
                        data.fillColor = '0ef748'; //green
                        data.strokeColor = '0ef748';
                        data.alwaysOn = !data.alwaysOn;
                        cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                        cur.addClass('green');
                    }
                    else {
                        var abc = 'map' + i;
                        var cur = $('#' + abc);
                        var data = cur.data('maphilight') || {};
                        data.fillColor = '414141'; //gray
                        data.strokeColor = '414141';
                        data.alwaysOn = !data.alwaysOn;
                        cur.data('maphilight', data).trigger('alwaysOn.maphilight');
                        cur.addClass('black');
                    }
                }
            }
        });
    </script>
		
    
    <style>
        .dropbtn
        {
            -webkit-appearance: none;
            width:160px;
	        padding: 16px 0;
	        padding-left:-5px;
        }
        .lbldate
        {
	        position:absolute;
	        z-index:100px;
	        color:White;
	        top:15px;
	        right:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    
    <asp:Panel runat="server" ID="pnlhd" CssClass="pnlhd">
        <%--<asp:HiddenField ID="hi2" runat="server" />--%>
    </asp:Panel>

    <%--<input type="hidden" id="hdid1" value="1" runat="server" class="txtTest" />--%>
    <label id="lblTime" style=" font-weight:bold" class="lbldate" ></label>
    
    <div class="header">
        <h2>TMS SPICE Hot Desking System</h2>
    </div>
    
    <div class="wrap">
        <div class="mtest center">
            <div class="btnlist">
                <%--<asp:TextBox ID="TextBox1" runat="server" Text=""  Width="491px"  onchange="changeBtnValue(this);"  ></asp:TextBox>--%>
                <input type='button' id='warehouse1' value='Central Park' class="dropbtn" />
                <input type='button' id='warehouse2' value='IToT Hall' class="dropbtn" />
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
                    <asp:TextBox ID="txtStaffID" runat="server"  CssClass="txtReadOnly txtStaffID txt"  STYLE="WIDTH: 150PX; BORDER-WIDTH:0PX;COLOR:black;BACKGROUND-COLOR:Transparent; font-size:22PX; font-weight:bold;" Text=""  Enabled="false"></asp:TextBox>&nbsp; &nbsp; 
                    <asp:TextBox ID="txtStaffName" runat="server"  CssClass="txtReadOnly txtStaffName txt" STYLE="BORDER-WIDTH:0PX;COLOR:black;BACKGROUND-COLOR:Transparent; font-size:22PX; font-weight:bold;" Text="" Enabled="false" Width="491px"  onkeyup="keyUP(this);" ></asp:TextBox>
                    <asp:label ID="userID" CssClass="LabelChange" style="display:none; color:white;font-size:18px;  padding-left:100px;" Text="" runat="server" />
                </div>
                
                <div id="dropdowncontent1" class="dropdown-content dc" style="border-color:red;border:solid 5px solid red">
                    <asp:Panel runat="server" ID="pnlhd1" CssClass="pnlhd" BorderColor="Black"></asp:Panel>
                    <asp:Image ID="Image1" runat="server" Height="" Width="" ImageUrl="../Acc/left.png" usemap="#simple" CssClass="map" />
                  
                    <map  id="tabs" class="tabs" name="simple">
					<%--<area title=""  shape="poly" id="map1"  coords="170,207,211,207,211,289,128,289,128,250,160,250,170,235,170,207"  />--%>
                        
<%--Max System -Kang Kah Cheng was invited to the meeting.

[8:29 PM] 
8:29 PM Meeting started

[9:01 PM] 
Chong, Charlene/TMS(MY)/Charlene Chong Seok Yun(Application Solution Sect Mgr) was invited to the meeting.

[9:27 PM] Max System - Rosmieza--%>
    <!--left-->
<area alt="" title=""  shape="poly" id="map1"  coords="6,32,6,79,62,88,121,82,120,30,90,31,64,37,42,32" />
<area alt="" title=""  shape="poly" id="map2"  coords="189,31,189,78,246,89,304,81,303,32,269,33,247,36,225,31" />
<area alt="" title=""  shape="poly" id="map3"  coords="426,32,426,79,483,90,541,82,540,33,510,31,484,37,462,32" />
<%-- Remove the area to prevent user check-in the specific place --%>
<%--<area alt="" title=""  shape="poly" id="map4"  coords="600,33,600,80,656,89,715,83,714,31,684,32,658,38,636,33" />--%>
 
<area alt="" title=""  shape="poly" id="map5"  coords="212,206,211,290,128,290,128,247,167,247,168,206" />
<area alt="" title=""  shape="poly" id="map6"  coords="214,205,213,291,298,291,298,251,258,246,255,205" />
<area alt="" title=""  shape="poly" id="map7"  coords="418,205,459,204,459,289,376,292,375,248,414,248" />
<area alt="" title=""  shape="poly" id="map8"  coords="461,206,460,292,545,292,545,252,505,247,502,206" />
 
<area alt="" title=""  shape="poly" id="map9"  coords="128,292,213,293,211,375,169,375,168,335,129,333" />
<area alt="" title=""  shape="poly" id="map10"  coords="214,292,212,376,257,377,259,334,299,332,297,291" />
<area alt="" title=""  shape="poly" id="map11"  coords="375,291,460,292,460,376,415,376,415,334,373,332" />
<area alt="" title=""  shape="poly" id="map12"  coords="461,292,459,376,504,377,506,334,546,332,544,291" />
<area alt="" title=""  shape="poly" id="map13"  coords="169,428,213,430,213,515,128,513,129,473,168,470" />
<area alt="" title=""  shape="poly" id="map14"  coords="211,428,212,512,298,513,297,473,259,468,258,427" />
<area alt="" title=""  shape="poly" id="map15"  coords="459,513,458,429,416,430,414,470,375,471,374,513" />
<area alt="" title=""  shape="poly" id="map16"  coords="461,430,461,513,546,512,544,473,506,469,504,428" />
<area alt="" title=""  shape="poly" id="map17"  coords="129,515,214,514,212,599,169,598,169,556,128,556" />
<area alt="" title=""  shape="poly" id="map18"  coords="212,514,214,598,257,600,259,557,299,555,298,515" />
<area alt="" title=""  shape="poly" id="map19"  coords="374,515,459,514,458,599,414,598,414,556,373,556" />
<area alt="" title=""  shape="poly" id="map20"  coords="460,515,458,599,503,600,505,557,545,555,544,515" />
<area alt="" title=""  shape="poly" id="map21"  coords="212,685,211,601,170,601,167,642,128,643,127,685" />
<area alt="" title=""  shape="poly" id="map22"  coords="213,599,213,684,299,684,297,643,259,641,256,599" />
<area alt="" title=""  shape="poly" id="map23"  coords="459,683,458,599,414,598,414,640,374,644,374,683" />
<area alt="" title=""  shape="poly" id="map24"  coords="459,601,460,686,545,685,543,646,505,642,503,601" />
<area alt="" title=""  shape="poly" id="map25"  coords="127,687,212,686,211,771,167,770,167,728,126,728" />
<area alt="" title=""  shape="poly" id="map26"  coords="215,685,213,769,258,770,260,727,300,727,299,685" />
<area alt="" title=""  shape="poly" id="map27"  coords="374,685,459,684,458,769,417,770,414,728,376,727" />
<area alt="" title=""  shape="poly" id="map28"  coords="460,685,460,770,504,770,506,728,545,727,546,684" />
 
<area alt="" title=""  shape="poly" id="map29"  coords="459,906,457,955,494,955,517,946,539,955,570,954,569,906,513,895" />


                      
                    </map>
                    
                    <div class="desc"><a href="#"></a></div>
                </div>
              
                <div id="dropdowncontent2" class="dropdown-content2 dc">
                    <asp:Panel runat="server" ID="pnlhd2" CssClass="pnlhd pnlhd2"></asp:Panel>
                    <asp:Image ID="Image2" runat="server" ImageUrl="../Acc/right.png" usemap="#Image2" CssClass="map" />
                  
                    <map id="Map1" class="tabs" name="Image2">
                        <%--<!-- left -->
                        <area title=""  shape="rect" id="map36" coords="207,63,300,92" />
                        <area title=""  shape="rect" id="map37" coords="207,95,298,122" />
                        <area title=""  shape="rect" id="map38" coords="302,95,393,121" />
                        <area title=""  shape="rect" id="map39" coords="237,223,288,302" />
                        <area title=""  shape="rect" id="map40" coords="235,308,287,385" />
                        <area title=""  shape="rect" id="map41" coords="295,223,345,302" />
                        <area title=""  shape="rect" id="map42" coords="295,310,345,386" /> 
                        <area title=""  shape="rect" id="map43" coords="561,59,714,122" />
                        <area title=""  shape="rect" id="map44" coords="479,94,569,120" />
                        <area title=""  shape="rect" id="map45" coords="575,62,665,88" />
                        <area title=""  shape="rect" id="map46" coords="575,94,665,120" />
                        <area title=""  shape="rect" id="map47" coords="516,198,567,278" />
                        <area title=""  shape="rect" id="map48" coords="517,287,565,362" />
                        <area title=""  shape="rect" id="map49" coords="575,199,623,278" />
                        <area title=""  shape="rect" id="map50" coords="574,287,624,363" />
                        <area title=""  shape="rect" id="map51" coords="516,394,567,471" />
                        <area title=""  shape="rect" id="map52" coords="516,479,566,557" />
                        <area title=""  shape="rect" id="map53" coords="574,395,623,469" />
                        <area title=""  shape="rect" id="map54" coords="573,479,624,557" />
                        <area title=""  shape="rect" id="map55" coords="303,65,395,90" />

                        added by ChristopherLeong 20200505 --> add 2 new desk
                        <area title=""  shape="rect" id="map64" coords="238,448,287,525" />
                        <area title=""  shape="rect" id="map65" coords="296,448,344,525" /> 
                         added by Goh Jin Hau --> added 2 new desks
                        <area title=""  shape="rect" id="map66" coords="236,533,287,610" /> 
                        <area title=""  shape="rect" id="map67" coords="295,533,344,611" /> 
                    
                        <!-- right  -->
                 
                        <!--bottom right-->
                        <area title=""  shape="rect" id="map56" coords="520,595,569,674" />
                        <area title=""  shape="rect" id="map57" coords="518,680,567,756" />
                        <area title=""  shape="rect" id="map58" coords="577,595,625,672" />
                        <area title=""  shape="rect" id="map59" coords="577,682,627,757" />
                    
                        <!--bottom left-->
                        <area title=""  shape="rect" id="map60" coords="237,789,289,874" />
                        <area title=""  shape="rect" id="map61" coords="237,879,289,959" />
                        <area title=""  shape="rect" id="map62" coords="295,789,347,875" />
                        <area title=""  shape="rect" id="map63" coords="295,879,349,957" />


                         added by Goh Jin Hau 20230106 --> added 4 new desks
                        <area title=""  shape="rect" id="map68" coords="517,792,570,870" /> 
                        <area title=""  shape="rect" id="map69" coords="577,795,626,869" /> 
                        <area title=""  shape="rect" id="map70" coords="519,878,569,956" /> 
                        <area title=""  shape="rect" id="map71" coords="578,878,627,956" />--%>

                        <%-- 20260313 by Wilson, change the layout for IToT Hall --%>
                        <%-- 4 besides 6 pax meeting table (1st top row)--%>
                         <area alt="" title=""  shape="rect" id="map36" coords="243,47,337,80" />
                         <area alt="" title=""  shape="rect" id="map37" coords="341,48,434,80" />
                         <area alt="" title=""  shape="rect" id="map38" coords="244,85,338,117" />
                         <area alt="" title=""  shape="rect" id="map39" coords="341,82,434,117" />
                        <%-- 2nd row tables --%>
                         <area alt="" title=""  shape="poly" id="map40" coords="256,224,244,254,330,289,343,259" />
                         <area alt="" title=""  shape="poly" id="map41" coords="346,259,333,291,420,325,433,295" />
                         <area alt="" title=""  shape="poly" id="map42" coords="243,258,230,288,316,323,329,292" /> 
                         <area alt="" title=""  shape="poly" id="map47" coords="331,293,320,324,406,359,418,329" />
                         <area alt="" title=""  shape="poly" id="map48" coords="526,224,515,254,600,288,612,259" />
                         <area alt="" title=""  shape="poly" id="map49" coords="616,260,603,290,690,325,702,295" />
                         <area alt="" title=""  shape="poly" id="map50" coords="512,259,500,287,586,322,598,293" />
                         <area alt="" title=""  shape="poly" id="map51" coords="603,293,591,324,676,359,688,329" />
                        <%-- 3rd row tables --%>
                         <area alt="" title=""  shape="poly" id="map52" coords="255,423,243,455,329,488,342,459" />
                         <area alt="" title=""  shape="poly" id="map53" coords="345,459,333,490,419,524,431,495" />
                         <area alt="" title=""  shape="poly" id="map54" coords="242,458,230,487,315,522,327,492" />
                         <area alt="" title=""  shape="poly" id="map55" coords="331,494,319,524,405,558,417,529" />
                         <area alt="" title=""  shape="rect" id="map56" coords="503,465,598,499" />
                         <area alt="" title=""  shape="rect" id="map57" coords="603,467,694,498" />
                         <area alt="" title=""  shape="rect" id="map58" coords="505,502,598,535" />
                         <area alt="" title=""  shape="rect" id="map59" coords="603,503,694,535" />
                        <%-- 4th row tables --%>
                         <area alt="" title=""  shape="poly" id="map60" coords="78,676,62,702,137,745,152,719" />
                         <area alt="" title=""  shape="poly" id="map61" coords="156,720,140,746,214,788,230,761" />
                         <area alt="" title=""  shape="poly" id="map62" coords="230,763,217,789,292,832,307,807" />
                         <area alt="" title=""  shape="poly" id="map63" coords="310,809,296,834,369,876,384,851" />
                         <area alt="" title=""  shape="poly" id="map64" coords="61,705,46,732,120,773,135,748" />
                         <area alt="" title=""  shape="poly" id="map65" coords="138,750,124,775,197,817,212,791" />
                         <area alt="" title=""  shape="poly" id="map66" coords="215,793,200,819,275,862,290,836" />
                         <area alt="" title=""  shape="poly" id="map66" coords="215,793,200,819,275,862,290,836" />
                         <area alt="" title=""  shape="poly" id="map66" coords="215,793,200,819,275,862,290,836" />
                         <area alt="" title=""  shape="poly" id="map67" coords="293,838,278,863,353,906,368,881" />
                         <area alt="" title=""  shape="poly" id="map68" coords="486,707,498,737,584,702,572,673" /> 
                         <area alt="" title=""  shape="poly" id="map69" coords="576,670,588,701,674,666,662,636" /> 
                         <area alt="" title=""  shape="poly" id="map70" coords="499,740,512,770,599,735,586,705" /> 
                         <area alt="" title=""  shape="poly" id="map71" coords="590,705,602,734,688,700,676,671" />
                    </map>
                
                    <div class="desc"><a href="#"></a></div>
                </div>
          
                <div id="dropdowncontent3" class="dropdown-content3 dc" >
                    <div style="" >
                        <iframe src="PopUp/list2.aspx"  clASS="map1" id="frame1" runat="server"></iframe>
                        <div class="desc"><a href="#"></a></div>
                    </div>
                </div>
                
                <div id="dropdowncontent4" class="dropdown-content4 dc" >
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

