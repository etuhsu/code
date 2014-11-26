<%@ Page Language="C#" MasterPageFile="~/MPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs"
    EnableEventValidation="false" Inherits="Order" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding: 0 60px; margin-top: 10px;">
        <div style="border: 1px #c1aa97 solid; padding: 10px; width: 760px;">
            <div>
                <span class="STYLE31">
                    <img src="img/proTitle.gif" width="9" height="9" />
                    我的订单</span></div>
            <div style="margin: 10px 0;">
                您的订单号为：<span class="fontT"><asp:Literal ID="ltrOrderCode" runat="server"></asp:Literal></span><br />
                商品总金额为：<span class="fontT">￥<asp:Literal ID="ltrProductAmount" runat="server"></asp:Literal></span><br /> 
                优惠金额为：<span class="fontT">￥<asp:Literal ID="ltrDiscountAmount1" runat="server"></asp:Literal></span><br />   
                运费为：<span class="fontT">￥<asp:Literal ID="ltrTransportFee" runat="server"></asp:Literal></span><br />
                总计金额为：<span class="fontT">￥<asp:Literal ID="ltrTotalAmount" runat="server"></asp:Literal></span>
                <asp:HiddenField ID="hddTotalPayAmount" runat="server" />
                </div>
            <div>
                <asp:Repeater ID="rptProduct" runat="server">
                    <HeaderTemplate>
                        <table class="tableBg" cellspacing="1" cellpadding="2" width="98%" align="center"
                            border="1" bordercolor="#cccccc">
                            <tbody>
                                <tr>
                                    <td class="tdTitleC" width="8%">
                                        序号</td>
                                    <td class="tdTitleC">
                                        商品编号</td>
                                    <td class="tdTitleC">
                                        商品名称</td>
                                    <td class="tdTitleC">
                                        单价(￥)</td>
                                    <td class="tdTitleC">
                                        数量</td>
                                    <td class="tdTitleC">
                                        总价(￥)</td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center" class="tdTitleD">
                                <%#i++ %>
                            </td>
                            <td align="center" class="tdTitleD">
                                <%#Eval("PRD_CODE") %>
                            </td>
                            <td align="center" class="tdTitleD">
                                <%#Eval("PRD_LOCALNAME") %>
                            </td>
                            <td align="center" class="tdTitleD">
                                <%#Math.Round(Convert.ToDecimal(Eval("PRD_MEMBER_PRICE")),2) %>
                            </td>
                            <td align="center" class="tdTitleD">
                                <%#Eval("LPK_QTY") %>
                            </td>
                            <td align="center" class="tdTitleD">
                                <%#Eval("LPK_AMOUNT") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="y_line">
            </div>
            <div>
                <div>
                    &nbsp;&nbsp;&nbsp;<span style="font-weight: bold;">送货地址</span></div>
                <div style="margin: 15px 0 10px 45px; line-height: 20px;">
                    &nbsp;姓名：<asp:Literal ID="ltrName" runat="server"></asp:Literal>
                    <br>
                    &nbsp;地址：<asp:Literal ID="ltrAddress" runat="server"></asp:Literal><br>
                    &nbsp;邮编：<asp:Literal ID="ltrZip" runat="server"></asp:Literal><br>
                    &nbsp;电话：<asp:Literal ID="ltrTel" runat="server"></asp:Literal></div>
                <div class="y_line">
                </div>
                <div>
                    &nbsp;&nbsp;&nbsp;<span style="font-weight: bold;">送货方式</span>&nbsp;&nbsp;&nbsp;</div>
                <div style="margin: 10px 0 10px 70px;">
                    &nbsp;物流快递</div>
                <div class="y_line">
                </div>
                <div>
                    &nbsp;&nbsp;&nbsp;<span style="font-weight: bold;">优惠类型</span></div>
                <div style="margin: 10px 0;">
                    <table class="tableBg" cellspacing="1" cellpadding="2" width="80%" align="center"
                        border="1" bordercolor="#cccccc">
                        <tr>
                            <td class="tdTitleC">
                                名称</td>
                            <td class="tdTitleC">
                                低扣/优惠金额</td>
                        </tr>
                        <tr>
                            <td class="tdTitleD" align="center">
                                <asp:Literal ID="ltrDiscountName" Text="无" runat="server"></asp:Literal></td>
                            <td class="tdTitleD" align="center">
                                <span class="fontT">￥</span><asp:Literal ID="ltrDiscountAmount" Text="0" runat="server"></asp:Literal></td>
                        </tr>
                    </table>
                </div>
                <div class="y_line">
                </div>
                <div>
                    &nbsp;&nbsp;&nbsp;<span style="font-weight: bold;">付款方式</span></div>
                <div style="margin: 10px 0 10px 70px;">
                    <div id="divPayAfter" runat="server">
                        &nbsp;&nbsp;&nbsp;<span style="font-weight: bold;">货到付款</span>
                    </div>
                    <asp:ImageButton ID="imgBtnAlipay" AlternateText="使用支付宝支付" runat="server" ImageUrl="~/img/alipay_bwrx.gif"
                        OnClick="imgBtnAlipay_Click" />
                    <asp:ImageButton ID="imgBtn99Bill" AlternateText="使用快钱支付" runat="server" ImageUrl="~/img/99bill.gif"
                        OnClick="imgBtn99Bill_Click" />
                    <table id="tbPost" width="99%" border="0" cellspacing="1" cellpadding="15" runat="server">
                        <tr>
                            <td align="left">
                                <b>邮局汇款支付<br />
                                    <br />
                                    注意事项：</b><br />
                                (1) 请您一定在汇款单的附言处注明订单号和用户名（非常重要哦！）。<br />
                                (2) 订单确认后请汇款至：收款人姓名：011284ABS公司 收款人地址：011284上海市邮政公司市南信箱 收款人邮编：201201。<br />
                                (3) 注意：ABS目前仅受理"中国邮政汇款单"普通汇款业务。<br />
                                (4) 请您参考如下标准格式填写汇款单：<br />
                                <img alt="邮局汇款单" src="img/huikuan.jpg" style="width: 493px" /><br />
                            </td>
                        </tr>
                    </table>
                    <form id="kqPay" method="post" action="https://www.99bill.com/gateway/recvMerchantInfoAction.htm">
                        <input id="inputCharset" runat="server" type="hidden" />
                        <input id="bgUrl" runat="server" type="hidden" />
                        <input id="version" runat="server" type="hidden" />
                        <input id="language" runat="server" type="hidden" />
                        <input id="signType" runat="server" type="hidden" />
                        <input id="signMsg" runat="server" type="hidden" />
                        <input id="merchantAcctId" runat="server" type="hidden" />
                        <input id="payerName" runat="server" type="hidden" />
                        <input id="payerContactType" runat="server" type="hidden" />
                        <input id="payerContact" runat="server" type="hidden" />
                        <input id="orderId" runat="server" type="hidden" />
                        <input id="orderAmount" runat="server" type="hidden" />
                        <input id="orderTime" runat="server" type="hidden" />
                        <input id="productName" runat="server" type="hidden" />
                        <input id="productNum" runat="server" type="hidden" />
                        <input id="productId" runat="server" type="hidden" />
                        <input id="productDesc" runat="server" type="hidden" />
                        <input id="ext1" runat="server" type="hidden" />
                        <input id="ext2" runat="server" type="hidden" />
                        <input id="payType" runat="server" type="hidden" />
                        <input id="redoFlag" runat="server" type="hidden" />
                        <input id="pid" runat="server" type="hidden" />&nbsp;
                    </form>
                </div>
            </div>
        </div>
</asp:Content>
