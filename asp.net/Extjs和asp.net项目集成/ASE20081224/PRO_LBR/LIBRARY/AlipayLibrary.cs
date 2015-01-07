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
            /// ��ASP���ݵ�MD5�����㷨
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
            /// ð������
            /// </summary>

            int i, j; //������־ 
            string temp;

            bool exchange;

            for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
            {
                exchange = false; //��������ʼǰ��������־ӦΪ��

                for (j = r.Length - 2; j >= i; j--)
                {
                    if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)��//��������
                    {
                        temp = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = temp;

                        exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                    }
                }

                if (!exchange) //��������δ������������ǰ��ֹ�㷨 
                {
                    break;
                }

            }
            return r;
        }
        /// <summary>
        /// ����֧����URL
        /// </summary>
        /// <param name="gateway">֧����http��ַ</param>
        /// <param name="service">�ӿ�����</param>
        /// <param name="partner">�������ID</param>
        /// <param name="sign_type">ǩ����ʽ</param>
        /// <param name="out_trade_no">�ⲿ���׺�</param>
        /// <param name="subject">��Ʒ����</param>
        /// <param name="body">��Ʒ����</param>
        /// <param name="payment_type">֧������  1:��Ʒ���� 2:������ 3:�������� 4:���� 5:�ʷѲ��� 6:����</param>
        /// <param name="total_fee">�ܼƷ���</param>
        /// <param name="show_url">��Ʒչʾ��ַ</param>
        /// <param name="seller_email">����Email</param>
        /// <param name="key">key</param>
        /// <param name="return_url">����URL</param>
        /// <param name="_input_charset">���������ַ���</param>
        /// <param name="notify_url">֪ͨURL</param>
        /// <param name="logistics_type">��������  VIRTUAL:������Ʒ  POST:ƽ�� EMS:EMS   EXPRESS:������ݹ�˾</param>
        /// <param name="logistics_fee">��������</param>
        /// <param name="logistics_payment">����֧������  SELLER_PAY:����֧��  BUYER_PAY:���֧��  BUYER_PAY_AFTER_RECEIVE:��������</param>
        /// <param name="quantity">��������</param>
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

            //�������飻
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

            //��������
            string[] Sortedstr = BubbleSort(Oristr);


            //�����md5ժҪ�ַ��� ��

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

            //����Md5ժҪ��
            string sign = GetMD5(prestr.ToString(), _input_charset);

            //����֧��Url��
            char[] delimiterChars = { '=' };
            StringBuilder parameter = new StringBuilder();
            parameter.Append(gateway);
            for (i = 0; i < Sortedstr.Length; i++)
            {

                parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" + HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
            }

            parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

            //����֧��Url��
            return parameter.ToString();

        }
    }
}
