using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using Res.Model;
using System.Text;
namespace Res.IDAL
{
    public interface IServer
    {
       int Add_ServerList(IList<Hashtable> lst_hash, string filename, string userId);
        int InsertEntryItems(SqlTransaction trans, string colName, string valueStr, string userStr, out int e_id);
        int AddServerMasterByAddServerList(SqlTransaction trans, Res.Model.BServerObj model, out int svs_id);
        string GetServerList(int pageSize, int pageNO, string strWhere);
        int DelServerListBySVS_ID(string[] IDList, String userid);
        string GetServerListForModify(int SVS_ID);
        System.Data.DataSet DownServerListALL(string whereStr);
        string GetMainMenu(string userStr);
        string GetServerList(string strWhere);
        int AddRServerByAddServerList(SqlTransaction trans, Res.Model.RServerObj model);
         int ModifyServerListBySVS_ID(SqlTransaction trans, Res.Model.BServerObj model);
         int ModifyRServerListBySVS_ID(SqlTransaction trans, Res.Model.RServerObj model);
    }
}
