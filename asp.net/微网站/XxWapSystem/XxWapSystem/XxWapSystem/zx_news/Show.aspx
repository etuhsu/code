<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="XxWapSystem.zx_news.Show" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta content="IE=11.0000" http-equiv="X-UA-Compatible">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <title>岳阳房地产装修网 新闻标题</title>
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
    <div class="app-download-bar" id="app-download-bar" style="display: none;">
        <a id="btn_app_down" href="#" target="_blank">
        </a><span class="downtxt fr" id="closetip">关闭</span>
    </div>
    <div class="app-open-bar" id="app-open-bar" style="display: none;">
        <span class="open_close" id="app_open_close"></span><span class="open_icon"></span>
        <span class="open_alt">极速体验更省流量</span> <span class="opentxt fr" id="openapp">立即打开</span>
    </div>
    <!--头部LOGO-->
<header class="m_wrap">
<section id="topbar" class="ytopnav_tool">
<button class="ytop_btn" id="Button1">返回</button>
<button class="top_btn_fav_news" onClick="gohome()">回首页</button>
<H1><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></H1>
</section>
</header>    

    <div class="news-wrap">
        <h1 class="news-title">
            <asp:Label ID="lblTitle2" runat="server" Text=""></asp:Label></h1>
        <h4 class="news-time">
            日期：<asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
            来源:岳阳房地产网
        </h4>
        <!--焦点图-->
        <asp:Label ID="lblPic" runat="server" Text="Label"></asp:Label>
        <!--基本信息-->
        <div class="info_box" id="info_box_project_info">
            <div class="news-content">
                <style type="text/css">
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
                <asp:Label ID="labcontent" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="info_box" id="info_box_project_intro">
            </div>
        </div>
    </div>

    <script type="text/javascript">
//分享
var share_link =window.location.href;
var share_content="";
var share_title="";
var share_img="";
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
  <LI id="footernav_newhouse"><A href="http://m.house365.com/nj/newhouse/" 
  target="_self">新房</A></LI>
  <LI id="footernav_sellhouse"><A href="http://m.house365.com/nj/sellhouse/" 
  target="_self">二手房</A></LI>
  <LI id="footernav_renthouse"><A href="http://m.house365.com/nj/renthouse/" 
  target="_self">租房</A></LI>
  <!--<li><a href="#">家居</a></li>--> 
  <LI id="footernav_news"><A href="http://m.house365.com/nj/news/">资讯</A></LI>
  <LI id="footnav_bbs"><A href="http://m.house365.com/nj/bbs/" 
  target="_self">社区</A></LI>
</UL></nav>
    <div class="footer">
        <div class="footer_link">
            <a href="#" class="agray">标准版</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">触屏版</a>&nbsp;&nbsp;<a href="http://xx.yyfdcw.com" class="agray">电脑版</a></div>
        <div class="f12 fgray" align="center">
            Copyright &copy; 2014 岳阳房地产网<br />
            m.yyfdcw.com 湘ICP备13012493号</div>
    </div>
    <div class="btn_gotop" id="btn_gotop" style="display: none">
    </div>
</body>
</html>
