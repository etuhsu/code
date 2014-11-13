using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.zx_ts
{
    public partial class tsList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlstr = "select top 10 * from xyda_ts where bIsAudit=1 order by iID desc";
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();
        }
    }
}
