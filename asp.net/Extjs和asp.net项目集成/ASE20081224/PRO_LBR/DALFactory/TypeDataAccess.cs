using System;
using System.Configuration;
using System.Reflection;
using System.Web;
using Res.IDAL;
namespace Res.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口)  
    /// 可以把所有DAL类的创建放在这个DataAccess类里
    /// <appSettings>  
    /// <add key="DAL" value="LiTianPing.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class TypeDataAccess
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
                { }
            }
            return objType;
        }
        /// <summary>
        /// 创建RCITY数据层接口
        /// </summary>
        public static Res.IDAL.IType CreateType()
        {

            string CacheKey = path + ".TypeDAL";
            object objType = CreateObject(path, CacheKey);
            return (Res.IDAL.IType)objType;
        }
    }
}
