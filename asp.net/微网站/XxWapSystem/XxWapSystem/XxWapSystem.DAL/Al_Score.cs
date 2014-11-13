using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace XxWapSystem.DAL
{
    /// <summary>
    /// 数据访问类:Al_Score
    /// </summary>
    public partial class Al_Score
    {
        public Al_Score()
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

            int result = DBHelper.RunProcedure("FC_UP_Al_Score_Exists", parameters, out rowsAffected);
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
        public funRtn Add(XxWapSystem.Model.Al_Score model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@iJ1", SqlDbType.Int,4),
					new SqlParameter("@iJ2", SqlDbType.Int,4),
					new SqlParameter("@iJ3", SqlDbType.Int,4),
					new SqlParameter("@iJ4", SqlDbType.Int,4),
					new SqlParameter("@iJ5", SqlDbType.Int,4),
					new SqlParameter("@iH1", SqlDbType.Int,4),
					new SqlParameter("@iH2", SqlDbType.Int,4),
					new SqlParameter("@iH3", SqlDbType.Int,4),
					new SqlParameter("@iH4", SqlDbType.Int,4),
					new SqlParameter("@iH5", SqlDbType.Int,4),
					new SqlParameter("@iG1", SqlDbType.Int,4),
					new SqlParameter("@iG2", SqlDbType.Int,4),
					new SqlParameter("@iG3", SqlDbType.Int,4),
					new SqlParameter("@iG4", SqlDbType.Int,4),
					new SqlParameter("@iG5", SqlDbType.Int,4),
					new SqlParameter("@iP1", SqlDbType.Int,4),
					new SqlParameter("@iP2", SqlDbType.Int,4),
					new SqlParameter("@iP3", SqlDbType.Int,4),
					new SqlParameter("@iP4", SqlDbType.Int,4),
					new SqlParameter("@iP5", SqlDbType.Int,4),
					new SqlParameter("@iK1", SqlDbType.Int,4),
					new SqlParameter("@iK2", SqlDbType.Int,4),
					new SqlParameter("@iK3", SqlDbType.Int,4),
					new SqlParameter("@iK4", SqlDbType.Int,4),
					new SqlParameter("@iK5", SqlDbType.Int,4),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.iJ1;
            parameters[2].Value = model.iJ2;
            parameters[3].Value = model.iJ3;
            parameters[4].Value = model.iJ4;
            parameters[5].Value = model.iJ5;
            parameters[6].Value = model.iH1;
            parameters[7].Value = model.iH2;
            parameters[8].Value = model.iH3;
            parameters[9].Value = model.iH4;
            parameters[10].Value = model.iH5;
            parameters[11].Value = model.iG1;
            parameters[12].Value = model.iG2;
            parameters[13].Value = model.iG3;
            parameters[14].Value = model.iG4;
            parameters[15].Value = model.iG5;
            parameters[16].Value = model.iP1;
            parameters[17].Value = model.iP2;
            parameters[18].Value = model.iP3;
            parameters[19].Value = model.iP4;
            parameters[20].Value = model.iP5;
            parameters[21].Value = model.iK1;
            parameters[22].Value = model.iK2;
            parameters[23].Value = model.iK3;
            parameters[24].Value = model.iK4;
            parameters[25].Value = model.iK5;
            parameters[26].Value = model.iProjectID;
            parameters[27].Direction = ParameterDirection.Output;
            parameters[28].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("FC_UP_Al_Score_ADD", parameters);
            //处理返回结果
            funRtn rtn = new funRtn();
            model.iID = int.Parse(parameters[0].Value.ToString());
            rtn.rtnID = int.Parse(parameters[27].Value.ToString());
            rtn.rtnMsg.Append(parameters[28].Value.ToString());
            return rtn;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_Score model)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4),
					new SqlParameter("@iJ1", SqlDbType.Int,4),
					new SqlParameter("@iJ2", SqlDbType.Int,4),
					new SqlParameter("@iJ3", SqlDbType.Int,4),
					new SqlParameter("@iJ4", SqlDbType.Int,4),
					new SqlParameter("@iJ5", SqlDbType.Int,4),
					new SqlParameter("@iH1", SqlDbType.Int,4),
					new SqlParameter("@iH2", SqlDbType.Int,4),
					new SqlParameter("@iH3", SqlDbType.Int,4),
					new SqlParameter("@iH4", SqlDbType.Int,4),
					new SqlParameter("@iH5", SqlDbType.Int,4),
					new SqlParameter("@iG1", SqlDbType.Int,4),
					new SqlParameter("@iG2", SqlDbType.Int,4),
					new SqlParameter("@iG3", SqlDbType.Int,4),
					new SqlParameter("@iG4", SqlDbType.Int,4),
					new SqlParameter("@iG5", SqlDbType.Int,4),
					new SqlParameter("@iP1", SqlDbType.Int,4),
					new SqlParameter("@iP2", SqlDbType.Int,4),
					new SqlParameter("@iP3", SqlDbType.Int,4),
					new SqlParameter("@iP4", SqlDbType.Int,4),
					new SqlParameter("@iP5", SqlDbType.Int,4),
					new SqlParameter("@iK1", SqlDbType.Int,4),
					new SqlParameter("@iK2", SqlDbType.Int,4),
					new SqlParameter("@iK3", SqlDbType.Int,4),
					new SqlParameter("@iK4", SqlDbType.Int,4),
					new SqlParameter("@iK5", SqlDbType.Int,4),
					new SqlParameter("@iProjectID", SqlDbType.Int,4),
                    new SqlParameter("@rtnID", SqlDbType.Int,4),
					new SqlParameter("@rtnMsg",SqlDbType.NVarChar,500)};
            parameters[0].Value = model.iID;
            parameters[1].Value = model.iJ1;
            parameters[2].Value = model.iJ2;
            parameters[3].Value = model.iJ3;
            parameters[4].Value = model.iJ4;
            parameters[5].Value = model.iJ5;
            parameters[6].Value = model.iH1;
            parameters[7].Value = model.iH2;
            parameters[8].Value = model.iH3;
            parameters[9].Value = model.iH4;
            parameters[10].Value = model.iH5;
            parameters[11].Value = model.iG1;
            parameters[12].Value = model.iG2;
            parameters[13].Value = model.iG3;
            parameters[14].Value = model.iG4;
            parameters[15].Value = model.iG5;
            parameters[16].Value = model.iP1;
            parameters[17].Value = model.iP2;
            parameters[18].Value = model.iP3;
            parameters[19].Value = model.iP4;
            parameters[20].Value = model.iP5;
            parameters[21].Value = model.iK1;
            parameters[22].Value = model.iK2;
            parameters[23].Value = model.iK3;
            parameters[24].Value = model.iK4;
            parameters[25].Value = model.iK5;
            parameters[26].Value = model.iProjectID;
            parameters[27].Direction = ParameterDirection.Output;
            parameters[28].Direction = ParameterDirection.Output;

            DBHelper.RunProcedure("FC_UP_Al_Score_Edit", parameters);
            //处理返回结果
            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[27].Value.ToString());
            rtn.rtnMsg.Append(parameters[28].Value.ToString());
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
            DBHelper.RunProcedure("FC_UP_Al_Score_Delete", parameters);

            funRtn rtn = new funRtn();
            rtn.rtnID = int.Parse(parameters[1].Value.ToString());
            rtn.rtnMsg.Append(parameters[2].Value.ToString());
            return rtn;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_Score GetModel(int iID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@iID", SqlDbType.Int,4)};
            parameters[0].Value = iID;

            XxWapSystem.Model.Al_Score model = new XxWapSystem.Model.Al_Score();
            DataSet ds = DBHelper.RunProcedure("FC_UP_Al_Score_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["iID"].ToString() != "")
                {
                    model.iID = int.Parse(ds.Tables[0].Rows[0]["iID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iJ1"].ToString() != "")
                {
                    model.iJ1 = int.Parse(ds.Tables[0].Rows[0]["iJ1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iJ2"].ToString() != "")
                {
                    model.iJ2 = int.Parse(ds.Tables[0].Rows[0]["iJ2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iJ3"].ToString() != "")
                {
                    model.iJ3 = int.Parse(ds.Tables[0].Rows[0]["iJ3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iJ4"].ToString() != "")
                {
                    model.iJ4 = int.Parse(ds.Tables[0].Rows[0]["iJ4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iJ5"].ToString() != "")
                {
                    model.iJ5 = int.Parse(ds.Tables[0].Rows[0]["iJ5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iH1"].ToString() != "")
                {
                    model.iH1 = int.Parse(ds.Tables[0].Rows[0]["iH1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iH2"].ToString() != "")
                {
                    model.iH2 = int.Parse(ds.Tables[0].Rows[0]["iH2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iH3"].ToString() != "")
                {
                    model.iH3 = int.Parse(ds.Tables[0].Rows[0]["iH3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iH4"].ToString() != "")
                {
                    model.iH4 = int.Parse(ds.Tables[0].Rows[0]["iH4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iH5"].ToString() != "")
                {
                    model.iH5 = int.Parse(ds.Tables[0].Rows[0]["iH5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iG1"].ToString() != "")
                {
                    model.iG1 = int.Parse(ds.Tables[0].Rows[0]["iG1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iG2"].ToString() != "")
                {
                    model.iG2 = int.Parse(ds.Tables[0].Rows[0]["iG2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iG3"].ToString() != "")
                {
                    model.iG3 = int.Parse(ds.Tables[0].Rows[0]["iG3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iG4"].ToString() != "")
                {
                    model.iG4 = int.Parse(ds.Tables[0].Rows[0]["iG4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iG5"].ToString() != "")
                {
                    model.iG5 = int.Parse(ds.Tables[0].Rows[0]["iG5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iP1"].ToString() != "")
                {
                    model.iP1 = int.Parse(ds.Tables[0].Rows[0]["iP1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iP2"].ToString() != "")
                {
                    model.iP2 = int.Parse(ds.Tables[0].Rows[0]["iP2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iP3"].ToString() != "")
                {
                    model.iP3 = int.Parse(ds.Tables[0].Rows[0]["iP3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iP4"].ToString() != "")
                {
                    model.iP4 = int.Parse(ds.Tables[0].Rows[0]["iP4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iP5"].ToString() != "")
                {
                    model.iP5 = int.Parse(ds.Tables[0].Rows[0]["iP5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iK1"].ToString() != "")
                {
                    model.iK1 = int.Parse(ds.Tables[0].Rows[0]["iK1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iK2"].ToString() != "")
                {
                    model.iK2 = int.Parse(ds.Tables[0].Rows[0]["iK2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iK3"].ToString() != "")
                {
                    model.iK3 = int.Parse(ds.Tables[0].Rows[0]["iK3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iK4"].ToString() != "")
                {
                    model.iK4 = int.Parse(ds.Tables[0].Rows[0]["iK4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iK5"].ToString() != "")
                {
                    model.iK5 = int.Parse(ds.Tables[0].Rows[0]["iK5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iProjectID"].ToString() != "")
                {
                    model.iProjectID = int.Parse(ds.Tables[0].Rows[0]["iProjectID"].ToString());
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
            PagerInfo PI = new PagerInfo("Al_Score", strGetFields, "iID", PageSize, PageIndex, bDesc, strFliter);
            PI.DoPager();
            return PI;
        }
        #endregion  Method
    }
}
