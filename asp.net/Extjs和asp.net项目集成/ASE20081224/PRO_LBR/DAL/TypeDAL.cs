using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Res.IDAL;
using Res.Model;
using Res.DBUtility;
using NetServ.Net.Json;
namespace Res.DAL
{
    public class TypeDAL : IType
    {
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
                return (System.Convert.ToInt32(reader.GetValue(0)) == 1);
            }
        }
        //得到服务器CPU 类型
        public IList<NodeObj> GetStrType()
        {
            string sql = "SELECT   MIN(STR_ID) AS STR_ID,STR_NAME FROM RSTRTYPE GROUP BY STR_NAME ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
     
        //请假类型
        public IList<NodeObj> GetLeeType()
        {
            string sql = "SELECT LEE_ID,LEE_NAME  FROM APP_RLEETYPE  ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        //加班类型
        public IList<NodeObj> GetOteType()
        {
            string sql = "SELECT Ote_ID,Ote_NAME  FROM APP_ROTETYPE  ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;
        }
        // 服务器部门
        public IList<NodeObj> GetTepType()
        {
            string sql = "SELECT   MIN(TEP_ID) AS TEP_ID,TEP_NAME FROM RTEAMTYPE GROUP BY TEP_NAME ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;
        }
        //得到服务器CPU 类型
        public IList<NodeObj> GetCpuType()
        {
            string sql = "SELECT   MIN(CPU_ID) AS CPU_ID,CPU_NAME FROM RCPUTYPE GROUP BY CPU_NAME ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID =IsInt(reader, 0);
                    node.NAME=IsString(reader,1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        //得到服务器内存信息 
        public IList<NodeObj> GetMeyType()
        {
            string sql = "SELECT   MIN(MEY_ID) AS MEY_ID, MEY_NAME from RMEYTYPE GROUP BY MEY_NAME  ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        //得到服务器类型
        public IList<NodeObj> GetSmoType()
        {
            string sql = "SELECT MIN(SMO_ID) AS SMO_ID,SMO_NAME FROM RSMOTYPE GROUP BY SMO_NAME ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        //得到服务器磁盘类型
        public IList<NodeObj> GetHadType()
        {
            string sql = "SELECT MIN(HAD_ID) AS HAD_ID,HAD_NAME FROM RHADTYPE GROUP BY HAD_NAME ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
       //得到服务器磁盘阵列类型
        public IList<NodeObj> GetAtyType()
        {
            string sql = "SELECT MIN(ATY_ID) AS ATY_ID,ATY_NAME FROM RATYTYPE GROUP BY ATY_NAME ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        //得到操作系统类型
        public IList<NodeObj> GetOsType()
        {
            string sql = "SELECT OS_ID,OS_NAME FROM ROSTYPE";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        //填单类型 
        public IList<AppObj> GetAteType()
        {
            string sql = "SELECT  ATE_ID,ATE_NAME,ATE_CODE  FROM APP_APPTYPE ";
            IList<AppObj> lst_node = new List<AppObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    AppObj node = new AppObj();
                    node.APP_ID = IsInt(reader, 0);
                    node.APP_NAME = IsString(reader, 1);
                    node.APP_CODE1 = IsString(reader, 2);
                    lst_node.Add(node);
                }
            }
            return lst_node;
        }
        // 填单 类型 小类型
        public IList<AppObj> GetAdsType()
        {
            string sql = "SELECT ADS_CODE,ADS_NAME,ADS_ATE_CODE  FROM APP_APPDETAILS ";
            IList<AppObj> lst_node = new List<AppObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    AppObj node = new AppObj();
                    node.APP_CODE1 = IsString(reader, 0);
                    node.APP_NAME = IsString(reader, 1);
                    node.APP_CODE2 = IsString(reader, 2);
                    lst_node.Add(node);
                }
            }
            return lst_node;
        }
        //得到IT部门类型
        public IList<NodeObj> GetGroupType()
        {
            string sql = "SELECT  GRP_ID,GRP_NAME FROM SR_RGROUP ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        

            //得到申请部门类型
        public IList<NodeObj> GetDepartmentType()
        {
            string sql = "SELECT  DET_ID,DET_NAME FROM SR_RDEPARTMENT ";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
                //得到类型
        public IList<NodeObj> GetLevelType()
        {
            string sql = "SELECT LEL_ID,LEL_NAME FROM SR_RLEVEL";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
                //得到操作系统类型
        public IList<NodeObj> GetRassortType()
        {
            string sql = "SELECT RAT_ID,RAT_NAME FROM SR_RRASSORT";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
                //得到系统类型
        public IList<NodeObj> GetSysType()
        {
            string sql = "SELECT  SYE_ID,SYE_NAME FROM SR_RSYSTYPE";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
        //SR 状态
        public IList<NodeObj> GetStatusType()
        {
            string sql = "SELECT  STS_ID,STS_NAME FROM SR_RSTATUS";
            IList<NodeObj> lst_node = new List<NodeObj>();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, sql, null))
            {
                while (reader.Read())
                {
                    NodeObj node = new NodeObj();
                    node.ID = IsInt(reader, 0);
                    node.NAME = IsString(reader, 1);
                    lst_node.Add(node);
                }
            }
            return lst_node;

        }
    

       
    }
}
