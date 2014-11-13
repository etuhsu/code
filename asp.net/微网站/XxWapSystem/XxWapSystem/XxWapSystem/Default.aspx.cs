using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using XxWapSystem.DAL;

namespace XxWapSystem
{
    public partial class _Default : System.Web.UI.Page
    {
        public string HouseNewsHtml = string.Empty;   //房产资讯
        public string DecorateHtml = string.Empty;    //装修资讯
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                doDataBind();
                doDecorateDataBind();
            }
        }

        private void doDataBind()
        {
            string sql = "select  top 5 * from AlArticle where IsDeleted=0 AND ColId in (904,913,917) and Status='3' order by AddTime desc";
            DataSet dt = DBHelper.Query(sql);

            if (dt.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    HouseNewsHtml = HouseNewsHtml + "<li id=\"redone\"><a href=\"/news/NewsShow.aspx?id=" + dt.Tables["ds"].Rows[i]["Id"].ToString() + "\" target=\"_self\">" + dt.Tables[0].Rows[i]["Title"].ToString() + "&nbsp;&nbsp;(<font>" + DateTime.Parse(dt.Tables[0].Rows[i]["AddTime"].ToString()).ToString("MM-dd") + "</font>)</a></li>";//<span>" + dt.Tables[0].Rows[i]["AddTime"].ToString() + "</span> 
                }
            }
            else
            {
                HouseNewsHtml = HouseNewsHtml + "<li id=\"redone\"><span></span> 暂无数据！</li>";
            }
           
        }
        public string IsImg(string ImgAddress)
        {
            string msg = string.Empty;
            if (ImgAddress.Length > 0)
            {
                msg = "http://xx.yyfdcw.com/upload/news/" + ImgAddress;
            }
            else
            {
                msg = "../images/no_pic.jpg";
            }
            return msg;
        }

        private void doDecorateDataBind()
        {
            DataSet dt = new DataSet();
            SqlConnection sqlcon;
            string strCon = "Data Source=192.168.5.253\\YYFDCW;database=Zxw_data;uid=zxw_data;pwd=zxw_data_2013";
            sqlcon = new SqlConnection(strCon);


            string sql = "select  top 5 * from Sys_News where iTypeID='10' and bIsAudit = 1 order by dUpdateTime desc";
            sqlcon.Open();
            SqlDataAdapter command = new SqlDataAdapter(sql, sqlcon);
            command.Fill(dt, "ds");
            if (dt.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    DecorateHtml = DecorateHtml + "<li id=\"redone\"><a href=\"/news/ZxNewShow.aspx?id=" + dt.Tables["ds"].Rows[i]["iID"].ToString() + "\" target=\"_self\">" + dt.Tables[0].Rows[i]["cTitle"].ToString() + "&nbsp;&nbsp;(<font>" + DateTime.Parse(dt.Tables[0].Rows[i]["dAddTime"].ToString()).ToString("MM-dd") + "</font>)</a></li>";//<span>" + dt.Tables[0].Rows[i]["AddTime"].ToString() + "</span> 
                }
            }
            else
            {
                DecorateHtml = DecorateHtml + "<li id=\"redone\"><span></span> 暂无数据！</li>";
            }
        }
    }
}
