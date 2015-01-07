<%@ Page Language="C#" MasterPageFile="~/MPage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="ConfirmInfo.aspx.cs" Inherits="ConfirmInfo"
    Title="Untitled Page" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
function ValidateFee(source,args)
{
//alert(document.getElementById("ctl00_ContentPlaceHolder1_ddl_free").value);
    if(document.getElementById("ctl00_ContentPlaceHolder1_ddl_free").value=='0')
        {
            args.IsValid=false;
        }
        else
        {
            args.IsValid=true;
        }
}
    </script>

    <div style="padding: 0 45px; margin-top: 10px;">
        <div style="padding: 10px; border: 1px #c1aa97 solid;">
            <div>
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td colspan="3">
                                <div class="listProT1" style="margin-top: 10px;">
                                    确认收货信息</div>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td align="right" width="22%" style="height: 25px">
                                <span id="nametitle">会员编号</span>：</td>
                            <td align="left" style="height: 25px">
                                <asp:Literal ID="ltrMobile" runat="server"></asp:Literal>
                                <asp:HiddenField ID="hddPspId" runat="server" />
                            </td>
                            <td style="height: 25px">
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
                            <td align="right" bgcolor="#f5f5f5">
                                优惠信息：</td>
                            <td align="left" bgcolor="#f5f5f5">
                                <asp:DropDownList ID="ddl_free" runat="server" DataSourceID="sds_free" DataTextField="DSC_DESC"
                                    DataValueField="DSC_ID" ValidationGroup="order" OnDataBound="ddl_free_DataBound">
                                </asp:DropDownList><asp:SqlDataSource ID="sds_free" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                                    SelectCommand="SELECT [DSC_ID], [DSC_DESC] FROM [WDISCOUNT] WHERE ([DSC_STATUS] = @DSC_STATUS)">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="1" Name="DSC_STATUS" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <img src="img_all/space.gif" width="1" height="10" /></td>
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
                                    选择送货地址</div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <img src="img_all/space.gif" width="1" height="10" /></td>
                        </tr>
                    </tbody>
                </table>
                <asp:UpdatePanel id="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
             
                
                <asp:DataList ID="dlAddress" Width="95%" runat="server" OnItemCommand="dlAddress_ItemCommand"
                    DataSourceID="sqlDsAddress">
                    <HeaderTemplate>
                        <table class="tableBg" cellspacing="0" cellpadding="2" width="95%" align="right"
                            border="1" bordercolor="#cccccc">
                            <tr>
                                <td class="tdTitleC">
                                    收件人</td>
                                <td class="tdTitleC">
                                    收件地址</td>
                                <td class="tdTitleC">
                                    邮编</td>
                                <td class="tdTitleC">
                                    联系电话</td>
                                <td class="tdTitleC">
                                    省份</td>
                                <td class="tdTitleC">
                                    城市</td>
                                <td style="width: 100px;" class="tdTitleC">
                                    &nbsp;</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
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
                                <asp:HiddenField ID="hddCtyId" Value='<%#Eval("ORA_CTY_ID") %>' runat="server"></asp:HiddenField>
                            </td>
                            <td align="center" class="tdTitleD">
                                <asp:Button ID="btnSel" ValidationGroup="Sel" runat="server" CommandName="Select"
                                    CommandArgument='<%#Eval("ORA_ID") %>' Text="选择" /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                     </table>
                    </FooterTemplate>
                </asp:DataList>
                
                <asp:SqlDataSource ID="sqlDsAddress" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                    SelectCommand="SELECT ORA_ID,ORA_NAME,ORA_ADDRESS,ORA_ZIP,ORA_PHONE,ORA_CTY_ID,CTY_LOCALNAME,PRV_LOCALNAME &#13;&#10;FROM BORDERADDRESS&#13;&#10;LEFT JOIN RCITY ON ORA_CTY_ID=CTY_ID&#13;&#10;LEFT JOIN RPROVINCE ON CTY_PRV_ID=PRV_ID&#13;&#10;WHERE ORA_PSP_ID=@PSP_ID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hddPspId" Name="PSP_ID" PropertyName="Value" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp;&nbsp;
                   
                </contenttemplate>
                </asp:UpdatePanel>&nbsp;
                <asp:UpdatePanel id="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
                    
                <div style="margin: 5px 40px 5px 0px; text-align: right">
                    <%--<asp:Label ID="lblAddAddress" runat="server" Text="添加新地址成功！" Visible="False" ForeColor="Red"></asp:Label>--%>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAddAddress" OnClick="btnAddAddress_Click" runat="server" Text=" 添加新地址 "
                        ValidationGroup="Sel"></asp:Button>
                </div>
                <div id="divAddress" runat="server">
                    <table cellspacing="0" cellpadding="3" width="100%" border="0">
                        <tbody>
                            <tr>
                                <td style="height: 25px">
                                </td>
                                <td style="height: 25px">
                                    <div>
                                    </div>
                                </td>
                                <td style="height: 25px">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="22%">
                                    <span style="color: #ff0000" class="title">*</span> <span id="Span1">收件人</span>：</td>
                                <td align="left">
                                    <asp:TextBox ID="txtName" runat="server" ValidationGroup="address" CssClass="text1"></asp:TextBox>
                                    <asp:Label ID="lblName" runat="server" Visible="False" ForeColor="Red">请输入姓名！</asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img height="10" src="img_all/space.gif" width="1" /></td>
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
                                    <span style="color: #ff0000" class="title">*</span> 所在省份：</td>
                                <td align="left" bgcolor="#f5f5f5">
                                    <asp:DropDownList ID="ddl_province" runat="server" ValidationGroup="address" DataValueField="PRV_ID"
                                        DataTextField="PRV_LOCALNAME" DataSourceID="sds_province" OnSelectedIndexChanged="ddl_province_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sds_province" runat="server" SelectCommand="SELECT [PRV_ID], [PRV_LOCALNAME] FROM [RPROVINCE] ORDER BY [PRV_ORDER_NUM]"
                                        ConnectionString="<%$ ConnectionStrings:SQLConnString %>" EnableCaching="true"
                                        CacheDuration="1800"></asp:SqlDataSource>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img height="10" src="img_all/space.gif" width="1" /></td>
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
                                    <span style="color: #ff0000" class="title">*</span> 所在城市：</td>
                                <td align="left">
                                    <asp:DropDownList ID="ddl_city" runat="server" ValidationGroup="address" DataValueField="CTY_ID"
                                        DataTextField="CTY_LOCALNAME" DataSourceID="sds_city" OnSelectedIndexChanged="ddl_city_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sds_city" runat="server" SelectCommand="SELECT [CTY_ID], [CTY_LOCALNAME] FROM [RCITY] WHERE ([CTY_PRV_ID] = @CTY_PRV_ID) ORDER BY [CTY_ORDER_NUM]"
                                        ConnectionString="<%$ ConnectionStrings:SQLConnString %>">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddl_province" DefaultValue="0" Name="CTY_PRV_ID"
                                                PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img height="10" src="img_all/space.gif" width="1" /></td>
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
                                    <span style="color: #ff0000" class="title">*</span> 邮编：</td>
                                <td align="left" bgcolor="#f5f5f5">
                                    <asp:TextBox ID="txtZip" runat="server" ValidationGroup="address" CssClass="text1"></asp:TextBox>&nbsp;
                                    <asp:Label ID="lblZip" runat="server" Visible="False" ForeColor="Red">请输入正确邮编！</asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img height="10" src="img_all/space.gif" width="1" /></td>
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
                                    <span style="color: #ff0000" class="title">*</span> 具体地址：</td>
                                <td align="left" colspan="2">
                                    <input id="txtAddress" class="text1" maxlength="100" size="50" name="address" runat="server" />
                                    <asp:Label ID="lblAddress" runat="server" Visible="False" ForeColor="Red">请输入具体地址！</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img height="10" src="img_all/space.gif" width="1" /></td>
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
                                    <img height="10" src="img_all/space.gif" width="1" /></td>
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
                                <td style="height: 25px" align="right">
                                    联系电话：</td>
                                <td style="height: 25px" align="left">
                                    <asp:TextBox ID="txtTel" runat="server" ValidationGroup="address" CssClass="text1"></asp:TextBox></td>
                                <td style="height: 25px">
                                    多个电话号码请用","隔开</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <img height="10" src="img_all/space.gif" width="1" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <div>
                                        &nbsp;<asp:Button ID="btnAddAdr" OnClick="btnAddAdr_Click" CssClass="button4" runat="server" Text=" 添 加 "
                                            ValidationGroup="address"></asp:Button>
                                        <asp:Button ID="btnCancelAdr" OnClick="btnCancelAdr_Click" CssClass="button4" runat="server" Text=" 取 消 "
                                            ValidationGroup="Sel"></asp:Button>
                                    </div>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                    </contenttemplate>
                </asp:UpdatePanel>
                <table cellspacing="0" cellpadding="3" width="100%" border="0">
                    <tbody>
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
                                    付款方式</div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div style="margin: 10px 0 10px 70px;">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="sds_paytype"
                                        DataTextField="PAY_DESC" DataValueField="PAY_ID" ValidationGroup="order">
                                    </asp:RadioButtonList><asp:RequiredFieldValidator ID="rfvPayType" runat="server"
                                        ControlToValidate="RadioButtonList1" ErrorMessage="请选择付款方式！" ValidationGroup="order"></asp:RequiredFieldValidator><asp:SqlDataSource
                                            ID="sds_paytype" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConnString %>"
                                            SelectCommand="SELECT [PAY_ID], [PAY_DESC] FROM [RPAYTYPE]"></asp:SqlDataSource>
                                    &nbsp;</div>
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
                                &nbsp;<input id="txtCode" runat="server" class="text1" maxlength="15" name="verifycode"
                                    size="15" /><asp:Image ID="Image1" runat="server" align="absmiddle" Height="19px"
                                        ImageUrl="Form/CodeForm.aspx" Width="54px" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            runat="server" ControlToValidate="txtCode" ErrorMessage="请输入验证码！" ValidationGroup="order"></asp:RequiredFieldValidator></td>
                            <td valign="middle">
                                这是一项防止外来电脑自动登记的功能。</td>
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
                <asp:Button ID="btnCreateCode" runat="server" CssClass="button4" OnClick="btnCreateCode_Click"
                    Text=" 生成订单 " ValidationGroup="order" />
                &nbsp;
                <input id="Reset1" runat="server" class="button4" name="Submit22" type="reset" value=" 重 置 " />&nbsp;</div>
        </div>
    </div>
</asp:Content>
