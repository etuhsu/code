using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.jc_go
{
    public partial class jcgoList : System.Web.UI.Page
    {
        public string AllBudingCount = string.Empty;
        public string ScriptStr = string.Empty;
        public string RequestStr = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlstr=string.Empty;
            string WhereStr = BuileWhere();
            DataSet dtall = DBHelperZxw.Query("select * from Sys_Product" + WhereStr + " order by iID desc");
            AllBudingCount = dtall.Tables[0].Rows.Count.ToString();

            sqlstr = "select top 10 * from Sys_Product" + WhereStr + " order by iID desc";
            DataSet dt = DBHelperZxw.Query(sqlstr);
            this.rptMessage.DataSource = dt;
            this.rptMessage.DataBind();

        }

        private string BuileWhere()
        {
            string StrWhere = " where 1=1 ";
            string sjcname = Request["jcname"];
            string ty=Request["ty"];
            if (!Equals(sjcname, null))
            {
                StrWhere +=" and cProductName like '%" + sjcname + "%'";
                RequestStr = "&jcname=" + sjcname;
            }
            else if(!Equals(ty,null))
            {
                StrWhere += " and iProductTypeID in  (select iID from Sys_ProductType where iID=" + ty + " or iPartentID =" + ty + ")";
                RequestStr = "&ty=" + ty;
            }
            string tystr = string.Empty;
            switch (ty)
            {
                case "1":
                    tystr = "瓷砖";
                    break;
                case "2":
                    tystr = "地面砖";
                    break;
                case "3":
                        tystr = "墙面砖";
                        break;
                case "4":
                        tystr = "背景类装饰砖";
                        break;
                case "5":
                        tystr = "地板";
                        break;
                case "6":
                        tystr = "实木复合地板";
                        break;
                case "7":
                        tystr = "实木地板";
                        break;
                case "8":
                        tystr = "竹地板";
                        break;
                case "9":
                        tystr = "软木地板";
                        break;
                case "10":
                        tystr = "强化复合地板";
                        break;
                case "11":
                        tystr = "门";
                        break;
                case "12":
                        tystr = "室内房门";
                        break;
                case "13":
                        tystr = "衣柜门";
                        break;
                case "14":
                        tystr = "隔断门";
                        break;
                case "30":
                        tystr = "柜体";
                        break;
                case "31":
                        tystr = "衣柜";
                        break;
                case "35":
                        tystr = "酒柜";
                        break;
                case "33":
                        tystr = "书柜";
                        break;
                case "34":
                        tystr = "鞋柜";
                        break;
                case "15":
                        tystr = "吊顶";
                        break;
                case "16":
                        tystr = "厨卫";
                        break;
                case "17":
                        tystr = "过道";
                        break;
                case "18":
                        tystr = "阳台";
                        break;
                case "19":
                        tystr = "墙纸";
                        break;
                case "20":
                        tystr = "卫浴";
                        break;
                case "21":
                        tystr = "面盆";
                        break;
                case "22":
                        tystr = "浴缸";
                        break;
                case "23":
                        tystr = "座便器";
                        break;
                case "24":
                        tystr = "淋浴房";
                        break;
                case "25":
                        tystr = "龙头及花洒";
                        break;
                case "26":
                        tystr = "橱柜";
                        break;
                case "27":
                        tystr = "灯饰";
                        break;
                case "28":
                        tystr = "客餐厅";
                        break;
                case "29":
                        tystr = "卧室";
                        break;

            }
            ScriptStr = ScriptStr + "$(\"#t" + ty + "\").parent().parent().find(\"dd\").removeClass('checked');$(\"#t" + ty + "\").parent().toggleClass('checked');choose_opts.put(\"HType\", \"" + tystr + "\");choose_opt_labels['HType']='类型';";
            return StrWhere;
        }

        //返回产品图片
        public string Thumbnail(string id)
        {
            string msg = string.Empty;
            string sql = "select top 1 * from Sys_ProductImages where iProductID=" + id + " and bIsTop=1 order by dAddTime desc";
            DataSet ds = DBHelperZxw.Query(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                msg = "http://zx.yyfdcw.com/" + ds.Tables[0].Rows[0]["cProductThumbnail"].ToString();
            }
            else
            {
                string sql_Image = "select top 1 * from Sys_ProductImages where iProductID=" + id + " order by dAddTime desc";
                DataSet ds1 = DBHelperZxw.Query(sql_Image);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    msg ="http://zx.yyfdcw.com/" + ds1.Tables[0].Rows[0]["cProductThumbnail"].ToString();
                }
                else
                {
                    msg = "";
                }
            }
            return msg;
        }
        //返回产品品牌名称
        public string Brand(string iBrandid)
        {
            string msg = string.Empty;
            string sql = "select top 1 * from Sys_Brand where iID=" + iBrandid + " order by dAddTime desc";
            DataSet ds = DBHelperZxw.Query(sql);
            return ds.Tables[0].Rows[0]["cBrandName"].ToString();
        }
    }
}
