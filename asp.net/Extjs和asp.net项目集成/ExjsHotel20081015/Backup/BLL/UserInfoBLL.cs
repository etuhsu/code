using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using DAL;

namespace BLL
{
    public class UserInfoBLL
    {
        UserInfoDAO dao = new UserInfoDAO();
        private DataSet ds;
         //判断用户名密码是否正确
        public int userIsRight(UserInfoBean u)
        {
            return dao.userIsRight(u);
        }

         //查询用户ID
        public int getIdByUserid(string userid)
        {
            return dao.getIdByUserid(userid);
        }

        //查询用户角色
        public int getRoleTypeInfo(string userID)
        {
            return dao.getRoleTypeInfo(userID);
        }
         //判断用户状态
        public int userStates(string userID)
        {
            return dao.userStates(userID);
        }

        //得到用户信息分页
        public string GetUserInfos(int start,int limit)
        {
            string jsons = "";
            JSONHelper json = new JSONHelper();
            json.success = true;
            ds = dao.GetUserInfo(start, limit);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("id",dr["id"].ToString());
                json.AddItem("userid", dr["userid"].ToString());
                json.AddItem("username", dr["username"].ToString());
                json.AddItem("userpwd", dr["userpwd"].ToString());
                json.AddItem("userstate", dr["userstate"].ToString());
                json.AddItem("roleid", dr["roleid"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetUserInfoCount();
            jsons=json.ToString();
            return jsons;
        }

          //添加用户信息
        public int AddUserInfo(UserInfoBean user)
        {
            return dao.AddUserInfo(user);
        }
         //保存用户信息
        public int EditUserInfo(UserInfoBean user)
        {
            return dao.EditUserInfo(user);
        }
         //删除用户信息
        public int DelUserInfo(int id)
        {
            return dao.DelUserInfo(id);
        }

        //修改用户密码加载
        public string GetUserInfoByID(string id)
        {
            FormJSONHelper json = new FormJSONHelper();
            ds = dao.GetUserInfoById(id);

            json.success = true;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("id", dr["id"].ToString());
                json.AddItem("userid", dr["userid"].ToString());
                json.AddItem("userpwd", dr["userpwd"].ToString());
                json.ItemOk();
            }
            string jsons = json.ToString();
            return jsons;
        }

         //保存用户信息
        public int SaveUserPwdInfo(string userid, string userpwd)
        {
            return dao.SaveUserPwdInfo(userid,userpwd);
        }
    }
}
