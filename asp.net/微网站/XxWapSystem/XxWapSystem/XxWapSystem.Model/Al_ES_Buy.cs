using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_ES_Buy:实体类(求购表)
    /// </summary>
    [Serializable]
    public partial class Al_ES_Buy
    {
        public Al_ES_Buy()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _codenum;
        private int _area;
        private string _areaName;
        private int? _area2;
        private string _area2Name;
        private string _address;
        private int? _hometype;
        private int? _hometype1;
        private int? _hometype2;
        private string _homeTypeName;
        private int? _construction;
        private string _constructionName;
        private int? _buildtype;
        private string _buildtypeName;
        private int? _direction;
        private string _directionName;
        private int? _price;
        private string _priceName;
        private string _housemess;
        private string _linker;
        private string _phone;
        private DateTime _addtime = DateTime.Now;
        private int? _updateuid;
        private DateTime? _updatetime = DateTime.Now;
        private int _uid;
        private int? _click = 0;
        private bool _ismiddle = false;
        private int? _middleid;
        private int? _compareid;
        private int? _deluid;
        private DateTime? _deltime;
        private bool _isdel = false;
        private bool _ishot = false;
        private bool _istop = false;
        private bool _isok = false;
        private DateTime _endtime;
        /// <summary>
        /// 求购ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 求购编号
        /// </summary>
        public string CodeNum
        {
            set { _codenum = value; }
            get { return _codenum; }
        }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName
        {
            set { _areaName = value; }
            get { return _areaName; }
        }
        /// <summary>
        /// 二级区域ID
        /// </summary>
        public int? Area2
        {
            set { _area2 = value; }
            get { return _area2; }
        }
        /// <summary>
        /// 二级区域名称
        /// </summary>
        public string Area2Name
        {
            set { _area2Name = value; }
            get { return _area2Name; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 期望户型ID室
        /// </summary>
        public int? HomeType
        {
            set { _hometype = value; }
            get { return _hometype; }
        }
        /// <summary>
        /// 期望户型ID厅
        /// </summary>
        public int? HomeType1
        {
            set { _hometype1 = value; }
            get { return _hometype1; }
        }
        /// <summary>
        /// 期望户型ID卫
        /// </summary>
        public int? HomeType2
        {
            set { _hometype2 = value; }
            get { return _hometype2; }
        }
        /// <summary>
        /// 期望户型名称
        /// </summary>
        public string HomeTypeName
        {
            set { _homeTypeName = value; }
            get { return _homeTypeName; }
        }
        /// <summary>
        /// 建筑面积范围ID
        /// </summary>
        public int? Construction
        {
            set { _construction = value; }
            get { return _construction; }
        }
        /// <summary>
        /// 建筑面积范围
        /// </summary>
        public string ConstructionName
        {
            set { _constructionName = value; }
            get { return _constructionName; }
        }
        /// <summary>
        /// 房屋类别ID
        /// </summary>
        public int? BuildType
        {
            set { _buildtype = value; }
            get { return _buildtype; }
        }
        /// <summary>
        /// 房屋类别名称
        /// </summary>
        public string BuildTypeName
        {
            set { _buildtypeName = value; }
            get { return _buildtypeName; }
        }
        /// <summary>
        /// 朝向ID
        /// </summary>
        public int? direction
        {
            set { _direction = value; }
            get { return _direction; }
        }
        /// <summary>
        /// 朝向
        /// </summary>
        public string directionName
        {
            set { _directionName = value; }
            get { return _directionName; }
        }
        /// <summary>
        /// 价格区间ID
        /// </summary>
        public int? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 价格区间
        /// </summary>
        public string PriceName
        {
            set { _priceName = value; }
            get { return _priceName; }
        }
        /// <summary>
        /// 说明信息
        /// </summary>
        public string HouseMess
        {
            set { _housemess = value; }
            get { return _housemess; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linker
        {
            set { _linker = value; }
            get { return _linker; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 提交日期
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UpdateUID
        {
            set { _updateuid = value; }
            get { return _updateuid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// 是否中介
        /// </summary>
        public bool IsMiddle
        {
            set { _ismiddle = value; }
            get { return _ismiddle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MiddleID
        {
            set { _middleid = value; }
            get { return _middleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CompareID
        {
            set { _compareid = value; }
            get { return _compareid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DelUID
        {
            set { _deluid = value; }
            get { return _deluid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DelTime
        {
            set { _deltime = value; }
            get { return _deltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsOk
        {
            set { _isok = value; }
            get { return _isok; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        #endregion Model
    }
}
