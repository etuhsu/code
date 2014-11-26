using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Res.DBUtility;
namespace Res.Library
{
    public class Freight
    {
        public static decimal CalculateAmount(int cty_id, IList<Res.Model.NodeIntObj> nodes, decimal amount)
        {
            int prv_id = 0;
            string sql = " SELECT CTY_PRV_ID FROM RCITY WHERE CTY_ID=@CTY_ID ";
            SqlParameter param = new SqlParameter("@CTY_ID", SqlDbType.Int);
            param.Value = cty_id;
            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, param);
            if (obj != null)
            {
                prv_id = Convert.ToInt32(obj);
            }

            if (prv_id == 1018 || prv_id == 1026 || prv_id == 1034)
            {
                if (amount >= 300.00M)
                {
                    if (prv_id == 1026)
                    {
                        return 0M;
                    }
                    else
                    {
                        return GetAmountType1(nodes) - 5.00M;
                    }
                }
                else
                {
                    return GetAmountType1(nodes);
                }
            }
            else if (prv_id == 1001 || prv_id == 1003 || prv_id == 1025)
            {
                if (amount >= 300.00M)
                {
                    return GetAmountType2(nodes) - 5.00M;
                }
                else
                {
                    return GetAmountType2(nodes);
                }
            }
            else if (prv_id == 1007 || prv_id == 1021 || prv_id == 1022 || prv_id == 1023 || prv_id == 1031 || prv_id == 1032)
            {
                if (amount >= 300.00M)
                {
                    return GetAmountType3(nodes) - 5.00M;
                }
                else
                {
                    return GetAmountType3(nodes);
                }
            }
            else
            {
                if (amount >= 300.00M)
                {
                    return GetAmountType4(nodes) - 5.00M;
                }
                else
                {
                    return GetAmountType4(nodes);
                }
            }
            return 0M;
        }
        /// <summary>
        /// 江浙沪：5元/公斤 不满1公斤算1公斤，比如 0.8公斤算1公斤，1.2公斤算2公斤
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="prd_id"></param>
        /// <returns></returns>
        public static decimal GetAmountType1(IList<Res.Model.NodeIntObj> nodes)
        {
            decimal weight = 0;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                conn.Open();
                foreach (Res.Model.NodeIntObj model in nodes)
                {
                    string sql = "SELECT PRD_WEIGHT FROM BPRODUCT WHERE PRD_ID=@PRD_ID";
                    SqlParameter param = new SqlParameter("@PRD_ID", SqlDbType.Int);
                    param.Value = model.ID;
                    object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, param);

                    if (obj != null && obj != DBNull.Value)
                    {
                        decimal wt = System.Convert.ToDecimal(obj) * model.NAME;
                        weight = weight + wt;
                    }
                }
            }
            int mt;
            if (weight > Math.Truncate(weight))
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight)) + 1;
            }
            else
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight));
            }
            return mt * 5.00M;
        }
        /// <summary>
        /// 安徽，山东，北京：8元/公斤
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="prd_id"></param>
        /// <returns></returns>
        public static decimal GetAmountType2(IList<Res.Model.NodeIntObj> nodes)
        {
            decimal weight = 0;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                conn.Open();
                foreach (Res.Model.NodeIntObj model in nodes)
                {
                    string sql = "SELECT PRD_WEIGHT FROM BPRODUCT WHERE PRD_ID=@PRD_ID";
                    SqlParameter param = new SqlParameter("@PRD_ID", SqlDbType.Int);
                    param.Value = model.ID;
                    object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, param);

                    if (obj != null && obj != DBNull.Value)
                    {
                        decimal wt = System.Convert.ToDecimal(obj) * model.NAME;
                        weight = weight + wt;
                    }
                }
            }
            int mt;
            if (weight > Math.Truncate(weight))
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight)) + 1;
            }
            else
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight));
            }
            return mt * 8.00M;
        }
        /// <summary>
        /// 新疆，西藏，青海，宁夏，内蒙古，甘肃：12元/公斤
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="prd_id"></param>
        /// <returns></returns>
        public static decimal GetAmountType3(IList<Res.Model.NodeIntObj> nodes)
        {
            decimal weight = 0;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                conn.Open();
                foreach (Res.Model.NodeIntObj model in nodes)
                {
                    string sql = "SELECT PRD_WEIGHT FROM BPRODUCT WHERE PRD_ID=@PRD_ID";
                    SqlParameter param = new SqlParameter("@PRD_ID", SqlDbType.Int);
                    param.Value = model.ID;
                    object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, param);

                    if (obj != null && obj != DBNull.Value)
                    {
                        decimal wt = System.Convert.ToDecimal(obj) * model.NAME;
                        weight = weight + wt;
                    }
                }
            }
            int mt;
            if (weight > Math.Truncate(weight))
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight)) + 1;
            }
            else
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight));
            }
            return mt * 12.00M;
        }
        /// <summary>
        /// 其他地区：10元/公斤
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="prd_id"></param>
        /// <returns></returns>
        public static decimal GetAmountType4(IList<Res.Model.NodeIntObj> nodes)
        {
            decimal weight = 0;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
            {
                conn.Open();
                foreach (Res.Model.NodeIntObj model in nodes)
                {
                    string sql = "SELECT PRD_WEIGHT FROM BPRODUCT WHERE PRD_ID=@PRD_ID";
                    SqlParameter param = new SqlParameter("@PRD_ID", SqlDbType.Int);
                    param.Value = model.ID;
                    object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, param);

                    if (obj != null && obj != DBNull.Value)
                    {
                        decimal wt = System.Convert.ToDecimal(obj) * model.NAME;
                        weight = weight + wt;
                    }
                }
            }
            int mt;
            if (weight > Math.Truncate(weight))
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight)) + 1;
            }
            else
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight));
            }
            return mt * 10.00M;
        }
        
        /// <summary>
        /// 根据重量和金额计算运费
        /// </summary>
        /// <param name="cty_id"></param>
        /// <param name="weight"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public static decimal CalculateAmountByWeight(int cty_id, decimal weight, decimal amount)
        {
            int prv_id = 0;
            string sql = " SELECT CTY_PRV_ID FROM RCITY WHERE CTY_ID=@CTY_ID ";
            SqlParameter param = new SqlParameter("@CTY_ID", SqlDbType.Int);
            param.Value = cty_id;
            object obj = SqlHelper.ExecuteScalar(SqlHelper.ConnectionString, CommandType.Text, sql, param);
            if (obj != null)
            {
                prv_id = Convert.ToInt32(obj);
            }

            int mt;
            if (weight > Math.Truncate(weight))
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight)) + 1;
            }
            else
            {
                mt = System.Convert.ToInt32(Math.Truncate(weight));
            }

            if (prv_id == 1018 || prv_id == 1026 || prv_id == 1034)
            {
                if (amount >= 300.00M)
                {
                    if (prv_id == 1026)
                    {
                        return 0M;
                    }
                    else
                    {
                        return mt * 5.00M - 5.00M;
                    }
                }
                else
                {
                    return mt * 5.00M;
                }
            }
            else if (prv_id == 1001 || prv_id == 1003 || prv_id == 1025)
            {
                if (amount >= 300.00M)
                {
                    return mt * 8.00M - 5.00M;
                }
                else
                {
                    return mt * 8.00M;
                }
            }
            else if (prv_id == 1007 || prv_id == 1021 || prv_id == 1022 || prv_id == 1023 || prv_id == 1031 || prv_id == 1032)
            {
                if (amount >= 300.00M)
                {
                    return mt * 12.00M-5.00M;
                }
                else
                {
                    return mt * 12.00M;
                }
            }
            else
            {
                if (amount >= 300.00M)
                {
                    return mt * 10.00M - 5.00M;
                }
                else
                {
                    return mt * 10.00M;
                }
            }
            return 0M;
        }
    }
}
