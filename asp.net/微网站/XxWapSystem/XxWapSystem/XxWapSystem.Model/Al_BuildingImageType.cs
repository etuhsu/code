using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_BuildingImageType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingImageType
    {
        public Al_BuildingImageType()
        { }
        #region Model
        private int _iid;
        private string _ctypename;
        private DateTime _daddtime = DateTime.Now;
        private int _isort = 0;
        private bool _bisaudit;
        private int _iprojectid;
        /// <summary>
        /// 图片分类表
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 图片类型名称
        /// </summary>
        public string cTypeName
        {
            set { _ctypename = value; }
            get { return _ctypename; }
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
        /// 排序
        /// </summary>
        public int iSort
        {
            set { _isort = value; }
            get { return _isort; }
        }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool bIsAudit
        {
            set { _bisaudit = value; }
            get { return _bisaudit; }
        }
        /// <summary>
        /// 楼盘编号 外键 取自于楼盘表
        /// </summary>
        public int iProjectID
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }
        #endregion Model

    }
}


