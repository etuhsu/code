using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PublishDAO
    {
        SQLHelper sqlhepler = new SQLHelper();
        private DataSet ds;
        private SqlParameter para;
        //��ѯ���м�¼��
        public int GetAllPublishCount()
        {
            try
            {
                int count = sqlhepler.ReturnSQL("select count(*) from publish");
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //��ѯ������Ϣ����ҳ

        public DataSet GetPublishInfo(int start,int limit)
        {
            try
            {
                ds = sqlhepler.GetDataSet("select top " + limit + " * from publish where pubid not in(select top " + start + " pubid from publish order by pubid desc) order by pubid desc");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //����������Ϣ
        public int InsertPublishInfo(PublishBean pub)
        {
            try
            {
                SqlParameter[] sp ={
                   para=new SqlParameter("@pubperson",pub.pubperson),
                   para=new SqlParameter("@pubTitle",pub.pubTitle),
                   para=new SqlParameter("@pubContent",pub.pubContent)
                };
                int count = sqlhepler.RunProc("proc_InsertPublish",sp);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //�޸Ĺ�����Ϣ
        public int EditPublishInfo(PublishBean pub)
        {
            try
            {
                int count = sqlhepler.RunSQL("update publish set pubtitle='"+pub.pubTitle+"',pubcontent='"+pub.pubContent+"' where pubid="+pub.pubID);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //ɾ��������Ϣ
        public int DelPublishInfo(int pubid)
        {
            try
            {
                int count = sqlhepler.RunSQL("delete publish where pubid="+pubid);
                return count;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
