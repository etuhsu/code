<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XydaShowJb.aspx.cs" Inherits="XxWapSystem.zx_xyda.XydaShowJb" %>

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
        <div class="info_h2">
            <span class="info_h2_title">基本信息</span><span class="info_h2_more" id="info_box_project_info_btn">收起<i
                class="icon_up"></i></span></div>
        <div class="info_box" id="info_box_project_info">
            <div class="info_content">
                <table class="white_title_big" border="0" cellspacing="1" width="100%">
                    <tbody>
                        <tr>
                            <td bgcolor="#ffffff" align="right" width="50%">
                                企业名称：&nbsp;
                            </td>
                            <td width="50%">
                                <%=cqyname%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                信用等级：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=ccredit%>信用分值<%=icreditvalue%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                资质等级：&nbsp;
                            </td>
                            <td>
                                <%=cgrade%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                分区：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=caddress%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                企业地址：&nbsp;
                            </td>
                            <td>
                                <%=caddress%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                营业执照注册号：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=cyyzch%>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                资质证书编号：&nbsp;
                            </td>
                            <td>
                                <%=czzbh %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                组织机构代码证：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=czzjg %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                税务登记证：&nbsp;
                            </td>
                            <td>
                                <%=cswdj %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                注册资本：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=izczb %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                企业类型：&nbsp;
                            </td>
                            <td>
                                <%=ctype %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                公司成立时间：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=dCreateTime %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                联系电话：&nbsp;
                            </td>
                            <td>
                                <%=ctel %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                法定代表人：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=ccor %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                企业经理：&nbsp;
                            </td>
                            <td>
                                <%=cqyjl %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                人员总数：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=iryzs %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                专业技术人员数：&nbsp;
                            </td>
                            <td>
                                <%=izyzs %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                合同履约情况：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=cht %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" align="right">
                                工程质量及服务：&nbsp;
                            </td>
                            <td>
                                <%=cgc %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#e8ebee" align="right">
                                专项检查情况：&nbsp;
                            </td>
                            <td bgcolor="#e8ebee">
                                <%=ccheck %>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" colspan="2" align="center">
                                企业介绍：&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <%=cintro%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <!--从业人员-->
        <div class="info_h2">
            <span class="info_h2_title">从业人员</span></div>
        <div class="info_box" id="info_box_project_building">
            <div class="info_content">
                <table cellspacing="0" cellpadding="4" align="center" width="100%" border="1">
                    <asp:Repeater ID="rptcyry" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td width="50%" rowspan="5" align="right">
                                    <img src="<%# SzPic(Eval("cThumbnail").ToString())%>" width="200">
                                </td>
                                <td bgcolor="#e8ebee">
                                    姓名：<a href="XydaShowRyxx.aspx?id=<%# Eval("iId").ToString()%>" target="_blank">
                                        <%# Eval("cName").ToString()%></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    类型：<%# Eval("cType").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    信用等级：<%# Eval("ccredit").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    级别：<%# Eval("cjb").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    证件编号：<%# Eval("czjbh").ToString()%>
                                </td>
                            </tr>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_building_btn">展开<i class="icon_down"></i></span></div>
        </div>
        <!--代表工程-->
        <div class="info_h2">
            <span class="info_h2_title">代表工程</span></div>
        <div class="info_box" id="info_box_project_intro">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptxm" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td align="center">
                                    工程名称：<%# Eval("cxmname").ToString()%>
                            </tr>
                            <tr>
                                </td>
                                <td align="center">
                                    竣工时间：<%# Eval("ckgsj").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    质量评定：<%# Eval("cpass").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_intro_btn">展开<i class="icon_down"></i></span></div>
        </div>
        <!--良好信息-->
        <div class="info_h2">
            <span class="info_h2_title">良好信息</span></div>
        <div class="info_box" id="info_box_project_jfbz">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptlh" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td>
                                    内容<%# Eval("csanction").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href='<%# Eval("cThumbnail").ToString()%>' target="_blank">照片<img src="<%# SzPic(Eval("cThumbnail").ToString())%>" width="200"></a>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    分值<%# Eval("ivalue").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    时间
                                    <%# Eval("dCreatetime").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    机构<%# Eval("cjg").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_jfbz_btn">展开<i class="icon_down"></i></span></div>
        </div>
        <!--提示信息-->
        <div class="info_h2">
            <span class="info_h2_title">提示信息</span></div>
        <div class="info_box" id="info_box_project_ptxx">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptts" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td align="center">
                                    内容<%# Eval("csanction").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href='<%# Eval("cThumbnail").ToString()%>' target="_blank">照片<img src="http://zx.yyfdcw.com<%# Eval("cThumbnail").ToString()%>"
                                        width="320" height="240"></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    分值<%# Eval("ivalue").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    时间
                                    <%# Eval("dCreatetime").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    机构<%# Eval("cjg").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="info_box_project_ptxx_btn">展开<i class="icon_down"></i></span></div>
        </div>
        <!--警示信息-->
        <div class="info_h2">
            <span class="info_h2_title">警示信息</span></div>
        <div class="info_box" id="Div4">
            <div class="info_content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <asp:Repeater ID="rptjs" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td align="center">
                                    内容<%# Eval("csanction").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <a href='<%# Eval("cThumbnail").ToString()%>' target="_blank">照片<img src="http://zx.yyfdcw.com<%# Eval("cThumbnail").ToString()%>"
                                        width="320" height="240"></a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    分值<%# Eval("ivalue").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    时间
                                    <%# Eval("dCreatetime").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    机构<%# Eval("cjg").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="btn_more">
                <span class="info_box_btn" id="Span4">展开<i class="icon_down"></i></span></div>
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
