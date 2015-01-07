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

        //��ѯ��Ϣ�ܼ�¼
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

        //�õ����з���������Ϣ
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

        //ɾ��������Ϣ
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

        //����typeid��ѯ������Ϣ���ر�
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

        //���·���������Ϣ
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

        //��ӷ���������Ϣ
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

        //���շ�����Ϣ
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

        //�޸Ľ��շ���
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
        //�����õ����з���������Ϣ
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
        //���ݷ������������ж��Ƿ����
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
