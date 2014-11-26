<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="LeaveMessage.aspx.cs" Inherits="LeaveMessage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="padding: 0 45px; margin-top: 10px;" class="clearfix">
            <div class="mainTableP2">
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
                    <li class="liLeft" onclick="window.location.href='ModifyUser.aspx'">基本信息</li><li class="liLeft" onclick="window.location.href='MyReceive.aspx'">收货信息</li><li class="liLeft" onclick="window.location.href='MyOrder.aspx'">订单查询</li><li class="liLeft" onclick="window.location.href='PointsExchange.aspx'">我的积分</li><li class="liLeft" onclick="window.location.href='#'">我的留言</li></ul>
            </div>
                <div class="divRight newsDetail2">
                    <div style="overflow: hidden; width: 570px; height: auto">
                    <div style="text-align:right;">
                        <asp:LinkButton ID="lnkBtnLeaveMessage" runat="server" OnClick="lnkBtnLeaveMessage_Click">我要留言>></asp:LinkButton>
                    </div>
                        <asp:Repeater ID="rptMessages" runat="server" DataSourceID="sdsMessages">
                            <HeaderTemplate>
                            <table cellspacing="1" bgcolor="#cccccc" cellpadding="1" width="98%" align="center" border="0">
                            <tbody>
                                <tr bgcolor="#ffffff">
                                    <td align="center" bgcolor="#f0f0f0">
                                        <strong>标题</strong></td>
                                    <td align="center" bgcolor="#f0f0f0">
                                        <strong>时间</strong></td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                            <tr bgcolor="#ffffff">
                                    <td align="center">
                                       <a href='<%#"ShowMsgDetails.aspx?CPL_ID="+Eval("CPL_ID") %>'><strong><%#Eval("CPL_TITLE") %></strong></a></td>
                                    <td align="center">
                                        <strong><%#FormatDate(Eval("CPL_DT")) %></strong></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                           <%-- <tr bgcolor="#ffffff">
                                    <td align="middle" colspan="2">
                                        暂无相关信息</td>
                                </tr>--%>
                            </tbody>
                        </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:SqlDataSource ID="sdsMessages" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                            SelectCommand="SELECT CPL_ID, CPL_DT, CPL_TITLE FROM BCOMPLAIN WHERE (CPL_PSP_ID = @PSP_ID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hddPspId" Name="PSP_ID" PropertyName="Value" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                       
                        <asp:HiddenField ID="hddPspId" runat="server" />
                    </div>
                </div>
                <div style="clear: both; display: block; font: 0px Sans-Serif">
                </div>
            </div>
        </div>
</asp:Content>

