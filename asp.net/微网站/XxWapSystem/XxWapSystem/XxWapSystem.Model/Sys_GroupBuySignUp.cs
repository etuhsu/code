using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{

    /// <summary>
    /// Sys_GroupBuySignUp:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_GroupBuySignUp
    {
        public Sys_GroupBuySignUp()
        { }
        #region Model
        private int _iid;
        private int _iuserid;
        private string _cmobile;
        private string _ccredentials;
        private DateTime _daddtime;
        private int _igroupbuyid;
        private bool _bisaudit = false;
        private string _cname;
        private string _chousearea;
        private string _cxqname;
        private bool _bisshenhe = false;
        /// <summary>
        /// 团购报名表 流水号 标识符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int iUserID
        {
            set { _iuserid = value; }
            get { return _iuserid; }
        }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string cMobile
        {
            set { _cmobile = value; }
            get { return _cmobile; }
        }
        /// <summary>
        /// 凭证编号
        /// </summary>
        public string cCredentials
        {
            set { _ccredentials = value; }
            get { return _ccredentials; }
        }
        /// <summary>
        /// 团购报名时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        /// <summary>
        /// 团购信息编号 外键
        /// </summary>
        public int iGroupBuyID
        {
            set { _igroupbuyid = value; }
            get { return _igroupbuyid; }
        }
        /// <summary>
        /// 标记是否已用
        /// </summary>
        public bool bIsAudit
        {
            set { _bisaudit = value; }
            get { return _bisaudit; }
        }

        /// <summary>
        /// 团购人名称
        /// </summary>
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }

        /// <summary>
        /// 房屋面积
        /// </summary>
        public string cHouseArea
        {
            set { _chousearea = value; }
            get { return _chousearea; }
        }

        /// <summary>
        /// 小区名称
        /// </summary>
        public string cXqName
        {
            set { _cxqname = value; }
            get { return _cxqname; }
        }
        /// <summary>
        /// 报名信息是否审核
        /// </summary>
        public bool bIsShenhe
        {
            set { _bisshenhe = value; }
            get { return _bisshenhe; }
        }

        #endregion Model

    }
}
