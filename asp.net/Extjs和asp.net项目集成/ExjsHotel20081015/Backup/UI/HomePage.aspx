<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HomePage</title>
<style type="text/css">
    .svw {width: 50px; height: 20px; background:lightblue;} 
    .svw ul {position: relative; left: -999em;}  /*core classes*/ 
    .svw img{
        width:expression( document.body.scrollWidth);
       
        border:1px dashed #000;
     }
    #mygaltwo{
       text-align:center;
       width:expression(document.body.scrollWidth);
       align:center;
     }
    
     .stripViewer {  position: relative; overflow: hidden;  border: 0px solid lightblue;   margin: 0 0 1px 0; } 
    .stripViewer ul { /* this is your UL of images */ margin: 0; padding: 0; position: relative; left: 0; top: 0; width: 1%; list-style-type: none; } 
    .stripViewer ul li {  float:left; } 
    .stripTransmitter { overflow: auto; width: 1%; } 
    .stripTransmitter ul { margin: 0; padding: 0; position: relative; list-style-type: none; }
    .stripTransmitter ul li{ width: 20px; float:left; margin: 0 1px 1px 0; }
    .stripTransmitter a{ font: bold 10px Verdana, Arial; text-align: center; line-height: 22px; background: lightblue; color: #fff; text-decoration: none; display: block; } 
    .stripTransmitter a:hover, a.current{ background: #fff; color: lightblue; }  /*tooltips formatting*/ 
    #tooltip { background: #fff; color: #000; opacity: 0.85; border: 5px solid #dedede; } 
    #tooltip h3 {  font: normal 10px Verdana;  margin: 0;  padding: 6px 2px;  border: 0; } 
</style>

<script src="Ext/j/jquery-1.2.1.min.js" type="text/javascript"></script>
<script src="Ext/j/jquery.easing.1.2.js" type="text/javascript"></script>
<script src="Ext/j/jquery.tooltip.js" type="text/javascript"></script>
<script src="Ext/j/jquery.slideviewer.1.1.js" type="text/javascript"></script>
<script type="Ext/j/jquery.chili.pack.js"></script>

<script type="text/javascript"> 
    $(window).bind("load", function() { 
       $("div#mygaltwo").slideView({
		easeFunc: "easeInOutBounce",
		easeTime: 2200
	});  
  }); 
</script> 
</head>
<body style=" text-align:center">
    <form id="form1" runat="server">

    <div id="mygaltwo" class="svw">
	<ul>
		<li><img height="398px"  alt="About marriott Hotel"  src="images/homepage/1.jpg" /></li>
		<li><img  height="398px"  alt="天空映衬下的Hotel"  src="images/homepage/2.jpg" /></li>		
		<li><img height="398px"  alt="鸟瞰酒店全景"  src="images/homepage/3.jpg" /></li>
		<li><img height="398px"  alt="优美的周边环境"  src="images/homepage/4.jpg" /></li>
		<li><img  height="398px"  alt="霞光中的酒店"  src="images/homepage/5.jpg" /></li>
	</ul>
</div>

    </form>
</body>
</html>
