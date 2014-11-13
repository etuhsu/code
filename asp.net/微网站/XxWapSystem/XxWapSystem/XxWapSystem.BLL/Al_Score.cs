using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XxWapSystem.DAL;

namespace XxWapSystem.BLL
{
    /// <summary>
    /// 业务逻辑类Al_Score 的摘要说明。
    /// </summary>
    public class Al_Score
    {
        private static readonly XxWapSystem.DAL.Al_Score dal = new XxWapSystem.DAL.Al_Score();
        public Al_Score() { }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iID)
        {
            return dal.Exists(iID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public funRtn Add(XxWapSystem.Model.Al_Score model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Al_Score model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public funRtn Delete(int iID)
        {
            return dal.Delete(iID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Al_Score GetModel(int iID)
        {
            return dal.GetModel(iID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public PagerInfo GetList(string strGetFields, int PageSize, int PageIndex, bool bDesc, string strFliter)
        {
            return dal.GetList(strGetFields, PageSize, PageIndex, bDesc, strFliter);
        }
    }
}
