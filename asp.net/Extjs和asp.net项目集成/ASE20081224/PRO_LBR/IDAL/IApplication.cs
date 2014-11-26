using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using Res.Model;
using System.Text;
namespace Res.IDAL
{
   public interface IApplication
    {
       string GetUserByUser_id(string user_id);
       int AddApplication(SqlTransaction trans, Res.Model.ApplicationObj model, out int app_id);
       string GetApplication(string strWhere);
       System.Data.DataSet DownApplication(string strWhere);
       int DelApplicationByAPP_ID(string[] IDList, string userid);
       int DisponseApplication(string[] IDList, string userid);
        string QueryApplication(string strWhere);
       int GetBoolDispose(string userid);
 
    }
     

    
}
