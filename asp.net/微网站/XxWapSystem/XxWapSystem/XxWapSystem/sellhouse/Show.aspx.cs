using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using XxWapSystem.Model;
using XxWapSystem.BLL;
using XxWapSystem.DAL;

namespace XxWapSystem.sellhouse
{
    public partial class Show : System.Web.UI.Page
    {
        public bool isMiddle, isBusiness;
        public string FlashImg, YYNum, Bus, FlashImg1, YYMess, buildStructName, pic1, strPB, HouseAge, Imgs, Title, AddTime, Click, CodeNum, PriceName, PriceD, ConstructionName, Address, Area, HomeTypeName, BuildTypeName, direction, Other, Phone, Linker, HouseMess, Decoration;
        public int FloorNum, MaxFloor;
        //地图
        protected string BName = string.Empty, Bcontent = string.Empty, bdx = string.Empty, bdy = string.Empty;
        public string ImageCount = string.Empty;

        public int MsgID = 0; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                MsgID = WbText.IsNumber(Request.QueryString["ID"].ToString()) ? int.Parse(Request.QueryString["ID"]) : 0;
                if (!IsPostBack)
                {
                    DataSet dsImg = DBHelper.Query("select * from Al_ES_Images where type='sale' and ESid = " + MsgID + " order by solID asc");
                    ImageCount = dsImg.Tables[0].Rows.Count.ToString();
                    if (dsImg.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsImg.Tables[0].Rows.Count; i++)
                        {
                            if (i < dsImg.Tables[0].Rows.Count)
                            {
                                if (i == 0)
                                {
                                    FlashImg = "<li><a href=\"http://xx.yyfdcw.com" + dsImg.Tables[0].Rows[i]["ImgPath"] + "\" target=\"_blank\"><img src=\"http://xx.yyfdcw.com" + dsImg.Tables[0].Rows[i]["ImgPath"] + "\" /></a></li>";
                                    FlashImg1 = "<li class=\"on\"></li>";
                                }
                                else
                                {
                                    FlashImg = FlashImg + "<li><a href=\"http://xx.yyfdcw.com" + dsImg.Tables[0].Rows[i]["ImgPath"] + "\" target=\"_blank\"><img src=\"http://xx.yyfdcw.com" + dsImg.Tables[0].Rows[i]["ImgPath"] + "\" /></a></li>";
                                    FlashImg1 = FlashImg1 + "<li></li>";
                                }
                            }
                            else return;
                        }
                    }
                    else
                    {
                        FlashImg = "<li><a href=\"/images/no_pic.jpg\" target=\"_blank\"><img src=\"/images/no_pic.jpg\" /></a></li>";
                        FlashImg1 = "<li class=\"on\"></li>";
                    }


                    string sql_Cha = "select * from Al_ES_Sale where ID=" + MsgID + "";
                    DataSet dtSet = DBHelper.Query(sql_Cha);

                    DataTable dt = dtSet.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        bdx = dr["cMaplat"].ToString();//对应数据库cMapLat字段
                        bdy = dr["cMaplng"].ToString();//对应数据库cMaplng字段
                    }
                    Bindrp();
                }
            }
        }


        private void Bindrp()
        {
            Al_ES_Sale buy = new B_ES_Sale().GetModel(Convert.ToInt32(Request["ID"]));
            

            Click = (buy.Click + 1).ToString();
            DBHelper.ExecuteSql("update Al_ES_Sale set click=click+1 where id=" + buy.ID);

            try
            {
                pic1 = DBHelper.ExecuteSaclar("select cqType from V_AL_ES_Sale where id=" + Request["id"]).ToString();
            }
            catch { pic1 = ""; }
            HouseAge = buy.HouseAge == 0 ? "" : buy.HouseAge.ToString() + " 年";
            //strPB = buy.pic3;
            isMiddle = buy.IsMiddle;
            isBusiness = buy.MiddleID == buy.CompareID;
            //uid = buy.IsMiddle ? buy.MiddleID.ToString() : buy.UID.ToString();
            Title = buy.Title;
            AddTime = buy.AddTime.ToString("yyyy-MM-dd");
            CodeNum = SubStr(buy.CodeNum, 14);
            Bus = buy.Bus;
            PriceName = buy.Price.ToString() == "0.000" ? "面议" : string.Format("{0}万元", buy.Price.ToString().Substring(0, buy.Price.ToString().Length - 2));
            try
            {
                ConstructionName = buy.Construction.ToString().Substring(0, buy.Price.ToString().Length - 2);
            }
            catch { ConstructionName = ""; }
            Address = buy.Address;
            Area = buy.AreaName;
            HomeTypeName = string.Format("{0}{1}{2}", (buy.HomeType == null || buy.HomeType <= 0) ? "" : buy.HomeType + "室", (buy.HomeType1 == null || buy.HomeType1 <= 0) ? "" : buy.HomeType1 + "厅", (buy.HomeType2 == null || buy.HomeType2 <= 0) ? "" : buy.HomeType2 + "卫");
            BuildTypeName = buy.ManagerTypeName;
            direction = buy.directionName;
            Phone = buy.Phone;
            Linker = buy.Linker;
            HouseMess = buy.HouseMess;
            buildStructName = buy.buildStructName;
            YYMess = buy.pic1;
            YYNum = DBHelper.ExecuteSaclar("select count(id) from al_Form_Subscribe where cid=" + buy.ID).ToString();

            string LinshiPriceD = "";
            try
            {
                LinshiPriceD = Convert.ToInt32(buy.Price / buy.Construction * 10000).ToString();
                //PriceD = Convert.ToInt32(buy.Price / buy.Construction * 10000).ToString() + "元/M&sup2;";
            }
            catch { }
            if (LinshiPriceD == "0" || LinshiPriceD == "")
            {
                PriceD = "面议";
            }
            else
            {
                PriceD = LinshiPriceD + "元/M&sup2;";
            }

           
            Other = buy.Other;
            Decoration = DBHelper.ExecuteSaclar("select DecorationName from V_Al_ES_Sale where id=" + buy.ID).ToString();
            FloorNum = int.Parse(buy.FloorNum.ToString());
            MaxFloor = int.Parse(buy.MaxFloor.ToString());
          
        }


        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="len">长度</param>
        /// <returns></returns>
        protected string SubStr(string str, int len)
        {
            string tempString = string.Empty;
            for (int i = 0, tempIndex = 0; i < str.Length; ++i, ++tempIndex)
            {
                if (System.Text.Encoding.UTF8.GetBytes(new char[] { str[i] }).Length > 1)
                    ++tempIndex;

                if (tempIndex >= len)
                {
                    //tempString += "...";
                    break;
                }
                tempString += str[i];
            }
            return tempString;
        }
        /// <summary>
        /// 房屋类型
        /// </summary>
        /// <param name="homeT"></param>
        /// <param name="homeT1"></param>
        /// <param name="homeT2"></param>
        /// <returns></returns>
        protected string BindHType(string homeT, string homeT1, string homeT2)
        {
            return string.Format("{0}{1}{2}", (homeT == null || homeT == "0") ? "" : homeT + "室", (homeT1 == null || homeT1 == "0") ? "" : homeT1 + "厅", (homeT2 == null || homeT2 == "0") ? "" : homeT2 + "卫");
        }
    }
}
