using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_Impression:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_Impression
    {
        public Al_Impression()
        { }
        #region Model
        private int _iid;
        private string _ctext;
        private int _ihit;
        private DateTime _daddtime = DateTime.Now;
        private int _iprojectid;
        /// <summary>
        /// 
        /// </summary>
        public int iId
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 印象内容
        /// </summary>
        public string cText
        {
            set { _ctext = value; }
            get { return _ctext; }
        }
        /// <summary>
        /// 重复数量  
        /// </summary>
        public int iHit
        {
            set { _ihit = value; }
            get { return _ihit; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        /// <summary>
        /// 外键 取自与楼盘表
        /// </summary>
        public int iProjectId
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }
        #endregion Model

    }
}

