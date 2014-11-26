using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;



namespace DAL
{
    public class TotalInfoDAO
    {
        SQLHelper sqlhelper = new SQLHelper();
        private DataSet ds;
        //���������Ϣ
        public int SaveRoomMoney(TotalInfoBean total)
        {
            try
            {
                int count = sqlhelper.RunSQL("insert into totalinfo values('����',"+total.totalMoney+",default,'"+total.totalRemark+"')");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //�ܼ�¼��
        public int GetAllCount()
        {
            try
            {
                int count = sqlhelper.ReturnSQL("select count(*) from totalinfo");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //�õ�������Ϣ��ҳ

        public DataSet GetToltalInfo(int start,int limit)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select top "+limit+" * from totalinfo where totalid not in(select top "+start+" totalid from totalinfo order by totaltime desc) order by totaltime desc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //��ѯ��ʼʱ��
        public string GetStartTime()
        {
            try
            {
                ds=sqlhelper.GetDataSet("Select CONVERT(varchar(100), (select top 1 totaltime from totalinfo order by totaltime asc), 121)");
                string starts=ds.Tables[0].Rows[0][0].ToString();
                return starts;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        //����ʱ��
        public string GetEndTime()
        {
            try
            {
                ds = sqlhelper.GetDataSet("Select CONVERT(varchar(100), (select top 1 totaltime from totalinfo order by totaltime desc), 121)");
                string endtime = ds.Tables[0].Rows[0][0].ToString();
                return endtime;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       


        //��ѯ���ڶ���Ϣ����ҳ
        public DataSet GetSTandETinfo(string starttime,string endtime)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select * from totalinfo where totaltime between '" + starttime + "' and  '" + endtime + "' order by totaltime desc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //�������ڶ�����
        public string GetAllMoney(string starttime, string endtime)
        {
            try
            {
                ds = sqlhelper.GetDataSet("select sum(totalmoney) from TotalInfo where totaltime between '"+starttime+"' and  '"+endtime+"'");
                string total = "";
                total=ds.Tables[0].Rows[0][0].ToString();
                if(total.Trim().Length==0)
                {
                    total = "false";
                }
                
                return total;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
