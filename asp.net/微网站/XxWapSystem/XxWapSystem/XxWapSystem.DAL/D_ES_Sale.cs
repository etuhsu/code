using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_ES_Sale
    /// </summary>
    public partial class D_ES_Sale
    {
        public D_ES_Sale()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
			};
            parameters[0].Value = ID;

            int result = DBHelper.RunProcedure("Al_ES_Sale_Exists", parameters, out rowsAffected);
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
        public int Add(XxWapSystem.Model.Al_ES_Sale model, int AddNum, string uType, ref int NID, ref string ReMessage)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@CodeNum", SqlDbType.NVarChar,20),
					new SqlParameter("@Area", SqlDbType.Int,4),
					new SqlParameter("@Area2", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@HomeType", SqlDbType.Int,4),
					new SqlParameter("@ManagerType", SqlDbType.Int,4),
					new SqlParameter("@Construction", SqlDbType.Decimal,5),
					new SqlParameter("@buildStruct", SqlDbType.Int,4),
					new SqlParameter("@direction", SqlDbType.Int,4),
					new SqlParameter("@darage", SqlDbType.Bit,1),
					new SqlParameter("@cupboard", SqlDbType.Bit,1),
					new SqlParameter("@cupboardSquare", SqlDbType.Decimal,5),
					new SqlParameter("@elevator", SqlDbType.Bit,1),
					new SqlParameter("@publicArea", SqlDbType.Float,8),
					new SqlParameter("@Decoration", SqlDbType.Int,4),
					new SqlParameter("@DecorationPrice", SqlDbType.Decimal,5),
					new SqlParameter("@FloorNum", SqlDbType.Int,4),
					new SqlParameter("@MaxFloor", SqlDbType.Int,4),
					new SqlParameter("@PropertyM", SqlDbType.Decimal,5),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@MaxPrice", SqlDbType.Decimal,9),
					new SqlParameter("@HouseAge", SqlDbType.Int,4),
					new SqlParameter("@Other", SqlDbType.NVarChar,500),
					new SqlParameter("@Phone", SqlDbType.NVarChar,30),
					new SqlParameter("@Linker", SqlDbType.NVarChar,20),
					new SqlParameter("@HouseMess", SqlDbType.NVarChar,1000),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Bus", SqlDbType.NVarChar,100),
					new SqlParameter("@pic1", SqlDbType.NVarChar,100),
					new SqlParameter("@pic2", SqlDbType.NVarChar,100),
					new SqlParameter("@pic3", SqlDbType.NVarChar,100),
					new SqlParameter("@pic4", SqlDbType.NVarChar,100),
					new SqlParameter("@pic5", SqlDbType.NVarChar,100),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMiddle", SqlDbType.Bit,1),
					new SqlParameter("@MiddleID", SqlDbType.Int,4),
					new SqlParameter("@CompareID", SqlDbType.Int,4),
					new SqlParameter("@DelUID", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@IsHot", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@UpNum", SqlDbType.Int,4),
					new SqlParameter("@ESType", SqlDbType.NVarChar,20),
					new SqlParameter("@uType", SqlDbType.NVarChar,20),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SMessage", SqlDbType.NVarChar,200),
					new SqlParameter("@IsOk", SqlDbType.Bit,1),
					new SqlParameter("@HomeType1", SqlDbType.Int,4),
					new SqlParameter("@HomeType2", SqlDbType.Int,4),
					new SqlParameter("@IsSScribe", SqlDbType.Bit,1),
					new SqlParameter("@SScribeTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.CodeNum;
            parameters[3].Value = model.Area;
            parameters[4].Value = model.Area2;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.HomeType;
            parameters[7].Value = model.ManagerType;
            parameters[8].Value = model.Construction;
            parameters[9].Value = model.buildStruct;
            parameters[10].Value = model.direction;
            parameters[11].Value = model.darage;
            parameters[12].Value = model.cupboard;
            parameters[13].Value = model.cupboardSquare;
            parameters[14].Value = model.elevator;
            parameters[15].Value = model.publicArea;
            parameters[16].Value = model.Decoration;
            parameters[17].Value = model.DecorationPrice;
            parameters[18].Value = model.FloorNum;
            parameters[19].Value = model.MaxFloor;
            parameters[20].Value = model.PropertyM;
            parameters[21].Value = model.Price;
            parameters[22].Value = model.MaxPrice;
            parameters[23].Value = model.HouseAge;
            parameters[24].Value = model.Other;
            parameters[25].Value = model.Phone;
            parameters[26].Value = model.Linker;
            parameters[27].Value = model.HouseMess;
            parameters[28].Value = model.AddTime;
            parameters[29].Value = model.UpdateUID;
            parameters[30].Value = model.UpdateTime;
            parameters[31].Value = model.Bus;
            parameters[32].Value = model.pic1;
            parameters[33].Value = model.pic2;
            parameters[34].Value = model.pic3;
            parameters[35].Value = model.pic4;
            parameters[36].Value = model.pic5;
            parameters[37].Value = model.UID;
            parameters[38].Value = model.Click;
            parameters[39].Value = model.IsMiddle;
            parameters[40].Value = model.MiddleID;
            parameters[41].Value = model.CompareID;
            parameters[42].Value = model.DelUID;
            parameters[43].Value = model.IsDel;
            parameters[44].Value = model.IsHot;
            parameters[45].Value = model.IsTop;
            parameters[46].Value = model.EndTime;

            parameters[47].Value = AddNum;
            parameters[48].Value = "出售";
            parameters[49].Value = uType;
            parameters[50].Direction = ParameterDirection.Output;
            parameters[51].Direction = ParameterDirection.Output;
            parameters[52].Value = model.IsOk;
            parameters[53].Value = model.HomeType1;
            parameters[54].Value = model.HomeType2;
            parameters[55].Value = model.IsSScribe;
            parameters[56].Value = model.SScribeTime;


            DBHelper.RunProcedure("Al_ES_Sale_Update", parameters, out rowsAffected);

            NID = Convert.ToInt32(parameters[50].Value);
            ReMessage = parameters[51].Value.ToString();
            return rowsAffected;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XxWapSystem.Model.Al_ES_Sale model, int AddNum, string uType, ref int NID, ref string ReMessage)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@CodeNum", SqlDbType.NVarChar,20),
					new SqlParameter("@Area", SqlDbType.Int,4),
					new SqlParameter("@Area2", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@HomeType", SqlDbType.Int,4),
					new SqlParameter("@ManagerType", SqlDbType.Int,4),
					new SqlParameter("@Construction", SqlDbType.Decimal,5),
					new SqlParameter("@buildStruct", SqlDbType.Int,4),
					new SqlParameter("@direction", SqlDbType.Int,4),
					new SqlParameter("@darage", SqlDbType.Bit,1),
					new SqlParameter("@cupboard", SqlDbType.Bit,1),
					new SqlParameter("@cupboardSquare", SqlDbType.Decimal,5),
					new SqlParameter("@elevator", SqlDbType.Bit,1),
					new SqlParameter("@publicArea", SqlDbType.Float,8),
					new SqlParameter("@Decoration", SqlDbType.Int,4),
					new SqlParameter("@DecorationPrice", SqlDbType.Decimal,5),
					new SqlParameter("@FloorNum", SqlDbType.Int,4),
					new SqlParameter("@MaxFloor", SqlDbType.Int,4),
					new SqlParameter("@PropertyM", SqlDbType.Decimal,5),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@MaxPrice", SqlDbType.Decimal,9),
					new SqlParameter("@HouseAge", SqlDbType.Int,4),
					new SqlParameter("@Other", SqlDbType.NVarChar,500),
					new SqlParameter("@Phone", SqlDbType.NVarChar,30),
					new SqlParameter("@Linker", SqlDbType.NVarChar,20),
					new SqlParameter("@HouseMess", SqlDbType.NVarChar,1000),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Bus", SqlDbType.NVarChar,100),
					new SqlParameter("@pic1", SqlDbType.NVarChar,100),
					new SqlParameter("@pic2", SqlDbType.NVarChar,100),
					new SqlParameter("@pic3", SqlDbType.NVarChar,100),
					new SqlParameter("@pic4", SqlDbType.NVarChar,100),
					new SqlParameter("@pic5", SqlDbType.NVarChar,100),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Click", SqlDbType.Int,4),
					new SqlParameter("@IsMiddle", SqlDbType.Bit,1),
					new SqlParameter("@MiddleID", SqlDbType.Int,4),
					new SqlParameter("@CompareID", SqlDbType.Int,4),
					new SqlParameter("@DelUID", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@IsHot", SqlDbType.Bit,1),
					new SqlParameter("@IsTop", SqlDbType.Bit,1),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@UpNum", SqlDbType.Int,4),
					new SqlParameter("@ESType", SqlDbType.NVarChar,20),
					new SqlParameter("@uType", SqlDbType.NVarChar,20),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SMessage", SqlDbType.NVarChar,200),
					new SqlParameter("@IsOk", SqlDbType.Bit,1),
					new SqlParameter("@HomeType1", SqlDbType.Int,4),
					new SqlParameter("@HomeType2", SqlDbType.Int,4),
					new SqlParameter("@IsSScribe", SqlDbType.Bit,1),
					new SqlParameter("@SScribeTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.CodeNum;
            parameters[3].Value = model.Area;
            parameters[4].Value = model.Area2;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.HomeType;
            parameters[7].Value = model.ManagerType;
            parameters[8].Value = model.Construction;
            parameters[9].Value = model.buildStruct;
            parameters[10].Value = model.direction;
            parameters[11].Value = model.darage;
            parameters[12].Value = model.cupboard;
            parameters[13].Value = model.cupboardSquare;
            parameters[14].Value = model.elevator;
            parameters[15].Value = model.publicArea;
            parameters[16].Value = model.Decoration;
            parameters[17].Value = model.DecorationPrice;
            parameters[18].Value = model.FloorNum;
            parameters[19].Value = model.MaxFloor;
            parameters[20].Value = model.PropertyM;
            parameters[21].Value = model.Price;
            parameters[22].Value = model.MaxPrice;
            parameters[23].Value = model.HouseAge;
            parameters[24].Value = model.Other;
            parameters[25].Value = model.Phone;
            parameters[26].Value = model.Linker;
            parameters[27].Value = model.HouseMess;
            parameters[28].Value = model.AddTime;
            parameters[29].Value = model.UpdateUID;
            parameters[30].Value = model.UpdateTime;
            parameters[31].Value = model.Bus;
            parameters[32].Value = model.pic1;
            parameters[33].Value = model.pic2;
            parameters[34].Value = model.pic3;
            parameters[35].Value = model.pic4;
            parameters[36].Value = model.pic5;
            parameters[37].Value = model.UID;
            parameters[38].Value = model.Click;
            parameters[39].Value = model.IsMiddle;
            parameters[40].Value = model.MiddleID;
            parameters[41].Value = model.CompareID;
            parameters[42].Value = model.DelUID;
            parameters[43].Value = model.IsDel;
            parameters[44].Value = model.IsHot;
            parameters[45].Value = model.IsTop;
            parameters[46].Value = model.EndTime;

            parameters[47].Value = AddNum;
            parameters[48].Value = "出售";
            parameters[49].Value = uType;
            parameters[50].Direction = ParameterDirection.Output;
            parameters[51].Direction = ParameterDirection.Output;
            parameters[52].Value = model.IsOk;
            parameters[53].Value = model.HomeType1;
            parameters[54].Value = model.HomeType2;
            parameters[55].Value = model.IsSScribe;
            parameters[56].Value = model.SScribeTime;

            DBHelper.RunProcedure("Al_ES_Sale_Update", parameters, out rowsAffected);

            NID = Convert.ToInt32(parameters[50].Value);
            ReMessage = parameters[51].Value.ToString();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID,int DelUID,bool RealDel,ref string ReMessage)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,500),
					new SqlParameter("@RealDel", SqlDbType.Bit),
					new SqlParameter("@DelUID", SqlDbType.Int,4),
					new SqlParameter("@BMessage", SqlDbType.NVarChar,100),
			};
            parameters[0].Value = "Al_ES_Sale";
            parameters[1].Value = ID;
            parameters[2].Value = RealDel;
            parameters[3].Value = DelUID;
            parameters[4].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("Al_ES_DEL", parameters, out rowsAffected);

            ReMessage = parameters[4].Value.ToString();

            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_ES_Sale GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tablename", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Where", SqlDbType.NVarChar,200)
			};
            parameters[0].Value = "V_Al_ES_Sale";
            parameters[1].Value = ID;
            parameters[2].Value = "";

            XxWapSystem.Model.Al_ES_Sale model = new XxWapSystem.Model.Al_ES_Sale();
            DataSet ds = DBHelper.RunProcedure("UP_ES_GetInfoList", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CodeNum"] != null && ds.Tables[0].Rows[0]["CodeNum"].ToString() != "")
                {
                    model.CodeNum = ds.Tables[0].Rows[0]["CodeNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Area"] != null && ds.Tables[0].Rows[0]["Area"].ToString() != "")
                {
                    model.Area = int.Parse(ds.Tables[0].Rows[0]["Area"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaName"] != null && ds.Tables[0].Rows[0]["AreaName"].ToString() != "")
                {
                    model.AreaName = ds.Tables[0].Rows[0]["AreaName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Area2"] != null && ds.Tables[0].Rows[0]["Area2"].ToString() != "")
                {
                    model.Area2 = int.Parse(ds.Tables[0].Rows[0]["Area2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Area2Name"] != null && ds.Tables[0].Rows[0]["Area2Name"].ToString() != "")
                {
                    model.Area2Name = ds.Tables[0].Rows[0]["Area2Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HomeType"] != null && ds.Tables[0].Rows[0]["HomeType"].ToString() != "")
                {
                    model.HomeType = int.Parse(ds.Tables[0].Rows[0]["HomeType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HomeType1"] != null && ds.Tables[0].Rows[0]["HomeType1"].ToString() != "")
                {
                    model.HomeType1 = int.Parse(ds.Tables[0].Rows[0]["HomeType1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HomeType2"] != null && ds.Tables[0].Rows[0]["HomeType2"].ToString() != "")
                {
                    model.HomeType2 = int.Parse(ds.Tables[0].Rows[0]["HomeType2"].ToString());
                }
                model.HomeTypeName = string.Format("{0}{1}{2}", (model.HomeType == null || model.HomeType <= 0) ? "" : model.HomeType.ToString() + "室", (model.HomeType1 == null || model.HomeType1 <= 0) ? "" : model.HomeType1.ToString() + "厅", (model.HomeType2 == null || model.HomeType2 <= 0) ? "" : model.HomeType2.ToString() + "卫");
                if (ds.Tables[0].Rows[0]["ManagerType"] != null && ds.Tables[0].Rows[0]["ManagerType"].ToString() != "")
                {
                    model.ManagerType = int.Parse(ds.Tables[0].Rows[0]["ManagerType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ManagerTypeName"] != null && ds.Tables[0].Rows[0]["ManagerTypeName"].ToString() != "")
                {
                    model.ManagerTypeName = ds.Tables[0].Rows[0]["ManagerTypeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Construction"] != null && ds.Tables[0].Rows[0]["Construction"].ToString() != "")
                {
                    model.Construction = decimal.Parse(ds.Tables[0].Rows[0]["Construction"].ToString());
                }
                if (ds.Tables[0].Rows[0]["buildStruct"] != null && ds.Tables[0].Rows[0]["buildStruct"].ToString() != "")
                {
                    model.buildStruct = int.Parse(ds.Tables[0].Rows[0]["buildStruct"].ToString());
                }
                if (ds.Tables[0].Rows[0]["buildStructName"] != null && ds.Tables[0].Rows[0]["buildStructName"].ToString() != "")
                {
                    model.buildStructName = ds.Tables[0].Rows[0]["buildStructName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["direction"] != null && ds.Tables[0].Rows[0]["direction"].ToString() != "")
                {
                    model.direction = int.Parse(ds.Tables[0].Rows[0]["direction"].ToString());
                }
                if (ds.Tables[0].Rows[0]["directionName"] != null && ds.Tables[0].Rows[0]["directionName"].ToString() != "")
                {
                    model.directionName = ds.Tables[0].Rows[0]["directionName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["darage"] != null && ds.Tables[0].Rows[0]["darage"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["darage"].ToString() == "1") || (ds.Tables[0].Rows[0]["darage"].ToString().ToLower() == "true"))
                    {
                        model.darage = true;
                    }
                    else
                    {
                        model.darage = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["cupboard"] != null && ds.Tables[0].Rows[0]["cupboard"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["cupboard"].ToString() == "1") || (ds.Tables[0].Rows[0]["cupboard"].ToString().ToLower() == "true"))
                    {
                        model.cupboard = true;
                    }
                    else
                    {
                        model.cupboard = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["cupboardSquare"] != null && ds.Tables[0].Rows[0]["cupboardSquare"].ToString() != "")
                {
                    model.cupboardSquare = decimal.Parse(ds.Tables[0].Rows[0]["cupboardSquare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["elevator"] != null && ds.Tables[0].Rows[0]["elevator"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["elevator"].ToString() == "1") || (ds.Tables[0].Rows[0]["elevator"].ToString().ToLower() == "true"))
                    {
                        model.elevator = true;
                    }
                    else
                    {
                        model.elevator = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["publicArea"] != null && ds.Tables[0].Rows[0]["publicArea"].ToString() != "")
                {
                    model.publicArea = decimal.Parse(ds.Tables[0].Rows[0]["publicArea"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Decoration"] != null && ds.Tables[0].Rows[0]["Decoration"].ToString() != "")
                {
                    model.Decoration = int.Parse(ds.Tables[0].Rows[0]["Decoration"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DecorationPrice"] != null && ds.Tables[0].Rows[0]["DecorationPrice"].ToString() != "")
                {
                    model.DecorationPrice = decimal.Parse(ds.Tables[0].Rows[0]["DecorationPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FloorNum"] != null && ds.Tables[0].Rows[0]["FloorNum"].ToString() != "")
                {
                    model.FloorNum = int.Parse(ds.Tables[0].Rows[0]["FloorNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaxFloor"] != null && ds.Tables[0].Rows[0]["MaxFloor"].ToString() != "")
                {
                    model.MaxFloor = int.Parse(ds.Tables[0].Rows[0]["MaxFloor"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PropertyM"] != null && ds.Tables[0].Rows[0]["PropertyM"].ToString() != "")
                {
                    model.PropertyM = decimal.Parse(ds.Tables[0].Rows[0]["PropertyM"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MaxPrice"] != null && ds.Tables[0].Rows[0]["MaxPrice"].ToString() != "")
                {
                    model.MaxPrice = decimal.Parse(ds.Tables[0].Rows[0]["MaxPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["HouseAge"] != null && ds.Tables[0].Rows[0]["HouseAge"].ToString() != "")
                {
                    model.HouseAge = int.Parse(ds.Tables[0].Rows[0]["HouseAge"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Other"] != null && ds.Tables[0].Rows[0]["Other"].ToString() != "")
                {
                    model.Other = ds.Tables[0].Rows[0]["Other"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Linker"] != null && ds.Tables[0].Rows[0]["Linker"].ToString() != "")
                {
                    model.Linker = ds.Tables[0].Rows[0]["Linker"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseMess"] != null && ds.Tables[0].Rows[0]["HouseMess"].ToString() != "")
                {
                    model.HouseMess = ds.Tables[0].Rows[0]["HouseMess"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AddTime"] != null && ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateUID"] != null && ds.Tables[0].Rows[0]["UpdateUID"].ToString() != "")
                {
                    model.UpdateUID = int.Parse(ds.Tables[0].Rows[0]["UpdateUID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"] != null && ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bus"] != null && ds.Tables[0].Rows[0]["Bus"].ToString() != "")
                {
                    model.Bus = ds.Tables[0].Rows[0]["Bus"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pic1"] != null && ds.Tables[0].Rows[0]["pic1"].ToString() != "")
                {
                    model.pic1 = ds.Tables[0].Rows[0]["pic1"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pic2"] != null && ds.Tables[0].Rows[0]["pic2"].ToString() != "")
                {
                    model.pic2 = ds.Tables[0].Rows[0]["pic2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pic3"] != null && ds.Tables[0].Rows[0]["pic3"].ToString() != "")
                {
                    model.pic3 = ds.Tables[0].Rows[0]["pic3"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pic4"] != null && ds.Tables[0].Rows[0]["pic4"].ToString() != "")
                {
                    model.pic4 = ds.Tables[0].Rows[0]["pic4"].ToString();
                }
                if (ds.Tables[0].Rows[0]["pic5"] != null && ds.Tables[0].Rows[0]["pic5"].ToString() != "")
                {
                    model.pic5 = ds.Tables[0].Rows[0]["pic5"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UID"] != null && ds.Tables[0].Rows[0]["UID"].ToString() != "")
                {
                    model.UID = int.Parse(ds.Tables[0].Rows[0]["UID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Click"] != null && ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsMiddle"] != null && ds.Tables[0].Rows[0]["IsMiddle"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsMiddle"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsMiddle"].ToString().ToLower() == "true"))
                    {
                        model.IsMiddle = true;
                    }
                    else
                    {
                        model.IsMiddle = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["MiddleID"] != null && ds.Tables[0].Rows[0]["MiddleID"].ToString() != "")
                {
                    model.MiddleID = int.Parse(ds.Tables[0].Rows[0]["MiddleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CompareID"] != null && ds.Tables[0].Rows[0]["CompareID"].ToString() != "")
                {
                    model.CompareID = int.Parse(ds.Tables[0].Rows[0]["CompareID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DelUID"] != null && ds.Tables[0].Rows[0]["DelUID"].ToString() != "")
                {
                    model.DelUID = int.Parse(ds.Tables[0].Rows[0]["DelUID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDel"] != null && ds.Tables[0].Rows[0]["IsDel"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsDel"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsDel"].ToString().ToLower() == "true"))
                    {
                        model.IsDel = true;
                    }
                    else
                    {
                        model.IsDel = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsHot"] != null && ds.Tables[0].Rows[0]["IsHot"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsHot"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsHot"].ToString().ToLower() == "true"))
                    {
                        model.IsHot = true;
                    }
                    else
                    {
                        model.IsHot = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsTop"] != null && ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsTop"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsTop"].ToString().ToLower() == "true"))
                    {
                        model.IsTop = true;
                    }
                    else
                    {
                        model.IsTop = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsOk"] != null && ds.Tables[0].Rows[0]["IsOk"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsOk"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOk"].ToString().ToLower() == "true"))
                    {
                        model.IsOk = true;
                    }
                    else
                    {
                        model.IsOk = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsSScribe"] != null && ds.Tables[0].Rows[0]["IsSScribe"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsSScribe"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsSScribe"].ToString().ToLower() == "true"))
                    {
                        model.IsSScribe = true;
                    }
                    else
                    {
                        model.IsSScribe = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SScribeTime"] != null && ds.Tables[0].Rows[0]["SScribeTime"].ToString() != "")
                {
                    model.SScribeTime = DateTime.Parse(ds.Tables[0].Rows[0]["SScribeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"] != null && ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Al_ES_Sale ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM V_Al_ES_Sale ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DBHelper.Query(strSql.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from V_Al_ES_Sale T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.Query(strSql.ToString());
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
        public PagerInfo GetList(string strGetFields, string orderby, int PageSize, int PageIndex, bool bDesc, string strFliter)
        {
            PagerInfo PI = new PagerInfo("V_Al_ES_Sale", strGetFields, orderby, PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "V_Al_ES_Sale";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelper.RunProcedure("UP_ES_GetRecordByPage",parameters,"ds");
        }

        #endregion  Method
    }
}