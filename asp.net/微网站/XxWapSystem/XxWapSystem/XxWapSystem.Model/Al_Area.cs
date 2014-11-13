using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_Area:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_Area
    {
        public Al_Area()
        { }
        #region Model
        private int _iid;
        private string _careaname;
        private DateTime _daddtime;
        private int _isort;
        /// <summary>
        /// 地区表， 流水号 标识符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string cAreaName
        {
            set { _careaname = value; }
            get { return _careaname; }
        }
        /// <summary>
        /// 记录添加时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int iSort
        {
            set { _isort = value; }
            get { return _isort; }
        }
        #endregion Model

    }
}
