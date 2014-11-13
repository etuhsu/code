using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using XxWapSystem.DAL;
namespace XxWapSystem.sellhouse
{
    public partial class List : System.Web.UI.Page
    {
        public string strWhere = "";                //临时过滤器
        public string ScriptStr = string.Empty;                    //script脚本输出
        public string PostStr = string.Empty;                      //post参数
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchStr();
            if (!IsPostBack)
            {
                doDataBind();
            }
        }
        private void doDataBind()
        {
            string sql = "select Top 10 *,(select top 1 ImgPath from AL_ES_Images where type='sale' and ESID=V_AL_ES_Sale.id) pic FROM V_AL_ES_Sale WHERE  isDel=0 AND isOk=1 AND DateDiff(day,GetDate(),EndTime) > 0 " + strWhere + " ORDER By SortID desc,isTop desc,updateTime desc,AddTime desc";
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
            //地区
            if (!string.IsNullOrEmpty(Request["q"]))
            {
                string RequestQ = Request["q"].ToString();
                string Q_str = string.Empty;
                if (RequestQ == "1")
                {
                    Q_str = "岳阳楼区";
                    strWhere += " AND Area = 1";
                }
                else if (RequestQ == "2")
                {
                    Q_str = "南湖风景区";
                    strWhere += " AND Area = 6";
                }
                else if (RequestQ == "3")
                {
                    Q_str = "经济开发区";
                    strWhere += " AND Area = 11";
                }
                else if (RequestQ == "4")
                {
                    Q_str = "城陵矶";
                    strWhere += " AND Area = 12";
                }
                else if (RequestQ == "5")
                {
                    Q_str = "云溪区";
                    strWhere += " AND Area = 13";
                }
                else if (RequestQ == "6")
                {
                    Q_str = "君山区";
                    strWhere += " AND Area = 16";
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


            //价格
            if (!string.IsNullOrEmpty(Request["j"]))
            {
                string RequestJJ = Request["j"].ToString();
                string JJ_str = string.Empty;
                if (RequestJJ == "1")
                {
                    JJ_str = "20万以下";
                    strWhere += " AND (Price < 20 OR Price is null )";
                }
                else if (RequestJJ == "2")
                {
                    JJ_str = "20-30万";
                    strWhere += " AND Price between 20 and 30";
                }
                else if (RequestJJ == "3")
                {
                    JJ_str = "30-40万";
                    strWhere += " AND Price between 30 and 40";
                }
                else if (RequestJJ == "4")
                {
                    JJ_str = "40-50万";
                    strWhere += " AND Price between 40 and 50";
                }
                else if (RequestJJ == "5")
                {
                    JJ_str = "50-60万";
                    strWhere += " AND Price between 50 and 60";
                }
                else if (RequestJJ == "6")
                {
                    JJ_str = "60-80万";
                    strWhere += " AND Price between 60 and 80";
                }
                else if (RequestJJ == "7")
                {
                    JJ_str = "80-100万";
                    strWhere += " AND Price between 80 and 100";
                }
                else if (RequestJJ == "8")
                {
                    JJ_str = "100万以上";
                    strWhere += " AND Price > 100";
                }
                else { }
                //参数输出
                PostStr = PostStr + "&j=" + RequestJJ;
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

            //面积
            if (!string.IsNullOrEmpty(Request["h"]))
            {
                string RequestH = Request["h"].ToString();
                string H_str = string.Empty;
                if (RequestH == "1")
                {
                    H_str = "60平方以下";
                    strWhere += " AND (Construction < 60 OR Construction is null )";
                }
                else if (RequestH == "2")
                {
                    H_str = "60-90平米";
                    strWhere += " AND Construction between 60 and 90";
                }
                else if (RequestH == "3")
                {
                    H_str = "90-120平米";
                    strWhere += " AND Construction between 90 and 120";
                }
                else if (RequestH == "4")
                {
                    H_str = "120-144平米";
                    strWhere += " AND Construction between 120 and 144";
                }
                else if (RequestH == "5")
                {
                    H_str = "144平米以上";
                    strWhere += " AND Construction > 144";
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
                    ScriptStr = ScriptStr + "$(\"#h" + RequestH + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#h" + RequestH + "\").parent().toggleClass('checked');choose_opts.put(\"HouseType\", \"" + H_str + "\");choose_opt_labels['HouseType']='面积';";
                }
            }
            
            //厅室
            if (!string.IsNullOrEmpty(Request["t"]))
            {
                string RequestT = Request["t"].ToString();
                string T_str = string.Empty;
                if (RequestT == "1")
                {
                    T_str = "一室";
                    strWhere += " AND HomeType = 1";
                }
                else if (RequestT == "2")
                {
                    T_str = "二室";
                    strWhere += " AND HomeType = 2";
                }
                else if (RequestT == "3")
                {
                    T_str = "三室";
                    strWhere += " AND HomeType = 3";
                }
                else if (RequestT == "4")
                {
                    T_str = "四室";
                    strWhere += " AND HomeType = 4";
                }
                else if (RequestT == "5")
                {
                    T_str = "五室";
                    strWhere += " AND HomeType = 5";
                }
                else if (RequestT == "6")
                {
                    T_str = "六室";
                    strWhere += " AND HomeType = 6";
                }
                else if (RequestT == "7")
                {
                    T_str = "七室";
                    strWhere += " AND HomeType = 7";
                }
                else if (RequestT == "8")
                {
                    T_str = "八室";
                    strWhere += " AND HomeType = 8";
                }
                else if (RequestT == "9")
                {
                    T_str = "八室以上";
                    strWhere += " AND HomeType = 9";
                }
                else { }
                //参数输出
                PostStr = PostStr + "&j=" + RequestT;
                //脚本输出
                if (RequestT == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#t" + RequestT + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + RequestT + "\").parent().toggleClass('checked');";
                }
                else
                {
                    ScriptStr = ScriptStr + "$(\"#t" + RequestT + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + RequestT + "\").parent().toggleClass('checked');choose_opts.put(\"ts\", \"" + T_str + "\");choose_opt_labels['ts']='厅室';";
                }
            }

            //用途
            if (!string.IsNullOrEmpty(Request["y"]))
            {
                string RequestY = Request["y"].ToString();
                string Y_str = string.Empty;
                if (RequestY == "1")
                {
                    Y_str = "普通住宅";
                }
                else if (RequestY == "2")
                {
                    Y_str = "商住";
                }
                else if (RequestY == "3")
                {
                    Y_str = "商铺";
                }
                else if (RequestY == "4")
                {
                    Y_str = "写字楼";
                }
                else if (RequestY == "5")
                {
                    Y_str = "别墅";
                }
                else if (RequestY == "6")
                {
                    Y_str = "公寓";
                }
                else if (RequestY == "7")
                {
                    Y_str = "厂房";
                }
                else if (RequestY == "8")
                {
                    Y_str = "其他";
                }
                else { }
                //参数输出
                PostStr = PostStr + "&j=" + RequestY;
                //脚本输出
                if (RequestY == "0")
                {
                    ScriptStr = ScriptStr + "$(\"#y" + RequestY + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#y" + RequestY + "\").parent().toggleClass('checked');";
                }
                else
                {
                    strWhere += " AND ManagerType = (select id from AlDictionary where ParentId=512 and Sort=" + RequestY + ")";
                    ScriptStr = ScriptStr + "$(\"#y" + RequestY + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#y" + RequestY + "\").parent().toggleClass('checked');choose_opts.put(\"yt\", \"" + Y_str + "\");choose_opt_labels['yt']='用途';";
                }
            }

            //关键字 key
            if (!string.IsNullOrEmpty(Request["key"]))
            {
                string RequestKey = HttpUtility.UrlDecode(Request["key"].ToString());
                strWhere += " AND Title like '%" + RequestKey + "%'";
                //参数输出
                PostStr = PostStr + "&key=" + RequestKey;
                //脚本输出
                ScriptStr = ScriptStr + "choose_opts.put(\"keyword\", \"" + RequestKey + "\");choose_opt_labels['keyword']='搜索';$(\"#searchInput\").val(\"" + RequestKey + "\");";
            }
        }

        protected string BindHType(string homeT, string homeT1, string homeT2)
        {
            string strtemp = "";
            string strtemp2 = "";
            switch (homeT)
            {
                case "1":
                    strtemp = "一室";
                    break;
                case "2":
                    strtemp = "二室";
                    break;
                case "3":
                    strtemp = "三室";
                    break;
                case "4":
                    strtemp = "四室";
                    break;
                case "5":
                    strtemp = "五室";
                    break;
                case "6":
                    strtemp = "六室";
                    break;
                case "7":
                    strtemp = "七室";
                    break;
                case "8":
                    strtemp = "八室";
                    break;
                case "9":
                    strtemp = "八室以上";
                    break;
                default:
                    break;
            }
            strtemp2 = "( " + ((homeT1 == null || homeT1 == "0") ? "" : homeT1 + "厅") + ((homeT2 == null || homeT2 == "0") ? "" : homeT2 + "卫") + " )";
            return string.Format("{0} {1}", strtemp, strtemp2 == "(  )" ? "" : strtemp2);
        }

        protected string BindMoney(string money)
        {
            return money == "0.000" ? "<b class=\"pri\">面议</b>" : "<b class=\"pri\">" + money + "</b> 万";
        }

        protected string BindPic(string pic)
        {
            string msg = string.Empty;
            if (pic.Length > 5)
            {
                msg = "http://xx.yyfdcw.com" + pic;
            }
            else
            {
                msg = "/images/no_pic.jpg";
            }
            return msg;
        }
    }
}
