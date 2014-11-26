<%@ WebHandler Language="C#" Class="GetUserByUser_id" %>

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
using Res.Service.ExcelTemplate;
using Res.Model;
using System.Data.SqlClient;
using Res.Core;
using NetServ.Net.Json;

public class GetUserByUser_id : IHttpHandler, IRequiresSessionState
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
        if (string.IsNullOrEmpty(context.Request["USER_ID"].ToString()))
        {
            context.Response.Write("{success:false,data:'缺少用户参数！'}");
            return;
        }
        Res.BLL.ApplicationBLL bll = new ApplicationBLL();
        context.Response.Write(bll.GetUserByUser_id(context.Request["USER_ID"].ToString()));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}