<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyNewShow.aspx.cs"
    Inherits="XxWapSystem.news.PolicyNewShow" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title>
        <%=Title %>一登记-岳阳房地产信息网</title>
    <meta name="keywords" content="<%=Title %>" />
    <meta name="description" content="<%=ShortContent %>" />
    <meta name="apple-mobile-web-app-title" content="岳阳房地产信息网">
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <script src="../js/jquery.js?version=1.0"></script>

    <script src="../js/common.js?version=1.0"></script>

    <link rel="stylesheet" type="text/css" href="../css/v2.css" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <link rel="stylesheet" type="text/css" href="../css/base.css" />
</head>
<body>
    <!--头部LOGO-->
    <header class="m_wrap">

<section id="topbar" class="ytopnav_tool">
<button class="ytop_btn" id="btn_back">返回</button>
<button class="top_btn_fav_news" onClick="gohome()">回首页</button>
<h1><%=Title %></h1>
</section>
 
</header>
    <div class="news-wrap">
        <h1 class="news-title">
            <%=Title %></h1>
        <h4 class="news-time">
            日期：<%=AddTime %>
            来源:岳阳房地产网
            <!--浏览:次-->
        </h4>
        <div class="news-content">
            <style>
                p
                {
                    color: #2C2C2C;
                    text-indent: 2em;
                    font-size: 17px;
                    line-height: 170%;
                    padding: 0;
                    marin: 7px 0;
                    text-align: justify;
                }
                img
                {
                    margin: 0 auto;
                    display: block;
                }
            </style>
            <%=MsgContent %>
        </div>
        <div class="bdsharebuttonbox" style="height: 46px;">
            <span style="font-weight: bold; font-size: 15px;">分享到:</span><img style="display: inline;
                padding-left: 9px;" title="分享到QQ空间" href="#" class="bds_qzone" data-cmd="qzone"
                src="../images/qzone.png"><img style="display: inline; padding-left: 9px;" title="分享到新浪微博"
                    href="#" class="bds_tsina" data-cmd="tsina" src="../images/sinaweibo.png"><img style="display: inline;
                        padding-left: 9px;" title="分享到腾讯微博" href="#" class="bds_tqq" data-cmd="tqq" src="../images/tentweibo.png"><img
                            style="display: inline; padding-left: 9px;" title="分享到微信" href="#" class="bds_weixin"
                            data-cmd="weixin" src="../images/weixin.png"></div>

        <script>            window._bd_share_config = { "common": { "bdSnsKey": {}, "bdText": "", "bdMini": "2", "bdMiniList": false, "bdPic": "", "bdStyle": "0", "bdSize": "16" }, "share": {}, "image": { "viewList": ["qzone", "tsina", "tqq", "renren", "weixin"], "viewText": "分享到：", "viewSize": "16" }, "selectShare": { "bdContainerClass": null, "bdSelectMiniList": ["qzone", "tsina", "tqq", "renren", "weixin"]} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];</script>

        <!--注释:这里被注释掉的是资讯详情页触屏端分享给第三方的按钮,把注释去掉即可用.wufading 2014-06-20-->
    </div>
    <!--资讯区域-->
    <div id="app-popup-wrap" style="display: none;">
        <div id="app-popup" class="app-popup">
            <span class="app-popup_close" id="app-popup_close"></span><span id="app-popup_btn"
                class="app-popup_btn"></span>
        </div>
    </div>

    <script type="text/javascript">
//分享
var share_link =window.location.href;
var share_content="<%=MsgContent %>";
var share_title="<%=Title %>";
var share_img="../images/20140822102210363005.jpg";
var dataForWeixin={
	appId:	"",
	img:	share_img,  
	url:	share_link,
	title:	share_title,
	desc:	share_content,
	fakeid:	"",
};
    </script>

    <script src="../js/share.js?version=1.0"></script>

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
            <a href="#" class="agray">标准版</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">触屏版</a>&nbsp;&nbsp;<a href="http://www.yyfdcw.com" class="agray">电脑版</a></div>
        <div class="f12 fgray" align="center">
            Copyright &copy; 2014 岳阳房地产网<br />
            m.yyfdcw.com 湘ICP备13012493号</div>
    </div>
    <div class="btn_gotop" id="btn_gotop" style="display: none;">
    </div>
</body>
</html>
