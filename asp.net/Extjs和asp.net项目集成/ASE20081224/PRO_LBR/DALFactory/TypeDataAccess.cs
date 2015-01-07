using System;
using System.Configuration;
using System.Reflection;
using System.Web;
using Res.IDAL;
namespace Res.DALFactory
{
    /// <summary>
    /// ���󹤳�ģʽ����DAL��
    /// web.config ��Ҫ�������ã�(���ù���ģʽ+�������+�������,ʵ�ֶ�̬������ͬ�����ݲ����ӿ�)  
    /// ���԰�����DAL��Ĵ����������DataAccess����
    /// <appSettings>  
    /// <add key="DAL" value="LiTianPing.SQLServerDAL" /> (����������ռ����ʵ���������Ϊ�Լ���Ŀ�������ռ�)
    /// </appSettings> 
    /// </summary>
    public sealed class TypeDataAccess
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
                { }
            }
            return objType;
        }
        /// <summary>
        /// ����RCITY���ݲ�ӿ�
        /// </summary>
        public static Res.IDAL.IType CreateType()
        {

            string CacheKey = path + ".TypeDAL";
            object objType = CreateObject(path, CacheKey);
            return (Res.IDAL.IType)objType;
        }
    }
}
