using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_BuildingYsxkz:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingYsxkz
    {
        public Al_BuildingYsxkz()
        { }
        #region Model
        private int _iid;
        private string _cysxkznum;
        private string _cysxkzimage;
        private string _cysxkzthumbnail;
        private DateTime _dissuedate;
        private string _cpaixu;
        private bool _bisaudit;
        private int _iprojectid;
        private int _ibid;
        private DateTime _daddtime;
        /// <summary>
        /// 预售许可证编号  流水号
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 预售许可证编号
        /// </summary>
        public string cYsxkzNum
        {
            set { _cysxkznum = value; }
            get { return _cysxkznum; }
        }
        /// <summary>
        /// 预售许可证图片
        /// </summary>
        public string cYsxkzImage
        {
            set { _cysxkzimage = value; }
            get { return _cysxkzimage; }
        }
        /// <summary>
        /// 预售许可证缩略图
        /// </summary>
        public string cYsxkzThumbnail
        {
            set { _cysxkzthumbnail = value; }
            get { return _cysxkzthumbnail; }
        }
        /// <summary>
        /// 颁发日期
        /// </summary>
        public DateTime dIssueDate
        {
            set { _dissuedate = value; }
            get { return _dissuedate; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public string cPaixu
        {
            set { _cpaixu = value; }
            get { return _cpaixu; }
        }
        /// <summary>
        /// 是否审核通过
        /// </summary>
        public bool bIsAudit
        {
            set { _bisaudit = value; }
            get { return _bisaudit; }
        }
        /// <summary>
        /// 楼盘编号  外键
        /// </summary>
        public int iProjectID
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }
        /// <summary>
        /// 楼盘栋信息编号  外键
        /// </summary>
        public int iBid
        {
            set { _ibid = value; }
            get { return _ibid; }
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

