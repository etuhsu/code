using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_BuildingInfo
    /// </summary>
    public partial class Al_BuildingInfo
    {
        public Al_BuildingInfo()
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
            int result = DBHelper.RunProcedure("FC_UP_Al_BuildingInfo_Exists", parameters, out rowsAffected);
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
        /// 增加一条数据
        /// </summary>
        public funRtn Add(XxWapSystem.Model.Al_BuildingInfo model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@cImageAddress", SqlDbType.NVarChar),
					new SqlParameter("@cThumbnail", SqlDbType.NVarChar),
					new SqlParameter("@cProInfo", SqlDbType.NText),
					new SqlParameter("@cAddress", SqlDbType.NVarChar,250),
					new SqlParameter("@cBuildingType", SqlDbType.NVarChar,250),
					new SqlParameter("@cDoorArea", SqlDbType.NVarChar,250),
					new SqlParameter("@cDevelopers", SqlDbType.NVarChar,50),
					new SqlParameter("@cDesignUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cConstructionUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cProManUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cSalesAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@cSalesPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@cTelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@cPaymentType", SqlDbType.NVarChar),
					new SqlParameter("@cPropertyPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cZzdmj", SqlDbType.NVarChar,50),
					new SqlParameter("@cZghjzmj", SqlDbType.NVarChar,50),
					new SqlParameter("@cVolumeRate", SqlDbType.NVarChar,50),
					new SqlParameter("@cCovered", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseNum", SqlDbType.NVarChar,50),
					new SqlParameter("@cPlanningZongHuShu", SqlDbType.NVarChar,50),
					new SqlParameter("@cTotalInvestment", SqlDbType.NVarChar,50),
					new SqlParameter("@cGytdsyqz", SqlDbType.NVarChar,50),
					new SqlParameter("@cJsgcghxkz", SqlDbType.NVarChar,50),
					new SqlParameter("@cJsydghxkz", SqlDbType.NVarChar,50),
					new SqlParameter("@cJsgcsgxkz", SqlDbType.NVarChar,50),
					new SqlParameter("@cPropertyYears", SqlDbType.NVarChar,50),
					new SqlParameter("@cPropertyTypes", SqlDbType.NVarChar,50),
					new SqlParameter("@dStartingTime", SqlDbType.DateTime),
					new SqlParameter("@dCompletionTime", SqlDbType.DateTime),
					new SqlParameter("@cStandard", SqlDbType.NText),
					new SqlParameter("@cPeripheral", SqlDbType.NText),
					new SqlParameter("@cInternalSupporting", SqlDbType.NText),
					new SqlParameter("@cSurroundingCommercial", SqlDbType.NText),
					new SqlParameter("@cSurroundingLandscape", SqlDbType.NText),
					new SqlParameter("@cSurroundingPark", SqlDbType.NText),
					new SqlParameter("@cPeripheralHospital", SqlDbType.NText),
					new SqlParameter("@cPeripheralSchool", SqlDbType.NText),
					new SqlParameter("@cSurroundingTraffic", SqlDbType.NText),
					new SqlParameter("@cDecorateInfo", SqlDbType.NVarChar),
					new SqlParameter("@cIntelligentFacilities", SqlDbType.NVarChar),
					new SqlParameter("@cSsjwh", SqlDbType.NVarChar,50),
					new SqlParameter("@cMap", SqlDbType.NVarChar,50),
					new SqlParameter("@bIsAudit", SqlDbType.NVarChar,50),
					new SqlParameter("@iHits", SqlDbType.Int,4),
					new SqlParameter("@bIsRecommend", SqlDbType.Bit,1),
					new SqlParameter("@iAreaID", SqlDbType.Int,4),
					new SqlParameter("@iChannelID", SqlDbType.Int,4),
					new SqlParameter("@cBuildingFeatures", SqlDbType.NVarChar),
					new SqlParameter("@cHouseType", SqlDbType.NVarChar),
					new SqlParameter("@cOpeningTime", SqlDbType.NVarChar,50),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@cZhuangtai", SqlDbType.NVarChar,50),
					new SqlParameter("@cCommentInfo", SqlDbType.NVarChar),
					new SqlParameter("@cVideoAddress", SqlDbType.NVarChar),
					new SqlParameter("@cCmpX", SqlDbType.NVarChar,50),
					new SqlParameter("@cCmpY", SqlDbType.NVarChar,50),
					new SqlParameter("@cAreaImage", SqlDbType.NVarChar),
					new SqlParameter("@cBuildPinYing", SqlDbType.NVarChar,50),
					new SqlParameter("@cMaplng", SqlDbType.NVarChar,50),
					new SqlParameter("@cMaplat", SqlDbType.NVarChar,50),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.cProjectName;
            parameters[2].Value = model.cImageAddress;
            parameters[3].Value = model.cThumbnail;
            parameters[4].Value = model.cProInfo;
            parameters[5].Value = model.cAddress;
            parameters[6].Value = model.cBuildingType;
            parameters[7].Value = model.cDoorArea;
            parameters[8].Value = model.cDevelopers;
            parameters[9].Value = model.cDesignUnit;
            parameters[10].Value = model.cConstructionUnit;
            parameters[11].Value = model.cProManUnit;
            parameters[12].Value = model.cSalesAddress;
            parameters[13].Value = model.cSalesPhone;
            parameters[14].Value = model.cTelephone;
            parameters[15].Value = model.cPaymentType;
            parameters[16].Value = model.cPropertyPrice;
            parameters[17].Value = model.cZzdmj;
            parameters[18].Value = model.cZghjzmj;
            parameters[19].Value = model.cVolumeRate;
            parameters[20].Value = model.cCovered;
            parameters[21].Value = model.cHouseNum;
            parameters[22].Value = model.cPlanningZongHuShu;
            parameters[23].Value = model.cTotalInvestment;
            parameters[24].Value = model.cGytdsyqz;
            parameters[25].Value = model.cJsgcghxkz;
            parameters[26].Value = model.cJsydghxkz;
            parameters[27].Value = model.cJsgcsgxkz;
            parameters[28].Value = model.cPropertyYears;
            parameters[29].Value = model.cPropertyTypes;
            parameters[30].Value = model.dStartingTime;
            parameters[31].Value = model.dCompletionTime;
            parameters[32].Value = model.cStandard;
            parameters[33].Value = model.cPeripheral;
            parameters[34].Value = model.cInternalSupporting;
            parameters[35].Value = model.cSurroundingCommercial;
            parameters[36].Value = model.cSurroundingLandscape;
            parameters[37].Value = model.cSurroundingPark;
            parameters[38].Value = model.cPeripheralHospital;
            parameters[39].Value = model.cPeripheralSchool;
            parameters[40].Value = model.cSurroundingTraffic;
            parameters[41].Value = model.cDecorateInfo;
            parameters[42].Value = model.cIntelligentFacilities;
            parameters[43].Value = model.cSsjwh;
            parameters[44].Value = model.cMap;
            parameters[45].Value = model.bIsAudit;
            parameters[46].Value = model.iHits;
            parameters[47].Value = model.bIsRecommend;
            parameters[48].Value = model.iAreaID;
            parameters[49].Value = model.iChannelID;
            parameters[50].Value = model.cBuildingFeatures;
            parameters[51].Value = model.cHouseType;
            parameters[52].Value = model.cOpeningTime;
            parameters[53].Value = model.dAddTime;
            parameters[54].Value = model.cZhuangtai;
            parameters[55].Value = model.cCommentInfo;
            parameters[56].Value = model.cVideoAddress;
            parameters[57].Value = model.cCmpX;
            parameters[58].Value = model.cCmpY;
            parameters[59].Value = model.cAreaImage;
            parameters[60].Value = model.cBuildPinYing;
            parameters[61].Value = model.cMaplng;
            parameters[62].Value = model.cMaplat;
            parameters[63].Direction = ParameterDirection.Output;
            parameters[64].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_BuildingInfo_ADD", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[63].Value.ToString());
            rtn.rtnMsg.Append(parameters[64].Value.ToString());
            return rtn;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_BuildingInfo model)
        {
            SqlParameter[] parameters = {
                   new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@cProjectName", SqlDbType.NVarChar,50),
					new SqlParameter("@cImageAddress", SqlDbType.NVarChar),
					new SqlParameter("@cThumbnail", SqlDbType.NVarChar),
					new SqlParameter("@cProInfo", SqlDbType.NText),
					new SqlParameter("@cAddress", SqlDbType.NVarChar,250),
					new SqlParameter("@cBuildingType", SqlDbType.NVarChar,250),
					new SqlParameter("@cDoorArea", SqlDbType.NVarChar,250),
					new SqlParameter("@cDevelopers", SqlDbType.NVarChar,50),
					new SqlParameter("@cDesignUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cConstructionUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cProManUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@cSalesAddress", SqlDbType.NVarChar,50),
					new SqlParameter("@cSalesPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@cTelephone", SqlDbType.NVarChar,50),
					new SqlParameter("@cPaymentType", SqlDbType.NVarChar),
					new SqlParameter("@cPropertyPrice", SqlDbType.NVarChar,50),
					new SqlParameter("@cZzdmj", SqlDbType.NVarChar,50),
					new SqlParameter("@cZghjzmj", SqlDbType.NVarChar,50),
					new SqlParameter("@cVolumeRate", SqlDbType.NVarChar,50),
					new SqlParameter("@cCovered", SqlDbType.NVarChar,50),
					new SqlParameter("@cHouseNum", SqlDbType.NVarChar,50),
					new SqlParameter("@cPlanningZongHuShu", SqlDbType.NVarChar,50),
					new SqlParameter("@cTotalInvestment", SqlDbType.NVarChar,50),
					new SqlParameter("@cGytdsyqz", SqlDbType.NVarChar,50),
					new SqlParameter("@cJsgcghxkz", SqlDbType.NVarChar,50),
					new SqlParameter("@cJsydghxkz", SqlDbType.NVarChar,50),
					new SqlParameter("@cJsgcsgxkz", SqlDbType.NVarChar,50),
					new SqlParameter("@cPropertyYears", SqlDbType.NVarChar,50),
					new SqlParameter("@cPropertyTypes", SqlDbType.NVarChar,50),
					new SqlParameter("@dStartingTime", SqlDbType.DateTime),
					new SqlParameter("@dCompletionTime", SqlDbType.DateTime),
					new SqlParameter("@cStandard", SqlDbType.NText),
					new SqlParameter("@cPeripheral", SqlDbType.NText),
					new SqlParameter("@cInternalSupporting", SqlDbType.NText),
					new SqlParameter("@cSurroundingCommercial", SqlDbType.NText),
					new SqlParameter("@cSurroundingLandscape", SqlDbType.NText),
					new SqlParameter("@cSurroundingPark", SqlDbType.NText),
					new SqlParameter("@cPeripheralHospital", SqlDbType.NText),
					new SqlParameter("@cPeripheralSchool", SqlDbType.NText),
					new SqlParameter("@cSurroundingTraffic", SqlDbType.NText),
					new SqlParameter("@cDecorateInfo", SqlDbType.NVarChar),
					new SqlParameter("@cIntelligentFacilities", SqlDbType.NVarChar),
					new SqlParameter("@cSsjwh", SqlDbType.NVarChar,50),
					new SqlParameter("@cMap", SqlDbType.NVarChar,50),
					new SqlParameter("@bIsAudit", SqlDbType.NVarChar,50),
					new SqlParameter("@iHits", SqlDbType.Int,4),
					new SqlParameter("@bIsRecommend", SqlDbType.Bit,1),
					new SqlParameter("@iAreaID", SqlDbType.Int,4),
					new SqlParameter("@iChannelID", SqlDbType.Int,4),
					new SqlParameter("@cBuildingFeatures", SqlDbType.NVarChar),
					new SqlParameter("@cHouseType", SqlDbType.NVarChar),
					new SqlParameter("@cOpeningTime", SqlDbType.NVarChar,50),
					new SqlParameter("@dAddTime", SqlDbType.DateTime),
					new SqlParameter("@cZhuangtai", SqlDbType.NVarChar,50),
					new SqlParameter("@cCommentInfo", SqlDbType.NVarChar),
					new SqlParameter("@cVideoAddress", SqlDbType.NVarChar),
					new SqlParameter("@cCmpX", SqlDbType.NVarChar,50),
					new SqlParameter("@cCmpY", SqlDbType.NVarChar,50),
					new SqlParameter("@cAreaImage", SqlDbType.NVarChar),
					new SqlParameter("@cBuildPinYing", SqlDbType.NVarChar,50),
					new SqlParameter("@cMaplng", SqlDbType.NVarChar,50),
					new SqlParameter("@cMaplat", SqlDbType.NVarChar,50),
					new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.cProjectName;
            parameters[2].Value = model.cImageAddress;
            parameters[3].Value = model.cThumbnail;
            parameters[4].Value = model.cProInfo;
            parameters[5].Value = model.cAddress;
            parameters[6].Value = model.cBuildingType;
            parameters[7].Value = model.cDoorArea;
            parameters[8].Value = model.cDevelopers;
            parameters[9].Value = model.cDesignUnit;
            parameters[10].Value = model.cConstructionUnit;
            parameters[11].Value = model.cProManUnit;
            parameters[12].Value = model.cSalesAddress;
            parameters[13].Value = model.cSalesPhone;
            parameters[14].Value = model.cTelephone;
            parameters[15].Value = model.cPaymentType;
            parameters[16].Value = model.cPropertyPrice;
            parameters[17].Value = model.cZzdmj;
            parameters[18].Value = model.cZghjzmj;
            parameters[19].Value = model.cVolumeRate;
            parameters[20].Value = model.cCovered;
            parameters[21].Value = model.cHouseNum;
            parameters[22].Value = model.cPlanningZongHuShu;
            parameters[23].Value = model.cTotalInvestment;
            parameters[24].Value = model.cGytdsyqz;
            parameters[25].Value = model.cJsgcghxkz;
            parameters[26].Value = model.cJsydghxkz;
            parameters[27].Value = model.cJsgcsgxkz;
            parameters[28].Value = model.cPropertyYears;
            parameters[29].Value = model.cPropertyTypes;
            parameters[30].Value = model.dStartingTime;
            parameters[31].Value = model.dCompletionTime;
            parameters[32].Value = model.cStandard;
            parameters[33].Value = model.cPeripheral;
            parameters[34].Value = model.cInternalSupporting;
            parameters[35].Value = model.cSurroundingCommercial;
            parameters[36].Value = model.cSurroundingLandscape;
            parameters[37].Value = model.cSurroundingPark;
            parameters[38].Value = model.cPeripheralHospital;
            parameters[39].Value = model.cPeripheralSchool;
            parameters[40].Value = model.cSurroundingTraffic;
            parameters[41].Value = model.cDecorateInfo;
            parameters[42].Value = model.cIntelligentFacilities;
            parameters[43].Value = model.cSsjwh;
            parameters[44].Value = model.cMap;
            parameters[45].Value = model.bIsAudit;
            parameters[46].Value = model.iHits;
            parameters[47].Value = model.bIsRecommend;
            parameters[48].Value = model.iAreaID;
            parameters[49].Value = model.iChannelID;
            parameters[50].Value = model.cBuildingFeatures;
            parameters[51].Value = model.cHouseType;
            parameters[52].Value = model.cOpeningTime;
            parameters[53].Value = model.dAddTime;
            parameters[54].Value = model.cZhuangtai;
            parameters[55].Value = model.cCommentInfo;
            parameters[56].Value = model.cVideoAddress;
            parameters[57].Value = model.cCmpX;
            parameters[58].Value = model.cCmpY;
            parameters[59].Value = model.cAreaImage;
            parameters[60].Value = model.cBuildPinYing;
            parameters[61].Value = model.cMaplng;
            parameters[62].Value = model.cMaplat;
            parameters[63].Direction = ParameterDirection.Output;
            parameters[64].Direction = ParameterDirection.Output;
            DBHelper.RunProcedure("FC_UP_Al_BuildingInfo_Edit", parameters);

            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[63].Value.ToString());
            rtn.rtnMsg.Append(parameters[64].Value.ToString());
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
            DBHelper.RunProcedure("FC_UP_Al_BuildingInfo_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_BuildingInfo GetModel(int iID)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            XxWapSystem.Model.Al_BuildingInfo model = new XxWapSystem.Model.Al_BuildingInfo();
            DataSet ds = DBHelper.RunProcedure("FC_UP_Al_BuildingInfo_GetModel", parameters, "ds");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                model.cProjectName = ds.Tables[0].Rows[0]["cProjectName"].ToString();
                model.cImageAddress = ds.Tables[0].Rows[0]["cImageAddress"].ToString();
                model.cThumbnail = ds.Tables[0].Rows[0]["cThumbnail"].ToString();
                model.cProInfo = ds.Tables[0].Rows[0]["cProInfo"].ToString();
                model.cAddress = ds.Tables[0].Rows[0]["cAddress"].ToString();
                model.cBuildingType = ds.Tables[0].Rows[0]["cBuildingType"].ToString();
                model.cDoorArea = ds.Tables[0].Rows[0]["cDoorArea"].ToString();
                model.cDevelopers = ds.Tables[0].Rows[0]["cDevelopers"].ToString();
                model.cDesignUnit = ds.Tables[0].Rows[0]["cDesignUnit"].ToString();
                model.cConstructionUnit = ds.Tables[0].Rows[0]["cConstructionUnit"].ToString();
                model.cProManUnit = ds.Tables[0].Rows[0]["cProManUnit"].ToString();
                model.cSalesAddress = ds.Tables[0].Rows[0]["cSalesAddress"].ToString();
                model.cSalesPhone = ds.Tables[0].Rows[0]["cSalesPhone"].ToString();
                model.cTelephone = ds.Tables[0].Rows[0]["cTelephone"].ToString();
                model.cPaymentType = ds.Tables[0].Rows[0]["cPaymentType"].ToString();
                model.cPropertyPrice = ds.Tables[0].Rows[0]["cPropertyPrice"].ToString();
                model.cZzdmj = ds.Tables[0].Rows[0]["cZzdmj"].ToString();
                model.cZghjzmj = ds.Tables[0].Rows[0]["cZghjzmj"].ToString();
                model.cVolumeRate = ds.Tables[0].Rows[0]["cVolumeRate"].ToString();
                model.cCovered = ds.Tables[0].Rows[0]["cCovered"].ToString();
                model.cHouseNum = ds.Tables[0].Rows[0]["cHouseNum"].ToString();
                model.cPlanningZongHuShu = ds.Tables[0].Rows[0]["cPlanningZongHuShu"].ToString();
                model.cTotalInvestment = ds.Tables[0].Rows[0]["cTotalInvestment"].ToString();
                model.cGytdsyqz = ds.Tables[0].Rows[0]["cGytdsyqz"].ToString();
                model.cJsgcghxkz = ds.Tables[0].Rows[0]["cJsgcghxkz"].ToString();
                model.cJsydghxkz = ds.Tables[0].Rows[0]["cJsydghxkz"].ToString();
                model.cJsgcsgxkz = ds.Tables[0].Rows[0]["cJsgcsgxkz"].ToString();
                model.cPropertyYears = ds.Tables[0].Rows[0]["cPropertyYears"].ToString();
                model.cPropertyTypes = ds.Tables[0].Rows[0]["cPropertyTypes"].ToString();
                if (ds.Tables[0].Rows[0]["dStartingTime"].ToString() != "")
                {
                    model.dStartingTime = DateTime.Parse(ds.Tables[0].Rows[0]["dStartingTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dCompletionTime"].ToString() != "")
                {
                    model.dCompletionTime = DateTime.Parse(ds.Tables[0].Rows[0]["dCompletionTime"].ToString());
                }
                model.cStandard = ds.Tables[0].Rows[0]["cStandard"].ToString();
                model.cPeripheral = ds.Tables[0].Rows[0]["cPeripheral"].ToString();
                model.cInternalSupporting = ds.Tables[0].Rows[0]["cInternalSupporting"].ToString();
                model.cSurroundingCommercial = ds.Tables[0].Rows[0]["cSurroundingCommercial"].ToString();
                model.cSurroundingLandscape = ds.Tables[0].Rows[0]["cSurroundingLandscape"].ToString();
                model.cSurroundingPark = ds.Tables[0].Rows[0]["cSurroundingPark"].ToString();
                model.cPeripheralHospital = ds.Tables[0].Rows[0]["cPeripheralHospital"].ToString();
                model.cPeripheralSchool = ds.Tables[0].Rows[0]["cPeripheralSchool"].ToString();
                model.cSurroundingTraffic = ds.Tables[0].Rows[0]["cSurroundingTraffic"].ToString();
                model.cDecorateInfo = ds.Tables[0].Rows[0]["cDecorateInfo"].ToString();
                model.cIntelligentFacilities = ds.Tables[0].Rows[0]["cIntelligentFacilities"].ToString();
                model.cSsjwh = ds.Tables[0].Rows[0]["cSsjwh"].ToString();
                model.cMap = ds.Tables[0].Rows[0]["cMap"].ToString();
                model.bIsAudit = ds.Tables[0].Rows[0]["bIsAudit"].ToString();
                if (ds.Tables[0].Rows[0]["iHits"].ToString() != "")
                {
                    model.iHits = int.Parse(ds.Tables[0].Rows[0]["iHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bIsRecommend"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["bIsRecommend"].ToString() == "1") || (ds.Tables[0].Rows[0]["bIsRecommend"].ToString().ToLower() == "true"))
                    {
                        model.bIsRecommend = true;
                    }
                    else
                    {
                        model.bIsRecommend = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["iAreaID"].ToString() != "")
                {
                    model.iAreaID = int.Parse(ds.Tables[0].Rows[0]["iAreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iChannelID"].ToString() != "")
                {
                    model.iChannelID = int.Parse(ds.Tables[0].Rows[0]["iChannelID"].ToString());
                }
                model.cBuildingFeatures = ds.Tables[0].Rows[0]["cBuildingFeatures"].ToString();
                model.cHouseType = ds.Tables[0].Rows[0]["cHouseType"].ToString();
                model.cOpeningTime = ds.Tables[0].Rows[0]["cOpeningTime"].ToString();
                if (ds.Tables[0].Rows[0]["dAddTime"].ToString() != "")
                {
                    model.dAddTime = DateTime.Parse(ds.Tables[0].Rows[0]["dAddTime"].ToString());
                }
                model.cZhuangtai = ds.Tables[0].Rows[0]["cZhuangtai"].ToString();
                model.cCommentInfo = ds.Tables[0].Rows[0]["cCommentInfo"].ToString();
                model.cVideoAddress = ds.Tables[0].Rows[0]["cVideoAddress"].ToString();
                model.cCmpX = ds.Tables[0].Rows[0]["cCmpX"].ToString();
                model.cCmpY = ds.Tables[0].Rows[0]["cCmpY"].ToString();
                model.cAreaImage = ds.Tables[0].Rows[0]["cAreaImage"].ToString();
                model.cBuildPinYing = ds.Tables[0].Rows[0]["cBuildPinYing"].ToString();
                model.cMaplng = ds.Tables[0].Rows[0]["cMaplng"].ToString();
                model.cMaplat = ds.Tables[0].Rows[0]["cMaplat"].ToString();
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
            PagerInfo PI = new PagerInfo("Al_BuildingInfo", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }

        #endregion  Method
    }
}

