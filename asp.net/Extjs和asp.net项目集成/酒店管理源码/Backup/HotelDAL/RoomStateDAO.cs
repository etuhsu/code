using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelModels;

namespace HotelDAL
{
    public class RoomStateDAO
    {

        SqlHelper sh = new SqlHelper();
        DataSet ds;
        private SqlParameter para; //参数



        /// <summary>
        /// 查询房间状态表(所有)
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllRoomState()
        {
            try
            {
                ds = sh.GetDataSet("GetAllRoomState");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

    }
}
