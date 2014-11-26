using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class RoomBLL
    {
        RoomDAO dao = new RoomDAO();
        private DataSet ds;
        //�õ�������Ϣ
        public string GetRoomInfosByTypeid(int typeid)
        {
            JSONHelper json = new JSONHelper();
            ds = dao.GetRoomInfoByTypeid(typeid);
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("roomid",dr["roomid"].ToString());
                json.AddItem("number",dr["number"].ToString());
                json.AddItem("roomdesc", dr["roomdesc"].ToString());
                json.ItemOk();
            }
            string jsons = json.ToString();
            return jsons;
        }
        //��ѯ������Ϣ��ҳ
        public string GetRoomInfoPage(int start,int limit)
        {
            JSONHelper json = new JSONHelper();
            ds = dao.GetRoomInfoPaging(start, limit);
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("roomid", dr["roomid"].ToString());
                json.AddItem("number", dr["number"].ToString());
                json.AddItem("bednumber", dr["bednumber"].ToString());
                json.AddItem("guestnumber", dr["guestnumber"].ToString());
                json.AddItem("typeid", dr["typeid"].ToString());
                json.AddItem("roomstate", dr["roomstate"].ToString());
                json.AddItem("roomdesc", dr["roomdesc"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetAllRoomCount();
            string jsons="";
            if (json.totlalCount > 0)
            {
                jsons = json.ToString();
            }
            else
            {
                jsons = @"{success:false}";
            }
           
            return jsons;
        }
        //�õ�������Ϣ���ж�״̬
        public RoomBean getRoonInfosNoState(int roomid)
        {
            return dao.getRoonInfosNoState(roomid);
        }
          //���·�����Ϣ
        public int SaveRoomInfo(RoomBean room)
        {
            return dao.SaveRoomInfo(room);
        }
        //����·���
        public int AddRoomInfo(RoomBean room)
        {
            return dao.AddRoomInfo(room);
        }
        //��֤������Ƿ����
        public int RoomIDIsOK(string roomid)
        {
            return dao.RoomIDIsOK(roomid);
        }
        //ɾ��������Ϣ
        public int DelRoomInfos(int roomid)
        {
            return dao.DelRoomInfos(roomid);
        }
    }
}
