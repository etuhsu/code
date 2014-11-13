<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductShow.aspx.cs" Inherits="XxWapSystem.jc_go.ProductShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="IE=11.0000" http-equiv="X-UA-Compatible">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <title>岳阳房地产装修网 建材GO便宜</title>
    <meta name="keywords" content="岳阳房地产装修网,岳阳装修,岳阳装修公司,岳阳建材,岳阳家居,设计师,装修作品,装修日记,本地团购" />
    <meta name="description" content="岳阳房地产装修网是岳阳地区唯一一家专门从事装修信息服务的网络媒体。为您提供最新的行业动态和促销信息、最全的装修建材、最权威的行业规章和信用档案。岳阳房地产装修网致力成为岳阳装修行业最权威的公信媒体。" />
    <meta name="apple-mobile-web-app-title" content="岳阳房地产装修网">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <script src="../js/jquery.js"></script>

    <script src="../js/common.js"></script>

    <link rel="stylesheet" type="text/css" href="../css/v2.css" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <link rel="stylesheet" type="text/css" href="../css/base.css" />

    <script type="text/javascript">
        var appdowntip = getCookie('appdowntip');
        var closetip = getCookie('closetip');
        if (navigator.cookieEnabled && appdowntip == null) {
            //document.write('<meta name="apple-itunes-app" content="app-id=543472063">');
            //setCookie('appdowntip',true);
        }
        $(document).ready(function() {
            var apppop = getCookie('apppop');
            if (navigator.cookieEnabled && apppop == null) {
                setCookie('apppop', true);
                //$("#app_downloads").show();
                $("#app_downloads").css("width", document.body.clientWidth);
                $("#app_downloads").css("height", document.body.clientHeight);
                $(".turn_off").click(function() {
                    //$("#app_downloads").hide();
                });
                $(".no_download").click(function() {
                    //$("#app_downloads").hide();
                });
            }
            //get_location();
        });
    </script>

    <link href="../images/apple-touch-icon.png" rel="apple-touch-icon" sizes="144x144">
</head>
<body>
    <div id="app-download-bar" class="app-download-bar" style="display: none">
        <a id="btn_app_down" href="http://app.house365.com/taofang/?channel=cptfxz" target="_blank">
        </a><span class="downtxt fr" id="closetip">关闭</span>
    </div>
    <div id="app-open-bar" class="app-open-bar" style="display: none">
        <span class="open_close" id="app_open_close"></span><span class="open_icon"></span>
        <span class="open_alt">极速体验更省流量</span> <span class="opentxt fr" id="openapp">立即打开</span>
    </div>
    <!--头部LOGO-->
    <header class="m_wrap">

<section id="topbar" class="topnav_tool">
<button class="top_btn" id="btn_back">返回</button>
<h1><%=ProductName %></h1>
<!--<button class="top_btn_fav" onclick="addFavorite(location.href, document.title)">收藏</button>-->
</section>
 
</header>
    <!--焦点图-->
    <div class="swipe_wrap">
        <div id='switch_gallery' class='swipe'>
            <div class='swipe_pic'>
                <%=ProductImage%>
            </div>
        </div>
    </div>
    <!--基本信息-->
    <div class="detail_info clear">
        <div class="info_title">
            <asp:Label ID="lbltitle" runat="server"></asp:Label></div>
        <div class="info_li">
            <span class="info_attr">商品原价：</span><span class="info_val" id="info_price">￥<%=ProductOldPrice %></span></div>
        <div class="info_li">
            <span class="info_attr">促 销 价：</span><span class="info_val">￥<%=ProductPrice %></span></div>
        <div class="info_li">
            <span class="info_attr">产品规格：</span><span class="info_val"><%=ProductStandard %></span></div>
        <div class="info_li">
            <span class="info_attr">产品型号：</span><span class="info_val"><%=ProductXh %></span></div>
        <div class="info_li">
            <span class="info_attr">产品类别：</span><span class="info_val">
                <%=ProductType %></span></div>
        <div class="info_li">
            <span class="info_attr">产品品牌：</span><span class="info_val"><%=BrandName %></span></div>
        <div class="info_li">
            <span class="info_attr">浏览次数：</span><span class="info_val"><%=iHits %></span></div>
        <div class="info_li">
            <span class="info_attr">商家地址：</span><span class="info_val"><%=UserAddress %></span></div>
        <div class="info_h2">
            <span class="info_h2_title">产品介绍</span></div>
        <div class="info_box">
            <p>
                <%=Explain%>
            </p>
        </div>
        <div class="call_wrap" id="call_bar">
            <span class="call_txt">
                <%=MemberName%><br />
                <%=UserPhone %></span> <span class="call_btn"><a href="tel:<%=UserPhone %>" onclick="_gaq.push(['_trackEvent', '[商家咨询电话]', '[拨打电话]', '<%=ProductName %>']);">
                    拨打</a></span>
        </div>
        <!--底部导航-->
        <nav class="footernav">
<ul>
<li id="footernav_news"><a href="/news/BuildingNews.aspx">资讯</a></li>
<li id="footernav_newhouse"><a href="/newhouse/List.aspx" target="_self">新房</a></li>
<li id="footernav_sellhouse"><a href="/sellhouse/List.aspx" target="_self">二手房</a></li> 
<li id="footnav_bbs"><a href="/index.html" target="_self">装修</a></li> 
</ul>
</nav>
        <div class="footer">
            <div class="footer_link">
                <a href="#" class="agray">标准版</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                    style="color: #507FBD;">触屏版</a>&nbsp;&nbsp;<a href="http://xx.yyfdcw.com" class="agray">电脑版</a></div>
            <div class="f12 fgray" align="center">
                Copyright &copy; 2014 岳阳房地产网<br />
                m.yyfdcw.com 湘ICP备13012493号</div>
        </div>
</body>
</html>
