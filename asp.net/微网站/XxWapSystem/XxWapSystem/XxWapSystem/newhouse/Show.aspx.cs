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
    public partial class Show : System.Web.UI.Page
    {
        public int MsgID = 0;         //楼盘编号
        public string ProjectName = string.Empty;   //楼盘名称
        public string SEODescription = string.Empty;//SEODescription 描述信息
        public string ImageCount = string.Empty;    //图片总数
        public string BuildingPrice = string.Empty;   //该楼盘价格
        public string OpenTime = string.Empty;        //开盘时间
        public string DecorateInfo = string.Empty;    //装修情况
        public string Jzlb = string.Empty;            //建筑类别
        public string Hxmj = string.Empty;            //户型面积
        public string Address = string.Empty;         //项目地址
        public string Thumbnail = string.Empty;       //图片地址
        public string SaleAddress = string.Empty;     //销售地址
        public string SalePhone = string.Empty;       //销售电话
        public string Kfs = string.Empty;             //开发商
        public string Sjdw = string.Empty;            //设计单位
        public string Cjdw = string.Empty;            //承建单位
        public string Wydw = string.Empty;            //物业单位
        public string Zdmj = string.Empty;            //占地面积
        public string Jzmj = string.Empty;            //总规划建筑面积
        public string Zds = string.Empty;             //总栋数
        public string Zhs = string.Empty;             //总户数
        public string Ztz = string.Empty;             //总投资
        public string Lhl = string.Empty;             //绿化率
        public string Rjl = string.Empty;             //容积率
        public string Gtsyqz = string.Empty;          //国土使用权证
        public string Tdsynx = string.Empty;          //土地使用年限
        public string Jsgcghxkz = string.Empty;       //建设工程规划许可证
        public string Jsydghxkz = string.Empty;       //建设用地规划许可证

        public string ProjectInfo = string.Empty;     //项目介绍
        public string Jfbz = string.Empty;            //交房标准

        public string Xzuobiao = string.Empty;        //当前楼盘x坐标
        public string Yzuobiao = string.Empty;        //当前楼盘y坐标
        public string Ptxx = string.Empty;            //配套信息

        //栋信息
        public string BuildingInfoHtml = string.Empty;

        int AreaID = 0;                             //所属地区编号
        public string AreaName = string.Empty;      //所属区域
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
                    //描述信息
                    if (mod.cCommentInfo.Length > 260)
                    {
                        SEODescription = mod.cCommentInfo.Substring(0, 260) + "...";
                    }
                    else
                    {
                        SEODescription = mod.cCommentInfo;
                    }

                    //查找除测绘图外所有的图
                    string sql_ImageCount = "select * from Al_BuildingImage where bIsAudit=1 and iProjectID=" + MsgID + " and iTypeID in (select iID from dbo.Al_BuildingImageType where cTypeName<>'测绘图')";
                    DataSet dtImageCount = DBHelper.Query(sql_ImageCount);
                    //查找栋数据中的所有预测报告
                    string sql_ImageBuilding = "select * from Al_BuildingYcbgImage where bIsAudit=1 and iBid in (select iID from Al_Building where iProjectID=" + MsgID + " and bIsAudit=1)";
                    DataSet dt_BuildingImageCount = DBHelper.Query(sql_ImageBuilding);
                    int AllImageCount = dtImageCount.Tables[0].Rows.Count+dt_BuildingImageCount.Tables[0].Rows.Count;
                    ImageCount = AllImageCount.ToString();

                    //图片地址
                    Thumbnail = mod.cThumbnail;
                    //楼盘价格
                    string sql_Price = "select * from V_BuildingPrice where iID=" + MsgID + "";
                    DataSet dtPrice = DBHelper.Query(sql_Price);
                    if (dtPrice.Tables[0].Rows.Count > 0)
                    {
                        if (dtPrice.Tables[0].Rows[0]["cZz_Jqcjjj"].ToString() == "0")
                        {
                            BuildingPrice = "待定";
                        }
                        else
                        {
                            BuildingPrice = dtPrice.Tables[0].Rows[0]["cZz_Jqcjjj"].ToString() + "元/平方米";
                        }
                    }
                    else
                    {
                        BuildingPrice = "待定";
                    }
                    //开盘时间
                    OpenTime = mod.cOpeningTime;
                    //装修情况
                    DecorateInfo = mod.cDecorateInfo;
                    //建筑类别
                    Jzlb = mod.cBuildingType.Replace("|", " ");
                    //户型面积
                    Hxmj = mod.cDoorArea.ToString().Replace("|", " ");
                    //项目地址
                    Address = mod.cAddress;
                    //所属区域
                    AreaID = mod.iAreaID;
                    XxWapSystem.BLL.Al_Area bllAreaName = new XxWapSystem.BLL.Al_Area();
                    XxWapSystem.Model.Al_Area modAreaName = new XxWapSystem.Model.Al_Area();
                    modAreaName = bllAreaName.GetModel(AreaID);
                    AreaName = modAreaName.cAreaName;
                    //该楼盘坐标
                    Xzuobiao = mod.cMaplng.ToString();
                    Yzuobiao = mod.cMaplat.ToString();
                    //销售地址
                    SaleAddress = mod.cSalesAddress;
                    //销售电话
                    SalePhone = mod.cSalesPhone;
                    //开发商
                    Kfs = mod.cDevelopers;
                    //设计单位
                    Sjdw = mod.cDesignUnit;
                    //承建单位
                    Cjdw = mod.cConstructionUnit;
                    //物业单位
                    Wydw = mod.cProManUnit;
                    //占地面积
                    Zdmj = mod.cZzdmj;
                    //建筑面积
                    Jzmj = mod.cZghjzmj;
                    //总栋数
                    Zds = mod.cHouseNum;
                    //总户数
                    Zhs = mod.cPlanningZongHuShu+"户";
                    //总投资
                    Ztz = mod.cTotalInvestment;
                    //绿化率
                    Lhl = mod.cVolumeRate.Replace("%", "") + "%";
                    //容积率
                    Rjl = mod.cCovered;
                    //国土使用权证
                    Gtsyqz = mod.cGytdsyqz;
                    //土地使用年限
                    Tdsynx = mod.cPropertyYears;
                    //建设工程规划许可证
                    Jsgcghxkz = mod.cJsgcghxkz;
                    //建设用地规划许可证
                    Jsydghxkz = mod.cJsydghxkz;

                    //项目介绍
                    ProjectInfo = mod.cProInfo;
                    //交房标准
                    Jfbz = mod.cStandard;

                    //配套信息
                    if (mod.cPeripheral.ToString().Length > 0)
                    {
                        Ptxx = Ptxx+"<b>周边配套：</b>" + mod.cPeripheral + "<br/>";
                    }
                    if (mod.cInternalSupporting.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + "<b>内部配套：</b>" + mod.cInternalSupporting + "<br/>";
                    }
                    if (mod.cSurroundingCommercial.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + "<b>周边商业：</b>" + mod.cSurroundingCommercial + "<br/>";
                    }
                    if (mod.cSurroundingLandscape.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + "<b>周边环境：</b>" + mod.cSurroundingLandscape + "<br/>";
                    }
                    if (mod.cSurroundingPark.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + " <b>周边公园：</b>" + mod.cSurroundingPark + "<br/>";
                    }
                    if (mod.cPeripheralHospital.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + "<b>周边医院：</b>" + mod.cPeripheralHospital + "<br/>";
                    }
                    if (mod.cPeripheralSchool.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + "<b>周边学校：</b>" + mod.cPeripheralSchool + "<br/>";
                    }
                    if (mod.cSurroundingTraffic.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + "<b>周边交通：</b>" + mod.cSurroundingTraffic + "<br/>";
                    }
                    if (mod.cIntelligentFacilities.ToString().Length > 0)
                    {
                        Ptxx = Ptxx + "<b>职能设施：</b>" + mod.cIntelligentFacilities + "<br/>";
                    }
                    //绑定输出楼盘资讯
                    doDataBind();
                    //绑定输出每幢房屋具体情况
                    doDataBindBuild();
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

        private void doDataBindBuild()
        {
            string sql = "select iID,cBuildingName,iProjectID,cMeasurementNum from Al_Building where iProjectID=" + MsgID + " and  bIsAudit=1 order by dAddTime desc";
            DataSet dt = DBHelper.Query(sql);

            if (dt.Tables[0].Rows.Count > 0)
            {
                BuildingInfoHtml = BuildingInfoHtml + "<div class=\"info_li_d\"><span class=\"info_attr_d\">栋名称</span><span class=\"info_val_d\">预售许可号</span></div>";
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    BuildingInfoHtml = BuildingInfoHtml + "<div class=\"info_li_r\"><span class=\"info_attr_d\">" + dt.Tables[0].Rows[i]["cBuildingName"].ToString() + "</span><span class=\"info_val_d\">" + YsxkzNum(dt.Tables[0].Rows[i]["iID"].ToString(), dt.Tables[0].Rows[i]["cMeasurementNum"].ToString()) + "</span></div>";
                }
            }
            else
            {
                BuildingInfoHtml = BuildingInfoHtml + "<div class=\"info_li\">暂无栋数据！</div>";
            }
        }
        /// <summary>
        /// 返回预售许可证编号
        /// </summary>
        /// <param name="bid">栋编号</param>
        /// <param name="clh">测量号码</param>
        /// <returns></returns>
        public string YsxkzNum(string bid, string clh)
        {
            string msg = string.Empty;

            string sql = "select top 1 * from Al_BuildingYsxkz where iBid=" + bid + "";
            DataSet dtYsxkz = DBHelper.Query(sql);
            if (dtYsxkz.Tables[0].Rows.Count > 0)
            {
                msg = "<a href='http://xx.yyfdcw.com/hetong/ysz.asp?id=" + clh + "' target=\"_blank\">" + dtYsxkz.Tables[0].Rows[0]["cYsxkzNum"].ToString() + "</a>";
            }
            else
            {
                msg = "暂无预售许可证！";
            }
            return msg;
        }
    }
}
