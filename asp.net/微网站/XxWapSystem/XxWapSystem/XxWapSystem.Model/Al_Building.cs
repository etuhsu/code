using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_Building:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_Building
    {
        public Al_Building()
        { }
        #region Model
        private int _iid;
        private string _cbuildingname;
        private string _cmeasurementnum;
        private int _chouselayer;
        private string _chousehight;
        private string _chousetoward;
        private string _chousestructure;
        private string _cconstructionunit;
        private string _chouseareaof;
        private string _cresidentialarea;
        private string _fcommercialarea;
        private string _fofficearea;
        private string _fotherarea;
        private string _chousestartprice;
        private string _cbusinessstartprice;
        private string _cofficestartprice;
        private string _cotherstartprice;
        private DateTime _dstartdate;
        private DateTime _dcompletiondate;
        private DateTime _ddeliverydate;
        private bool _bisaudit;
        private int _iprojectid;
        private DateTime _daddtime;
        /// <summary>
        /// 楼盘栋信息表  流水号  标识符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 楼盘栋名称
        /// </summary>
        public string cBuildingName
        {
            set { _cbuildingname = value; }
            get { return _cbuildingname; }
        }
        /// <summary>
        /// 测量号
        /// </summary>
        public string cMeasurementNum
        {
            set { _cmeasurementnum = value; }
            get { return _cmeasurementnum; }
        }
        /// <summary>
        /// 房屋层数
        /// </summary>
        public int cHouseLayer
        {
            set { _chouselayer = value; }
            get { return _chouselayer; }
        }
        /// <summary>
        /// 房屋高度
        /// </summary>
        public string cHouseHight
        {
            set { _chousehight = value; }
            get { return _chousehight; }
        }
        /// <summary>
        /// 房屋朝向
        /// </summary>
        public string cHouseToward
        {
            set { _chousetoward = value; }
            get { return _chousetoward; }
        }
        /// <summary>
        /// 房屋结构
        /// </summary>
        public string cHouseStructure
        {
            set { _chousestructure = value; }
            get { return _chousestructure; }
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
        /// 房屋总面积
        /// </summary>
        public string cHouseAreaOf
        {
            set { _chouseareaof = value; }
            get { return _chouseareaof; }
        }
        /// <summary>
        /// 住宅面积
        /// </summary>
        public string cResidentialArea
        {
            set { _cresidentialarea = value; }
            get { return _cresidentialarea; }
        }
        /// <summary>
        /// 商业面积
        /// </summary>
        public string fCommercialArea
        {
            set { _fcommercialarea = value; }
            get { return _fcommercialarea; }
        }
        /// <summary>
        /// 办公面积
        /// </summary>
        public string fOfficeArea
        {
            set { _fofficearea = value; }
            get { return _fofficearea; }
        }
        /// <summary>
        /// 其他面积
        /// </summary>
        public string fOtherArea
        {
            set { _fotherarea = value; }
            get { return _fotherarea; }
        }
        /// <summary>
        /// 住宅起步价
        /// </summary>
        public string cHouseStartPrice
        {
            set { _chousestartprice = value; }
            get { return _chousestartprice; }
        }
        /// <summary>
        /// 商业起步价
        /// </summary>
        public string cBusinessStartPrice
        {
            set { _cbusinessstartprice = value; }
            get { return _cbusinessstartprice; }
        }
        /// <summary>
        /// 办公起步价
        /// </summary>
        public string cOfficeStartPrice
        {
            set { _cofficestartprice = value; }
            get { return _cofficestartprice; }
        }
        /// <summary>
        /// 其他起步价
        /// </summary>
        public string cOtherStartPrice
        {
            set { _cotherstartprice = value; }
            get { return _cotherstartprice; }
        }
        /// <summary>
        /// 开工日期
        /// </summary>
        public DateTime dStartDate
        {
            set { _dstartdate = value; }
            get { return _dstartdate; }
        }
        /// <summary>
        /// 竣工日期
        /// </summary>
        public DateTime dCompletionDate
        {
            set { _dcompletiondate = value; }
            get { return _dcompletiondate; }
        }
        /// <summary>
        /// 交付日期
        /// </summary>
        public DateTime dDeliveryDate
        {
            set { _ddeliverydate = value; }
            get { return _ddeliverydate; }
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
        /// 外键  取自楼盘表
        /// </summary>
        public int iProjectID
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime dAddTime
        {
            set { _daddtime = value; }
            get { return _daddtime; }
        }
        #endregion Model

    }
}
