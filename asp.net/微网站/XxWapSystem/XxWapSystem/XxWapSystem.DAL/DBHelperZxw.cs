using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// DBHelper 的摘要说明
/// </summary>
public class DBHelperZxw
{
    private static string connectionString = ConfigurationManager.ConnectionStrings["Sql2008Zxw"].ConnectionString;

	public DBHelperZxw()
	{
		
	}
    /// <summary>
    /// 根据SQL命令判断记录是否存在
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public static bool Exists(string strSql)
    {
        object obj = GetSingle(strSql);
        int cmdresult;
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        {
            cmdresult = 0;
        }
        else
        {
            cmdresult = int.Parse(obj.ToString());
        }
        if (cmdresult == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static object GetSingle(string strSql)
    {
        throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// 执行不带参数的增、删、改sql语句
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <returns>返回SqlCommand</returns>
    public static int ExecuteCmd(string sql)
    {
        //创建数据库
        using (SqlConnection myConn = new SqlConnection(connectionString))
        {
            //打开数据库
            myConn.Open();
            //创建一个sqlCommand实例,并执行SQL语句或存储过程
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            //返回SqlCommand
            return myCmd.ExecuteNonQuery();
        }
    }
    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    connection.Close();
                    throw new Exception(E.Message);
                }
            }
        }
    }
    public int ExeSql(string Sql)
    {
        SqlConnection myConnection = new SqlConnection(connectionString);
        SqlCommand myCommand = new SqlCommand(Sql, myConnection);
        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Dispose();
            myConnection.Close();
            return 1;
        }
        catch
        {
            myCommand.Dispose();
            myConnection.Close();
            return 0;
        }
    }  // 执行无提取值的 SQL 语句。

    /// <summary>
    /// 执行查询语句，返回SqlDataReader
    /// </summary>
    /// <param name="strSQL">查询语句</param>
    /// <returns>SqlDataReader</returns>
    public static SqlDataReader ExecuteReader(string strSQL)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(strSQL, connection);
        try
        {
            connection.Open();
            SqlDataReader myReader = cmd.ExecuteReader();
            return myReader;
        }
        catch (System.Data.SqlClient.SqlException e)
        {
            throw new Exception(e.Message);
        }

    }	
    /// <summary>
    /// 执行带参数的增、删、改sql语句
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="pars">参数数组</param>
    /// <returns>返回SqlCommand</returns>
    public static int ExecuteCmd(string sql, SqlParameter[] pars)
    {
        //创建数据库
        using (SqlConnection myConn = new SqlConnection(connectionString))
        {
            //打开数据库
            myConn.Open();
            //创建一个sqlCommand实例,并执行SQL语句或存储过程
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            //将读取到的值添加到数组pars中
            myCmd.Parameters.AddRange(pars);
            //返回SqlCommand
            return myCmd.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// 利用适配器进行查询操作，返回DataSet
    /// </summary>
    /// <param name="sql">SQl语句</param>
    /// <returns>返回dataset类型数据的table参数</returns>
    public static DataSet QueryData(string sql)
    {
        //创建数据库
        using (SqlConnection myConn = new SqlConnection(connectionString))
        {
            //创建一个SqlDataAdapter实例,并执行SQL语句或存储过程
            SqlDataAdapter myDa = new SqlDataAdapter(sql, myConn);
            //定义一个数据集,用来赋值给应用程序的一个数据集
            DataSet myds = new DataSet();
            //将DataSet类型数据加入到table中
            myDa.Fill(myds, "table");
            //返回dataset类型数据的table参数
            return myds;
        }
    }

    
    /// <summary>
    /// 返回读取器的查询
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="pars">参数数组</param>
    /// <returns>返回SqlCommand</returns>
    public static SqlDataReader ExecuteReader(string sql, SqlParameter [] pars)
    {
        //创建数据库
        SqlConnection myConn = new SqlConnection(connectionString);
        //打开数据库
        myConn.Open();
        //创建一个SqlCommand的实例,表示要执行SQL语句或存储过程
        SqlCommand myCmd = new SqlCommand(sql, myConn);
        //将读取到的值添加到数组pars中
        myCmd.Parameters.AddRange(pars);
        //返回SqlCommand
        return myCmd.ExecuteReader();
    }
    /// <summary>
    /// 此方法返回一个SqlDataReader类型的参数
    /// </summary>
    /// <param name="SqlCom"></param>
    /// <returns></returns>
    public static SqlDataReader ExceRead(string sql)
    {
        SqlConnection myConn = new SqlConnection(connectionString);
        myConn.Open();   //打开链接
        //创建一个SqlCommand对象，表示要执行的SqlCom语句或存储过程
        SqlCommand myCmd = new SqlCommand(sql, myConn);
        SqlDataReader read = myCmd.ExecuteReader();
        return read;
    }
    /// <summary>
    /// 返回第一行第一列的查询
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <returns>返回SqlCommand</returns>
    public static object ExecuteSaclar(string sql)
    {
        //创建数据库
        using (SqlConnection myConn = new SqlConnection(connectionString))
        {
            //打开数据库
            myConn.Open();
            //创建一个SqlCommend实例, 表示要执行SQL语句或存储过程
            SqlCommand myCmd = new SqlCommand(sql, myConn);
            //返回SqlDataReader
            return myCmd.ExecuteScalar();
        }
    }
    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }
    }
    #region 存储过程操作

    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    /// <returns>SqlDataReader</returns>
    public static SqlDataReader RunReaderProcedure(string storedProcName, IDataParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataReader returnReader;
        connection.Open();
        SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        command.CommandType = CommandType.StoredProcedure;
        returnReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        return returnReader;
    }

    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    public static void RunProcedure(string storedProcName, IDataParameter[] parameters)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        command.CommandType = CommandType.StoredProcedure;
        command.ExecuteNonQuery();
        connection.Close();
    }


    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    /// <param name="tableName">DataSet结果中的表名</param>
    /// <returns>DataSet</returns>
    public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet dataSet = new DataSet();
            connection.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
            sqlDA.Fill(dataSet, tableName);
            connection.Close();
            return dataSet;
        }
    }


    /// <summary>
    /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
    /// </summary>
    /// <param name="connection">数据库连接</param>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    /// <returns>SqlCommand</returns>
    private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
    {
        SqlCommand command = new SqlCommand(storedProcName, connection);
        command.CommandType = CommandType.StoredProcedure;
        foreach (SqlParameter parameter in parameters)
        {
            command.Parameters.Add(parameter);
        }
        return command;
    }

    /// <summary>
    /// 执行存储过程，返回影响的行数		
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    /// <param name="rowsAffected">影响的行数</param>
    /// <returns>int</returns>
    public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            int result;
            connection.Open();
            SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
            rowsAffected = command.ExecuteNonQuery();
            result = (int)command.Parameters["ReturnValue"].Value;
            connection.Close();
            return result;
        }
    }

    /// <summary>
    /// 创建 SqlCommand 对象实例(用来返回一个整数值)
    /// </summary>
    /// <param name="connection">数据库连接对象</param>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数</param>
    /// <returns>SqlCommand 对象实例</returns>
    private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
    {
        SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        command.Parameters.Add(new SqlParameter("ReturnValue",
            SqlDbType.Int, 4, ParameterDirection.ReturnValue,
            false, 0, 0, string.Empty, DataRowVersion.Default, null));
        return command;
    }
    #endregion	

    internal static bool Exists(string p, SqlParameter[] parameters)
    {
        throw new Exception("The method or operation is not implemented.");
    }
}
