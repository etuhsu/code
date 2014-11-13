<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="XxWapSystem.jc_go.Images" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="keywords" content="<%=ProjectName %>效果图,<%=ProjectName %>户型图,<%=ProjectName %>实景图,<%=ProjectName %>位置图,<%=ProjectName %>测绘图,岳阳房地产网" />
    <meta name="description" content="<%=ProjectName %>效果图,<%=ProjectName %>户型图,<%=ProjectName %>实景图,<%=ProjectName %>位置图,<%=ProjectName %>测绘图,岳阳房地产网" />
    <title>
        <%=ProjectName %>效果图_户型图_实景图_位置图_测绘图-岳阳房地产网</title>
    <meta name="apple-mobile-web-app-title" content="岳阳房地产网">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link rel="stylesheet" type="text/css" href="../css/base.css">
    <link rel="stylesheet" type="text/css" href="../css/gallery.css">

    <script src="../js/jquery.js?version=1.0"></script>

    <script type="text/javascript" src="../js/klass.min.js"></script>

    <script type="text/javascript" src="../js/photoswipe.min.js"></script>

    <script type="text/javascript" src="../js/iscroll.js"></script>

</head>
<body>
    <ul id="Gallery" class="gallery" style="display: none">
        <%=ImageMsgReturn %>
    </ul>
    <header class="m_wrap">
<section id="topbar" class="topnav_tool">
<button class="top_btn" id="btn_back">返回</button>
<h1><span id="curnumber">1</span>/<%=ImageCounts%></h1>
</section>
 
</header>
    <div class="album_tag">
        <div class="albnav rbox6 f16">
            
            <div class="clear">
            </div>
        </div>

        <script type="text/javascript" src="../js/house_gallery.js"></script>

        <script>
            $("#btn_back").click(function() {
                window.history.go(-1);
            });
        </script>
</body>
</html>
