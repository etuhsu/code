<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>系统后台登录</title>
<link rel="stylesheet" type="text/css" href="css/login.css" />
<style type="text/css">
.font {
	color: #1682b0;
	font-family: "新宋体";
	font-size: 15px;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
<div id="main_body">
<div><img src="img/header.jpg" width="960" height="70" /></div>
<div id="main_table">
  <div style="text-align:center;">
	<table cellpadding="0" cellspacing="0" border="0">
		<tr>
			<td><img src="img/board_top.jpg" width="443" height="114" /></td>
		</tr>
		<tr>
			<td background="img/bg_board.jpg">
				<table cellpadding="0" cellspacing="0" border="0">
					<tr>
						<td colspan="5"><img src="img/spacer.gif" width="1" height="10" /></td>
					</tr>
					<tr>
						<td><img src="img/spacer.gif" width="60" height="1" /></td>
						<td valign="top" width="331">
							<table cellpadding="0" cellspacing="0" border="0">
								<tr>
									<td width="85" class="font"><strong>登录用户：</strong></td>
									<td align="left">
                                        <asp:TextBox ID="txtUserName" Width="140px" class="text1"  runat="server"></asp:TextBox></td>
								</tr>
								<tr>
									<td colspan="2"><img src="img/spacer.gif" width="1" height="15" /></td>
								</tr>
								<tr>
									<td class="font"><strong>登录密码：</strong></td>
									<td align="left"><asp:TextBox ID="txtPwd"  Width="140px" class="text1"  runat="server" TextMode="Password"></asp:TextBox></td>
								</tr>
								<tr>
									<td colspan="2"><img src="img/spacer.gif" width="1" height="15" /></td>
								</tr>
								<tr>
									<td class="font"><strong>验证码：</strong></td>
								  <td valign="middle" align="left"><asp:TextBox ID="txtCode" type="text" Width="60px" class="text1"  runat="server"></asp:TextBox>&nbsp;&nbsp;<img src="Form/CodeForm.aspx" width="60" height="20" style="vertical-align:bottom;"/></td>
								</tr>
								<tr>
									<td colspan="2"><img src="img/spacer.gif" width="1" height="18" /></td>
								</tr>
								<tr>
									<td colspan="2">
										<table cellpadding="0" cellspacing="0" border="0">
											<tr>
												<td style="height: 27px"><img src="img/spacer.gif" width="18" height="1" /></td>
												<td style="height: 27px"> 
                                                    <asp:ImageButton ID="imgBtnLogin" ImageUrl="img/login.jpg" width="81" height="27" border="0" runat="server" OnClick="imgBtnLogin_Click" /></td>
												<td style="height: 27px"><img src="img/spacer.gif" width="18" height="1" /></td>
												<td style="height: 27px"><asp:ImageButton ID="imgBtnReset" ImageUrl="img/reset.jpg" width="81" height="27" border="0" runat="server" OnClick="imgBtnReset_Click" /></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
						<td><img src="img/eg.gif" width="2" height="181" /></td>
						<td style="width: 51px"><img src="img/spacer.gif" width="50" height="1" /></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td><img src="img/board_bottom.jpg" width="443" height="10" /></td>
		</tr>
	</table>
  </div>
</div>
</div>
    </form>
</body>
</html>
