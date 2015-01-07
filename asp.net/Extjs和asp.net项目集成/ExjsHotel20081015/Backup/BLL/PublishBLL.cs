using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class PublishBLL
    {
        PublishDAO dao = new PublishDAO();
        private DataSet ds;
        //��ѯ��ҳ
        public string GetPublishInfos(int start,int limit)
        {
            JSONHelper json = new JSONHelper();
            string jsons = "";
            json.success = true;
            ds = dao.GetPublishInfo(start, limit);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                json.AddItem("pubid",dr["pubid"].ToString());
                json.AddItem("pubperson", dr["pubperson"].ToString());
                json.AddItem("pubtitle", dr["pubtitle"].ToString());
                json.AddItem("pubdate", dr["pubdate"].ToString());
                json.AddItem("pubcontent", dr["pubcontent"].ToString());
                json.ItemOk();
            }
            json.totlalCount = dao.GetAllPublishCount();
            jsons = json.ToString();
            return jsons;
        }

        //����������Ϣ
        public int InsertPublishInfo(PublishBean pub)
        {
            return dao.InsertPublishInfo(pub);
        }

        //�޸Ĺ�����Ϣ
        public int EditPublishInfo(PublishBean pub)
        {
            return dao.EditPublishInfo(pub);
        }

        //ɾ��������Ϣ
        public int DelPublishInfo(int pubid)
        {
            return dao.DelPublishInfo(pubid);
        }
    }
}
