using System;
using System.Collections.Generic;
using Res.Model;
using Res.IDAL;
using Res.DALFactory;
using NetServ.Net.Json;
namespace Res.BLL
{
    public class TypeBLL
    {
        private readonly IType dal = TypeDataAccess.CreateType();
        public IList<NodeObj> GetCpuType()
        {
            return dal.GetCpuType();
        }
        public IList<NodeObj> GetMeyType()
        {
            return dal.GetMeyType();
        }
        public IList<NodeObj> GetSmoType()
        {
            return dal.GetSmoType();
        }
        public IList<NodeObj> GetHadType()
        {
            return dal.GetHadType();
        }
        public IList<NodeObj> GetAtyType()
        {
            return dal.GetAtyType();
        }
        public IList<NodeObj> GetOstype()
        {
            return dal.GetOsType();
        }
        public IList<NodeObj> GetStrType()
        {
            return dal.GetStrType();
        }
        public IList<NodeObj> GetTepType()
        {
            return dal.GetTepType();
        }
        public IList<NodeObj> GetLeeType()
        {
            return dal.GetLeeType();
        }
        public IList<NodeObj> GetOteType()
        {
            return dal.GetOteType();
        }
        public IList<AppObj> GetAteType()
        {
            return dal.GetAteType();
        }
        public IList<AppObj> GetAdsType()
        {
            return dal.GetAdsType();
        }
        public IList<NodeObj> GetDepartmentType()
        {
            return dal.GetDepartmentType();
        }
        public IList<NodeObj> GetLevelType()
        {
            return dal.GetLevelType();
        }
        public IList<NodeObj> GetRassortType()
        {
            return dal.GetRassortType();
        }
        public IList<NodeObj> GetSysType()
        {
            return dal.GetSysType();
        }
        public IList<NodeObj> GetGroupType()
        {
            return dal.GetGroupType();
        }
        public IList<NodeObj> GetStatusType()
        {
            return dal.GetStatusType();
        }
        //城市信息
        /*  public IList<NodeObj> GetCpuType()
          {
              string CacheKey = "GetCpuType";
              object objModel = Res.Library.DataCache.GetCache(CacheKey);
              if (objModel == null)
              {
                  objModel = dal.GetCpuType();
                  if (objModel != null)
                  {
                      int ModelCache = Res.Library.ConfigHelper.GetConfigInt("TypeModelCache");
                      Res.Library.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                  }
              }
              return (IList<NodeObj>)objModel;

          }
          //GetCpuTypeJson  GetMeyTypeJson  GetHadTypeJson GetAtyTypeJson  GetOstypeJson
          public IList<NodeObj> GetMeyType()
          {
              string CacheKey = "GetMeyType";
              object objModel = Res.Library.DataCache.GetCache(CacheKey);
              if (objModel == null)
              {
                  objModel = dal.GetMeyType();
                  if (objModel != null)
                  {
                      int ModelCache = Res.Library.ConfigHelper.GetConfigInt("TypeModelCache");
                      Res.Library.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                  }
              }
              return (IList<NodeObj>)objModel;

          }
           public IList<NodeObj> GetStrType()
          {
              string CacheKey = "GetStrType";
              object objModel = Res.Library.DataCache.GetCache(CacheKey);
              if (objModel == null)
              {
                  objModel = dal.GetStrType();
                  if (objModel != null)
                  {
                      int ModelCache = Res.Library.ConfigHelper.GetConfigInt("TypeModelCache");
                      Res.Library.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                  }
              }
              return (IList<NodeObj>)objModel;

          }
          public IList<NodeObj> GetSmoType()
          {
              string CacheKey = "GetSmoType";
              object objModel = Res.Library.DataCache.GetCache(CacheKey);
              if (objModel == null)
              {
                  objModel = dal.GetSmoType();
                  if (objModel != null)
                  {
                      int ModelCache = Res.Library.ConfigHelper.GetConfigInt("TypeModelCache");
                      Res.Library.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                  }
              }
              return (IList<NodeObj>)objModel;

          }
          public IList<NodeObj> GetHadType()
          {
              string CacheKey = "GetHadType";
              object objModel = Res.Library.DataCache.GetCache(CacheKey);
              if (objModel == null)
              {
                  objModel = dal.GetHadType();
                  if (objModel != null)
                  {
                      int ModelCache = Res.Library.ConfigHelper.GetConfigInt("TypeModelCache");
                      Res.Library.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                  }
              }
              return (IList<NodeObj>)objModel;

          }
          public IList<NodeObj> GetAtyType()
          {
              string CacheKey = "GetAtyType";
              object objModel = Res.Library.DataCache.GetCache(CacheKey);
              if (objModel == null)
              {
                  objModel = dal.GetAtyType();
                  if (objModel != null)
                  {
                      int ModelCache = Res.Library.ConfigHelper.GetConfigInt("TypeModelCache");
                      Res.Library.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                  }
              }
              return (IList<NodeObj>)objModel;

          }
          public IList<NodeObj> GetOstype()
          {
              string CacheKey = "GetOstype";
              object objModel = Res.Library.DataCache.GetCache(CacheKey);
              if (objModel == null)
              {
                  objModel = dal.GetOsType();
                  if (objModel != null)
                  {
                      int ModelCache = Res.Library.ConfigHelper.GetConfigInt("TypeModelCache");
                      Res.Library.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                  }
              }
              return (IList<NodeObj>)objModel;

          }
          */

    }

}
