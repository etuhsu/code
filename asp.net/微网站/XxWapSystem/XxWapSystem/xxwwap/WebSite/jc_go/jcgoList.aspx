<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jcgoList.aspx.cs" Inherits="XxWapSystem.jc_go.jcgoList" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no"/> 
<meta name="format-detection" content="telephone=no" />
<title>岳阳房地产装修网 建材GO便宜</title>
<meta name="keywords" content="岳阳房地产装修网,岳阳装修,岳阳装修公司,岳阳建材,岳阳家居,设计师,装修作品,装修日记,本地团购"/>
<meta name="description" content="岳阳房地产装修网是岳阳地区唯一一家专门从事装修信息服务的网络媒体。为您提供最新的行业动态和促销信息、最全的装修建材、最权威的行业规章和信用档案。岳阳房地产装修网致力成为岳阳装修行业最权威的公信媒体。"/>
<meta name="apple-mobile-web-app-title" content="岳阳房地产装修网">
<meta name="apple-mobile-web-app-capable" content="yes" />
<script src="../js/jquery.js?version=1.0"></script> 
<script src="../js/common.js?version=1.0"></script>
<link rel="stylesheet" type="text/css" href="../css/v2.css" />
<link rel="stylesheet" type="text/css" href="../css/main.css" />
<link rel="stylesheet" type="text/css" href="../css/base.css" />
<link rel="stylesheet" type="text/css" href="../css/city/nj.css" />

</head>
<body>
    <!--头部LOGO-->
<header class="m_wrap">
<section id="topbar" class="ytopnav_tool">
<button class="ytop_btn" id="btn_back">返回</button>
<button class="top_btn_fav_news" onClick="gohome()">回首页</button>
<h1>建材GO便宜</h1>
</section>
</header>    

    <script type="text/javascript">
        var choose_opts = new Map();
        var choose_opt_labels = new Array();

        function submitsearch() {
            var jumpurl = "?jcname=" + encodeURIComponent(jQuery("#searchInput").val()) + "";
            document.location.href = jumpurl;
        }

        function choose_search(type, val) {
            var args = GetUrlParms();
            var temp = "?action=jc";
            if (type == "type") {
                temp = temp + "&ty=" + val + "";
                if (args["key"] == null || args["key"] == "undefined") { } else {
                    temp = temp + "&key=" + args["key"];
                }
            }
            document.location.href = temp;
        }
    </script>
    <!--搜索区域-->
    <div class="search_wrap">
        <div id="sugglist">
        </div>
        <form method="get" id="search_form" name="search_form" action="?">
        <div class="search-input">
            <label for="searchInput" class="forSearchInput2">
            </label>
            <input type="text" class="textInput" name="keyword" value="" id="searchInput" placeholder="请输入建材关键字"
                autocomplete="off" />
            <input type="bottom" class="search-submit right" onClick="submitsearch()" vlaue="搜索" />
        </div>
        </form>
    </div>
    <!--已选择条件-->
    <div class="choose_selected">
        <span class="choose_sel_label">已选条件：</span>
        <ul id="choose_selected_list">
        </ul>
    </div>
    <!--筛选区域-->
    <h2 class="h2_tabtitle">
        <span class="cur_title_font">筛选建材</span></h2>
    <div class="choose_opt">
        <!--新的筛选条件start-->
        <dl>
            <dt></dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
<%--                <dd class="checked">
                    <a id="A1" onclick="choose_search('type','0');" href="#">全部</a></dd>--%>
                <dd>
                    <a id="t1" onclick="choose_search('type','1');" href="#">瓷砖</a></dd>
                <dd>
                    <a id="t2" onclick="choose_search('type','2');" href="#">地面砖</a></dd>
                <dd>
                    <a id="t3" onclick="choose_search('type','3');" href="#">墙面砖</a></dd>
                <dd>
                    <a id="t4" onclick="choose_search('type','4');" href="#">背景类装饰砖</a></dd>
            </div>
        </dl>
        <dl>
            <dt></dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd>
                    <a id="t5" onclick="choose_search('type','5');" href="#">地板</a></dd>
                <dd>
                    <a id="t6" onclick="choose_search('type','6');" href="#">实木复合地板</a></dd>
                <dd>
                    <a id="t7" onclick="choose_search('type','7');" href="#">实木地板</a></dd>
                <dd>
                    <a id="t8" onclick="choose_search('type','8');" href="#">竹地板</a></dd>
                <dd>
                    <a id="t9" onclick="choose_search('type','9');" href="#">软木地板</a></dd>
                <dd>
                    <a id="t10" onclick="choose_search('type','10');" href="#">强化复合地板</a></dd>
            </div>
        </dl>
        <dl>
            <dt></dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd>
                    <a id="t11" onclick="choose_search('type','11');" href="#">门</a></dd>
                <dd>
                    <a id="t12" onclick="choose_search('type','12');" href="#">室内房门</a></dd>
                <dd>
                    <a id="t13" onclick="choose_search('type','13');" href="#">衣柜门</a></dd>
                <dd>
                    <a id="t14" onclick="choose_search('type','14');" href="#">隔断门</a></dd>
            </div>
        </dl>
        <dl>
            <dt></dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd>
                    <a id="t30" onclick="choose_search('type','30');" href="#">柜体</a></dd>
                <dd>
                    <a id="t31" onclick="choose_search('type','31');" href="#">衣柜</a></dd>
                <dd>
                    <a id="t35" onclick="choose_search('type','35');" href="#">酒柜</a></dd>
                <dd>
                    <a id="t33" onclick="choose_search('type','33');" href="#">书柜</a></dd>
                <dd>
                    <a id="t34" onclick="choose_search('type','34');" href="#">鞋柜</a></dd>
            </div>
        </dl>
        <dl>
            <dt></dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd>
                    <a id="t15" onclick="choose_search('type','15');" href="#">吊顶</a></dd>
                <dd>
                    <a id="t16" onclick="choose_search('type','16');" href="#">厨卫</a></dd>
                <dd>
                    <a id="t17" onclick="choose_search('type','17');" href="#">过道</a></dd>
                <dd>
                    <a id="t18" onclick="choose_search('type','18');" href="#">阳台</a></dd>
                <dd>
                    <a id="t19" onclick="choose_search('type','19');" href="#">墙纸</a></dd>
            </div>
        </dl>
        <dl>
            <dt></dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd>
                    <a id="t20" onclick="choose_search('type','20');" href="#">卫浴</a></dd>
                <dd>
                    <a id="t21" onclick="choose_search('type','21');" href="#">面盆</a></dd>
                <dd>
                    <a id="t22" onclick="choose_search('type','22');" href="#">浴缸</a></dd>
                <dd>
                    <a id="t23" onclick="choose_search('type','23');" href="#">座便器</a></dd>
                <dd>
                    <a id="t24" onclick="choose_search('type','24');" href="#">淋浴房</a></dd>
                <dd>
                    <a id="t25" onclick="choose_search('type','25');" href="#">龙头及花洒</a></dd>
                <dd>
                    <a id="t26" onclick="choose_search('type','26');" href="#">橱柜</a></dd>
                <dd>
                    <a id="t27" onclick="choose_search('type','27');" href="#">灯饰</a></dd>
                <dd>
                    <a id="t28" onclick="choose_search('type','28');" href="#">客餐厅</a></dd>
                <dd>
                    <a id="t29" onclick="choose_search('type','29');" href="#">卧室</a></dd>                                                                                
            </div>
        </dl>
        <!--新的筛选条件end -->
    </div>
    <div class="choose_more">
        更多筛选条件<i class="icon-down"></i></div>
    <!--数据-->
    <h2 class="h2_tabtitle">
        <span class="cur_title_count"><i class="bhline"></i>
            <%=AllBudingCount %>个建材</span>
    </h2>
    <!--数据-->
    <h2 class="h2_tabtitle">
        <span class="cur_title_count"><i class="bhline"></i>精品家装材料</span>
    </h2>
    <div id="datalist">
        <div class="tplist">
            <ul>
                <asp:Repeater ID="rptMessage" runat="server">
                    <ItemTemplate>
                        <li class="p-item" onClick="gourl('ProductShow.aspx?id=<%# Eval("iID").ToString() %>')">
                            <div class="p-img">
                                <a href="ProductShow.aspx?id=<%# Eval("iID").ToString() %>">
                                    <img width="50" height="50" alt="<%# Eval("cProductName").ToString() %>" src="<%# Thumbnail(Eval("iID").ToString()) %>" />
                                </a>
                            </div>
                            <div class="p-txt">
                                <div class="s-name">
                                    <a href="ProductShow.aspx?id=<%# Eval("iID").ToString() %>"><%# Eval("cProductName").ToString()%></a></div>
                                <div class="s-addr">
                                    品牌：<%# Brand(Eval("iBrandID").ToString())%> - 产品型号：<%# Eval("cProductXh").ToString()%></div>
                                <div class="s-addr">
                                    促销价</div>
                                <div class="s-price">
                                   ￥<%# Eval("cPrice").ToString()%></div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
        var page = 2;
        var url = "ProductAjax.aspx?Action=list<%=RequestStr%>";

        $(document).ready(function() {


            //新加的
            var is_topnav_show = false;
            $(".top_btn_fav").click(function() {
                if (is_topnav_show) {
                    $("#topnav_menu").slideUp();
                    is_topnav_show = false;
                } else {
                    $("#topnav_menu").slideDown();
                    is_topnav_show = true;
                }
            });
            $(".topnav_contract").click(function() {
                $("#topnav_menu").slideUp();
                is_topnav_show = false;
            });
            $(".choose_opt dl").addClass('choose_line');
            $(".choose_switch").click(function() {
                //alert($(this).parent().html());
                $(this).parent().toggleClass('choose_line');
                //alert($(this).find("i").hasClass("icon-on"));
                if ($(this).find("i").hasClass("icon-on")) {
                    $(this).find("i").removeClass('icon-on');
                    $(this).find("i").toggleClass('icon-off');
                } else {
                    $(this).find("i").removeClass('icon-off');
                    $(this).find("i").toggleClass('icon-on')
                }
            });

            //更多筛选
            var choose_more = false;
            var more_choose_up_html = '更多筛选条件<i class="icon-down"></i>';
            var more_choose_down_html = '精简筛选条件<i class="icon-up"></i>';
            $(".choose_opt dl:gt(1)").hide();
            $(".choose_more").click(function() {
                if (choose_more) {
                    $(".choose_opt dl:gt(1)").hide();
                    $(this).html(more_choose_up_html);
                    choose_more = false;
                } else {
                    $(".choose_opt dl:gt(1)").show();
                    $(this).html(more_choose_down_html);
                    choose_more = true;
                }
            });
            //已选条件  
            var choose_selected_list_html = "";
            if (choose_opts.size() > 0) {
                for (var i = 0; i < choose_opts.size(); i++) {
                    choose_selected_list_html += "<li><label>" + choose_opt_labels[choose_opts.element(i).key] + ":</label>" + choose_opts.element(i).value + "</li>";
                }
                $("#choose_selected_list").html(choose_selected_list_html);
            } else {
                $(".choose_selected").hide();
            }

            //初始化排序选择
            //initOrderParam();
            //新加end

            var moreitem = '<div class="more_tag">点击加载更多</div>';
            var nodataitem = '<div class="nodata_tag">很抱歉,没有找到相关建材信息！</div>';

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
                            //$("#datalist").append(moreitem);
                            $(".more_tag").show();
                        } else {
                            $(".more_tag").hide();
                            $("#datalist").append('<div class="nodata_tag">没有更多数据了</div>');
                        }
                    }
                });
            });

            $("#datalist li:even").addClass("bg2");


            //搜索联想
            $("#searchInput").keyup(function() {
                var thinkurl = "SearchLink.aspx";
                var searchInput = $("#searchInput").val();
                if (searchInput.length >= 1) {
                    $("#sugglist").html('<img src="../images/loading.gif"/>');
                    $("#sugglist").show();
                    $.ajax({
                        type: 'POST',
                        url: thinkurl,
                        data: "k=" + encodeURIComponent($.trim(searchInput)),
                        success: function(d) {
                            var bData = eval('(' + d + ')');
                            if (bData.error == "false") {
                                var sugglisthtml = '<ul>';
                                for (var i = 0; i < bData.data.length; i++) {
                                    sugglisthtml += "<li pid=\"" + bData.data[i].id + "\">" + bData.data[i].name + "</li>";
                                }
                                sugglisthtml += '</ul>';
                            }
                            else {
                                $("#sugglist").hide();
                            }
                            $("#sugglist").html(sugglisthtml);
                        }
                    });
                } else {
                    $("#sugglist").hide();
                }

            });

            $('#sugglist li').live('click', function() {
                window.location = 'ProductShow.aspx?ID=' + $(this).attr("pid");
                $("#sugglist").hide();
            });

        });
        <%=ScriptStr %>
    </script>

    <!--底部导航-->
<div class="footer">
	<footer>
		<div class="footer_top">
		  <div class="islogin">
			<a href="/news/BuildingNews.aspx">资讯</a>
			<a href="/newhouse/List.aspx" target="_self">新房</a>
			<a href="/sellhouse/List.aspx" target="_self">二手房</a>
			<a href="/zxindex.aspx" target="_self">装修</a>
          </div>
		</div>
		<div class="footer_bottom">
		  <div class="gotop" id="gotop" style="display:none;"><a href="javascript:scroll(0,0)"><img src="content/home/images/top.png" style="width:100%" /></a></div>
          <div class="links">
          <span>触屏版</span>
          <span>-</span>
          <a href="http://zx.yyfdcw.com">电脑版</a>
          </div>
		</div>
		<p class="copyRight">
          <span>岳阳房地产装修网版权所有&copy;2014</span>
		</p>
	</footer>
</div>
    <div class="btn_gotop" id="btn_gotop" style="display: none">
    </div>
</body>
</html>