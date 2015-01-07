using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class GuestInfoDAO
    {
        SQLHelper sqlhelper = new SQLHelper();
        private DataSet ds;
        private SqlParameter para;

        //保存客人信息
        public int SaveGuestInfo(GuestInfoBean guest)
        {
            int count = 0;
            try
            {
                SqlParameter [] sp={
                    para = new SqlParameter("@GuestCardID",guest.GuestCardID),
                    para =new SqlParameter("@GuestName",guest.GuestName),
                    para =new SqlParameter("@GuestSex",guest.GuestSex),
                    para =new SqlParameter("@GuestMobile",guest.GuestMobile),
                    para =new SqlParameter("@GuestAddress",guest.GuestAddress)
                };
                count = sqlhelper.RunProc("proc_AddGuestInfo", sp);
            }
            catch (Exception)
            {
                
                throw;
            }
            return count;
        }

        //查询客人信息总记录
        public int GetGuestInfoCount()
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from guestinfo");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        //分页查询客人信息
        public DataSet GetGuestInfo(int start,int limit)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select top " + limit + " * from guestinfo where guestid not in(select top " + start + " guestid from guestinfo order by guestid asc) order by guestid asc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        //修改保存客人信息

        public int EditSaveGuestInfo(GuestInfoBean guest)
        {
            try
            {
                int count = sqlhelper.RunSQL("update guestinfo set guestcardid="+guest.GuestCardID+",guestname='"+guest.GuestName+"',guestsex="+guest.GuestSex+",guestmobile="+guest.GuestMobile+",guestaddress='"+guest.GuestAddress+"' where guestid="+guest.Guestid);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }
        //删除客人信息
        public int DeleteGuestInfo(int guestid)
        {
            try
            {
                int count = sqlhelper.RunSQL("delete guestinfo where guestid="+guestid);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
