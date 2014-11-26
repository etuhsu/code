using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
using DAL;


namespace BLL
{
    public class RoomTypeBLL
    {
        private DataSet ds;
        RoomTypeDAO dao = new RoomTypeDAO();
        JSONHelper json = new  JSONHelper();
        

        //��DataSet ת��ΪJSON����
        public string getRoomTypeInfo(int start,int limit)
        {
            ds = dao.getAllRoomTypeInfo(start,limit);
            json.success = true;
           
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typeid",dr["typeid"].ToString());
                json.AddItem("typename", dr["typename"].ToString());
                json.AddItem("typeprice", dr["typeprice"].ToString());
                json.AddItem("typeaddbed", dr["typeaddbed"].ToString());
                json.AddItem("addbed", dr["addbed"].ToString());
                json.AddItem("typedesc", dr["typedesc"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.getInfoCount();
            string jsons = "";
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

        //ɾ��������Ϣ
        public int DeleteRoomTypeInfo(int typeid)
        {
            return dao.DeleteRoomTypeInfo(typeid);
        }

        //����typeid��������Ϣ
        public string getRoomTypeInfo(int typeid)
        {
         
            FormJSONHelper json = new FormJSONHelper();
            ds = dao.GetTypeInfoByTypeid(typeid);
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typeid", dr["typeid"].ToString());
                json.AddItem("typename", dr["typename"].ToString());
                json.AddItem("typeprice", dr["typeprice"].ToString());
                json.AddItem("typeaddbed", dr["typeaddbed"].ToString());
                json.AddItem("addbed", dr["addbed"].ToString());
                json.AddItem("typedesc", dr["typedesc"].ToString());
                json.ItemOk();
            }
            string jsons = json.ToString();
            return jsons;
        }

        //���淿��������Ϣ
        public int saveRoomTypeInfo(RoomTypeBean type)
        {
            return dao.saveRoomTypeInfo(type);
        }

        //��ӷ���������Ϣ
        public int AddRoomTypeInfo(RoomTypeBean type)
        {
            return dao.AddRoomTypeInfo(type);
        }

        //���շ�����Ϣ
        public string getToDayRoomTypeInfo()
        {
            json.success = true;
            ds = dao.TodayRoomTypePrice();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typename",dr["typename"].ToString());
                json.AddItem("typeprice",dr["typeprice"].ToString());
                json.ItemOk();
            }
            string jsons = "";
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

          //�޸Ľ��շ���
        public int EditTodayPrice(string typename, decimal typeprice)
        {
            return dao.EditTodayPrice(typename,typeprice);
        }

        //�����õ�����������Ϣ
        public string OpenRoomGetAllRoomTypeInfos()
        {
            ds = dao.OpenRoomGetRoomTypeInfo();
            json.success = true;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("typeid", dr["typeid"].ToString());
                json.AddItem("typename", dr["typename"].ToString());
                json.AddItem("typedesc", dr["typedesc"].ToString());
                json.ItemOk();
            }
            string jsonss = json.ToString();
            return jsonss;
        }
         //���ݷ������������ж��Ƿ����
        public int RoomTypeIsOK(string roomTypeName)
        {
            return dao.RoomTypeIsOK(roomTypeName);
        }
    }
}
