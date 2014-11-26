using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using HotelModels;
//��Դ���׷���www.51aspx.com(�������p��������)

namespace HotelDAL
{
    public class RoomDAO
    {

        SqlHelper sh = new SqlHelper();
        DataSet ds;
        private SqlParameter para; //����


        /// <summary>
        /// ��������Id��ѯ���пͷ���Ϣ(״̬Ϊ����)
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public DataSet GetRoomByTypeId(int TypeId)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@TypeId",TypeId)
                };
                ds = sh.GetDataSet("GetRoomByTypeId", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        /// <summary>
        /// ��ӿͷ���
        /// </summary>
        /// <param name="rb"></param>
        /// <returns></returns>
        public int AddRoom(RoomBean rb)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@Number",rb.Number),
                    para = new SqlParameter("@BedNumber",rb.BedNumber),
                    para = new SqlParameter("@TypeId",rb.TypeId),
                    para = new SqlParameter("@StateId",rb.StateId),
                    para = new SqlParameter("@Remark",rb.Remark)
                };
                count = sh.RunSql("AddRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }


       
        /// <summary>
        /// ��ѯ���пͷ���Ϣ(�鿴�ͷ���Ϣ�õ�,������)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public DataSet GetAllRoom(string message)
        {
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@message",message)
                };
                ds = sh.GetDataSet("GetAllRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        /// <summary>
        /// ��ѯ����״̬Ϊ���еķ���(ɾ���ͷ�ʱ�õ�)
        /// </summary>
        /// <returns></returns>
        public DataSet GetRoom()
        {
            try
            {
                ds = sh.GetDataSet("GetRoom");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        /// <summary>
        /// ɾ���ͷ���(���ݷ�����)
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public int DelRoom(string Number)
        {
            int count = 0;
            try
            {
                SqlParameter[] sp ={
                    para = new SqlParameter("@Number",Number)
                };
                count = sh.RunSql("DelRoom", sp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return count;
        }
    }
}
