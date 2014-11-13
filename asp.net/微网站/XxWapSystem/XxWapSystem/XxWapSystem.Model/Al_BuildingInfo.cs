using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_BuildingInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingInfo
    {
        public Al_BuildingInfo()
        { }
        #region Model
        private int _iid;
        private string _cprojectname;
        private string _cimageaddress;
        private string _cthumbnail;
        private string _cproinfo;
        private string _caddress;
        private string _cbuildingtype;
        private string _cdoorarea;
        private string _cdevelopers;
        private string _cdesignunit;
        private string _cconstructionunit;
        private string _cpromanunit;
        private string _csalesaddress;
        private string _csalesphone;
        private string _ctelephone;
        private string _cpaymenttype;
        private string _cpropertyprice;
        private string _czzdmj;
        private string _czghjzmj;
        private string _cvolumerate;
        private string _ccovered;
        private string _chousenum;
        private string _cplanningzonghushu;
        private string _ctotalinvestment;
        private string _cgytdsyqz;
        private string _cjsgcghxkz;
        private string _cjsydghxkz;
        private string _cjsgcsgxkz;
        private string _cpropertyyears;
        private string _cpropertytypes;
        private DateTime _dstartingtime;
        private DateTime _dcompletiontime;
        private string _cstandard;
        private string _cperipheral;
        private string _cinternalsupporting;
        private string _csurroundingcommercial;
        private string _csurroundinglandscape;
        private string _csurroundingpark;
        private string _cperipheralhospital;
        private string _cperipheralschool;
        private string _csurroundingtraffic;
        private string _cdecorateinfo;
        private string _cintelligentfacilities;
        private string _cssjwh;
        private string _cmap;
        private string _bisaudit;
        private int _ihits;
        private bool _bisrecommend;
        private int _iareaid;
        private int _ichannelid;
        private string _cbuildingfeatures;
        private string _chousetype;
        private string _copeningtime;
        private DateTime _daddtime = DateTime.Now;
        private string _czhuangtai;
        private string _ccommentinfo;
        private string _cvideoaddress;
        private string _ccmpx;
        private string _ccmpy;
        private string _careaimage;
        private string _cbuildpinying;
        private string _cmaplng;
        private string _cmaplat;
        /// <summary>
        /// 楼盘信息表  标识符类型  流水号
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 楼盘名称
        /// </summary>
        public string cProjectName
        {
            set { _cprojectname = value; }
            get { return _cprojectname; }
        }
        /// <summary>
        /// 楼盘图片
        /// </summary>
        public string cImageAddress
        {
            set { _cimageaddress = value; }
            get { return _cimageaddress; }
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
        /// 楼盘介绍
        /// </summary>
        public string cProInfo
        {
            set { _cproinfo = value; }
            get { return _cproinfo; }
        }
        /// <summary>
        /// 楼盘地址
        /// </summary>
        public string cAddress
        {
            set { _caddress = value; }
            get { return _caddress; }
        }
        /// <summary>
        /// 建筑类型
        /// </summary>
        public string cBuildingType
        {
            set { _cbuildingtype = value; }
            get { return _cbuildingtype; }
        }
        /// <summary>
        /// 户型面积
        /// </summary>
        public string cDoorArea
        {
            set { _cdoorarea = value; }
            get { return _cdoorarea; }
        }
        /// <summary>
        /// 开发商名称
        /// </summary>
        public string cDevelopers
        {
            set { _cdevelopers = value; }
            get { return _cdevelopers; }
        }
        /// <summary>
        /// 设计单位
        /// </summary>
        public string cDesignUnit
        {
            set { _cdesignunit = value; }
            get { return _cdesignunit; }
        }
        /// <summary>
        /// 承建单位
        /// </summary>
        public string cConstructionUnit
        {
            set { _cconstructionunit = value; }
            get { return _cconstructionunit; }
        }
        /// <summary>
        /// 物业管理单位
        /// </summary>
        public string cProManUnit
        {
            set { _cpromanunit = value; }
            get { return _cpromanunit; }
        }
        /// <summary>
        /// 销售地址
        /// </summary>
        public string cSalesAddress
        {
            set { _csalesaddress = value; }
            get { return _csalesaddress; }
        }
        /// <summary>
        /// 销售电话
        /// </summary>
        public string cSalesPhone
        {
            set { _csalesphone = value; }
            get { return _csalesphone; }
        }
        /// <summary>
        /// 咨询电话   
        /// </summary>
        public string cTelephone
        {
            set { _ctelephone = value; }
            get { return _ctelephone; }
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string cPaymentType
        {
            set { _cpaymenttype = value; }
            get { return _cpaymenttype; }
        }
        /// <summary>
        /// 物业费
        /// </summary>
        public string cPropertyPrice
        {
            set { _cpropertyprice = value; }
            get { return _cpropertyprice; }
        }
        /// <summary>
        /// 总占地面积
        /// </summary>
        public string cZzdmj
        {
            set { _czzdmj = value; }
            get { return _czzdmj; }
        }
        /// <summary>
        /// 总规划建筑面积
        /// </summary>
        public string cZghjzmj
        {
            set { _czghjzmj = value; }
            get { return _czghjzmj; }
        }
        /// <summary>
        /// 容积率
        /// </summary>
        public string cVolumeRate
        {
            set { _cvolumerate = value; }
            get { return _cvolumerate; }
        }
        /// <summary>
        /// 绿化率
        /// </summary>
        public string cCovered
        {
            set { _ccovered = value; }
            get { return _ccovered; }
        }
        /// <summary>
        /// 总栋数
        /// </summary>
        public string cHouseNum
        {
            set { _chousenum = value; }
            get { return _chousenum; }
        }
        /// <summary>
        /// 规划总户数
        /// </summary>
        public string cPlanningZongHuShu
        {
            set { _cplanningzonghushu = value; }
            get { return _cplanningzonghushu; }
        }
        /// <summary>
        /// 项目总投资
        /// </summary>
        public string cTotalInvestment
        {
            set { _ctotalinvestment = value; }
            get { return _ctotalinvestment; }
        }
        /// <summary>
        /// 国有土地使用权证
        /// </summary>
        public string cGytdsyqz
        {
            set { _cgytdsyqz = value; }
            get { return _cgytdsyqz; }
        }
        /// <summary>
        /// 建设工程规划许可证
        /// </summary>
        public string cJsgcghxkz
        {
            set { _cjsgcghxkz = value; }
            get { return _cjsgcghxkz; }
        }
        /// <summary>
        /// 建设用地规划许可证
        /// </summary>
        public string cJsydghxkz
        {
            set { _cjsydghxkz = value; }
            get { return _cjsydghxkz; }
        }
        /// <summary>
        /// 建设工程施工许可证
        /// </summary>
        public string cJsgcsgxkz
        {
            set { _cjsgcsgxkz = value; }
            get { return _cjsgcsgxkz; }
        }
        /// <summary>
        /// 产权年限
        /// </summary>
        public string cPropertyYears
        {
            set { _cpropertyyears = value; }
            get { return _cpropertyyears; }
        }
        /// <summary>
        /// 产权类型
        /// </summary>
        public string cPropertyTypes
        {
            set { _cpropertytypes = value; }
            get { return _cpropertytypes; }
        }
        /// <summary>
        /// 开工时间
        /// </summary>
        public DateTime dStartingTime
        {
            set { _dstartingtime = value; }
            get { return _dstartingtime; }
        }
        /// <summary>
        /// 竣工时间
        /// </summary>
        public DateTime dCompletionTime
        {
            set { _dcompletiontime = value; }
            get { return _dcompletiontime; }
        }
        /// <summary>
        /// 交房标准
        /// </summary>
        public string cStandard
        {
            set { _cstandard = value; }
            get { return _cstandard; }
        }
        /// <summary>
        /// 周边配套
        /// </summary>
        public string cPeripheral
        {
            set { _cperipheral = value; }
            get { return _cperipheral; }
        }
        /// <summary>
        /// 内部配套
        /// </summary>
        public string cInternalSupporting
        {
            set { _cinternalsupporting = value; }
            get { return _cinternalsupporting; }
        }
        /// <summary>
        /// 周边商业
        /// </summary>
        public string cSurroundingCommercial
        {
            set { _csurroundingcommercial = value; }
            get { return _csurroundingcommercial; }
        }
        /// <summary>
        /// 周边环境
        /// </summary>
        public string cSurroundingLandscape
        {
            set { _csurroundinglandscape = value; }
            get { return _csurroundinglandscape; }
        }
        /// <summary>
        /// 周边公园
        /// </summary>
        public string cSurroundingPark
        {
            set { _csurroundingpark = value; }
            get { return _csurroundingpark; }
        }
        /// <summary>
        /// 周边医院
        /// </summary>
        public string cPeripheralHospital
        {
            set { _cperipheralhospital = value; }
            get { return _cperipheralhospital; }
        }
        /// <summary>
        /// 周边学校
        /// </summary>
        public string cPeripheralSchool
        {
            set { _cperipheralschool = value; }
            get { return _cperipheralschool; }
        }
        /// <summary>
        /// 周边交通
        /// </summary>
        public string cSurroundingTraffic
        {
            set { _csurroundingtraffic = value; }
            get { return _csurroundingtraffic; }
        }
        /// <summary>
        /// 装修
        /// </summary>
        public string cDecorateInfo
        {
            set { _cdecorateinfo = value; }
            get { return _cdecorateinfo; }
        }
        /// <summary>
        /// 职能设施
        /// </summary>
        public string cIntelligentFacilities
        {
            set { _cintelligentfacilities = value; }
            get { return _cintelligentfacilities; }
        }
        /// <summary>
        /// 所属居委会
        /// </summary>
        public string cSsjwh
        {
            set { _cssjwh = value; }
            get { return _cssjwh; }
        }
        /// <summary>
        /// 地图，预留字段
        /// </summary>
        public string cMap
        {
            set { _cmap = value; }
            get { return _cmap; }
        }
        /// <summary>
        /// 是否通过审核  0为未通过审核  1为通过初次审核 2为终审通过
        /// </summary>
        public string bIsAudit
        {
            set { _bisaudit = value; }
            get { return _bisaudit; }
        }
        /// <summary>
        /// 浏览次数  
        /// </summary>
        public int iHits
        {
            set { _ihits = value; }
            get { return _ihits; }
        }
        /// <summary>
        /// 是否设为推荐楼盘 0为普通 1为推荐
        /// </summary>
        public bool bIsRecommend
        {
            set { _bisrecommend = value; }
            get { return _bisrecommend; }
        }
        /// <summary>
        /// 行政区域,外键 取自地区表
        /// </summary>
        public int iAreaID
        {
            set { _iareaid = value; }
            get { return _iareaid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int iChannelID
        {
            set { _ichannelid = value; }
            get { return _ichannelid; }
        }
        /// <summary>
        /// 楼盘特色  外键  取自楼盘特色表  可多选
        /// </summary>
        public string cBuildingFeatures
        {
            set { _cbuildingfeatures = value; }
            get { return _cbuildingfeatures; }
        }
        /// <summary>
        /// 楼盘类型  外键  取自楼盘类型表
        /// </summary>
        public string cHouseType
        {
            set { _chousetype = value; }
            get { return _chousetype; }
        }
        /// <summary>
        /// 开盘时间
        /// </summary>
        public string cOpeningTime
        {
            set { _copeningtime = value; }
            get { return _copeningtime; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        /// <summary>
        /// 销售状态 (待售、在售、售馨)
        /// </summary>
        public string cZhuangtai
        {
            set { _czhuangtai = value; }
            get { return _czhuangtai; }
        }
        /// <summary>
        /// 编辑点评
        /// </summary>
        public string cCommentInfo
        {
            set { _ccommentinfo = value; }
            get { return _ccommentinfo; }
        }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string cVideoAddress
        {
            set { _cvideoaddress = value; }
            get { return _cvideoaddress; }
        }
        /// <summary>
        /// 触摸屏X坐标
        /// </summary>
        public string cCmpX
        {
            set { _ccmpx = value; }
            get { return _ccmpx; }
        }
        /// <summary>
        /// 触摸屏Y坐标
        /// </summary>
        public string cCmpY
        {
            set { _ccmpy = value; }
            get { return _ccmpy; }
        }
        /// <summary>
        /// 地理位置图
        /// </summary>
        public string cAreaImage
        {
            set { _careaimage = value; }
            get { return _careaimage; }
        }
        /// <summary>
        /// 拼音项目名称
        /// </summary>
        public string cBuildPinYing
        {
            set { _cbuildpinying = value; }
            get { return _cbuildpinying; }
        }
        /// <summary>
        /// 地图坐标字段
        /// </summary>
        public string cMaplng
        {
            set { _cmaplng = value; }
            get { return _cmaplng; }
        }
        /// <summary>
        /// 地图坐标字段
        /// </summary>
        public string cMaplat
        {
            set { _cmaplat = value; }
            get { return _cmaplat; }
        }
        #endregion Model
    }
}

