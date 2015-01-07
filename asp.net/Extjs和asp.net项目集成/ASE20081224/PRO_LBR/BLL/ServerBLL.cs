using System;
using System.Collections.Generic;
using Res.Model;
using Res.IDAL;
using System.Collections;
using System.Data.SqlClient;
using Res.DALFactory;

namespace Res.BLL
{
  public  class ServerBLL
    {
      private readonly IServer dal = ServerDataAccess.CreateServer();
        public int Add_ServerList(IList<Hashtable> lst_hash, string filename, string userId)
        {
            return dal.Add_ServerList(lst_hash, filename, userId);
        }
      public int InsertEntryItems(SqlTransaction trans, string colName, string valueStr, string userStr, out int e_id)
      {
          return dal.InsertEntryItems(trans, colName, valueStr, userStr, out  e_id);
      }
      public int AddServerMasterByAddServerList(SqlTransaction trans, Res.Model.BServerObj model, out int svs_id)
      {
          return dal.AddServerMasterByAddServerList(trans, model, out  svs_id);
      }
      public string GetServerList(int pageSize, int pageNO, string strWhere)
      {
          return dal.GetServerList(pageSize, pageNO, strWhere);
      }
      public int DelServerListBySVS_ID(string[] IDList,String  userid)
      {
          return dal.DelServerListBySVS_ID(IDList,userid);
      }
      public string GetServerListForModify(int SVS_ID)
      {
          return dal.GetServerListForModify(SVS_ID);
      }
      public int ModifyServerListBySVS_ID(SqlTransaction trans, Res.Model.BServerObj model)
      {
        return  dal.ModifyServerListBySVS_ID(trans, model);
      }
      public System.Data.DataSet DownServerListALL(string whereStr)
      {
          return dal.DownServerListALL( whereStr);
      }
      public string GetMainMenu(string userStr)
      {
          return dal.GetMainMenu(userStr);
      }
      public string GetServerList(string strWhere)
      {
          return dal.GetServerList(strWhere);
      }
      public int AddRServerByAddServerList(SqlTransaction trans, Res.Model.RServerObj model)
      {
          return dal.AddRServerByAddServerList(trans, model);
      }
      public int ModifyRServerListBySVS_ID(SqlTransaction trans, Res.Model.RServerObj model)
      {
          return dal.ModifyRServerListBySVS_ID(trans, model);
      }
    }
}
