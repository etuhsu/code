using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_Building
    /// </summary>
    public partial class Al_Building
    {
        public Al_Building()
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

            int result = DBHelper.RunProcedure("FC_UP_Al_Building_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Al_Building model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cBuildingName", SqlDbType.NVarChar,50),
					new SqlParameter("@cMeasurementNum", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseLayer", SqlDbType.Int,4),
					new SqlParameter("@cHouseHight", SqlDbType.NChar,10),
					new SqlParameter("@cHouseToward", SqlDbType.NChar,10),
					new SqlParameter("@cHouseStructure", SqlDbType.NVarChar,50),
					new SqlParameter("@cConstructionUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseAreaOf", SqlDbType.NVarChar,50),
					new SqlParameter("@cResidentialArea", SqlDbType.NVarChar,50),
					new SqlParameter("@fCommercialArea", SqlDbType.NVarChar,50),
					new SqlParameter("@fOfficeArea", SqlDbType.NVarChar,50),
					new SqlParameter("@fOtherArea", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cBusinessStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cOfficeStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cOtherStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@dStartDate", SqlDbType.DateTime),
					new SqlParameter("@dCompletionDate", SqlDbType.DateTime),
					new SqlParameter("@dDeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cBuildingName;
            parameters[2].Value = model.cMeasurementNum;
            parameters[3].Value = model.cHouseLayer;
            parameters[4].Value = model.cHouseHight;
            parameters[5].Value = model.cHouseToward;
            parameters[6].Value = model.cHouseStructure;
            parameters[7].Value = model.cConstructionUnit;
            parameters[8].Value = model.cHouseAreaOf;
            parameters[9].Value = model.cResidentialArea;
            parameters[10].Value = model.fCommercialArea;
            parameters[11].Value = model.fOfficeArea;
            parameters[12].Value = model.fOtherArea;
            parameters[13].Value = model.cHouseStartPrice;
            parameters[14].Value = model.cBusinessStartPrice;
            parameters[15].Value = model.cOfficeStartPrice;
            parameters[16].Value = model.cOtherStartPrice;
            parameters[17].Value = model.dStartDate;
            parameters[18].Value = model.dCompletionDate;
            parameters[19].Value = model.dDeliveryDate;
            parameters[20].Value = model.bIsAudit;
            parameters[21].Value = model.iProjectID;
            parameters[22].Value = model.dAddTime;
            parameters[23].Direction = ParameterDirection.Output;
            parameters[24].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_Building_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[23].Value.ToString());
            rtn.rtnMsg.Append(parameters[24].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_Building model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cBuildingName", SqlDbType.NVarChar,50),
					new SqlParameter("@cMeasurementNum", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseLayer", SqlDbType.Int,4),
					new SqlParameter("@cHouseHight", SqlDbType.NChar,10),
					new SqlParameter("@cHouseToward", SqlDbType.NChar,10),
					new SqlParameter("@cHouseStructure", SqlDbType.NVarChar,50),
					new SqlParameter("@cConstructionUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseAreaOf", SqlDbType.NVarChar,50),
					new SqlParameter("@cResidentialArea", SqlDbType.NVarChar,50),
					new SqlParameter("@fCommercialArea", SqlDbType.NVarChar,50),
					new SqlParameter("@fOfficeArea", SqlDbType.NVarChar,50),
					new SqlParameter("@fOtherArea", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cBusinessStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cOfficeStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cOtherStartPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@dStartDate", SqlDbType.DateTime),
					new SqlParameter("@dCompletionDate", SqlDbType.DateTime),
					new SqlParameter("@dDeliveryDate", SqlDbType.DateTime),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cBuildingName;
            parameters[2].Value = model.cMeasurementNum;
            parameters[3].Value = model.cHouseLayer;
            parameters[4].Value = model.cHouseHight;
            parameters[5].Value = model.cHouseToward;
            parameters[6].Value = model.cHouseStructure;
            parameters[7].Value = model.cConstructionUnit;
            parameters[8].Value = model.cHouseAreaOf;
            parameters[9].Value = model.cResidentialArea;
            parameters[10].Value = model.fCommercialArea;
            parameters[11].Value = model.fOfficeArea;
            parameters[12].Value = model.fOtherArea;
            parameters[13].Value = model.cHouseStartPrice;
            parameters[14].Value = model.cBusinessStartPrice;
            parameters[15].Value = model.cOfficeStartPrice;
            parameters[16].Value = model.cOtherStartPrice;
            parameters[17].Value = model.dStartDate;
            parameters[18].Value = model.dCompletionDate;
            parameters[19].Value = model.dDeliveryDate;
            parameters[20].Value = model.bIsAudit;
            parameters[21].Value = model.iProjectID;
            parameters[22].Value = model.dAddTime;
            parameters[23].Direction = ParameterDirection.Output;
            parameters[24].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("FC_UP_Al_Building_Edit", parameters);
            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[23].Value.ToString());
            rtn.rtnMsg.Append(parameters[24].Value.ToString());
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
            DBHelper.RunProcedure("FC_UP_Al_Building_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_Building GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            XxWapSystem.Model.Al_Building model = new XxWapSystem.Model.Al_Building();
            DataSet ds = DBHelper.RunProcedure("FC_UP_Al_Building_GetModel", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                model.cBuildingName = ds.Tables[0].Rows[0]["cBuildingName"].ToString();
                model.cMeasurementNum = ds.Tables[0].Rows[0]["cMeasurementNum"].ToString();
                if (ds.Tables[0].Rows[0]["cHouseLayer"].ToString() != "")
                {
                    model.cHouseLayer = int.Parse(ds.Tables[0].Rows[0]["cHouseLayer"].ToString());
                }
                model.cHouseHight = ds.Tables[0].Rows[0]["cHouseHight"].ToString();
                model.cHouseToward = ds.Tables[0].Rows[0]["cHouseToward"].ToString();
                model.cHouseStructure = ds.Tables[0].Rows[0]["cHouseStructure"].ToString();
                model.cConstructionUnit = ds.Tables[0].Rows[0]["cConstructionUnit"].ToString();
                model.cHouseAreaOf = ds.Tables[0].Rows[0]["cHouseAreaOf"].ToString();
                model.cResidentialArea = ds.Tables[0].Rows[0]["cResidentialArea"].ToString();
                model.fCommercialArea = ds.Tables[0].Rows[0]["fCommercialArea"].ToString();
                model.fOfficeArea = ds.Tables[0].Rows[0]["fOfficeArea"].ToString();
                model.fOtherArea = ds.Tables[0].Rows[0]["fOtherArea"].ToString();
                model.cHouseStartPrice = ds.Tables[0].Rows[0]["cHouseStartPrice"].ToString();
                model.cBusinessStartPrice = ds.Tables[0].Rows[0]["cBusinessStartPrice"].ToString();
                model.cOfficeStartPrice = ds.Tables[0].Rows[0]["cOfficeStartPrice"].ToString();
                model.cOtherStartPrice = ds.Tables[0].Rows[0]["cOtherStartPrice"].ToString();
                if (ds.Tables[0].Rows[0]["dStartDate"].ToString() != "")
                {
                    model.dStartDate = DateTime.Parse(ds.Tables[0].Rows[0]["dStartDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dCompletionDate"].ToString() != "")
                {
                    model.dCompletionDate = DateTime.Parse(ds.Tables[0].Rows[0]["dCompletionDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dDeliveryDate"].ToString() != "")
                {
                    model.dDeliveryDate = DateTime.Parse(ds.Tables[0].Rows[0]["dDeliveryDate"].ToString());
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
                if (ds.Tables[0].Rows[0]["iProjectID"].ToString() != "")
                {
                    model.iProjectID = int.Parse(ds.Tables[0].Rows[0]["iProjectID"].ToString());
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
            PagerInfo PI = new PagerInfo("Al_Building", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }
        #endregion  Method
    }
}
