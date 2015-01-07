using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
//��Դ��������www.51aspx.com(����a����������)

namespace Res.DALFactory
{
    /// <summary>
    /// ����
    /// </summary>
    public class PointDataAccess
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
        public static Res.IDAL.IPoint CreatePoint()
        {

            string CacheKey = path + ".PointDAL";
            object objType = CreateObject(path, CacheKey);
            return (Res.IDAL.IPoint)objType;
        }
    }
}
