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
         //�ж��û��������Ƿ���ȷ
        public int userIsRight(UserInfoBean u)
        {
            return dao.userIsRight(u);
        }

         //��ѯ�û�ID
        public int getIdByUserid(string userid)
        {
            return dao.getIdByUserid(userid);
        }

        //��ѯ�û���ɫ
        public int getRoleTypeInfo(string userID)
        {
            return dao.getRoleTypeInfo(userID);
        }
         //�ж��û�״̬
        public int userStates(string userID)
        {
            return dao.userStates(userID);
        }

        //�õ��û���Ϣ��ҳ
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

          //����û���Ϣ
        public int AddUserInfo(UserInfoBean user)
        {
            return dao.AddUserInfo(user);
        }
         //�����û���Ϣ
        public int EditUserInfo(UserInfoBean user)
        {
            return dao.EditUserInfo(user);
        }
         //ɾ���û���Ϣ
        public int DelUserInfo(int id)
        {
            return dao.DelUserInfo(id);
        }

        //�޸��û��������
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

         //�����û���Ϣ
        public int SaveUserPwdInfo(string userid, string userpwd)
        {
            return dao.SaveUserPwdInfo(userid,userpwd);
        }
    }
}
