using System;
using System.Collections.Generic;
using System.Text;

namespace HotelModels
{

    /// <summary>
    /// 用户表实体Bean
    /// </summary>
    public class UserInfoBean
    {
        private int _UserId;

        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private string _LoginName;

        public string LoginName
        {
            get { return _LoginName; }
            set { _LoginName = value; }
        }
        private string _LoginPass;

        public string LoginPass
        {
            get { return _LoginPass; }
            set { _LoginPass = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

    }
}
