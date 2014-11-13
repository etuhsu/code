using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_ts
{
    public partial class tsAjax : System.Web.UI.Page
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
                string sqlstr = "select top " + Pagesize + " * from xyda_ts where iID not in (select top " + PageCount + " iID from xyda_ts order by iID desc) order by iID desc";
                DataSet dt = DBHelperZxw.Query(sqlstr);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    string shuchu = string.Format("<li onclick=\"gourl('tsShow.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "')\"><div class=\"p-txt\"><div class=\"p-title\"><a target=\"_self\" href=\"tsShow.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\">投诉标题:" + dt.Tables[0].Rows[i]["ctitle"].ToString() + "</a></div><div class=\"p-summary\">投诉对象:" + dt.Tables[0].Rows[i]["cqyname"].ToString() + "<br>时间:" + dt.Tables[0].Rows[i]["daddtime"].ToString() + "</div></div></li>");
                    msg = msg + shuchu;
                }
            }
            Response.Write(msg);

        }
    }
}
