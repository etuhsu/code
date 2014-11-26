using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class OpenRoomRecordInfoDAO
    {
        SQLHelper sqlhelper = new SQLHelper();
        private DataSet ds;

        //房费总额
        public string GetRoomMoney(string roomid)
        {
            try
            {
                SqlParameter[] sp = new SqlParameter[2];
                sp[0] = new SqlParameter("@roomid",SqlDbType.VarChar,10);
                sp[0].Value = roomid;
                sp[1] = new SqlParameter("@AllMoney",SqlDbType.Money);
                sp[1].Direction = ParameterDirection.Output;
                string allmoney = sqlhelper.OutPutProc("proc_GetAllRoomMoney", sp);
                return allmoney;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //得到开房记录总数

        public int GetAllCountOpenRoomRecord()
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from openroomrecordinfo");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //分页得到开房记录

        public DataSet GetOpenRoomInfo(int start,int limit)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select top "+limit+" * from openroomrecordinfo where recordid not in(select top "+start+" recordid from openroomrecordinfo order by endtodaytime desc) order by endtodaytime desc,endtime desc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataSet GetOpenRoomInfoAll(string message)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from openroomrecordinfo where (OpenTodayTime like '%'+'" + message + "'+'%' or OpenTime like '%'+'" + message + "'+'%' or EndTodayTime like '%'+'" + message + "'+'%' or endtime like '%'+'" + message + "'+'%' or Remark like '%'+'" + message + "'+'%') order by endtodaytime desc,endtime desc");
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
