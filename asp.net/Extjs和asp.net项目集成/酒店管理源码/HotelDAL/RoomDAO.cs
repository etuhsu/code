using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelModels;
//该源码首发自www.51aspx.com(５１ａｓpｘ．ｃｏｍ)

namespace HotelDAL
{
    public class RoomDAO
    {

        SqlHelper sh = new SqlHelper();
        DataSet ds;
        private SqlParameter para; //参数


        /// <summary>
        /// 根据类型Id查询所有客房信息(状态为空闲)
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public DataSet GetRoomByTypeId(int TypeId)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@TypeId",TypeId)
                };
                ds = sh.GetDataSet("GetRoomByTypeId", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        /// <summary>
        /// 添加客房表
        /// </summary>
        /// <param name="rb"></param>
        /// <returns></returns>
        public int AddRoom(RoomBean rb)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@Number",rb.Number),
                    para = new SqlParameter("@BedNumber",rb.BedNumber),
                    para = new SqlParameter("@TypeId",rb.TypeId),
                    para = new SqlParameter("@StateId",rb.StateId),
                    para = new SqlParameter("@Remark",rb.Remark)
                };
                count = sh.RunSql("AddRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }


       
        /// <summary>
        /// 查询所有客房信息(查看客房信息用到,带搜索)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public DataSet GetAllRoom(string message)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@message",message)
                };
                ds = sh.GetDataSet("GetAllRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        /// <summary>
        /// 查询所有状态为空闲的房间(删除客房时用到)
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoom()
        {
            try
            {
                ds = sh.GetDataSet("GetRoom");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        /// <summary>
        /// 删除客房表(根据房间编号)
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public int DelRoom(string Number)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@Number",Number)
                };
                count = sh.RunSql("DelRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
    }
}
