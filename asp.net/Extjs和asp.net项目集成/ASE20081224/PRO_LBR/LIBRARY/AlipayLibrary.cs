using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
namespace Res.Library
{
    public class AlipayLibrary
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
        /// <summary>
        /// 创建支付宝URL
        /// </summary>
        /// <param name="gateway">支付宝http地址</param>
        /// <param name="service">接口名称</param>
        /// <param name="partner">合作伙伴ID</param>
        /// <param name="sign_type">签名方式</param>
        /// <param name="out_trade_no">外部交易号</param>
        /// <param name="subject">商品名称</param>
        /// <param name="body">商品描述</param>
        /// <param name="payment_type">支付类型  1:商品购买 2:服务购买 3:网络拍卖 4:捐赠 5:邮费补偿 6:奖金</param>
        /// <param name="total_fee">总计费用</param>
        /// <param name="show_url">商品展示网址</param>
        /// <param name="seller_email">卖家Email</param>
        /// <param name="key">key</param>
        /// <param name="return_url">返回URL</param>
        /// <param name="_input_charset">参数编码字符集</param>
        /// <param name="notify_url">通知URL</param>
        /// <param name="logistics_type">物流类型  VIRTUAL:虚拟物品  POST:平邮 EMS:EMS   EXPRESS:其他快递公司</param>
        /// <param name="logistics_fee">物流费用</param>
        /// <param name="logistics_payment">物流支付类型  SELLER_PAY:卖家支付  BUYER_PAY:买家支付  BUYER_PAY_AFTER_RECEIVE:货到付款</param>
        /// <param name="quantity">购买数量</param>
        /// <returns></returns>
        public string CreatUrl(
            string gateway,
            string service,
            string partner,
            string sign_type,
            string out_trade_no,
            string subject,
            string body,
            string payment_type,
            string total_fee,
            string show_url,
            string seller_email,
            string key,
            string return_url,
            string _input_charset,
            string notify_url,
            string logistics_type,
            string logistics_fee,
            string logistics_payment,
            string quantity
            )
        {
            int i;

            //构造数组；
            string[] Oristr ={ 
                "service="+service, 
                "partner=" + partner, 
                "subject=" + subject, 
                "body=" + body, 
                "out_trade_no=" + out_trade_no, 
                "price=" + total_fee, 
                "show_url=" + show_url,  
                "payment_type=" + payment_type, 
                "seller_email=" + seller_email, 
                "notify_url=" + notify_url,
                "_input_charset="+_input_charset,          
                "return_url=" + return_url,
                "quantity="+quantity,
                "logistics_type="+logistics_type,
                "logistics_fee="+logistics_fee ,
                "logistics_payment="+logistics_payment
                };

            //进行排序；
            string[] Sortedstr = BubbleSort(Oristr);


            //构造待md5摘要字符串 ；

            StringBuilder prestr = new StringBuilder();

            for (i = 0; i < Sortedstr.Length; i++)
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i]);

                }
                else
                {

                    prestr.Append(Sortedstr[i] + "&");
                }

            }

            prestr.Append(key);

            //生成Md5摘要；
            string sign = GetMD5(prestr.ToString(), _input_charset);

            //构造支付Url；
            char[] delimiterChars = { '=' };
            StringBuilder parameter = new StringBuilder();
            parameter.Append(gateway);
            for (i = 0; i < Sortedstr.Length; i++)
            {

                parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" + HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
            }

            parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

            //返回支付Url；
            return parameter.ToString();

        }
    }
}
