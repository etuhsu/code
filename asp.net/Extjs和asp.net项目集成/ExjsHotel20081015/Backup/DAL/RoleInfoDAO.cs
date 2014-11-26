using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;


namespace DAL
{
    public class RoleInfoDAO
    {
        private DataSet ds;
        SQLHelper sqlhelper = new SQLHelper();

        //查询总记录数
        public int GetRoleInfoCount()
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from roleinfo");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //查询角色信息分页

        public DataSet GetRoleInfo(int start, int limit)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select top "+limit+" * from roleinfo where roleid not in(select top "+start+" roleid from roleinfo order by roleid desc) order by roleid desc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //查询所有角色信息
        public DataSet GetRoleInfos()
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from roleinfo");
                return ds;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //增加角色信息
        public int AddRoleInfo(RoleinfoBean role)
        {
            try
            {
                int count = sqlhelper.RunSQL("insert into roleinfo values('"+role.roleName+"','"+role.roleDesc+"')");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //增加角色信息
        public int EditRoleInfo(RoleinfoBean role)
        {
            try
            {
                int count = sqlhelper.RunSQL("update roleinfo set rolename='"+role.roleName+"',roledesc='"+role.roleDesc+"' where roleid="+role.roleid);
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DelRoleInfo(int roleid)
        {
            try
            {
                int count = sqlhelper.RunSQL("delete roleinfo where roleid="+roleid);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
