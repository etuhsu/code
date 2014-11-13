<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XydaShowRyxx.aspx.cs" Inherits="XxWapSystem.zx_xyda.XydaShowRyxx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        <a id="btn_app_down" href="http://app.house365.com/taofang/?channel=cptfxz" target="_blank">
        </a><span class="downtxt fr" id="closetip">关闭</span>
    </div>
    <div class="app-open-bar" id="app-open-bar" style="display: none;">
        <span class="open_close" id="app_open_close"></span><span class="open_icon"></span>
        <span class="open_alt">极速体验更省流量</span> <span class="opentxt fr" id="openapp">立即打开</span>
    </div>
    <!--头部LOGO-->
    <header class="m_wrap"><SECTION class="topnav_tool" 
id="topbar"><BUTTON class="top_btn" id="btn_back">返回</BUTTON> 
<H1>岳阳市装饰装修企业基本情况 </H1>
</SECTION></header>
    
    <!--基本信息-->
    <div class="news-wrap">
        <div class="info_box" id="info_box_project_info">
            <div class="news-content">
                <table class="white_title_big" border="0" cellspacing="1" width="100%">
                    <tbody>
                        <%if (cThumbnail.Length > 0)
                          {%>
                        <tr>
                            <td bgcolor="#e8ebee" align="right" width="38%">
                                照片：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee" width="62%">
                                <img class="lazy" src="http://zx.yyfdcw.com/<%=cThumbnail %>" width="200px" height="285px">
                            </td>
                        </tr>
                        <%} %>
                        <tr>
                            <td bgcolor="#e8ebee" align="right" width="38%">
                                姓名：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee" width="62%">
                                <%=cName%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                企业名称：&nbsp;
                            </td>
                            <td>
                                <%=cqyname%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                人员类型：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=cType%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                信用等级：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=ccredit%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                性别：&nbsp;
                            </td>
                            <td>
                                <%=csex%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right" class="style2">
                                专业：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee" class="style2">
                                <%=cgz%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                级别：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=cjb%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                信用信息编号：&nbsp;
                            </td>
                            <td>
                                <%=czjbh%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                发证时间：&nbsp;
                            </td>
                            <td>
                                <%=cfzsj%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                发证机关：&nbsp;
                            </td>
                            <td>
                                <%=cfzjg%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                最高学历：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=cxl%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                工作年限：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=czl%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                年度审核情况：&nbsp;
                            </td>
                            <td>
                                <%=cby%>
                            </td>
                            <tr>
                                <td bgcolor="#ffffff" align="right">
                                    工作简历：&nbsp;
                                </td>
                                <td colspan="3">
                                    <%=cjl%>
                                </td>
                            </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="info_box" id="info_box_project_intro">
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
<ul>
<li id="footernav_news"><a href="/news/BuildingNews.aspx">资讯</a></li>
<li id="footernav_newhouse"><a href="/newhouse/List.aspx" target="_self">新房</a></li>
<li id="footernav_sellhouse"><a href="/sellhouse/List.aspx" target="_self">二手房</a></li> 
<li id="footnav_bbs"><a href="/index.html" target="_self">装修</a></li> 
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
