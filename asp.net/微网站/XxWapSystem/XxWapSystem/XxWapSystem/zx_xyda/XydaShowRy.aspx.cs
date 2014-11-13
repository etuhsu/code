using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class XydaShowRy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int NewId = int.Parse(Request["id"]);
            string sqlstr = "select * from xyda_ry where iqyid=" + NewId + " order by iID desc";
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();
        }
    }
}
