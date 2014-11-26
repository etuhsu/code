<%@ WebHandler Language="C#" Class="Upload_ServerList" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Res.Pub;
using Res.BLL;
using Res.Model;
using Res.Core;
using NetServ.Net.Json;
using System.Text;

public class Upload_ServerList : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context)
    {
        string userStr = "";
        if (string.IsNullOrEmpty(context.Session["user"].ToString()))
        {
            return;
        }
        else
        {
            userStr = context.Session["user"].ToString();
        }
        string uploadFile = context.Request.MapPath("~/") + System.Configuration.ConfigurationManager.AppSettings["FilePath"] + "\\";
        if (context.Request.Files.Count > 0)
        {
            int pos = context.Request.Files[0].FileName.LastIndexOf('\\');
            int end = context.Request.Files[0].FileName.Length - pos - 1;
            string str = context.Request.Files[0].FileName.Substring(pos + 1, end);//文件名后缀
            int posType = str.LastIndexOf('.');
            string upType = str.Substring(posType + 1, str.Length - posType - 1);
            if (upType != "xls")
            {
                context.Response.Write("{success:false,data:'上传文件类型必须为 .xls 文件!'}");
                return;
            }
            string result = Guid.NewGuid().ToString() + "-" + str;
            string tmpname = uploadFile + result;

            context.Request.Files[0].SaveAs(tmpname);

            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + tmpname + ";Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            IList<Hashtable> lst_hash = new List<Hashtable>();
            try
            {
                cmd.CommandText = "select * from [Sheet1$]";
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    int fieldcount = reader.FieldCount;
                    //   int j = 0;
                    while (reader.Read())
                    {
                        Hashtable hash = new Hashtable();
                        for (int col = 0; col < reader.FieldCount; col++)
                        {
                            if (reader.IsDBNull(col) == true)
                            {
                                hash.Add(reader.GetName(col).Trim(), "");
                            }
                            else
                            {
                                hash.Add(reader.GetName(col).Trim(), reader.GetValue(col).ToString().Trim());
                            }
                        }
                        lst_hash.Add(hash);
                    }
                }
            }
            finally
            {
                conn.Close();
            }
            Res.BLL.ServerBLL bll = new ServerBLL();
            if (bll.Add_ServerList(lst_hash, result, userStr) > 0) 
            {
                context.Response.Write("{success:true,data:'文件上传成功！'}");
                return;
            }
            else
            {
                context.Response.Write("{success: false,data:'上传发生错误,请联系相关技术人员'}");
                return;
            }
        }
        else
        {
            context.Response.Write("{success: false,data:'上传文件不能为空'}");
            return;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}