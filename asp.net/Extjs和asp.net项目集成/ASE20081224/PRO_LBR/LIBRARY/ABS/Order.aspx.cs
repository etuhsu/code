using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Res.BLL;
using Res.Model;
using Res.Library;

public partial class Order : System.Web.UI.Page
{
    protected int i = 1;//序号
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 21;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "生成订单", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }

            if (string.IsNullOrEmpty(Request.QueryString["PUR_ID"]) == false)
            {
                int purId = Convert.ToInt32(Request.QueryString["PUR_ID"]);
                OrderBLL bll = new OrderBLL();
                using (System.Data.SqlClient.SqlDataReader reader = bll.GetWPurchaseByPurId(purId))
                {
                    if (reader.Read())
                    {
                        string address = "";
                        if (reader["PRV_LOCALNAME"] != DBNull.Value)
                            address += reader["PRV_LOCALNAME"].ToString();
                        if (reader["CTY_LOCALNAME"] != DBNull.Value)
                            address += reader["CTY_LOCALNAME"].ToString();
                        if (reader["XPU_ADDRESS"] != DBNull.Value)
                            address += reader["XPU_ADDRESS"].ToString();
                        ltrAddress.Text = address;

                        if (reader["XPU_NAME"] != DBNull.Value)
                            ltrName.Text = reader["XPU_NAME"].ToString();
                        else
                            ltrName.Text = "";

                        if (reader["PUR_CODE"] != DBNull.Value)
                            ltrOrderCode.Text = reader["PUR_CODE"].ToString();
                        else
                            ltrOrderCode.Text = "";
                        if (reader["XPU_TEL"] != DBNull.Value)
                            ltrTel.Text = reader["XPU_TEL"].ToString();
                        else
                            ltrTel.Text = "";

                        decimal orderAmount = 0.00M;//商品总金额

                        if (reader["PUR_AMOUNT"] != DBNull.Value)
                            orderAmount = Convert.ToDecimal(reader["PUR_AMOUNT"]);
                        else
                            orderAmount = 0.00M;

                        decimal discountAmount = 0.00M;//优惠金额
                        if (reader["DSC_AMOUNT"] != DBNull.Value)
                            discountAmount = Convert.ToDecimal(reader["DSC_AMOUNT"]);
                        else
                            discountAmount = 0.00M;

                        decimal transportAmount = 0.00M;//运费
                        if (reader["PUR_EXPAMOUNT"] != DBNull.Value)
                            transportAmount = Convert.ToDecimal(reader["PUR_EXPAMOUNT"]);
                        else
                            transportAmount = 0.00M;

                        ltrProductAmount.Text = Convert.ToString(orderAmount + discountAmount);
                        ltrTotalAmount.Text = Convert.ToString(orderAmount + transportAmount);//合计金额

                        hddTotalPayAmount.Value = orderAmount.ToString();//不包含运费的订单金额

                        ltrTransportFee.Text = transportAmount.ToString();
                        if (reader["XPU_ZIP"] != DBNull.Value)
                            ltrZip.Text = reader["XPU_ZIP"].ToString();
                        else
                            ltrZip.Text = "";
                     
                        ltrDiscountAmount.Text = discountAmount.ToString();
                        ltrDiscountAmount1.Text = discountAmount.ToString();
                        if (reader["DSC_DESC"] != DBNull.Value)
                            ltrDiscountName.Text = reader["DSC_DESC"].ToString();

                        if (reader["PAY_ID"] != null)
                        {
                            int payId = Convert.ToInt32(reader["PAY_ID"]);
                            if (payId == 1)//货到付款
                            {
                                divPayAfter.Visible = true;
                                imgBtnAlipay.Visible = false;
                                imgBtn99Bill.Visible = false;
                                tbPost.Visible = false;
                            }
                            else if (payId == 2)//支付宝

                            {
                                divPayAfter.Visible = false;
                                imgBtnAlipay.Visible = true;
                                imgBtn99Bill.Visible = false;
                                tbPost.Visible = false;
                            }
                            else if (payId == 3)//快钱
                            {
                                decimal amout = Convert.ToDecimal(hddTotalPayAmount.Value.Trim());//订单总金额



                                decimal transportFee = Convert.ToDecimal(ltrTransportFee.Text.Trim());//运费
                                string allAmout = Convert.ToString(Math.Round((amout + transportFee) * 100, 0));//含运费的总金额(已经转化为分为单位)
                                Init99Bill(ltrOrderCode.Text.Trim(), allAmout);

                                divPayAfter.Visible = false;
                                imgBtn99Bill.Visible = true;
                                imgBtnAlipay.Visible = false;
                                tbPost.Visible = false;
                            }
                            else if (payId == 4)//邮局汇款
                            {
                                divPayAfter.Visible = false;
                                imgBtn99Bill.Visible = false;
                                imgBtnAlipay.Visible = false;
                                tbPost.Visible = true;
                            }
                            else
                            {
                                divPayAfter.Visible = false;
                                imgBtnAlipay.Visible = false;
                                imgBtn99Bill.Visible = false;
                                tbPost.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        string script = "<script type='text/javascript'>alert('操作错误！');window.location.href='ConfirmInfo.aspx';</script>";
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
                        return;
                    }
                }
                rptProduct.DataSource = bll.GetWPrdpurList(purId);
                rptProduct.DataBind();
            }
            else
            {
                Response.Redirect("error.aspx?type=1");
            }
        }
    }
    protected void imgBtnAlipay_Click(object sender, ImageClickEventArgs e)
    {
        string userName = ((UserObj)Session["MEB"]).USR_LOGIN;
        if (string.IsNullOrEmpty(userName))
        {
            Response.Redirect("error.aspx?type=2");
        }
        string out_trade_no = ltrOrderCode.Text.Trim();//订单编码

        string gateway = System.Configuration.ConfigurationManager.AppSettings["AlipayNotifyURL"];
        string service = System.Configuration.ConfigurationManager.AppSettings["AlipayService"];
        string partner = System.Configuration.ConfigurationManager.AppSettings["Partner"];
        string sign_type = System.Configuration.ConfigurationManager.AppSettings["AlipaySignType"];

        string subject = "用户:" + userName + " 于 " + DateTime.Now.ToString("yyyy年MM月dd日") + " 在ABS订购了家纺商品"; ;// "用户：13816951336于2008-9-1在ABS订购了家纺商品";//订单名称

        string body = ltrOrderCode.Text.Trim(); //"商品描述";		//body			商品描述    

        string payment_type = System.Configuration.ConfigurationManager.AppSettings["AlipayPaymentType"];

        string price = hddTotalPayAmount.Value.Trim();// ltrTotalAmount.Text.Trim();// "1";//订单金额

        string quantity = "1";//默认1
        string show_url = "www.abs.cn";//当前订单信息显示页面

        string seller_email = System.Configuration.ConfigurationManager.AppSettings["Seller_email"];
        string key = System.Configuration.ConfigurationManager.AppSettings["AlipayKey"];
        string return_url = System.Configuration.ConfigurationManager.AppSettings["Return_url"];
        string notify_url = System.Configuration.ConfigurationManager.AppSettings["Notify_url"];
        string _input_charset = System.Configuration.ConfigurationManager.AppSettings["AlipayCharset"];
        string logistics_type = System.Configuration.ConfigurationManager.AppSettings["Logistics_Type"];
        string logistics_fee = ltrTransportFee.Text;
        //System.Configuration.ConfigurationManager.AppSettings["Logistics_Fee"];
        string logistics_payment = System.Configuration.ConfigurationManager.AppSettings["Logistics_Payment"];

        AlipayLibrary ap = new AlipayLibrary();
        string aliay_url = ap.CreatUrl(
            gateway,
            service,
            partner,
            sign_type,
            out_trade_no,
            subject,
            body,
            payment_type,
            price,
            show_url,
            seller_email,
            key,
            return_url,
            _input_charset,
            notify_url,
            logistics_type,
            logistics_fee,
            logistics_payment,
            quantity
            );

        Response.Redirect(aliay_url);
    }
    protected void imgBtn99Bill_Click(object sender, ImageClickEventArgs e)
    {
        System.Net.WebClient client = new System.Net.WebClient();
        System.Collections.Specialized.NameValueCollection lst = new System.Collections.Specialized.NameValueCollection();

        String key = System.Configuration.ConfigurationManager.AppSettings["99Billkey"];

        string strParam = "";
        strParam = appendParam(strParam, "inputCharset", inputCharset.Value);
        strParam = appendParam(strParam, "bgUrl", bgUrl.Value);
        strParam = appendParam(strParam, "version", version.Value);
        strParam = appendParam(strParam, "language", language.Value);
        strParam = appendParam(strParam, "signType", signType.Value);

        strParam = appendParam(strParam, "merchantAcctId", merchantAcctId.Value);
        strParam = appendParam(strParam, "payerName", payerName.Value);
        strParam = appendParam(strParam, "payerContactType", payerContactType.Value);
        strParam = appendParam(strParam, "payerContact", payerContact.Value);
        strParam = appendParam(strParam, "orderId", orderId.Value);

        strParam = appendParam(strParam, "orderAmount", orderAmount.Value);
        strParam = appendParam(strParam, "orderTime", orderTime.Value);
        strParam = appendParam(strParam, "productName", productName.Value);
        strParam = appendParam(strParam, "productNum", productNum.Value);
        strParam = appendParam(strParam, "productId", productId.Value);

        strParam = appendParam(strParam, "productDesc", productDesc.Value);
        strParam = appendParam(strParam, "ext1", ext1.Value);
        strParam = appendParam(strParam, "ext2", ext2.Value);
        strParam = appendParam(strParam, "payType", payType.Value);
        strParam = appendParam(strParam, "redoFlag", redoFlag.Value);

        strParam = appendParam(strParam, "pid", pid.Value);
        strParam = appendParam(strParam, "key", key);
        strParam = appendParam(strParam, "signMsg", signMsg.Value);


        Response.Redirect("https://www.99bill.com/gateway/recvMerchantInfoAction.htm?" + strParam);
    }
    private void Init99Bill(string strOrderCode, string strOrderAmount)
    {
        //人民币网关账户号
        ///请登录快钱系统获取用户编号，用户编号后加01即为人民币网关账户号。





        merchantAcctId.Value = System.Configuration.ConfigurationManager.AppSettings["99BillmerchantAcctId"];// "1000300079901";

        //人民币网关密钥





        ///区分大小写.请与快钱联系索取
        String key = System.Configuration.ConfigurationManager.AppSettings["99Billkey"];//"1234567897654321";

        //字符集.固定选择值。可为空。





        ///只能选择1、2、3.
        ///1代表UTF-8; 2代表GBK; 3代表gb2312
        ///默认值为1
        inputCharset.Value = System.Configuration.ConfigurationManager.AppSettings["99BillinputCharset"]; //"1";


        //服务器接受支付结果的后台地址.与[pageUrl]不能同时为空。必须是绝对地址。





        ///快钱通过服务器连接的方式将交易结果发送到[bgUrl]对应的页面地址，在商户处理完成后输出的<result>如果为1，页面会转向到<redirecturl>对应的地址。





        ///如果快钱未接收到<redirecturl>对应的地址，快钱将把支付结果GET到[pageUrl]对应的页面。





        bgUrl.Value = System.Configuration.ConfigurationManager.AppSettings["99BillbgUrl"];// "http://www.yoursite.com/receive.aspx";

        //网关版本.固定值





        ///快钱会根据版本号来调用对应的接口处理程序。





        ///本代码版本号固定为v2.0
        version.Value = "v2.0";

        //语言种类.固定选择值。





        ///只能选择1、2、3
        ///1代表中文；2代表英文
        ///默认值为1
        language.Value = "1";

        //签名类型.固定值





        ///1代表MD5签名
        ///当前版本固定为1
        signType.Value = "1";

        //支付人姓名





        ///可为中文或英文字符





        payerName.Value = ((UserObj)Session["MEB"]).USR_LOGIN;//"payerName";

        //支付人联系方式类型.固定选择值





        ///只能选择1
        ///1代表Email
        payerContactType.Value = "1";

        //支付人联系方式





        ///只能选择Email或手机号
        payerContact.Value = "";

        //商户订单号





        ///由字母、数字、或[-][_]组成
        orderId.Value = strOrderCode;//DateTime.Now.ToString("yyyyMMddHHmmss");

        //订单金额
        ///以分为单位，必须是整型数字





        ///比方2，代表0.02元





        orderAmount.Value = strOrderAmount;//"2";

        //订单提交时间
        ///14位数字。年[4位]月[2位]日[2位]时[2位]分[2位]秒[2位]
        ///如；20080101010101
        orderTime.Value = DateTime.Now.ToString("yyyyMMddHHmmss");

        //商品名称
        ///可为中文或英文字符





        productName.Value = "家纺商品";

        //商品数量
        ///可为空，非空时必须为数字
        productNum.Value = "1";

        //商品代码
        ///可为字符或者数字





        productId.Value = "";//-----------------

        //商品描述
        productDesc.Value = "用户:" + ((UserObj)Session["MEB"]).USR_LOGIN + " 于 " + DateTime.Now.ToString("yyyy年MM月dd日") + " 在ABS订购了家纺商品";

        //扩展字段1
        ///在支付结束后原样返回给商户





        ext1.Value = "";

        //扩展字段2
        ///在支付结束后原样返回给商户





        ext2.Value = "";

        //支付方式.固定选择值





        ///只能选择00、10、11、12、13、14
        ///00：组合支付（网关支付页面显示快钱支持的各种支付方式，推荐使用）10：银行卡支付（网关支付页面只显示银行卡支付）.11：电话银行支付（网关支付页面只显示电话支付）.12：快钱账户支付（网关支付页面只显示快钱账户支付）.13：线下支付（网关支付页面只显示线下支付方式）
        payType.Value = "00";


        //同一订单禁止重复提交标志
        ///固定选择值： 1、0
        ///1代表同一订单号只允许提交1次；0表示同一订单号在没有支付成功的前提下可重复提交多次。默认为0建议实物购物车结算类商户采用0；虚拟产品类商户采用1
        redoFlag.Value = "1";

        //快钱的合作伙伴的账户号





        ///如未和快钱签订代理合作协议，不需要填写本参数
        pid.Value = "";



        //生成加密签名串





        ///请务必按照如下顺序和规则组成加密串！
        String signMsgVal = "";
        signMsgVal = appendParam(signMsgVal, "inputCharset", inputCharset.Value);
        signMsgVal = appendParam(signMsgVal, "bgUrl", bgUrl.Value);
        signMsgVal = appendParam(signMsgVal, "version", version.Value);
        signMsgVal = appendParam(signMsgVal, "language", language.Value);
        signMsgVal = appendParam(signMsgVal, "signType", signType.Value);
        signMsgVal = appendParam(signMsgVal, "merchantAcctId", merchantAcctId.Value);
        signMsgVal = appendParam(signMsgVal, "payerName", payerName.Value);
        signMsgVal = appendParam(signMsgVal, "payerContactType", payerContactType.Value);
        signMsgVal = appendParam(signMsgVal, "payerContact", payerContact.Value);
        signMsgVal = appendParam(signMsgVal, "orderId", orderId.Value);
        signMsgVal = appendParam(signMsgVal, "orderAmount", orderAmount.Value);
        signMsgVal = appendParam(signMsgVal, "orderTime", orderTime.Value);
        signMsgVal = appendParam(signMsgVal, "productName", productName.Value);
        signMsgVal = appendParam(signMsgVal, "productNum", productNum.Value);
        signMsgVal = appendParam(signMsgVal, "productId", productId.Value);
        signMsgVal = appendParam(signMsgVal, "productDesc", productDesc.Value);
        signMsgVal = appendParam(signMsgVal, "ext1", ext1.Value);
        signMsgVal = appendParam(signMsgVal, "ext2", ext2.Value);
        signMsgVal = appendParam(signMsgVal, "payType", payType.Value);
        signMsgVal = appendParam(signMsgVal, "redoFlag", redoFlag.Value);
        signMsgVal = appendParam(signMsgVal, "pid", pid.Value);
        signMsgVal = appendParam(signMsgVal, "key", key);
        signMsg.Value = FormsAuthentication.HashPasswordForStoringInConfigFile(signMsgVal, "MD5").ToUpper();
    }

    //功能函数。将变量值不为空的参数组成字符串
    String appendParam(String returnStr, String paramId, String paramValue)
    {

        if (returnStr != "")
        {

            if (paramValue != "")
            {

                returnStr += "&" + paramId + "=" + paramValue;
            }

        }
        else
        {

            if (paramValue != "")
            {
                returnStr = paramId + "=" + paramValue;
            }
        }

        return returnStr;
    }
    //功能函数。将变量值不为空的参数组成字符串。结束




}
