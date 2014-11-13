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
    public partial class NewHouse_Ajax : System.Web.UI.Page
    {
        public int PageSize = 10;      //每页显示数据量
        public int Pages = 1;          //定义页数
        public string OrderPostStr = string.Empty;     //定义接受Post过来的order值
        public string orderstr = string.Empty;         //定义Order排序方式

        string strWhere = string.Empty;                //临时过滤器
        public string ScriptStr = string.Empty;                    //script脚本输出
        public string PostStr = string.Empty;                      //post参数
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["page"] == null)
                return;
            if (Request["order"] == null)
                return;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                Pages = int.Parse(Request["page"].ToString());
                OrderPostStr = Request["order"].ToString();
                SearchStr();
                if (!IsPostBack)
                {
                    string result = string.Empty;   //定义返回值

                    //根据Order值不同，排序方式不同。0表示默认iid排序 降序，1表示按开盘时间降序排序，2表示按开盘时间升序排序，3表示按价格降序排序，4表示按价格升序排序
                    if (OrderPostStr == "0")
                    {
                        orderstr = "order by a.iID desc";
                    }
                    else if (OrderPostStr == "1")
                    {
                        orderstr = "order by a.iID desc";
                    }
                    else if (OrderPostStr == "2")
                    {
                        orderstr = "order by a.iID asc";
                    }
                    else if (OrderPostStr == "3")
                    {
                        orderstr = "order by convert(int,b.cZz_Jqcjjj) desc";
                    }
                    else if (OrderPostStr == "4")
                    {
                        orderstr = "order by convert(int,b.cZz_Jqcjjj) asc";
                    }
                    else 
                    {
                        orderstr = "order by a.iID desc";
                    }
                    //定义sql语句
                    string sql = string.Empty;
                    //定义页数对应要筛选的条数
                    int NewsCount = (Pages - 1) * PageSize;
                    sql = "select top " + PageSize + " a.*,b.cZz_Jqcjjj from Al_BuildingInfo as a  left join Al_BuildingInfo_Tj as b on a.iid=b.iProjectID where a.iID not in (select top " + NewsCount + " a.iID from Al_BuildingInfo as a  left join Al_BuildingInfo_Tj as b on a.iid=b.iProjectID where  a.bIsAudit='2' " + strWhere + " " + orderstr + ") and a.bIsAudit='2' " + strWhere + " " + orderstr + "";
                    DataSet dt = DBHelper.Query(sql);
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder ReturnMsg = new StringBuilder();
                        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                        {
                            ReturnMsg.Append(string.Format("<li class=\"p-item\" onclick=\"gourl('Show.aspx?ID=" + dt.Tables["ds"].Rows[i]["iID"].ToString() + "')\"><div class=\"p-img\"><a href=\"Show.aspx?ID=" + dt.Tables["ds"].Rows[i]["iID"].ToString() + "\"><img width=\"50\" height=\"50\" alt=\"" + dt.Tables["ds"].Rows[i]["cProjectName"].ToString() + "\" src=\"http://xx.yyfdcw.com" + dt.Tables["ds"].Rows[i]["cThumbnail"].ToString().Replace("\\", "/") + "\" /></a></div><div class=\"p-txt\"><div class=\"p-name\"><a href=\"Show.aspx?ID=" + dt.Tables["ds"].Rows[i]["iID"].ToString() + "\">" + dt.Tables["ds"].Rows[i]["cProjectName"].ToString() + "</a></div><div class=\"p-addr\">" + dt.Tables["ds"].Rows[i]["cAddress"].ToString() + "</div><div class=\"p-price\">" + PriceType(dt.Tables["ds"].Rows[i]["iID"].ToString()) + "</div></div>" + ZhuangTai(dt.Tables["ds"].Rows[i]["cZhuangtai"].ToString()) + "</li>"));
                        }
                        result = ReturnMsg.ToString();
                    }

                    Response.Write(result);
                }
            }
        }
        /// <summary>
        /// 根据搜索条件 设置查询条件 改变页面搜索条件状态值
        /// </summary>
        /// <returns>返回搜索条件sql语句</returns>
        private void SearchStr()
        {
            //楼盘类型
            if (!string.IsNullOrEmpty(Request["ty"]))
            {
                string RequestTy = Request["ty"].ToString();
                string ty_str = string.Empty;
                if (RequestTy == "1")
                {
                    ty_str = "住宅";
                    strWhere += " AND a.cHouseType like '%6|%'";
                }
                else if (RequestTy == "2")
                {
                    ty_str = "写字楼";
                    strWhere += " AND a.cHouseType like '%8|%'";
                }
                else if (RequestTy == "3")
                {
                    ty_str = "别墅";
                    strWhere += " AND a.cHouseType like '%4|%'";
                }
                else if (RequestTy == "4")
                {
                    ty_str = "商业";
                    strWhere += " AND a.cHouseType like '%9|%'";
                }
                else if (RequestTy == "5")
                {
                    ty_str = "公寓";
                    strWhere += " AND a.cHouseType like '%7|%'";
                }
                else if (RequestTy == "6")
                {
                    ty_str = "综合楼";
                    strWhere += " AND a.cHouseType like '%3|%'";
                }
                else if (RequestTy == "7")
                {
                    ty_str = "其他";
                    strWhere += " AND a.cHouseType like '%1|%'";
                }
                else { }
            }

            //楼盘地区
            if (!string.IsNullOrEmpty(Request["q"]))
            {
                string RequestQ = Request["q"].ToString();
                string Q_str = string.Empty;
                if (RequestQ == "1")
                {
                    Q_str = "岳阳楼区";
                    strWhere += " AND a.iAreaID = 1";
                }
                else if (RequestQ == "2")
                {
                    Q_str = "南湖风景区";
                    strWhere += " AND a.iAreaID = 6";
                }
                else if (RequestQ == "3")
                {
                    Q_str = "经济开发区";
                    strWhere += " AND a.iAreaID = 11";
                }
                else if (RequestQ == "4")
                {
                    Q_str = "城陵矶";
                    strWhere += " AND a.iAreaID = 12";
                }
                else if (RequestQ == "5")
                {
                    Q_str = "云溪区";
                    strWhere += " AND a.iAreaID = 13";
                }
                else if (RequestQ == "6")
                {
                    Q_str = "君山区";
                    strWhere += " AND a.iAreaID = 16";
                }
                else { }
            }

            //楼盘状态
            if (!string.IsNullOrEmpty(Request["z"]))
            {
                string RequestZ = Request["z"].ToString();
                string Z_str = string.Empty;
                if (RequestZ == "1")
                {
                    Z_str = "待售";
                    strWhere += " AND a.cZhuangtai='待售'";
                }
                else if (RequestZ == "2")
                {
                    Z_str = "新盘";
                    strWhere += " AND a.cZhuangtai='新盘'";
                }
                else if (RequestZ == "3")
                {
                    Z_str = "在售";
                    strWhere += " AND a.cZhuangtai='在售'";
                }
                else if (RequestZ == "4")
                {
                    Z_str = "尾盘";
                    strWhere += " AND a.cZhuangtai='尾盘'";
                }
                else if (RequestZ == "5")
                {
                    Z_str = "售完";
                    strWhere += " AND a.cZhuangtai='售完'";
                }
                else { }
            }

            //楼盘价格
            if (!string.IsNullOrEmpty(Request["jj"]))
            {
                string RequestJJ = Request["jj"].ToString();
                string JJ_str = string.Empty;
                if (RequestJJ == "1")
                {
                    JJ_str = "3000以下";
                    strWhere += " AND b.cZz_Jqcjjj between 0 and 3000";
                }
                else if (RequestJJ == "2")
                {
                    JJ_str = "3000-4000元";
                    strWhere += " AND b.cZz_Jqcjjj between 3000 and 4000";
                }
                else if (RequestJJ == "3")
                {
                    JJ_str = "4000-5000元";
                    strWhere += " AND b.cZz_Jqcjjj between 4000 and 5000";
                }
                else if (RequestJJ == "4")
                {
                    JJ_str = "5000-6000元";
                    strWhere += " AND b.cZz_Jqcjjj between 5000 and 6000";
                }
                else if (RequestJJ == "5")
                {
                    JJ_str = "6000以上";
                    strWhere += " AND b.cZz_Jqcjjj > 6000";
                }
                else { }
            }


            //楼盘特色
            if (!string.IsNullOrEmpty(Request["s"]))
            {
                string RequestS = Request["s"].ToString();
                string S_str = string.Empty;
                if (RequestS == "1")
                {
                    S_str = "精装房";
                    strWhere += " AND a.cBuildingFeatures like '%2|%'";
                }
                else if (RequestS == "2")
                {
                    S_str = "水景房";
                    strWhere += " AND a.cBuildingFeatures like '%6|%'";
                }
                else if (RequestS == "3")
                {
                    S_str = "教育地产";
                    strWhere += " AND a.cBuildingFeatures like '%7|%'";
                }
                else if (RequestS == "4")
                {
                    S_str = "公园地产";
                    strWhere += " AND a.cBuildingFeatures like '%9|%'";
                }
                else if (RequestS == "5")
                {
                    S_str = "投资地产";
                    strWhere += " AND a.cBuildingFeatures like '%10|%'";
                }
                else if (RequestS == "6")
                {
                    S_str = "低密度地产";
                    strWhere += " AND a.cBuildingFeatures like '%11|%'";
                }
                else if (RequestS == "7")
                {
                    S_str = "生态地产";
                    strWhere += " AND a.cBuildingFeatures like '%12|%'";
                }
                else if (RequestS == "8")
                {
                    S_str = "其他";
                    strWhere += " AND a.cBuildingFeatures like '%13|%'";
                }
                else { }
            }

            //楼盘户型
            if (!string.IsNullOrEmpty(Request["h"]))
            {
                string RequestH = Request["h"].ToString();
                string H_str = string.Empty;
                if (RequestH == "1")
                {
                    H_str = "60平方以下";
                    strWhere += " AND a.cDoorArea like '%60平方以下%'";
                }
                else if (RequestH == "2")
                {
                    H_str = "60-90平米";
                    strWhere += " AND a.cDoorArea like '%60-90平米%'";
                }
                else if (RequestH == "3")
                {
                    H_str = "90-120平米";
                    strWhere += " AND a.cDoorArea like '%90-120平米%'";
                }
                else if (RequestH == "4")
                {
                    H_str = "120-144平米";
                    strWhere += " AND a.cDoorArea like '%120-144平米%'";
                }
                else if (RequestH == "5")
                {
                    H_str = "144平米以上";
                    strWhere += " AND a.cDoorArea like '%144平米以上%'";
                }
                else { }
            }

            //楼盘关键字 key
            if (!string.IsNullOrEmpty(Request["key"]))
            {
                string RequestKey = HttpUtility.UrlDecode(Request["key"].ToString());
                strWhere += " AND a.cProjectName like '%" + RequestKey + "%'";
            }
        }
        public string PriceType(string id)
        {
            string msg = string.Empty;
            string sql_cha = "select * from Al_BuildingInfo_Tj where iProjectID=" + id + "";
            DataSet dt = DBHelper.Query(sql_cha);
            int datasetcount = dt.Tables["ds"].Rows.Count;
            if (datasetcount > 0)
            {
                if (dt.Tables["ds"].Rows[0]["cZz_Jqcjjj"].ToString() == "0")
                {
                    msg = "价格待定";
                }
                else
                {
                    msg = dt.Tables["ds"].Rows[0]["cZz_Jqcjjj"].ToString() + "元/平方米";
                }
            }
            else
            {
                msg = "价格待定";
            }

            return msg;
        }

        public string ZhuangTai(string Zt)
        {
            string msg = string.Empty;
            if (Zt == "在售")
            {
                msg = "<div class=\"p-tag tag_label_g\">在售</div>";
            }
            else if (Zt == "尾盘")
            {
                msg = "<div class=\"p-tag tag_label_y\">尾盘</div>";
            }
            else if (Zt == "新盘")
            {
                msg = "<div class=\"p-tag tag_label_r\">新盘</div>";
            }
            else if (Zt == "售完")
            {
                msg = "<div class=\"p-tag tag_label_gray\">售完</div>";
            }
            else
            {
                msg = "<div class=\"p-tag tag_label_gray\">待售</div>";
            }
            return msg;
        }
    }
}
