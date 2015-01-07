using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类RoomBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class RoomBean
    {
        public RoomBean()
        { }
        #region Model
        private int _roomid;
        private string _number;
        private int _bednumber;
        private int _roomstate;
        private int _guestnumber;
        private string _roomdesc;
        private int _typeid;
        /// <summary>
        /// 
        /// </summary>
        public int roomid
        {
            set { _roomid = value; }
            get { return _roomid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bedNumber
        {
            set { _bednumber = value; }
            get { return _bednumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int roomstate
        {
            set { _roomstate = value; }
            get { return _roomstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int guestNumber
        {
            set { _guestnumber = value; }
            get { return _guestnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string roomDesc
        {
            set { _roomdesc = value; }
            get { return _roomdesc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int typeid
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        #endregion Model

    }
}
