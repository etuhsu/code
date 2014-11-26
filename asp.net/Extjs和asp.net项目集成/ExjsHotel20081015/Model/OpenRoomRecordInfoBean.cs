using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OpenRoomRecordInfoBean
    {
        public OpenRoomRecordInfoBean()
        { }
        #region Model
        private int _recordid;
        private int _roomid;
        private int _guestid;
        private decimal _guestmoney;
        private string _opentodaytime;
        private string _opentime;
        private string _endtodaytime;
        private string _endtime;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
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
        /// <summary>
        /// 
        /// </summary>
        public string OpenTodayTime
        {
            set { _opentodaytime = value; }
            get { return _opentodaytime; }
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
        public string EndTodayTime
        {
            set { _endtodaytime = value; }
            get { return _endtodaytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
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
