using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_BuildingImage:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingImage
    {
        public Al_BuildingImage()
        { }
        #region Model
        private int _iid;
        private string _ctitle;
        private string _cimgaddress;
        private string _cthumbnail;
        private int _itypeid;
        private DateTime _daddtime = DateTime.Now;
        private bool _bisaudit = false;
        private string _daudittime;
        private int _iprojectid;
        private int _ipaixu;
        private int _iallpaixu;
        private bool _bisrecommend;
        /// <summary>
        /// 楼盘图片表 流水号
        /// </summary>
        public int iId
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
        /// 图片地址
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
        /// 图片类型（效果图、位置图、社区实景图、户型图、规划图） 外键 取自图片分类表
        /// </summary>
        public int iTypeID
        {
            set { _itypeid = value; }
            get { return _itypeid; }
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
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
        /// 审核时间
        /// </summary>
        public string dAuditTime
        {
            set { _daudittime = value; }
            get { return _daudittime; }
        }
        /// <summary>
        /// 外键 楼盘id
        /// </summary>
        public int iProjectID
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }
        /// <summary>
        /// 分类排序
        /// </summary>
        public int iPaixu
        {
            set { _ipaixu = value; }
            get { return _ipaixu; }
        }
        /// <summary>
        /// 总排序
        /// </summary>
        public int iAllPaixu
        {
            set { _iallpaixu = value; }
            get { return _iallpaixu; }
        }
        /// <summary>
        /// 是否设为推荐楼盘 0为普通 1为推荐
        /// </summary>
        public bool bIsRecommend
        {
            set { _bisrecommend = value; }
            get { return _bisrecommend; }
        }
        #endregion Model

    }
}

