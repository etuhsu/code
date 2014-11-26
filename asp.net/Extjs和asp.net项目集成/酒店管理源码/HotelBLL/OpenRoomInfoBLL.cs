using System;
using System.Collections.Generic;
using System.Text;
using HotelModels;
using System.Data;
using HotelDAL;

namespace HotelBLL
{
    public class OpenRoomInfoBLL
    {

        OpenRoomInfoDAO orid = new OpenRoomInfoDAO();

        
        /// <summary>
        /// 查询所有的开房信息(首页的Grid,带搜索功能)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetOpenRoomInfoAll(string message)
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = orid.GetOpenRoomInfoAll(message);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("OpenRoomId", dr["OpenRoomId"].ToString());
                jsonHelp.AddItem("Number", dr["Number"].ToString());
                jsonHelp.AddItem("TypeName", dr["TypeName"].ToString());
                jsonHelp.AddItem("TypePrice", dr["TypePrice"].ToString());
                jsonHelp.AddItem("OpenTime", dr["OpenTime"].ToString());
                jsonHelp.AddItem("GuestMoney", dr["GuestMoney"].ToString());
                jsonHelp.AddItem("GuestNumber", dr["GuestNumber"].ToString());
                jsonHelp.AddItem("GuestName", dr["GuestName"].ToString());
                jsonHelp.AddItem("Remark", dr["Remark"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }


        /// <summary>
        /// 开房操作
        /// </summary>
        /// <param name="orib"></param>
        /// <returns></returns>
        public bool OpenRoom(OpenRoomInfoBean orib)
        {
            if (orid.OpenRoom(orib) > 0)
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// 退房操作
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public bool CloseRoom(string Number)
        {
            if (orid.CloseRoom(Number) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
