<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="MyDefault.aspx.cs" Inherits="MyDefault" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<DIV class=divLeft>
<TABLE cellSpacing=0 cellPadding=0 width="99%" border=0>
  <TBODY>
  <TR>
    <TD class=leftTitle21>爱彼此俱乐部</TD></TR></TBODY></TABLE>
<UL class=leftUl>
  <LI class=liLeftHot ><a href="ModifyUser.aspx">基本信息</a></LI>
  <LI class=liLeft><a href="MyReceive.aspx">收货信息</a></LI>
  <LI class=liLeft><a href="MyOrder.aspx">订单查询</a></LI>
</UL>
</DIV>
<DIV class="divRight newsDetail2">
<DIV style="OVERFLOW: hidden; WIDTH: 575px; HEIGHT: auto">
<P><STRONG class=fontTT><%=strTitle %> </STRONG><A id=a name=a></A><BR><BR><%=strContent %></P>
</DIV>
</DIV>
</asp:Content>

