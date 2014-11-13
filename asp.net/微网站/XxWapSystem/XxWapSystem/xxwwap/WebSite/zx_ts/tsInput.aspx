<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tsInput.aspx.cs" Inherits="XxWapSystem.zx_ts.tsInput" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="width=device-width; initial-scale=1.0; maximum-scale=1.0; minimum-scale=1.0; user-scalable=false;"
        name="viewport" />
    <meta name="apple-mobile-web-app-capable" content="no" />
    <title>填写投诉表单</title>
    <script src="../js/jquery.js?version=1.0"></script>
    <script src="../js/common.js"></script>
    
    <link rel="stylesheet" href="../css/Login.css">
    <link href="/Content/personal/Style/style.css" rel="stylesheet" />

    <script src="/Content/Company/Script/login.js"></script>

    <script src="/Content/Company/Script/validedata.js"></script>

    <script src="/Content/Company/Script/base.js"></script>

    <script src="/Content/Company/Script/pop.js"></script>

</head>
<body>
    <iframe scr="/Content/company/cache/cache.html" style="display: none"></iframe>
    <div class="content">
        <header>
    <h2>填写投诉表单</h2>
  </header>
        <div id="EntPage">
        </div>
        <form id="form1" runat="server">
        <div class="fullscreen">
            <div class="login">
                <div style="text-align: center;">
                    <asp:TextBox class="inputBox" ID="txtName" name="UserName" placeholder="投诉人姓名" runat="server" /></asp:TextBox>
                    <asp:TextBox class="inputBox" ID="txttel" placeholder="联系电话" runat="server"></asp:TextBox>
                    <asp:TextBox class="inputBox" ID="txtqyname" placeholder="投诉对象" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtcontent" class="inputBox" TextMode="MultiLine" Height="260px"
                        placeholder="投诉内容" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnSub" runat="server" class="loginLine cplogin_button" OnClick="btnSub_click"
                    Style="text-align: center; font-size: 20px; vertical-align: middle" Text="填写完毕，点此按钮提交信息" />
                    
                <asp:Button ID="Button1" runat="server" class="loginLine cpregister_button" OnClick="btnrtn_click"
                    Style="text-align: center; font-size: 20px; vertical-align: middle" Text="返回" />
            </div>
        </div>
        <div class="footer1">
            <a href="#" class="agray">标准版</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">触屏版</a>&nbsp;&nbsp;<a href="http://xx.yyfdcw.com" class="agray">电脑版</a></div>
        Copyright &copy; 2014 岳阳房地产网
    </div>
    </form>
</body>
</html>
