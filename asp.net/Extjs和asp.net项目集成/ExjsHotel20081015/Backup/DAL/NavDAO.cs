using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
//��Դ���׷���www.51aspx.com(��1����x������)

namespace DAL
{
    
    public class NavDAO
    {
        private DataSet ds;
        SQLHelper sqlhelper=new SQLHelper();

        //��ѯȨ�����˵���Ϣ
        public DataSet getDTreeInfo(int parentID)
        {
            ds = sqlhelper.GetDataSet("select * from nav where parentID="+parentID);
            return ds;
        }
    }
}
