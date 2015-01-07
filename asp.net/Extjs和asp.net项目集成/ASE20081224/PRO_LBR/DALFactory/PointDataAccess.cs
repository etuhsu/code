using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
//该源码下载自www.51aspx.com(５１aｓｐｘ．ｃｏｍ)

namespace Res.DALFactory
{
    /// <summary>
    /// 积分
    /// </summary>
    public class PointDataAccess
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
        public static Res.IDAL.IPoint CreatePoint()
        {

            string CacheKey = path + ".PointDAL";
            object objType = CreateObject(path, CacheKey);
            return (Res.IDAL.IPoint)objType;
        }
    }
}
