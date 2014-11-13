using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Sys_SmsSend:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_SmsSend
    {
        public Sys_SmsSend()
        { }
        #region Model
        private int _iid;
        private string _cusername;
        private string _cmobile;
        private string _cmsg;
        private string _bissend;
        private string _cwhy;
        private DateTime _dsendtime;
        private DateTime _daddtime;
        /// <summary>
        /// 已发送短信编号  流水号
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 发送人名称
        /// </summary>
        public string cUserName
        {
            set { _cusername = value; }
            get { return _cusername; }
        }
        /// <summary>
        /// 发送手机号码
        /// </summary>
        public string cMobile
        {
            set { _cmobile = value; }
            get { return _cmobile; }
        }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string cMsg
        {
            set { _cmsg = value; }
            get { return _cmsg; }
        }
        /// <summary>
        /// 标记是否发送成功   0标记等待发送短信  1标记为发送成功短信  -1标记为发送失败短信
        /// </summary>
        public string bIsSend
        {
            set { _bissend = value; }
            get { return _bissend; }
        }
        /// <summary>
        /// 发送失败原因
        /// </summary>
        public string cWhy
        {
            set { _cwhy = value; }
            get { return _cwhy; }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime dSendTime
        {
            set { _dsendtime = value; }
            get { return _dsendtime; }
        }
        /// <summary>
        /// 记录添加时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        #endregion Model

    }
}
