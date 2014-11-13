using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Sys_Sms:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_Sms
    {
        public Sys_Sms()
        { }
        #region Model
        private int _iid;
        private string _cname;
        private string _cpassword;
        private string _curl;
        private bool _bisopen;
        /// <summary>
        /// 短信帐号编号
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 帐号用户名
        /// </summary>
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 帐号密码
        /// </summary>
        public string cPassWord
        {
            set { _cpassword = value; }
            get { return _cpassword; }
        }
        /// <summary>
        /// 帐号post地址
        /// </summary>
        public string cUrl
        {
            set { _curl = value; }
            get { return _curl; }
        }
        /// <summary>
        /// 是否启用   0为关闭  1为开启
        /// </summary>
        public bool bIsOpen
        {
            set { _bisopen = value; }
            get { return _bisopen; }
        }
        #endregion Model

    }
}
