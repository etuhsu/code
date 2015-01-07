<%@ WebHandler Language="C#" Class="ListServer" %>

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
using Res.DBUtility;
using Res.Model;
using System.Data.SqlClient;
using Res.Core;
using NetServ.Net.Json;
using System.Text;

public class ListServer : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) 
    {
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        string userStr = "";
        if (string.IsNullOrEmpty(context.Session["user"].ToString()))
        {
            return;
        }
        else
        {
            userStr = context.Session["user"].ToString();
        }
        int start = WebUtility.InputInt(context.Request["start"]);
        int limit = WebUtility.InputInt(context.Request["limit"]);
        int pageno = start / limit + 1;
        if (limit == 0)
        {
            context.Response.Write("{success: false,data:'参数错误'}");
            return;
        }
        string strWhere = "";
        ServerBLL bll = new ServerBLL();
        context.Response.Write(bll.GetServerList(limit,pageno, strWhere));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}