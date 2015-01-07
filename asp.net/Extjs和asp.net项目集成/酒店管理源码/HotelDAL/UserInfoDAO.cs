using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelModels;

namespace HotelDAL
{
    public class UserInfoDAO
    {
        SqlHelper sh = new SqlHelper();
        DataSet ds;
        private SqlParameter para; //参数



        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="uib"></param>
        /// <returns></returns>
        public DataTable GetLogin(UserInfoBean uib)
        {
            SqlParameter[] sp ={
                para = new SqlParameter("@LoginName",uib.LoginName),
                para = new SqlParameter("@LoginPass",uib.LoginPass)
            };
            ds = sh.GetDataSet("GetLogin", sp);
            return ds.Tables[0];
        }



        /// <summary>
        /// 检查登录名是否重复
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataSet CheckUserId(string UserId)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@LoginName",UserId)
                };
                ds = sh.GetDataSet("CheckUserId", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        /// <summary>
        /// 添加普通员工
        /// </summary>
        /// <param name="uib"></param>
        /// <returns></returns>
        public int AddUser(UserInfoBean uib)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                para = new SqlParameter("@LoginName",uib.LoginName),
                para = new SqlParameter("@LoginPass",uib.LoginPass),
                para = new SqlParameter("@UserName",uib.UserName),
                para = new SqlParameter("@Remark",uib.Remark)
                };
                count = sh.RunSql("AddUser", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }



        /// <summary>
        /// 查询所有员工(删除用到)
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public DataSet GetUser(string LoginName)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@LoginName",LoginName)
                };
                ds = sh.GetDataSet("GetUser", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        /// <summary>
        /// 删除员工(根据Id删除)
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public int DelUser(int UserId)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@UserId",UserId)
                };
                count = sh.RunSql("DelUser", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
    }
}
