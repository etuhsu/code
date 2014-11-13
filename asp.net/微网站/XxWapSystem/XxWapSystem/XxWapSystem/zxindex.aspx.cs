using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem
{
    public partial class zxindex : System.Web.UI.Page
    {
        public string DecorateHtml = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select top 10 * from Sys_News where (iTypeID=10) and bIsAudit = 1 order by iID desc";//iTypeID=7 or iTypeID=9 or
            DataSet dt = DBHelperZxw.Query(sql);
            if (dt.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    DecorateHtml = DecorateHtml + "<li id=\"redone\"><a href=\"/news/ZxNewShow.aspx?id=" + dt.Tables["ds"].Rows[i]["iID"].ToString() + "\" target=\"_self\">" + dt.Tables[0].Rows[i]["cTitle"].ToString() + "&nbsp;&nbsp;(<font>" + DateTime.Parse(dt.Tables[0].Rows[i]["dAddTime"].ToString()).ToString("MM-dd") + "</font>)</a></li>";//<span>" + dt.Tables[0].Rows[i]["AddTime"].ToString() + "</span> 
                }
            }
            else
            {
                DecorateHtml = DecorateHtml + "<li id=\"redone\"><span></span> 暂无数据！</li>";
            }
        }
    }
}
