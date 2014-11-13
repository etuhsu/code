using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_BuildingYsxkz
    /// </summary>
    public partial class Al_BuildingYsxkz
    {
        public Al_BuildingYsxkz()
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

            int result = DBHelper.RunProcedure("FC_UP_Al_BuildingYsxkz_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Al_BuildingYsxkz model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cYsxkzNum", SqlDbType.NVarChar,50),
					new SqlParameter("@cYsxkzImage", SqlDbType.NVarChar,500),
					new SqlParameter("@cYsxkzThumbnail", SqlDbType.NVarChar,500),
					new SqlParameter("@dIssueDate", SqlDbType.DateTime),
					new SqlParameter("@cPaixu", SqlDbType.NVarChar,50),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
					new SqlParameter("@iBid", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cYsxkzNum;
            parameters[2].Value = model.cYsxkzImage;
            parameters[3].Value = model.cYsxkzThumbnail;
            parameters[4].Value = model.dIssueDate;
            parameters[5].Value = model.cPaixu;
            parameters[6].Value = model.bIsAudit;
            parameters[7].Value = model.iProjectID;
            parameters[8].Value = model.iBid;
            parameters[9].Value = model.dAddTime;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_BuildingYsxkz_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[10].Value.ToString());
            rtn.rtnMsg.Append(parameters[11].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_BuildingYsxkz model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cYsxkzNum", SqlDbType.NVarChar,50),
					new SqlParameter("@cYsxkzImage", SqlDbType.NVarChar,500),
					new SqlParameter("@cYsxkzThumbnail", SqlDbType.NVarChar,500),
					new SqlParameter("@dIssueDate", SqlDbType.DateTime),
					new SqlParameter("@cPaixu", SqlDbType.NVarChar,50),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
					new SqlParameter("@iBid", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cYsxkzNum;
            parameters[2].Value = model.cYsxkzImage;
            parameters[3].Value = model.cYsxkzThumbnail;
            parameters[4].Value = model.dIssueDate;
            parameters[5].Value = model.cPaixu;
            parameters[6].Value = model.bIsAudit;
            parameters[7].Value = model.iProjectID;
            parameters[8].Value = model.iBid;
            parameters[9].Value = model.dAddTime;
            parameters[10].Direction = ParameterDirection.Output;
            parameters[11].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("FC_UP_Al_BuildingYsxkz_Edit", parameters);
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
            DBHelper.RunProcedure("FC_UP_Al_BuildingYsxkz_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_BuildingYsxkz GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            XxWapSystem.Model.Al_BuildingYsxkz model = new XxWapSystem.Model.Al_BuildingYsxkz();
            DataSet ds = DBHelper.RunProcedure("FC_UP_Al_BuildingYsxkz_GetModel", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                model.cYsxkzNum = ds.Tables[0].Rows[0]["cYsxkzNum"].ToString();
                model.cYsxkzImage = ds.Tables[0].Rows[0]["cYsxkzImage"].ToString();
                model.cYsxkzThumbnail = ds.Tables[0].Rows[0]["cYsxkzThumbnail"].ToString();
                if (ds.Tables[0].Rows[0]["dIssueDate"].ToString() != "")
                {
                    model.dIssueDate = DateTime.Parse(ds.Tables[0].Rows[0]["dIssueDate"].ToString());
                }
                model.cPaixu = ds.Tables[0].Rows[0]["cPaixu"].ToString();
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
                if (ds.Tables[0].Rows[0]["iProjectID"].ToString() != "")
                {
                    model.iProjectID = int.Parse(ds.Tables[0].Rows[0]["iProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iBid"].ToString() != "")
                {
                    model.iBid = int.Parse(ds.Tables[0].Rows[0]["iBid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dAddTime"].ToString() != "")
                {
                    model.dAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAddTime"].ToString());
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
            PagerInfo PI = new PagerInfo("Al_BuildingYsxkz", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }
        #endregion  Method
    }
}
