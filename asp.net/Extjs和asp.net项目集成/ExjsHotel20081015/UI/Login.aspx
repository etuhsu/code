<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>酒店管理系统--登 陆</title>
     <link href="CSS/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/Login.js"></script>
</head>
<body style=" text-align:center">
   <form action="" runat="server">
    <div style="text-align: center; background-image:url(Images/Login.gif);width:435px;height:283px;position: relative; top: 143px">
        <div style="left: 30px; width: 328px; position: relative; top: 133px; height: 134px">
            <div style="width: 322px; height: 25px; text-align: left">
                <span style="font-size: 10pt"> <span>帐 &nbsp;号：</span></span><input
                    id="TxtName" style="width: 190px" type="text" /></div>
            <div style="width: 322px; height: 25px; text-align: left">
                <span style="font-size: 10pt"><span>密 &nbsp;码：</span></span><input
                    id="TxtPwd" style="width: 190px" type="text" /></div>
            <div style="width: 322px; height: 25px; text-align: left">
                <span style="font-size: 11pt"> <span style="font-size: 10pt">验证码：</span></span><input id="TxtCode"
                    style="width: 71px; height: 15px;" type="text" />&nbsp;<asp:Image ID="Image1" runat="server"
                        Height="20px" ImageUrl="~/URL/Image.aspx" Style="left: 0px; position: relative; top: 3px"
                        Width="57px" />
                <input id="Eyes" style="width: 44px; height: 21px" type="button" onclick="ReBtn();" value="看不清" class="btn" /></div>
            <div style="width: 320px; height: 35px">
            </div>
            <div style="width: 320px; height: 33px; text-align: left;">
                &nbsp; 
                <input id="Login" type="button" value="登  陆"  onclick=" ValidateCode();" style="width: 75px" class="btn"/>
                &nbsp; &nbsp;&nbsp; &nbsp; 
                <input id="Reset" style="width: 75px" type="reset" value="重  置" class="btn" /></div>
        </div>
        
    </div>
   </form>
</body>
</html>
