using System;
using System.Collections.Generic;
using Res.Model;
using Res.IDAL;
using System.Collections;
using System.Data.SqlClient;
using Res.DALFactory;

namespace Res.BLL
{
   public class SrBLL
    {
       private readonly ISr dal = SrDataAccess.CreateSr();
       public int AddSrList(Res.Model.Sr_bsrObj model, out int sr_id)
       {
           return dal.AddSrList(model, out  sr_id);
       }
       public string GetSrList()
       {
           return dal.GetSrList();
       }
       public string GetSrStatus(string userStr)
       {
           return dal.GetSrStatus(userStr);
       }
       public int UpdateSRStatus(IList<Res.Model.ChildObj> clist, string userStr)
       {
           return dal.UpdateSRStatus(clist, userStr);
       }
       public int AddSrrelation(Res.Model.ChildObj model)
       {
           return dal.AddSrrelation(model);
       }
       public int GetNumOfSr_idGroup(int sr_id)
       {
           return dal.GetNumOfSr_idGroup(sr_id);
       }
       public string GetAllSRForModifyByOwner(string strWhere)
       {
           return dal.GetAllSRForModifyByOwner(strWhere);
       }
       public int UpdateSRList(Res.Model.Sr_bsrObj model)
       {
           return dal.UpdateSRList(model);
       }
    }
}
