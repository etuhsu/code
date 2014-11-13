using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XxWapSystem.DAL;

namespace XxWapSystem.xyda
{
    public partial class RYSearchLink : System.Web.UI.Page
    {
        public string type = string.Empty;
        string strWhere = "1=1";                //临时过滤器
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["k"] == null)
            {
                return;
            }
            else
            {
                type = HttpUtility.UrlDecode(Request["k"].ToString());
                strWhere = strWhere + " and cName like '%" + type + "%'";
                string sql = "select * from xyda_ry where " + strWhere + " order by iID desc";
                DataSet dt = DBHelperZxw.Query(sql);
                StringBuilder sb = new StringBuilder();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    sb.Append("{\"error\":\"false\",\"data\":[");
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        if (i == dt.Tables[0].Rows.Count - 1)
                        {
                            sb.Append("{\"id\":\"" + dt.Tables[0].Rows[i]["iID"].ToString() + "\",\"name\":\"" + dt.Tables[0].Rows[i]["cName"].ToString() + "\"}");
                        }
                        else
                        {
                            sb.Append("{\"id\":\"" + dt.Tables[0].Rows[i]["iID"].ToString() + "\",\"name\":\"" + dt.Tables[0].Rows[i]["cName"].ToString() + "\"},");
                        }
                    }
                    sb.Append("]}");
                }
                else
                {
                    sb.Append("{\"error\":\"true\",\"data\":\"\"}");
                }
                

                Response.Write(sb.ToString());
            }
        }
    }
}
