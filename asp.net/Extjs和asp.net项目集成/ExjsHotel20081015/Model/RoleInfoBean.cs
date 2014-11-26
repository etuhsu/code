using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

    /// <summary>
    /// 实体类RoleinfoBean 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class RoleinfoBean
    {
        public RoleinfoBean()
        { }
        #region Model
        private int _roleid;
        private string _rolename;
        private string _roledesc;
        /// <summary>
        /// 
        /// </summary>
        public int roleid
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string roleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string roleDesc
        {
            set { _roledesc = value; }
            get { return _roledesc; }
        }
        #endregion Model

    }
}
