<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XxWapSystem._Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <meta name="keywords" content="岳阳房地产网,岳阳房地产信息网,岳阳新房,岳阳商品房,岳阳二手房,出售,出租,岳阳楼盘搜索,楼盘预售公示,岳阳楼盘资讯,市场动态,交易行情">
    <meta name="description" content="岳阳房地产信息网是岳阳最专业的房地产信息网站,为您提供最新的岳阳楼盘资料,最全面的楼盘数据,最权威的市场分析及公示,最及时的楼盘交易行情,海量的二手售房、租房信息,您还可以在这里发布您的出售、出租、求租、求购信息。岳阳房地产信息网,最权威最具公信力的网络平台,看房选房首选岳阳房地产信息网！">
    <title>岳阳房地产网</title>
    <meta name="apple-mobile-web-app-title" content="岳阳房地产网">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <script src="js/jquery.js"></script>

    <script src="js/common.js"></script>

    <link href="css/v2.css" rel="stylesheet" type="text/css">
</head>
<body>
    <!--头部LOGO-->
    <header class="m_wrap"><SECTION class="nav_bg_top" id="topbar"><A 
href="http://m.yyfdcw.com/">
<DIV id="logo"></DIV></A>
<span id="app_link"><a href="#" id="addFavoriteId"><i class="icon_download"></i>收藏</a></span>
</SECTION></header>
    <nav class="nav_btn_group" style="max-height: 120px;">
<UL>
  <LI id="nav_btn_news"><A href="/news/BuildingNews.aspx" 
  target="_self"><I class="nav_icon_news"></I>资讯</A></LI>
  <LI id="nav_btn_newhouse"><A href="/newhouse/list.aspx" target="_self"><I 
  class="nav_icon_newhouse"></I>新房</A></LI>
  <LI id="nav_btn_sellhouse"><A href="/sellhouse/list.aspx" 
  target="_self"><I class="nav_icon_sellhouse"></I>二手房</A></LI> 
  <LI id="nav_btn_decoration"><A href="/zxindex.aspx" 
  target="_self"><I class="nav_icon_decoration"></I>装修</A></LI></UL></nav>
    <!--搜索区域-->
    <div class="csearch_wrap">
        <div class="choose_opts" id="choose_opts">
            <ul>
                <li id="choose_li_1" onclick="choose_select('newhouse','新房')">新房</li>
                <li id="choose_li_2" onclick="choose_select('sellhouse','二手房')">二手房</li>
                <input name="app" id="choose_app" type="hidden" />
            </ul>
        </div>
        <div class="csearch-input">
            <span class="choose_title" id="choose_title"><font>综合</font><i class="icon-arrow"></i></span><input
                name="keyword" class="textInput" id="searchInput" type="text" placeholder="请输入查询关键字"
                value="">
            <button class="search-submit right" type="submit" onclick="submitsearch()">
                搜索</button>
        </div>
    </div>
    <!--资讯区域-->
    <div id="news_wrap">
        <h2 class="h2_v2">
            <span class="title_news"><a href="/news/BuildingNews.aspx">房产资讯</a></span></h2>
        <div class="cnews_list">
            <ul>
                <%=HouseNewsHtml %>
            </ul>
        </div>
    </div>
    <!--装修资讯-->
    <div id="bbs_wrap">
        <h2 class="h2_v2">
            <span class="title_news"><a href="/zx/">装修资讯</a></span></h2>
        <div class="cnews_list">
            <ul>
             <%=DecorateHtml %>
            </ul>
        </div>
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
            <a href="javascript:void(0)" class="agray" style="color: #507FBD;">触屏版</a>&nbsp;&nbsp;<a
                href="http://www.yyfdcw.com" class="agray">电脑版</a></div>
        <div class="f12 fgray" align="center">
            Copyright &copy; 2014 岳阳房地产网<br />
            m.yyfdcw.com 湘ICP备13012493号</div>
    </div>
    <div class="btn_gotop" id="btn_gotop" style="display: none;">
    </div>

    <script>
    function choose_select(val, text) {
        $("#choose_app").val(val);
        $("#choose_title font").html(text);
        $("#choose_opts").hide();
    }
    /*************2014-4-23*************************/
    $("#choose_title").mouseover(function() {
        $("#choose_opts").show();
    });
    $("#choose_title").mouseout(function() {
        $("#choose_opts").mouseover(function() {
            $("#choose_opts").show();
        });
        $("#choose_opts").hide();
    });

    $("#app_link").click(function() {
      addFavorite("http://m.yyfdcw.com", "岳阳房地产网");
    });

    function submitsearch() {
        var searchtype = $("#choose_app").val();
        var jumpurl;
        var keyword = "?key=" + encodeURIComponent(jQuery("#searchInput").val()) + "";
        if (searchtype == "newhouse") {
            jumpurl = "/newhouse/List.aspx";
        }
        else if (searchtype == "sellhouse") {
            jumpurl = "/sellhouse/List.aspx";
        }
        else {
            jumpurl = "/newhouse/List.aspx";
        }
        document.location.href = jumpurl + keyword;
    }
    </script>

</body>
</html>
