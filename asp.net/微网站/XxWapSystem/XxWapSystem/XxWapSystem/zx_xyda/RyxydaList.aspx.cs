using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class RyxydaList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sname = Request["name"];
            string sqlstr = string.Empty;
            if (!Equals(sname, null))
            {
                sqlstr = "select * from xyda_ry where cName like '%" + sname.ToString() + "%' order by iID desc";
            }
            else
            {
                sqlstr = "select top 10 * from xyda_ry order by iID desc";
            }
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();
        }

        public string qyname(string uid)
        {
            string msg = string.Empty;
            string sqlstr = "select * from xyda_jb where iID=" + uid ;
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
