using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Sms
    /// </summary>
    public partial class Sys_Sms
    {
        public Sys_Sms()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            int result = DBHelper.RunProcedure("Sys_Sms_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public funRtn Add(XxWapSystem.Model.Sys_Sms model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@cPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@cUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@bIsOpen", SqlDbType.Bit,1),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cName;
            parameters[2].Value = model.cPassWord;
            parameters[3].Value = model.cUrl;
            parameters[4].Value = model.bIsOpen;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_Sms_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[5].Value.ToString());
            rtn.rtnMsg.Append(parameters[6].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Sys_Sms model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@cPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@cUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@bIsOpen", SqlDbType.Bit,1),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cName;
            parameters[2].Value = model.cPassWord;
            parameters[3].Value = model.cUrl;
            parameters[4].Value = model.bIsOpen;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_Sms_Update", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[5].Value.ToString());
            rtn.rtnMsg.Append(parameters[6].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据--不包含密码
        /// </summary>
        public funRtn Update_NoPass(XxWapSystem.Model.Sys_Sms model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@cUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@bIsOpen", SqlDbType.Bit,1),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cName;
            parameters[2].Value = model.cUrl;
            parameters[3].Value = model.bIsOpen;
            parameters[4].Direction = ParameterDirection.Output;
            parameters[5].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_Sms_UpdateNoPass", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[4].Value.ToString());
            rtn.rtnMsg.Append(parameters[5].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  只更新密码
        /// </summary>
        public funRtn Update_Pass(XxWapSystem.Model.Sys_Sms model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
                    new SqlParameter("@cPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cPassWord;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_Sms_UpdatePass", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[2].Value.ToString());
            rtn.rtnMsg.Append(parameters[3].Value.ToString());
            return rtn;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Sys_Sms GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            XxWapSystem.Model.Sys_Sms model = new XxWapSystem.Model.Sys_Sms();
            DataSet ds = DBHelper.RunProcedure("Sys_Sms_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                model.cName = ds.Tables[0].Rows[0]["cName"].ToString();
                model.cPassWord = ds.Tables[0].Rows[0]["cPassWord"].ToString();
                model.cUrl = ds.Tables[0].Rows[0]["cUrl"].ToString();
                if (ds.Tables[0].Rows[0]["bIsOpen"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bIsOpen"].ToString() == "1") || (ds.Tables[0].Rows[0]["bIsOpen"].ToString().ToLower() == "true"))
                    {
                        model.bIsOpen = true;
                    }
                    else
                    {
                        model.bIsOpen = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  Method
    }
}
