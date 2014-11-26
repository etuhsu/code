using System;
using System.Collections.Generic;
using System.Text;
using Res.Model;

namespace Res.IDAL
{
    /// <summary>
    /// 积分
    /// </summary>
    public interface IPoint
    {
        /// <summary>
        /// 查询赠品所需积分
        /// </summary>
        /// <param name="gifId"></param>
        /// <returns></returns>
        System.Data.SqlClient.SqlDataReader GetPointById(int gifId);
        /// <summary>
        /// 修改积分
        /// </summary>
        /// <param name="pspId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        int UpdatePoint(int pspId, int point);
        /// <summary>
        /// 添加积分记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hptId"></param>
        /// <returns></returns>
        int AddHPoint(HPointObj model, out int hptId);
        /// <summary>
        /// 修改积分
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="pspId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        int UpdatePoint(System.Data.SqlClient.SqlTransaction trans, int pspId, int point);
        /// <summary>
        /// 添加积分记录
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="model"></param>
        /// <param name="hptId"></param>
        /// <returns></returns>
        int AddHPoint(System.Data.SqlClient.SqlTransaction trans, HPointObj model, out int hptId);
        /// <summary>
        /// 分页查询积分规则
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNO"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        string ListPointRule(int pageSize, int pageNO, string strWhere);
    }
}
