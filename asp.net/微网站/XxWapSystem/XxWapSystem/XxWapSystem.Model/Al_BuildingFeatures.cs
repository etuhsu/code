using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_BuildingFeatures:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingFeatures
    {
        public Al_BuildingFeatures()
        { }
        #region Model
        private int _iid;
        private string _cchname;
        private DateTime _daddtime;
        /// <summary>
        /// 楼盘特色表 流水号  标识符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 特色名称
        /// </summary>
        public string cChName
        {
            set { _cchname = value; }
            get { return _cchname; }
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
