<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tsInput.aspx.cs" Inherits="XxWapSystem.zx_ts.tsInput" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta content="telephone=no" name="format-detection" />
    <meta content="width=device-width; initial-scale=1.0; maximum-scale=1.0; minimum-scale=1.0; user-scalable=false;"
        name="viewport" />
    <meta name="apple-mobile-web-app-capable" content="no" />
    <title>��дͶ�߱�</title>
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
    <h2>��дͶ�߱�</h2>
  </header>
        <div id="EntPage">
        </div>
        <form id="form1" runat="server">
        <div class="fullscreen">
            <div class="login">
                <div style="text-align: center;">
                    <asp:TextBox class="inputBox" ID="txtName" name="UserName" placeholder="Ͷ��������" runat="server" /></asp:TextBox>
                    <asp:TextBox class="inputBox" ID="txttel" placeholder="��ϵ�绰" runat="server"></asp:TextBox>
                    <asp:TextBox class="inputBox" ID="txtqyname" placeholder="Ͷ�߶���" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtcontent" class="inputBox" TextMode="MultiLine" Height="260px"
                        placeholder="Ͷ������" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnSub" runat="server" class="loginLine cplogin_button" OnClick="btnSub_click"
                    Style="text-align: center; font-size: 20px; vertical-align: middle" Text="��д��ϣ���˰�ť�ύ��Ϣ" />
                    
                <asp:Button ID="Button1" runat="server" class="loginLine cpregister_button" OnClick="btnrtn_click"
                    Style="text-align: center; font-size: 20px; vertical-align: middle" Text="����" />
            </div>
        </div>
        <div class="footer1">
            <a href="#" class="agray">��׼��</a>&nbsp;&nbsp;<a href="javascript:void(0)" class="agray"
                style="color: #507FBD;">������</a>&nbsp;&nbsp;<a href="http://xx.yyfdcw.com" class="agray">���԰�</a></div>
        Copyright &copy; 2014 �������ز���
    </div>
    </form>
</body>
</html>
