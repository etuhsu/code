using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using DAL;


namespace BLL
{
    public class RoomTypeBLL
    {
        private DataSet ds;
        RoomTypeDAO dao = new RoomTypeDAO();
        JSONHelper json = new  JSONHelper();
        

        //将DataSet 转换为JSON数据
        public string getRoomTypeInfo(int start,int limit)
        {
            ds = dao.getAllRoomTypeInfo(start,limit);
            json.success = true;
           
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typeid",dr["typeid"].ToString());
                json.AddItem("typename", dr["typename"].ToString());
                json.AddItem("typeprice", dr["typeprice"].ToString());
                json.AddItem("typeaddbed", dr["typeaddbed"].ToString());
                json.AddItem("addbed", dr["addbed"].ToString());
                json.AddItem("typedesc", dr["typedesc"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.getInfoCount();
            string jsons = "";
            if (json.totlalCount > 0)
            {
                jsons = json.ToString();
            }
            else
            {
                jsons = @"{success:false}";
            }
            return jsons;
        }

        //删除房间信息
        public int DeleteRoomTypeInfo(int typeid)
        {
            return dao.DeleteRoomTypeInfo(typeid);
        }

        //根据typeid查类型信息
        public string getRoomTypeInfo(int typeid)
        {
         
            FormJSONHelper json = new FormJSONHelper();
            ds = dao.GetTypeInfoByTypeid(typeid);
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typeid", dr["typeid"].ToString());
                json.AddItem("typename", dr["typename"].ToString());
                json.AddItem("typeprice", dr["typeprice"].ToString());
                json.AddItem("typeaddbed", dr["typeaddbed"].ToString());
                json.AddItem("addbed", dr["addbed"].ToString());
                json.AddItem("typedesc", dr["typedesc"].ToString());
                json.ItemOk();
            }
            string jsons = json.ToString();
            return jsons;
        }

        //保存房间类型信息
        public int saveRoomTypeInfo(RoomTypeBean type)
        {
            return dao.saveRoomTypeInfo(type);
        }

        //添加房间类型信息
        public int AddRoomTypeInfo(RoomTypeBean type)
        {
            return dao.AddRoomTypeInfo(type);
        }

        //今日房价信息
        public string getToDayRoomTypeInfo()
        {
            json.success = true;
            ds = dao.TodayRoomTypePrice();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typename",dr["typename"].ToString());
                json.AddItem("typeprice",dr["typeprice"].ToString());
                json.ItemOk();
            }
            string jsons = "";
            if (json.totlalCount > 0)
            {
                jsons = json.ToString();
            }
            else
            {
                jsons = @"{success:false}";
            }
            return jsons;
        }

          //修改今日房价
        public int EditTodayPrice(string typename, decimal typeprice)
        {
            return dao.EditTodayPrice(typename,typeprice);
        }

        //开房得到房间类型信息
        public string OpenRoomGetAllRoomTypeInfos()
        {
            ds = dao.OpenRoomGetRoomTypeInfo();
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typeid", dr["typeid"].ToString());
                json.AddItem("typename", dr["typename"].ToString());
                json.AddItem("typedesc", dr["typedesc"].ToString());
                json.ItemOk();
            }
            string jsonss = json.ToString();
            return jsonss;
        }
         //根据房间类型名称判断是否存在
        public int RoomTypeIsOK(string roomTypeName)
        {
            return dao.RoomTypeIsOK(roomTypeName);
        }
    }
}
