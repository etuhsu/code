using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Sys_GroupBuyInfo
    /// </summary>
    public partial class Sys_GroupBuyInfo
    {
        public Sys_GroupBuyInfo()
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

            int result = DBHelper.RunProcedure("Sys_GroupBuyInfo_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@cProductName", SqlDbType.NVarChar,100),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@cGroupBuyingAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@cGroupBuyingStartTime", SqlDbType.DateTime),
					new SqlParameter("@cGroupBuyingEndTime", SqlDbType.DateTime),
					new SqlParameter("@cOldPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cPriceDw", SqlDbType.NVarChar,50),
					new SqlParameter("@cNewPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@iGroupBuyingMinPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@iGroupBuyingMaxPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@cTitleImg", SqlDbType.NVarChar,255),
					new SqlParameter("@cTitleImgThumbnail", SqlDbType.NVarChar,255),
					new SqlParameter("@cGroupInfo", SqlDbType.NVarChar),
					new SqlParameter("@cIntroduce", SqlDbType.NText),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@bIsRecommended", SqlDbType.Bit,1),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@cGroupBuyLinkman", SqlDbType.NVarChar,50),
					new SqlParameter("@cGroupBuyPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@cGroupBuySmsContent", SqlDbType.NVarChar),
                    new SqlParameter("@cFolderPath", SqlDbType.NVarChar,500),
                    new SqlParameter("@cFileName", SqlDbType.NVarChar,500),
                    new SqlParameter("@cFileExtend", SqlDbType.NVarChar,500),
                    new SqlParameter("@cTemplatePath", SqlDbType.NVarChar,500),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cTitle;
            parameters[2].Value = model.cProductName;
            parameters[3].Value = model.cName;
            parameters[4].Value = model.cGroupBuyingAddress;
            parameters[5].Value = model.cGroupBuyingStartTime;
            parameters[6].Value = model.cGroupBuyingEndTime;
            parameters[7].Value = model.cOldPrice;
            parameters[8].Value = model.cPriceDw;
            parameters[9].Value = model.cNewPrice;
            parameters[10].Value = model.iGroupBuyingMinPerson;
            parameters[11].Value = model.iGroupBuyingMaxPerson;
            parameters[12].Value = model.cTitleImg;
            parameters[13].Value = model.cTitleImgThumbnail;
            parameters[14].Value = model.cGroupInfo;
            parameters[15].Value = model.cIntroduce;
            parameters[16].Value = model.bIsAudit;
            parameters[17].Value = model.bIsRecommended;
            parameters[18].Value = model.dAddTime;
            parameters[19].Value = model.cGroupBuyLinkman;
            parameters[20].Value = model.cGroupBuyPhone;
            parameters[21].Value = model.cGroupBuySmsContent;
            parameters[22].Value = model.cFolderPath;
            parameters[23].Value = model.cFileName;
            parameters[24].Value = model.cFileExtend;
            parameters[25].Value = model.cTemplatePath;
            parameters[26].Direction = ParameterDirection.Output;
            parameters[27].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("Sys_GroupBuyInfo_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[26].Value.ToString());
            rtn.rtnMsg.Append(parameters[27].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cTitle", SqlDbType.NVarChar,200),
					new SqlParameter("@cProductName", SqlDbType.NVarChar,100),
					new SqlParameter("@cName", SqlDbType.NVarChar,50),
					new SqlParameter("@cGroupBuyingAddress", SqlDbType.NVarChar,500),
					new SqlParameter("@cGroupBuyingStartTime", SqlDbType.DateTime),
					new SqlParameter("@cGroupBuyingEndTime", SqlDbType.DateTime),
					new SqlParameter("@cOldPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cPriceDw", SqlDbType.NVarChar,50),
					new SqlParameter("@cNewPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@iGroupBuyingMinPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@iGroupBuyingMaxPerson", SqlDbType.NVarChar,50),
					new SqlParameter("@cTitleImg", SqlDbType.NVarChar,255),
					new SqlParameter("@cTitleImgThumbnail", SqlDbType.NVarChar,255),
					new SqlParameter("@cGroupInfo", SqlDbType.NVarChar),
					new SqlParameter("@cIntroduce", SqlDbType.NText),
					new SqlParameter("@bIsAudit", SqlDbType.Bit,1),
					new SqlParameter("@bIsRecommended", SqlDbType.Bit,1),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@cGroupBuyLinkman", SqlDbType.NVarChar,50),
					new SqlParameter("@cGroupBuyPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@cGroupBuySmsContent", SqlDbType.NVarChar),
                    new SqlParameter("@cFolderPath", SqlDbType.NVarChar,500),
                    new SqlParameter("@cFileName", SqlDbType.NVarChar,500),
                    new SqlParameter("@cFileExtend", SqlDbType.NVarChar,500),
                    new SqlParameter("@cTemplatePath", SqlDbType.NVarChar,500),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cTitle;
            parameters[2].Value = model.cProductName;
            parameters[3].Value = model.cName;
            parameters[4].Value = model.cGroupBuyingAddress;
            parameters[5].Value = model.cGroupBuyingStartTime;
            parameters[6].Value = model.cGroupBuyingEndTime;
            parameters[7].Value = model.cOldPrice;
            parameters[8].Value = model.cPriceDw;
            parameters[9].Value = model.cNewPrice;
            parameters[10].Value = model.iGroupBuyingMinPerson;
            parameters[11].Value = model.iGroupBuyingMaxPerson;
            parameters[12].Value = model.cTitleImg;
            parameters[13].Value = model.cTitleImgThumbnail;
            parameters[14].Value = model.cGroupInfo;
            parameters[15].Value = model.cIntroduce;
            parameters[16].Value = model.bIsAudit;
            parameters[17].Value = model.bIsRecommended;
            parameters[18].Value = model.dAddTime;
            parameters[19].Value = model.cGroupBuyLinkman;
            parameters[20].Value = model.cGroupBuyPhone;
            parameters[21].Value = model.cGroupBuySmsContent;
            parameters[22].Value = model.cFolderPath;
            parameters[23].Value = model.cFileName;
            parameters[24].Value = model.cFileExtend;
            parameters[25].Value = model.cTemplatePath;
            parameters[26].Direction = ParameterDirection.Output;
            parameters[27].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("Sys_GroupBuyInfo_Update", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[26].Value.ToString());
            rtn.rtnMsg.Append(parameters[27].Value.ToString());
            return rtn;
        }

        //更新是否推荐
        public int Update_Recommended(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            string delSql = "update Sys_GroupBuyInfo set bIsRecommended=@bIsRecommended where iID=@iID";
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@bIsRecommended", SqlDbType.Bit,1)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.bIsRecommended;

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

        //更新是否审核
        public int Update_Audit(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            string delSql = "update Sys_GroupBuyInfo set bIsAudit=@bIsAudit where iID=@iID";
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
            DBHelper.RunProcedure("Sys_GroupBuyInfo_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 删除该团购下的所有报名
        /// </summary>
        public int Delete_GroupSignUp(int iGroupID)
        {
            string delSql = "delete from Sys_GroupBuySignUp where iGroupBuyID=" + iGroupID + "";
            object obj = DBHelper.ExecuteCmd(delSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Sys_GroupBuyInfo GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)
};
            parameters[0].Value = iID;

            XxWapSystem.Model.Sys_GroupBuyInfo model = new XxWapSystem.Model.Sys_GroupBuyInfo();
            DataSet ds = DBHelper.RunProcedure("Sys_GroupBuyInfo_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                model.cTitle = ds.Tables[0].Rows[0]["cTitle"].ToString();
                model.cProductName = ds.Tables[0].Rows[0]["cProductName"].ToString();
                model.cName = ds.Tables[0].Rows[0]["cName"].ToString();
                model.cGroupBuyingAddress = ds.Tables[0].Rows[0]["cGroupBuyingAddress"].ToString();
                if (ds.Tables[0].Rows[0]["cGroupBuyingStartTime"].ToString() != "")
                {
                    model.cGroupBuyingStartTime = DateTime.Parse(ds.Tables[0].Rows[0]["cGroupBuyingStartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cGroupBuyingEndTime"].ToString() != "")
                {
                    model.cGroupBuyingEndTime = DateTime.Parse(ds.Tables[0].Rows[0]["cGroupBuyingEndTime"].ToString());
                }
                model.cOldPrice = ds.Tables[0].Rows[0]["cOldPrice"].ToString();
                model.cPriceDw = ds.Tables[0].Rows[0]["cPriceDw"].ToString();
                model.cNewPrice = ds.Tables[0].Rows[0]["cNewPrice"].ToString();
                model.iGroupBuyingMinPerson = ds.Tables[0].Rows[0]["iGroupBuyingMinPerson"].ToString();
                model.iGroupBuyingMaxPerson = ds.Tables[0].Rows[0]["iGroupBuyingMaxPerson"].ToString();
                model.cTitleImg = ds.Tables[0].Rows[0]["cTitleImg"].ToString();
                model.cTitleImgThumbnail = ds.Tables[0].Rows[0]["cTitleImgThumbnail"].ToString();
                model.cGroupInfo = ds.Tables[0].Rows[0]["cGroupInfo"].ToString();
                model.cIntroduce = ds.Tables[0].Rows[0]["cIntroduce"].ToString();
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
                if (ds.Tables[0].Rows[0]["bIsRecommended"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bIsRecommended"].ToString() == "1") || (ds.Tables[0].Rows[0]["bIsRecommended"].ToString().ToLower() == "true"))
                    {
                        model.bIsRecommended = true;
                    }
                    else
                    {
                        model.bIsRecommended = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["dAddTime"].ToString() != "")
                {
                    model.dAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAddTime"].ToString());
                }
                model.cGroupBuyLinkman = ds.Tables[0].Rows[0]["cGroupBuyLinkman"].ToString();
                model.cGroupBuyPhone = ds.Tables[0].Rows[0]["cGroupBuyPhone"].ToString();
                model.cGroupBuySmsContent = ds.Tables[0].Rows[0]["cGroupBuySmsContent"].ToString();
                model.cFolderPath = ds.Tables[0].Rows[0]["cFolderPath"].ToString();
                model.cFileName = ds.Tables[0].Rows[0]["cFileName"].ToString();
                model.cFileExtend = ds.Tables[0].Rows[0]["cFileExtend"].ToString();
                model.cTemplatePath = ds.Tables[0].Rows[0]["cTemplatePath"].ToString();
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
            PagerInfo PI = new PagerInfo("Sys_GroupBuyInfo", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }
        #endregion  Method
    }
}
