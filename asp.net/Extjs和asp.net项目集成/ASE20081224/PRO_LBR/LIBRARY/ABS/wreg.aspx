<%@ Page Language="C#" MasterPageFile="~/MPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="wreg.aspx.cs" Inherits="wreg" Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
   //验证密码长度
    function ValidatePwd(source,args)
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_txtPspPwd").value.length<6)
        {
            args.IsValid=false;
        }
        else
        {
            args.IsValid=true;
        }
    }
    //验证省份 
    function ValidateProvince(source,args)
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlProvince").value=='0')
        {
            args.IsValid=false;
        }
        else
        {
            args.IsValid=true;
        }
    }
    //验证城市 
    function ValidateCity(source,args)
    {
//        alert(document.getElementById("ctl00_ContentPlaceHolder1_ddlCity").value);
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlCity").value=='0')
        {
            args.IsValid=false;
        }
        else
        {
            args.IsValid=true;
        }
    } 
    //验证年龄 
    function ValidateAgeSplit(source,args)
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlAgeSplit").value=='0')
        {
            args.IsValid=false;
        }
        else
        {
            args.IsValid=true;
        }
    }
    //验证行业 
    function ValidateTrade(source,args)
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_cmbTrade").value=='0')
        {
            args.IsValid=false;
        }
        else
        {
            args.IsValid=true;
        }
    }
    //验证获知途径
    function ValidateDts(source,args)
    {
        if(document.getElementById("ctl00_ContentPlaceHolder1_ddlDts").value=='0')
        {
            args.IsValid=false;
        }
        else
        {
            args.IsValid=true;
        }
    }
    </script>

    <div style="padding: 0 60px; margin-top: 10px;">
        <div>
            <img src="img/border_newuser.gif" width="780" height="30" /></div>
        <div class="border_color">
            <div style="padding: 10px;">
                <div class="listProT1">
                    填写您的帐户资料</div>
                <div>
                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr valign="top" style="margin: 10px 0;">
                                <td align="right" width="18%" valign="middle">
                                    <span style="color: #ff0000">*</span> 会员编号：</td>
                                <td align="left" valign="middle" style="width: 198px">
                                    <input class="text1" maxlength="30" size="25" name="membernumber" id="txtPspMobile"
                                        runat="server" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ErrorMessage="*" ControlToValidate="txtPspMobile"></asp:RequiredFieldValidator>会员编号是您在ABS的唯一编号，请用您的手机号码作为您的编号，可直接输入，如13812345678<asp:RegularExpressionValidator
                                        ID="revMobile" runat="server" ErrorMessage="(请输入正确的手机号码作为您的会员编号)" ValidationExpression="^(13[0-9]|15[0|3|6|8|9])\d{8}$"
                                        ControlToValidate="txtPspMobile"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr valign="top">
                                <td align="right" bgcolor="#f5f5f5" valign="middle">
                                    <span style="color: #ff0000">*</span> 电邮地址：</td>
                                <td align="left" bgcolor="#f5f5f5" valign="middle" style="width: 198px">
                                    <input class="text1" maxlength="255" size="25" name="email" id="txtPspEmail" runat="server" />
                                </td>
                                <td valign="middle">
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtPspEmail"
                                        ErrorMessage="请输入邮箱地址!"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="revEmail" runat="server" ControlToValidate="txtPspEmail" ErrorMessage="请正确填写您的邮箱地址，以便我们及时与您联系"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr valign="top">
                                <td align="right" valign="middle">
                                    <span style="color: #ff0000">*</span> 密码：</td>
                                <td align="left" valign="middle" style="width: 198px">
                                    <input class="text1" type="password" maxlength="255" size="25" name="txtPspPwd" id="txtPspPwd"
                                        runat="server" /></td>
                                <td valign="middle">
                                    <asp:CustomValidator ID="ctvPwd" runat="server" ErrorMessage="不少于 6 个字符，且区分大小写。"
                                        ClientValidationFunction="ValidatePwd" ControlToValidate="txtPspPwd"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr valign="top">
                                <td align="right" bgcolor="#f5f5f5" valign="middle">
                                    <span style="color: #ff0000">*</span> 再输入确认密码：</td>
                                <td align="left" bgcolor="#f5f5f5" valign="middle" style="width: 198px">
                                    <input class="text1" maxlength="255" type="password" size="25" name="pwd" id="txtRePwd"
                                        runat="server" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvRePwd" runat="server" ControlToValidate="txtRePwd"
                                        ErrorMessage="请输入确认密码!"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cpvRePwd" runat="server" ErrorMessage="两次输入的密码不一致!" ControlToCompare="txtPspPwd"
                                        ControlToValidate="txtRePwd"></asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td style="height: 25px">
                                </td>
                                <td style="width: 198px; height: 25px;">
                                    <div>
                                    </div>
                                </td>
                                <td style="height: 25px">
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
                                        填写个人资料</div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="22%">
                                    <span class="title" style="color: #ff0000">*</span> <span id="nametitle">姓名</span>：</td>
                                <td align="left" style="width: 198px">
                                    <input class="text1" size="25" name="membername" id="txtPspNmae" runat="server" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="请输入姓名!" ControlToValidate="txtPspNmae"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5">
                                    <span class="title" style="color: #ff0000">*</span> 性别：</td>
                                <td align="left" bgcolor="#f5f5f5" style="width: 198px">
                                    <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">男</asp:ListItem>
                                        <asp:ListItem Value="0">女</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvSex" runat="server" ErrorMessage="请选择性别!" ControlToValidate="rblSex"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span class="title" style="color: #ff0000">*</span> 年龄：</td>
                                <td align="left" style="width: 198px">
                                    <asp:DropDownList ID="ddlAgeSplit" runat="server" OnDataBound="ddlAgeSplit_DataBound">
                                    </asp:DropDownList></td>
                                <td>
                                    &nbsp;<asp:CustomValidator ID="ctvAgeSplit" runat="server" ClientValidationFunction="ValidateAgeSplit"
                                        ControlToValidate="ddlAgeSplit" ErrorMessage="请选择年龄!"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5" style="height: 28px">
                                    <span class="title" style="color: #ff0000">*</span> 所在省份：</td>
                                <td align="left" bgcolor="#f5f5f5" style="height: 28px; width: 198px;">
                               
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
<asp:DropDownList id="ddlProvince" runat="server" DataValueField="ID" DataTextField="NAME" DataSourceID="odsProvince" AutoPostBack="True" OnDataBound="ddlProvince_DataBound"></asp:DropDownList> 
</ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:ObjectDataSource ID="odsProvince" runat="server" SelectMethod="GetPrvTypeList"
                                        TypeName="Res.BLL.TypeBLL"></asp:ObjectDataSource>
                                </td>
                                <td style="height: 28px">
                                    <asp:CustomValidator ID="ctvProvince" runat="server" ClientValidationFunction="ValidateProvince"
                                        ErrorMessage="请选择省份!" ControlToValidate="ddlProvince"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span class="title" style="color: #ff0000">*</span> 所在城市：</td>
                                <td align="left" style="width: 198px">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
<asp:DropDownList id="ddlCity" runat="server" DataValueField="ID" DataTextField="NAME" DataSourceID="odsCity" EnableViewState="False" name="ddlCity" OnDataBound="ddlCity_DataBound"></asp:DropDownList> 
</ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:ObjectDataSource ID="odsCity" runat="server" SelectMethod="GetCityName" TypeName="Res.BLL.TypeBLL">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlProvince" Name="PRV_ID" PropertyName="SelectedValue"
                                                Type="Int32" DefaultValue="0" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:CustomValidator ID="ctvCity" runat="server" ClientValidationFunction="ValidateCity"
                                        ControlToValidate="ddlCity" ErrorMessage="请选择城市!"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5">
                                    <span class="title" style="color: #ff0000">*</span> 邮编：</td>
                                <td align="left" bgcolor="#f5f5f5" style="width: 198px">
                                    <input class="text1" maxlength="100" size="15" name="zipcode" id="txtPspZip" runat="server" /></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" ErrorMessage="请输入邮编！" ControlToValidate="txtPspZip"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revZip" runat="server" ErrorMessage="请输入正确的邮编！"
                                        ControlToValidate="txtPspZip" ValidationExpression="\d{6}"></asp:RegularExpressionValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
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
                                    <input class="text1" maxlength="100" size="50" name="address" id="txtAddress" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="请输入具体地址！"
                                        ControlToValidate="txtAddress"></asp:RequiredFieldValidator></td>
                            </tr>
                            
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 30px">
                                    固定电话：</td>
                                <td align="left" style="height: 30px; width: 198px;">
                                    <input class="text1" maxlength="100" size="25" name="telephone" id="txtPspTel" runat="server" /></td>
                                <td style="height: 30px">
                                    多个电话号码请用&quot;,&quot;隔开</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" bgcolor="#f5f5f5">
                                    传真：</td>
                                <td align="left" bgcolor="#f5f5f5" style="width: 198px">
                                    <input class="text1" maxlength="100" size="25" name="fax" id="txtPspFax" runat="server" /></td>
                                <td>
                                    多个电话号码请用&quot;,&quot;隔开</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 28px">
                                    所属行业：</td>
                                <td align="left" style="width: 198px; height: 28px;">
                                    <select name="trade" id="cmbTrade" runat="server">
                                        <option value="0">--请选择--</option>
                                        <option value="金融/保险业">金融/保险业</option>
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
                                    </select>
                                </td>
                                <td style="height: 28px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
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
                                        如何知道我们</div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="22%" bgcolor="#f5f5f5">
                                    <span class="title" style="color: #ff0000">*</span> 获知途径：</td>
                                <td align="left" bgcolor="#f5f5f5" style="width: 198px">
                                    &nbsp;<asp:DropDownList ID="ddlDts" runat="server" OnDataBound="ddlDts_DataBound">
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:CustomValidator ID="ctvDts" runat="server" ClientValidationFunction="ValidateDts"
                                        ControlToValidate="ddlDts" ErrorMessage="请选择获知途径!"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
                                    <div>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    推荐人：</td>
                                <td align="left" style="width: 198px">
                                    <input class="text1" maxlength="15" size="15" name="guide" id="txtRecomand" runat="server" />
                                </td>
                                <td>
                                    请填写推荐人的会员编号</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
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
                                <td align="left" bgcolor="#f5f5f5" valign="middle" style="width: 198px">
                                    <input class="text1" maxlength="15" size="15" name="verifycode" id="txtCode" runat="server" /><img
                                        src="Form/CodeForm.aspx" width="54" height="19" /></td>
                                <td valign="middle">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode"
                                        ErrorMessage="请输入验证码！"></asp:RequiredFieldValidator>这是一项防止外来电脑自动登记的功能。</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img src="../img_all/space.gif" width="1" height="10" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td style="width: 198px">
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
                    <input class="button4" type="submit" value=" 注 册 " name="Submit" id="btnRegister"
                        runat="server" onserverclick="btnRegister_ServerClick" />
                    <input class="button4" type="reset" value=" 重 置 " name="Submit22" /></div>
            </div>
        </div>
        <div>
            <img src="img/border_newuser_bottom.gif" width="780" height="20" /></div>
    </div>
</asp:Content>
