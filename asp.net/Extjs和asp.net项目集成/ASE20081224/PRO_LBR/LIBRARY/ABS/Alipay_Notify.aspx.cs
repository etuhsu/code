﻿using System;
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

public partial class Alipay_Notify : System.Web.UI.Page
{
    public static string GetMD5(string s)
    {
        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding("utf-8").GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }
    public static string[] BubbleSort(string[] R)
    {
        /// <summary>
        /// 冒泡排序法
        /// </summary>

        int i, j; //交换标志 
        string temp;

        bool exchange;

        for (i = 0; i < R.Length; i++) //最多做R.Length-1趟排序 
        {
            exchange = false; //本趟排序开始前，交换标志应为假

            for (j = R.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(R[j + 1], R[j]) < 0)　//交换条件
                {
                    temp = R[j + 1];
                    R[j + 1] = R[j];
                    R[j] = temp;

                    exchange = true; //发生了交换，故将交换标志置为真 
                }
            }

            if (!exchange) //本趟排序未发生交换，提前终止算法 
            {
                break;
            }
        }
        return R;
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
        string partner = System.Configuration.ConfigurationManager.AppSettings["Partner"];		//partner合作伙伴id（必须填写）
        alipayNotifyURL = alipayNotifyURL + "service=notify_verify" + "&partner=" + partner + "&notify_id=" + Request.QueryString["notify_id"];

        string responseTxt = Get_Http(alipayNotifyURL, 120000);
        int i;
        NameValueCollection coll;
        //Load Form variables into NameValueCollection variable.
        coll = Request.Form;
        // Get names of all forms into a string array.
        String[] requestarr = coll.AllKeys;
        //进行排序；
        string[] Sortedstr = BubbleSort(requestarr);
        //构造待md5摘要字符串 ；
        string prestr = "";
        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]];
                }
                else
                {
                    prestr = prestr + Sortedstr[i] + "=" + Request.Form[Sortedstr[i]] + "&";
                }
            }
        }
        prestr = prestr + key;
        string mysign = GetMD5(prestr);
        string sign = Request.Form["sign"];
        if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确
        {
            if (Request.Form["trade_status"] == "WAIT_SELLER_SEND_GOODS")//   判断支付状态TRADE_FINISHED（文档中有枚举表可以参考）            
            {
                //更新自己数据库的订单语句，请自己填写一下
                Response.Write("success");     //返回给支付宝消息，成功
            }
            else
            {
                Response.Write("fail");////返回失败信息给支付宝
            }
        }

    }
}
