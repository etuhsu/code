using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XxWapSystem.DAL;

namespace XxWapSystem.BLL
{
    /// <summary>
    /// 二手房求购业务逻辑类Al_ES_Buy
    /// </summary>
    public class B_ES_Buy
    {
        private static readonly D_ES_Buy dal = new D_ES_Buy();
        public B_ES_Buy() { }

        /// <summary>
        /// 是否存在该二手房求购记录
        /// </summary>
        public bool Exists(int iID)
        {
            return dal.Exists(iID);
        }

        /// <summary>
        /// 增加一条二手房求购数据
        /// </summary>
        public int Add(XxWapSystem.Model.Al_ES_Buy model, string uType, ref int NID, ref string ReMessage)
        {
            return dal.Add(model,1,uType,ref NID,ref ReMessage);
        }

        /// <summary>
        /// 更新一条二手房求购数据
        /// </summary>
        public bool Update(XxWapSystem.Model.Al_ES_Buy model, int AddNum, string uType, ref int NID, ref string ReMessage)
        {
            return dal.Update(model,AddNum,uType,ref NID,ref ReMessage);
        }
        
        /// <summary>
        /// 删除一条二手房求购数据
        /// </summary>
        public bool Delete(string iID, int DelUID, bool RealDel, ref string ReMessage)
        {
            return dal.Delete(iID,DelUID,RealDel,ref ReMessage);
        }

        /// <summary>
        /// 得到一个二手房求购实体
        /// </summary>
        public XxWapSystem.Model.Al_ES_Buy GetModel(int iID)
        {
            return dal.GetModel(iID);
        }

        /// <summary>
        /// 获得二手房求购数据列表
        /// </summary>
        public PagerInfo GetList(string strGetFields,string orderby , int PageSize, int PageIndex, bool bDesc, string strFliter)
        {
            return dal.GetList(strGetFields,orderby, PageSize, PageIndex, bDesc, strFliter);
        }

        /// <summary>
        /// 获得指定页二手房求购数据列表
        /// </summary>
        public DataSet GetListBuyPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere,orderby,startIndex,endIndex);
        }
    }
}
