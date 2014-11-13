using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_xyda
{
    public partial class XydaShowJs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int NewId = int.Parse(Request["id"]);
            string sqlstr = "select * from xyda_jf where iqyid=" + NewId + " and ctype='警示信息' and (bIsAudit = 1) order by dCreatetime desc";
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.Repeater1.DataSource = dt;
            this.Repeater1.DataBind();
        }
    }
}
