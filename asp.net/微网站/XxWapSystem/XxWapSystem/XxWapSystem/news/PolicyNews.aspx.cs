using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using XxWapSystem.DAL;

namespace XxWapSystem.news
{
    public partial class PolicyNews : System.Web.UI.Page
    {
        public string colid = "909";
        public string base64 = "eyJzaXRlIjoieXlmY2oiLCJjb3VudCI6IjQiLCJjaGFubmVsSWQiOiI3MzQ5%20Iiwic3RhcnQiOiIwIiwidXNlck5hbWUiOiJ4aW54aWNhaWppIn0=";
        public string sss = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                doDataBind();

                sss = encodeCmd();
                
            }
        }
        private void doDataBind()
        {
            DataSet dt = new DataSet();
            SqlConnection sqlcon;
            string strCon = "Data Source=192.168.5.253\\YYFDCW;Database=yyfcj_data;Uid=yyfcj;Pwd=yyfcj_gov_cn2012";
            sqlcon = new SqlConnection(strCon);


            string sql = "select  top 10 * from AlArticle where IsDeleted=0 AND ColId =909 and Status='3' order by AddTime desc";
            sqlcon.Open();
            SqlDataAdapter command = new SqlDataAdapter(sql, sqlcon);
            command.Fill(dt, "ds");

            this.rptlist.DataSource = dt;
            this.rptlist.DataBind();
            sqlcon.Close();
        }
        public string IsImg(string ImgAddress)
        {
            string msg = string.Empty;
            if (ImgAddress.Length > 0)
            {
                msg = "http://zw.yyfdcw.com/upload/news/" + ImgAddress;
            }
            else
            {
                msg = "../images/no_pic.jpg";
            }
            return msg;
        }
        public string IsShort(string ShortContent, string Content)
        {
            string msg = string.Empty;
            if (ShortContent.Length > 0)
            {
                msg = ShortContent;
            }
            else
            {
                msg = XxWapSystem.DAL.WbText.SqlText(NoHtml(Content), 100);
            }
            return msg;
        }


        public string NoHtml(string Htmlstring) //去除HTML标记 
        {
            //删除脚本 
            Htmlstring = Regex.Replace(Htmlstring, @" <script[^>]*?>.*? </script>", "", RegexOptions.IgnoreCase);
            //删除HTML 
            Htmlstring = Regex.Replace(Htmlstring, @" <(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @" <!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", " <", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\<(?<x>[^\>]*)\>", @"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"\[(?<x>[^\]]*)\]", @"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace(" <", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }





        private static char[] legalChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".ToCharArray();

        public static string encode(byte[] data)
        {
            int start = 0;
            int len = data.Length;
            StringBuilder buf = new StringBuilder(data.Length * 3 / 2);

            int end = len - 3;
            int i = start;
            int n = 0;

            while (i <= end)
            {
                int d = ((((int)data[i]) & 0x0ff) << 16)
                        | ((((int)data[i + 1]) & 0x0ff) << 8)
                        | (((int)data[i + 2]) & 0x0ff);

                buf.Append(legalChars[(d >> 18) & 63]);
                buf.Append(legalChars[(d >> 12) & 63]);
                buf.Append(legalChars[(d >> 6) & 63]);
                buf.Append(legalChars[d & 63]);

                i += 3;

                if (n++ >= 14)
                {
                    n = 0;
                    buf.Append(" ");
                }
            }

            if (i == start + len - 2)
            {
                int d = ((((int)data[i]) & 0x0ff) << 16)
                        | ((((int)data[i + 1]) & 255) << 8);

                buf.Append(legalChars[(d >> 18) & 63]);
                buf.Append(legalChars[(d >> 12) & 63]);
                buf.Append(legalChars[(d >> 6) & 63]);
                buf.Append("=");
            }
            else if (i == start + len - 1)
            {
                int d = (((int)data[i]) & 0x0ff) << 16;

                buf.Append(legalChars[(d >> 18) & 63]);
                buf.Append(legalChars[(d >> 12) & 63]);
                buf.Append("==");
            }

            return buf.ToString();
        }
        public static string encodeCmd()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("userName", "xinxicaiji");
            data.Add("site", "yyfcj");
            data.Add("channelId", "7349");
            data.Add("count", "10");
            data.Add("start", "0");
            string aaa = "{";
            foreach (KeyValuePair<string, string> kvp in data)
            {
                aaa = aaa + "\""+kvp.Key+"\":\""+kvp.Value+"\",";
            }
            aaa = aaa + "}";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(aaa.ToString());
            return encode(bytes);
        }
    }
}
