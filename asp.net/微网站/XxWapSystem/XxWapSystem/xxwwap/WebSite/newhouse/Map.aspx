<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="XxWapSystem.newhouse.Map" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title><%=ProjectName %>手机地图_周边配套_地图找房_岳阳房地产网</title>
    <meta name="keywords" content="<%=ProjectName %>手机地图,<%=ProjectName %>周边配套,岳阳房地产网" />
    <meta name="description" content="<%=ProjectName %>手机地图,<%=ProjectName %>周边配套,岳阳房地产网" />
    <meta name="apple-mobile-web-app-title" content="岳阳房地产网">
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <script src="../js/jquery.js?version=1.0"></script>

    <script src="../js/common.js?version=1.0"></script>

    <link rel="stylesheet" type="text/css" href="../css/v2.css" />
</head>
<body>

    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.5&ak=B8453121d1d64c42af06601f4948660c"></script>

    <script type="text/javascript">

        // 编写自定义函数,创建标注
        function addMarker(point) {
            var marker = new BMap.Marker(point);
            map.addOverlay(marker);
        }
    </script>

    <!--头部LOGO-->
    <header class="m_wrap">
<section id="topbar" class="topnav_tool">
<button class="top_btn" id="btn_back">返回</button>
<h1>手机地图</h1>
</section>
 </header>
    <div id="container">
    </div>

    <script type="text/javascript">
        var boxheight = 40;

        $("#container").css("height", window.innerHeight - boxheight);
        $("#container").css("margin-top", "-18px");
        document.addEventListener('touchmove', function(e) { e.preventDefault(); });

        var map = new BMap.Map("container"); // 创建地图实例
        map.addControl(new BMap.NavigationControl());
        map.addControl(new BMap.ScaleControl());
        map.addControl(new BMap.OverviewMapControl());
        map.addControl(new BMap.MapTypeControl());
        var gpsPoint = new BMap.Point(<%=Yzuobiao %>, <%=Xzuobiao %>);
        map.centerAndZoom(gpsPoint, 17);
        // 创建点坐标
        //var marker = new BMap.Marker(point);        // 创建标注  
        //map.addOverlay(marker);
        var bua = navigator.userAgent.toLowerCase();
        if (bua.indexOf('iphone') != -1 || bua.indexOf('ios') != -1) {
            //判断系统类型，显示客户端下载图片
            //$('#clientpic').attr('src','');
        }
        var marker = new BMap.Marker(gpsPoint);
        map.addOverlay(marker);
        /*
        translateCallback = function (point){
        var marker = new BMap.Marker(point);
        map.addOverlay(marker);
        map.centerAndZoom(point, 15); // 初始化地图，设置中心点坐标和地图级别
        }

setTimeout(function(){
        BMap.Convertor.translate(gpsPoint,2,translateCallback);     //真实经纬度转成百度坐标
        }, 2000);
        */
    </script>

</body>
</html>
