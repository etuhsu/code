using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HotelModels;
using HotelDAL;

namespace HotelBLL
{
    public class RoomStateBLL
    {
        RoomStateDAO rsd = new RoomStateDAO(); //数据层


        
        /// <summary>
        /// 查询房间状态表(所有)
        /// </summary>
        /// <returns></returns>
        public string  GetAllRoomState()
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = rsd.GetAllRoomState();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("StateId", dr["StateId"].ToString());
                jsonHelp.AddItem("StateName", dr["StateName"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }
    }
}
