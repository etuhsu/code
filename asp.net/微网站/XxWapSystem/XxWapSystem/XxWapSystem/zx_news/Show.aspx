<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="XxWapSystem.zx_news.Show" %>

<!DOCTYPE HTML>
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
        <a id="btn_app_down" href="#" target="_blank">
        </a><span class="downtxt fr" id="closetip">�ر�</span>
    </div>
    <div class="app-open-bar" id="app-open-bar" style="display: none;">
        <span class="open_close" id="app_open_close"></span><span class="open_icon"></span>
        <span class="open_alt">���������ʡ����</span> <span class="opentxt fr" id="openapp">������</span>
    </div>
    <!--ͷ��LOGO-->
<header class="m_wrap">
<section id="topbar" class="ytopnav_tool">
<button class="ytop_btn" id="Button1">����</button>
<button class="top_btn_fav_news" onClick="gohome()">����ҳ</button>
<H1><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></H1>
</section>
</header>    

    <div class="news-wrap">
        <h1 class="news-title">
            <asp:Label ID="lblTitle2" runat="server" Text=""></asp:Label></h1>
        <h4 class="news-time">
            ���ڣ�<asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
            ��Դ:�������ز���
        </h4>
        <!--����ͼ-->
        <asp:Label ID="lblPic" runat="server" Text="Label"></asp:Label>
        <!--������Ϣ-->
        <div class="info_box" id="info_box_project_info">
            <div class="news-content">
                <style type="text/css">
                    p
                    {
                        color: #2C2C2C;
                        text-indent: 2em;
                        font-size: 17px;
                        line-height: 170%;
                        padding: 0;
                        marin: 7px 0;
                        text-align: justify;
                    }
                    img
                    {
                        margin: 0 auto;
                        display: block;
                    }
                </style>
                <asp:Label ID="labcontent" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="info_box" id="info_box_project_intro">
            </div>
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
<UL>
  <LI id="footernav_newhouse"><A href="http://m.house365.com/nj/newhouse/" 
  target="_self">�·�</A></LI>
  <LI id="footernav_sellhouse"><A href="http://m.house365.com/nj/sellhouse/" 
  target="_self">���ַ�</A></LI>
  <LI id="footernav_renthouse"><A href="http://m.house365.com/nj/renthouse/" 
  target="_self">�ⷿ</A></LI>
  <!--<li><a href="#">�Ҿ�</a></li>--> 
  <LI id="footernav_news"><A href="http://m.house365.com/nj/news/">��Ѷ</A></LI>
  <LI id="footnav_bbs"><A href="http://m.house365.com/nj/bbs/" 
  target="_self">����</A></LI>
</UL></nav>
    <div class="footer">
        <div class="footer_link">
            <a href="#" class="agray">��׼��</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">������</a>&nbsp;&nbsp;<a href="http://xx.yyfdcw.com" class="agray">���԰�</a></div>
        <div class="f12 fgray" align="center">
            Copyright &copy; 2014 �������ز���<br />
            m.yyfdcw.com ��ICP��13012493��</div>
    </div>
    <div class="btn_gotop" id="btn_gotop" style="display: none">
    </div>
</body>
</html>
