using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public  class OpenRoomRecordInfoBLL
    {
        OpenRoomRecordInfoDAO dao = new OpenRoomRecordInfoDAO();

        private DataSet ds;
         //房费总额
        public string GetRoomMoney(string roomid)
        {
            FormJSONHelper json = new FormJSONHelper();
            string money= dao.GetRoomMoney(roomid);
            json.success = true;
            json.AddItem("roommoney",money);
            json.ItemOk();
            string allmoney = json.ToString();
            return allmoney;
        }

        //分页得到开房记录
        public string GetOpenRoomRecordInfos(int start,int limit,string message)
        {
            JSONHelper json = new JSONHelper();
            json.success = true;
            string jsons = "";
            if (message == null || message.Trim().Length == 0 ||message=="开房/退房（日期/时间）/备注信息")
            {
                ds = dao.GetOpenRoomInfo(start, limit);
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    json.AddItem("recordid", dr["recordid"].ToString());
                    json.AddItem("roomid", dr["roomid"].ToString());
                    json.AddItem("guestid", dr["guestid"].ToString());
                    json.AddItem("guestmoney", dr["guestmoney"].ToString());
                    json.AddItem("opentodaytime", dr["opentodaytime"].ToString());
                    json.AddItem("opentime", dr["opentime"].ToString());
                    json.AddItem("endtodaytime", dr["endtodaytime"].ToString());
                    json.AddItem("endtime", dr["endtime"].ToString());
                    json.AddItem("remark", dr["remark"].ToString());
                    json.ItemOk();
                }
                json.totlalCount = dao.GetAllCountOpenRoomRecord();
                jsons = json.ToString();
            }
            else
            {
                ds = dao.GetOpenRoomInfoAll(message);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    json.AddItem("recordid", dr["recordid"].ToString());
                    json.AddItem("roomid", dr["roomid"].ToString());
                    json.AddItem("guestid", dr["guestid"].ToString());
                    json.AddItem("guestmoney", dr["guestmoney"].ToString());
                    json.AddItem("opentodaytime", dr["opentodaytime"].ToString());
                    json.AddItem("opentime", dr["opentime"].ToString());
                    json.AddItem("endtodaytime", dr["endtodaytime"].ToString());
                    json.AddItem("endtime", dr["endtime"].ToString());
                    json.AddItem("remark", dr["remark"].ToString());
                    json.ItemOk();
                }
                jsons = json.ToString();       
            }
            return jsons;
        }
    }
}
