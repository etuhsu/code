using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelModels;

namespace HotelDAL
{
    public class RoomTypeDAO
    {

        SqlHelper sh = new SqlHelper();
        DataSet ds;
        private SqlParameter para; //参数


        /// <summary>
        /// 添加房间类型
        /// </summary>
        /// <param name="rtb"></param>
        /// <returns></returns>
        public int AddRoomType(RoomTypeBean rtb)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp = {
                    para = new SqlParameter("@TypeName",rtb.TypeName),
                    para = new SqlParameter("@TypePrice",rtb.TypePrice),
                    para = new SqlParameter("@IsTv",rtb.IsTv),
                    para = new SqlParameter("@IsKongTiao",rtb.IsKongTiao),
                    para = new SqlParameter("@Remark",rtb.Remark)
                };
                count = sh.RunSql("AddRoomType", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }



        /// <summary>
        /// 删除房间类型(根据类型Id)
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public int DelRoomType(int TypeId)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@TypeId",TypeId)
                };
                count = sh.RunSql("DelRoomType", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }



        /// <summary>
        /// 查询所有房间类型(查询房间类型用到,带搜索)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public DataSet GetAllRoomType(string message)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@message",message)
                };
                ds = sh.GetDataSet("GetAllRoomType", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        /// <summary>
        /// 查询所有未被使用的房间类型(删除用到)
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoomType()
        {
            try
            {
                ds = sh.GetDataSet("GetRoomType");
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return ds;
        }



        /// <summary>
        /// 查询今日房价
        /// </summary>
        /// <returns></returns>
        public DataSet GetTodyPrice()
        {
            try
            {
                ds = sh.GetDataSet("GetTodyPrice");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
    }
}
