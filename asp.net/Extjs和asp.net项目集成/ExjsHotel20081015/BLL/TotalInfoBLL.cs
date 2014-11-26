using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class TotalInfoBLL
    {
        private DataSet ds;
        TotalInfoDAO dao = new TotalInfoDAO();
         //保存结帐信息
        public int SaveRoomMoney(TotalInfoBean total)
        {
            return dao.SaveRoomMoney(total);
        }

        //分页查询收入信息
        public string GetTotalInfo(int start,int limit,string starttime,string endtime)
        {
            string jsons = "";
            JSONHelper json = new JSONHelper();
            json.success = true;
            if (starttime == null && endtime == null)
            {
                ds = dao.GetToltalInfo(start, limit);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    json.AddItem("totalid", dr["totalid"].ToString());
                    json.AddItem("totaltype", dr["totaltype"].ToString());
                    json.AddItem("totalmoney", dr["totalmoney"].ToString());
                    json.AddItem("totaltime", dr["totaltime"].ToString());
                    json.AddItem("totalremark", dr["totalremark"].ToString());
                    json.ItemOk();
                }
                json.totlalCount = dao.GetAllCount();
                jsons = json.ToString();
            }
            else if (starttime == null  && endtime != null)
            {
                ds = dao.GetSTandETinfo(dao.GetStartTime(), endtime + " 23:59:59.999");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    json.AddItem("totalid", dr["totalid"].ToString());
                    json.AddItem("totaltype", dr["totaltype"].ToString());
                    json.AddItem("totalmoney", dr["totalmoney"].ToString());
                    json.AddItem("totaltime", dr["totaltime"].ToString());
                    json.AddItem("totalremark", dr["totalremark"].ToString());
                    json.ItemOk();
                }
                jsons = json.ToString();
            }
            else if (starttime != null && endtime == null)
            {
                ds = dao.GetSTandETinfo(starttime + " 00:00:00.000", dao.GetEndTime());
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    json.AddItem("totalid", dr["totalid"].ToString());
                    json.AddItem("totaltype", dr["totaltype"].ToString());
                    json.AddItem("totalmoney", dr["totalmoney"].ToString());
                    json.AddItem("totaltime", dr["totaltime"].ToString());
                    json.AddItem("totalremark", dr["totalremark"].ToString());
                    json.ItemOk();
                }
                jsons = json.ToString();
            }
            else if (starttime != null && endtime != null)
            {
                ds = dao.GetSTandETinfo(starttime + " 00:00:00.000", endtime + " 23:59:59.999");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    json.AddItem("totalid", dr["totalid"].ToString());
                    json.AddItem("totaltype", dr["totaltype"].ToString());
                    json.AddItem("totalmoney", dr["totalmoney"].ToString());
                    json.AddItem("totaltime", dr["totaltime"].ToString());
                    json.AddItem("totalremark", dr["totalremark"].ToString());
                    json.ItemOk();
                }
                jsons = json.ToString();
            }
            
            return jsons;
        }

        //计算日期段收入
        public string GetAllMoney(string starttime, string endtime)
        {
            string AllMoney = "";
            if (starttime == null  && endtime == null )
            {
                AllMoney = dao.GetAllMoney(dao.GetStartTime(),dao.GetEndTime());
            }
            else if (starttime == null && endtime != null)
            {
                AllMoney = dao.GetAllMoney(dao.GetStartTime(), endtime +" 23:59:59");
            }
            else if (starttime != null && endtime == null)
            {
                AllMoney = dao.GetAllMoney(starttime + " 00:00:00",dao.GetEndTime());
            }
            else if (starttime != null && endtime != null)
            {
                AllMoney = dao.GetAllMoney(starttime + " 00:00:00", endtime + " 23:59:59");
            }
            return AllMoney; 
        }
    }
}
