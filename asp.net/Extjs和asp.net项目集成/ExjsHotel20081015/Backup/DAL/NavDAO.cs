using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;
//该源码首发自www.51aspx.com(５1ａｓｐx．ｃｏｍ)

namespace DAL
{
    
    public class NavDAO
    {
        private DataSet ds;
        SQLHelper sqlhelper=new SQLHelper();

        //查询权限树菜单信息
        public DataSet getDTreeInfo(int parentID)
        {
            ds = sqlhelper.GetDataSet("select * from nav where parentID="+parentID);
            return ds;
        }
    }
}
