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
        #region 文件名称操作

        /// <summary>
        /// 检查文件的文件名是否在规定的扩展名之内
        /// </summary>
        /// <param name="chkFileName">被检查的文件名</param>
        /// <param name="AllowExt">允许的扩展名，格式如： mp3|gif|mp4</param>
        /// <returns>有效返回真,否则为假</returns>
        /// <remarks>测试通过 2007-5-8 吴彬豪</remarks>
        public static bool isExtValid(string chkFileName, string AllowExt)
        {
            bool isValid = false;		//默认为无效
            string[] strAllowExt;
            strAllowExt = AllowExt.Split(new char[] { '|' });
            for (int i = 0; i < strAllowExt.Length; i++)
            {
                if (chkFileName.Substring(chkFileName.LastIndexOf(".") + 1).ToLower() == strAllowExt[i].ToLower())
                {
                    isValid = true;	//有匹配项,标记为有效
                    break;
                }
            }
            return isValid;
        }

        /// <summary>
        /// 获取随机日期文件名(yyyyMMddHHmmXXX),最后三位为随机数
        /// </summary>
        /// <returns>与日期相关的随机文件名</returns>
        /// <remarks>测试通过 2007-2-9</remarks>
        public static string GetRndName()
        {
            string strNow = DateTime.Now.ToString("yyyyMMddHHmm");
            int strRndNum = new Random(DateTime.Now.Millisecond).Next(1000, 9999);	//随机数值范围
            return (strNow + strRndNum.ToString());
        }


        /// <summary>
        /// 取得文件扩展名(适合于传文件名)
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <example>
        /// string filename = "aaa.aspx"; 
        /// string s = yyniit.Utility.File.GetFileExt(filename); 
        /// </example>
        /// <returns>文件的扩展名(不含点号)</returns>
        /// <remarks>测试通过 2007-5-8 吴彬豪</remarks>
        public static string GetFileExt(string filename)
        {
            if (filename.IndexOf(".") < 0)
            {
                return "";
            }
            return filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
        }


        /// <summary>
        /// 取得文件扩展名(适合于传文件具体路径并验证文件是否有效！)
        /// </summary>
        /// <param name="path">文件路径</param>
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

        #region 文件数据操作

        /// <summary>
        /// 转换目录的大小单位
        /// </summary>
        /// <param name="size">字节数</param>
        /// <returns>格式化之后的文件或目录的大小(G,M,K,Bytes)</returns>
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
            return (size + " 字节");
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="path">文件路径</param>
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
        /// 删除文件
        /// </summary>
        /// <param name="path">文件路径</param>
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
        /// 获取文件的最后修改时间
        /// </summary>
        /// <param name="path">文件路径</param>
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
        /// 读取文本内容
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default2.aspx");  
        /// string s = yyniit.Utility.File.ReadFile(Path);
        /// </example>
        /// <param name="Path">文件路径</param>
        public static string ReadFile(string Path)
        {
            string s = "";
            if (!System.IO.File.Exists(Path))
                s = "不存在相应的目录";
            else
            {
                StreamReader f2 = new StreamReader(Path, System.Text.Encoding.GetEncoding("gb2312"));
                s = f2.ReadToEnd();
                f2.Close();
            }
            return s;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default2.aspx");
        /// string Strings = "这是我写的内容啊";
        /// yyniit.Utility.File.WriteFile(Path,Strings);
        /// </example>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
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
        /// 追加文件
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default2.aspx");   
        /// string Strings = "新追加内容";
        /// yyniit.Utility.File.FileAppend(Path, Strings);
        ///</example>
        /// <param name="Path">文件路径</param>
        /// <param name="strings">内容</param>
        public static void FileAppend(string Path, string strings)
        {
            StreamWriter sw = System.IO.File.AppendText(Path);
            sw.Write(strings);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <example>
        /// string orignFile = Server.MapPath("Default2.aspx"); 
        /// string NewFile = Server.MapPath("Default3.aspx");
        /// yyniit.Utility.File.FileCoppy(OrignFile, NewFile);
        /// </example>
        /// <param name="OrignFile">原始文件</param>
        /// <param name="NewFile">新文件路径</param>
        public static void FileCoppy(string OrignFile, string NewFile)
        {
            System.IO.File.Copy(OrignFile, NewFile, true);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <example>
        /// string Path = Server.MapPath("Default3.aspx");  
        /// yyniit.Utility.File.FileDel(Path);
        /// </example>
        /// <param name="Path">路径</param>
        public static void FileDel(string Path)
        {
            System.IO.File.Delete(Path);
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <example>
        /// string orignFile = Server.MapPath("../说明.txt");
        /// string NewFile = Server.MapPath("../../说明.txt");
        /// yyniit.Utility.File.FileMove(OrignFile, NewFile);
        /// </example>
        /// <param name="OrignFile">原始路径</param>
        /// <param name="NewFile">新路径</param>
        public static void FileMove(string OrignFile, string NewFile)
        {
            System.IO.File.Move(OrignFile, NewFile);
        }
        
        #endregion

        #region 目录相关操作

        /// <summary>
        /// 自动生成上传目录(如：200601)
        /// </summary>
        /// <param name="strUploadPath">指定上传的根目录(如：站点目录下的Upload目录)</param>
        /// <example>this.lblInfo.Text=ea.Common.UploadDir("Upload");</example>
        /// <returns>自动生成的目录名</returns>
        /// <remarks>测试通过 2007-2-8</remarks>
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
        /// 在当前目录下创建目录
        /// </summary>
        /// <example>
        /// string orignDir = Server.MapPath("test/"); 
        /// string NewFloder = "new";
        /// yyniit.Utility.File.CreateDir(OrignDir, NewDir); 
        /// </example>
        /// <param name="OrignDir">当前目录</param>
        /// <param name="NewDir">新目录</param>
        public static void CreateDir(string OrignDir, string NewDir)
        {
            Directory.SetCurrentDirectory(OrignDir);
            Directory.CreateDirectory(NewDir);
        }


        /// <summary>
        /// 指定任意路径直接创建目录
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
        /// 递归删除文件夹目录及文件
        /// </summary>
        /// <example>
        /// string dir = Server.MapPath("test/"); 
        /// yyniit.Utility.File.DeleteDir(dir);  
        /// </example>
        /// <param name="dir">文件夹路径</param>
        public static void DeleteDir(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (System.IO.File.Exists(d))
                        System.IO.File.Delete(d); //直接删除其中的文件 
                    else
                        DeleteDir(d); //递归删除子文件夹 
                }
                Directory.Delete(dir); //删除已空文件夹 
            }
        }


        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="path">目录路径</param>
        /// <param name="child">是否删除任何子目录</param>
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
        /// 将指定文件夹下面的所有内容copy到目标文件夹下面，若目标文件夹为只读属性就会报错。
        /// </summary>
        /// <example>
        /// string srcPath = Server.MapPath("test/");
        /// string aimPath = Server.MapPath("test1/");
        /// yyniit.Utility.File.CopyDir(srcPath,aimPath);  
        /// </example>
        /// <param name="srcPath">原始路径</param>
        /// <param name="aimPath">目标文件夹</param>
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(aimPath))
                    Directory.CreateDirectory(aimPath);
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                //如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                //string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                //遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    //先当作目录处理如果存在这个目录就递归Copy该目录下面的文件

                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    //否则直接Copy文件
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
        /// 移动目录
        /// </summary>
        /// <param name="oldPath">源路径</param>
        /// <param name="newPath">新路径</param>
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
        /// 获取目录大小
        /// </summary>
        /// <param name="dirPath">具体目录的路径</param>
        /// <returns>目录大小的字节数</returns>
        /// <remarks>数值精确,测试成功 2007-2-9</remarks>
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
                    len += GetDirLength(dis[i].FullName);	//递归调用
                }
            }
            return len;
        }

        #endregion
        /// <summary>
        /// 自动生成备份目录(如：200601)
        /// </summary>
        /// <returns>自动生成的目录名</returns>
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
