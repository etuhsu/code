using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类TotalInfoBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class TotalInfoBean
    {
        public TotalInfoBean()
        { }
        #region Model
        private int _totalid;
        private string _totaltype;
        private decimal _totalmoney;
        private DateTime? _totaltime;
        private string _totalremark;
        /// <summary>
        /// 
        /// </summary>
        public int totalID
        {
            set { _totalid = value; }
            get { return _totalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string totalType
        {
            set { _totaltype = value; }
            get { return _totaltype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal totalMoney
        {
            set { _totalmoney = value; }
            get { return _totalmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? totalTime
        {
            set { _totaltime = value; }
            get { return _totaltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string totalRemark
        {
            set { _totalremark = value; }
            get { return _totalremark; }
        }
        #endregion Model

    }
}
