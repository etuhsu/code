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
        /// ���������ӻ����ȡ
        /// </summary>
        public static object CreateObject(string path, string CacheKey)
        {
            object objType = Res.Library.DataCache.GetCache(CacheKey);//�ӻ����ȡ
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(path).CreateInstance(CacheKey);//���䴴��
                    Res.Library.DataCache.SetCache(CacheKey, objType);// д�뻺��
                }
                catch
                {
                }
            }
            return objType;
        }
        /// <summary>
        /// ����BPRODUCT���ݲ�ӿ�
        /// </summary>
        public static Res.IDAL.ISr CreateSr()
        {

            string CacheKey = path + ".SrDAL";
            object objType = CreateObject(path, CacheKey);
            return (Res.IDAL.ISr)objType;
        }
    }
}
