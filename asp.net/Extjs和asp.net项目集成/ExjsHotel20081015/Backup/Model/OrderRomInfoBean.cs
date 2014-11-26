using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类OrderRoomInfoBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class OrderRoomInfoBean
    {
        public OrderRoomInfoBean()
        { }
        #region Model
        private int _orderid;
        private int _roomid;
        private int _guestid;
        private DateTime _ordertime;
        private DateTime _arrvaltime;
        private int? _ordersate;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Roomid
        {
            set { _roomid = value; }
            get { return _roomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Guestid
        {
            set { _guestid = value; }
            get { return _guestid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderTime
        {
            set { _ordertime = value; }
            get { return _ordertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ArrvalTime
        {
            set { _arrvaltime = value; }
            get { return _arrvaltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? orderSate
        {
            set { _ordersate = value; }
            get { return _ordersate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}
