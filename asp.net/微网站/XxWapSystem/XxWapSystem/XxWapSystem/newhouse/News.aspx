<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="XxWapSystem.newhouse.News" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title><%=ProjectName %>最新资讯-岳阳房地产网</title>
    <meta name="keywords" content="<%=ProjectName %>最新资讯,<%=ProjectName %>最新促销信息" />
    <meta name="description" content="<%=ProjectName %>销售动态信息" />
    <meta name="apple-mobile-web-app-title" content="岳阳房地产网">
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <script src="../js/jquery.js?version=1.0"></script>

    <script src="../js/common.js?version=1.0"></script>

    <link rel="stylesheet" type="text/css" href="../css/v2.css" />
</head>
<body>
    <header class="m_wrap">
<section id="topbar" class="topnav_tool">
<button class="top_btn" id="btn_back">返回</button>
<h1>最新动态</h1>
</section>
  </header>
    <div class="hnews_list">
        <ul>
            <asp:Repeater ID="rptZxdt" runat="server">
                    <ItemTemplate>
                        <li><a href="/News/NewsShow.aspx?id=<%#Eval("Id").ToString()%>">
                            <%#Eval("Title").ToString()%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
        </ul>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            $(".hnews_list li:even").addClass("bg2");
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
