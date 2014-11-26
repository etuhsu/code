<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>L的酒店管理系统</title>
    <link href="/HotelUI/Css/main.css" rel="stylesheet" type="text/css" />
    <link href="/HotelUI/Ext/resources/css/ext-all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/HotelUI/Ext/adapter/ext/ext-base.js"></script>
    <script type="text/javascript" src="/HotelUI/Ext/ext-all.js"></script>
    <script type="text/javascript" src="/HotelUI/Ext/ext-lang-zh_CN.js"></script>
    
    <script type="text/javascript">
        function GetUserName()
        {
            WebService.GetLoginName
            (
                callback = function(res)
                {
                    $get('UserName').innerHTML = res;
                }
            )
        }
    </script>
    
    
    
    <script type="text/javascript" src="/HotelUI/Js/Main.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/GridMain.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/OpenRoom.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/AddUser.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/DelUser.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/AddRoomType.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/DelRoomType.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/AddRoom.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/DelRoom.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/CloseRoom.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/TodayPrice.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/SerachRoomType.js"></script>
    <script type="text/javascript" src="/HotelUI/Js/SerachRoom.js"></script> 
    <script type="text/javascript" src="/HotelUI/Js/SerachMoney.js"></script> 
    <script type="text/javascript" src="/HotelUI/Js/MyTime.js"></script>
    
</head>
<body onload="getCurrentTime(),GetUserName()">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="/HotelUI/WebServices/WebService.asmx" />
        </Services>
        </asp:ScriptManager>
    
    <div>
        <div id="north" style=" background-image:url(/HotelUI/Images/main_top_BG.gif);width: 980px; height: 65px">
            <div id="myTime" style="width: 237px; height: 19px; float:right; left: -11px; position: relative; top: 41px; font-size: 12px; color: #ffffff; z-index: 101;">
            </div>
            <div id="UserName" style="width: 187px; height: 18px; float:right; left: 152px; position: relative; top: 21px; font-size: 12px; color: #ffffff; z-index: 102;">
            </div>
            <div id="logo" style="width: 464px;
                height: 61px; background-image: url(Images/aa.gif);">
            </div>
            </div>
        <div id="west" style="width: 190px; height: 400px; float:left">
            </div>
        <div id="center" style="width: 579px; height: 400px; float:left">
        </div>
        <div id="east" style="width: 160px; height: 400px; float:left">
        </div>
    </div>
        <div id="south" style="width: 980px; height: 105px; color:Red; margin:5px;font:normal 12px tahoma, arial, sans-serif, 宋体;" align="center">
        ．·冰凍女人 版权所有 CopyRight © 2007-2008. 联系QQ:453863971，<a href="http://www.51aspx.com/CV/MyHotelManager" target="_blank" title="Asp.net源码下载专业站">download from 51aspx.com</a>

        </div>
    </form>
</body>
</html>
