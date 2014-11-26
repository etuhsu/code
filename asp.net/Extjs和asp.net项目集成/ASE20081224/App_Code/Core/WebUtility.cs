using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Xml;
using System.Text;
using System.Net.Mail;
using System.Web.Mail;
using System.Threading;
using System.Web.Caching;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// WebUtility 的摘要说明


/// </summary>
public class WebUtility
{
    public WebUtility()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static string InputText(string text, int maxLength)
    {
        if (text == null)
            return string.Empty;
        text = text.Trim();
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        if (text.Length > maxLength)
            text = text.Substring(0, maxLength);
        text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
        text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
        text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
        text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);	//any other tags
        text = text.Replace("'", "''");
        return text;
    }
    public static decimal InputDecimal(string text)
    {
        decimal result = 0;
        if (decimal.TryParse(text, out result) == true)
            return result;
        else
            return 0;
    }
    public static int InputInt(string text)
    {
        int result = 0;
        if (int.TryParse(text, out result) == true)
            return result;
        else
            return 0;
    }
    public static double InputDouble(string text)
    {
        double result = 0;
        if (double.TryParse(text, out result) == true)
            return result;
        else
            return 0;
    }
    public static float InputFloat(string text)
    {
        float result = 0;
        if (float.TryParse(text, out result) == true)
            return result;
        else
            return 0;
    }
    /// <summary>
    /// 是否全是正整数





    /// </summary>
    /// <param name="Input"></param>
    /// <param name="Plus"></param>
    /// <returns></returns>
    public static bool IsInteger(string Input, bool Plus)
    {
        if (Input == null)
        {
            return false;
        }
        else
        {
            string pattern = "^-?[0-9]+$";
            if (Plus)
                pattern = "^[0-9]+$";
            if (Regex.Match(Input, pattern, RegexOptions.Compiled).Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public static string HtmlText(string text)
    {
        if (text == null)
        {
            return string.Empty;
        }
        else
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text) == true)
                return string.Empty;
            if (text.Length > 8000)
            {
                text = text.Substring(0, 8000);
            }
            return text;
        }
    }
    /// <summary>
    /// 图片缩略制作
    /// </summary>
    /// <param name="filename">图片文件名称</param>
    /// <param name="targetSize">图片宽度</param>
    /// <param name="str">图片水印字符串</param>
    /// <returns></returns>
    public static byte[] ReSizeImageFile(string filename, int targetSize, string str)
    {
        System.Drawing.Image oldimage = System.Drawing.Image.FromFile(filename);
        Size newSize = CalculateDimensions(oldimage.Size, targetSize);//Format24bpprgb
        Bitmap newimage = new Bitmap(newSize.Width, newSize.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        Graphics canvas = Graphics.FromImage(newimage);
        canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        canvas.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //   canvas.DrawImage(oldimage, new Point(0, 0));//newSize
        // canvas.Clear(Color.Transparent); 

        canvas.DrawImage(oldimage, new Rectangle(0, 0, newSize.Width, newSize.Height), new Rectangle(0, 0, oldimage.Size.Width, oldimage.Size.Height), GraphicsUnit.Pixel);

        /* Font f = new Font("Verdana", 16);//
         Brush b = new SolidBrush(Color.LightGray);
         string addText = str;//要加的水印的文字
         canvas.DrawString(addText, f, b, 20, newSize.Height - 20); //给我加水印文字*/

        MemoryStream m = new MemoryStream();
        newimage.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
        return m.GetBuffer();
    }
    /// <summary>
    /// 根据输入的图片宽度和图片默认规格获取缩略的图片规格







    /// </summary>
    /// <param name="oldSize">图片默认规格</param>
    /// <param name="targetSize">图片宽度</param>
    /// <returns></returns>
    private static Size CalculateDimensions(Size oldSize, int targetSize)
    {

        Size newSize = new Size();
        if (oldSize.Height > oldSize.Width)
        {
            newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
            newSize.Height = targetSize;
        }
        else
        {
            newSize.Width = targetSize;
            newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
        }
        return newSize;
    }
    /// <summary>
    /// 查询集合被删除的数据集







    /// </summary>
    /// <param name="lstx">初始数据集</param>
    /// <param name="lsty">结果数据集</param>
    /// <returns></returns>
    public static IList<int> GetRemoveItems(IList<int> lstx, IList<int> lsty)
    {
        if (lsty == null || lsty.Count <= 0)
        {
            return lstx;
        }
        if (lstx == null || lstx.Count <= 0)
        {
            return lstx;
        }
        IList<int> lst_res = new List<int>();
        for (int i = 0; i < lstx.Count; i++)
        {
            if (lsty.Contains(lstx[i]) == false)
            {
                lst_res.Add(lstx[i]);
            }
        }
        return lst_res;
    }
    /// <summary>
    /// 查询集合新增的数据集
    /// </summary>
    /// <param name="lstx">初始数据集</param>
    /// <param name="lsty">结果数据集</param>
    /// <returns></returns>
    public static IList<int> GetAddItems(IList<int> lstx, IList<int> lsty)
    {

        if (lstx == null || lstx.Count <= 0)
        {
            return lsty;
        }
        if (lsty == null || lsty.Count <= 0)
        {
            return lsty;
        }
        IList<int> lst_res = new List<int>();
        for (int i = 0; i < lsty.Count; i++)
        {
            if (lstx.Contains(lsty[i]) == false)
            {
                lst_res.Add(lsty[i]);  //新的要添加的东西
            }
        }
        return lst_res;
    }

    #region md5加密码







    public static string MD5(string str)
    {
        return EncryptMD5ToHexString(str, System.Text.Encoding.UTF8.CodePage);
    }
    public static string EncryptMD5ToHexString(string s, int EncodingCodePage)
    {
        if (s == null || s == "") return null;
        return ByteArrayToHexString(EncryptMD5ToByteArray(s, EncodingCodePage));
    }
    public static string ByteArrayToHexString(byte[] ba)
    {
        string r = "";
        string s = "";
        for (long l = 0; l < ba.Length; l++)
        {
            byte b = (byte)(ba.GetValue(l));
            s = Convert.ToString(b, 16);
            if (s.Length < 2) s = "0" + s;
            r += s;
        }
        return r;
    }
    public static byte[] EncryptMD5ToByteArray(string s, int EncodingCodePage)
    {
        return EncryptMD5ToByteArray(StringToByteArray(s, EncodingCodePage));
    }
    public static byte[] EncryptMD5ToByteArray(byte[] ba)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider oMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] r = oMD5.ComputeHash(ba);
        oMD5 = null;
        return r;
    }
    public static byte[] StringToByteArray(string s, int EncodingCodePage)
    {
        return System.Text.Encoding.GetEncoding(EncodingCodePage).GetBytes(s);
    }
    /// <summary>
    /// 获取主菜单


    /// </summary>
    /// <returns></returns>
    public static string GetMenuString()
    {
        return "";
        /* string filename = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/webmap.xml");
         CacheDependency dep = new CacheDependency(filename);
         System.Web.Caching.Cache cache = HttpRuntime.Cache;
         if (dep.HasChanged == true || cache["MenuString"] == null)
         {
             XmlDocument doc = new XmlDocument();
             doc.Load(filename);
             StringBuilder Res = new StringBuilder();
             Res.Append("<div class=\"menu\">");
             Res.Append("<ul class=\"clearfix\">");
             foreach (XmlNode node in doc.SelectSingleNode("siteMap").ChildNodes)
             {
                 Res.Append("<li><a class=\"hide\" href=\"" + node.Attributes.GetNamedItem("url").Value + "\"><b>" + node.Attributes.GetNamedItem("title").Value + "</b></a>");
                 Res.Append("<!--[if lte IE 6]>");
                 Res.Append("<a href=\"" + node.Attributes.GetNamedItem("url").Value + "\"><b>" + node.Attributes.GetNamedItem("title").Value + "</li>");
                 Res.Append("<table><tr><td>");
                 Res.Append("<![endif]-->");
                 Res.Append("<ul>");
                 foreach (XmlNode child in node.ChildNodes)
                 {
                     Res.Append("<li><a class=\"hide\" href=\"" + child.Attributes.GetNamedItem("url").Value + "\">" + child.Attributes.GetNamedItem("title").Value + " &gt;</a>");
                     Res.Append("<!--[if lte IE 6]>");
                     Res.Append("<a class=\"sub\" href=\"" + child.Attributes.GetNamedItem("url").Value + "\">" + child.Attributes.GetNamedItem("title").Value + " &gt");
                     Res.Append("<table><tr><td>");
                     Res.Append("<![endif]-->");
                     Res.Append("<ul>");
                     foreach (XmlNode leaf in child.ChildNodes)
                     {
                         Res.Append("<li><a href=\"" + leaf.Attributes.GetNamedItem("url").Value + "?pct_id=" + leaf.Attributes.GetNamedItem("id").Value + "\">" + leaf.Attributes.GetNamedItem("title").Value + "</a></li>");
                     }
                     Res.Append("</ul>");
                     Res.Append("<!--[if lte IE 6]>");
                     Res.Append("</td></tr></table>");
                     Res.Append("</a>");
                     Res.Append("<![endif]-->");
                     Res.Append("</li>");
                 }
                 Res.Append("</ul>");
                 Res.Append("<!--[if lte IE 6]>");
                 Res.Append("</td></tr></table>");
                 Res.Append("</a>");
                 Res.Append("<![endif]-->");
                 Res.Append("</li>");
             }
             Res.Append("</ul>");
             Res.Append("</div>");
             cache.Insert("MenuString", Res.ToString(), dep);
             return Res.ToString();
         }
         else
         {
             string result = cache["MenuString"].ToString();
             return result;
         }*/
    }
    public static string GetLeftString()
    {
        string filename = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/webmap.xml");
        CacheDependency dep = new CacheDependency(filename);
        System.Web.Caching.Cache cache = HttpRuntime.Cache;
        if (dep.HasChanged == true || cache["LeftString"] == null)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            StringBuilder res = new StringBuilder();
            res.Append("<div id=\"left\">");
            foreach (XmlNode node in doc.SelectSingleNode("siteMap").ChildNodes)
            {
                res.Append("<div class=\"main_tit\"><p><a href=\"ListLine.aspx?prl_name=" + node.Attributes.GetNamedItem("title").Value + "\">" + node.Attributes.GetNamedItem("title").Value + "</a></p></div>");
                res.Append("<div class=\"wrap\">");
                if (node.ChildNodes.Count > 0)
                {
                    res.Append("<ul class=\"menu\">");
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        res.Append("<li><a href=\"" + child.Attributes.GetNamedItem("url").Value + "\">" + child.Attributes.GetNamedItem("title").Value + "</a>");
                        if (child.ChildNodes.Count > 0)
                        {
                            res.Append("<ul>");
                            foreach (XmlNode leaf in child.ChildNodes)
                            {
                                res.Append("<li><a href=\"" + leaf.Attributes.GetNamedItem("url").Value + "\">" + leaf.Attributes.GetNamedItem("title").Value + "</a></li>");
                            }
                            res.Append("</ul>");
                        }
                        res.Append("</li>");
                    }
                    res.Append("</ul>");
                }
                res.Append("</div>");
            }
            res.Append("</div>");
            cache.Insert("LeftString", res.ToString(), dep);
            return res.ToString();
        }
        else
        {
            string result = cache["LeftString"].ToString();
            return result;
        }
    }
    public static string GetLeftDetailString()
    {
        string filename = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/webmap.xml");
        CacheDependency dep = new CacheDependency(filename);
        System.Web.Caching.Cache cache = HttpRuntime.Cache;
        if (dep.HasChanged == true || cache["LeftDetailString"] == null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            StringBuilder Res = new StringBuilder();
            Res.Append("<div id=\"left_b\">");
            Res.Append("\r\n");
            int count = 0;
            foreach (XmlNode node in doc.SelectSingleNode("siteMap").ChildNodes)
            {
                if (count == 0)
                    Res.Append("<div class=\"nav\"><a href=\"ListLine.aspx?prl_name=" + node.Attributes.GetNamedItem("title").Value + "\">" + node.Attributes.GetNamedItem("title").Value + "</a></div>");
                else
                    Res.Append("<div style=\"margin-top: 20px;\" class=\"nav_s\"><a href=\"ListLine.aspx?prl_name=" + node.Attributes.GetNamedItem("title").Value + "\">" + node.Attributes.GetNamedItem("title").Value + "</a></div>");

                Res.Append("\r\n");
                count++;
                int i = 0;
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.ChildNodes.Count > 0)
                    {
                        Res.Append("<p style=\"margin: 5px 0 5px 30px;\"><a href=\"ListCategory.aspx?pct_id=" + child.Attributes.GetNamedItem("id").Value + "\">" + child.Attributes.GetNamedItem("title").Value + "</a></p>");
                        Res.Append("<div style=\"text-align:center;\"><img src=\"img/dashed.gif\" width=\"142\" height=\"1\" /></div>");
                        Res.Append("<div style=\"text-align: center;\" class=\"subline\">");
                        Res.Append("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" align=\"center\" width=\"120\">");
                        int j = 0;
                        foreach (XmlNode leaf in child.ChildNodes)
                        {
                            if (j % 2 == 0)
                            {
                                if (j < child.ChildNodes.Count - 1)
                                {
                                    Res.Append("<tr>");
                                    Res.Append("<td align=\"right\" width=\"50\"><a href=\"ListHeader.aspx?pct_id=" + leaf.Attributes.GetNamedItem("id").Value + "\">" + leaf.Attributes.GetNamedItem("title").Value + "</a></td>");
                                    Res.Append("<td align=\"center\" width=\"20\">&nbsp;|&nbsp;</td>");
                                }
                                else
                                {
                                    Res.Append("<tr>");
                                    Res.Append("<td align=\"right\" width=\"50\"><a href=\"ListHeader.aspx?pct_id=" + leaf.Attributes.GetNamedItem("id").Value + "\">" + leaf.Attributes.GetNamedItem("title").Value + "</a></td>");
                                    Res.Append("<td align=\"center\" width=\"20\">&nbsp;|&nbsp;</td>");
                                    Res.Append("</tr>");
                                }
                            }
                            else
                            {
                                Res.Append("<td align=\"left\" width=\"50\"><a href=\"ListHeader.aspx?pct_id=" + leaf.Attributes.GetNamedItem("id").Value + "\">" + leaf.Attributes.GetNamedItem("title").Value + "</a></td></tr>");
                            }
                            j++;
                        }
                        Res.Append("</table>");
                        Res.Append("</div>");
                        Res.Append("<div><img src=\"img/line.gif\" width=\"186\" height=\"1\" /></div>");
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Res.Append("<p style=\"margin-top: 5px;\"><a href=\"ListCategory.aspx?pct_id=" + child.Attributes.GetNamedItem("id").Value + "\">" + child.Attributes.GetNamedItem("title").Value + "</a></p>");
                            Res.Append("<div><img src=\"img/border.gif\" width=\"150\" height=\"14\" /></div>");

                        }
                        else
                        {
                            Res.Append("<p style=\"margin-top: 5px;\"><a href=\"ListCategory.aspx?pct_id=" + child.Attributes.GetNamedItem("id").Value + "\">" + child.Attributes.GetNamedItem("title").Value + "</a></p>");
                            Res.Append("<div><img src=\"img/border.gif\" width=\"150\" height=\"14\" /></div>");
                        }
                    }

                    i++;
                }
            }
            Res.Append("</div>");
            Res.Append("\r\n");
            cache.Insert("LeftDetailString", Res.ToString(), dep);
            return Res.ToString();
        }
        else
        {
            string result = cache["LeftDetailString"].ToString();
            return result;
        }
    }
    /// <summary>
    /// 同步发送邮件





    /// </summary>
    /// <param name="message"></param>
   /* public static void SendMailMessage(System.Web.Mail.MailMessage message, string username)
    {
        if (message == null)
            throw new ArgumentNullException("message");

        try
        {
            string Mail_Server = System.Configuration.ConfigurationManager.AppSettings["Mail_Server"].ToString();
            string Mail_Address = System.Configuration.ConfigurationManager.AppSettings["Mail_Address"].ToString();
            string Mail_Username = System.Configuration.ConfigurationManager.AppSettings["Mail_Username"].ToString();
            string Mail_Password = System.Configuration.ConfigurationManager.AppSettings["Mail_Password"].ToString();
            message.BodyFormat = System.Web.Mail.MailFormat.Html;
            message.Priority = System.Web.Mail.MailPriority.High;
            message.BodyEncoding = Encoding.UTF8;
            System.Web.Mail.SmtpMail.SmtpServer = Mail_Server;
            // SmtpClient smtp = new SmtpClient(Mail_Server);
            //  smtp.Credentials = new System.Net.NetworkCredential(Mail_Username,Mail_Password);
            //    smtp.Port = BlogSettings.Instance.SmtpServerPort;
            //  smtp.EnableSsl = BlogSettings.Instance.EnableSsl;
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");           //认证类型  
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", Mail_Address);//要认证的用户名  
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Mail_Password);
            // MailAddress from = new MailAddress(Mail_Address, username);
            message.From = Mail_Address;
            // smtp.Send(message);
            System.Web.Mail.SmtpMail.Send(message);
            OnEmailSent(message);
        }
        catch (SmtpException)
        {
            OnEmailFailed(message);
        }
        finally
        {
            // Remove the pointer to the message object so the GC can close the thread.
            // message.Dispose();
            message = null;
        }
    }*/

    /// <summary>
    /// 异步发送邮件





    /// </summary>
    /// <param name="message"></param>
   /* public static void SendMailMessageAsync(System.Web.Mail.MailMessage message, string usernmae)
    {
        //ThreadStart threadStart = delegate { Utils.SendMailMessage(message); };
        //Thread thread = new Thread(threadStart);
        //thread.IsBackground = true;
        //thread.Start();
        ThreadPool.QueueUserWorkItem(delegate { WebUtility.SendMailMessage(message, usernmae); });
    }
    public static event EventHandler<EventArgs> EmailSent;
    private static void OnEmailSent(System.Web.Mail.MailMessage message)
    {
        if (EmailSent != null)
        {
            EmailSent(message, new EventArgs());
        }
    }
    public static event EventHandler<EventArgs> EmailFailed;
    private static void OnEmailFailed(System.Web.Mail.MailMessage message)
    {
        if (EmailFailed != null)
        {
            EmailFailed(message, new EventArgs());
        }
    }*/
    //获取采购信息右边菜单
    public static string GetPurchaseLeftString()
    {
        string filename = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/WebPage.xml");
        CacheDependency dep = new CacheDependency(filename);
        System.Web.Caching.Cache cache = HttpRuntime.Cache;
        if (dep.HasChanged == true || cache["PurchaseLeft"] == null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            StringBuilder Res = new StringBuilder();
            Res.Append("<DIV class=divLeft>");
            foreach (XmlNode node in doc.SelectSingleNode("WebPage").ChildNodes)
            {
                if (string.Compare(node.Attributes.GetNamedItem("url").Value, "BaseInfo.aspx", true) == 0)
                {
                    Res.Append("<TABLE cellSpacing=0 cellPadding=0 width=\"99%\" border=0><TBODY><TR><TD class=leftTitle22>" + node.Attributes.GetNamedItem("title").Value + "</TD></TR></TBODY></TABLE>");
                    Res.Append("<UL class=\"leftUl\">");
                    foreach (XmlNode leaf in node.ChildNodes)
                    {
                        Res.Append("<li class=\"liLeft\" onclick=\"window.location.href='" + leaf.Attributes.GetNamedItem("url").Value + "'\">" + leaf.Attributes.GetNamedItem("title").Value);
                        Res.Append("</li>");
                    }
                    Res.Append("</UL>");
                }
            }
            Res.Append("</div>");
            cache.Insert("PurchaseLeft", Res.ToString(), dep);
            return Res.ToString();
        }
        else
        {
            string result = cache["PurchaseLeft"].ToString();
            return result;
        }
    }
    /// <summary>
    /// 获取活动信息左边菜单
    /// </summary>
    /// <returns></returns>
    public static string GetActivityString()
    {
        string filename = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/WebPage.xml");
        CacheDependency dep = new CacheDependency(filename);
        System.Web.Caching.Cache cache = HttpRuntime.Cache;
        if (dep.HasChanged == true || cache["ActivityString"] == null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            StringBuilder Res = new StringBuilder();
            Res.Append("<DIV class=divLeft>");
            foreach (XmlNode node in doc.SelectSingleNode("WebPage").ChildNodes)
            {
                if (string.Compare(node.Attributes.GetNamedItem("url").Value, "Activity.aspx", true) == 0)
                {
                    Res.Append("<TABLE cellSpacing=0 cellPadding=0 width=\"99%\" border=0><TBODY><TR><TD class=leftTitle22>" + node.Attributes.GetNamedItem("title").Value + "</TD></TR></TBODY></TABLE>");
                    Res.Append("<UL class=\"leftUl\">");
                    foreach (XmlNode leaf in node.ChildNodes)
                    {
                        Res.Append("<li class=\"liLeft\" onclick=\"window.location.href='" + leaf.Attributes.GetNamedItem("url").Value + "'\">" + leaf.Attributes.GetNamedItem("title").Value);
                        Res.Append("</li>");
                    }
                    Res.Append("</UL>");
                }
            }
            Res.Append("</div>");
            cache.Insert("ActivityString", Res.ToString(), dep);
            return Res.ToString();
        }
        else
        {
            string result = cache["ActivityString"].ToString();
            return result;
        }
    }
    /// <summary>
    /// 获取页面ｈｅａｄｅｒ
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string GetPageHeader(int id)
    {
        string filename = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/setting.xml");
        CacheDependency dep = new CacheDependency(filename);
        System.Web.Caching.Cache cache = HttpRuntime.Cache;
        if (dep.HasChanged == true || cache["PageSetting"] == null)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            StringDictionary dic = new StringDictionary();
            foreach (XmlNode node in doc.SelectSingleNode("settings").ChildNodes)
            {
                string ids = node.Attributes.GetNamedItem("ID").Value.ToString();
                string value = node.InnerText;
                dic.Add(ids, value);
            }
            cache.Insert("PageSetting", dic, dep);
            return dic[id.ToString()];
        }
        else
        {
            StringDictionary dic = (StringDictionary)cache["PageSetting"];
            string result = dic[id.ToString()];
            if (result == null)
                return "";
            else
                return result;
        }
    }
     
    /// <summary>
    /// 设置登录前正在浏览页面的URL
    /// </summary>
    /// <param name="url"></param>
    /// <param name="request"></param>
    /// <param name="response"></param>
    public static void SetBackUrl(HttpRequest request, HttpResponse response)
    {
        HttpCookie cookie;
        if (request.Cookies["LastUrl"] != null)
        {
            cookie = request.Cookies["LastUrl"];
        }
        else
        {
            cookie = new HttpCookie("LastUrl");
        }
        cookie["Last"] = request.Url.ToString();
        response.AppendCookie(cookie);
    }
    /// <summary>
    /// 获取登录前正在浏览页面的URL
    /// </summary>
    /// <param name="request"></param>
    /// <param name="response"></param>
    /// <returns></returns>
    public static string GetBackUrl(HttpRequest request, HttpResponse response)
    {
        HttpCookie cookie;
        if (request.Cookies["LastUrl"] != null)
        {
            cookie = request.Cookies["LastUrl"];
            return cookie["Last"];
        }
        else
        {
            return "";
        }
    }

     #endregion
}
