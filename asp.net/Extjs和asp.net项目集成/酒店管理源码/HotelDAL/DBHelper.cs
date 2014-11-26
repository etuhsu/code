using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//该源码首发自www.51aspx.com(５１aｓpｘ．ｃｏｍ)

namespace HotelDAL
{
    /// <summary>
    /// 数据库连接类
    /// </summary>
    public abstract class DBHelper
    {
        public SqlConnection CreateConn()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConn"]);
            return conn;
        }
    }

    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class SqlHelper : DBHelper
    {
        #region ADO.NET组件
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private DataSet ds;
        #endregion

        /// <summary>
        /// 创建SqlCommand来执行存储过程(带参数)
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public SqlCommand CreateCmd(string procName, SqlParameter[] para)
        {
            try
            {
                conn = CreateConn(); //得到数据库连接
                cmd = new SqlCommand(); //设置Command对象
                cmd.CommandType = CommandType.StoredProcedure; //创建存储过程
                cmd.CommandText = procName; //调用存储过程名称
                cmd.Connection = conn; //创建数据库连接对象
                if (para != null)
                {
                    //添加存储过程参数
                    foreach (SqlParameter sp in para)
                    {
                        cmd.Parameters.Add(sp);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cmd;
        }

        /// <summary>
        /// 创建SqlCommand来执行存储过程(不带参数)
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        public SqlCommand CreateCmd(string procName)
        {
            try
            {
                conn = CreateConn(); //得到数据库连接
                cmd = new SqlCommand(); //设置Command对象
                cmd.CommandType = CommandType.StoredProcedure; //创建存储过程
                cmd.CommandText = procName; //调用存储过程名称
                cmd.Connection = conn; //创建数据库连接对象
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cmd;
        }

        /// <summary>
        /// 增删改操作
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public int RunSql(string procName, SqlParameter[] para)
        {
            int count = 0;
            try
            {
                //得到SqlCommand对象
                cmd = CreateCmd(procName, para);
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        /// <summary>
        /// 查询DataSet(带参数)
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="para">参数</param>
        /// <returns></returns>
        public DataSet GetDataSet(string procName, SqlParameter[] para)
        {
            try
            {
                //得到SqlCommand对象
                cmd = CreateCmd(procName, para);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        /// <summary>
        /// 查询DataSet(不带参数)
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public DataSet GetDataSet(string procName)
        {
            try
            {
                //得到SqlCommand对象
                cmd = CreateCmd(procName);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
    }
}
