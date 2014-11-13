<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XydaShowXm.aspx.cs" Inherits="XxWapSystem.zx_xyda.XydaShowXm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta content="IE=11.0000" http-equiv="X-UA-Compatible">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <title>�������ز�װ���� ���ű���</title>
    <meta name="keywords" content="�������ز�װ����,����װ��,����װ�޹�˾,��������,�����Ҿ�,���ʦ,װ����Ʒ,װ���ռ�,�����Ź�" />
    <meta name="description" content="�������ز�װ��������������Ψһһ��ר�Ŵ���װ����Ϣ���������ý�塣Ϊ���ṩ���µ���ҵ��̬�ʹ�����Ϣ����ȫ��װ�޽��ġ���Ȩ������ҵ���º����õ������������ز�װ����������Ϊ����װ����ҵ��Ȩ���Ĺ���ý�塣" />
    <meta name="apple-mobile-web-app-title" content="�������ز�װ����">
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
        </a><span class="downtxt fr" id="closetip">�ر�</span>
    </div>
    <div class="app-open-bar" id="app-open-bar" style="display: none;">
        <span class="open_close" id="app_open_close"></span><span class="open_icon"></span>
        <span class="open_alt">���������ʡ����</span> <span class="opentxt fr" id="openapp">������</span>
    </div>
    <!--ͷ��LOGO-->
    <header class="m_wrap"><SECTION class="topnav_tool" 
id="topbar"><BUTTON class="top_btn" id="btn_back">����</BUTTON> 
<H1>������װ��װ����ҵ������� </H1>
</SECTION></header>
    <div class="ntab_title">
        <ul>
            <li><a href="XydaShowJb.aspx?id=<%=Request["id"]%>">������Ϣ</a></li>
            <li><a href="XydaShowRy.aspx?id=<%=Request["id"]%>">��ҵ��Ա</a></li>
            <li class="selected"><a href="XydaShowXm.aspx?id=<%=Request["id"]%>">������</a></li>
            <li><a href="XydaShowLh.aspx?id=<%=Request["id"]%>">������Ϣ</a></li>
            <li><a href="XydaShowTs.aspx?id=<%=Request["id"]%>">��ʾ��Ϣ</a></li>
            <li><a href="XydaShowJs.aspx?id=<%=Request["id"]%>">��ʾ��Ϣ</a></li>
        </ul>
    </div>
    <!--������Ϣ-->
    <div class="news-wrap">
        <div class="info_box" id="info_box_project_info">
            <div class="news-content">
                <table cellspacing="0" bordercolordark="#ffffff" cellpadding="4" align="center" bordercolorlight="#333333"
                    width="100%" border="1">
                    <tr>
                        <td height="29" background="images/bg2.gif" align="left">
                            <span class="STYLE50">��ҵ��Ŀ���</span>
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#e8ebee">
                                <td align="center">
                                    �������ƣ�<%# Eval("cxmname").ToString()%>
                            </tr>
                            <tr>
                                </td>
                                <td align="center">
                                    ����ʱ�䣺<%# Eval("ckgsj").ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    ����������<%# Eval("cpass").ToString()%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="info_box" id="info_box_project_intro">
        </div>
    </div>

    <script type="text/javascript">
//����
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

    <!--�ײ�����-->
    <nav class="footernav">
<ul>
<li id="footernav_news"><a href="/news/BuildingNews.aspx">��Ѷ</a></li>
<li id="footernav_newhouse"><a href="/newhouse/List.aspx" target="_self">�·�</a></li>
<li id="footernav_sellhouse"><a href="/sellhouse/List.aspx" target="_self">���ַ�</a></li> 
<li id="footnav_bbs"><a href="/index.html" target="_self">װ��</a></li> 
</ul>
</nav>
    <div class="footer">
        <div class="footer_link">
            <a href="#" class="agray">��׼��</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">������</a>&nbsp;&nbsp;<a href="http://xx.yyfdcw.com" class="agray">���԰�</a></div>
        <div class="f12 fgray" align="center">
            Copyright &copy; 2014 �������ز���<br />
            m.yyfdcw.com ��ICP��13012493��</div>
    </div>
</body>
</html>
