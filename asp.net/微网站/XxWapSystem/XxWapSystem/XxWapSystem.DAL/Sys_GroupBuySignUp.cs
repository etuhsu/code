using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Sys_GroupBuySignUp
    /// </summary>
    public partial class Sys_GroupBuySignUp
    {
        public Sys_GroupBuySignUp()
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

            int result = DBHelper.RunProcedure("Sys_GroupBuySignUp_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@iUserID", SqlDbType.Int,4),
					new SqlParameter("@cMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@cCredentials", SqlDbType.NVarChar,50),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@iGroupBuyID", SqlDbType.Int,4),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
                    new SqlParameter("@cName", SqlDbType.NVarChar,50),
                    new SqlParameter("@cHouseArea", SqlDbType.NVarChar,50),
                    new SqlParameter("@cXqName", SqlDbType.NVarChar,50),
                    new SqlParameter("@bIsShenhe", SqlDbType.Bit,1),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.iUserID;
            parameters[2].Value = model.cMobile;
            parameters[3].Value = model.cCredentials;
            parameters[4].Value = model.dAddTime;
            parameters[5].Value = model.iGroupBuyID;
            parameters[6].Value = model.bIsAudit;
            parameters[7].Value = model.cName;
            parameters[8].Value = model.cHouseArea;
            parameters[9].Value = model.cXqName;
            parameters[10].Value = model.bIsShenhe;
            parameters[11].Direction = ParameterDirection.Output;
            parameters[12].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_GroupBuySignUp_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[11].Value.ToString());
            rtn.rtnMsg.Append(parameters[12].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 更新报名信息已用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update_Audit(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            string delSql = "update Sys_GroupBuySignUp set bIsAudit=@bIsAudit where iID=@iID";
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.bIsAudit;

            object obj = DBHelper.ExecuteCmd(delSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新报名信息是否审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update_Shenhe(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            string delSql = "update Sys_GroupBuySignUp set bIsShenhe=@bIsShenhe where iID=@iID";
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@bIsShenhe", SqlDbType.Bit,1)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.bIsShenhe;

            object obj = DBHelper.ExecuteCmd(delSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Sys_GroupBuySignUp model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@iUserID", SqlDbType.Int,4),
					new SqlParameter("@cMobile", SqlDbType.NVarChar,50),
					new SqlParameter("@cCredentials", SqlDbType.NVarChar,50),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@iGroupBuyID", SqlDbType.Int,4),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
                    new SqlParameter("@cName", SqlDbType.NVarChar,50),
                    new SqlParameter("@cHouseArea", SqlDbType.NVarChar,50),
                    new SqlParameter("@cXqName", SqlDbType.NVarChar,50),
                    new SqlParameter("@bIsShenhe", SqlDbType.Bit,1),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.iUserID;
            parameters[2].Value = model.cMobile;
            parameters[3].Value = model.cCredentials;
            parameters[4].Value = model.dAddTime;
            parameters[5].Value = model.iGroupBuyID;
            parameters[6].Value = model.bIsAudit;
            parameters[7].Value = model.cName;
            parameters[8].Value = model.cHouseArea;
            parameters[9].Value = model.cXqName;
            parameters[10].Value = model.bIsShenhe;
            parameters[11].Direction = ParameterDirection.Output;
            parameters[12].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("Sys_GroupBuySignUp_Update", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[10].Value.ToString());
            rtn.rtnMsg.Append(parameters[11].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public funRtn Delete(int iID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@iID", SqlDbType.Int,4),
											new SqlParameter("@rtnID", SqlDbType.Int,4),
											new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)
										};
            parameters[0].Value = iID;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_GroupBuySignUp_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Sys_GroupBuySignUp GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)
};
            parameters[0].Value = iID;

            XxWapSystem.Model.Sys_GroupBuySignUp model = new XxWapSystem.Model.Sys_GroupBuySignUp();
            DataSet ds = DBHelper.RunProcedure("Sys_GroupBuySignUp_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iUserID"].ToString() != "")
                {
                    model.iUserID = int.Parse(ds.Tables[0].Rows[0]["iUserID"].ToString());
                }
                model.cMobile = ds.Tables[0].Rows[0]["cMobile"].ToString();
                model.cCredentials = ds.Tables[0].Rows[0]["cCredentials"].ToString();
                if (ds.Tables[0].Rows[0]["dAddTime"].ToString() != "")
                {
                    model.dAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iGroupBuyID"].ToString() != "")
                {
                    model.iGroupBuyID = int.Parse(ds.Tables[0].Rows[0]["iGroupBuyID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bIsAudit"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bIsAudit"].ToString() == "1") || (ds.Tables[0].Rows[0]["bIsAudit"].ToString().ToLower() == "true"))
                    {
                        model.bIsAudit = true;
                    }
                    else
                    {
                        model.bIsAudit = false;
                    }
                }
                model.cName = ds.Tables[0].Rows[0]["cName"].ToString();
                model.cHouseArea = ds.Tables[0].Rows[0]["cHouseArea"].ToString();
                model.cXqName = ds.Tables[0].Rows[0]["cXqName"].ToString();
                if (ds.Tables[0].Rows[0]["bIsShenhe"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bIsShenhe"].ToString() == "1") || (ds.Tables[0].Rows[0]["bIsShenhe"].ToString().ToLower() == "true"))
                    {
                        model.bIsShenhe = true;
                    }
                    else
                    {
                        model.bIsShenhe = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取一个分页对象
        /// </summary>
        /// <param name="strGetFields">要获取的字段</param>
        /// <param name="PageSize">每页的大小</param>
        /// <param name="PageIndex">当前的页号</param>
        /// <param name="bDesc">是否降序排列记录</param>
        /// <param name="strFliter">条件</param>
        /// <returns>分页对象</returns>
        public PagerInfo GetList(string strGetFields, int PageSize, int PageIndex, bool bDesc, string strFliter)
        {
            PagerInfo PI = new PagerInfo("Sys_GroupBuySignUp", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }

        #endregion  Method
    }
}
