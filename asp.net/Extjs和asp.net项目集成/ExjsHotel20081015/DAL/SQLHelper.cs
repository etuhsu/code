using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public abstract class DBHelper
    {
        public SqlConnection Getconn()
        {
            string Strconn = ConfigurationManager.AppSettings["conn"].ToString();
            SqlConnection conn = new SqlConnection(Strconn);
            return conn;
        }
    }

    public class SQLHelper:DBHelper
    {

        private DataSet ds;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter sda;

        //数据库操作类

        public int RunSQL(string sql)
        {
            int count = 0;
            try
            {
                conn = Getconn();
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally {
                conn.Close();
            }
            return count;
        }

        //返回首行首列
        public int ReturnSQL(string sql)
        {
            int count = 0;
            try
            {
                conn = Getconn();
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {                
                throw;
            }finally{
                conn.Close();
            }
            return count;
        
        }

        //返回DataSet
        public DataSet GetDataSet(string sql)
        {
            try
            {
                conn = Getconn();
                sda = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception)
            {
                
                throw;
            }finally{
                conn.Close();
            }
            return ds;
        }
        //数据库操作存储过程
        public int RunProc(string procName,SqlParameter [] sp)
        {
            int count = 0;
            try
            {
                conn = Getconn();
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
                cmd.Connection = conn;

                foreach(SqlParameter para in sp)
                {
                    cmd.Parameters.Add(para);
                }

                count = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {  
                conn.Close();
            }
            return count;
        }

        //查询存储过程
        public DataSet GetProcDataSet(string procName,SqlParameter [] sp)
        {
            try
            {
                conn = Getconn();
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
                cmd.Connection = conn;
                foreach(SqlParameter para in sp)
                {
                    cmd.Parameters.Add(para);
                }
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                ds = new DataSet();
                sda.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
            
        }

        //带输出参数存储过程 
        public string OutPutProc(string procName,SqlParameter [] sp)
        {
            try
            {
                conn = Getconn();
                conn.Open();
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
                cmd.Connection = conn;
                if (sp != null && sp.Length > 0)
                {
                    foreach (SqlParameter para in sp)
                    {
                        cmd.Parameters.Add(para);
                    }
                }
                cmd.ExecuteNonQuery();
                string allmoney = string.Empty;
                if (sp != null && sp.Length > 0)
                {
                    for (int i = 0; i < sp.Length; i++)
                    {
                        if (sp[i].Direction == ParameterDirection.Output)
                        {
                            allmoney = Convert.ToString(sp[i].Value);
                        }

                    }
                }
                return allmoney;

            }
            catch (Exception)
            {

                throw;
            }
            finally {
                conn.Close();
            }

        }
    }
}
