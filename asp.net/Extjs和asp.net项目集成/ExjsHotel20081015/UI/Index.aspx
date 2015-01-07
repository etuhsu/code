<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Marriott-酒店管理系统</title>
<link href="CSS/Loading.css" rel="stylesheet" type="text/css" />
<link href="CSS/css.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet"  type="text/css" href="Ext/resources/css/ext-all.css" />
<link rel="stylesheet" type="text/css" href="Ext/resources/css/xtheme-galdaka.css" />

<style type="text/css">
    .cbox{border:0px solid #D6D6D6;float:right;width:140px;height:80px}
    .cbox img{margin-bottom:3px;vertical-align:middle}
</style>

<script src="Ext/adapter/ext/ext-base.js" type="text/javascript"></script>
<script src="Ext/ext-all.js"type="text/javascript"></script>
<script src="JS/skin.js" type="text/javascript"></script>
<script src="JS/RoomTypePicture.js" type="text/javascript"></script>
<script type="text/javascript">
var rootsid="";
var loginid="";
function load()
{
    if(<%= Number.userid %>==null)
    {
            rootsid="1";
    }
    else
    {
        rootsid=<%= Number.userid %>;
        loginid=<%= Number.loginid %>;
    }
}



 
</script>
<script type="text/javascript" src="JS/ALLEvents.js"></script>
<script type="text/javascript" src="JS/RoomType/AddRoomType.js"></script>
<script type="text/javascript" src="JS/RoomType/DeleRoomType.js"></script>
<script type="text/javascript" src="JS/RoomType/EditRoomType.js"></script>
<script type="text/javascript" src="JS/RoomType/RoomTypeManage.js"></script>


<script type="text/javascript" src="JS/OpenRoomInfo/RoomInfoManage.js"></script>
<script type="text/javascript" src="JS/OpenRoomInfo/AddGuestInfo.js"></script>
<script type="text/javascript" src="JS/OpenRoomInfo/OpenRoomInfo.js"></script>
<script type="text/javascript" src="JS/OpenRoomInfo/EditOpenRoomInfo.js"></script>
<script type="text/javascript" src="JS/OpenRoomInfo/DelOpenRoomInfo.js"></script>


<script type="text/javascript" src="JS/Room/RoomManage.js"></script>
<script type="text/javascript" src="JS/Room/AddRoomInfo.js"></script>
<script type="text/javascript" src="JS/Room/DelRoomInfo.js"></script>

<script type="text/javascript" src="JS/OpenRoomRecordInfo/OpenRoomRecordInfoManage.js"></script>

<script type="text/javascript" src="JS/TotalInfo/TotalInfoManage.js"></script>

<script type="text/javascript" src="JS/GuestInfo/GuestInfoManage.js"></script>
<script type="text/javascript" src="JS/GuestInfo/EditGuestInfo.js"></script>
<script type="text/javascript" src="JS/GuestInfo/DelGuestInfo.js"></script>


<script type="text/javascript" src="JS/UserRoleInfo/UserRoleManage.js"></script>
<script type="text/javascript" src="JS/UserInfo/AddUserInfo.js"></script>
<script type="text/javascript" src="JS/UserInfo/EditUserInfo.js"></script>
<script type="text/javascript" src="JS/UserInfo/DelUserInfo.js"></script>

<script type="text/javascript" src="JS/RoleInfo/AddRoleInfo.js"></script>
<script type="text/javascript" src="JS/RoleInfo/DelRoleInfo.js"></script>
<script type="text/javascript" src="JS/RoleInfo/EditRoleInfo.js"></script>

<script type="text/javascript" src="JS/UserInfo/EditUserPwdInfo.js"></script>

<script type="text/javascript" src="JS/Publish/PublishManage.js"></script>
<script type="text/javascript" src="JS/Publish/AddPublishInfo.js"></script>
<script type="text/javascript" src="JS/Publish/DelPublishInfo.js"></script>
<script type="text/javascript" src="JS/Publish/EditPublishInfo.js"></script>

<script type="text/javascript" src="JS/Publish.js"></script>
<script type="text/javascript" src="JS/ToDayTypePrice.js"></script>
<script type="text/javascript" src="JS/Main.js"></script>


</head>
    <body>

         <div id="loading">
                    <div  class="loading-indicator">
                        <img src="Images/extanim32.gif" alt="" width="32" height="32" style="margin-right:8px;" align="absmiddle"/>
                            Loading......
                    </div>
         </div>
         <div id="loading-mask">
         </div>
         
         

        <div id="top"  class="fiterall">
<div id="bg" style=" vertical-align:middle;width:160px;height:49px;background-image:url(images/topbg.gif);">
<embed src="FLASH/hotel.swf" style="height: 55px; width: 436px;" autostart="1" loop="-1" type="application/x-shockwave-flash" wmode="transparent" quality="high" ></embed>  
 
 </div>       
           <div class="cbox" style="left: 0px; position: relative; top: -45px; height: 65px">
           <embed src="FLASH/fivestar.swf" style="height:20px; width: 134px;float:left" autostart="1" loop="-1" type="application/x-shockwave-flash" wmode="transparent" quality="high" ></embed>
            <br><br><br>
            <script type="text/javascript">
                    for(var i=0;i<5;i++)
                    {
                        if(parseInt(skinID)==i)
                        {
                            document.writeln("<img id=\"imgkin"+i+"\" src=\"Images\/skin/\c"+i+"_1.gif\" width=\"12\" height=\"12\" alt=\"\" onclick=\"setSkin("+i+")\" \/>");
                        }
                        else
                        {
                            document.writeln("<img id=\"imgkin"+i+"\" src=\"Images\/skin/\c"+i+"_0.gif\" width=\"12\" height=\"12\" alt=\"\" onclick=\"setSkin("+i+")\" \/>");
                        }
                    }
             </script>
                <a href="Exit.aspx">退出后台</a>
                
            </div>
            
            
        </div>
      
        <div id="botton"  class="bottonall">
            <br/><b>2008&nbsp;&nbsp; Hotels Corporation <font color="red">Marriott</font> International, Inc. (Athor:Mr.Wan QQ:391111389),<a href="http://www.51aspx.com/CV/ExtjsHotelManage" target="_blank" title="Asp.net源码下载专业站">download from 51aspx.com</a>
</b> 
        </div>

        <div id="roomtypeSee" style=" height:490px;">
            <div id="demo" style="overflow:hidden; width:200px; height:450px; text-align:center">
            <div id="demo1">
            <center><font color="red"><b>
                <img src="images/roomtypepic/tp1.jpg" alt="标准间实景图"  height="180" /><br/>标准间实景图<br/>
                    <img src="images/roomtypepic/tp2.jpg" alt="高级间实景图" height="180" /><br/>高级间实景图<br/>
                    <img src="images/roomtypepic/tp3.jpg"  alt="豪华间实景图" height="180" /><br/>豪华间实景图<br/>
                    <img src="images/roomtypepic/tp4.jpg" alt="行政间实景图"  height="180" /><br/>行政间实景图<br/>
                    <img src="images/roomtypepic/tp5.jpg" alt="高级套房实景图"  height="180" /><br/>高级套房实景图<br/>
                    <img src="images/roomtypepic/tp6.jpg" alt="豪华套房实景图"  height="180" /><br/>豪华套房实景图<br/>
                    <img src="images/roomtypepic/tp7.jpg" alt="豪华套房实景图"  height="180" /><br/>豪华套房实景图<br/>
                    </b>
            </font>
            </center>
            </div>
            <div id="demo2"></div>
            </div>
               <script type="text/javascript">
                    var speed=1
                    var demo2=document.getElementById("demo2");
                    var demo1=document.getElementById("demo1");
                    var demo=document.getElementById("demo");
                    demo2.innerHTML=demo1.innerHTML
                    function Marquee(){
                    if(demo2.offsetTop-demo.scrollTop<=0)
                    demo.scrollTop-=demo1.offsetHeight
                    else{
                    demo.scrollTop++
                    }
                    }
                    var MyMar=setInterval(Marquee,speed)
                    demo.onmouseover=function() {clearInterval(MyMar)}
                    demo.onmouseout=function() {MyMar=setInterval(Marquee,speed)}
        </script> 
         </div>
         
         <div id="centerindex">
         </div>

    </body>
</html>
