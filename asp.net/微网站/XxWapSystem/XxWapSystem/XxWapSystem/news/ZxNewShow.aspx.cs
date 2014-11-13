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
    public partial class ZxNewShow : System.Web.UI.Page
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
                    DataSet dt = new DataSet();
                    SqlConnection sqlcon;
                    string strCon = "Data Source=192.168.5.253\\YYFDCW;database=Zxw_data;uid=zxw_data;pwd=zxw_data_2013";
                    sqlcon = new SqlConnection(strCon);


                    string sql = "select * from Sys_News where iID=" + msgid + "";
                    sqlcon.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sql, sqlcon);
                    command.Fill(dt, "ds");

                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        if (dt.Tables[0].Rows[0]["cDirectLinks"].ToString().Length > 0)
                        {
                            sqlcon.Close();
                            Response.Redirect(dt.Tables[0].Rows[0]["cDirectLinks"].ToString());
                        }
                        else
                        {
                            Title = dt.Tables[0].Rows[0]["cTitle"].ToString();
                            AddTime = DateTime.Parse(dt.Tables[0].Rows[0]["dAddTime"].ToString()).ToString("yyyy-MM-dd");

                            //修改新闻内容中的图片路径不一致问题

                            MsgContent = dt.Tables[0].Rows[0]["cContent"].ToString();
                            // 定义正则表达式用来匹配 img 标签 
                            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
                            // 搜索匹配的字符串 
                            MatchCollection matches = regImg.Matches(dt.Tables[0].Rows[0]["cContent"].ToString());
                            string[] sUrlList = new string[matches.Count];
                            // 取得匹配项列表 
                            foreach (Match match in matches)
                            {
                                if (match.Groups["imgUrl"].Value.ToString().Length > match.Groups["imgUrl"].Value.ToString().Replace("zx.yyfdcw.com", "").Length)
                                {
                                   //
                                }
                                else if (match.Groups["imgUrl"].Value.ToString().Length > match.Groups["imgUrl"].Value.ToString().Replace("http://", "").Length)
                                {
                                   //
                                }
                                else
                                {
                                    MsgContent = MsgContent.Replace(match.Groups["imgUrl"].Value.ToString(),"http://zx.yyfdcw.com" + match.Groups["imgUrl"].Value.ToString());
                                }
                            }
                            ShortContent = dt.Tables[0].Rows[0]["cIntroduction"].ToString();
                            msgcontent_fx = IsShort(dt.Tables[0].Rows[0]["cIntroduction"].ToString(), dt.Tables[0].Rows[0]["cContent"].ToString()).Trim();
                        }
                    }
                    sqlcon.Close();
                }
            }
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

    }
}
