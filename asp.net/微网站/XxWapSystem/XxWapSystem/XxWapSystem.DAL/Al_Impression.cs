using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_Impression
    /// </summary>
    public partial class Al_Impression
    {
        public Al_Impression()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iId)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@iId", SqlDbType.Int,4)};
            parameters[0].Value = iId;

            int result = DBHelper.RunProcedure("FC_UP_Al_Impression_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Al_Impression model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iId", SqlDbType.Int,4),
					new SqlParameter("@cText", SqlDbType.NVarChar,50),
					new SqlParameter("@iHit", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@iProjectId", SqlDbType.Int,4),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cText;
            parameters[2].Value = model.iHit;
            parameters[3].Value = model.dAddTime;
            parameters[4].Value = model.iProjectId;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_Impression_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iId = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[5].Value.ToString());
            rtn.rtnMsg.Append(parameters[6].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_Impression model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iId", SqlDbType.Int,4),
					new SqlParameter("@cText", SqlDbType.NVarChar,50),
					new SqlParameter("@iHit", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@iProjectId", SqlDbType.Int,4),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iId;
            parameters[1].Value = model.cText;
            parameters[2].Value = model.iHit;
            parameters[3].Value = model.dAddTime;
            parameters[4].Value = model.iProjectId;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("FC_UP_Al_Impression_Edit", parameters);
            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[5].Value.ToString());
            rtn.rtnMsg.Append(parameters[6].Value.ToString());
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
            DBHelper.RunProcedure("FC_UP_Al_Impression_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_Impression GetModel(int iId)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iId", SqlDbType.Int,4)};
            parameters[0].Value = iId;

            XxWapSystem.Model.Al_Impression model = new XxWapSystem.Model.Al_Impression();
            DataSet ds = DBHelper.RunProcedure("FC_UP_Al_Impression_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iId"].ToString() != "")
                {
                    model.iId = int.Parse(ds.Tables[0].Rows[0]["iId"].ToString());
                }
                model.cText = ds.Tables[0].Rows[0]["cText"].ToString();
                if (ds.Tables[0].Rows[0]["iHit"].ToString() != "")
                {
                    model.iHit = int.Parse(ds.Tables[0].Rows[0]["iHit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dAddTime"].ToString() != "")
                {
                    model.dAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iProjectId"].ToString() != "")
                {
                    model.iProjectId = int.Parse(ds.Tables[0].Rows[0]["iProjectId"].ToString());
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
            PagerInfo PI = new PagerInfo("Al_Impression", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }
        #endregion  Method
    }
}
