using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class OpenRoomInfoBLL
    {
        OpenRoomInfoDAO dao = new OpenRoomInfoDAO();
        private DataSet ds;

        //��ҳ��ѯopenroominfo
        public string PageingOpenRoomInfo(int start,int limit)
        {
            JSONHelper json = new JSONHelper();
            ds = dao.GetRoomOpenInfo(start,limit);
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("openroomid", dr["openroomid"].ToString());
                json.AddItem("roomid", dr["roomid"].ToString());
                json.AddItem("guestid", dr["guestid"].ToString());
                json.AddItem("guestmoney", dr["guestmoney"].ToString());
                json.AddItem("OpenTodayTime", dr["OpenTodayTime"].ToString());
                json.AddItem("opentime", dr["opentime"].ToString());
                json.AddItem("remark", dr["remark"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetOpenRoomAllCount();
            string openroominfo = json.ToString();
            return openroominfo;
        }

         //���濪����Ϣ
        public int SaveOpenRoomInfo(OpenRoomInfoBean open)
        {
            return dao.SaveOpenRoomInfo(open);
        }

         //�޸Ŀ�����Ϣ
        public int EditOpenRoomInfo(OpenRoomInfoBean open)
        {
            return dao.EditOpenRoomInfo(open);
        }
        //ɾ��������Ϣ
        public int DelOpenRoomInfo(int OpenRoomID)
        {
            return dao.DelOpenRoomInfo(OpenRoomID);
        }
    }
}
