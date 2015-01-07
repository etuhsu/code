using System;
using System.Collections.Generic;
using System.Text;
using Res.IDAL;
using Res.DAL;
using Res.DALFactory;
using Res.Model;

namespace Res.BLL
{
    public class PointBLL
    {
        private readonly IPoint dal = PointDataAccess.CreatePoint();
        /// <summary>
        /// 查询赠品所需积分
        /// </summary>
        /// <param name="gifId"></param>
        /// <returns></returns>
        public System.Data.SqlClient.SqlDataReader GetPointById(int gifId)
        {
            return dal.GetPointById(gifId);
        }
        /// <summary>
        /// 修改积分
        /// </summary>
        /// <param name="pspId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public int UpdatePoint(int pspId, int point)
        {
            return dal.UpdatePoint(pspId, point);
        }
        /// <summary>
        /// 添加积分记录
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="model"></param>
        /// <param name="hptId"></param>
        /// <returns></returns>
        public int AddHPoint(System.Data.SqlClient.SqlTransaction trans, HPointObj model, out int hptId)
        {
            return dal.AddHPoint(trans,model, out hptId);
        }
        /// <summary>
        /// 修改积分
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="pspId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public int UpdatePoint(System.Data.SqlClient.SqlTransaction trans, int pspId, int point)
        {
            return dal.UpdatePoint(trans, pspId, point);
        }
        /// <summary>
        /// 添加积分记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hptId"></param>
        /// <returns></returns>
        public int AddHPoint(HPointObj model, out int hptId)
        {
            return dal.AddHPoint(model, out hptId);
        }
        /// <summary>
        /// 分页查询积分规则
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNO"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string ListPointRule(int pageSize, int pageNO, string strWhere)
        {
            return dal.ListPointRule(pageSize, pageNO, strWhere);
        }
    }
}
