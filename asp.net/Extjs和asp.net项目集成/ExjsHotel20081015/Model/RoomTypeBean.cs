using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类RoomTypeBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class RoomTypeBean
    {
        public RoomTypeBean()
        { }
        #region Model
        private int _typeid;
        private string _typename;
        private decimal _typeprice;
        private string _typeaddbed;
        private decimal _addbed;
        private string _typedesc;
        /// <summary>
        /// 
        /// </summary>
        public int typeid
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal typePrice
        {
            set { _typeprice = value; }
            get { return _typeprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typeAddBed
        {
            set { _typeaddbed = value; }
            get { return _typeaddbed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal addbed
        {
            set { _addbed = value; }
            get { return _addbed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string typeDesc
        {
            set { _typedesc = value; }
            get { return _typedesc; }
        }
        #endregion Model

    }
}
