using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;
public partial class Alipay_Return : System.Web.UI.Page
{
    public static string GetMD5(string s, string _input_charset)
    {
        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>

        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }
    public static string[] BubbleSort(string[] r)
    {
        /// <summary>
        /// 冒泡排序法
        /// </summary>

        int i, j; //交换标志 
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++) //最多做R.Length-1趟排序 
        {
            exchange = false; //本趟排序开始前，交换标志应为假

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)　//交换条件
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true; //发生了交换，故将交换标志置为真 
                }
            }

            if (!exchange) //本趟排序未发生交换，提前终止算法 
            {
                break;
            }
        }
        return r;
    }
    //获取远程服务器ATN结果
    public String Get_Http(String a_strUrl, int timeout)
    {
        string strResult;
        try
        {
            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
            myReq.Timeout = timeout;
            HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
            Stream myStream = HttpWResp.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                strBuilder.Append(sr.ReadLine());
            }

            strResult = strBuilder.ToString();
        }
        catch (Exception exp)
        {

            strResult = "错误：" + exp.Message;
        }

        return strResult;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string alipayNotifyURL = System.Configuration.ConfigurationManager.AppSettings["AlipayNotifyURL"];
        string key = System.Configuration.ConfigurationManager.AppSettings["AlipayKey"]; //partner 的对应交易安全校验码（必须填写）
        string _input_charset = System.Configuration.ConfigurationManager.AppSettings["AlipayCharset"];
        string service = System.Configuration.ConfigurationManager.AppSettings["AlipayService"];
        string partner = System.Configuration.ConfigurationManager.AppSettings["Partner"];		//partner合作伙伴id（必须填写）
        alipayNotifyURL = alipayNotifyURL + "service=notify_verify"  + "&partner=" + partner + "&notify_id=" + Request.QueryString["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = Get_Http(alipayNotifyURL, 120000);
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.QueryString;
        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;
        //进行排序；
        string[] Sortedstr = BubbleSort(requestarr);
        //构造待md5摘要字符串 ；
        StringBuilder prestr = new StringBuilder();
        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]]);
                }
                else
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]] + "&");

                }
            }
        }
        prestr.Append(key);
        //生成Md5摘要；
        string mysign = GetMD5(prestr.ToString(), _input_charset);
        string sign = Request.QueryString["sign"];
        //  Response.Write(prestr.ToString());  
        if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确
        {
            //更新自己数据库的订单语句，请自己填写一下
            Response.Write("success");//返回给支付宝消息，成功
        }
        else
        {
            //支付信息失败
            Response.Write("fail");
        }

    }
}
