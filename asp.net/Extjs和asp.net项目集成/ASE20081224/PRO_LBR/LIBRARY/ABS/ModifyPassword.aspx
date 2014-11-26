<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="ModifyPassword.aspx.cs" Inherits="ModifyPassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
//验证密码长度
</script>
<script type="text/javascript" src="../js/show_hide.js"></script>


<div id="login">
<div style="padding: 0 70px;">
<div class="xiugai">
<p class="p-font">密码修改</p>
<div id="description1" style="display:none;">对不起,该用户不存</div>
<div>
<table cellpadding="0" cellspacing="0" border="0" width="316">
<tr>
<td align=right width="32%" style="height: 19px">用户编号：</td>
<td align=left style="height: 19px; width: 254px;"><% =userId%></td>
</tr>
<tr>
<td colspan="2"><img src="img_all/space.gif" width="1" height="10" /></td>
</tr>
<tr>
<td align=right width="32%" style="height: 43px">请输入旧密码：</td>
<td align=left style="height: 43px; width: 254px;"><input size=22 class="text1" type="password"  name=userName id="oldPwd" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldPwd"
        Display="Dynamic" ErrorMessage="请输入旧密码!">*</asp:RequiredFieldValidator></td>
</tr>
<tr>
<td colspan="2" style="height: 10px"><img src="img_all/space.gif" width="1" height="10" /></td>
</tr>
<tr>
<td align=right style="height: 36px">请输入新密码：</td>
<td align=left style="height: 36px; width: 254px;"><input size=24 class="text1"  name=userName type="password"  id="newPwd1" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入新密码!" ControlToValidate="newPwd1">*</asp:RequiredFieldValidator></td>
</tr>
<tr>
<td colspan="2" style="height: 10px"><img src="img_all/space.gif" width="1" height="10" /></td>
</tr>
<tr>
<td align=right style="height: 42px">请确认新密码：</td>
<td align=left style="width: 254px; height: 42px;"><input size=24 class="text1" type="password"   name=userName id="newPwd2" runat="server" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入确认密码!" ControlToValidate="newPwd2">*</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="newPwd1"
        ControlToValidate="newPwd2" Display="Dynamic" ErrorMessage="两次输入的密码不一致!">*</asp:CompareValidator></td>
</tr>
<tr>
<td colspan="2"><img src="img_all/space.gif" width="1" height="10" /></td>
</tr>

<tr>
<td align=right>验证码：</td>
<td align=left style="width: 254px"><input size=11 class="text1"  name=userName id="txtCode" runat="server" /><img src="Form/CodeForm.aspx" width="54" height="19" />  <asp:RequiredFieldValidator ID="rfvCode" runat="server" ErrorMessage="请输入验证码!" ControlToValidate="txtCode">*</asp:RequiredFieldValidator></td>
</tr>
<tr>
<td colspan="2"><img src="img_all/space.gif" width="1" height="10" /></td>
</tr>

<tr>
<td>&nbsp;</td>
<td align=left style="width: 254px"><a href="#">忘记了密码？</a></td>
</tr>
</table>
</div>

<div style="text-align:center; padding: 10px 0; width: 316px;">
<a href="javascript:;" onclick="javascript:showElement('description1')"><input class=button4 type=submit value=" 修 改 " name=Submit id="Submit1" language="javascript"  onserverclick="Submit1_ServerClick" runat="server" /></a>&nbsp;&nbsp;<input class=button4 type=reset value=" 重 置 "  id="Reset1" language="javascript" onserverclick="Submit2_ServerClick" runat="server" /><br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <br />
</div>

</div>
</div>
</div>
</asp:Content>

