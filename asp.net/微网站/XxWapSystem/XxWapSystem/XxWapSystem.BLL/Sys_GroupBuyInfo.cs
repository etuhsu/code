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
    /// Sys_GroupBuyInfo
    /// </summary>
    public class Sys_GroupBuyInfo
    {
        private readonly XxWapSystem.DAL.Sys_GroupBuyInfo dal = new XxWapSystem.DAL.Sys_GroupBuyInfo();
        public Sys_GroupBuyInfo()
        { }
        #region  Method
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
        public funRtn Add(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新是否推荐
        /// </summary>
        public int Update_Recommended(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            XxWapSystem.DAL.Sys_GroupBuyInfo update = new XxWapSystem.DAL.Sys_GroupBuyInfo();
            return update.Update_Recommended(model);
        }

        /// <summary>
        /// 更新是否审核
        /// </summary>
        public int Update_Audit(XxWapSystem.Model.Sys_GroupBuyInfo model)
        {
            XxWapSystem.DAL.Sys_GroupBuyInfo update = new XxWapSystem.DAL.Sys_GroupBuyInfo();
            return update.Update_Audit(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public funRtn Delete(int iID)
        {
            return dal.Delete(iID);
        }

        /// <summary>
        /// 删除该团购下的所有报名
        /// </summary>
        public int Delete_GroupSignUp(int iGroupID)
        {
            return dal.Delete_GroupSignUp(iGroupID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Sys_GroupBuyInfo GetModel(int iID)
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
        #endregion  Method
    }
}
