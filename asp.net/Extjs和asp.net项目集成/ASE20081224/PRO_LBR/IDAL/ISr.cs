using System;
using System.Collections.Generic;
using Res.Model;
using NetServ.Net.Json;

namespace Res.IDAL
{
   public interface ISr
    {
       int AddSrList(Res.Model.Sr_bsrObj model, out int sr_id);
       string GetSrList();
       string GetSrStatus(string userStr);
       int UpdateSRStatus(IList<Res.Model.ChildObj> clist, string userStr);
        int AddSrrelation(Res.Model.ChildObj model);
       int GetNumOfSr_idGroup(int sr_id);
       string GetAllSRForModifyByOwner(string strWhere);
       int UpdateSRList(Res.Model.Sr_bsrObj model);

    }
}
