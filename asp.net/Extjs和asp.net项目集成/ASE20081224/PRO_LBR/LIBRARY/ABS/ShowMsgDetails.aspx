<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="ShowMsgDetails.aspx.cs"
    Inherits="ShowMsgDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    <li class="liLeft" onclick="window.location.href='ModifyUser.aspx'">基本信息</li><li
                        class="liLeft" onclick="window.location.href='MyReceive.aspx'">收货信息</li><li class="liLeft"
                            onclick="window.location.href='MyOrder.aspx'">订单查询</li><li class="liLeft"
                             onclick="window.location.href='PointsExchange.aspx'">
                                我的积分</li><li class="liLeft" onclick="window.location.href='LeaveMessage.aspx'">我的留言</li></ul>
            </div>
            <div class="divRight newsDetail2">
                <div class="listProT1" style="margin-top: 10px;">
                    <b>我的留言详情</b>
                </div>
                <div style="overflow: hidden; width: 570px; height: auto">
                    <table cellspacing="1" cellpadding="1" width="98%" align="center" border="0">
                        <tbody>
                            <tr bgcolor="#ffffff">
                                <td style="text-align: center;">
                                    <b>
                                        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal></b></td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td style="text-align: left;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Literal ID="ltrContent" runat="server"></asp:Literal></td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td align="right">
                                    <asp:Literal ID="ltrDate" runat="server"></asp:Literal>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div style="clear: both; display: block; font: 0px Sans-Serif">
            </div>
        </div>
    </div>
</asp:Content>
