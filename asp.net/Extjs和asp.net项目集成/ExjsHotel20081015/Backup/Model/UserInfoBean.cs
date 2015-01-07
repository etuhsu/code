using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 实体类UserInfoBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class UserInfoBean
    {
        public UserInfoBean()
        { }
        #region Model
        private string _userid;
        private string _username;
        private string _userpwd;
        private int _userstate;
        private int _roleid;
        /// <summary>
        /// 
        /// </summary>
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int userState
        {
            set { _userstate = value; }
            get { return _userstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int roleid
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model

    }
}
