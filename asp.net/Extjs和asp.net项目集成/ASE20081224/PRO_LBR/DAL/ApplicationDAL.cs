using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NetServ.Net.Json;
using Res.DBUtility;
using System.Globalization;
using Res.IDAL;

namespace Res.DAL
{
  public  class ApplicationDAL : IApplication
    {
        #region [SQL 字段处理方法]
        private int IsInt(SqlDataReader reader, int n)
        {
            if (reader.IsDBNull(n) == true)
            {
                return 0;
            }
            else
            {
                return reader.GetInt32(n);
            }
        }
        private string IsString(SqlDataReader reader, int n)
        {
            if (reader.IsDBNull(n) == true)
            {
                return "";
            }
            else
            {
                return reader.GetString(n);
            }
        }
        private Decimal IsDecimal(SqlDataReader reader, int n)
        {
            if (reader.IsDBNull(n) == true)
            {
                return 0;
            }
            else
            {
                return System.Convert.ToDecimal(reader.GetValue(n));
            }
        }
        private DateTime IsDateTime(SqlDataReader reader, int n)
        {
            if (reader.IsDBNull(n) == true)
            {
                return DateTime.MinValue;
            }
            else
            {
                return reader.GetDateTime(n);
            }
        }
        private float IsFloat(SqlDataReader reader, int n)
        {
            if (reader.IsDBNull(n) == true)
            {
                return 0;
            }
            else
            {
                return (float)Convert.ToSingle(reader.GetValue(n));
            }
        }
        private double IsDouble(SqlDataReader reader, int n)
        {
            if (reader.IsDBNull(n) == true)
            {
                return 0;
            }
            else
            {
                return System.Convert.ToDouble(reader.GetValue(n));
            }
        }
        private bool IsBit(SqlDataReader reader, int n)
        {
            if (reader.IsDBNull(n) == true)
            {
                return false;
            }
            else
            {
                return (System.Convert.ToInt32(reader.GetValue(n)) == 1);
            }
        }
        #endregion [SQL 字段处理方法]
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddApplication(SqlTransaction trans, Res.Model.ApplicationObj model,out int app_id)
        {
            string sql = "PROC_APP_RAPPLICATION_ADD";
            SqlParameter[] parameters = {
					new SqlParameter("@APP_ID", SqlDbType.Int,4),
					new SqlParameter("@APP_CAUSE", SqlDbType.VarChar,500),
					new SqlParameter("@APP_ATE_ID", SqlDbType.VarChar,10),
					new SqlParameter("@APP_ADS_ID", SqlDbType.VarChar,10),
					new SqlParameter("@APP_USER_ID", SqlDbType.VarChar,5),

					new SqlParameter("@APP_DATE", SqlDbType.DateTime),
					new SqlParameter("@APP_FROM_TIME", SqlDbType.VarChar,50),
					new SqlParameter("@APP_TO_TIME", SqlDbType.VarChar,50),
					new SqlParameter("@APP_NUM_TIME", SqlDbType.VarChar,20),
					new SqlParameter("@APP_CREATIONUID", SqlDbType.VarChar,5),

                    new SqlParameter("@APP_LEE_OTE_ID", SqlDbType.Int)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.APP_CAUSE;
            parameters[2].Value = model.APP_ATE_ID;
            parameters[3].Value = model.APP_ADS_ID;
            parameters[4].Value = model.APP_USER_ID;

            parameters[5].Value = model.APP_DATE;
            parameters[6].Value = model.APP_FROM_TIME;
            parameters[7].Value = model.APP_TO_TIME;
            parameters[8].Value = model.APP_NUM_TIME;
            parameters[9].Value = model.APP_CREATIONUID;

            parameters[10].Value = model.APP_LEE_OTE_ID;

            int result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sql, parameters);
            app_id = Convert.ToInt32(parameters[0].Value);
            return result;
        }
        /// <summary>
        /// 得到人是资料信息
        /// </summary>
        public string GetUserByUser_id(string user_id)
        {
            string sql = " SELECT  USER_CNAME,USER_NAME,USER_ID,USER_DEPARTMENT,USER_SHIFT FROM users where USER_ID=@USER_ID";
            SqlParameter param = new SqlParameter("@USER_ID",SqlDbType.VarChar,5);
            param.Value = user_id;
            JsonObject record = new JsonObject();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, param))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        record.Add("USER_CNAME", IsString(reader, 0));
                        record.Add("USER_NAME", IsString(reader, 1));
                        record.Add("USER_ID", IsString(reader, 2));
                        record.Add("USER_DEPARTMENT", IsString(reader, 3));
                        record.Add("USER_SHIFT", IsString(reader, 4));

                    }
                }
            }
            IJsonWriter iwriter = new JsonWriter();
            record.Write(iwriter);
            return iwriter.ToString();

        }
        public string GetApplication(string strWhere)
        {
            string sql = " SELECT * FROM VM_APPLICATION ";
            if (string.IsNullOrEmpty(strWhere) == false)
            {
                sql += " where " + strWhere;
            }
            JsonObject records = new JsonObject();
            JsonArray jay = new JsonArray();
            using (SqlDataReader reader=SqlHelper.ExecuteReader(SqlHelper.ConnectionString,CommandType.Text,sql,null))
            {
                if(reader!=null)
                {
                    while(reader.Read())
                    {
                        JsonObject record=new JsonObject();
                            record.Add("APP_ID",IsInt(reader, 0));
                            record.Add("APP_DATE",IsDateTime(reader, 1).ToString("yyyy-MM-dd"));
                            record.Add("APP_FROM_TIME",IsString(reader, 2));
                            record.Add("APP_TO_TIME",IsString(reader, 3));
                            record.Add("APP_NUM_TIME",IsString(reader, 4));
                            record.Add("APP_CAUSE",IsString(reader, 5));
                            record.Add("ATE_ID",IsInt(reader, 6));
                         if(IsInt(reader, 6)==1)//请假
                         {
                            record.Add("LEE_OTE_CODE",IsString(reader, 10));
                            record.Add("LEE_OTE_NAME",IsString(reader, 11));

                         }
                         else if(IsInt(reader, 6)==2)//加班
                         {
                            record.Add("LEE_OTE_CODE",IsString(reader, 12));
                            record.Add("LEE_OTE_NAME",IsString(reader, 13));

                         }
                            record.Add("ATE_NAME",IsString(reader, 7));//JIA BAN

                            record.Add("ADS_CODE",IsString(reader, 8));
                            record.Add("ADS_NAME",IsString(reader, 9));

                            record.Add("USER_ID",IsString(reader, 14));
                            record.Add("USER_CNAME",IsString(reader, 15));
                            record.Add("USER_DEPARTMENT",IsString(reader, 16));
                            record.Add("USER_SHIFT",IsString(reader, 17));

                            record.Add("APP_CREATE_DT", IsDateTime(reader, 18).ToString("yyyy-MM-dd hh:mm:ss"));
                            record.Add("APP_DISPOSED", IsBit(reader, 19));
                        jay.Add(record);
                    }

                }
            }
            records.Add("LIST", jay);
            IJsonWriter IWriter =new JsonWriter();
            records.Write(IWriter);
            return IWriter.ToString();

        }
      public string QueryApplication(string strWhere)
      {
          StringBuilder SQL =new StringBuilder();
          SQL.Append(" SELECT * FROM VM_APPLICATION ");
          
          if (string.IsNullOrEmpty(strWhere) == false)
          {
              SQL.Append(" WHERE ");
              SQL.Append(strWhere);
          }
          JsonObject records = new JsonObject();
          JsonArray jay = new JsonArray();
          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, SQL.ToString(), null))
          {
              if (reader != null)
              {
                  while (reader.Read())
                  {
                      JsonObject record = new JsonObject();
                      record.Add("APP_ID", IsInt(reader, 0));
                      record.Add("APP_DATE", IsDateTime(reader, 1).ToString("yyyy-MM-dd"));
                      record.Add("APP_FROM_TIME", IsString(reader, 2));
                      record.Add("APP_TO_TIME", IsString(reader, 3));
                      record.Add("APP_NUM_TIME", IsString(reader, 4));
                      record.Add("APP_CAUSE", IsString(reader, 5));
                      record.Add("ATE_ID", IsInt(reader, 6));
                      if (IsInt(reader, 6) == 1)//请假
                      {
                          record.Add("LEE_OTE_CODE", IsString(reader, 10));
                          record.Add("LEE_OTE_NAME", IsString(reader, 11));

                      }
                      else if (IsInt(reader, 6) == 2)//加班
                      {
                          record.Add("LEE_OTE_CODE", IsString(reader, 12));
                          record.Add("LEE_OTE_NAME", IsString(reader, 13));

                      }
                      record.Add("ATE_NAME", IsString(reader, 7));//JIA BAN

                      record.Add("ADS_CODE", IsString(reader, 8));
                      record.Add("ADS_NAME", IsString(reader, 9));

                      record.Add("USER_ID", IsString(reader, 14));
                      record.Add("USER_CNAME", IsString(reader, 15));
                      record.Add("USER_DEPARTMENT", IsString(reader, 16));
                      record.Add("USER_SHIFT", IsString(reader, 17));

                      record.Add("APP_CREATE_DT", IsDateTime(reader, 18).ToString("yyyy-MM-dd hh:mm:ss"));
                      record.Add("APP_DISPOSED", IsBit(reader, 19));
                      jay.Add(record);
                  }

              }
          }
          records.Add("LIST", jay);
          IJsonWriter IWriter = new JsonWriter();
          records.Write(IWriter);
          return IWriter.ToString();

      }
        public DataSet DownApplication(string strWhere)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.Append(" SELECT TEST, OVERTIME ,CARD ,USER_DEPARTMENT, USER_SHIFT ,USER_ID, USER_CNAME ,APP_DATE, LEE_CODE, APP_FROM_TIME, APP_TO_TIME ,APP_NUM_TIME ,APP_CAUSE FROM VM_APP_DOWNLOAD ");
            if (string.IsNullOrEmpty(strWhere)==false)
            {
                SQL.Append(" where ");
                SQL.Append(strWhere);
            }
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            conn.Open();
            SqlCommand com = new SqlCommand(SQL.ToString());
            com.Connection = conn;
            SqlDataAdapter adr = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adr.Fill(ds);
            return ds;
        }

       public int DelApplicationByAPP_ID(string[] IDList, string userid)
        {
            string sql = "UPDATE APP_RAPPLICATION SET APP_DELETED=1 WHERE APP_ID=@APP_ID ";//AND APP_USER_ID=@USER_ID";
            SqlParameter[] paramers = new SqlParameter[]
                            {new SqlParameter("@APP_ID", SqlDbType.Int),
                            new SqlParameter("@USER_ID",SqlDbType.VarChar,5)};
           
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    foreach (string ID in IDList)
                    {
                        paramers[0].Value = Convert.ToInt32(ID);
                        paramers[1].Value = userid;
                        if (SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, paramers) > 0)
                        {
                            continue;
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    trans.Commit();
                    conn.Close();
                    
                }
                catch (SqlException)
                {
                    trans.Rollback();
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
            return IDList.Length;
        }
      public int DisponseApplication(string[] IDList, string userid)
      {
          string sql = "UPDATE APP_RAPPLICATION SET APP_DISPOSED=1 WHERE APP_ID=@APP_ID ";
          SqlParameter[] paramers = new SqlParameter[]
                            {new SqlParameter("@APP_ID", SqlDbType.Int),
                            new SqlParameter("@USER_ID",SqlDbType.VarChar,5)};
          int result = 0;
          foreach (string ID in IDList)
          {
              paramers[0].Value = Convert.ToInt32(ID);
              paramers[1].Value = userid;
              result += SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, paramers);
          }
          return result;

      }
      public int GetBoolDispose( string userid)
      {
          string sql = "SELECT POM_DISPOSE FROM APP_POPEDOM WHERE   POM_DISPOSE=1 AND POM_USER_ID='" + userid + "'";

           SqlDataReader reader=SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null);

           if (reader.HasRows)
           {
                return 1;
           }
           else
           {
               return 0;
           }


      }

    }
}
