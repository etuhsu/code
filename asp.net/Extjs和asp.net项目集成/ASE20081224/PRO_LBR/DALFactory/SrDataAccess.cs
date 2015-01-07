using System;
using System.Configuration;
using System.Reflection;
using System.Web;
using Res.IDAL;

namespace Res.DALFactory
{
    public class SrDataAccess
    {
        private static readonly string path = System.Configuration.ConfigurationManager.AppSettings["DAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string path, string CacheKey)
        {
            object objType = Res.Library.DataCache.GetCache(CacheKey);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(path).CreateInstance(CacheKey);//反射创建
                    Res.Library.DataCache.SetCache(CacheKey, objType);// 写入缓存
                }
                catch
                {
                }
            }
            return objType;
        }
        /// <summary>
        /// 创建BPRODUCT数据层接口
        /// </summary>
        public static Res.IDAL.ISr CreateSr()
        {

            string CacheKey = path + ".SrDAL";
            object objType = CreateObject(path, CacheKey);
            return (Res.IDAL.ISr)objType;
        }
    }
}
