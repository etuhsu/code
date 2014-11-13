using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XxWapSystem.jc_go
{
    public partial class ProductShow : System.Web.UI.Page
    {
        public string ProductImage = string.Empty;  //产品图片
        public string ProductName = string.Empty;   //产品名称
        public string ProductPrice = string.Empty;  //产品价格
        public string ProductStandard = string.Empty;   //产品规格
        public string ProductXh = string.Empty;  //产品型号
        public string ProductType = string.Empty;   //产品类别
        public string BrandName = string.Empty;  //产品品牌
        public string iHits = string.Empty;     //浏览次数
        public string Explain = string.Empty;   //产品说明
        public string ProductAddTime = string.Empty;  //产品添加时间
        public string Address = string.Empty;    //路径
        public string UserAddress = string.Empty;      //商家地址  
        public string UserPhone = string.Empty;        //商家电话
        public string MemberName = string.Empty;      //商家账号
        public string ProductOldPrice = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                int NewId = int.Parse(Request["id"].ToString());

                string sqlstr = "select * from Sys_Product where iID=" + NewId;
                DataSet dt = DBHelperZxw.Query(sqlstr);

                ProductOldPrice = dt.Tables[0].Rows[0]["cOldPrice"].ToString();
                ProductName = dt.Tables[0].Rows[0]["cProductName"].ToString();
                ProductPrice = dt.Tables[0].Rows[0]["cPrice"].ToString();
                ProductStandard = dt.Tables[0].Rows[0]["cProductStandard"].ToString();
                ProductXh = dt.Tables[0].Rows[0]["cProductXh"].ToString();
                ProductAddTime = dt.Tables[0].Rows[0]["dAddTime"].ToString();
                iHits = dt.Tables[0].Rows[0]["iHits"].ToString();
                Explain = dt.Tables[0].Rows[0]["cExplain"].ToString();

                //产品图片
                if (Thumbnail(NewId.ToString()).Length > 0)
                {
                    ProductImage = string.Format("<a href=\"Images.aspx?id=") + NewId + string.Format("\" target=\"_self\"><img width=\"320\" height=\"200\" src=\"") + Thumbnail(NewId.ToString()) + "\" jqimg=\"" + Thumbnail(NewId.ToString()) + "\" ></a>";
                }
                else
                {
                    ProductImage = "暂无图片！";
                }

                string sqlstrs = "select * from Sys_Member where iID=" + dt.Tables[0].Rows[0]["iUserID"].ToString();
                DataSet dt_pho = DBHelperZxw.Query(sqlstrs);
                UserAddress = dt_pho.Tables[0].Rows[0]["cAddress"].ToString();
                MemberName = dt_pho.Tables[0].Rows[0]["cMemberName"].ToString();
                if (dt_pho.Tables[0].Rows[0]["cPhone"].ToString().Length > 0)
                {
                    UserPhone = dt_pho.Tables[0].Rows[0]["cPhone"].ToString();
                }
                else
                {
                    UserPhone = dt_pho.Tables[0].Rows[0]["cMobile"].ToString();
                }
            }
        }

        public string Thumbnail(string id)
        {
            string msg = string.Empty;
            string sql = "select top 1 * from Sys_ProductImages where iProductID=" + id + " and bIsTop=1 order by dAddTime desc";
            DataSet ds = DBHelperZxw.Query(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                msg ="http://zx.yyfdcw.com" + ds.Tables[0].Rows[0]["cProductThumbnail"].ToString();
            }
            else
            {
                string sql_Image = "select top 1 * from Sys_ProductImages where iProductID=" + id + " order by dAddTime desc";
                DataSet ds1 = DBHelperZxw.Query(sql_Image);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    msg = "http://zx.yyfdcw.com" + ds1.Tables[0].Rows[0]["cProductThumbnail"].ToString();
                }
                else
                {
                    msg = "";
                }
            }
            return msg;
        }

    }
}
