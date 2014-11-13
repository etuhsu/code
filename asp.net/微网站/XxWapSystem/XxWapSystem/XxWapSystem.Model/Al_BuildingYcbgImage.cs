using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{

    /// <summary>
    /// Al_BuildingYcbgImage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingYcbgImage
    {
        public Al_BuildingYcbgImage()
        { }
        #region Model
        private int _iid;
        private string _ctitle;
        private string _cimgaddress;
        private string _cthumbnail;
        private DateTime _daddtime;
        private bool _bisaudit;
        private int _ibid;
        private int _ipaixu;
        /// <summary>
        /// 流水号
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string cTitle
        {
            set { _ctitle = value; }
            get { return _ctitle; }
        }
        /// <summary>
        /// 原图地址
        /// </summary>
        public string cImgAddress
        {
            set { _cimgaddress = value; }
            get { return _cimgaddress; }
        }
        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string cThumbnail
        {
            set { _cthumbnail = value; }
            get { return _cthumbnail; }
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
        /// 是否审核
        /// </summary>
        public bool bIsAudit
        {
            set { _bisaudit = value; }
            get { return _bisaudit; }
        }
        /// <summary>
        /// 楼盘栋编号  （外键） 取自于楼盘栋信息表
        /// </summary>
        public int iBid
        {
            set { _ibid = value; }
            get { return _ibid; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int iPaixu
        {
            set { _ipaixu = value; }
            get { return _ipaixu; }
        }
        #endregion Model

    }
}
