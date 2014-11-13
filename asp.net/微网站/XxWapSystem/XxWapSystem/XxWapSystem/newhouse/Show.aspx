<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="XxWapSystem.newhouse.Show" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <title>
        <%=ProjectName %>_岳阳房地产网</title>
    <meta name="keywords" content="<%=ProjectName %>,<%=ProjectName %>项目简介,<%=ProjectName %>价格走势,<%=ProjectName %>位置图,<%=ProjectName %>户型图,<%=ProjectName %>最新资讯,预售许可证,楼盘资料,开发商,企业诚信,论坛" />
    <meta name="description" content="<%=SEODescription %>" />
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
<h1><%=ProjectName %></h1>
<!--<button class="top_btn_fav" onclick="addFavorite(location.href, document.title)">收藏</button>-->
</section>
</header>
    <!--焦点图-->
    <div class="detail_pic">
        <div class="switch_pic">
            <a href="Images.aspx?id=<%=MsgID %>" target="_self">
                <img src="http://xx.yyfdcw.com<%=Thumbnail %>" width="320px" height="200px"></a>
        </div>
        <div class="switch_indicators">
        </div>
        <div class="bg_transparent_switch">
            <span class="switch_count">共<%=ImageCount %>张图片</span></div>
    </div>
    <!--基本信息-->
    <div class="detail_info clear">
        <div class="info_li">
            <span class="info_attr">参考价格：</span><span class="info_val" id="info_price"><%=BuildingPrice %></span></div>
        <div class="info_li">
            <span class="info_attr">开盘时间：</span><span class="info_val"><%=OpenTime %></span></div>
        <div class="info_li">
            <span class="info_attr">装修情况：</span><span class="info_val"><%=DecorateInfo%></span></div>
        <div class="info_li">
            <span class="info_attr">建筑类别：</span><span class="info_val"><%=Jzlb%></span></div>
        <div class="info_li">
            <span class="info_attr">户型面积：</span><span class="info_val"><%=Hxmj%></span></div>
        <div class="info_li">
            <span class="info_attr">项目地址：</span></div>
        <div class="info_li">
            <span class="info_val" style="padding-left: 10px;">
                <%=Address%></span></div>
        <div class="clear">
        </div>
        <div class="info_map">
            <a href="map.aspx?id=<%=MsgID %>">
                <img width="300px" height="130px" src="http://api.map.baidu.com/staticimage?width=300&amp;height=130&amp;zoom=14&amp;markers=<%=Yzuobiao %>,<%=Xzuobiao %>&amp;markerStyles=s,0"></a>
        </div>
        <!--最新动态-->
        <div class="info_h2">
            <span class="info_h2_title">最新资讯</span> <span class="info_h2_more"><a href="News.aspx?id=<%=MsgID %>"
                target="_self">更多<i class="icon_arrow"></i></a></span>
        </div>
        <div class="info_list clist">
            <ul>
                <asp:Repeater ID="rptZxdt" runat="server">
                    <ItemTemplate>
                        <li><a href="/News/NewsShow.aspx?id=<%#Eval("Id").ToString()%>">
                            <%#Eval("Title").ToString()%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!--详细参数-->
        <div class="info_h2">
            <span class="info_h2_title">详细参数</span><span class="info_h2_more" id="info_box_project_info_btn">收起<i
                class="icon_up"></i></span></div>
        <div class="info_box" id="info_box_project_info">
            <div class="info_content">
                <div class="info_li">
                    <span class="info_attr">参考均价：</span><span class="info_val"><%=BuildingPrice %></span></div>
                <div class="info_li">
                    <span class="info_attr">开盘时间：</span><span class="info_val"><%=OpenTime %></span></div>
                <div class="info_li">
                    <span class="info_attr">装修情况：</span><span class="info_val"><%=DecorateInfo%></span></div>
                <div class="info_li">
                    <span class="info_attr">项目地址：</span><span class="info_val"><%=Address%></span></div>
                <div class="info_li">
                    <span class="info_attr">所属区域：</span><span class="info_val"><%=AreaName %></span></div>
                <div class="info_li">
                    <span class="info_attr">销售地址：</span><span class="info_val"><%=SaleAddress %></span></div>
                <div class="info_li">
                    <span class="info_attr">销售热线：</span><span class="info_val"><%=SalePhone %></span></div>
                <div class="info_li">
                    <span class="info_attr">开 发 商：</span><span class="info_val"><%=Kfs %></span></div>
                <div class="info_li">
                    <span class="info_attr">设计单位：</span><span class="info_val"><%=Sjdw %></span></div>
                <div class="info_li">
                    <span class="info_attr">承建单位：</span><span class="info_val"><%=Cjdw %></span></div>
                <div class="info_li">
                    <span class="info_attr">物业单位：</span><span class="info_val"><%=Wydw %></span></div>
                <div class="info_li">
                    <span class="info_attr">建筑类别：</span><span class="info_val"><%=Jzlb%></span></div>
                <div class="info_li">
                    <span class="info_attr">占地面积：</span><span class="info_val"><%=Zdmj %>平方米</span></div>
                <div class="info_li">
                    <span class="info_attr">建筑面积：</span><span class="info_val"><%=Jzmj %>平方米</span></div>
                <div class="info_li">
                    <span class="info_attr">总 栋 数：</span><span class="info_val"><%=Zds %>栋</span></div>
                <div class="info_li">
                    <span class="info_attr">总 户 数：</span><span class="info_val"><%=Zhs %></span></div>
                <div class="info_li">
                    <span class="info_attr">总 投 资：</span><span class="info_val"><%=Ztz %>万元</span></div>
                <div class="info_li">
                    <span class="info_attr">绿 化 率：</span><span class="info_val"><%=Lhl %></span></div>
                <div class="info_li">
                    <span class="info_attr">容 积 率：</span><span class="info_val"><%=Rjl %></span></div>
                <div class="info_li">
                    <span class="info_attr">国土使用权证：</span><span class="info_val"><%=Gtsyqz %></span></div>
                <div class="info_li">
                    <span class="info_attr">土地使用年限：</span><span class="info_val"><%=Tdsynx %>年</span></div>
                <div class="info_li">
                    <span class="info_attr">建设工程规划许可证：</span><span class="info_val"><%=Jsgcghxkz %></span></div>
                <div class="info_li">
                    <span class="info_attr">建设用地规划许可证：</span><span class="info_val"><%=Jsydghxkz %></span></div>
            </div>
        </div>
        <!--栋信息-->
        <div class="info_h2">
            <span class="info_h2_title">每幢房屋具体情况</span></div>
        <div class="info_box" id="info_box_project_building">
            <div class="info_content">
               <%=BuildingInfoHtml %>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_building_btn">展开<i class="icon_down"></i></span></div>
        </div>
        <!--项目介绍-->
        <div class="info_h2">
            <span class="info_h2_title">项目介绍</span></div>
        <div class="info_box" id="info_box_project_intro">
            <div class="info_content">
                <%=ProjectInfo %>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_intro_btn">收起<i class="icon_up"></i></span></div>
        </div>
        <!--周边配套-->
        <div class="info_h2">
            <span class="info_h2_title">交房标准</span></div>
        <div class="info_box" id="info_box_project_jfbz">
            <div class="info_content">
                <%=Jfbz %>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_jfbz_btn">展开<i class="icon_down"></i></span></div>
        </div>
        <!--交通-->
        <div class="info_h2">
            <span class="info_h2_title">配套信息</span></div>
        <div class="info_box" id="info_box_project_ptxx">
            <div class="info_content">
                <%=Ptxx %></div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_ptxx_btn">展开<i class="icon_down"></i></span></div>
        </div>
    </div>
    <div class="call_wrap" id="call_bar">
        <span class="call_tel">
            <%=SalePhone %></span> <span class="call_btn"><a href="tel:<%=SalePhone %>" onclick="_gaq.push(['_trackEvent', '[岳阳房地产网-新房详情]', '[拨打电话]', '<%=ProjectName %>']);">
                拨打</a></span>
    </div>

    <script type="text/javascript">
//分享
var share_link =window.location.href;
var share_content="<%=ProjectInfo %>";
var share_title="<%=ProjectName %>";
var share_img="http://xx.yyfdcw.com<%=Thumbnail %>";
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
