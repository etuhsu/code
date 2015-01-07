using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class NavBLL
    {
        private DataSet ds;
        NavDAO dao = new NavDAO();

        //查询权限树信息
        public string GetDtreeInfos(int parentID)
        {
            string DTreeJSON="";
            DTreeJSONHelper json = new DTreeJSONHelper();
            try
            {
                ds=dao.getDTreeInfo(parentID);
                json.success = true;
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    json.AddItem("id", dr["id"].ToString());
                    json.AddItem("parentid", dr["parentid"].ToString());
                    json.AddItem("text", dr["title"].ToString());
                    json.AddItem("leaf", dr["leaf"].ToString());
                    json.AddItem("iconCls",dr["iconCls"].ToString());
                    json.AddItem("number", dr["number"].ToString());
                    json.AddItem("url", dr["url"].ToString());
                   json.ItemOk();
                }
                DTreeJSON = json.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
            return DTreeJSON; 
        }
    }
}
