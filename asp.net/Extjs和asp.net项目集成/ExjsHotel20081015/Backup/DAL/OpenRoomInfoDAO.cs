using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class OpenRoomInfoDAO
    {
        private DataSet ds;
        SQLHelper sqlhelper = new SQLHelper();
        private SqlParameter para;


        //��ѯopenroom���ܼ�¼��
        public int GetOpenRoomAllCount()
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from openroominfo");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //��ҳ��ѯ
        public DataSet GetRoomOpenInfo(int start, int limit)
        {

            try
            {
                ds = sqlhelper.GetDataSet("select top " + limit + " * from OpenRoomInfo where openroomid not in(select top " + start + " openroomid from openroominfo order by OpenTodayTime DESC) order by OpenTodayTime DESC,opentime DESC");
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //���濪����Ϣ
        public int SaveOpenRoomInfo(OpenRoomInfoBean open)
        {
            try
            {
                SqlParameter[] sp ={ 
                    para=new SqlParameter("@Roomid",open.Roomid),
                    para=new SqlParameter("@GuestMoney",open.GuestMoney),
                    para=new SqlParameter("@Remark",open.Remark)
                };
                int count = sqlhelper.RunProc("proc_OpenRoomInfo",sp);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //�޸Ŀ�����Ϣ
        public int EditOpenRoomInfo(OpenRoomInfoBean open)
        {
            try
            {
                int count = sqlhelper.RunSQL("update openroominfo set guestmoney="+open.GuestMoney+",Remark='"+open.Remark+"' where roomid="+open.Roomid);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //ɾ��������Ϣ
        public int DelOpenRoomInfo(int OpenRoomID)
        {
            try
            {
                int count = sqlhelper.RunSQL("delete openroominfo where openroomid="+OpenRoomID);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
