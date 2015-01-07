<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="wlogin.aspx.cs" Inherits="wlogin" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
//验证密码长度
function ValidatePwd(source,args)
{
    if(document.getElementById("ctl00_ContentPlaceHolder1_txtPwd").value.length<6)
    {
        args.IsValid=false;
    }
    else
    {
        args.IsValid=true;
    }
}
</script>
<script type="text/javascript" src="../js/show_hide.js"></script>
<div id="login" class="clearfix">
<div class="box">
<div><img src="img/border_top_login.gif" width="320" height="25" /></div>
<div class="border_color" style="height: 230px;">
<p>
    已注册用户请从这里登录</p>
<div id="description1" style="display:none;">对不起,该用户不存</div>
<div>
<table cellpadding="0" cellspacing="10" border="0" width="316">
<tr>
<td class="font14b" align=right width="32%">用户名</td>
<td align=left width="60%"><input size=22 class="text1"  name=userName id="txtUser" runat="server" />
    <asp:RequiredFieldValidator ID="rfvUser" runat="server" ErrorMessage="请输入用户名!" ControlToValidate="txtUser">*</asp:RequiredFieldValidator></td>
</tr>
<tr>
<td class=font14b align=right>密　码</td>
<td align=left><input size=24 class="text1" type="password" id="txtPwd" runat="server" />
    <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ErrorMessage="请输入密码!" ControlToValidate="txtPwd">*</asp:RequiredFieldValidator><asp:CustomValidator
        ID="ctvPwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="密码长度应该不少于６个字符！" ClientValidationFunction="ValidatePwd">*</asp:CustomValidator></td>
</tr>
<tr>
<td class=font14b align=right>验证码</td>
<td align=left><input size=11 class="text1"  name=userName id="txtCode" runat="server" />
    <img src="Form/CodeForm.aspx" width="54" height="19" />
    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ErrorMessage="请输入验证码!" ControlToValidate="txtCode">*</asp:RequiredFieldValidator></td>
</tr>
<tr>
<td>&nbsp;</td>
<td align=left><a href="#">忘记了密码？</a><asp:ValidationSummary ID="ValidationSummary1" runat="server"
        ShowMessageBox="True" ShowSummary="False" />
</td>
</tr>
</table>
</div>

<div style="text-align:center; padding: 10px 0;">
    <asp:Button ID="imgBtnWLogin" runat="server" Text="会员登陆" OnClick="imgBtnWLogin_Click" CssClass="button4"/>
    &nbsp;&nbsp;</div>


</div>
<div><img src="img/border_bottom.gif" width="320" height="16" /></div>
</div>

<div class="box" style="margin-left: 50px;">
<div><img src="img/border_top_newuser.gif" width="320" height="25" /></div>
<div class="border_color" style="height: 230px;">
<p>新用户注册</p>

<div><table cellspacing="10" cellpadding="10" width="280" 
border="0" align="center">
                          <tbody>
                          <tr>
                            <td class=important align=left 
                            colspan="4"><table cellspacing="1" cellpadding="5" width="90%" border="0">
                              <tbody>
                                <tr valign="top">
                                  <td align="left" colspan="2">注册成为ABS会员，您将享有以下服务：</td>
                                </tr>
                              </tbody>
                            </table></td></tr>
                          
                          <tr>
                            <td align=right width="7%"><img src="img/dui.gif" width="12" height="16" /></td>
                            <td class="font12" align="left" width="93%" 
                              colspan="3">ABS积分兑换</td>
                          </tr>
						
                          <tr>
                            <td align=right><img src="img/dui.gif" width="12" height="16" /></td>
                            <td class=font12 align=left>ABS俱乐部</td>
                          </tr>
                          <tr>
                            <td align=right><img src="img/dui.gif" width="12" height="16" /></td>
                            <td class=font12 align=left>ABS收藏夹</td>
                          </tr>
                          
        </tbody></table></div>

<div style="text-align:center; padding: 10px 0;">
<a href="#" onclick="javascript:window.location.href='wreg.aspx'"><input class="button2"  value=" 新用户注册 " name="Submit" /></a>
</div>


</div>
<div><img src="img/border_bottom.gif" width="320" height="16" /></div>
</div>
</div>
<div id="tit_bottom"></div>
</asp:Content>