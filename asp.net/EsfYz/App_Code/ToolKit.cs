using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using System.Collections;

/// <summary>
///ToolKit 的摘要说明
/// </summary>
namespace EsfYz
{
    public class ToolKit
    {
        public ToolKit()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }
        public OracleConnection Get_Fdc_Conn()//读数据连接
        {
            string connstr = "Data Source=fdc;Persist Security Info=True;User ID=fdcmain;Password=fdcmain;Unicode=True";
            OracleConnection conn = new OracleConnection(connstr);

            return conn;
        }
        public DataTable Get_Tbl(string sql)
        {
            OracleCommand command = new OracleCommand(sql, Get_Fdc_Conn());
            DataTable Tbl = new DataTable();
            OracleDataAdapter adp = new OracleDataAdapter(command);
            adp.Fill(Tbl);
            command.Connection.Close();
            return Tbl;
        }
        public DataRow Get_Row(string sql)
        {
            OracleCommand command = new OracleCommand(sql, Get_Fdc_Conn());
            DataTable Tbl = new DataTable();
            OracleDataAdapter adp = new OracleDataAdapter(command);
            adp.Fill(Tbl);
            command.Connection.Close();

            if (Tbl.Rows.Count > 0)
            {
                return Tbl.Rows[0];
            }
            else
            {
                return null;
            }

        }
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                OracleConnection conn = Get_Fdc_Conn();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = sql;
                conn.Open();
                int i = comm.ExecuteNonQuery();

                conn.Close();
                return i;
            }
            catch (OracleException err)
            {
                string str = err.ToString();
            }
            return 0;
        }
        public object ExecuteOracleScalar(string sql)
        {
            try
            {
                OracleConnection conn = Get_Fdc_Conn();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = sql;
                conn.Open();
                object obj = comm.ExecuteOracleScalar();
                conn.Close();
                return obj;
            }
            catch (OracleException err)
            {
                string str = err.ToString();
            }
            return null;
        }
        public int ExecuteOracleInt(string sql)
        {
            try
            {
                OracleConnection conn = Get_Fdc_Conn();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = sql;
                conn.Open();
                object obj = comm.ExecuteOracleScalar();
                conn.Close();
                return obj == null ? 0 : int.Parse(obj.ToString());
            }
            catch (OracleException err)
            {
                string str = err.ToString();
            }
            return 0;
        }
        public string ExecuteOracleStr(string sql)
        {
            try
            {
                OracleConnection conn = Get_Fdc_Conn();
                OracleCommand comm = new OracleCommand("", conn);
                comm.CommandText = sql;
                conn.Open();
                object obj = comm.ExecuteOracleScalar();
                conn.Close();
                return obj == null ? "" : obj.ToString();
            }
            catch (OracleException err)
            {
                string str = err.ToString();
            }
            return "";
        }
    }
}
