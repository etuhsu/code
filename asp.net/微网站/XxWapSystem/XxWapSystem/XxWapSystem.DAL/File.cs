using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Threading;

namespace XxWapSystem.DAL
{
    public class File
    {
        #region �ļ����Ʋ���

        /// <summary>
        /// ����ļ����ļ����Ƿ��ڹ涨����չ��֮��
        /// </summary>
        /// <param name="chkFileName">�������ļ���</param>
        /// <param name="AllowExt">�������չ������ʽ�磺 mp3|gif|mp4</param>
        /// <returns>��Ч������,����Ϊ��</returns>
        /// <remarks>����ͨ�� 2007-5-8 ����</remarks>
        public static bool isExtValid(string chkFileName, string AllowExt)
        {
            bool isValid = false;		//Ĭ��Ϊ��Ч
            string[] strAllowExt;
            strAllowExt = AllowExt.Split(new char[] { '|' });
            for (int i = 0; i < strAllowExt.Length; i++)
            {
                if (chkFileName.Substring(chkFileName.LastIndexOf(".") + 1).ToLower() == strAllowExt[i].ToLower())
                {
                    isValid = true;	//��ƥ����,���Ϊ��Ч
                    break;
                }
            }
            return isValid;
        }

        /// <summary>
        /// ��ȡ��������ļ���(yyyyMMddHHmmXXX),�����λΪ�����
        /// </summary>
        /// <returns>��������ص�����ļ���</returns>
        /// <remarks>����ͨ�� 2007-2-9</remarks>
        public static string GetRndName()
        {
            string strNow = DateTime.Now.ToString("yyyyMMddHHmm");
            int strRndNum = new Random(DateTime.Now.Millisecond).Next(1000, 9999);	//�����ֵ��Χ
            return (strNow + strRndNum.ToString());
        }


        /// <summary>
        /// ȡ���ļ���չ��(�ʺ��ڴ��ļ���)
        /// </summary>
        /// <param name="filename">�ļ���</param>
        /// <example>
        /// string filename = "aaa.aspx"; 
        /// string s = yyniit.Utility.File.GetFileExt(filename); 
        /// </example>
        /// <returns>�ļ�����չ��(�������)</returns>
        /// <remarks>����ͨ�� 2007-5-8 ����</remarks>
        public static string GetFileExt(string filename)
        {
            if (filename.IndexOf(".") < 0)
            {
                return "";
            }
            return filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
        }


        /// <summary>
        /// ȡ���ļ���չ��(�ʺ��ڴ��ļ�����·������֤�ļ��Ƿ���Ч��)
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        public static string GetFileType(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    FileInfo info = new FileInfo(path);
                    return info.Extension;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region �ļ����ݲ���

        /// <summary>
        /// ת��Ŀ¼�Ĵ�С��λ
        /// </summary>
        /// <param name="size">�ֽ���</param>
        /// <returns>��ʽ��֮����ļ���Ŀ¼�Ĵ�С(G,M,K,Bytes)</returns>
        public static string cSize(float size)
        {
            float rtnSize = size;
            if (size >= 0x40000000)
            {
                rtnSize = (rtnSize / ((long)0x40000000));
                return rtnSize.ToString("0.##") + " GB";
            }
            if (size >= 0x100000)
            {
                rtnSize = (rtnSize / ((long)0x100000));
                return rtnSize.ToString("0.##") + " MB";
            }
            if (size >= 0x400)
            {
                rtnSize = (rtnSize / ((long)0x400));
                return rtnSize.ToString("0.##") + " KB";
            }
            return (size + " �ֽ�");
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        public static bool CreateFile(string path)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        public static bool DeleteFile(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ��ȡ�ļ�������޸�ʱ��
        /// </summary>
        /// <param name="path">�ļ�·��</param>
        public static string GetLastFileModifyTime(string path)
        {
            string strModifyTime = "";
            try
            {
                if (System.IO.File.Exists(path))
                {
                    FileInfo info = new FileInfo(path);
                    strModifyTime = info.LastWriteTime.ToString();
                }
                else
                {
                    strModifyTime = "";
                }
            }
            catch (Exception)
            {
            }
            return strModifyTime.ToString();
        }
        /// <summary>
        /// ��ȡ�ı�����
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default2.aspx");  
        /// string s = yyniit.Utility.File.ReadFile(Path);
        /// </example>
        /// <param name="Path">�ļ�·��</param>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "��������Ӧ��Ŀ¼";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
            }
            return s;
        }

        /// <summary>
        /// д�ļ�
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default2.aspx");
        /// string Strings = "������д�����ݰ�";
        /// yyniit.Utility.File.WriteFile(Path,Strings);
        /// </example>
        /// <param name="Path">�ļ�·��</param>
        /// <param name="Strings">�ļ�����</param>
        public static void WriteFile(string Path, string Strings)
        {
            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, false, System.Text.Encoding.GetEncoding("gb2312"));
            f2.Write(Strings);
            f2.Close();
        }

        /// <summary>
        /// ׷���ļ�
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default2.aspx");   
        /// string Strings = "��׷������";
        /// yyniit.Utility.File.FileAppend(Path, Strings);
        ///</example>
        /// <param name="Path">�ļ�·��</param>
        /// <param name="strings">����</param>
        public static void FileAppend(string Path, string strings)
        {
            StreamWriter sw = System.IO.File.AppendText(Path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <example>
        /// string orignFile = Server.MapPath("Default2.aspx"); 
        /// string NewFile = Server.MapPath("Default3.aspx");
        /// yyniit.Utility.File.FileCoppy(OrignFile, NewFile);
        /// </example>
        /// <param name="OrignFile">ԭʼ�ļ�</param>
        /// <param name="NewFile">���ļ�·��</param>
        public static void FileCoppy(string OrignFile, string NewFile)
        {
            System.IO.File.Copy(OrignFile, NewFile, true);
        }

        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default3.aspx");  
        /// yyniit.Utility.File.FileDel(Path);
        /// </example>
        /// <param name="Path">·��</param>
        public static void FileDel(string Path)
        {
            System.IO.File.Delete(Path);
        }

        /// <summary>
        /// �ƶ��ļ�
        /// </summary>
        /// <example>
        /// string orignFile = Server.MapPath("../˵��.txt");
        /// string NewFile = Server.MapPath("../../˵��.txt");
        /// yyniit.Utility.File.FileMove(OrignFile, NewFile);
        /// </example>
        /// <param name="OrignFile">ԭʼ·��</param>
        /// <param name="NewFile">��·��</param>
        public static void FileMove(string OrignFile, string NewFile)
        {
            System.IO.File.Move(OrignFile, NewFile);
        }
        
        #endregion

        #region Ŀ¼��ز���

        /// <summary>
        /// �Զ������ϴ�Ŀ¼(�磺200601)
        /// </summary>
        /// <param name="strUploadPath">ָ���ϴ��ĸ�Ŀ¼(�磺վ��Ŀ¼�µ�UploadĿ¼)</param>
        /// <example>this.lblInfo.Text=ea.Common.UploadDir("Upload");</example>
        /// <returns>�Զ����ɵ�Ŀ¼��</returns>
        /// <remarks>����ͨ�� 2007-2-8</remarks>
        public static string GetUploadDir(string strUploadPath)
        {
            string strDirName = DateTime.Now.ToString("yyyyMM");
            try
            {
                DirectoryInfo info = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(strUploadPath));
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strUploadPath + "\\" + strDirName)))
                {
                    info.CreateSubdirectory(strDirName);
                    return (strUploadPath + "\\" + strDirName);
                }
                return (strUploadPath + "\\" + strDirName);
            }
            catch
            {
                return strUploadPath;
            }
        }

        /// <summary>
        /// �ڵ�ǰĿ¼�´���Ŀ¼
        /// </summary>
        /// <example>
        /// string orignDir = Server.MapPath("test/"); 
        /// string NewFloder = "new";
        /// yyniit.Utility.File.CreateDir(OrignDir, NewDir); 
        /// </example>
        /// <param name="OrignDir">��ǰĿ¼</param>
        /// <param name="NewDir">��Ŀ¼</param>
        public static void CreateDir(string OrignDir, string NewDir)
        {
            Directory.SetCurrentDirectory(OrignDir);
            Directory.CreateDirectory(NewDir);
        }


        /// <summary>
        /// ָ������·��ֱ�Ӵ���Ŀ¼
        /// </summary>
        /// <param name="path"></param>
        public static bool CreateDir(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// �ݹ�ɾ���ļ���Ŀ¼���ļ�
        /// </summary>
        /// <example>
        /// string dir = Server.MapPath("test/"); 
        /// yyniit.Utility.File.DeleteDir(dir);  
        /// </example>
        /// <param name="dir">�ļ���·��</param>
        public static void DeleteDir(string dir)
        {
            if (Directory.Exists(dir)) //�����������ļ���ɾ��֮ 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (System.IO.File.Exists(d))
                        System.IO.File.Delete(d); //ֱ��ɾ�����е��ļ� 
                    else
                        DeleteDir(d); //�ݹ�ɾ�����ļ��� 
                }
                Directory.Delete(dir); //ɾ���ѿ��ļ��� 
            }
        }


        /// <summary>
        /// ɾ��Ŀ¼
        /// </summary>
        /// <param name="path">Ŀ¼·��</param>
        /// <param name="child">�Ƿ�ɾ���κ���Ŀ¼</param>
        public static bool DeleteDir(string path, bool child)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, child);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// ��ָ���ļ����������������copy��Ŀ���ļ������棬��Ŀ���ļ���Ϊֻ�����Ծͻᱨ��
        /// </summary>
        /// <example>
        /// string srcPath = Server.MapPath("test/");
        /// string aimPath = Server.MapPath("test1/");
        /// yyniit.Utility.File.CopyDir(srcPath,aimPath);  
        /// </example>
        /// <param name="srcPath">ԭʼ·��</param>
        /// <param name="aimPath">Ŀ���ļ���</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // ���Ŀ��Ŀ¼�Ƿ���Ŀ¼�ָ��ַ�����������������֮
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // �ж�Ŀ��Ŀ¼�Ƿ����������������½�֮
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);
                // �õ�ԴĿ¼���ļ��б��������ǰ����ļ��Լ�Ŀ¼·����һ������
                //�����ָ��copyĿ���ļ�������ļ���������Ŀ¼��ʹ������ķ���
                //string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //�������е��ļ���Ŀ¼
                foreach (string file in fileList)
                {
                    //�ȵ���Ŀ¼��������������Ŀ¼�͵ݹ�Copy��Ŀ¼������ļ�

                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    //����ֱ��Copy�ļ�
                    else
                        System.IO.File.Copy(file, aimPath + Path.GetFileName(file), true);
                }

            }
            catch (Exception ee)
            {
                throw new Exception(ee.ToString());
            }
        }


        /// <summary>
        /// �ƶ�Ŀ¼
        /// </summary>
        /// <param name="oldPath">Դ·��</param>
        /// <param name="newPath">��·��</param>
        public static bool MoveDir(string oldPath, string newPath)
        {
            try
            {
                if (Directory.Exists(oldPath))
                {
                    Directory.Move(oldPath, newPath);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ��ȡĿ¼��С
        /// </summary>
        /// <param name="dirPath">����Ŀ¼��·��</param>
        /// <returns>Ŀ¼��С���ֽ���</returns>
        /// <remarks>��ֵ��ȷ,���Գɹ� 2007-2-9</remarks>
        public static long GetDirLength(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirLength(dis[i].FullName);	//�ݹ����
                }
            }
            return len;
        }

        #endregion
        /// <summary>
        /// �Զ����ɱ���Ŀ¼(�磺200601)
        /// </summary>
        /// <returns>�Զ����ɵ�Ŀ¼��</returns>
        public static bool GetDataBack(string strUploadPath)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(strUploadPath));
                info.Create();
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(strUploadPath)))
                {

                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
