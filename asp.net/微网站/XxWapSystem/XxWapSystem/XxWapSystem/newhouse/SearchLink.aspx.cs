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

namespace XxWapSystem.newhouse
{
    public partial class SearchLink : System.Web.UI.Page
    {
        public string type = string.Empty;
        string strWhere = "1=1 and bIsAudit='2'";                //临时过滤器
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["k"] == null)
            {
                return;
            }
            else
            {
                type = HttpUtility.UrlDecode(Request["k"].ToString());
                strWhere = strWhere + " and cProjectName like '%" + type + "%'";
                string sql = "select * from Al_BuildingInfo where " + strWhere + " order by iID desc";
                DataSet dt = DBHelper.Query(sql);
                StringBuilder sb = new StringBuilder();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    sb.Append("{\"error\":\"false\",\"data\":[");
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        if (i == dt.Tables[0].Rows.Count - 1)
                        {
                            sb.Append("{\"id\":\"" + dt.Tables[0].Rows[i]["iID"].ToString() + "\",\"name\":\"" + dt.Tables[0].Rows[i]["cProjectName"].ToString() + "\"}");
                        }
                        else
                        {
                            sb.Append("{\"id\":\"" + dt.Tables[0].Rows[i]["iID"].ToString() + "\",\"name\":\"" + dt.Tables[0].Rows[i]["cProjectName"].ToString() + "\"},");
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
