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
        /// ��ѯ��Ʒ�������
        /// </summary>
        /// <param name="gifId"></param>
        /// <returns></returns>
        public System.Data.SqlClient.SqlDataReader GetPointById(int gifId)
        {
            return dal.GetPointById(gifId);
        }
        /// <summary>
        /// �޸Ļ���
        /// </summary>
        /// <param name="pspId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public int UpdatePoint(int pspId, int point)
        {
            return dal.UpdatePoint(pspId, point);
        }
        /// <summary>
        /// ��ӻ��ּ�¼
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
        /// �޸Ļ���
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
        /// ��ӻ��ּ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hptId"></param>
        /// <returns></returns>
        public int AddHPoint(HPointObj model, out int hptId)
        {
            return dal.AddHPoint(model, out hptId);
        }
        /// <summary>
        /// ��ҳ��ѯ���ֹ���
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
