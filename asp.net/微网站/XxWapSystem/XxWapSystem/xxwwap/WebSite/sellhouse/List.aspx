<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="XxWapSystem.sellhouse.List" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title>【岳阳二手房网|岳阳二手房买卖信息】_岳阳房地产网</title>
    <meta name="keywords" content="岳阳二手房网,岳阳二手房买卖信息,岳阳房地产网" />
    <meta name="description" content="岳阳房地产网岳阳二手房,为您提供最新、最真实的岳阳二手房信息,免费发布岳阳二手房买卖、岳阳二手房出租信息,找岳阳二手房优质中介、岳阳二手房优质经纪人、岳阳二手房优质房源信息，欢迎您来到岳阳二手房网。" />
    <meta name="apple-mobile-web-app-title" content="岳阳房地产网">
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
<h1><a href="/sellhouse/list.aspx" target="_self">二手房</a></h1>
<button class="top_btn_fav">导航</button>
</section>
</header>
    <div id="topnav_menu" class="topnav_menu" style="display: none">
        <ul>
            <li id="topnav_menu_index"><a href="/" target="_self">首页</a><s class="nav_gap"></s></li>
            <li id="topnav_menu_newhouse"><a href="/newhouse/list.aspx" target="_self">新房</a><s
                class="nav_gap"></s></li>
            <li id="topnav_menu_sellhouse"><a href="/sellhouse/list.aspx" target="_self">二手房</a><s
                class="nav_gap"></s></li>
            <li id="topnav_menu_news"><a href="/news/BuildingNews.aspx">资讯</a><s class="nav_gap"></s></li>
             <li id="topnav_menu_renthouse"><a href="/zxindex.aspx" target="_self">装修</a><s
                class="nav_gap"></s></li>
        </ul>
        <span class="topnav_contract"><i class="icon-up"></i></span>
    </div>

    <script  type="text/javascript">
        var choose_opts = new Map();
        var choose_opt_labels = new Array();

        function choose_search(type, val) {
            var args = GetUrlParms();
            var temp = "?action=es";
            if (type == "area") {
                temp = temp + "&q=" + val + "";
                if (args["h"] == null || args["h"] == "undefined") { } else {
                    temp = temp + "&h=" + args["h"];
                }
                if (args["j"] == null || args["j"] == "undefined") { } else {
                    temp = temp + "&j=" + args["j"];
                }
                if (args["t"] == null || args["t"] == "undefined") { } else {
                    temp = temp + "&t=" + args["t"];
                }
                if (args["y"] == null || args["y"] == "undefined") { } else {
                    temp = temp + "&y=" + args["y"];
                }
                if (args["key"] == null || args["key"] == "undefined") { } else {
                    temp = temp + "&key=" + args["key"];
                }

            } else if (type == "HouseType") {
                if (args["q"] == null || args["q"] == "undefined") { } else {
                    temp = temp + "&q=" + args["q"];
                }
                temp = temp + "&h=" + val + "";
                if (args["j"] == null || args["j"] == "undefined") { } else {
                    temp = temp + "&j=" + args["j"];
                }
                if (args["t"] == null || args["t"] == "undefined") { } else {
                    temp = temp + "&t=" + args["t"];
                }
                if (args["y"] == null || args["y"] == "undefined") { } else {
                    temp = temp + "&y=" + args["y"];
                }
                if (args["key"] == null || args["key"] == "undefined") { } else {
                    temp = temp + "&key=" + args["key"];
                }
            } else if (type == "price") {
                if (args["q"] == null || args["q"] == "undefined") { } else {
                    temp = temp + "&q=" + args["q"];
                }
                if (args["h"] == null || args["h"] == "undefined") { } else {
                    temp = temp + "&h=" + args["h"];
                }
                temp = temp + "&j=" + val + "";
                if (args["t"] == null || args["t"] == "undefined") { } else {
                    temp = temp + "&t=" + args["t"];
                }
                if (args["y"] == null || args["y"] == "undefined") { } else {
                    temp = temp + "&y=" + args["y"];
                }
                if (args["key"] == null || args["key"] == "undefined") { } else {
                    temp = temp + "&key=" + args["key"];
                }
            } else if (type == "ts") {
                if (args["q"] == null || args["q"] == "undefined") { } else {
                    temp = temp + "&q=" + args["q"];
                }
                if (args["h"] == null || args["h"] == "undefined") { } else {
                    temp = temp + "&h=" + args["h"];
                }
                if (args["j"] == null || args["j"] == "undefined") { } else {
                    temp = temp + "&j=" + args["j"];
                }
                temp = temp + "&t=" + val + "";
                if (args["y"] == null || args["y"] == "undefined") { } else {
                    temp = temp + "&y=" + args["y"];
                }
                if (args["key"] == null || args["key"] == "undefined") { } else {
                    temp = temp + "&key=" + args["key"];
                }
            } else if (type == "yt") {
                if (args["q"] == null || args["q"] == "undefined") { } else {
                    temp = temp + "&q=" + args["q"];
                }
                if (args["h"] == null || args["h"] == "undefined") { } else {
                    temp = temp + "&h=" + args["h"];
                }
                if (args["j"] == null || args["j"] == "undefined") { } else {
                    temp = temp + "&j=" + args["j"];
                }
                if (args["t"] == null || args["t"] == "undefined") { } else {
                    temp = temp + "&t=" + args["t"];
                }
                temp = temp + "&y=" + val + "";
                if (args["key"] == null || args["key"] == "undefined") { } else {
                    temp = temp + "&key=" + args["key"];
                }
            } else {
                if (args["q"] == null || args["q"] == "undefined") { } else {
                    temp = temp + "&q=" + args["q"];
                }
                if (args["h"] == null || args["h"] == "undefined") { } else {
                    temp = temp + "&h=" + args["h"];
                }
                if (args["j"] == null || args["j"] == "undefined") { } else {
                    temp = temp + "&j=" + args["j"];
                }
                if (args["t"] == null || args["t"] == "undefined") { } else {
                    temp = temp + "&t=" + args["t"];
                }
                if (args["y"] == null || args["y"] == "undefined") { } else {
                    temp = temp + "&y=" + args["y"];
                }
                if (args["key"] == null || args["key"] == "undefined") { } else {
                    temp = temp + "&key=" + args["key"];
                }
            }
            document.location.href = temp
        }
        //搜索
        function submitsearch() {
            var args = GetUrlParms();
            var temp = "?action=es";
            if (args["q"] == null || args["q"] == "undefined") { } else {
                temp = temp + "&q=" + args["q"];
            }
            if (args["h"] == null || args["h"] == "undefined") { } else {
                temp = temp + "&h=" + args["h"];
            }
            if (args["j"] == null || args["j"] == "undefined") { } else {
                temp = temp + "&j=" + args["j"];
            }
            if (args["t"] == null || args["t"] == "undefined") { } else {
                temp = temp + "&t=" + args["t"];
            }
            if (args["y"] == null || args["y"] == "undefined") { } else {
                temp = temp + "&y=" + args["y"];
            }
            if (args["key"] == null || args["key"] == "undefined") { } else {
                temp = temp + "&key=" + args["key"];
            }
            temp = temp + "&key=" + encodeURIComponent(jQuery("#searchInput").val()) + "";
            document.location.href = temp
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
            <input type="text" class="textInput" name="keyword" value="" id="searchInput" placeholder="请输入房源关键字"
                autocomplete="off" />
            <input type="bottom" class="search-submit right" onclick="submitsearch()" vlaue="搜索" />
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
        <span class="cur_title_font">筛选楼盘</span></h2>
    <div class="choose_opt">
        <!--新的筛选条件start-->
        <dl>
            <dt>区域</dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd class="checked">
                    <a id="q0" onclick="choose_search('area','0');" href="#">任意</a></dd>
                <dd>
                    <a id="q1" onclick="choose_search('area','1');" href="#">岳阳楼区</a></dd>
                <dd>
                    <a id="q2" onclick="choose_search('area','2');" href="#">南湖风景区</a></dd>
                <dd>
                    <a id="q3" onclick="choose_search('area','3');" href="#">经济开发区</a></dd>
                <dd>
                    <a id="q4" onclick="choose_search('area','4');" href="#">城陵矶</a></dd>
                <dd>
                    <a id="q5" onclick="choose_search('area','5');" href="#">云溪区</a></dd>
                <dd>
                    <a id="q6" onclick="choose_search('area','6');" href="#">君山区</a></dd>
            </div>
        </dl>
        <dl>
            <dt>面积</dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd class="checked">
                    <a id="h0" onclick="choose_search('HouseType','0');" href="#">任意</a></dd>
                <dd>
                    <a id="h1" onclick="choose_search('HouseType','1');" href="#">60平米以下</a></dd>
                <dd>
                    <a id="h2" onclick="choose_search('HouseType','2');" href="#">60-90平米</a></dd>
                <dd>
                    <a id="h3" onclick="choose_search('HouseType','3');" href="#">90-120平米</a></dd>
                <dd>
                    <a id="h4" onclick="choose_search('HouseType','4');" href="#">120-144平米</a></dd>
                <dd>
                    <a id="h5" onclick="choose_search('HouseType','5');" href="#">144平米以上</a></dd>
            </div>
        </dl>
        <dl>
            <dt>价格</dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd class="checked">
                    <a id="j0" onclick="choose_search('price','0');" href="#">任意</a></dd>
                <dd>
                    <a id="j1" onclick="choose_search('price','1');" href="#">20万以下</a></dd>
                <dd>
                    <a id="j2" onclick="choose_search('price','2');" href="#">20-30万</a></dd>
                <dd>
                    <a id="j3" onclick="choose_search('price','3');" href="#">30-40万</a></dd>
                <dd>
                    <a id="j4" onclick="choose_search('price','4');" href="#">40-50万</a></dd>
                <dd>
                    <a id="j5" onclick="choose_search('price','5');" href="#">50-60万</a></dd>
                <dd>
                    <a id="j6" onclick="choose_search('price','6');" href="#">60-80万</a></dd>
                <dd>
                    <a id="j7" onclick="choose_search('price','7');" href="#">80-100万</a></dd>
                <dd>
                    <a id="j8" onclick="choose_search('price','8');" href="#">100万以上</a></dd>
            </div>
        </dl>
        <dl>
            <dt>厅室</dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd class="checked">
                    <a id="t0" onclick="choose_search('ts','0');" href="#">任意</a></dd>
                <dd>
                    <a id="t1" onclick="choose_search('ts','1');" href="#">一室</a></dd>
                <dd>
                    <a id="t2" onclick="choose_search('ts','2');" href="#">二室</a></dd>
                <dd>
                    <a id="t3" onclick="choose_search('ts','3');" href="#">三室</a></dd>
                <dd>
                    <a id="t4" onclick="choose_search('ts','4');" href="#">四室</a></dd>
                <dd>
                    <a id="t5" onclick="choose_search('ts','5');" href="#">五室</a></dd>
                <dd>
                    <a id="t6" onclick="choose_search('ts','6');" href="#">六室</a></dd>
                <dd>
                    <a id="t7" onclick="choose_search('ts','7');" href="#">七室</a></dd>
                <dd>
                    <a id="t8" onclick="choose_search('ts','8');" href="#">八室</a></dd>
                <dd>
                    <a id="t9" onclick="choose_search('ts','9');" href="#">八室以上</a></dd>
            </div>
        </dl>
        <dl>
            <dt>用途</dt>
            <span class="choose_switch"><i class="icon-on"></i></span>
            <div class="choose_opt_list">
                <dd class="checked">
                    <a id="y0" onclick="choose_search('yt','0');" href="#">任意</a></dd>
                <dd>
                    <a id="y1" onclick="choose_search('yt','1');" href="#">普通住宅</a></dd>
                <dd>
                    <a id="y2" onclick="choose_search('yt','2');" href="#">商住</a></dd>
                <dd>
                    <a id="y3" onclick="choose_search('yt','3');" href="#">商铺</a></dd>
                <dd>
                    <a id="y4" onclick="choose_search('yt','4');" href="#">写字楼</a></dd>
                <dd>
                    <a id="y5" onclick="choose_search('yt','5');" href="#">别墅</a></dd>
                <dd>
                    <a id="y6" onclick="choose_search('yt','6');" href="#">公寓</a></dd>
                <dd>
                    <a id="y7" onclick="choose_search('yt','7');" href="#">厂房</a></dd>
                <dd>
                    <a id="y8" onclick="choose_search('yt','8');" href="#">其他</a></dd>
            </div>
        </dl>
        <!--新的筛选条件end -->
    </div>
    <div class="choose_more">
        更多筛选条件<i class="icon-down"></i></div>
    <!--数据-->
    <h2 class="h2_tabtitle">
        <span class="cur_title_count"><i class="bhline"></i>出售房源</span>
    </h2>
    <div id="datalist">
        <div class="tplist">
            <ul>
                <asp:Repeater ID="rptlist" runat="server">
                    <ItemTemplate>
                        <li class="p-item" onclick="gourl('Show.aspx?id=<%# Eval("ID").ToString() %>')">
                            <div class="p-img">
                                <a href="Show.aspx?id=<%# Eval("ID").ToString() %>">
                                    <img width="50" height="50" alt="<%# Eval("Title").ToString() %>" src="<%#BindPic(Eval("pic").ToString()) %>" />
                                </a>
                            </div>
                            <div class="p-txt">
                                <div class="s-name">
                                    <a href="Show.aspx?id=<%# Eval("ID").ToString() %>"><%# Eval("Title").ToString() %></a></div>
                                <div class="s-addr">
                                    <%# Eval("AreaName") %> - <%# Eval("Address") %></div>
                                <div class="s-addr">
                                    <%# BindHType(Eval("HomeType").ToString(),Eval("HomeType1").ToString(),Eval("HomeType2").ToString())%> <%#Eval("Construction")%>平米</div>
                                <div class="s-price">
                                   <%# BindMoney(Eval("Price").ToString())%></div>
                            </div>
                            <%--<div class="s-tag ctag_label_r">
                        急售</div>--%>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
        var page = 2;
        var url = "SellHouseAjax.aspx?Action=list<%=PostStr %>";

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
            var nodataitem = '<div class="nodata_tag">很抱歉,没有找到相关楼盘信息！</div>';

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
                if (searchInput.length >= 2) {
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
                go_sellhouse_block_url($(this).attr("pid"));
                $("#sugglist").hide();
            });

        });
        
        
         <%=ScriptStr %>
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
