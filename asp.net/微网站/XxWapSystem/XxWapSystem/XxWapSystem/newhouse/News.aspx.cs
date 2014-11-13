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
    public partial class News : System.Web.UI.Page
    {
        public int MsgID = 0;         //楼盘编号
        public string ProjectName = string.Empty;   //楼盘名称
        public string Xzuobiao = string.Empty;        //当前楼盘x坐标
        public string Yzuobiao = string.Empty;        //当前楼盘y坐标
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                MsgID = WbText.IsNumber(Request.QueryString["ID"].ToString()) ? int.Parse(Request.QueryString["ID"]) : 0;
                XxWapSystem.BLL.Al_BuildingInfo bll = new XxWapSystem.BLL.Al_BuildingInfo();
                XxWapSystem.Model.Al_BuildingInfo mod = new XxWapSystem.Model.Al_BuildingInfo();
                if (!IsPostBack)
                {
                    mod = bll.GetModel(MsgID);
                    ProjectName = mod.cProjectName;
                    doDataBind();
                }
            }
        }

        private void doDataBind()
        {
            string sql = "select * from AlArticle where IsDeleted=0 AND ColId in (913,904) and Status='3' and ViewEndTime='" + MsgID + "' order by AddTime desc";
            DataSet dt = DBHelper.Query(sql);

            this.rptZxdt.DataSource = dt;
            this.rptZxdt.DataBind();
        }
    }
}
