using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HotelDAL
{
    public class MoneyInfoDAO
    {

        SqlHelper sh = new SqlHelper();
        DataSet ds;
        private SqlParameter para; //参数


        /// <summary>
        /// 查账(全查,根据时间查询都可以)
        /// </summary>
        /// <returns></returns>
        public DataSet SerachMoney(string BeginTime,string EndTime)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@BeginTime",BeginTime),
                    para = new SqlParameter("@EndTime",EndTime)
                };
                ds = sh.GetDataSet("SerachMoney", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
