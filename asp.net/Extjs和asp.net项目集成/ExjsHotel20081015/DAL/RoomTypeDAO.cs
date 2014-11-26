using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;

namespace DAL
{
    public class RoomTypeDAO
    {
        private DataSet ds;
        SQLHelper sqlhelper = new SQLHelper();

        //查询信息总记录
        public int getInfoCount()
        {
            int count = 0;
            try
            {
                count = sqlhelper.ReturnSQL("select count(*) from  roomtype");
            }
            catch (Exception)
            {
                
                throw;
            }
            return count;
        }

        //得到所有房间类型信息
        public DataSet getAllRoomTypeInfo(int start,int limit)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select top "+limit+" * from roomtype where typeid not in(select top "+start+" typeid from roomtype order by typeid asc)");
            }
            catch (Exception)
            {
                
                throw;
            }
            return ds;
        }

        //删除房间信息
        public int DeleteRoomTypeInfo(int typeid)
        {
            int count = 0;
            try
            {
                count = sqlhelper.RunSQL("delete roomtype where typeid="+typeid);
            }
            catch (Exception)
            {
                
                throw;
            }
            return count;
        }

        //根据typeid查询类型信息加载表单
        public DataSet GetTypeInfoByTypeid(int typeid)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from roomtype where typeid=" + typeid);
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        //更新房间类型信息
        public int saveRoomTypeInfo(RoomTypeBean type)
        { 
            int count=0;
            try
            {
                count = sqlhelper.RunSQL("update roomtype set typename='"+type.typeName+"',typeprice="+type.typePrice+",typeaddbed='"+type.typeAddBed+"',addbed="+type.addbed+",typedesc='"+type.typeDesc+"' where typeid="+type.typeid);
            }
            catch (Exception)
            {
                
                throw;
            }
            return count;
        }

        //添加房间类型信息
        public int AddRoomTypeInfo(RoomTypeBean type)
        {
            int count = 0;
            try
            {
                count = sqlhelper.RunSQL("insert into roomtype values('"+type.typeName+"',"+type.typePrice+",'"+type.typeAddBed+"',"+type.addbed+",'"+type.typeDesc+"')");
            }
            catch (Exception)
            {
                
                throw;
            }
            return count;
        }

        //今日房价信息
        public DataSet TodayRoomTypePrice()
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from roomtype");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //修改今日房价
        public int EditTodayPrice(string typename,decimal typeprice)
        {
            try
            {
                int count = 0;
                count = sqlhelper.RunSQL("update roomtype set typeprice="+typeprice+" where typename='"+typename+"'");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //开房得到所有房间类型信息
        public DataSet OpenRoomGetRoomTypeInfo()
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from roomtype");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }
        //根据房间类型名称判断是否存在
        public int RoomTypeIsOK(string roomTypeName)
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from roomtype where typename='"+roomTypeName+"'");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
