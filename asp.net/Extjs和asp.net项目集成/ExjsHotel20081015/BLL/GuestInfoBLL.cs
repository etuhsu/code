using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using DAL;
namespace BLL
{
    public class GuestInfoBLL
    {
        GuestInfoDAO dao=new GuestInfoDAO();
        private DataSet ds;
         //���������Ϣ
        public int SaveGuestInfo(GuestInfoBean guest)
        {
            return dao.SaveGuestInfo(guest);
        }

        //��ҳ��ѯ������Ϣ
        public string GetGuestInfos(int start,int limit)
        {
            JSONHelper json = new JSONHelper();
            string jsons = "";
            json.success = true;
            ds = dao.GetGuestInfo(start, limit);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("guestid",dr["guestid"].ToString());
                json.AddItem("guestcardid", dr["guestcardid"].ToString());
                json.AddItem("guestname", dr["guestname"].ToString());
                json.AddItem("guestsex", dr["guestsex"].ToString());
                json.AddItem("guestmobile", dr["guestmobile"].ToString());
                json.AddItem("guestaddress", dr["guestaddress"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetGuestInfoCount();
            jsons = json.ToString();
            return jsons;
        }

        //�޸ı��������Ϣ

        public int EditSaveGuestInfo(GuestInfoBean guest)
        {
            return dao.EditSaveGuestInfo(guest);
        }

         //ɾ��������Ϣ
        public int DeleteGuestInfo(int guestid)
        {
            return dao.DeleteGuestInfo(guestid);
        }
    }
}
