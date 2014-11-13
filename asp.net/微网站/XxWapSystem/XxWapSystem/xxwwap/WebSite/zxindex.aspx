<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zxindex.aspx.cs" Inherits="XxWapSystem.zxindex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no"
        name="viewport" />
    <meta name="apple-mobile-web-app-capable" content="no" />
    <title>�������ز�װ����</title>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="keywords" content="�������ز�װ����,����װ��,����װ�޹�˾,��������,�����Ҿ�,���ʦ,װ����Ʒ,װ���ռ�,�����Ź�" />
    <meta name="description" content="�������ز�װ��������������Ψһһ��ר�Ŵ���װ����Ϣ���������ý�塣Ϊ���ṩ���µ���ҵ��̬�ʹ�����Ϣ����ȫ��װ�޽��ġ���Ȩ������ҵ���º����õ������������ز�װ����������Ϊ����װ����ҵ��Ȩ���Ĺ���ý�塣" />
    <meta name="apple-mobile-web-app-title" content="�������ز�װ����">
    <meta name="viewport" content="width=device-width" />
    <link href="css//style3860.css?v=1" rel="stylesheet">
    <link href="css//menu3860.css?v=1" rel="stylesheet">

    <script src="js/jquery-1.5.2.min.js"></script>
    <script src="js/index3860.js?v=1"></script>
    <script src="js/base.min3860.js?v=1"></script>
    <script src="js/common.js?version=1.0"></script>

    <link rel="stylesheet" type="text/css" href="css/v2.css" />
    <style type="text/css">
        .ytopnav_tool
        {
            background-image: url(images/ytop_nav.png);
            background-repeat: repeat-x;
        }
        class*='top_btn']
        {
            background-image: url(images/top_btn_bg.png);
            background-repeat: repeat-x;
            width: 80px;
            color: #fff;
            line-height: 40px;
            float: left;
            position: absolute;
        }
        .ytop_btn
        {
            background-image: url(images/ytop_btn_bg.png);
            background-repeat: repeat-x;
            width: 80px;
            color: #fff;
            line-height: 40px;
            float: left;
            position: absolute;
        }
        .top_btn_fav_news
        {
            background-image: url(images/ytop_btn_bg.png);
            background-repeat: repeat-x;
            width: 80px;
            color: #fff;
            line-height: 40px;
            float: right;
            position: absolute;
        }
    </style>
</head>
<body>
    <header class="m_wrap">
<section id="topbar" class="ytopnav_tool">
<button class="ytop_btn" id="btn_back">����</button>
<button class="top_btn_fav_news" onClick="gohome()">����ҳ</button>
<h1>�������ز�װ����</h1>
</section>

</header>
    <div class="content">
        <div class="banner">
            <img src='images/sy_001.jpg' />
        </div>
        <nav class="nav_btn_group" style="max-height: 120px;">
<UL>
  <LI id="nav_btn_news"><A href="/jc_go/jcgoList.aspx" 
  target="_self"><I class="nav_icon_news"></I>����</A></LI>
  <LI id="nav_btn_newhouse"><A href="/zx_xyda/xydaList.aspx" target="_self"><I 
  class="nav_icon_newhouse"></I>����</A></LI>
  <LI id="nav_btn_sellhouse"><A href="/zx_ts/tsList.aspx" 
  target="_self"><I class="nav_icon_sellhouse"></I>Ͷ��</A></LI> 
  <LI id="nav_btn_decoration"><A href="/news/ZxNews.aspx" 
  target="_self"><I class="nav_icon_decoration"></I>��Ѷ</A></LI></UL></nav>
        <!--װ����Ѷ-->
        <div id="bbs_wrap">
            <h2 class="h2_v2">
                <span class="title_news"><a href="/zx/">װ����Ѷ</a></span></h2>
            <div class="cnews_list">
                <ul>
                    <%=DecorateHtml %>
                </ul>
            </div>
        </div>
        <div class="footer">
            <footer>

		<div class="footer_bottom">
		  <div class="gotop" id="gotop" style="display:none;"><a href="javascript:scroll(0,0)"><img src="images/top.png" style="width:100%" /></a></div>
          <div class="links">
          <span>������</span>
          <span>-</span>
          <a href="http://zx.yyfdcw.com">���԰�</a>
          </div>
		</div>
		<p class="copyRight">
          <span>�������ز�װ������Ȩ����&copy;2014</span>
		</p>
	</footer>
        </div>

        <script>
            $(function() {
                //�����������¹���ʱ��ʾTOP
                if ($("#gotop")) {
                    $(window).scroll(function() {
                        if ($(window).scrollTop() > 0) {
                            $("#gotop").fadeIn(100);
                        }
                        else {
                            $("#gotop").fadeOut(100);
                        }
                    });
                }
            });
        </script>

    </div>
</body>
</html>
