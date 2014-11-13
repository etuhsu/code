using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using XxWapSystem.DAL;

namespace XxWapSystem.newhouse
{
    public partial class List : System.Web.UI.Page
    {
        string strWhere = "1=1 and a.bIsAudit='2'";                //临时过滤器
        public string Sort = "order by a.iID desc";                //排序条件以及方式，默认为iid排序
        public string order_btn_str = string.Empty;                //排序html输出.
        /// <summary>
        /// order为0表示默认iid排序 降序，1表示按开盘时间降序排序，2表示按开盘时间升序排序，3表示按价格降序排序，4表示按价格升序排序
        /// </summary>
        public string SortPost = "&order=0";                        //排序post值，与ajax数据相关连

        public string AllBudingCount = string.Empty;               //楼盘总数
        public string ScriptStr = string.Empty;                    //script脚本输出
        public string PostStr = string.Empty;                      //post参数
        protected void Page_Load(object sender, EventArgs e)
        {
            //开盘时间
            if (!string.IsNullOrEmpty(Request["T"]))
            {
                string RequestT = Request["T"].ToString();
                if (RequestT == "1")
                {
                    Sort = " order by a.cOpeningTime desc";
                    SortPost = "&order=1";
                    order_btn_str = order_btn_str + "<span id=\"order_time\" onclick=\"setRewriteOrderParam('T','0')\">开盘时间<i class=\"icon-down\"></i></span>";
                }
                else
                {
                    Sort = "order  by a.cOpeningTime asc";
                    SortPost = "&order=2";
                    order_btn_str = order_btn_str + "<span id=\"order_time\" onclick=\"setRewriteOrderParam('T','1')\">开盘时间<i class=\"icon-up\"></i></span>";
                }
            }
            else
            {
                order_btn_str = order_btn_str + "<span id=\"order_time\" onclick=\"setRewriteOrderParam('T','1')\">开盘时间<i class=\"icon-up\"></i></span>";
            }

            //价格
            if (!string.IsNullOrEmpty(Request["J"]))
            {
                string RequestJ = Request["J"].ToString();
                if (RequestJ == "1")
                {
                    Sort = " order by convert(int,b.cZz_Jqcjjj) desc";
                    SortPost = "&order=3";
                    order_btn_str = order_btn_str + "<span id=\"order_price\" onclick=\"setRewriteOrderParam('J','0')\">价格<i class=\"icon-down\"></i></span>";
                }
                else
                {
                    Sort = "order by convert(int,b.cZz_Jqcjjj) asc";
                    SortPost = "&order=4";
                    order_btn_str = order_btn_str + "<span id=\"order_price\" onclick=\"setRewriteOrderParam('J','1')\">价格<i class=\"icon-up\"></i></span>";
                }

            }
            else
            {
                order_btn_str = order_btn_str + "<span id=\"order_price\" onclick=\"setRewriteOrderParam('J','1')\">价格<i class=\"icon-up\"></i></span>";
            }
            SearchStr();
            if (!IsPostBack)
            {
                string sql_AllBuildingCount = "select a.*,b.cZz_Jqcjjj from Al_BuildingInfo as a  left join Al_BuildingInfo_Tj as b on a.iid=b.iProjectID where " + strWhere + " " + Sort + "";
                DataSet dt = DBHelper.Query(sql_AllBuildingCount);
                AllBudingCount = dt.Tables[0].Rows.Count.ToString();
                doDataBind();
            }
        }

        private void doDataBind()
        {
            string sql = "select top 10 a.*,b.cZz_Jqcjjj from Al_BuildingInfo as a  left join Al_BuildingInfo_Tj as b on a.iid=b.iProjectID where " + strWhere + " " + Sort + "";
            DataSet dt = DBHelper.Query(sql);

            this.rptlist.DataSource = dt;
            this.rptlist.DataBind();
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
                //参数输出
                PostStr = PostStr + "&ty=" + RequestTy;
                //脚本输出
                if (RequestTy == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#t" + RequestTy + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + RequestTy + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#t" + RequestTy + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + RequestTy + "\").parent().toggleClass('checked');choose_opts.put(\"HType\", \"" + ty_str + "\");choose_opt_labels['HType']='类型';";
                }
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
                //参数输出
                PostStr = PostStr + "&q=" + RequestQ;
                //脚本输出
                if (RequestQ == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#q" + RequestQ + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#q" + RequestQ + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#q" + RequestQ + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#q" + RequestQ + "\").parent().toggleClass('checked');choose_opts.put(\"area\", \"" + Q_str + "\");choose_opt_labels['area']='区域';";
                }
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
                //参数输出
                PostStr = PostStr + "&z=" + RequestZ;
                //脚本输出
                if (RequestZ == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#z" + RequestZ + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#z" + RequestZ + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#z" + RequestZ + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#z" + RequestZ + "\").parent().toggleClass('checked');choose_opts.put(\"zhuangtai\", \"" + Z_str + "\");choose_opt_labels['zhuangtai']='状态';";
                }
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
                //参数输出
                PostStr = PostStr + "&jj=" + RequestJJ;
                //脚本输出
                if (RequestJJ == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#j" + RequestJJ + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#j" + RequestJJ + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#j" + RequestJJ + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#j" + RequestJJ + "\").parent().toggleClass('checked');choose_opts.put(\"price\", \"" + JJ_str + "\");choose_opt_labels['price']='价格';";
                }
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
                //参数输出
                PostStr = PostStr + "&s=" + RequestS;
                //脚本输出
                if (RequestS == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#s" + RequestS + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#s" + RequestS + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#s" + RequestS + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#s" + RequestS + "\").parent().toggleClass('checked');choose_opts.put(\"features\", \"" + S_str + "\");choose_opt_labels['features']='特色';";
                }
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
                //参数输出
                PostStr = PostStr + "&h=" + RequestH;
                //脚本输出
                if (RequestH == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#h" + RequestH + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#h" + RequestH + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#h" + RequestH + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#h" + RequestH + "\").parent().toggleClass('checked');choose_opts.put(\"HouseType\", \"" + H_str + "\");choose_opt_labels['HouseType']='户型';";
                }
            }

            //楼盘关键字 key
            if (!string.IsNullOrEmpty(Request["key"]))
            {
                string RequestKey = HttpUtility.UrlDecode(Request["key"].ToString());
                strWhere += " AND a.cProjectName like '%" + RequestKey + "%'";
                //参数输出
                PostStr = PostStr + "&key=" + RequestKey;
                //脚本输出
                ScriptStr = ScriptStr + "choose_opts.put(\"keyword\", \"" + RequestKey + "\");choose_opt_labels['keyword']='搜索';$(\"#searchInput\").val(\"" + RequestKey + "\");";
            }
        }

        /// <summary>
        /// 排序方式
        /// </summary>
        /// <returns>返回排序 sql语句</returns>
        private void OrderStr()
        {

        }

        /// <summary>
        /// 价格
        /// </summary>
        /// <param name="id">楼盘编号</param>
        /// <returns></returns>
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

        /// <summary>
        /// 楼盘状态
        /// </summary>
        /// <param name="Zt">楼盘状态</param>
        /// <returns></returns>
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
