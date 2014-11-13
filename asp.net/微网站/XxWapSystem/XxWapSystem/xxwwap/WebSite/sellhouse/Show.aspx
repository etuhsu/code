<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="XxWapSystem.sellhouse.Show" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title><%=Title %>-【岳阳二手房网|岳阳二手房买卖信息】-岳阳房地产信息网</title>
    <meta name="keywords" content="岳阳二手房网,岳阳二手房买卖信息,岳阳房地产网" />
    <meta name="description" content="岳阳二手房网为您提供100%真实<%=Title %>信息,买好房,上岳阳房地产网!" />
    <meta name="apple-mobile-web-app-title" content="365淘房">
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <script src="../js/jquery.js?version=1.0"></script>

    <script src="../js/common.js?version=1.0"></script>

    <link rel="stylesheet" type="text/css" href="../css/v2.css" />
</head>
<body>
    <!--头部LOGO-->
    <header class="m_wrap">

<section id="topbar" class="topnav_tool">
<button class="top_btn" id="btn_back">返回</button>
<h1><%=Title %></h1>
<!--<button class="top_btn_fav" onclick="addFavorite(location.href, document.title)">收藏</button>-->
</section>
 
</header>
    <!--焦点图-->
    <div class="swipe_wrap">
        <div id='switch_gallery' class='swipe'>
            <div class='swipe_pic'>
                <%=FlashImg%>
            </div>
        </div>
        <div class="bg_transparent_switch">
            <div id='switch_indicators' class="switch_indicators">
                <ul>
                   <%=FlashImg1%>
                </ul>
            </div>
            <span class="switch_count">共<%=ImageCount %>张图片</span>
        </div>
    </div>

    <script type="text/javascript">
        var swipe_elem = document.getElementById('switch_gallery');
        window.mySwipe = Swipe(swipe_elem, {
            // startSlide: 4,
            auto: 3000,
            continuous: true,
            callback: function(pos) {
                var i = bullets.length;
                while (i--) {
                    bullets[i].className = ' ';
                }
                bullets[pos].className = 'on';

            }
        });
        var bullets = document.getElementById('switch_indicators').getElementsByTagName('li');
    </script>

    <!--基本信息-->
    <div class="detail_info clear">
        <div class="info_title">
            <%=Title %></div>
        <div class="info_li">
            <span class="info_attr">售价：</span><span class="info_val" id="info_price"><%=PriceName %></span></div>
        <div class="info_li">
            <span class="info_attr">单价：</span><span class="info_val"><%=PriceD %></span></div>
        <div class="info_li">
            <span class="info_attr">户型：</span><span class="info_val"><%=HomeTypeName %> </span>
        </div>
        <div class="info_li">
            <span class="info_attr">面积：</span><span class="info_val"><%=ConstructionName %> M&sup2;</span></div>
        <div class="info_li">
            <span class="info_attr">装修：</span><span class="info_val"><%=Decoration %></span></div>
        <div class="info_li">
            <span class="info_attr">朝向：</span><span class="info_val"><%=direction%></span></div>
        <div class="info_li">
            <span class="info_attr">楼层：</span><span class="info_val"><%=FloorNum %>层(共<%=MaxFloor %>层)</span></div>
        <div class="info_li">
            <span class="info_attr">房龄：</span><span class="info_val"><%=(HouseAge == "0" ? "" : HouseAge) %></span></div>
        <div class="info_li">
            <span class="info_attr">类型：</span><span class="info_val"><%=BuildTypeName%></span></div>
        <div class="info_li">
            <span class="info_attr">权属：</span><span class="info_val"><%=pic1 %></span></div>
        <div class="info_li">
            <span class="info_attr">更新：</span><span class="info_val"><%=AddTime %></span></div>
        <div class="info_li">
            <span class="info_attr">编号：</span><span class="info_val"><%=CodeNum %></span></div>
        <div class="info_h2">
            <span class="info_h2_title">房源描述</span></div>
        <div class="info_box">
         <%=HouseMess %>
        </div>
         
        <div class="info_h2">
            <span class="info_h2_title">房源地址</span></div>
        <div class="info_box">
            <%=Address %>
            <div class="info_map">
                <a href="map.aspx?id=<%=MsgID %>">
                    <img width="300px" height="130px" src="http://api.map.baidu.com/staticimage?width=300&amp;height=130&amp;zoom=14&amp;markers=<%=bdx %>,<%=bdy %>&amp;markerStyles=s,0"></a>
            </div>
        </div>
         <!--房源配套-->
        <div class="info_h2">
            <span class="info_h2_title">房源配套</span></div>
        <div class="info_box">
        <div class="info_content">
               <%=Other %>
            </div>
        </div>
        <!--交通配套-->
        <div class="info_h2">
            <span class="info_h2_title">交通配套</span></div>
        <div class="info_box">
            <div class="info_content">
              <%=Bus %>
            </div>
        </div>
    </div>
    <!--联系人-->
    <div class="info_h2">
        <span class="info_h2_title">联系信息</span></div>
    <div class="info_box">
        <div class="info_content">
            <div class="info_li">
                <span class="info_attr">联系人：</span><span class="info_val"><%=Linker %></span></div>
            <div class="info_li">
                <span class="info_attr">电话：</span><span class="info_val"><%=Phone %></span></div>
            
        </div>
    </div>
    </div>
    <div class="call_wrap" id="call_bar">
        <span class="call_txt"><%=Linker %><br />
            <%=Phone %></span> <span class="call_btn"><a href="tel:<%=Phone %>" onclick="_gaq.push(['_trackEvent', '[岳阳房地产网-二手房详情]', '[拨打电话]', '<%=Title %>']);">
                拨打</a></span>
    </div>
    <!--底部导航-->
<nav class="footernav">
<UL>
<li id="footernav_news"><a href="/news/BuildingNews.aspx">资讯</a></li>
<li id="footernav_newhouse"><a href="/newhouse/List.aspx" target="_self">新房</a></li>
<li id="footernav_sellhouse"><a href="/sellhouse/List.aspx" target="_self">二手房</a></li> 
<li id="footnav_bbs"><a href="/zxindex.aspx" target="_self">装修</a></li> 
  </UL></nav>
    <div class="footer">
        <div class="footer_link">
            <a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">触屏版</a>&nbsp;&nbsp;<a href="http://www.yyfdcw.com" class="agray">电脑版</a></div>
        <div class="f12 fgray" align="center">
            Copyright &copy; 2014 岳阳房地产网<br />
            m.yyfdcw.com 湘ICP备13012493号</div>
    </div>
    <div class="btn_gotop" id="btn_gotop" style="display: none;">
    </div>
</body>
</html>
