using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class RyxydaAjax : System.Web.UI.Page
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
                string sqlstr = "select top " + Pagesize + " * from xyda_ry where iID not in (select top " + PageCount + " iID from xyda_ry order by iID desc) order by iID desc";
                DataSet dt = DBHelperZxw.Query(sqlstr);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    string shuchu = string.Format("<li onclick=\"gourl('XydaShowRyxx.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "')\"><div class=\"p-txt\"><div class=\"p-title\"><a target=\"_self\" href=\"XydaShowJb.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\">姓名：" + dt.Tables[0].Rows[i]["cName"].ToString() + "</a></div><div class=\"p-summary\">企业名称：" + qyname(dt.Tables[0].Rows[i]["iqyID"].ToString()) + "</div></div></li>");
                    msg = msg + shuchu;
                }
            }
            Response.Write(msg);

        }
        public string qyname(string uid)
        {
            string msg = string.Empty;
            string sqlstr = "select * from xyda_jb where iID=" + uid;
            DataSet dt = DBHelperZxw.Query(sqlstr);
            if (dt.Tables[0].Rows.Count > 0)
            {
                msg = dt.Tables[0].Rows[0]["cqyname"].ToString();
            }
            else
            {
                msg = "";
            }
            return msg;
        }
    }

}
