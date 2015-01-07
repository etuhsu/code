using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;

namespace DAL
{
    public class RoomDAO
    {
        SQLHelper sqlhelper = new SQLHelper();
        private DataSet ds;

        //得到房间信息
        public DataSet GetRoomInfoByTypeid(int typeid)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from room where roomstate=0 and  typeid="+typeid);
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //查询房间信息总记录数
        public int GetAllRoomCount()
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from room");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //得到房间信息 分页显示
        public DataSet GetRoomInfoPaging(int start,int limit)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select top " + limit + " * from room where roomid not in(select top " + start + " roomid from room order by roomstate asc) order by roomstate asc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }

        
        }

        //得到房间信息不判断状态
        public RoomBean getRoonInfosNoState(int roomid)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from room where roomid="+roomid);
                RoomBean room = new RoomBean();
                room.roomid=int.Parse(ds.Tables[0].Rows[0]["roomid"].ToString());
                room.Number = ds.Tables[0].Rows[0]["number"].ToString();
                room.bedNumber = int.Parse(ds.Tables[0].Rows[0]["bednumber"].ToString());
                room.guestNumber = int.Parse(ds.Tables[0].Rows[0]["guestnumber"].ToString());
                room.typeid = int.Parse(ds.Tables[0].Rows[0]["typeid"].ToString());
                room.roomstate = int.Parse(ds.Tables[0].Rows[0]["roomstate"].ToString());
                room.roomDesc = ds.Tables[0].Rows[0]["roomdesc"].ToString();
                return room;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //更新房间信息
        public int SaveRoomInfo(RoomBean room)
        {

            try
            {
                int count = sqlhelper.RunSQL("update room set bednumber="+room.bedNumber+",guestnumber="+room.guestNumber+",typeid="+room.typeid+",roomstate="+room.roomstate+",roomdesc='"+room.roomDesc+"' where roomid="+room.roomid);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //添加新房间
        public int AddRoomInfo(RoomBean room)
        {
            try
            {
                int count = sqlhelper.RunSQL("insert into room values('"+room.Number+"',"+room.bedNumber+","+room.guestNumber+","+room.typeid+","+room.roomstate+",'"+room.roomDesc+"')");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //验证房间号是否存在
        public int RoomIDIsOK(string roomid)
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from room where number='"+roomid+"'");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        //删除房间信息
        public int DelRoomInfos(int roomid)
        {
            try
            {
                int count = sqlhelper.RunSQL("delete room where roomid="+roomid);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
