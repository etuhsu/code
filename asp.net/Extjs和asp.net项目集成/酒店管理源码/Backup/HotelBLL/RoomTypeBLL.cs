using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HotelModels;
using HotelDAL;

namespace HotelBLL
{
    public class RoomTypeBLL
    {
        RoomTypeDAO rtd = new RoomTypeDAO(); //数据层

        /// <summary>
        /// 添加房间类型
        /// </summary>
        /// <param name="rtb"></param>
        /// <returns></returns>
        public bool AddRoomType(RoomTypeBean rtb)
        {
            if (rtd.AddRoomType(rtb) > 0)
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// 删除房间类型(根据类型Id)
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public bool DelRoomType(int TypeId)
        {
            if (rtd.DelRoomType(TypeId) > 0)
            {
                return true;
            }
            return false;
        }


        
        /// <summary>
        /// 查询所有房间类型(查询房间类型用到,带搜索)
        /// </summary>
        /// <returns></returns>
        public string GetAllRoomType(string message)
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = rtd.GetAllRoomType(message);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("TypeId", dr["TypeId"].ToString());
                jsonHelp.AddItem("TypeName", dr["TypeName"].ToString());
                jsonHelp.AddItem("TypePrice", dr["TypePrice"].ToString());
                jsonHelp.AddItem("IsTv", dr["IsTv"].ToString());
                jsonHelp.AddItem("IsKongTiao", dr["IsKongTiao"].ToString());
                jsonHelp.AddItem("Remark", dr["Remark"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }



        /// <summary>
        /// 查询所有未被使用的房间类型(删除用到)
        /// </summary>
        /// <returns></returns>
        public string GetRoomType()
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = rtd.GetRoomType();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("TypeId", dr["TypeId"].ToString());
                jsonHelp.AddItem("TypeName", dr["TypeName"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }




        /// <summary>
        /// 查询今日房价
        /// </summary>
        /// <returns></returns>
        public string GetTodyPrice()
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = rtd.GetTodyPrice();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("TypeName", dr["TypeName"].ToString());
                jsonHelp.AddItem("TypePrice", dr["TypePrice"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }

    }
}
