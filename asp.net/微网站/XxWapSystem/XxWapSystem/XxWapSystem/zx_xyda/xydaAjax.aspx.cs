using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class xydaAjax : System.Web.UI.Page
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
                string WhereStr = BuileWhere();
                string sqlstr = "select top " + Pagesize + " * from xyda_jb where iID not in (select top " + PageCount + " iID from xyda_jb where 1=1 " + WhereStr + " order by iID desc)" + WhereStr + " order by iID desc";
                DataSet dt = DBHelperZxw.Query(sqlstr);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    string shuchu = string.Format("<li onclick=\"gourl('XydaShowJb.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "')\"><div class=\"p-txt\"><div class=\"p-title\"><a target=\"_self\" href=\"XydaShowJb.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\">" + dt.Tables[0].Rows[i]["cqyname"].ToString() + "</a></div><div class=\"p-summary\">" + dt.Tables[0].Rows[i]["ccredit"].ToString() + "(" + dt.Tables[0].Rows[i]["icreditvalue"].ToString() + "分)</div></div></li>");
                    msg = msg + shuchu;
                }
            }
            Response.Write(msg);

        }

        private string BuileWhere()
        {
            string StrWhere = string.Empty;
            string sjcname = Request["jcname"];
            string ty = Request["ty"];
            string requestc = Request["c"];

            string tystr = string.Empty;
            if (!string.IsNullOrEmpty(ty))
            {
                switch (ty)
                {
                    case "1":
                        tystr = "壹级";
                        break;
                    case "2":
                        tystr = "贰级";
                        break;
                    case "3":
                        tystr = "叁级";
                        break;
                    case "4":
                        tystr = "暂定";
                        break;
                }
            }

            string cstr = string.Empty;
            if (!string.IsNullOrEmpty(requestc))
            {
                switch (requestc)
                {
                    case "1":
                        cstr = "A级";
                        break;
                    case "2":
                        cstr = "B级";
                        break;
                    case "3":
                        cstr = "C级";
                        break;
                    case "4":
                        cstr = "D级";
                        break;
                }
            }
            if (!Equals(sjcname, null))
            {
                StrWhere += " and cqyname like '%" + sjcname + "%'";
            }
            if (!Equals(ty, null) && ty != "0")
            {
                StrWhere += " and cgrade ='" + tystr + "'";
            }
            if (!Equals(requestc, null) && requestc != "0")
            {
                StrWhere += " and ccredit ='" + cstr + "'";
            }

            return StrWhere;
        }

    }
}
