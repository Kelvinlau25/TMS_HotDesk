<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Menu.aspx.cs" Inherits="Style2_Menu" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= ConfigurationManager.AppSettings["title"] %></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <link href="../resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
    <link href="../css/Menu.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.4.3.js" type="text/javascript"></script>
    <script src="../js/ext-base.js" type="text/javascript"></script>
    <script src="../js/ext-all.js" type="text/javascript"></script>
    <script type="text/javascript">    
        function change_vs(obj) {
            var vs_id = obj.checked;

            if (vs_id)
                Ext.get(obj.id + "-vs").setStyle('display', 'list-item');
            else
                Ext.get(obj.id + "-vs").setStyle('display', 'none');
        }

        Ext.onReady(function () {

            Ext.state.Manager.setProvider(new Ext.state.CookieProvider());

            var viewport = new Ext.Viewport({
                layout: 'border',
                items: [
                    new Ext.BoxComponent({
                        region: 'north',
                        el: 'north',
                        height: 100
                    }),
                    {
                        region: 'west',
                        id: 'west-panel',
                        title: 'Menu',
                        split: true,
                        width: 200,
                        minSize: 175,
                        maxSize: 300,
                        collapsible: true,
                        margins: '0 0 0 5',
                        layout: 'accordion',
                        layoutConfig: {
                            animate: true
                        },
                        items: <%= _list.ToString() %>
				},
                {
                    region: 'center',
                    margins: '0',
                    layout: 'column',
                    autoScroll: true,
                    items: [{
                        columnWidth: 1,
                        title: 'Page',
                        contentEl: 'main-div'
                    }]
                }
             ]
	        });
	    });
    </script>
    <style type="text/css">
        div#ext-gen9 { overflow-y: auto; }
        div.home a { color: #FFFFFF; }
    </style>

    <script type="text/javascript">
        function setIframeHeight(iframeName) {
            var iframeEl = document.getElementById ? document.getElementById(iframeName) : document.all ? document.all[iframeName] : null;
            if (iframeEl) {
                iframeEl.style.height = "auto";
                var h = alertSize();
                var new_h = (h - 148);
                iframeEl.style.height = new_h + "px";
            }
        }

        function alertSize() {
            var myHeight = 0;
            if (typeof (window.innerWidth) == 'number') {
                myHeight = window.innerHeight;
            } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
                myHeight = document.documentElement.clientHeight;
            } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
                myHeight = document.body.clientHeight;
            }
            return myHeight;
        }
    </script>

	<style type="text/css">
        .dropbtn {
            background-color: #4CAF50;
            color: white;
            padding: 16px;
            font-size: 16px;
            border: none;
            cursor: pointer;
        }

        .dropdown {
            position: relative;
            display: inline-block;
        }

        .dropdown-content {
            display: none;
            position: absolute;
            background-color: #f9f9f9;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        }

        .dropdown-content a {
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
        }

        .dropdown-content a:hover { background-color: #f1f1f1; }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        .dropdown:hover .dropbtn {
            background-color: #3e8e41;
        }
    </style>
</head>
<body>
    <asp:Literal ID="liItems" runat="server"></asp:Literal>
    <div class="remark" id="main-div">
        <%--<iframe scrolling="auto" name="page" frameborder="0" width="100%" id="frContent" src="../Acc/Display_IOT.aspx"></iframe>--%>
        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Acc/Display_IOT.aspx">HyperLink</asp:HyperLink>--%>
        <div class="dropdown">
            <button class="dropbtn">Warehouse 1</button>
            <div class="dropdown-content">
                <a href="#">Link 1</a>
                <a href="#">Link 2</a>
                <a href="#">Link 3</a>
            </div>
            <button class="dropbtn">Warehouse 2</button>
            <div class="dropdown-content">
                <a href="#">Link 1</a>
                <a href="#">Link 2</a>
                <a href="#">Link 3</a>
            </div>
        </div>
    </div>

    <div id="north">
        <div id="divinfo">
            <div>
                <span><%= this._words %>, <%= this.Session["gettemp"] %></span>
            </div>
            <br />
            <div class="time">
                <span>Date : <%= this.Session["LoginHis"] %></span>
            </div>
            <br />
            <div class="home" id="trhome" runat="server">
                <a target="_parent" href='<%= this.SignOutURL %>'>Log Out</a>
                <a target="_parent" runat="server" id="ahrefhome">Home</a>
            </div>
            <div class="clear"></div>
        </div>
        <img class="imgheader" src="../image/header1.jpg" />
    </div>
</body>
</html>