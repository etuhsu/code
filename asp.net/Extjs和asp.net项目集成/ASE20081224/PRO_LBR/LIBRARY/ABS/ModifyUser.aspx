<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="ModifyUser.aspx.cs" Inherits="ModifyUser" Title="Untitled Page" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="padding: 0 60px; margin-top: 10px;">
       <DIV class=mainTableP2>

<DIV class=divLeft>
<TABLE cellSpacing=0 cellPadding=0 width="99%" border=0>
  <TBODY>
  <TR>
    <TD class="leftTitle25" style=" BORDER-BOTTOM: #cccccc 1px solid;"><a href="wreg.aspx">会员注册</a></TD>
  </TR>
  </TBODY>
</TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="99%" border=0>
  <TBODY>
  <TR>
    <TD class=leftTitle25 style=" BORDER-BOTTOM: #cccccc 1px solid;"><a href="wlogin.aspx">会员登陆</a></TD>
  </TR></TBODY>
  </TABLE>
  <TABLE cellSpacing=0 cellPadding=0 width="99%" border=0>
  <TBODY>
  <TR>
    <TD class="leftTitle25"><a href="Activity.aspx?frm_id=60">限时抢购</a></TD>
  </TR>
  </TBODY>
</TABLE>
<TABLE cellSpacing=0 cellPadding=0 width="99%" border=0>
  <TBODY>
  <TR>
    <TD class="leftTitle22"><a href="#">我的爱彼此</a></TD>
  </TR></TBODY></TABLE>
<UL class=leftUl>
  <LI class=liLeft onclick="window.location.href='ModifyUser.aspx'">基本信息</LI>
  <LI class=liLeft onclick="window.location.href='MyReceive.aspx'">收货信息</LI>
  <LI class=liLeft onclick="window.location.href='MyOrder.aspx'">订单查询</LI>
  <LI class=liLeft onclick="window.location.href='PointsExchange.aspx'">我的积分</LI>
  <LI class=liLeft onclick="window.location.href='#'">我的留言</LI>
 </UL>
</DIV>

        <DIV class="divRight newsDetail2">
        <DIV style="OVERFLOW: hidden; WIDTH: 570px; HEIGHT: auto">
        <div>
                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td colspan="3">
                                    <div class="listProT1" style="margin-top: 10px;">
                                        修改个人信息</div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="22%">
                                    <span id="nametitle">会员编号</span>：</td>
                                <td align="left">
                                    <asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="22%">
                                    <span class="title" style="color: #ff0000">*</span> <span id="Span1">邮件地址</span>：</td>
                                <td align="left">
                                    <input class="text1" size="25" name="membername" id="txtPspEmail" runat="server" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtPspEmail"
                                        ErrorMessage="请输入邮箱地址!"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="revEmail" runat="server" ControlToValidate="txtPspEmail" ErrorMessage="请正确填写您的邮箱地址，以便我们及时与您联系"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="22%">
                                    <span class="title" style="color: #ff0000">*</span> <span id="Span2">姓名</span>：</td>
                                <td align="left">
                                    <input class="text1" size="25" name="membername" id="txtPspName" runat="server" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtPspName"
                                        ErrorMessage="请输入姓名!"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5" style="height: 13px">
                                    <span class="title" style="color: #ff0000">*</span> 性别：</td>
                                <td align="left" bgcolor="#f5f5f5" style="height: 13px">
                                    <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">男</asp:ListItem>
                                        <asp:ListItem Value="2">女</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td style="height: 13px">
                                    <asp:RequiredFieldValidator ID="rfvSex" runat="server" ControlToValidate="rblSex"
                                        ErrorMessage="请选择性别!"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span class="title" style="color: #ff0000">*</span> 年龄：</td>
                                <td align="left">
                                    <select id="cmbAgeSplit" runat="server" name="age">
                                    </select>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="cmbAgeSplit"
                                        ErrorMessage="请选择年龄!"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td style="height: 26px">
                                </td>
                                <td style="height: 26px">
                                    <div>
                                    </div>
                                </td>
                                <td style="height: 26px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5">
                                    <span class="title" style="color: #ff0000">*</span> 所在省份：</td>
                                <td align="left" bgcolor="#f5f5f5">
                                    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                        <contenttemplate>
<asp:DropDownList id="ddlProvince" runat="server" DataValueField="ID" DataTextField="NAME" DataSourceID="odsProvince" AutoPostBack="True">
                                        </asp:DropDownList> 
</contenttemplate>
                                    </asp:UpdatePanel>
                                    <asp:ObjectDataSource ID="odsProvince" runat="server" SelectMethod="GetPrvTypeList"
                                        TypeName="Res.BLL.TypeBLL"></asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince"
                                        ErrorMessage="请选择省份!"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span class="title" style="color: #ff0000">*</span> 所在城市：</td>
                                <td align="left">
                                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                                        <contenttemplate><asp:DropDownList ID="ddlCity" runat="server" name="ddlCity" DataSourceID="odsCity"
                                        DataTextField="NAME" DataValueField="ID">
                                    </asp:DropDownList>
                                    </contenttemplate></asp:UpdatePanel>
                                    <asp:ObjectDataSource ID="odsCity" runat="server" SelectMethod="GetCityName" TypeName="Res.BLL.TypeBLL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlProvince" Name="PRV_ID" PropertyName="SelectedValue"
                                                Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                        ErrorMessage="请选择城市!"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5">
                                    <span class="title" style="color: #ff0000">*</span> 邮编：</td>
                                <td align="left" bgcolor="#f5f5f5">
                                    <input id="txtPspZip" runat="server" class="text1" maxlength="100" name="zipcode"
                                        size="15" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtPspZip"
                                        ErrorMessage="请输入邮编！"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="revZip" runat="server" ControlToValidate="txtPspZip" ErrorMessage="请输入正确的邮编！"
                                            ValidationExpression="\d{6}"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span class="title" style="color: #ff0000">*</span> 具体地址：</td>
                                <td align="left" colspan="2">
                                    <input id="txtAddress" runat="server" class="text1" maxlength="100" name="address"
                                        size="50" />
                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                        ErrorMessage="请输入具体地址！"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    固定电话：</td>
                                <td align="left">
                                    <input id="txtPspTel" runat="server" class="text1" maxlength="100" name="telephone"
                                        size="25" /></td>
                                <td>
                                    多个电话号码请用&quot;,&quot;隔开</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5">
                                    传真：</td>
                                <td align="left" bgcolor="#f5f5f5">
                                    <input id="txtPspFax" runat="server" class="text1" maxlength="100" name="fax" size="25" /></td>
                                <td>
                                    多个电话号码请用&quot;,&quot;隔开</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    所属行业：</td>
                                <td align="left">
                                    &nbsp;<select id="cmbTrade" runat="server" name="trade">
                                        <%--<option value="" selected="selected">请选择..</option>--%>
                                        <option selected="selected" value="金融/保险业">金融/保险业</option>
                                        <option value="房地产业">房地产业</option>
                                        <option value="信息技术">信息技术</option>
                                        <option value="交通运输">交通运输</option>
                                        <option value="文艺/影视娱乐">文艺/影视娱乐</option>
                                        <option value="服务业">服务业</option>
                                        <option value="体育">体育</option>
                                        <option value="商业">商业</option>
                                        <option value="旅游业">旅游业</option>
                                        <option value="法律">法律</option>
                                        <option value="科研机构">科研机构</option>
                                        <option value="教育">教育</option>
                                        <option value="制造业">制造业</option>
                                        <option value="传媒业">传媒业</option>
                                        <option value="政府机构">政府机构</option>
                                        <option value="医疗保健">医疗保健</option>
                                        <option value="其它">其它</option>
                                    </select></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div style="background: url(img/dashed_s.gif) repeat-x; width: 750px; text-align: center;
                                        margin-top: 10px;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div class="listProT1" style="margin-top: 10px;">
                                        核实登记</div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="22%" bgcolor="#f5f5f5" valign="middle">
                                    <span class="title" style="color: #ff0000">*</span> 验证码：</td>
                                <td align="left" bgcolor="#f5f5f5" valign="middle">
                                    <input id="txtCode" runat="server" class="text1" maxlength="15" name="verifycode"
                                        size="15" />
                                    <img src="Form/CodeForm.aspx" width="54" height="19" />
                                </td>
                                <td valign="middle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode"
                                        ErrorMessage="请输入验证码！"></asp:RequiredFieldValidator>这是一项防止外来电脑自动登记的功能。</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
         <div style="text-align: center;">
                    <input class="button4" type="submit" value=" 修 改 " name="Submit" id="btnModify" onserverclick="btnModify_ServerClick"
                        runat="server" />
                    <input class="button4" type="reset" value=" 重 置 " name="Submit22" id="btnReset" runat="server" /></div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
