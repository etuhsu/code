<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tsList.aspx.cs" Inherits="XxWapSystem.zx_ts.tsList" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title>岳阳房地产装修网 装修投诉</title>
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
var appdowntip=getCookie('appdowntip');
var closetip=getCookie('closetip');
if(navigator.cookieEnabled && appdowntip==null){
   //document.write('<meta name="apple-itunes-app" content="app-id=543472063">');
   //setCookie('appdowntip',true);
}
$(document).ready(function(){
	var apppop=getCookie('apppop');
	if(navigator.cookieEnabled && apppop==null){
	    setCookie('apppop',true);
		//$("#app_downloads").show();
		$("#app_downloads").css("width",document.body.clientWidth);
		$("#app_downloads").css("height",document.body.clientHeight);
		$(".turn_off").click( function () {
			//$("#app_downloads").hide();
		});
		$(".no_download").click( function () {
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
<h1>装修投诉</h1>
</section>

</header>
    <div class="clear">
    </div>
    <div id="datalist">
        <div class="nplist">
            <ul>
                <asp:Repeater ID="rptMessage" runat="server">
                    <ItemTemplate>
                        <li onclick="gourl('tsShow.aspx?id=<%# Eval("iID").ToString() %>')">
                            <div class="p-txt">
                                <div class="p-title">
                                    <a target="_self" href="tsShow.aspx?id=<%# Eval("iID").ToString() %>">投诉标题:<%# Eval("ctitle").ToString()%> </a>
                                </div>
                                <div class="p-summary">
                                    投诉对象:<%# Eval("cqyname").ToString()%>
                                    <br>
                                    时间:<%#Eval("daddtime").ToString()%>
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
var page=2;
var url = "tsAjax.aspx";

$(document).ready(function() {
    var moreitem ='<div class="more_tag">点击加载更多</div>';
    $("#datalist").append(moreitem);

     $(".more_tag").click(function(){
        $(".more_tag").hide();
        $("#datalist").append('<div class="page_loading"></div>');
            $.ajax({
            type: "GET",
            url: url,
            data: "page="+page,
            success: function(msg){

                $(".page_loading").remove();
                if(msg!=''){
                    page=page+1;
                    $("#datalist ul").append(msg);
                    $(".more_tag").show();
                }else{
                   $(".more_tag").hide();
                   $("#datalist").append('<div class="nodata_tag">没有更多数据了</div>');
                }
            }
            });
    });

    $("#datalist li:even").addClass("bg2");
});
    </script>

<div class="call_wrap" id="call_bar">
            <span class="tousu_txt">
                在填写“联系电话”时请真实填写，方便
                <br />工作人员及时联系您处理相关问题。
                </span> <span class="call_btn"><a href="tsInput.aspx">
                    投诉</a></span>
        </div>

    <!--底部导航-->
    <nav class="footernav">
<ul>
<li id="footernav_news"><a href="/news/BuildingNews.aspx">资讯</a></li>
<li id="footernav_newhouse"><a href="/newhouse/List.aspx" target="_self">新房</a></li>
<li id="footernav_sellhouse"><a href="/sellhouse/List.aspx" target="_self">二手房</a></li> 
<li id="footnav_bbs"><a href="/zxindex.aspx" target="_self">装修</a></li> 
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
