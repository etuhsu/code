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
    public partial class Images : System.Web.UI.Page
    {
        public int MsgID = 0;                               //楼盘编号
        public string ProjectName = string.Empty;           //楼盘名称
        public string ImageCount = string.Empty;            //图片总数

        StringBuilder ImageMsg = new StringBuilder();       //图片输出
        public string ImageMsgReturn = string.Empty;        //图片输出
        StringBuilder ImageTypeMsg = new StringBuilder();   //图片类型输出
        public string ImageTypeMsgReturn = string.Empty;    //图片类型输出
        public int iBcount = 0;
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

                    //查找除测绘图外所有的图
                    string sql_ImageCount = "select * from Al_BuildingImage where bIsAudit=1 and iProjectID=" + MsgID + " and iTypeID in (select iID from dbo.Al_BuildingImageType where cTypeName<>'测绘图' and bIsAudit=1 )";
                    DataSet dtImageCount = DBHelper.Query(sql_ImageCount);
                    //查找栋数据中的所有预测报告
                    string sql_ImageBuilding = "select * from Al_BuildingYcbgImage where bIsAudit=1 and iBid in (select iID from Al_Building where iProjectID=" + MsgID + " and bIsAudit=1)";
                    DataSet dt_BuildingImageCount = DBHelper.Query(sql_ImageBuilding);
                    int AllImageCount = dtImageCount.Tables[0].Rows.Count + dt_BuildingImageCount.Tables[0].Rows.Count;
                    ImageCount = AllImageCount.ToString();

                    #region 图片输出
                    //除去测绘图以外的所有图片
                    string sql_ImageType = "select * from Al_BuildingImageType where bIsAudit=1 and cTypeName<>'测绘图'";
                    DataSet dtImageType = DBHelper.Query(sql_ImageType);
                    int Counter = 0;          //图片计数器
                    int ImageTypeJsq = 0;       //图片类型计数器
                    int ImageNumQ = 0;
                    int ImageNumH = 0;

                    //先算出有图片的类型
                    string sql_tpyenum = "select iTypeID from dbo.Al_BuildingImage where bIsAudit=1 and iProjectID=" + MsgID + " group by iTypeID";
                    DataSet dt_typenum = DBHelper.Query(sql_tpyenum);
                    if (dt_BuildingImageCount.Tables[0].Rows.Count > 0)
                    {
                        iBcount = dt_typenum.Tables[0].Rows.Count + 1;
                    }
                    else
                    {
                        iBcount = dt_typenum.Tables[0].Rows.Count;
                    }
                    ImageTypeMsg.Append(string.Format("<div id=\"scroller\" size=\"" + iBcount + "\">"));


                    if (dtImageType.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dtImageType.Tables[0].Rows.Count; i++)
                        {
                            string sql_Image = "select * from Al_BuildingImage where bIsAudit=1 and iProjectID=" + MsgID + " and iTypeID=" + dtImageType.Tables[0].Rows[i]["iID"].ToString() + "";
                            DataSet dtImage = DBHelper.Query(sql_Image);
                            if (dtImage.Tables[0].Rows.Count > 0)
                            {
                                ImageNumH = ImageNumQ + dtImage.Tables[0].Rows.Count-1;
                                ImageTypeMsg.Append(string.Format("<a href=\"javascript:void(0)\" class=\"ablue\" id=\"item_" + ImageTypeJsq + "\" num=\"" + ImageNumQ + "_" + ImageNumH + "\">" + dtImageType.Tables[0].Rows[i]["cTypeName"].ToString() + "</a> "));
                                ImageNumQ = ImageNumQ + dtImage.Tables[0].Rows.Count;
                                ImageTypeJsq++;
                                for (int a = 0; a < dtImage.Tables[0].Rows.Count; a++)
                                {
                                    ImageMsg.Append(string.Format("<li id=\"img_" + Counter + "\"><a href=\"http://xx.yyfdcw.com" + dtImage.Tables[0].Rows[a]["cImgAddress"].ToString().Replace("\\", "/") + "\" target=\"_blank\"><img src=\"http://xx.yyfdcw.com" + dtImage.Tables[0].Rows[a]["cThumbnail"].ToString().Replace("\\", "/") + "\" alt=\"" + dtImage.Tables[0].Rows[a]["cTitle"].ToString() + "\" /></a></li>"));
                                    Counter++;
                                }
                            }
                        }
                    }
                    //测绘图输出
                    if (dt_BuildingImageCount.Tables[0].Rows.Count > 0)
                    {
                        ImageNumH = ImageNumQ + dt_BuildingImageCount.Tables[0].Rows.Count - 1;
                        ImageTypeMsg.Append(string.Format("<a href=\"javascript:void(0)\" class=\"ablue\" id=\"item_" + ImageTypeJsq + "\" num=\"" + ImageNumQ + "_" + ImageNumH + "\">测绘图</a> "));
                        ImageNumQ = ImageNumQ + dt_BuildingImageCount.Tables[0].Rows.Count;
                        ImageTypeJsq++;
                        for (int b = 0; b < dt_BuildingImageCount.Tables[0].Rows.Count; b++)
                        {
                            ImageMsg.Append(string.Format("<li id=\"img_" + Counter + "\"><a href=\"http://xx.yyfdcw.com" + dt_BuildingImageCount.Tables[0].Rows[b]["cImgAddress"].ToString().Replace("\\", "/") + "\" target=\"_blank\"><img src=\"http://xx.yyfdcw.com" + dt_BuildingImageCount.Tables[0].Rows[b]["cThumbnail"].ToString().Replace("\\", "/") + "\" alt=\"" + dt_BuildingImageCount.Tables[0].Rows[b]["cTitle"].ToString() + "\" /></a></li>"));
                            Counter++;
                        }
                    }
                    ImageTypeMsg.Append(string.Format("</div>"));
                    ImageMsgReturn = ImageMsg.ToString();
                    ImageTypeMsgReturn = ImageTypeMsg.ToString();
                    #endregion
                }
            }
        }
    }
}
