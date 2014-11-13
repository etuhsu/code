using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Sys_WebPage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_WebPage
    {
        public Sys_WebPage()
        { }
        #region Model
        private int _iid;
        private string _ctitle;
        private string _ccontent;
        private int _ihits;
        private DateTime _daddtime;
        private DateTime _dupdatetime;

        /// <summary>
        /// 单页流水号  标示符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 单页标题
        /// </summary>
        public string cTitle
        {
            set { _ctitle = value; }
            get { return _ctitle; }
        }
        /// <summary>
        /// 单页内容
        /// </summary>
        public string cContent
        {
            set { _ccontent = value; }
            get { return _ccontent; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int iHits
        {
            set { _ihits = value; }
            get { return _ihits; }
        }
        /// <summary>
        /// 单页添加时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime dUpdateTime
        {
            set { _dupdatetime = value; }
            get { return _dupdatetime; }
        }
        #endregion Model

    }
}
