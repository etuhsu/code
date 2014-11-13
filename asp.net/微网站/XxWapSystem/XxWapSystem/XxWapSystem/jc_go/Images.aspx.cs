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

namespace XxWapSystem.jc_go
{
    public partial class Images : System.Web.UI.Page
    {
        public int MsgID = 0;                               //楼盘编号
        public string ProjectName = string.Empty;           //楼盘名称
        public string ImageCounts = string.Empty;            //图片总数

        StringBuilder ImageMsg = new StringBuilder();       //图片输出
        public string ImageMsgReturn = string.Empty;        //图片输出
        public int iBcount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                MsgID = WbText.IsNumber(Request.QueryString["ID"].ToString()) ? int.Parse(Request.QueryString["ID"]) : 0;
                if (!IsPostBack)
                {
                    

                    #region 图片输出
                    string sql_Image = "select * from Sys_ProductImages where iProductID=" + MsgID;
                    DataSet dtImage = DBHelperZxw.Query(sql_Image);
                    int ImageCount = dtImage.Tables[0].Rows.Count;
                    ImageCounts = ImageCount.ToString();
                    ProjectName = dtImage.Tables[0].Rows[0]["cImageTitle"].ToString();
                    //if (ImageCount > 0)
                    //{
                    //    iBcount = dtImage.Tables[0].Rows.Count + 1;
                    //}
                    //else
                    //{
                    //    iBcount = dtImage.Tables[0].Rows.Count;
                    //}
                    //ImageTypeMsg.Append(string.Format("<div id=\"scroller\" size=\"" + iBcount + "\">"));


                    if (ImageCount > 0)
                    {
                        int Counter = 0;
                            for (int a = 0; a < dtImage.Tables[0].Rows.Count; a++)
                            {
                                ImageMsg.Append(string.Format("<li id=\"img_" + Counter + "\"><a href=\"http://zx.yyfdcw.com" + dtImage.Tables[0].Rows[a]["cProductThumbnail"].ToString().Replace("\\", "/") + "\" target=\"_blank\"><img src=\"http://zx.yyfdcw.com" + dtImage.Tables[0].Rows[a]["cProductThumbnail"].ToString().Replace("\\", "/") + "\" alt=\"" + dtImage.Tables[0].Rows[a]["cImageTitle"].ToString() + "\" /></a></li>"));
                                Counter++;
                            }
                    }
                    ImageMsgReturn = ImageMsg.ToString();
                    #endregion
                }
            }
        }
    }
}
