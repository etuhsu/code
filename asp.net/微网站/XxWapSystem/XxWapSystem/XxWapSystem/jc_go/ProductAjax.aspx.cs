using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace XxWapSystem
{
    public partial class ProductAjax : System.Web.UI.Page
    {
        public int Pagesize = 10;
        public int Page = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                Page = int.Parse(Request["page"].ToString());
                int PageCount = (Page - 1) * Pagesize;
                string WhereStr = BuileWhere();
                string sqlstr = "select top " + Pagesize + " * from Sys_Product where iID not in (select top " + PageCount + " iID from Sys_Product where 1=1 " + WhereStr + " order by iID desc) " + WhereStr + " order by iID desc";
                DataSet dt = DBHelperZxw.Query(sqlstr);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {
                    string shuchu = string.Format("<li class=\"p-item\" onClick=\"gourl('ProductShow.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "')\"><div class=\"p-img\"><a href=\"ProductShow.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\"><img width=\"50\" height=\"50\" alt=\"" + dt.Tables[0].Rows[i]["cProductName"].ToString() + "\" src=\"" + Thumbnail(dt.Tables[0].Rows[i]["iID"].ToString()) + "\" /></a></div><div class=\"p-txt\"><div class=\"s-name\"><a href=\"ProductShow.aspx?id=" + dt.Tables[0].Rows[i]["iID"].ToString() + "\">" + dt.Tables[0].Rows[i]["cProductName"].ToString() + "</a></div><div class=\"s-addr\">品牌：" + Brand(dt.Tables[0].Rows[i]["iBrandID"].ToString()) + " - 产品型号：" + dt.Tables[0].Rows[i]["cProductXh"].ToString() + "</div><div class=\"s-addr\">促销价</div><div class=\"s-price\">￥" + dt.Tables[0].Rows[i]["cPrice"].ToString() + "</div></div></li>");
                    msg = msg + shuchu;
                }
            }
            Response.Write(msg);
         
        }
        private string BuileWhere()
        {
            string StrWhere = string.Empty;
            string sjcname = Request["jcname"];
            string ty = Request["ty"];
            if (!Equals(sjcname, null))
            {
                StrWhere += " and cProductName like '%" + sjcname + "%'";
            }
            else if (!Equals(ty, null))
            {
                StrWhere += " and iProductTypeID in  (select iID from Sys_ProductType where iID=" + ty + " or iPartentID =" + ty + ")";
            }
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
                    msg = "http://zx.yyfdcw.com/" + ds1.Tables[0].Rows[0]["cProductThumbnail"].ToString();
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
