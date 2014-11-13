<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JyhqNews.aspx.cs" Inherits="XxWapSystem.news.JyhqNews" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title>交易行情-岳阳房地产网</title>
    <meta name="keywords" content="岳阳房产新闻, 岳阳房产资讯, 岳阳房地产网楼盘资讯，岳阳楼市新闻，岳阳楼盘市场分析,岳阳房地产市场动态" />
    <meta name="description" content="岳阳房产新闻,岳阳房地产网提供最及时岳阳房地产新闻、岳阳房产资讯，为您解读岳阳房产最新政策，预测岳阳房价走势，分析岳阳楼市成交数据。岳阳房地产网权威房地产媒体！" />
    <meta name="apple-mobile-web-app-title" content="岳阳房地产网">
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
<h1>交易行情</h1>
</section>

</header>
    <div class="ntab_title">
        <ul>
             <li><a href="BuildingNews.aspx">楼盘资讯</a></li>
            <li class="selected"><a href="JyhqNews.aspx">交易行情</a></li>
            <li><a href="CxxxNews.aspx">楼盘促销</a></li>
            <li><a href="ZxNews.aspx">装修促销</a></li>
        </ul>
    </div>
    <div class="clear">
    </div>
    <div id="datalist">
        <div class="nplist_hq">
            <ul>
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li onclick="gourl('NewsShow.aspx?id=<%#Eval("Id").ToString()%>')">
                            <a target="_self" href="NewsShow.aspx?id=<%#Eval("Id").ToString()%>"><%#Eval("Title").ToString()%> </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
        var page = 2;
        var url = "newsajax_jyhq.aspx?channel=<%=colid %>";

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

            $(".cplist li:even").addClass("bg2");
        });
    </script>

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
