using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelModels;

namespace HotelDAL
{
    public class OpenRoomInfoDAO
    {

        SqlHelper sh = new SqlHelper();
        DataSet ds;
        private SqlParameter para; //参数


        
        /// <summary>
        /// 查询所有的开房信息(首页的Grid,带搜索功能)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public DataSet GetOpenRoomInfoAll(string message)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@message",message)
                };
                ds = sh.GetDataSet("GetOpenRoomInfoAll", sp);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return ds;
        }



        /// <summary>
        /// 开房操作
        /// </summary>
        /// <param name="orib"></param>
        /// <returns></returns>
        public int OpenRoom(OpenRoomInfoBean orib)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@RoomId",orib.RoomId),
                    para = new SqlParameter("@GuestNumber",orib.GuestNumber),
                    para = new SqlParameter("@GuestName",orib.GuestName),
                    para = new SqlParameter("@GuestMoney",orib.GuestMoney),
                    para = new SqlParameter("@Remark",orib.Remark)
                };
                count = sh.RunSql("OpenRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }




        /// <summary>
        /// 退房操作
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public int CloseRoom(string Number)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@Number",Number)
                };
                count = sh.RunSql("CloseRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }

    }
}
