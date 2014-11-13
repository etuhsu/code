using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class XydaShowRyxx : System.Web.UI.Page
    {
        public string cqyname = string.Empty;     //公司名称
        public string cType = string.Empty;
        public string cName = string.Empty;
        public string ccredit = string.Empty;
        public string csex = string.Empty;
        public string cgz = string.Empty;
        public string cjb = string.Empty;
        public string czjbh = string.Empty;
        public string cfzsj = string.Empty;
        public string cfzjg = string.Empty;
        public string cThumbnail = string.Empty;
        public string czw = string.Empty;
        public string czc = string.Empty;
        public string cxl = string.Empty;
        public string cby = string.Empty;
        public string czl = string.Empty;
        public string cjl = string.Empty;
        public string dAddTime = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int NewId = int.Parse(Request["id"]);
                string sqlstr = "select * from xyda_ry where iID=" + NewId;
                DataSet dt = DBHelperZxw.Query(sqlstr);

                cqyname = qyname(dt.Tables[0].Rows[0]["iqyID"].ToString());
                cType = dt.Tables[0].Rows[0]["cType"].ToString();
                cName = dt.Tables[0].Rows[0]["cName"].ToString();
                ccredit = dt.Tables[0].Rows[0]["ccredit"].ToString();
                csex = dt.Tables[0].Rows[0]["csex"].ToString();
                cgz = dt.Tables[0].Rows[0]["cgz"].ToString();
                cjb = dt.Tables[0].Rows[0]["cjb"].ToString();
                czjbh = dt.Tables[0].Rows[0]["czjbh"].ToString();
                cfzsj = dt.Tables[0].Rows[0]["dCreateTime"].ToString();
                cfzjg = dt.Tables[0].Rows[0]["cfzjg"].ToString();
                cThumbnail = dt.Tables[0].Rows[0]["cThumbnail"].ToString();
                czw = dt.Tables[0].Rows[0]["czw"].ToString();
                czc = dt.Tables[0].Rows[0]["czc"].ToString();
                cxl = dt.Tables[0].Rows[0]["cxl"].ToString();
                cjl = dt.Tables[0].Rows[0]["cjl"].ToString();
                dAddTime = dt.Tables[0].Rows[0]["dAddTime"].ToString();
            }
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
