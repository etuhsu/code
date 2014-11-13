using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_ES_Lease
    /// </summary>
    public partial class D_ES_Lease
    {
        public D_ES_Lease()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int result = DBHelper.RunProcedure("Al_ES_Lease_Exists", parameters, out rowsAffected);
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
        public int Add(XxWapSystem.Model.Al_ES_Lease model, int AddNum, string uType, ref int NID, ref string ReMessage)
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
					new SqlParameter("@Construction", SqlDbType.Int,4),
					new SqlParameter("@buildStruct", SqlDbType.Int,4),

					new SqlParameter("@Decoration", SqlDbType.Int,4),
					new SqlParameter("@FloorNum", SqlDbType.Int,4),
					new SqlParameter("@direction", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Int,4),
					new SqlParameter("@Other", SqlDbType.NVarChar,500),

					new SqlParameter("@Phone", SqlDbType.NVarChar,30),
					new SqlParameter("@Linker", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@HouseMess", SqlDbType.NVarChar,1000),
					new SqlParameter("@AddTime", SqlDbType.DateTime),

					new SqlParameter("@UpdateUID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Bus", SqlDbType.NVarChar,100),
					new SqlParameter("@IsMiddle", SqlDbType.Bit,1),
					new SqlParameter("@UID", SqlDbType.Int,4),

					new SqlParameter("@Click", SqlDbType.Int,4),
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
					new SqlParameter("@LID", SqlDbType.Int,4),
					new SqlParameter("@LMessage", SqlDbType.NVarChar,200),
					new SqlParameter("@IsOk", SqlDbType.Bit,1),
					new SqlParameter("@HomeType1", SqlDbType.Int,4),
					new SqlParameter("@HomeType2", SqlDbType.Int,4)};

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

            parameters[10].Value = model.Decoration;
            parameters[11].Value = model.FloorNum;
            parameters[12].Value = model.direction;
            parameters[13].Value = model.Price;
            parameters[14].Value = model.Other;

            parameters[15].Value = model.Phone;
            parameters[16].Value = model.Linker;
            parameters[17].Value = model.Email;
            parameters[18].Value = model.HouseMess;
            parameters[19].Value = model.AddTime;

            parameters[20].Value = model.UpdateUID;
            parameters[21].Value = model.UpdateTime;
            parameters[22].Value = model.Bus;
            parameters[23].Value = model.IsMiddle;
            parameters[24].Value = model.UID;

            parameters[25].Value = model.Click;
            parameters[26].Value = model.MiddleID;
            parameters[27].Value = model.CompareID;
            parameters[28].Value = model.DelUID;
            parameters[29].Value = model.IsDel;

            parameters[30].Value = model.IsHot;
            parameters[31].Value = model.IsTop;
            parameters[32].Value = model.EndTime;

            parameters[33].Value = AddNum;
            parameters[34].Value = "求租";
            parameters[35].Value = uType;
            parameters[36].Direction = ParameterDirection.Output;
            parameters[37].Direction = ParameterDirection.Output;
            parameters[38].Value = model.IsOk;
            parameters[39].Value = model.HomeType1;
            parameters[40].Value = model.HomeType2;

            DBHelper.RunProcedure("Al_ES_Lease_Update", parameters, out rowsAffected);

            NID = Convert.ToInt32(parameters[36].Value);
            ReMessage = parameters[37].Value.ToString();

            return rowsAffected;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public bool Update(XxWapSystem.Model.Al_ES_Lease model, int AddNum, string uType, ref int NID, ref string ReMessage)
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
					new SqlParameter("@Construction", SqlDbType.Int,4),
					new SqlParameter("@buildStruct", SqlDbType.Int,4),
					new SqlParameter("@Decoration", SqlDbType.Int,4),
					new SqlParameter("@FloorNum", SqlDbType.Int,4),
					new SqlParameter("@direction", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Int,4),
					new SqlParameter("@Other", SqlDbType.NVarChar,500),
					new SqlParameter("@Phone", SqlDbType.NVarChar,30),
					new SqlParameter("@Linker", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@HouseMess", SqlDbType.NVarChar,1000),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Bus", SqlDbType.NVarChar,100),
					new SqlParameter("@IsMiddle", SqlDbType.Bit,1),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Click", SqlDbType.Int,4),
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
					new SqlParameter("@LID", SqlDbType.Int,4),
					new SqlParameter("@LMessage", SqlDbType.NVarChar,200),
					new SqlParameter("@IsOk", SqlDbType.Bit,1),
					new SqlParameter("@HomeType1", SqlDbType.Int,4),
					new SqlParameter("@HomeType2", SqlDbType.Int,4)};
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
            parameters[10].Value = model.Decoration;
            parameters[11].Value = model.FloorNum;
            parameters[12].Value = model.direction;
            parameters[13].Value = model.Price;
            parameters[14].Value = model.Other;
            parameters[15].Value = model.Phone;
            parameters[16].Value = model.Linker;
            parameters[17].Value = model.Email;
            parameters[18].Value = model.HouseMess;
            parameters[19].Value = model.AddTime;
            parameters[20].Value = model.UpdateUID;
            parameters[21].Value = model.UpdateTime;
            parameters[22].Value = model.Bus;
            parameters[23].Value = model.IsMiddle;
            parameters[24].Value = model.UID;
            parameters[25].Value = model.Click;
            parameters[26].Value = model.MiddleID;
            parameters[27].Value = model.CompareID;
            parameters[28].Value = model.DelUID;
            parameters[29].Value = model.IsDel;
            parameters[30].Value = model.IsHot;
            parameters[31].Value = model.IsTop;
            parameters[32].Value = model.EndTime;

            parameters[33].Value = AddNum;
            parameters[34].Value = "求租";
            parameters[35].Value = uType;
            parameters[36].Direction = ParameterDirection.Output;
            parameters[37].Direction = ParameterDirection.Output;
            parameters[38].Value = model.IsOk;
            parameters[39].Value = model.HomeType1;
            parameters[40].Value = model.HomeType2;

            DBHelper.RunProcedure("Al_ES_Lease_Update", parameters, out rowsAffected);

            NID = Convert.ToInt32(parameters[36].Value);
            ReMessage = parameters[37].Value.ToString();

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
        public bool Delete(string ID, int DelUID, bool RealDel, ref string ReMessage)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.NVarChar,500),
					new SqlParameter("@RealDel", SqlDbType.Bit),
					new SqlParameter("@DelUID", SqlDbType.Int,4),
					new SqlParameter("@BMessage", SqlDbType.NVarChar,100),
			};
            parameters[0].Value = "Al_ES_Lease";
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
        public XxWapSystem.Model.Al_ES_Lease GetModel(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tablename", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Where", SqlDbType.NVarChar,200)
			};
            parameters[0].Value = "V_Al_ES_Lease";
            parameters[1].Value = ID;
            parameters[2].Value = "";

            XxWapSystem.Model.Al_ES_Lease model = new XxWapSystem.Model.Al_ES_Lease();
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
                    model.Construction = int.Parse(ds.Tables[0].Rows[0]["Construction"].ToString());
                }
                if (ds.Tables[0].Rows[0]["buildStruct"] != null && ds.Tables[0].Rows[0]["buildStruct"].ToString() != "")
                {
                    model.buildStruct = int.Parse(ds.Tables[0].Rows[0]["buildStruct"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Decoration"] != null && ds.Tables[0].Rows[0]["Decoration"].ToString() != "")
                {
                    model.Decoration = int.Parse(ds.Tables[0].Rows[0]["Decoration"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ConstructionName"] != null && ds.Tables[0].Rows[0]["ConstructionName"].ToString() != "")
                {
                    model.ConstructionName = ds.Tables[0].Rows[0]["ConstructionName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["buildStructName"] != null && ds.Tables[0].Rows[0]["buildStructName"].ToString() != "")
                {
                    model.buildStructName = ds.Tables[0].Rows[0]["buildStructName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DecorationName"] != null && ds.Tables[0].Rows[0]["DecorationName"].ToString() != "")
                {
                    model.DecorationName = ds.Tables[0].Rows[0]["DecorationName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FloorNum"] != null && ds.Tables[0].Rows[0]["FloorNum"].ToString() != "")
                {
                    model.FloorNum = int.Parse(ds.Tables[0].Rows[0]["FloorNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["direction"] != null && ds.Tables[0].Rows[0]["direction"].ToString() != "")
                {
                    model.direction = int.Parse(ds.Tables[0].Rows[0]["direction"].ToString());
                }
                if (ds.Tables[0].Rows[0]["directionName"] != null && ds.Tables[0].Rows[0]["directionName"].ToString() != "")
                {
                    model.directionName = ds.Tables[0].Rows[0]["directionName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Price"] != null && ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = int.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PriceName"] != null && ds.Tables[0].Rows[0]["PriceName"].ToString() != "")
                {
                    model.PriceName = ds.Tables[0].Rows[0]["PriceName"].ToString();
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
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
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
                if (ds.Tables[0].Rows[0]["UID"] != null && ds.Tables[0].Rows[0]["UID"].ToString() != "")
                {
                    model.UID = int.Parse(ds.Tables[0].Rows[0]["UID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Click"] != null && ds.Tables[0].Rows[0]["Click"].ToString() != "")
                {
                    model.Click = int.Parse(ds.Tables[0].Rows[0]["Click"].ToString());
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
            strSql.Append(" FROM V_Al_ES_Lease ");
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
            strSql.Append(" FROM V_Al_ES_Lease ");
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
            strSql.Append(")AS Row, T.*  from V_Al_ES_Lease T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DBHelper.Query(strSql.ToString());
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
            parameters[0].Value = "V_Al_ES_Lease";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DBHelper.RunProcedure("UP_ES_GetRecordByPage",parameters,"ds");
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
            PagerInfo PI = new PagerInfo("V_Al_ES_Lease", strGetFields, orderby, PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }

        #endregion  Method
    }
}
