using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类NavBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class NavBean
    {
        public NavBean()
        { }
        #region Model
        private int _navid;
        private int _id;
        private int _parentid;
        private string _title;
        private int _leaf;
        private int _number;
        private string _url;
        /// <summary>
        /// 
        /// </summary>
        public int navid
        {
            set { _navid = value; }
            get { return _navid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int parentid
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int leaf
        {
            set { _leaf = value; }
            get { return _leaf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        #endregion Model

    }
}
