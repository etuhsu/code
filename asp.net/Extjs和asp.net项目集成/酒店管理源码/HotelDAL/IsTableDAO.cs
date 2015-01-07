using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelDAL
{
    public class IsTableDAO
    {

        SqlHelper sh = new SqlHelper();
        DataSet ds;


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public DataSet GetIsAll()
        {
            try
            {
                ds = sh.GetDataSet("GetIsAll");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
