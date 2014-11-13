using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using XxWapSystem.DAL;

namespace XxWapSystem.BLL
{
    /// <summary>
    /// 二手房求租业务逻辑类Al_ES_Lease
    /// </summary>
    public class B_ES_Lease
    {
        private static readonly XxWapSystem.DAL.D_ES_Lease dal = new XxWapSystem.DAL.D_ES_Lease();
        public B_ES_Lease() { }

        /// <summary>
        /// 是否存在该二手房求租记录
        /// </summary>
        /// <param name="iID">返回的新增ID</param>
        /// <returns>是否存在</returns>
        public bool Exists(int iID)
        {
            return dal.Exists(iID);
        }

        /// <summary>
        /// 增加一条二手房求租数据
        /// </summary>
        /// <param name="model">求租实体</param>
        /// <param name="uType">用户类别:普通用户、高级用户、经纪人用户、企业用户</param>
        /// <param name="NID">返回的新增ID</param>
        /// <param name="ReMessage">操作反馈信息</param>
        /// <returns></returns>
        public int Add(XxWapSystem.Model.Al_ES_Lease model, string uType, ref int NID, ref string ReMessage)
        {
            return dal.Add(model,1,uType,ref NID,ref ReMessage);
        }

        /// <summary>
        /// 更新一条二手房求租数据
        /// </summary>
        /// <param name="model">求租实体</param>
        /// <param name="AddNum">更新数量</param>
        /// <param name="uType">用户类别</param>
        /// <param name="NID">返回的新增ID</param>
        /// <param name="ReMessage">操作反馈信息</param>
        /// <returns></returns>
        public bool Update(XxWapSystem.Model.Al_ES_Lease model, int AddNum, string uType, ref int NID, ref string ReMessage)
        {
            return dal.Update(model,AddNum,uType,ref NID,ref ReMessage);
        }
        
        /// <summary>
        /// 删除一条二手房求租数据
        /// </summary>
        /// <param name="iID">信息ID</param>
        /// <param name="DelUID">操作用户ID</param>
        /// <param name="RealDel">true:物理删除 false:标记删除</param>
        /// <param name="ReMessage">操作反馈信息</param>
        /// <returns></returns>
        public bool Delete(string iID,int DelUID,bool RealDel,ref string ReMessage)
        {
            return dal.Delete(iID,DelUID,RealDel,ref ReMessage);
        }

        /// <summary>
        /// 得到一个二手房求租实体
        /// </summary>
        /// <param name="iID">信息ID</param>
        /// <returns></returns>
        public XxWapSystem.Model.Al_ES_Lease GetModel(int iID)
        {
            return dal.GetModel(iID);
        }

        /// <summary>
        /// 获得二手房求租数据列表
        /// </summary>
        /// <param name="strGetFields"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="bDesc"></param>
        /// <param name="strFliter"></param>
        /// <returns></returns>
        public PagerInfo GetList(string strGetFields, string orderby, int PageSize, int PageIndex, bool bDesc, string strFliter)
        {
            return dal.GetList(strGetFields, orderby, PageSize, PageIndex, bDesc, strFliter);
        }
    }
}
