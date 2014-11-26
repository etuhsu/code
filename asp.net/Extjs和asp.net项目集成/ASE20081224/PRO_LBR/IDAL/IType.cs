using System;
using System.Collections.Generic;
using Res.Model;
using NetServ.Net.Json;
namespace Res.IDAL
{
    public interface IType
    {
        IList<NodeObj> GetCpuType();
        IList<NodeObj> GetMeyType();
        IList<NodeObj> GetHadType();
        IList<NodeObj> GetAtyType();
        IList<NodeObj> GetOsType();
        IList<NodeObj> GetSmoType();
        IList<NodeObj> GetStrType();
        IList<NodeObj> GetTepType();
        IList<NodeObj> GetLeeType();
        IList<NodeObj> GetOteType();
        IList<AppObj> GetAteType();
        IList<AppObj> GetAdsType();
        IList<NodeObj> GetDepartmentType();
        IList<NodeObj> GetLevelType();
        IList<NodeObj> GetRassortType();
        IList<NodeObj> GetSysType();
         IList<NodeObj> GetGroupType();
        IList<NodeObj> GetStatusType();

    }
}
