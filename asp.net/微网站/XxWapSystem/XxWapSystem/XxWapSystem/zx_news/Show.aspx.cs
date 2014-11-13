using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace XxWapSystem.zx_news
{
    public partial class Show : System.Web.UI.Page
    {
        public string Ccoutent = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int NewId = int.Parse(Request["id"].ToString());

                string sqlstr = "select * from Sys_News where iID="+NewId;
                DataSet dt = DBHelperZxw.Query(sqlstr);
                this.lblTitle.Text = dt.Tables[0].Rows[0]["cTitle"].ToString();
                this.lblTitle2.Text = dt.Tables[0].Rows[0]["cTitle"].ToString();
                this.lblDate.Text = dt.Tables[0].Rows[0]["dAddTime"].ToString();
                Ccoutent = dt.Tables[0].Rows[0]["cContent"].ToString();
                this.labcontent.Text = dt.Tables[0].Rows[0]["cContent"].ToString().Replace("/html/", "http://zx.yyfdcw.com/html/");
                string sPic = dt.Tables[0].Rows[0]["cThumbnail"].ToString();
                if (sPic.Length > 5)
                {
                    this.lblPic.Text = string.Format("<div class=\"detail_pic\"><div class=\"switch_pic\"><img src=\"http://zx.yyfdcw.com/" + sPic + "\" width=\"240\" height=\"158\"></div><div class=\"switch_indicators\"></div></div>");
                }
                else {
                    this.lblPic.Text = "";
                }
            }
            
        }
    }
}
