<%@ Page Language="C#" MasterPageFile="~/MPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="MyOrder.aspx.cs" Inherits="MyOrder" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



 <div style="padding: 0 60px; margin-top: 10px;" class="clearfix">
   <DIV class=mainTableP2>
<div class="divLeft">
                <table cellspacing="0" cellpadding="0" width="99%" border="0">
                    <tbody>
                        <tr>
                            <td class="leftTitle25" style="border-bottom: #cccccc 1px solid;">
                                <a href="wreg.aspx">会员注册</a></td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" width="99%" border="0">
                    <tbody>
                        <tr>
                            <td class="leftTitle25" style="border-bottom: #cccccc 1px solid;">
                                <a href="wlogin.aspx">会员登陆</a></td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" width="99%" border="0">
                    <tbody>
                        <tr>
                            <td class="leftTitle25">
                                <a href="Activity.aspx?frm_id=60">限时抢购</a></td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" width="99%" border="0">
                    <tbody>
                        <tr>
                            <td class="leftTitle22">
                                <a href="#">我的爱彼此</a></td>
                        </tr>
                    </tbody>
                </table>
                <ul class="leftUl">
                    <li class="liLeft" onclick="window.location.href='ModifyUser.aspx'">基本信息</li>
                    <li class="liLeft" onclick="window.location.href='MyReceive.aspx'">收货信息</li>
                    <li class="liLeft" onclick="window.location.href='MyOrder.aspx'">订单查询</li>
                    <li class="liLeft" onclick="window.location.href='PointsExchange.aspx'">我的积分</li>
                    <li class="liLeft" onclick="window.location.href='LeaveMessage.aspx'">我的留言</li>
                </ul>
            </div>
<DIV class="divRight newsDetail2">
<DIV style="OVERFLOW: hidden; WIDTH: 570px; HEIGHT: auto">
        <div>
<TABLE height=38 cellSpacing=1 cellPadding=2 align=center border=0>
  <TBODY>
  <TR>
    
    <TD>搜索：</TD>
    <TD>
        &nbsp;<asp:TextBox ID="txtBegin" CssClass="text1" onclick="if (this.value == '开始时间') this.value = '';" 
     onmouseover="if(this.value=='')this.value='开始时间'" Text="开始时间" runat="server" Width="110px"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBegin">
        </cc1:CalendarExtender>
    </TD>
    <TD>&nbsp;至&nbsp;</TD>
    <TD>
        &nbsp;
        <asp:TextBox ID="txtEnd"  CssClass="text1"  Width="110px" onmouseover="if(this.value=='')this.value='结束时间'"  onclick="if (this.value == '结束时间') this.value = '';"  value="结束时间" runat="server"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEnd">
        </cc1:CalendarExtender>
    </TD>
	  <TD>&nbsp;<INPUT class=text1 onmouseover="if(this.value=='')this.value='订单号'" 
      onclick="if (this.value == '订单号') this.value = '';" size=17 
      value=订单号 name=ordernumber id="txtOrderCode" runat="server">&nbsp;</TD>
    <TD style="width: 5px">
        <asp:DropDownList ID="ddlOrderStatus" runat="server" DataSourceID="SqlDataSource1" DataTextField="PUS_DESC" DataValueField="PUS_ID" OnDataBound="ddlOrderStatus_DataBound">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
            SelectCommand="SELECT PUS_ID, PUS_DESC FROM RPURCHASESTATUS"></asp:SqlDataSource>
        <asp:HiddenField ID="hddUserId" runat="server" />
    </TD>
    
    <TD>
       <asp:UpdatePanel id="UpdatePanel3" runat="server">
        <contenttemplate>
        <asp:ImageButton ID="imgQuery" ImageUrl="~/img_all/go.gif" runat="server" OnClick="imgQuery_Click" />
       </contenttemplate>
       </asp:UpdatePanel>
      </TD></TR>
      </TBODY>
 </TABLE>

    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
    <asp:Repeater ID="rptOrderList" runat="server" OnItemCommand="rptOrderList_ItemCommand">
    <HeaderTemplate>
    <TABLE cellSpacing=1 cellPadding=1 bgcolor=#cccccc width="570px" align=center border=0>
      <TR>
        <TD align=center bgColor=#f0f0f0><STRONG>订单号</STRONG></TD>
        <TD align=center bgColor=#f0f0f0><STRONG>下单时间</STRONG></TD>
        <TD align=center bgColor=#f0f0f0><STRONG>订单金额</STRONG></TD>
        <TD align=center bgColor=#f0f0f0><STRONG>状态</STRONG></TD>
        <TD align=center bgColor=#f0f0f0><STRONG>付款方式</STRONG></TD>
      </TR>
    </HeaderTemplate>
    <ItemTemplate>
    <TR bgcolor=#ffffff>
        <TD class=listC vAlign=top align=center><a href="order.aspx?PUR_ID=<%# Eval("PUR_ID") %>"><%#Eval("PUR_CODE") %></a></TD>
        <TD class=listC align=center><%#Eval("PUR_DT") %></TD>
         <TD class=listC align=center><%#Eval("PUR_AMOUNT") %></TD>
        <TD class=listC align=center><%#Eval("PUS_DESC") %></TD>
        <TD class=listC align=center><%#Eval("PAY_DESC") %></TD>
        </TR>
    </ItemTemplate>
    <FooterTemplate>
   </TABLE>
    <center>
        <br />
        当前第 <span style="color:Red;"><%=ViewState["pageNo"] %></span> 页  共 <span style="color:Red;"><%=totalPages %></span> 页&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkBtnFirst" CommandName="first" runat="server">第一页</asp:LinkButton>
        <asp:LinkButton ID="lnkBtnPrevious" CommandName="previous" runat="server">上一页</asp:LinkButton>
        <asp:LinkButton ID="lnkBtnNext" CommandName="next" runat="server">下一页</asp:LinkButton>
        <asp:LinkButton ID="lnkBtnLast" CommandName="last" runat="server">最后一页</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;共 <span style="color:Red;"><%=totalData %></span> 条

    </center>
    </FooterTemplate>
    </asp:Repeater></contenttemplate>
    </asp:UpdatePanel>
            

		</div>
		<div></div>
		<div style="text-align:center; margin-top: 10px;">
		 <asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
		<input class="button4" type="button" value=" 查 询 " id="btnQuery" onserverclick="btnQuery_ServerClick" runat="server" onserverchange="btnQuery_ServerChange" />
		</contenttemplate>
    </asp:UpdatePanel>
		</div>
</DIV>
</DIV>
<DIV style="CLEAR: both; DISPLAY: block; FONT: 0px Sans-Serif"></DIV></DIV> 
    
  </div>
</asp:Content>

