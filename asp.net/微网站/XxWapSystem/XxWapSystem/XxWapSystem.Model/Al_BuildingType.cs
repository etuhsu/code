using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_BuildingType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingType
    {
        public Al_BuildingType()
        { }
        #region Model
        private int _iid;
        private string _ctypename;
        private DateTime _daddtime;
        /// <summary>
        /// 楼盘分类表  标识符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string cTypeName
        {
            set { _ctypename = value; }
            get { return _ctypename; }
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
