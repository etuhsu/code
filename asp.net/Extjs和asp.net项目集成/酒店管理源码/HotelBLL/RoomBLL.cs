using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using HotelModels;
using HotelDAL;

namespace HotelBLL
{
    public class RoomBLL
    {

        RoomDAO rd = new RoomDAO(); //���ݲ�


        /// <summary>
        /// ��������Id��ѯ���пͷ���Ϣ(״̬Ϊ����)
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public string GetRoomByTypeId(int TypeId)
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = rd.GetRoomByTypeId(TypeId);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("RoomId", dr["RoomId"].ToString());
                jsonHelp.AddItem("Number", dr["Number"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }


        /// <summary>
        /// ��ӿͷ���
        /// </summary>
        /// <param name="rb"></param>
        /// <returns></returns>
        public bool AddRoom(RoomBean rb)
        {
            if (rd.AddRoom(rb) > 0)
            {
                return true;
            }
            return false;
        }


        
        /// <summary>
        /// ��ѯ���пͷ���Ϣ(�鿴�ͷ���Ϣ�õ�,������)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string GetAllRoom(string message)
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = rd.GetAllRoom(message);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("Number", dr["Number"].ToString());
                jsonHelp.AddItem("BedNumber", dr["BedNumber"].ToString());
                jsonHelp.AddItem("TypeName", dr["TypeName"].ToString());
                jsonHelp.AddItem("StateName", dr["StateName"].ToString());
                jsonHelp.AddItem("Remark", dr["Remark"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }


        /// <summary>
        /// ��ѯ����״̬Ϊ���еķ���(ɾ���ͷ�ʱ�õ�)
        /// </summary>
        /// <returns></returns>
        public string GetRoom()
        {
            JSONHelper jsonHelp = new JSONHelper();
            jsonHelp.success = true;
            DataSet ds = rd.GetRoom();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                jsonHelp.AddItem("RoomId", dr["RoomId"].ToString());
                jsonHelp.AddItem("Number", dr["Number"].ToString());
                jsonHelp.ItemOk();
            }
            string str = jsonHelp.ToString();
            return str;
        }


        /// <summary>
        /// ɾ���ͷ���(���ݷ�����)
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public bool DelRoom(string Number)
        {
            if (rd.DelRoom(Number) > 0)
            {
                return true;
            }
            return false;
        }

    }
}
