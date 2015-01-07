<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="PointsExchange.aspx.cs"
    Inherits="PointsExchange" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[

function Submit1_onclick() {

}

// ]]>
    </script>

    <div style="padding: 0 45px; margin-top: 10px;" class="clearfix">
        <div class="mainTableP2">
            <div class="divLeft">
                <table cellspacing="0" cellpadding="0" width="99%" border="0">
                    <tbody>
                        <tr>
                            <td class="leftTitle25" style="border-bottom: #cccccc 1px solid; height: 19px;">
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
                            onclick="window.location.href='MyOrder.aspx'">订单查询</li><li class="liLeft" onclick="window.location.href='PointsExchange.aspx'">
                                我的积分</li><li class="liLeft" onclick="window.location.href='LeaveMessage.aspx'">我的留言</li></ul>
            </div>
            <div class="divRight newsDetail2">
                <div style="overflow: hidden; width: 570px; height: auto">
                    <table cellspacing="1" cellpadding="1" width="98%" align="center" bgcolor="#cccccc"
                        border="0">
                        <tbody>
                            <tr>
                                <td bgcolor="#eaeaea" colspan="6">
                                    <span style="font-weight: bold">&nbsp;我的积分</span></td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td align="center" style="height: 21px">
                                    总积分</td>
                                <td align="center" style="height: 21px">
                                    <asp:Literal ID="ltrTotalPoint" runat="server"></asp:Literal></td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td align="center" style="height: 21px">
                                    兑换积分</td>
                                <td align="center" style="height: 21px">
                                    <asp:Literal ID="ltrRedeemPoint" runat="server"></asp:Literal></td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td align="center">
                                    有效积分</td>
                                <td align="center">
                                    &nbsp;<asp:Literal ID="ltrAvailablePoint" runat="server"></asp:Literal></td>
                            </tr>
                        </tbody>
                    </table>
                    <br>
                    <asp:Repeater ID="rptPoints" runat="server" DataSourceID="sdsPoints">
                        <HeaderTemplate>
                            <table cellspacing="1" cellpadding="1" width="98%" align="center" bgcolor="#cccccc"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td bgcolor="#eaeaea" colspan="6">
                                            <span style="font-weight: bold">&nbsp;积分明细</span></td>
                                    </tr>
                                    <tr bgcolor="#ffffff">
                                        <td align="center">
                                            积分时间</td>
                                        <td align="center">
                                            积分类型</td>
                                        <td align="center">
                                            定单编号</td>
                                            <td align="center">积分</td>
                                    </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr bgcolor="#ffffff">
                                <td align="center">
                                    <%#FormatDate( Eval("HPT_DT")) %>
                                </td>
                                <td align="center">
                                    <%#Eval("PNT_DESC") %>
                                </td>
                                <td align="center">
                                    <%#Eval("PUR_CODE") %>
                                </td>
                                <td align="center"><%#Eval("HPT_POINT_NUM") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:SqlDataSource ID="sdsPoints" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                        SelectCommand="SELECT HPT_DT,PNT_DESC,PUR_CODE,HPT_POINT_NUM,HPT_ID,HPT_PSP_ID,HPT_PUR_ID,PNT_ID&#13;&#10;FROM HPOINT&#13;&#10;LEFT JOIN BPURCHASE ON PUR_ID=HPT_PUR_ID&#13;&#10;LEFT JOIN RPOINTOPERATIONTYPE ON PNT_ID=HPT_PNT_ID&#13;&#10;WHERE HPT_PSP_ID=@PSP_ID">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="hddPspId" Name="PSP_ID" PropertyName="Value" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br>
                     <asp:UpdatePanel id="udpPoint" runat="server">
                        <contenttemplate>
                    <table cellspacing="1" cellpadding="1" width="98%" align="center" bgcolor="#cccccc"
                        border="0">
                        <tbody>
                            <tr>
                                <td bgcolor="#eaeaea" colspan="6">
                                    <span style="font-weight: bold">&nbsp;积分兑换</span></td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td align="center">
                                    积分范围</td>
                                <td align="center">
                                    兑换产品</td>
                                <td align="center">
                                    兑换数量</td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td align="center">
                                    &nbsp;<asp:DropDownList ID="ddlPointRange" runat="server" DataSourceID="sdsPointRange"
                                        DataTextField="PTR_DESC" DataValueField="PTR_ID" AutoPostBack="True" Width="155px">
                                    </asp:DropDownList><asp:SqlDataSource ID="sdsPointRange" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                                        SelectCommand="SELECT PTR_ID,PTR_DESC FROM RPOINTRANGE"></asp:SqlDataSource>
                                </td>
                                <td align="center">
                                    <asp:DropDownList ID="ddlPoitProduct" runat="server" DataSourceID="sdsPointProduct"
                                        DataTextField="GIF_NAME" DataValueField="GIF_ID" Width="178px">
                                    </asp:DropDownList><asp:SqlDataSource ID="sdsPointProduct" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                                        SelectCommand="PROC_RGIFT_GetRange" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlPointRange" DefaultValue="1" Name="PTR_ID" PropertyName="SelectedValue"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    &nbsp;</td>
                                <td align="center">
                                    <input style="width: 56px" id="txtNum" class="text1" maxlength="100" name="fax" runat="server" /></td>
                            </tr>
                            <tr bgcolor="#ffffff">
                                <td align="right" colspan="3">
                                    <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                            </tr>
                        </tbody>
                    </table>
                    <div style="margin-top: 8px; text-align: center">
                        &nbsp;<asp:Button ID="btnOk" OnClick="btnOk_Click" runat="server" Text="确定" __designer:wfdid="w8"
                            CssClass="button4"></asp:Button>
                        <asp:HiddenField ID="hddPspId" runat="server"></asp:HiddenField>
                    </div>
                    </contenttemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div style="clear: both; display: block; font: 0px Sans-Serif">
            </div>
        </div>
    </div>
</asp:Content>
