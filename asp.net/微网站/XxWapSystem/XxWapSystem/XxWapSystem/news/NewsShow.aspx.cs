using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using XxWapSystem.DAL;

namespace XxWapSystem.news
{
    public partial class NewsShow : System.Web.UI.Page
    {
        public string Title = string.Empty;
        public string MsgContent = string.Empty;
        public string AddTime = string.Empty;
        public string ShortContent = string.Empty;
        public string msgcontent_fx = string.Empty;

        public string msgid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] == null)
                return;
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                

                if (!IsPostBack)
                {
                    msgid = Request.QueryString["ID"].ToString();
                    string sql = "select * from AlArticle where id=" + msgid + "";
                    DataSet dt = DBHelper.Query(sql);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        Title = dt.Tables[0].Rows[0]["Title"].ToString();
                        AddTime = DateTime.Parse(dt.Tables[0].Rows[0]["AddTime"].ToString()).ToString("yyyy-MM-dd");
                        MsgContent = dt.Tables[0].Rows[0]["Content"].ToString();
                        msgcontent_fx = IsShort(dt.Tables[0].Rows[0]["ShortContent"].ToString(), dt.Tables[0].Rows[0]["Content"].ToString()).Trim();
                        ShortContent = dt.Tables[0].Rows[0]["ShortContent"].ToString();
                    }
                }
            }
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


        /// <summary>
        /// 去除html标记
        /// </summary>
        /// <param name="Htmlstring">html</param>
        /// <returns></returns>
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
    }
}
