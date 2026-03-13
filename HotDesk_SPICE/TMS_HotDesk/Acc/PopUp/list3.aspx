<%@ Page Language="VB" AutoEventWireup="false" CodeFile="list3.aspx.vb" Inherits="Acc_PopUp_list3" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server"> 
<script src="../../jss/jquery.1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
$(document).ready(function(){

        document.getElementById("sub2").style.backgroundColor = "BLACK";
        document.getElementById("sub1").style.backgroundColor = "BLUE"; 
            
        $("#subdrop2").hide();
        $("#subdrop1").show();
 
    $("#sub1").click(function(){

        document.getElementById("sub2").style.backgroundColor = "BLACK";
        document.getElementById("sub1").style.backgroundColor = "BLUE"; 
            
        $("#subdrop2").hide();
        $("#subdrop1").show();
    });
    
     $("#sub2").click(function(){

        document.getElementById("sub1").style.backgroundColor = "BLACK";
        document.getElementById("sub2").style.backgroundColor = "BLUE"; 
            
        $("#subdrop1").hide();
        $("#subdrop2").show();
    });

});



</script>

<link href="../../css_new/TMSAccess.css" rel="stylesheet" type="text/css" />
   <style>
 .framebody
{
    margin-top: 40px;	}
.dropbtn
{
	width:200px;
	padding: 16px 0;
	}
.map2
{
	height: 850px;    width: 710px !important; border:0;
	}
</style>
</head>
<body class="framebody">
    <div class="wrap">
        <div class="mtest center">
          <div class="btnlist">
          <input type='button' id='sub1' value='First Arm Person' class="dropbtn" />
          <input type='button' id='sub2' value='Last Arm Person' class="dropbtn" />
         </div>
        </div> 
    </div> 
    <div class="wrap hidedrop">
        <div class="dropdown">
            <div id="subdrop1" class="dropdown-content4 dc" >
                <div style="" >
                        <iframe src="FirstArm.aspx"  clASS="map1 map2" id="Iframe2" runat="server"></iframe>
       
                </div>
            </div>
            <div id="subdrop2" class="dropdown-content4 dc" >
                <div style="" >
                        <iframe src="LastArm.aspx"  clASS="map1 map2" id="Iframe1" runat="server"></iframe>
                        
                </div>
            </div>
        </div> 
    </div>         
</body>
</html>
