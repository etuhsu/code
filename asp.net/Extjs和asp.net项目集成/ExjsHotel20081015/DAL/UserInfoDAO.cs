using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;

namespace DAL
{
    public class UserInfoDAO
    {
       
        SQLHelper sqlhelper = new SQLHelper();
        private DataSet ds;

        //判断用户名密码是否正确
        public int userIsRight(UserInfoBean u)
        {
            int count = 0;
            count = sqlhelper.ReturnSQL("select count(*) from userinfo where userid='"+u.userid+"' and userpwd='"+u.userPwd+"'");
            return count;
        }
        //查询用户ID
        public int getIdByUserid(string userid)
        {
            int count = sqlhelper.ReturnSQL("select id from userinfo where userid='"+userid+"'");
            return count;
        }
        //查询用户角色
        public int getRoleTypeInfo(string userID)
        {
            int count = 0;
            count = sqlhelper.ReturnSQL("select roleid from userinfo where userid='"+userID+"'");
            return count;
        }
        //判断用户状态
        public int userStates(string userID)
        {
            int count = 0;
            count = sqlhelper.ReturnSQL("select userstate from userinfo where userid='"+userID+"'");
            return count;
        }

        //得到总记录数
        public int GetUserInfoCount()
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from userinfo");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //查询用户信息
        public DataSet GetUserInfo(int start,int limit)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select top "+limit+" * from userinfo where id not in(select top "+start+" id from userinfo order by id desc) order by id desc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //添加用户信息
        public int AddUserInfo(UserInfoBean user)
        {
            try
            {
                int count = sqlhelper.RunSQL("insert into userinfo values('" + user.userid + "','" + user.userName + "','" + user.userPwd + "'," + user.userState + "," + user.roleid + ")");
                return count;
            }
            catch (Exception)
            {

                throw;
            }        
        }
        //保存用户信息
        public int EditUserInfo(UserInfoBean user)
        {
            try
            {
                int count = sqlhelper.RunSQL("update userinfo set username='"+user.userName+"',userpwd='"+user.userPwd+"',userstate="+user.userState+",roleid="+user.roleid+" where userid='"+user.userid+"'");
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //删除用户信息
        public int DelUserInfo(int id)
        {
            try
            {
                int count = sqlhelper.RunSQL("delete userinfo where id=" + id);
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //根据ID查询用户信息
        public DataSet GetUserInfoById(string id)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from userinfo where id="+id);
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //保存用户信息
        public int SaveUserPwdInfo(string userid,string userpwd)
        {
            try
            {
                int count = sqlhelper.RunSQL("update userinfo set userpwd='"+userpwd+"' where userid='"+userid+"'");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
