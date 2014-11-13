using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_ts
{
    public partial class tsShow : System.Web.UI.Page
    {
        public string ctitle = string.Empty;
        public string cname = string.Empty;
        public string cqyname = string.Empty;
        public string ccontent = string.Empty;
        public string cfruit = string.Empty;
        public string daddtime = string.Empty;
        public string inID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int NewId = int.Parse(Request["id"].ToString());

                string sqlstr = "select * from xyda_ts where iID=" + NewId;
                DataSet dt = DBHelperZxw.Query(sqlstr);
                ctitle = dt.Tables[0].Rows[0]["ctitle"].ToString();
                cname = dt.Tables[0].Rows[0]["cname"].ToString();
                cqyname = dt.Tables[0].Rows[0]["cqyname"].ToString();
                ccontent = dt.Tables[0].Rows[0]["ccontent"].ToString();
                cfruit = dt.Tables[0].Rows[0]["cfruit"].ToString();
                daddtime = dt.Tables[0].Rows[0]["dAddTime"].ToString();
            }
        }
    }
}
