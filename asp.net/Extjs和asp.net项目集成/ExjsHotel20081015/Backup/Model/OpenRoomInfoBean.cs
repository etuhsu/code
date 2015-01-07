using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类OpenRoomInfoBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class OpenRoomInfoBean
    {
        public OpenRoomInfoBean()
        { }
        #region Model
        private int _openroomid;
        private int _roomid;
        private int _guestid;
        private decimal _guestmoney;
        private string _opentodaytime;
        

        private string _opentime;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int OpenRoomID
        {
            set { _openroomid = value; }
            get { return _openroomid; }
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
        public decimal GuestMoney
        {
            set { _guestmoney = value; }
            get { return _guestmoney; }
        }
        public string Opentodaytime
        {
            get { return _opentodaytime; }
            set { _opentodaytime = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OpenTime
        {
            set { _opentime = value; }
            get { return _opentime; }
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
