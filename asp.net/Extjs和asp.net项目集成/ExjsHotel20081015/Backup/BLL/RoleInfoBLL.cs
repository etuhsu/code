using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class RoleInfoBLL
    {
        RoleInfoDAO dao = new RoleInfoDAO();
        private DataSet ds;
        //��ѯ�û���ɫ��Ϣ��ҳ
        public string GetRoleInfos(int start,int limit)
        { 
            string jsons="";
            JSONHelper json=new JSONHelper();
            json.success = true;
            ds = dao.GetRoleInfo(start, limit);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("roleid", dr["roleid"].ToString());
                json.AddItem("rolename", dr["rolename"].ToString());
                json.AddItem("roledesc", dr["roledesc"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetRoleInfoCount();
            jsons = json.ToString();
            return jsons;
        }

         //��ѯ���н�ɫ��Ϣ
        public string GetRoleInfos()
        {
            string jsons = "";
            JSONHelper json = new JSONHelper();
            json.success = true;
            ds = dao.GetRoleInfos();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("roleid", dr["roleid"].ToString());
                json.AddItem("rolename", dr["rolename"].ToString());
                json.AddItem("roledesc", dr["roledesc"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetRoleInfoCount();
            jsons = json.ToString();
            return jsons;
        }
         //���ӽ�ɫ��Ϣ
        public int AddRoleInfo(RoleinfoBean role)
        {
            return dao.AddRoleInfo(role);
        }
        //���ӽ�ɫ��Ϣ
        public int EditRoleInfo(RoleinfoBean role)
        {
            return dao.EditRoleInfo(role);
        }
        //ɾ����ɫ��Ϣ
        public int DelRoleInfo(int roleid)
        {
            return dao.DelRoleInfo(roleid);
        }
    }
}
