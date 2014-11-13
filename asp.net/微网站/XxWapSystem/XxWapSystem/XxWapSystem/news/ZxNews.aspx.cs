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
    public partial class ZxNews : System.Web.UI.Page
    {
        public string sss = string.Empty;
        public string colid = "10";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                doDataBind();

            }
        }
        private void doDataBind()
        {
            DataSet dt = new DataSet();
            SqlConnection sqlcon;
            string strCon = "Data Source=192.168.5.253\\YYFDCW;database=Zxw_data;uid=zxw_data;pwd=zxw_data_2013";
            sqlcon = new SqlConnection(strCon);


            string sql = "select  top 10 * from Sys_News where iTypeID='10' and bIsAudit = 1 order by dUpdateTime desc";
            sqlcon.Open();
            SqlDataAdapter command = new SqlDataAdapter(sql, sqlcon);
            command.Fill(dt, "ds");

            this.rptlist.DataSource = dt;
            this.rptlist.DataBind();
            sqlcon.Close();
        }

        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <param name="ImgAddress"></param>
        /// <returns></returns>
        public string IsImg(string ImgAddress, string MsContent)
        {
            string msg = string.Empty;
            if (ImgAddress.Length > 0)
            {
                msg = "http://zx.yyfdcw.com" + ImgAddress;
            }
            else
            {
                string[] ImgUrl = GetHtmlImageUrlList(MsContent);
                if (ImgUrl.Length > 0)
                {
                    if (ImgUrl[0].ToString().Length > ImgUrl[0].ToString().Replace("zx.yyfdcw.com", "").Length)
                    {
                        msg = ImgUrl[0];
                    }
                    else if (ImgUrl[0].ToString().Length > ImgUrl[0].ToString().Replace("http://", "").Length)
                    {
                        msg = ImgUrl[0];
                    }
                    else
                    {
                        msg = "http://zx.yyfdcw.com" + ImgUrl[0];
                    }
                }
                else
                {
                    msg = "../images/no_pic.jpg";
                }
            }
            return msg;
        }

        /// <summary>
        /// 获取导读
        /// </summary>
        /// <param name="ShortContent">导读</param>
        /// <param name="Content">新闻内容</param>
        /// <returns></returns>
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

        /// <summary> 
        /// 取得HTML中所有图片的 URL。 
        /// </summary> 
        /// <param name="sHtmlText">HTML代码</param> 
        /// <returns>图片的URL列表</returns> 
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签 
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串 
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表 
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            return sUrlList;
        }

    }
}
