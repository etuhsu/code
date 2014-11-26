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

        //�ж��û��������Ƿ���ȷ
        public int userIsRight(UserInfoBean u)
        {
            int count = 0;
            count = sqlhelper.ReturnSQL("select count(*) from userinfo where userid='"+u.userid+"' and userpwd='"+u.userPwd+"'");
            return count;
        }
        //��ѯ�û�ID
        public int getIdByUserid(string userid)
        {
            int count = sqlhelper.ReturnSQL("select id from userinfo where userid='"+userid+"'");
            return count;
        }
        //��ѯ�û���ɫ
        public int getRoleTypeInfo(string userID)
        {
            int count = 0;
            count = sqlhelper.ReturnSQL("select roleid from userinfo where userid='"+userID+"'");
            return count;
        }
        //�ж��û�״̬
        public int userStates(string userID)
        {
            int count = 0;
            count = sqlhelper.ReturnSQL("select userstate from userinfo where userid='"+userID+"'");
            return count;
        }

        //�õ��ܼ�¼��
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
        //��ѯ�û���Ϣ
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

        //����û���Ϣ
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
        //�����û���Ϣ
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
        //ɾ���û���Ϣ
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

        //����ID��ѯ�û���Ϣ
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

        //�����û���Ϣ
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
