using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Sys_GroupBuyInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_GroupBuyInfo
    {
        public Sys_GroupBuyInfo()
        { }
        #region Model
        private int _iid;
        private string _ctitle;
        private string _cproductname;
        private string _cname;
        private string _cgroupbuyingaddress;
        private DateTime _cgroupbuyingstarttime;
        private DateTime _cgroupbuyingendtime;
        private string _coldprice;
        private string _cpricedw;
        private string _cnewprice;
        private string _igroupbuyingminperson;
        private string _igroupbuyingmaxperson;
        private string _ctitleimg;
        private string _ctitleimgthumbnail;
        private string _cgroupinfo;
        private string _cintroduce;
        private bool _bisaudit;
        private bool _bisrecommended;
        private DateTime _daddtime;
        private string _cgroupbuylinkman;
        private string _cgroupbuyphone;
        private string _cgroupbuysmscontent;

        private string _cfolderpath;
        private string _cfilename;
        private string _cfileextend;
        private string _ctemplatepath;
        /// <summary>
        /// 团购信息表  流水号 标识符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 团购信息标题
        /// </summary>
        public string cTitle
        {
            set { _ctitle = value; }
            get { return _ctitle; }
        }
        /// <summary>
        /// 团购商品名称
        /// </summary>
        public string cProductName
        {
            set { _cproductname = value; }
            get { return _cproductname; }
        }
        /// <summary>
        /// 发布人编号
        /// </summary>
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 团购地点
        /// </summary>
        public string cGroupBuyingAddress
        {
            set { _cgroupbuyingaddress = value; }
            get { return _cgroupbuyingaddress; }
        }
        /// <summary>
        /// 团购开始时间
        /// </summary>
        public DateTime cGroupBuyingStartTime
        {
            set { _cgroupbuyingstarttime = value; }
            get { return _cgroupbuyingstarttime; }
        }
        /// <summary>
        /// 团购截止时间
        /// </summary>
        public DateTime cGroupBuyingEndTime
        {
            set { _cgroupbuyingendtime = value; }
            get { return _cgroupbuyingendtime; }
        }
        /// <summary>
        /// 团购原始价格
        /// </summary>
        public string cOldPrice
        {
            set { _coldprice = value; }
            get { return _coldprice; }
        }
        /// <summary>
        /// 价格单位
        /// </summary>
        public string cPriceDw
        {
            set { _cpricedw = value; }
            get { return _cpricedw; }
        }
        /// <summary>
        /// 团购折扣价格
        /// </summary>
        public string cNewPrice
        {
            set { _cnewprice = value; }
            get { return _cnewprice; }
        }
        /// <summary>
        /// 团购最低要求人数
        /// </summary>
        public string iGroupBuyingMinPerson
        {
            set { _igroupbuyingminperson = value; }
            get { return _igroupbuyingminperson; }
        }
        /// <summary>
        /// 团购最高人数
        /// </summary>
        public string iGroupBuyingMaxPerson
        {
            set { _igroupbuyingmaxperson = value; }
            get { return _igroupbuyingmaxperson; }
        }
        /// <summary>
        /// 团购图片标题
        /// </summary>
        public string cTitleImg
        {
            set { _ctitleimg = value; }
            get { return _ctitleimg; }
        }
        /// <summary>
        /// 团购图片缩略图
        /// </summary>
        public string cTitleImgThumbnail
        {
            set { _ctitleimgthumbnail = value; }
            get { return _ctitleimgthumbnail; }
        }
        /// <summary>
        /// 团购简介
        /// </summary>
        public string cGroupInfo
        {
            set { _cgroupinfo = value; }
            get { return _cgroupinfo; }
        }
        /// <summary>
        /// 团购介绍
        /// </summary>
        public string cIntroduce
        {
            set { _cintroduce = value; }
            get { return _cintroduce; }
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
        /// 
        /// </summary>
        public bool bIsRecommended
        {
            set { _bisrecommended = value; }
            get { return _bisrecommended; }
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
        /// 团购联系人
        /// </summary>
        public string cGroupBuyLinkman
        {
            set { _cgroupbuylinkman = value; }
            get { return _cgroupbuylinkman; }
        }
        /// <summary>
        /// 团购热线
        /// </summary>
        public string cGroupBuyPhone
        {
            set { _cgroupbuyphone = value; }
            get { return _cgroupbuyphone; }
        }
        /// <summary>
        /// 团购成功后发送短信内容
        /// </summary>
        public string cGroupBuySmsContent
        {
            set { _cgroupbuysmscontent = value; }
            get { return _cgroupbuysmscontent; }
        }

        /// <summary>
        /// 文件夹路径
        /// </summary>
        public string cFolderPath
        {
            set { _cfolderpath = value; }
            get { return _cfolderpath; }
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string cFileName
        {
            set { _cfilename = value; }
            get { return _cfilename; }
        }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string cFileExtend
        {
            set { _cfileextend = value; }
            get { return _cfileextend; }
        }
        /// <summary>
        /// 团购专题模板路径
        /// </summary>
        public string cTemplatePath
        {
            set { _ctemplatepath = value; }
            get { return _ctemplatepath; }
        }
        #endregion Model
    }
}
