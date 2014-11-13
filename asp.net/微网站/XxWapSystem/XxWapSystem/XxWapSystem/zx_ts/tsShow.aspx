<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tsShow.aspx.cs" Inherits="XxWapSystem.zx_ts.tsShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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

    <script src="../js/jquery.js?version=1.0"></script>

    <script src="../js/common.js?version=1.0"></script>

    <link rel="stylesheet" type="text/css" href="../css/v2.css" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <link rel="stylesheet" type="text/css" href="../css/base.css" />
    <link rel="stylesheet" type="text/css" href="../css/city/nj.css" />

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

    <!--ͷ��LOGO-->
    <header class="m_wrap">
<section id="topbar" class="topnav_tool">
<button class="top_btn" id="btn_back">����</button>
<h1><%=ctitle %></h1>
</section>
 
</header>
    <!--������Ϣ-->
    <div class="detail_info clear">
        <div class="info_title">
            Ͷ�߱��⣺<%=ctitle %></div>
        <div class="info_li">
            <span class="info_attr">Ͷ��������</span><span class="info_val" id="info_price"><%=cname %></span></div>
        <div class="info_li">
            <span class="info_attr">Ͷ�߶���</span><span class="info_val"><%=cqyname%></span></div>
        <div class="info_li">
            <span class="info_attr">Ͷ��ʱ�䣺</span><span class="info_val"><%=daddtime %></span></div>
        <div class="info_h2">
            <span class="info_h2_title">Ͷ�����ݣ�</span></div>
        <div class="info_box">
            <p>
                <%=ccontent.Replace("\n", " <br/>").Replace(" ", "&nbsp;")%>
            </p>
        </div>
        <div class="info_h2">
            <span class="info_h2_title">�������� </span>
        </div>
        <div class="info_box">
            <%=cfruit.Replace("\n", " <br/>").Replace(" ", "&nbsp;")%>
        </div>
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
