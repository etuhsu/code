using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_BuildingFeatures
    /// </summary>
    public partial class Al_BuildingFeatures
    {
        public Al_BuildingFeatures()
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

            int result = DBHelper.RunProcedure("FC_UP_Al_BuildingFeatures_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Al_BuildingFeatures model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cChName", SqlDbType.NVarChar,50),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cChName;
            parameters[2].Value = model.dAddTime;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_BuildingFeatures_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[3].Value.ToString());
            rtn.rtnMsg.Append(parameters[4].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_BuildingFeatures model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cChName", SqlDbType.NVarChar,50),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cChName;
            parameters[2].Value = model.dAddTime;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_BuildingFeatures_Edit", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[3].Value.ToString());
            rtn.rtnMsg.Append(parameters[4].Value.ToString());
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
            DBHelper.RunProcedure("FC_UP_Al_BuildingFeatures_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_BuildingFeatures GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;
            XxWapSystem.Model.Al_BuildingFeatures model = new XxWapSystem.Model.Al_BuildingFeatures();
            DataSet ds = DBHelper.RunProcedure("FC_UP_Al_BuildingFeatures_GetModel", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                model.cChName = ds.Tables[0].Rows[0]["cChName"].ToString();
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
            PagerInfo PI = new PagerInfo("Al_BuildingFeatures", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }
        #endregion  Method
    }
}
