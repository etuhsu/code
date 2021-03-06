﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_ES_Lease:实体类(求租表)
    /// </summary>
    [Serializable]
    public partial class Al_ES_Lease
    {
        public Al_ES_Lease()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _codenum;
        private int? _area;
        private string _areaName;
        private int? _area2;
        private string _area2Name;
        private string _address;
        private int? _hometype;
        private int? _hometype1;
        private int? _hometype2;
        private string _hometypeName;
        private int? _managertype;
        private string _managertypeName;
        private int? _construction;
        private string _constructionName;
        private int? _buildstruct;
        private string _buildstructName;
        private int? _decoration;
        private string _decorationName;
        private int? _floornum;
        private int? _direction;
        private string _directionName;
        private int? _price;
        private string _priceName;
        private string _other;
        private string _phone;
        private string _linker;
        private string _email;
        private string _housemess;
        private DateTime _addtime;
        private int? _updateuid;
        private DateTime? _updatetime = DateTime.Now;
        private string _bus;
        private bool _ismiddle;
        private int? _uid;
        private int? _click;
        private int? _middleid;
        private int? _compareid;
        private int? _deluid;
        private bool _isdel;
        private bool _ishot;
        private bool _istop;
        private bool _isok = false;
        private DateTime _endtime;
        /// <summary>
        /// LId
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
        /// 编号
        /// </summary>
        public string CodeNum
        {
            set { _codenum = value; }
            get { return _codenum; }
        }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 区域
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
        /// 二级区域
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
        /// 户型
        /// </summary>
        public string HomeTypeName
        {
            set { _hometypeName = value; }
            get { return _hometypeName; }
        }
        /// <summary>
        /// 物业类型ID
        /// </summary>
        public int? ManagerType
        {
            set { _managertype = value; }
            get { return _managertype; }
        }
        /// <summary>
        /// 物业类型
        /// </summary>
        public string ManagerTypeName
        {
            set { _managertypeName = value; }
            get { return _managertypeName; }
        }
        /// <summary>
        /// 面积ID
        /// </summary>
        public int? Construction
        {
            set { _construction = value; }
            get { return _construction; }
        }
        /// <summary>
        /// 面积
        /// </summary>
        public string ConstructionName
        {
            set { _constructionName = value; }
            get { return _constructionName; }
        }
        /// <summary>
        /// 建筑结构ID
        /// </summary>
        public int? buildStruct
        {
            set { _buildstruct = value; }
            get { return _buildstruct; }
        }
        /// <summary>
        /// 建筑结构
        /// </summary>
        public string buildStructName
        {
            set { _buildstructName = value; }
            get { return _buildstructName; }
        }
        /// <summary>
        /// 装修程度ID
        /// </summary>
        public int? Decoration
        {
            set { _decoration = value; }
            get { return _decoration; }
        }
        /// <summary>
        /// 装修程度
        /// </summary>
        public string DecorationName
        {
            set { _decorationName = value; }
            get { return _decorationName; }
        }
        /// <summary>
        /// 楼层
        /// </summary>
        public int? FloorNum
        {
            set { _floornum = value; }
            get { return _floornum; }
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
        /// 价格ID
        /// </summary>
        public int? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public string PriceName
        {
            set { _priceName = value; }
            get { return _priceName; }
        }
        /// <summary>
        /// 配备
        /// </summary>
        public string Other
        {
            set { _other = value; }
            get { return _other; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
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
        /// Email
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 房屋信息
        /// </summary>
        public string HouseMess
        {
            set { _housemess = value; }
            get { return _housemess; }
        }
        /// <summary>
        /// 添加日期
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
        /// 交通要求
        /// </summary>
        public string Bus
        {
            set { _bus = value; }
            get { return _bus; }
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
        /// 用户ID
        /// </summary>
        public int? UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 点击数
        /// </summary>
        public int? Click
        {
            set { _click = value; }
            get { return _click; }
        }
        /// <summary>
        /// 中介ID
        /// </summary>
        public int? MiddleID
        {
            set { _middleid = value; }
            get { return _middleid; }
        }
        /// <summary>
        /// 企业ID
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
        /// 是否删除
        /// </summary>
        public bool IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsHot
        {
            set { _ishot = value; }
            get { return _ishot; }
        }
        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool IsOk
        {
            set { _isok = value; }
            get { return _isok; }
        }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        #endregion Model

    }
}
