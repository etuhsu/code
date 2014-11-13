using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XxWapSystem.Model
{
    /// <summary>
    /// Al_BuildingPrice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Al_BuildingPrice
    {
        public Al_BuildingPrice()
        { }
        #region Model
        private int _iid;
        private string _cstartingprice;
        private string _caverageprice;
        private string _chighestprice;
        private string _cminimumallprice;
        private string _chighestallprice;
        private string _cpriceinfo;
        private DateTime _daddtime;
        private int _iprojectid;
        /// <summary>
        /// 楼盘价格表  流水号  标识符类型
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 起步价
        /// </summary>
        public string cStartingPrice
        {
            set { _cstartingprice = value; }
            get { return _cstartingprice; }
        }
        /// <summary>
        /// 均价
        /// </summary>
        public string cAveragePrice
        {
            set { _caverageprice = value; }
            get { return _caverageprice; }
        }
        /// <summary>
        /// 最高价
        /// </summary>
        public string cHighestPrice
        {
            set { _chighestprice = value; }
            get { return _chighestprice; }
        }
        /// <summary>
        /// 最低总价
        /// </summary>
        public string cMinimumAllPrice
        {
            set { _cminimumallprice = value; }
            get { return _cminimumallprice; }
        }
        /// <summary>
        /// 最高总价
        /// </summary>
        public string cHighestAllPrice
        {
            set { _chighestallprice = value; }
            get { return _chighestallprice; }
        }
        /// <summary>
        /// 价格描述
        /// </summary>
        public string cPriceInfo
        {
            set { _cpriceinfo = value; }
            get { return _cpriceinfo; }
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
        /// 外键 楼盘编号
        /// </summary>
        public int iProjectID
        {
            set { _iprojectid = value; }
            get { return _iprojectid; }
        }
        #endregion Model

    }
}
