<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="XxWapSystem.zx_news.NewsList" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title>岳阳房地产装修网 岳阳家装唯一官方门户网站 岳阳市装修办和装饰装修行业协会主办</title>
    <meta name="keywords" content="岳阳房地产装修网,岳阳装修,岳阳装修公司,岳阳建材,岳阳家居,设计师,装修作品,装修日记,本地团购" />
    <meta name="description" content="岳阳房地产装修网是岳阳地区唯一一家专门从事装修信息服务的网络媒体。为您提供最新的行业动态和促销信息、最全的装修建材、最权威的行业规章和信用档案。岳阳房地产装修网致力成为岳阳装修行业最权威的公信媒体。" />
    <meta name="apple-mobile-web-app-title" content="岳阳房地产装修网">
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <script src="../js/jquery.js?version=1.0"></script>

    <script src="../js/common.js?version=1.0"></script>

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

</head>
<body>
    <div id="app-download-bar" class="app-download-bar" style="display: none">
        <a id="btn_app_down" href="#" target="_blank"></a><span id="closetip" class="downtxt fr">
            关闭</span>
    </div>
    <div id="app-open-bar" class="app-open-bar" style="display: none">
        <span class="open_close" id="app_open_close"></span><span class="open_icon"></span>
        <span class="open_alt">极速体验更省流量</span> <span id="openapp" class="opentxt fr">立即打开</span>
    </div>
    <!--头部LOGO-->
    <header class="m_wrap">
<section id="topbar" class="ytopnav_tool">
<button class="ytop_btn" id="btn_back">返回</button>
<button class="top_btn_fav_news" onClick="gohome()">回首页</button>
<h1>装修资讯</h1>
</section>

</header>
    <div class="ntab_title">
        <ul>
            <li class="selected"><a href="NewsList.aspx">行业动态</a></li>
            <li><a href="jjList.aspx">行业简介</a></li>
            <li><a href="gzList.aspx">行业规章</a></li>
            <li><a href="znList.aspx">办事指南</a></li>
        </ul>
    </div>
    <div class="clear">
    </div>
    <div id="datalist">
        <div class="nplist">
            <ul>
                <asp:Repeater ID="repbuild" runat="server">
                    <ItemTemplate>
                        <li onclick="gourl('Show.aspx?id=<%# Eval("iID").ToString() %>')">
                            <div class="p-img">
                                <a target="_self" href="Show.aspx?id=<%# Eval("iID").ToString() %>">
                                    <img width="50" height="50" alt="<%# Eval("cTitle").ToString() %>" src="<%# BindPic(Eval("cThumbnail").ToString()) %>" />
                                </a>
                            </div>
                            <div class="p-txt">
                                <div class="p-title">
                                    <a target="_self" href="Show.aspx?id=<%# Eval("iID").ToString() %>"><%# Eval("cTitle").ToString() %></a>
                                </div>
                                <div class="p-summary">
                                    <%# NoHtml(Eval("cContent").ToString()).PadLeft(50)%>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
        var page = 2;
        var url = "newsajax.aspx";

        $(document).ready(function() {
            var moreitem = '<div class="more_tag">点击加载更多</div>';
            $("#datalist").append(moreitem);

            $(".more_tag").click(function() {
                $(".more_tag").hide();
                $("#datalist").append('<div class="page_loading"></div>');
                $.ajax({
                    type: "GET",
                    url: url,
                    data: "page=" + page,
                    success: function(msg) {

                        $(".page_loading").remove();
                        if (msg != '') {
                            page = page + 1;
                            $("#datalist ul").append(msg);
                            $(".more_tag").show();
                        } else {
                            $(".more_tag").hide();
                            $("#datalist").append('<div class="nodata_tag">没有更多数据了</div>');
                        }
                    }
                });
            });

            $("#datalist li:even").addClass("bg2");
        });
    </script>

    <!--底部导航-->
    <nav class="footernav">
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
