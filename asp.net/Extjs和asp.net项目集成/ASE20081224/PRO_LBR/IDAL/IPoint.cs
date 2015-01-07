using System;
using System.Collections.Generic;
using System.Text;
using Res.Model;

namespace Res.IDAL
{
    /// <summary>
    /// ����
    /// </summary>
    public interface IPoint
    {
        /// <summary>
        /// ��ѯ��Ʒ�������
        /// </summary>
        /// <param name="gifId"></param>
        /// <returns></returns>
        System.Data.SqlClient.SqlDataReader GetPointById(int gifId);
        /// <summary>
        /// �޸Ļ���
        /// </summary>
        /// <param name="pspId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        int UpdatePoint(int pspId, int point);
        /// <summary>
        /// ��ӻ��ּ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="hptId"></param>
        /// <returns></returns>
        int AddHPoint(HPointObj model, out int hptId);
        /// <summary>
        /// �޸Ļ���
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="pspId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        int UpdatePoint(System.Data.SqlClient.SqlTransaction trans, int pspId, int point);
        /// <summary>
        /// ��ӻ��ּ�¼
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="model"></param>
        /// <param name="hptId"></param>
        /// <returns></returns>
        int AddHPoint(System.Data.SqlClient.SqlTransaction trans, HPointObj model, out int hptId);
        /// <summary>
        /// ��ҳ��ѯ���ֹ���
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNO"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        string ListPointRule(int pageSize, int pageNO, string strWhere);
    }
}
