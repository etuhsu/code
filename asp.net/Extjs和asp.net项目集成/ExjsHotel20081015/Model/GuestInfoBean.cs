using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类GuestInfoBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class GuestInfoBean
    {
        public GuestInfoBean()
        { }
        #region Model
        private int _guestid;
        private decimal _guestcardid;
        private string _guestname;
        private int _guestsex;
        private decimal _guestmobile;
        private string _guestaddress;
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
        public decimal GuestCardID
        {
            set { _guestcardid = value; }
            get { return _guestcardid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GuestName
        {
            set { _guestname = value; }
            get { return _guestname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GuestSex
        {
            set { _guestsex = value; }
            get { return _guestsex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal GuestMobile
        {
            set { _guestmobile = value; }
            get { return _guestmobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GuestAddress
        {
            set { _guestaddress = value; }
            get { return _guestaddress; }
        }
        #endregion Model

    }
}
