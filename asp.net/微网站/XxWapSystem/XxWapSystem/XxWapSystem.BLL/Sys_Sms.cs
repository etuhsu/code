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
    /// Sys_Sms
    /// </summary>
    public partial class Sys_Sms
    {
        private readonly XxWapSystem.DAL.Sys_Sms dal = new XxWapSystem.DAL.Sys_Sms();
        public Sys_Sms()
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
        public funRtn Add(XxWapSystem.Model.Sys_Sms model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public funRtn Update(XxWapSystem.Model.Sys_Sms model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据--不包含密码
        /// </summary>
        public funRtn Update_NoPass(XxWapSystem.Model.Sys_Sms model)
        {
            return dal.Update_NoPass(model);
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        public funRtn Update_Pass(XxWapSystem.Model.Sys_Sms model)
        {
            return dal.Update_Pass(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XxWapSystem.Model.Sys_Sms GetModel(int iID)
        {

            return dal.GetModel(iID);
        }

        #endregion  Method
    }
}
