<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="SendMessage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="padding: 0 60px; margin-top: 10px;">
    <div class=path><a href="Index.aspx">首页</a> &gt;&gt; 推荐给好友</div>
    <div style="margin-top: 10px; padding-top: 5px; border-top: 1px solid #c9c9c9;" class="clearfix">
		<div style="width: 160px; float: left;  margin-top: 5px;  border-right: 1px solid #c9c9c9;">
		<div id="divPic" runat="server" style="padding: 20px;">&nbsp;<img style="border: 1px solid #000000" src="img_dongtai/page03_04.jpg" width="120" height="120" id="imgProduct" runat="server" /></div>
		<div style="text-align: center; font-weight: bold;">
            <asp:Literal ID="ltrProductName" runat="server"></asp:Literal></div>
		</div>
		<div style="float: left; padding: 20px;  margin-top: 5px; width: 550px; ">
		<div class=listProT1>收件人：</div>
		<div style="margin: 10px 0">
      <TABLE cellSpacing=0 cellPadding=3 width="100%" border=0>
        <TBODY>
        <TR>
          <TD align=right width="15%" style="height: 49px">称呼：</TD>
          <TD align=left width="35%" style="height: 49px"><INPUT class=text1 size=18 name=addressee id="txtCall" runat="server"> 
              <asp:RequiredFieldValidator ID="rfvCall" runat="server" ControlToValidate="txtEmail"
                  ErrorMessage="请填写好友的称呼!">*</asp:RequiredFieldValidator></TD>
          <TD align=right width="15%" style="height: 49px">Email:</TD>
          <TD align=left width="35%" style="height: 49px"><INPUT class=text1 name=email id="txtEmail" runat="server"> 
              <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                  ErrorMessage="请填写好友的Email地址！">*</asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                  ErrorMessage="请正确填写的好友的Email地址！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></TD></TR></TBODY></TABLE></div>
      <div class=listProT1>发件人：</div>
	  <div style="margin: 10px 0">
      <TABLE cellSpacing=0 cellPadding=3 width="100%" border=0>
        <TBODY>
        <TR>
            <TD align=right width="15%">我的名字：</TD>
          <TD align=left><INPUT class=text1 size=18 name=sender id="txtMyName" runat="server">
              <asp:RequiredFieldValidator ID="rfvMyName" runat="server" ControlToValidate="txtMyName"
                  ErrorMessage="请填写自己的名字!">*</asp:RequiredFieldValidator></TD></TR></TBODY></TABLE>
		</div>
		<div style="text-align: center;">
            &nbsp;<INPUT class=button4 type=submit value=" 发 送 " name=submit id="btnSend" onserverclick="btnSend_ServerClick" runat="server">&nbsp;&nbsp;&nbsp; 
<INPUT class=button4 type=reset value=" 重 置 ">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
        </div>
		</div>
	</div>
  </div>
</asp:Content>

