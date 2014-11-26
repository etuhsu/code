<%@ Page Language="C#" MasterPageFile="~/MPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="MyReceive.aspx.cs" Inherits="MyReceive" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
function ValidateProvince(source,args)
{
    if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_province").value=='0')
    {
        args.IsValid=false;
    }
    else
    {
        args.IsValid=true;
    }
}
function ValidateCtiy(source,args)
{
    if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_city").value=='0')
    {
        args.IsValid=false;
    }
    else
    {
        args.IsValid=true;
    }
}
    </script>

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
                    <li class="liLeft" onclick="window.location.href='ModifyUser.aspx'">基本信息</li>
                    <li class="liLeft" onclick="window.location.href='MyReceive.aspx'">收货信息</li>
                    <li class="liLeft" onclick="window.location.href='MyOrder.aspx'">订单查询</li>
                    <li class="liLeft" onclick="window.location.href='PointsExchange.aspx'">我的积分</li>
                    <li class="liLeft" onclick="window.location.href='LeaveMessage.aspx'">我的留言</li>
                </ul>
            </div>
            <div class="divRight newsDetail2">
                <div style="overflow: hidden; width: 570px; height: auto">
                    <div style="overflow: hidden; width: 570px; height: auto">
                        <div>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <HeaderTemplate>
                                    <table cellspacing="1" cellpadding="2" width="98%" align="center" bgcolor="#cccccc"
                                        border="0">
                                        <tr bgcolor="#eaeaea">
                                            <td align="center" bgcolor="#f0f0f0">
                                                <span style="font-weight: bold">收货人</span></td>
                                            <td align="center" bgcolor="#f0f0f0">
                                                <span style="font-weight: bold">地址</span></td>
                                            <td align="center" bgcolor="#f0f0f0">
                                                <span style="font-weight: bold">邮编</span></td>
                                            <td align="center" bgcolor="#f0f0f0">
                                                <span style="font-weight: bold">电话</span></td>
                                            <td align="center" bgcolor="#f0f0f0">
                                                <span style="font-weight: bold">省份</span></td>
                                            <td align="center" bgcolor="#f0f0f0">
                                                <span style="font-weight: bold">城市</span></td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr bgcolor="#ffffff">
                                        <td align="center" class="tdTitleD">
                                            <%#Eval("ORA_NAME")%>
                                        </td>
                                        <td align="left" class="tdTitleD">
                                            <%#Eval("ORA_ADDRESS")%>
                                        </td>
                                        <td align="center" class="tdTitleD">
                                            <%#Eval("ORA_ZIP")%>
                                        </td>
                                        <td align="center" class="tdTitleD">
                                            <%#Eval("ORA_PHONE")%>
                                        </td>
                                        <td align="center" class="tdTitleD">
                                            <%#Eval("PRV_LOCALNAME")%>
                                        </td>
                                        <td align="center" class="tdTitleD">
                                            <%#Eval("CTY_LOCALNAME")%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                            &nbsp;
                            <br>
                            <table cellspacing="1" cellpadding="3" width="98%" align="center" bgcolor="#cccccc"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td class="tdTitleC" align="left" colspan="3">
                                            新增联系人</td>
                                    </tr>
                                    <tr valign="top">
                                        <td nowrap bgcolor="#ffffff" class="tdTitleb" style="height: 25px">
                                            收件人：</td>
                                        <td colspan="2" align="left" bgcolor="#ffffff" valign="middle" style="height: 25px">
                                            <input id="txtName" runat="server" class="text1" maxlength="100" name="consignee" /><asp:RequiredFieldValidator
                                                ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入收件人姓名!"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr valign="top">
                                        <td nowrap bgcolor="#ffffff" class="tdTitleb">
                                            所在省份：</td>
                                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 47px">
                                            <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
<asp:DropDownList id="ddl_province" runat="server" DataSourceID="sds_province" DataTextField="PRV_LOCALNAME" DataValueField="PRV_ID" AutoPostBack="True" OnSelectedIndexChanged="ddl_province_SelectedIndexChanged" OnDataBound="ddl_province_DataBound" __designer:wfdid="w26">
                    </asp:DropDownList>&nbsp;&nbsp; <asp:SqlDataSource id="sds_province" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>" SelectCommand="SELECT [PRV_ID], [PRV_LOCALNAME] FROM [RPROVINCE] ORDER BY [PRV_ORDER_NUM]" CacheDuration="1800" EnableCaching="true" __designer:wfdid="w27">
                    </asp:SqlDataSource> 
</contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td align="left" bgcolor="#ffffff" valign="middle">
                                            <asp:CustomValidator ID="cvdProvince" runat="server" ClientValidationFunction="ValidateProvince"
                                                ControlToValidate="ddl_province" ErrorMessage="请选择省份!"></asp:CustomValidator></td>
                                    </tr>
                                    <tr valign="top">
                                        <td nowrap bgcolor="#ffffff" class="tdTitleb">
                                            所在城市：</td>
                                        <td align="left" bgcolor="#ffffff" valign="middle" style="width: 50px;">
                                            <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <contenttemplate>
<asp:DropDownList id="ddl_city" runat="server" DataSourceID="sds_city" DataTextField="CTY_LOCALNAME" DataValueField="CTY_ID" OnDataBound="ddl_city_DataBound" __designer:wfdid="w28">
                    </asp:DropDownList>&nbsp;&nbsp; <asp:SqlDataSource id="sds_city" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>" SelectCommand="SELECT [CTY_ID], [CTY_LOCALNAME] FROM [RCITY] WHERE ([CTY_PRV_ID] = @CTY_PRV_ID) ORDER BY [CTY_ORDER_NUM]" __designer:wfdid="w29">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddl_province" DefaultValue="0" Name="CTY_PRV_ID"
                                PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource> 
</contenttemplate>
                                                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddl_province" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td style="width: 200px" align="left" bgcolor="#ffffff" valign="middle">
                                            <asp:CustomValidator ID="cvdCity" runat="server" ClientValidationFunction="ValidateCtiy"
                                                ControlToValidate="ddl_city" ErrorMessage="请选择城市!"></asp:CustomValidator></td>
                                    </tr>
                                    <tr valign="top">
                                        <td nowrap bgcolor="#ffffff" class="tdTitleb">
                                            邮编：</td>
                                        <td colspan="2" align="left" bgcolor="#ffffff" valign="middle" style="width: 342px">
                                            <input id="txtZip" runat="server" class="text1" maxlength="100" name="zipcode" size="15" /><asp:RequiredFieldValidator
                                                ID="rfvZip" runat="server" ControlToValidate="txtZip" ErrorMessage="请输入邮编！"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="revZip" runat="server" ControlToValidate="txtZip" ErrorMessage="请输入正确的邮编！"
                                                    ValidationExpression="\d{6}"></asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr valign="top">
                                        <td nowrap bgcolor="#ffffff" class="tdTitleb">
                                            具体地址：</td>
                                        <td colspan="2" align="left" bgcolor="#ffffff" valign="middle">
                                            <input id="txtAddress" runat="server" class="text1" maxlength="100" name="address"
                                                size="50" /><asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                    ErrorMessage="请输入具体地址！"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr valign="top">
                                        <td nowrap bgcolor="#ffffff" class="tdTitleb">
                                            联系电话或手机：</td>
                                        <td colspan="2" align="left" bgcolor="#ffffff" valign="middle">
                                            &nbsp;<input id="txtPhone" runat="server" class="text1" maxlength="100" name="telephone"
                                                size="25" />&nbsp;多个电话号码请用","隔开</td>
                                    </tr>
                            </table>
                            <br>
                        </div>
                        <div>
                        </div>
                        <div style="text-align: center;">
                            <input class="button4" type="submit" value=" 保 存 " id="btnSavea" onserverclick="btnSave_ServerClick"
                                runat="server" />
                        </div>
                    </div>
                    <asp:HiddenField ID="hddPspId" runat="server" />
                </div>
                <div style="clear: both; display: block; font: 0px Sans-Serif">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
