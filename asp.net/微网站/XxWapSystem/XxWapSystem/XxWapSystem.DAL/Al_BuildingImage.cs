using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_BuildingImage
    /// </summary>
    public partial class Al_BuildingImage
    {
        public Al_BuildingImage()
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

            int result = DBHelper.RunProcedure("FC_UP_Al_BuildingImage_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Al_BuildingImage model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iId", SqlDbType.Int,4),
                    new SqlParameter("@cTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@cImgAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@cThumbnail", SqlDbType.NVarChar,500),
					new SqlParameter("@iTypeID", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@dAuditTime", SqlDbType.NVarChar,50),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
                    new SqlParameter("@iPaixu", SqlDbType.Int,4),
                    new SqlParameter("@iAllPaixu", SqlDbType.Int,4),
                    new SqlParameter("@bIsRecommend", SqlDbType.Bit,1),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cTitle;
            parameters[2].Value = model.cImgAddress;
            parameters[3].Value = model.cThumbnail;
            parameters[4].Value = model.iTypeID;
            parameters[5].Value = model.dAddTime;
            parameters[6].Value = model.bIsAudit;
            parameters[7].Value = model.dAuditTime;
            parameters[8].Value = model.iProjectID;
            parameters[9].Value = model.iPaixu;
            parameters[10].Value = model.iAllPaixu;
            parameters[11].Value = model.bIsRecommend;
            parameters[12].Direction = ParameterDirection.Output;
            parameters[13].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_BuildingImage_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iId = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[12].Value.ToString());
            rtn.rtnMsg.Append(parameters[13].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_BuildingImage model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iId", SqlDbType.Int,4),
                    new SqlParameter("@cTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@cImgAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@cThumbnail", SqlDbType.NVarChar,500),
					new SqlParameter("@iTypeID", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@dAuditTime", SqlDbType.NVarChar,50),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
                    new SqlParameter("@iPaixu", SqlDbType.Int,4),
                    new SqlParameter("@iAllPaixu", SqlDbType.Int,4),
                    new SqlParameter("@bIsRecommend", SqlDbType.Bit,1),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iId;
            parameters[1].Value = model.cTitle;
            parameters[2].Value = model.cImgAddress;
            parameters[3].Value = model.cThumbnail;
            parameters[4].Value = model.iTypeID;
            parameters[5].Value = model.dAddTime;
            parameters[6].Value = model.bIsAudit;
            parameters[7].Value = model.dAuditTime;
            parameters[8].Value = model.iProjectID;
            parameters[9].Value = model.iPaixu;
            parameters[10].Value = model.iAllPaixu;
            parameters[11].Value = model.bIsRecommend;
            parameters[12].Direction = ParameterDirection.Output;
            parameters[13].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_BuildingImage_Edit", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[12].Value.ToString());
            rtn.rtnMsg.Append(parameters[13].Value.ToString());
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
            DBHelper.RunProcedure("FC_UP_Al_BuildingImage_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_BuildingImage GetModel(int iId)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iId", SqlDbType.Int,4)};
            parameters[0].Value = iId;

            XxWapSystem.Model.Al_BuildingImage model = new XxWapSystem.Model.Al_BuildingImage();
            DataSet ds = DBHelper.RunProcedure("FC_UP_Al_BuildingImage_GetModel", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iId"].ToString() != "")
                {
                    model.iId = int.Parse(ds.Tables[0].Rows[0]["iId"].ToString());
                }
                model.cTitle = ds.Tables[0].Rows[0]["cTitle"].ToString();
                model.cImgAddress = ds.Tables[0].Rows[0]["cImgAddress"].ToString();
                model.cThumbnail = ds.Tables[0].Rows[0]["cThumbnail"].ToString();
                if (ds.Tables[0].Rows[0]["iTypeID"].ToString() != "")
                {
                    model.iTypeID = int.Parse(ds.Tables[0].Rows[0]["iTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dAddTime"].ToString() != "")
                {
                    model.dAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAddTime"].ToString());
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
                if (ds.Tables[0].Rows[0]["bIsRecommend"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bIsRecommend"].ToString() == "1") || (ds.Tables[0].Rows[0]["bIsRecommend"].ToString().ToLower() == "true"))
                    {
                        model.bIsAudit = true;
                    }
                    else
                    {
                        model.bIsAudit = false;
                    }
                }
                model.dAuditTime = ds.Tables[0].Rows[0]["dAuditTime"].ToString();
                if (ds.Tables[0].Rows[0]["iProjectID"].ToString() != "")
                {
                    model.iProjectID = int.Parse(ds.Tables[0].Rows[0]["iProjectID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iPaixu"].ToString() != "")
                {
                    model.iPaixu = int.Parse(ds.Tables[0].Rows[0]["iPaixu"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iAllPaixu"].ToString() != "")
                {
                    model.iAllPaixu = int.Parse(ds.Tables[0].Rows[0]["iAllPaixu"].ToString());
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
            PagerInfo PI = new PagerInfo("Al_BuildingImage", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }
        #endregion  Method
    }
}
