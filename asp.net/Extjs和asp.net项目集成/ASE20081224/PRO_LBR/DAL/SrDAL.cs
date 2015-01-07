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
  public  class SrDAL:ISr
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
        public int  AddSrList(Res.Model.Sr_bsrObj  model,out int sr_id)
        {
            string sql = "PROC_SR_BSR_ADD";
            SqlParameter[] parameters = {
					new SqlParameter("@SR_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_TITLE", SqlDbType.VarChar,200),
					new SqlParameter("@SR_PROPOSER", SqlDbType.VarChar,20),
					new SqlParameter("@SR_CLIENT", SqlDbType.VarChar,20),
					new SqlParameter("@SR_IT_COSt", SqlDbType.VarChar,20),
					new SqlParameter("@SR_USER_BENEFIT", SqlDbType.VarChar,200),
					new SqlParameter("@SR_DET_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_LEL_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_RAT_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_SYE_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_OVERDATE", SqlDbType.DateTime),
					new SqlParameter("@SR_SR_FLAG", SqlDbType.Bit,1),
					new SqlParameter("@SR_AR_FLAG", SqlDbType.Bit,1),
					new SqlParameter("@SR_DEMAND_DESC", SqlDbType.Text),
					new SqlParameter("@SR_CREATIONUID", SqlDbType.VarChar,5),
                    new SqlParameter("@SR_CODE", SqlDbType.VarChar,100),
                    new SqlParameter("@SR_PRO_FLAG", SqlDbType.Bit,1),

            		new SqlParameter("@SR_GRP_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_SOD_EXPECT", SqlDbType.DateTime),
                    new SqlParameter("@SR_SOD_UPDATE", SqlDbType.DateTime),
                    new SqlParameter("@SR_IT_OWNER", SqlDbType.VarChar,20)};




            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.SR_TITLE;
            parameters[2].Value = model.SR_PROPOSER;
            parameters[3].Value = model.SR_CLIENT;
            parameters[4].Value = model.SR_IT_COST;
            parameters[5].Value = model.SR_USER_BENEFIT;
            parameters[6].Value = model.SR_DET_ID;
            parameters[7].Value = model.SR_LEL_ID;
            parameters[8].Value = model.SR_RAT_ID;
            parameters[9].Value = model.SR_SYE_ID;
            parameters[10].Value = model.SR_OVERDATE;
            parameters[11].Value = model.SR_SR_FLAG;
            parameters[12].Value = model.SR_AR_FLAG;
            parameters[13].Value = model.SR_DEMAND_DESC;
            parameters[14].Value = model.SR_CREATIONUID;
            parameters[15].Value = model.SR_CODE;
            parameters[16].Value = model.SR_PRO_FLAG;

            parameters[17].Value = model.SR_GRP_ID;
            parameters[18].Value = model.SR_SOD_EXPECT;
            parameters[19].Value = model.SR_SOD_UPDATE;
            parameters[20].Value = model.SR_IT_OWNER;





            int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters);
            sr_id = Convert.ToInt32(parameters[0].Value);
            return result;
        }
      public string GetSrList()
      {
          string sql = "select * from VM_SR ";
          JsonObject records = new JsonObject();
          JsonArray jay = new JsonArray();
          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
          {
              if (reader != null)
              {
                  while (reader.Read())
                  {
                      JsonObject record = new JsonObject();
                      record.Add("SR_ID", IsInt(reader, 0));
                      record.Add("SR_CODE", IsString(reader, 1));
                      record.Add("SR_TITLE", IsString(reader, 2));
                      record.Add("SR_PROPOSER", IsString(reader, 3));
                      record.Add("SR_CLIENT", IsString(reader, 4));
                      record.Add("SR_IT_COST", IsString(reader, 5));
                      record.Add("SR_USER_BENEFIT", IsString(reader, 6));

                      record.Add("SR_OVERDATE", IsDateTime(reader, 7).ToString("yyyy-MM-dd"));

                      record.Add("SR_SR_FLAG", IsBit(reader, 8));
                      record.Add("SR_AR_FLAG", IsBit(reader, 9));

                      record.Add("SR_PRO_FLAG", IsBit(reader, 10));

                      record.Add("SR_DEMAND_DESC", IsString(reader, 11));
                      record.Add("DET_NAME", IsString(reader, 13));
                      record.Add("LEL_NAME", IsString(reader, 15));

                      record.Add("RAT_NAME", IsString(reader, 17).ToString());
                      record.Add("SYE_NAME", IsString(reader, 19));



                      record.Add("SR_CREATIONUID", IsString(reader, 20));
                      record.Add("SR_CREATE_DT", IsDateTime(reader, 21).ToString("yyyy-MM-dd"));

                      record.Add("SR_UPDATEUID", IsString(reader, 22));
                      record.Add("SR_UPDATE_DT", IsDateTime(reader, 23)==DateTime.MinValue ? "" : IsDateTime(reader, 23).ToString("yyyy-MM-dd"));
                      jay.Add(record);
                  }

              }
          }
          records.Add("LIST", jay);
          IJsonWriter IWriter = new JsonWriter();
          records.Write(IWriter);
          return IWriter.ToString();

      }
      /// <summary>
      /// 得到 查询修改  gird  数据根据不同的ITOWNER
      /// </summary>
      /// <param name="strWhere"></param>
      /// <returns></returns>
      public string GetAllSRForModifyByOwner( string strWhere)
      {
          string sql = "select * from VM_SR  A LEFT JOIN USERS AS B ON  A.SR_IT_OWNER=B.USER_CNAME";
          if (string.IsNullOrEmpty(strWhere) == false)
          {
              sql += "  WHERE  " + strWhere;
          }
          JsonObject records = new JsonObject();
          JsonArray jay = new JsonArray();
          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
          {
              if (reader != null)
              {
                  while (reader.Read())
                  {
                      JsonObject record = new JsonObject();
                      record.Add("SR_ID", IsInt(reader, 0));
                      record.Add("SR_CODE", IsString(reader, 1));
                      record.Add("SR_TITLE", IsString(reader, 2));
                      record.Add("SR_PROPOSER", IsString(reader, 3));
                      record.Add("SR_CLIENT", IsString(reader, 4));
                      record.Add("SR_IT_COST", IsString(reader, 5));
                      record.Add("SR_USER_BENEFIT", IsString(reader, 6));

                      record.Add("SR_OVERDATE", IsDateTime(reader, 7).ToString("yyyy-MM-dd"));
                      record.Add("SR_SR_FLAG", IsBit(reader, 8));
                      record.Add("SR_AR_FLAG", IsBit(reader, 9));
                      record.Add("SR_PRO_FLAG", IsBit(reader, 10));

                      record.Add("SR_DEMAND_DESC", IsString(reader, 11));

                      record.Add("DET_ID", IsInt(reader, 12));
                      record.Add("DET_NAME", IsString(reader, 13));
                      record.Add("LEL_ID", IsInt(reader, 14));
                      record.Add("LEL_NAME", IsString(reader, 15));
                      record.Add("RAT_ID", IsInt(reader, 16).ToString());
                      record.Add("RAT_NAME", IsString(reader, 17).ToString());
                      record.Add("SYE_ID", IsInt(reader, 18));
                      record.Add("SYE_NAME", IsString(reader, 19));



                      record.Add("SR_CREATIONUID", IsString(reader, 20));
                      record.Add("SR_CREATE_DT", IsDateTime(reader, 21).ToString("yyyy-MM-dd"));
                      record.Add("SR_UPDATEUID", IsString(reader, 22));
                      record.Add("SR_UPDATE_DT", IsDateTime(reader, 23) == DateTime.MinValue ? "" : IsDateTime(reader, 23).ToString("yyyy-MM-dd"));

                      record.Add("SR_IT_OWNER", IsString(reader, 27));
                      record.Add("SR_GRP_ID", IsInt(reader, 28));
                      record.Add("SR_SOD_EXPECT", IsDateTime(reader, 29).ToString("yyyy-MM-dd"));
                      record.Add("SR_SOD_UPDATE", IsDateTime(reader, 30).ToString("yyyy-MM-dd"));
   
                      jay.Add(record);
                  }

              }
          }
          records.Add("LIST", jay);
          IJsonWriter IWriter = new JsonWriter();
          records.Write(IWriter);
          return IWriter.ToString();

      }
      public string GetSrStatus(string userStr)
      {
          string sql = "PROC_SR_STATUS_MODEL  ";
          SqlParameter param = new SqlParameter("@USER_ID", SqlDbType.VarChar, 5);
          param.Value = userStr;
          JsonObject records = new JsonObject();
          JsonArray jay = new JsonArray();
          using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, param))
          {
              if (reader != null)
              {
                  while (reader.Read())
                  {
                  JsonObject record = new JsonObject();
                      record.Add("SR_ID", IsInt(reader, 0));
                      record.Add("SR_CODE", IsString(reader, 1));
                      record.Add("SR_TITLE", IsString(reader, 2));
                      record.Add("SR_PROPOSER", IsString(reader, 3));
                      record.Add("SR_SR_FLAG", IsBit(reader, 4));

                      record.Add("SR_AR_FLAG", IsBit(reader, 5));
                      record.Add("SR_PRO_FLAG", IsBit(reader, 6));
                      record.Add("SR_CREATIONUID", IsString(reader, 7));
                      record.Add("SR_CREATE_DT", IsDateTime(reader, 8).ToString("yyyy-MM-dd"));
                      record.Add("SR_UPDATEUID", IsString(reader, 9));

                      record.Add("SR_UPDATE_DT", IsDateTime(reader, 10) == DateTime.MinValue ? "" : IsDateTime(reader, 10).ToString("yyyy-MM-dd"));
                      record.Add("STS_NAME", IsString(reader, 11));
                      jay.Add(record);
                  }

              }
          }
          records.Add("LIST", jay);
          IJsonWriter IWriter = new JsonWriter();
          records.Write(IWriter);
          return IWriter.ToString();

      }
      public int UpdateSRStatus(IList< Res.Model.ChildObj> clist,string userStr)
      {
          string sql = "PROC_SR_STATUS_ADD_UPDATE";
          SqlParameter[] param = new SqlParameter[] {
              new SqlParameter("@STS_ID",SqlDbType.Int,4),
              new SqlParameter("@SR_ID",SqlDbType.Int,4),
          new SqlParameter("@USER_ID",SqlDbType.VarChar,5)};
          using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
          {
              conn.Open();
              SqlTransaction trans = conn.BeginTransaction();
              try
              {
                  foreach (Res.Model.ChildObj ob in clist)
                  {
                      param[0].Value =ob.Level ;
                      param[1].Value = ob.ID;
                      param[2].Value = userStr;
                      int result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sql, param);
                  }
                  trans.Commit();
              }
              catch(System.Exception  ex)
              {
                  trans.Rollback();
              }
          }
          return clist.Count;
      }
      //添加关联
      public int AddSrrelation(Res.Model.ChildObj model)
      {
          string sql = "UP_SR_LSRRELATION_ADD";
          SqlParameter[] parameters = {
					new SqlParameter("@REN_SR1", SqlDbType.Int,4),
					new SqlParameter("@REN_SR2", SqlDbType.Int,4),
					new SqlParameter("@REN_CREATIONUID", SqlDbType.VarChar,5)};
          parameters[0].Value = model.ID;
          parameters[1].Value = model.Level;
          parameters[2].Value = model.NAME;

          int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, parameters);
          return result;
      }
      public int  GetNumOfSr_idGroup(int sr_id)
      {
          string sql = "SELECT COUNT(*) AS COUNTSR FROM dbo.SR_LSRRELATION where REN_SR1=@SR_ID ";
          SqlParameter parameters = 
					new SqlParameter("@SR_ID", SqlDbType.Int,4);
          parameters.Value = sr_id;


          Object result = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, parameters);
          return Convert.ToInt32(result);

      }
      /////
      public int UpdateSRList(Res.Model.Sr_bsrObj model)
		{
                string sql="PROC_SR_BSR_Update";

	
			SqlParameter[] parameters = {
					new SqlParameter("@SR_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_RAT_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_SYE_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_GRP_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_SOD_EXPECT", SqlDbType.DateTime),

					new SqlParameter("@SR_SOD_UPDATE", SqlDbType.DateTime),
					new SqlParameter("@SR_IT_OWNER", SqlDbType.VarChar,20),
					new SqlParameter("@SR_OVERDATE", SqlDbType.DateTime),
					new SqlParameter("@SR_SR_FLAG", SqlDbType.Bit,1),
					new SqlParameter("@SR_AR_FLAG", SqlDbType.Bit,1),

					new SqlParameter("@SR_PRO_FLAG", SqlDbType.Bit,1),
					new SqlParameter("@SR_DEMAND_DESC", SqlDbType.Text),
					new SqlParameter("@SR_UPDATEUID", SqlDbType.VarChar,5),
					new SqlParameter("@SR_TITLE", SqlDbType.VarChar,200),
					new SqlParameter("@SR_PROPOSER", SqlDbType.VarChar,20),

					new SqlParameter("@SR_CLIENT", SqlDbType.VarChar,20),
					new SqlParameter("@SR_IT_COST", SqlDbType.VarChar,20),
					new SqlParameter("@SR_USER_BENEFIT", SqlDbType.VarChar,200),
					new SqlParameter("@SR_DET_ID", SqlDbType.Int,4),
					new SqlParameter("@SR_LEL_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.SR_ID;
			parameters[1].Value = model.SR_RAT_ID;
			parameters[2].Value = model.SR_SYE_ID;
			parameters[3].Value = model.SR_GRP_ID;
			parameters[4].Value = model.SR_SOD_EXPECT;

			parameters[5].Value = model.SR_SOD_UPDATE;
			parameters[6].Value = model.SR_IT_OWNER;
			parameters[7].Value = model.SR_OVERDATE;
			parameters[8].Value = model.SR_SR_FLAG;
			parameters[9].Value = model.SR_AR_FLAG;

			parameters[10].Value = model.SR_PRO_FLAG;
			parameters[11].Value = model.SR_DEMAND_DESC;
			parameters[12].Value = model.SR_UPDATEUID;
			parameters[13].Value = model.SR_TITLE;
			parameters[14].Value = model.SR_PROPOSER;

			parameters[15].Value = model.SR_CLIENT;
			parameters[16].Value = model.SR_IT_COST;
			parameters[17].Value = model.SR_USER_BENEFIT;
			parameters[18].Value = model.SR_DET_ID;
			parameters[19].Value = model.SR_LEL_ID;

			int result=SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,CommandType.StoredProcedure,sql,parameters);
            return result;
		}


	}
}
    

