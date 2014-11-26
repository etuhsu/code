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

//该源码下载自www.51aspx.com(５１ａｓpｘ．ｃｏｍ)

namespace Res.DAL
{
   public  class ServerDAL:IServer
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
        public int Add_ServerList(IList<Hashtable> lst_hash, string filename,string userId)
        {
            int result = 0;
            int svs_id = 0;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    foreach (Hashtable hash in lst_hash)
                    {
                        int ret = AddServerList(trans, hash, filename, userId,out svs_id);
                        result +=ret;
                    }
                    result = AddExcelFile(trans, "服务器信息上传", filename, result, "已上传");
                    trans.Commit();
                }
                catch (SqlException ex)
                {
                    string sss = ex.Message;
                    result = 0;
                    trans.Rollback();
                }
            }
            return result;//表示成功 
        }

       /// <summary>
       /// 上传文件写入 数据库记录
       /// </summary>
       /// <param name="trans"></param>
       /// <param name="ftype"></param>
       /// <param name="path"></param>
       /// <param name="count"></param>
       /// <param name="status"></param>
       /// <returns></returns>
        public int AddExcelFile(SqlTransaction trans, string ftype, string path, int count, string status)
        {
            string sql = "insert into Web_ExcelImport(AddedTime,type,path,icount,status) values(getdate(),@type,@path,@icount,@status)";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@type",SqlDbType.VarChar,50),
                new SqlParameter("@path",SqlDbType.VarChar,1000),
                new SqlParameter("@icount",SqlDbType.Int),
                new SqlParameter("@status",SqlDbType.VarChar,50)};
            parameters[0].Value = ftype;
            parameters[1].Value = path;
            parameters[2].Value = count;
            parameters[3].Value = status;
            return SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql, parameters);


        }
       /// <summary>
       ///  插入 附表 信息
       /// </summary>
       /// <parameters name="trans"></parameters>
       /// <parameters name="valueStr"></parameters>
       /// <parameters name="userStr"></parameters>
       /// <returns></returns>

        public int InsertEntryItems(SqlTransaction trans, string colName,string valueStr,string userStr,out int e_id)
        {
            string tableName = "";
            SqlParameter[] parameters = null;
            switch (colName.Trim().ToUpper())
            {
                case "CPU":
                parameters =new  SqlParameter[]{
                new SqlParameter("@CPU_ID", SqlDbType.Int),
			    new SqlParameter("@CPU_NAME", SqlDbType.VarChar,100),
			    new SqlParameter("@CPU_CREATIONUID", SqlDbType.VarChar,5)}; tableName = "RCPUTYPE"; break;
            case "型號":
                parameters = new SqlParameter[]{
                new SqlParameter("@SMO_ID", SqlDbType.Int),
			    new SqlParameter("@SMO_NAME", SqlDbType.VarChar,50),
			    new SqlParameter("@SMO_CREATIONUID", SqlDbType.VarChar,20)}; tableName = "RSMOTYPE"; break;
            case "ARRAY TYPE":
                parameters = new SqlParameter[]{
                new SqlParameter("@ATY_ID", SqlDbType.Int),
			    new SqlParameter("@ATY_NAME", SqlDbType.VarChar,20),
			    new SqlParameter("@ATY_CREATIONUID", SqlDbType.VarChar,5)}; tableName = "RATYTYPE"; break;
            case "OS":
                parameters = new SqlParameter[]{
                new SqlParameter("@OS_ID", SqlDbType.Int),
			    new SqlParameter("@OS_NAME", SqlDbType.VarChar,50),
			    new SqlParameter("@OS_CREATIONUID", SqlDbType.VarChar,5)}; tableName = "ROSTYPE"; break;
            case "MEMORY":
                parameters = new SqlParameter[]{
                new SqlParameter("@MEY_ID", SqlDbType.Int),
			    new SqlParameter("@MEY_NAME", SqlDbType.VarChar,30),
			    new SqlParameter("@MEY_CREATIONUID", SqlDbType.VarChar,5)}; tableName = "RMEYTYPE"; break;
            case "HARD DISK":
                parameters = new SqlParameter[]{
                new SqlParameter("@HAD_ID", SqlDbType.Int),
			    new SqlParameter("@HAD_NAME", SqlDbType.VarChar,30),
			    new SqlParameter("@HAD_CREATIONUID", SqlDbType.VarChar,5)}; tableName = "RHADTYPE"; break;
            case "STORAGE": 
                parameters = new SqlParameter[]{
                new SqlParameter("@STR_ID", SqlDbType.Int),
			    new SqlParameter("@STR_NAME", SqlDbType.VarChar,30),
			    new SqlParameter("@STR_CREATIONUID", SqlDbType.VarChar,5)}; tableName = "RSTRTYPE"; break;
            case "IT TEAM":
                parameters = new SqlParameter[]{
                new SqlParameter("@TEP_ID", SqlDbType.Int),
			    new SqlParameter("@TEP_NAME", SqlDbType.VarChar,30),
			    new SqlParameter("@TEP_CREATIONUID", SqlDbType.VarChar,5)}; tableName = "RTEAMTYPE"; break;
            default: parameters=null; break;   
            }
            string sqltrans = "PROC_" + tableName + "_ADD";
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = valueStr;
            parameters[2].Value = userStr;
            int result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sqltrans.ToString(), parameters);
            e_id = Convert.ToInt32(parameters[0].Value);
            return e_id;
        }
       /// <summary>
       /// 根据条件查询服务器列表的所有数据 不分页显示
       /// </summary>
       /// <param name="strWhere"></param>
       /// <returns></returns>
       public string GetServerList(string strWhere)
       {
           StringBuilder SQL = new StringBuilder();
           SQL.Append("SELECT SVS_ID,SVS_NAME,SVS_IPADDRESS,SVS_SHORTDESC,SVS_SN,SMO_NAME,CPU_NAME,MEY_NAME,HAD_NAME,ATY_NAME,OS_NAME, CONVERT(varchar(10), SER_COME_DT, 120 ) as SER_COME_DT, SER_OWNER ,SER_PO_NO ,TEP_NAME, STR_NAME, SER_AP_LIST ");
           SQL.Append(" FROM VM_SERVER_MODEL ");
           if (string.IsNullOrEmpty(strWhere) == false)
           {
               SQL.Append(" WHERE ");
               SQL.Append(strWhere);
           }
           JsonObject jsonobj=new JsonObject();
           JsonArray records=new JsonArray();

            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, SQL.ToString(), null);
               int count = 0;
               while (reader.Read())
               {
                   JsonObject record = new JsonObject();
                   record.Add("SVS_ID", IsInt(reader, 0));
                   record.Add("SVS_NAME", IsString(reader, 1));
                   record.Add("SVS_IPADDRESS", IsString(reader, 2));
                   record.Add("SVS_SHORTDESC", IsString(reader, 3));
                   record.Add("SVS_SN", IsString(reader, 4));
                   record.Add("SMO_NAME", IsString(reader, 5));
                   record.Add("CPU_NAME", IsString(reader, 6));
                   record.Add("HAD_NAME", IsString(reader, 8));
                   record.Add("MEY_NAME", IsString(reader, 7));
                   record.Add("ATY_NAME", IsString(reader, 9));
                   record.Add("OS_NAME", IsString(reader, 10));

                   record.Add("SER_COME_DT", IsString(reader, 11));
                   record.Add("SER_OWNER", IsString(reader, 12));
                   record.Add("SER_PO_NO", IsString(reader, 13));
                   record.Add("TEP_NAME", IsString(reader, 14));

                   record.Add("STR_NAME", IsString(reader, 15));
                   record.Add("SER_AP_LIST", IsString(reader, 16));
                   records.Add(record);
                   count++;
               }
               reader.Close();
               jsonobj.Add("LIST", records);
               jsonobj.Add("TOTALCOUNT", count);
           IJsonWriter writer = new JsonWriter();
           jsonobj.Write(writer);
           return writer.ToString();

       }
        public int AddServerList(SqlTransaction trans, Hashtable hash, string filename,string userStr,out int svs_id)
        {
            string sqlTrans = "PROC_BSERVER_ADD";
         SqlParameter[] parameters = {
                    new SqlParameter("@SVS_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@SVS_SHORTDESC", SqlDbType.VarChar,100),
					new SqlParameter("@SVS_IPADDRESS", SqlDbType.VarChar,15),
					new SqlParameter("@SVS_SMO_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_CPU_ID", SqlDbType.Int,4),

					new SqlParameter("@SVS_MEY_ID", SqlDbType.Int,4),
                    new SqlParameter("@SVS_ATY_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_HAD_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_OS_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_SN", SqlDbType.VarChar,50),

            		new SqlParameter("@SVS_CREATIONUID", SqlDbType.VarChar,5),
                    new SqlParameter("@SVS_ID", SqlDbType.Int)};
            int isNllRow = 0;
            if (hash["Server Name"] != null && string.IsNullOrEmpty(hash["Server Name"].ToString()) == false)
            {
                parameters[0].Value = hash["Server Name"].ToString();
            }
            else
            {
                parameters[0].Value = DBNull.Value;
                isNllRow++;
            }
            if (hash["Function Description"] != null && string.IsNullOrEmpty(hash["Function Description"].ToString()) == false)
            {
                parameters[1].Value = hash["Function Description"];
            }
            else
            {
                parameters[1].Value = DBNull.Value;
                isNllRow++;
            }
            if (hash["IP Address"] != null && string.IsNullOrEmpty(hash["IP Address"].ToString()) == false)
            {
                parameters[2].Value = hash["IP Address"];
            }
            else
            {
                parameters[2].Value = DBNull.Value;
                isNllRow++;
            }
            if (hash["型號"] != null && string.IsNullOrEmpty(hash["型號"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "型號",hash["型號"].ToString(), userStr, out EntryID) > 0)
                {
                    parameters[3].Value = EntryID;
                }
            }
            else
            {
                parameters[3].Value = DBNull.Value;
                isNllRow++;
            }
            //CPU
            if (hash["CPU"] != null && string.IsNullOrEmpty(hash["CPU"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "CPU", hash["CPU"].ToString(), userStr, out EntryID) > 0)
                {
                    parameters[4].Value = EntryID;
                   
                }
            }
            else
            {
                parameters[4].Value = DBNull.Value;
                isNllRow++;
            }
            //内存
            if (hash["Memory"] != null && string.IsNullOrEmpty(hash["Memory"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "Memory", hash["Memory"].ToString(), userStr, out EntryID) > 0)
                {
                    parameters[5].Value = EntryID;
                }
            }
            else
            {
                parameters[5].Value = DBNull.Value;
                isNllRow++;
            }
            //磁盘阵列

            if (hash["Array Type"] != null && string.IsNullOrEmpty(hash["Array Type"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "Array Type", hash["Array Type"].ToString(), userStr, out EntryID) > 0)
                {
                    parameters[6].Value = EntryID;
                }
            }
            else
            {
                parameters[6].Value = DBNull.Value;
                isNllRow++;
            }
            //磁盘阵列

            if (hash["Hard Disk"] != null && string.IsNullOrEmpty(hash["Hard Disk"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "Hard Disk", hash["Hard Disk"].ToString(), userStr, out EntryID) > 0)
                {
                    parameters[7].Value = EntryID;
                }
            }
            else
            {
                parameters[7].Value = DBNull.Value;
                isNllRow++;
            }
            //操作系统

            if (hash["OS"] != null && string.IsNullOrEmpty(hash["OS"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "OS", hash["OS"].ToString(), userStr, out EntryID) > 0)
                {
                    parameters[8].Value = EntryID;
                }
            }
            else
            {
                parameters[8].Value = DBNull.Value;
                isNllRow++;
            }
            // SN
            if (hash["SN"] != null && string.IsNullOrEmpty(hash["SN"].ToString()) == false)
            {
                parameters[9].Value = hash["SN"];
            }
            else
            {
                parameters[9].Value = DBNull.Value;
                isNllRow++;
            }
            if (isNllRow >= 10)
            {
                svs_id = 0;
                return 0;
            }
            parameters[10].Value = userStr;
            parameters[11].Direction = ParameterDirection.Output;
            int result=0;
            result=SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sqlTrans, parameters);
            svs_id = Convert.ToInt32(parameters[11].Value);
            string sqlTrans2 = "PROC_RSERVER_UPDATE";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@SER_SVS_ID", SqlDbType.Int,4),
                    new SqlParameter("@SER_COME_DT", SqlDbType.DateTime),
					new SqlParameter("@SER_OWNER", SqlDbType.VarChar,50),
					new SqlParameter("@SER_PO_NO", SqlDbType.VarChar,50),
					new SqlParameter("@SER_TEP_ID", SqlDbType.Int,4),

					new SqlParameter("@SER_STR_ID", SqlDbType.Int,4),
					new SqlParameter("@SER_AP_LIST", SqlDbType.Text),
                    new SqlParameter("@SER_OPERATEUID", SqlDbType.VarChar,5),
					new SqlParameter("@SER_OPERATE_DT", SqlDbType.DateTime)};

            param[0].Value = svs_id;
            if (hash["Arrive Date"] != null && string.IsNullOrEmpty(hash["Arrive Date"].ToString()) == false)
            {
                param[1].Value = hash["Arrive Date"];
            }
            else
            {
                param[1].Value = DBNull.Value;
            }
            if (hash["Owner"] != null && string.IsNullOrEmpty(hash["Owner"].ToString()) == false)
            {
                param[2].Value = hash["Owner"];
            }
            else
            {
                param[2].Value = DBNull.Value;
            }
            if (hash["PO NO"] != null && string.IsNullOrEmpty(hash["PO NO"].ToString()) == false)
            {
                param[3].Value = hash["PO NO"];
            }
            else
            {
                param[3].Value = DBNull.Value;
            }
            if (hash["IT Team"] != null && string.IsNullOrEmpty(hash["IT Team"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "IT Team", hash["IT Team"].ToString(), userStr, out EntryID) > 0)
                {
                    param[4].Value = EntryID;
                }
            }
            else
            {
                param[4].Value = DBNull.Value;
            }
            if (hash["Storage"] != null && string.IsNullOrEmpty(hash["Storage"].ToString()) == false)
            {
                int EntryID = 0;
                if (InsertEntryItems(trans, "Storage", hash["Storage"].ToString(), userStr, out EntryID) > 0)
                {
                    param[5].Value = EntryID;
                }
            }
            else
            {
                param[5].Value = DBNull.Value;
            }
            if (hash["AP List"] != null && string.IsNullOrEmpty(hash["AP List"].ToString()) == false)
            {

                param[6].Value = hash["AP List"];

            }
            else
            {
                param[6].Value = DBNull.Value;
            }
            param[7].Value = userStr;
            param[8].Value = DateTime.Now;
            int result2 = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sqlTrans2, param);
            return result2;
        }
        /// <summary>
        /// 单项新增
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="model"></param>
        /// <param name="userStr"></param>
        /// <param name="svs_id"></param>
        /// <returns></returns>
        public int AddServerMasterByAddServerList(SqlTransaction trans, Res.Model.BServerObj model, out int svs_id)
        {
            string sqlTrans = "PROC_BSERVER_ADD";
            SqlParameter[] parameters = {
                    new SqlParameter("@SVS_ID", SqlDbType.Int,4),
                    new SqlParameter("@SVS_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@SVS_SHORTDESC", SqlDbType.VarChar,100),
					new SqlParameter("@SVS_IPADDRESS", SqlDbType.VarChar,15),
					new SqlParameter("@SVS_SMO_ID", SqlDbType.Int,4),

					new SqlParameter("@SVS_CPU_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_MEY_ID", SqlDbType.Int,4),
                    new SqlParameter("@SVS_ATY_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_HAD_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_OS_ID", SqlDbType.Int,4),

					new SqlParameter("@SVS_SN", SqlDbType.VarChar,50),
            		new SqlParameter("@SVS_CREATIONUID", SqlDbType.VarChar,5)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.SVS_NAME;
            parameters[2].Value = model.SVS_SHORTDESC;
            parameters[3].Value = model.SVS_IPADDRESS;
            parameters[4].Value = model.SVS_SMO_ID;
            parameters[5].Value = model.SVS_CPU_ID;
            parameters[6].Value = model.SVS_MEY_ID;
            parameters[7].Value = model.SVS_ATY_ID;

            parameters[8].Value = model.SVS_HAD_ID;
            parameters[9].Value = model.SVS_OS_ID;
            parameters[10].Value = model.SVS_SN;
            parameters[11].Value = model.SVS_CREATIONUID;
            int result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sqlTrans, parameters);
            svs_id = Convert.ToInt32(parameters[0].Value);
            return result;



        }

        /// <summary>
        /// 单项新增
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="model"></param>
        /// <param name="userStr"></param>
        /// <param name="svs_id"></param>
        /// <returns></returns>
        public int AddRServerByAddServerList(SqlTransaction trans, Res.Model.RServerObj model)
        {
            string sqlTrans = "PROC_RSERVER_UPDATE";
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@SER_SVS_ID", SqlDbType.Int,4),
                    new SqlParameter("@SER_COME_DT", SqlDbType.DateTime),
					new SqlParameter("@SER_OWNER", SqlDbType.VarChar,50),
					new SqlParameter("@SER_PO_NO", SqlDbType.VarChar,50),
					new SqlParameter("@SER_TEP_ID", SqlDbType.Int,4),

					new SqlParameter("@SER_STR_ID", SqlDbType.Int,4),
					new SqlParameter("@SER_AP_LIST", SqlDbType.Text),
                    new SqlParameter("@SER_OPERATEUID", SqlDbType.VarChar,5),
					new SqlParameter("@SER_OPERATE_DT", SqlDbType.DateTime)};
            try
            {
                param[0].Value = model.SER_SVS_ID;
                param[1].Value = model.SER_COME_DT;
                param[2].Value = model.SER_OWNER;
                param[3].Value = model.SER_PO_NO;
                param[4].Value = model.SER_TEP_ID;
                param[5].Value = model.SER_STR_ID;
                param[6].Value = model.SER_AP_LIST;
                param[7].Value = model.SER_OPERATEUID;
                param[8].Value = DateTime.Now;
                int result = 0;
                 result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sqlTrans, param);
                return result;
            }
            catch 
            {
                return 0;
            }
                   
            



        }
       /// <summary>
       /// 分页查询服务器列表
       /// </summary>
       /// <param name="pageSize"></param>
       /// <param name="pageNO"></param>
       /// <param name="strWhere"></param>
       /// <returns></returns>
       public string GetServerList(int pageSize, int pageNO, string strWhere)
       {
           StringBuilder jsonStr = new StringBuilder();
           string fields = " SVS_ID,SVS_NAME,SVS_IPADDRESS,SVS_SHORTDESC,SVS_SN,SMO_NAME,CPU_NAME,MEY_NAME,HAD_NAME,ATY_NAME,OS_NAME  ,SER_COME_DT ,SER_OWNER ,SER_PO_NO ,TEP_NAME ,STR_NAME ,SER_AP_LIST ";
           string orderFields = "SVS_ID";
           string sql = "PROC_GET_SPLITTEXT";
           SqlParameter[] param = new SqlParameter[] { 
                new SqlParameter("@TABLENAME",SqlDbType.VarChar,255),
                new SqlParameter("@FIELDSCOLUMN",SqlDbType.VarChar,1000),
                new SqlParameter("@SORTFIELDS",SqlDbType.VarChar,255),
                new SqlParameter("@PAGESIZE",SqlDbType.Int),
                new SqlParameter("@PAGEINDEX",SqlDbType.Int),
                new SqlParameter("@TOTALCOUNT",SqlDbType.Bit),
                new SqlParameter("@ORDERTYPE",SqlDbType.Bit),
                new SqlParameter("@WHERE",SqlDbType.VarChar,255)};
           param[0].Value = "VM_SERVER_MODEL";
           param[1].Value = "SVS_ID";
           param[2].Value = orderFields;
           param[3].Value = pageSize;
           param[4].Value = pageNO;
           param[5].Value = 1;
           param[6].Value = 1;
           param[7].Value = strWhere;

           JsonObject jsonobj = new JsonObject();
           JsonArray datas = new JsonArray();
           JsonArray records = new JsonArray();
           jsonobj.Add("LIST", records);
           using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
           {
               conn.Open();
               object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.StoredProcedure, sql, param);
               param[0].Value = "VM_SERVER_MODEL";
               param[1].Value = fields;
               param[2].Value = orderFields;
               param[3].Value = pageSize;
               param[4].Value = pageNO;
               param[5].Value = 0;
               param[6].Value = 1;
               param[7].Value = strWhere;
               SqlDataReader reader = SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, sql, param);
               //int count = 1;
               while (reader.Read())
               {
                   JsonObject record = new JsonObject();
                   record.Add("SVS_ID", IsInt(reader, 0));
                   record.Add("SVS_NAME", IsString(reader, 1));
                   record.Add("SVS_IPADDRESS", IsString(reader, 2));
                   record.Add("SVS_SHORTDESC", IsString(reader, 3));
                   record.Add("SVS_SN", IsString(reader, 4));
                   record.Add("SMO_NAME", IsString(reader, 5));
                   record.Add("CPU_NAME", IsString(reader, 6));
                   record.Add("HAD_NAME", IsString(reader, 8));
                   record.Add("MEY_NAME", IsString(reader, 7));
                   record.Add("ATY_NAME", IsString(reader, 9));
                   record.Add("OS_NAME", IsString(reader, 10));

                   record.Add("SER_COME_DT", IsDateTime(reader, 11).ToString("yyyy-MM-dd"));
                   record.Add("SER_OWNER", IsString(reader, 12));
                   record.Add("SER_PO_NO", IsString(reader, 13));
                   record.Add("TEP_NAME", IsString(reader, 14));

                   record.Add("STR_NAME", IsString(reader, 15));
                   record.Add("SER_AP_LIST", IsString(reader, 16));
                   records.Add(record);
               }
               reader.Close();
               jsonobj.Add("TOTALCOUNT", Convert.ToInt32(obj));
           }
           IJsonWriter writer = new JsonWriter();
           jsonobj.Write(writer);
           jsonStr.Append(writer.ToString());
           return jsonStr.ToString();
       }
       /// <summary>
       /// 删除服务器 一条记录根据ID 
       /// </summary>
       /// <param name="IDList"></param>
       /// <param name="userid"></param>
       /// <returns></returns>
       public int DelServerListBySVS_ID(string[] IDList,String  userid)
       {
           string sql = "DELETE FROM BSERVER WHERE SVS_ID=@SVS_ID";
           string sql2 = "INSERT INTO BSVSBACKUP (SVS_ID,SVS_OPERATEUID,SVS_OPERATE_DT) VALUES(@SVS_ID,@OPID,GETDATE())";
           SqlParameter param = new SqlParameter("@SVS_ID", SqlDbType.Int);
            SqlParameter[] paramers = new SqlParameter[]
                            {new SqlParameter("@SVS_ID", SqlDbType.Int),
                            new SqlParameter("@OPID",SqlDbType.VarChar,5)};
           using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
           {
               conn.Open();
               SqlTransaction trans = conn.BeginTransaction();
               try
               {
                   foreach (string ID in IDList)
                   {
                       param.Value = Convert.ToInt32(ID);
                       paramers[0].Value = Convert.ToInt32(ID);
                       paramers[1].Value = userid;
                       if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, param) > 0)
                       {
                           if (SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql2, paramers) > 0)
                           {
                               continue;
                           }
                           else
                           {
                               trans.Rollback();
                           }

                       }
                       else
                       {
                           trans.Rollback();
                       }
                   }

                   trans.Commit();
                   return IDList.Length;
               }
               catch (SqlException)
               {
                   trans.Rollback();
               }
               finally
               {
                   conn.Close();
               }
           }

           
           int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, CommandType.Text, sql, param);
           return result;
       }
       /// <summary>
       /// 装载修改页面 信息
       /// </summary>
       /// <param name="SVS_ID"></param>
       /// <returns></returns>
       public string GetServerListForModify(int SVS_ID)
       {
           string sql = "SELECT SVS_ID,SVS_NAME,SVS_IPADDRESS,SVS_SHORTDESC,SVS_SN,SMO_ID,CPU_ID, MEY_ID ,HAD_ID, ATY_ID, ";
           sql+=" OS_ID ,SER_COME_DT ,SER_OWNER ,SER_PO_NO ,TEP_ID ,STR_ID ,SER_AP_LIST FROM VM_SERVER_MODEL WHERE SVS_ID=@SVS_ID ";
           SqlParameter param = new SqlParameter("@SVS_ID", SqlDbType.Int);
           param.Value = SVS_ID;
           JsonObject record = new JsonObject();
           using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, param))
           {
               while (reader.Read())
               {
                    record.Add("SVS_ID", IsInt(reader, 0));
                    record.Add("SVS_NAME", IsString(reader, 1));
                    record.Add("SVS_IPADDRESS", IsString(reader, 2));
                    record.Add("SVS_SHORTDESC", IsString(reader, 3));
                    record.Add("SVS_SN", IsString(reader, 4));

                    record.Add("SMO_ID", IsInt(reader, 5));
                    record.Add("CPU_ID", IsInt(reader, 6));
                    record.Add("MEY_ID", IsInt(reader, 7));
                    record.Add("HAD_ID", IsInt(reader, 8));
                    record.Add("ATY_ID", IsInt(reader, 9));

                    record.Add("OS_ID", IsInt(reader, 10));
                    record.Add("SER_COME_DT", IsDateTime(reader, 11).ToString("yyyy-MM-dd"));
                    record.Add("SER_OWNER", IsString(reader, 12));
                    record.Add("SER_PO_NO", IsString(reader, 13));
                    record.Add("SER_TEP_ID", IsInt(reader, 14));

                    record.Add("SER_STR_ID", IsInt(reader, 15));
                    record.Add("SER_AP_LIST", IsString(reader, 16));
               }
           }
           IJsonWriter writer = new JsonWriter();
           record.Write(writer);
           return writer.ToString();
       }
       /// <summary>
       /// 修改 服务器信息
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int  ModifyServerListBySVS_ID(SqlTransaction trans, Res.Model.BServerObj model)
       {
           string sql = "PROC_BSERVER_UPDATE";
           SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@SVS_ID", SqlDbType.Int,4),
                    new SqlParameter("@SVS_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@SVS_SHORTDESC", SqlDbType.VarChar,100),
					new SqlParameter("@SVS_IPADDRESS", SqlDbType.VarChar,15),
					new SqlParameter("@SVS_SMO_ID", SqlDbType.Int,4),

					new SqlParameter("@SVS_CPU_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_MEY_ID", SqlDbType.Int,4),
                    new SqlParameter("@SVS_ATY_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_HAD_ID", SqlDbType.Int,4),
					new SqlParameter("@SVS_OS_ID", SqlDbType.Int,4),

					new SqlParameter("@SVS_SN", SqlDbType.VarChar,50),
            		new SqlParameter("@SVS_UPDATEUID", SqlDbType.VarChar,5)};
                   parameters[0].Value = model.SVS_ID;
                   parameters[1].Value = model.SVS_NAME;
                   parameters[2].Value = model.SVS_SHORTDESC;
                   parameters[3].Value = model.SVS_IPADDRESS;
                   parameters[4].Value = model.SVS_SMO_ID;
                   parameters[5].Value = model.SVS_CPU_ID;
                   parameters[6].Value = model.SVS_MEY_ID;
                   parameters[7].Value = model.SVS_ATY_ID;

                   parameters[8].Value = model.SVS_HAD_ID;
                   parameters[9].Value = model.SVS_OS_ID;
                   parameters[10].Value = model.SVS_SN;
                   parameters[11].Value = model.SVS_UPDATEUID;

                   int result=SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sql, parameters);
                   return result;

       }
      /// <summary>
      /// 修改RSERVER
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>
       public int ModifyRServerListBySVS_ID(SqlTransaction trans,Res.Model.RServerObj model)
       {
           string sql = "PROC_RSERVER_UPDATE";
           SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@SER_SVS_ID", SqlDbType.Int,4),
                    new SqlParameter("@SER_COME_DT", SqlDbType.DateTime),
					new SqlParameter("@SER_OWNER", SqlDbType.VarChar,50),
					new SqlParameter("@SER_PO_NO", SqlDbType.VarChar,50),
					new SqlParameter("@SER_TEP_ID", SqlDbType.Int,4),

					new SqlParameter("@SER_STR_ID", SqlDbType.Int,4),
					new SqlParameter("@SER_AP_LIST", SqlDbType.Text),
                    new SqlParameter("@SER_OPERATEUID", SqlDbType.VarChar,5),
					new SqlParameter("@SER_OPERATE_DT", SqlDbType.DateTime)};
                   parameters[0].Value = model.SER_SVS_ID;
                   parameters[1].Value = model.SER_COME_DT;
                   parameters[2].Value = model.SER_OWNER;
                   parameters[3].Value = model.SER_PO_NO;
                   parameters[4].Value = model.SER_TEP_ID;
                   parameters[5].Value = model.SER_STR_ID;
                   parameters[6].Value = model.SER_AP_LIST;
                   parameters[7].Value = model.SER_OPERATEUID;

                   parameters[8].Value = model.SER_OPERATE_DT;

                   int result = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, sql, parameters);
                   return result;

       }
       /// <summary>
       /// 根据条件 查询 下载
       /// </summary>
       /// <param name="whereStr"></param>
       /// <returns></returns>
       public DataSet DownServerListALL(string whereStr)
       {
           string[] header = new string[] { "Server Name", "Function Description", "IP Address", " 型號", " CPU", " Memory", " Hard Disk", " Array Type", " OS", " SN", "PO NO.", "Owner", "IT Team", "Storage", " Arrive Date", "AP List" };
           string sql = " SELECT SVS_NAME,SVS_SHORTDESC,SVS_IPADDRESS,SMO_NAME,CPU_NAME,MEY_NAME,HAD_NAME,ATY_NAME,OS_NAME,SVS_SN,SER_PO_NO,SER_OWNER,TEP_NAME,STR_NAME, CONVERT(varchar(10), SER_COME_DT, 120 ),SER_AP_LIST FROM VM_SERVER_MODEL ";
           if (string.IsNullOrEmpty(whereStr.Trim())==false)
           {
               sql += " WHERE  " + whereStr;
           }
            SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString);
            conn.Open();
            SqlCommand com = new SqlCommand(sql);
            com.Connection = conn;
            SqlDataAdapter adr = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adr.Fill(ds);
            return ds;
         //  return SqlHelper.(SqlHelper.ConnectionString, CommandType.Text, sql, null);
           
       }
      /// <summary>
      /// 得到菜单权限
      /// </summary>
      /// <param name="userStr"></param>
      /// <returns></returns>
       public string GetMainMenu(string userStr)
       {
           string sql = " SELECT POP_LIST_ADD,POP_LIST_MODIFY,POP_LIST_QUERY,POP_LIST_DEL,POP_LIST_DOWNLOAD,POP_UPLOAD_ADD FROM LSVSPOPEDOM WHERE POP_USR_ID=@POP_USR_ID ";
           SqlParameter param = new SqlParameter("@POP_USR_ID", SqlDbType.VarChar,5);
           param.Value = userStr;
           JsonObject record = new JsonObject();
           using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, param))
           {
               while (reader.Read())
               {
                   record.Add("POP_LIST_ADD", IsBit(reader, 0));
                   record.Add("POP_LIST_MODIFY", IsBit(reader, 1));
                   record.Add("POP_LIST_QUERY", IsBit(reader, 2));
                   record.Add("POP_LIST_DEL", IsBit(reader, 3));
                   record.Add("POP_LIST_DOWNLOAD", IsBit(reader, 4));
                   record.Add("POP_UPLOAD_ADD", IsBit(reader, 5));
         
               }
           }
           IJsonWriter writer = new JsonWriter();
           record.Write(writer);
           return writer.ToString();
       }
    }
}
