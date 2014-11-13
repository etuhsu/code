using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace XxWapSystem.zx_news
{
    public partial class newsajax_zn : System.Web.UI.Page
    {
        public int Pagesize = 10;
        public int Page = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                Page = int.Parse(Request["page"].ToString());
                int PageCount = (Page - 1) * Pagesize;
                string sqlstr = "select top " + Pagesize + " * from Sys_News where iID not in (select top " + PageCount + " iID from Sys_News where (iTypeID=18 or iTypeID=19 or iTypeID=20 or iTypeID=21 or iTypeID=22) and bIsAudit = 1 order by iID desc) and (iTypeID=18 or iTypeID=19 or iTypeID=20 or iTypeID=21 or iTypeID=22) and bIsAudit = 1 order by iID desc";
                DataSet dt = DBHelperZxw.Query(sqlstr);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    //Response.Write(dt.Tables[0].Rows[i]["cTitle"].ToString());
                    string shuchu = string.Format("<li onclick=\"gourl('Show.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "')\"><div class=\"p-img\"><a target=\"_self\" href=\"Show.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\"><img width=\"50\" height=\"50\" alt=\"" + dt.Tables[0].Rows[i]["cTitle"].ToString() + "\" src=\"" + BindPic(dt.Tables[0].Rows[i]["cThumbnail"].ToString()) + "\" /></a></div><div class=\"p-txt\"><div class=\"p-title\"><a target=\"_self\" href=\"Show.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\">" + dt.Tables[0].Rows[i]["cTitle"].ToString() + "</a></div><div class=\"p-summary\">" + NoHtml(dt.Tables[0].Rows[i]["cContent"].ToString()).PadLeft(50) + "</div></div></li>");
                    msg = msg + shuchu;
                }
            }
            Response.Write(msg);
         
        }

        protected string BindPic(string pic)
        {
            string msg = string.Empty;
            if (pic.Length > 5)
            {
                msg = "http://zx.yyfdcw.com" + pic;
            }
            else
            {
                msg = "/images/no_pic.jpg";
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
