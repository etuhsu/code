using System;
using System.Collections.Generic;
using Res.Model;
using Res.IDAL;
using System.Collections;
using System.Data.SqlClient;
using Res.DALFactory;

namespace Res.BLL
{
   public class ApplicationBLL
    {
        private readonly IApplication dal = Res.DALFactory.ApplicationDataAccess.CreateServer();
       public string GetUserByUser_id(string user_id)
       {
           return dal.GetUserByUser_id(user_id);
       }
       public int AddApplication(SqlTransaction trans ,Res.Model.ApplicationObj model,out int app_id)
       {
           return dal.AddApplication(trans,model,out app_id);
       }
       public string GetApplication(string strWhere)
       {
           return dal.GetApplication(strWhere);
       }
       public System.Data.DataSet DownApplication(string strWhere)
       {
           return dal.DownApplication(strWhere);
       }
       public int DelApplicationByAPP_ID(string[] IDList, string userid)
       {
           return dal.DelApplicationByAPP_ID( IDList,  userid);
       }
       public int DisponseApplication(string[] IDList, string userid)
       {
           return dal.DisponseApplication(IDList, userid);
       }
       public string QueryApplication(string strWhere)
       {
           return dal.QueryApplication(strWhere);
       }
       public int GetBoolDispose(string userid)
       {
          return dal.GetBoolDispose(  userid);
       }
    }
}
