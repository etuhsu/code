using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HotelModels;
using HotelDAL;

namespace HotelBLL
{
    public class UserInfoBLL
    {

        UserInfoDAO uid = new UserInfoDAO(); //数据层


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="uib"></param>
        /// <returns></returns>
        public bool GetLogin(UserInfoBean uib)
        {
            DataTable dt = uid.GetLogin(uib);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// 检查登录名是否重复
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool CheckUserId(string UserId)
        {
            if (uid.CheckUserId(UserId).Tables[0].Rows.Count > 0)
            {
                return true; //已被注册
            }
            return false;
        }



        /// <summary>
        /// 查询所有员工(删除用到)
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public string GetUser(string LoginName)
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = uid.GetUser(LoginName);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("UserId", dr["UserId"].ToString());
                jsonHelp.AddItem("LoginName", dr["LoginName"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }



        /// <summary>
        /// 添加普通员工
        /// </summary>
        /// <param name="uib"></param>
        /// <returns></returns>
        public bool AddUser(UserInfoBean uib)
        {
            if (uid.AddUser(uib) > 0)
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// 删除员工(根据Id删除)
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DelUser(int UserId)
        {
            if (uid.DelUser(UserId) > 0)
            {
                return true;
            }
            return false;
        }


    }
}
