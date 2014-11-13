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

namespace XxWapSystem.sellhouse
{
    public partial class Map : System.Web.UI.Page
    {
        public int MsgID = 0;         //编号
        public string Title = string.Empty;   //标题
        public string Xzuobiao = string.Empty;        //当前x坐标
        public string Yzuobiao = string.Empty;        //当前y坐标
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                MsgID = WbText.IsNumber(Request.QueryString["ID"].ToString()) ? int.Parse(Request.QueryString["ID"]) : 0;
                
                if (!IsPostBack)
                {
                    string sql_Cha = "select * from Al_ES_Sale where ID=" + MsgID + "";
                    DataSet dtSet = DBHelper.Query(sql_Cha);

                    DataTable dt = dtSet.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        Title = dr["Title"].ToString();
                        Yzuobiao = dr["cMaplat"].ToString();//对应数据库cMapLat字段
                        Xzuobiao = dr["cMaplng"].ToString();//对应数据库cMaplng字段
                    }
                    
                }
            }
        }
    }
}
