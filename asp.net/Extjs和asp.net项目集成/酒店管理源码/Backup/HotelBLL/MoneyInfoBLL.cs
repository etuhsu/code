using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HotelDAL;

namespace HotelBLL
{
    public class MoneyInfoBLL
    {

        MoneyInfoDAO mid = new MoneyInfoDAO();


        /// <summary>
        /// 查账(全查,根据时间查询都可以)
        /// </summary>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public string SerachMoney(string BeginTime, string EndTime)
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = mid.SerachMoney(BeginTime, EndTime);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("MoneyInfoId", dr["MoneyInfoId"].ToString());
                jsonHelp.AddItem("OpenTime", dr["OpenTime"].ToString());
                jsonHelp.AddItem("RoomNumber", dr["RoomNumber"].ToString());
                jsonHelp.AddItem("GuestNumber", dr["GuestNumber"].ToString());
                jsonHelp.AddItem("GuestName", dr["GuestName"].ToString());
                jsonHelp.AddItem("MoneyDate", dr["MoneyDate"].ToString());
                jsonHelp.AddItem("DetailsMoney", dr["DetailsMoney"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }
    }
}
