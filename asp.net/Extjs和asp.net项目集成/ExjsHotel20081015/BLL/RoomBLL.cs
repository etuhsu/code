using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class RoomBLL
    {
        RoomDAO dao = new RoomDAO();
        private DataSet ds;
        //得到房间信息
        public string GetRoomInfosByTypeid(int typeid)
        {
            JSONHelper json = new JSONHelper();
            ds = dao.GetRoomInfoByTypeid(typeid);
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("roomid",dr["roomid"].ToString());
                json.AddItem("number",dr["number"].ToString());
                json.AddItem("roomdesc", dr["roomdesc"].ToString());
                json.ItemOk();
            }
            string jsons = json.ToString();
            return jsons;
        }
        //查询房间信息分页
        public string GetRoomInfoPage(int start,int limit)
        {
            JSONHelper json = new JSONHelper();
            ds = dao.GetRoomInfoPaging(start, limit);
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("roomid", dr["roomid"].ToString());
                json.AddItem("number", dr["number"].ToString());
                json.AddItem("bednumber", dr["bednumber"].ToString());
                json.AddItem("guestnumber", dr["guestnumber"].ToString());
                json.AddItem("typeid", dr["typeid"].ToString());
                json.AddItem("roomstate", dr["roomstate"].ToString());
                json.AddItem("roomdesc", dr["roomdesc"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetAllRoomCount();
            string jsons="";
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
        //得到房间信息不判断状态
        public RoomBean getRoonInfosNoState(int roomid)
        {
            return dao.getRoonInfosNoState(roomid);
        }
          //更新房间信息
        public int SaveRoomInfo(RoomBean room)
        {
            return dao.SaveRoomInfo(room);
        }
        //添加新房间
        public int AddRoomInfo(RoomBean room)
        {
            return dao.AddRoomInfo(room);
        }
        //验证房间号是否存在
        public int RoomIDIsOK(string roomid)
        {
            return dao.RoomIDIsOK(roomid);
        }
        //删除房间信息
        public int DelRoomInfos(int roomid)
        {
            return dao.DelRoomInfos(roomid);
        }
    }
}
