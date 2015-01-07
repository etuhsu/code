<%@ WebHandler Language="C#" Class="GetDisposeBtn" %>

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

public class GetDisposeBtn : IHttpHandler, IRequiresSessionState
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
        ApplicationBLL bll = new ApplicationBLL();
        if (bll.GetBoolDispose(userStr) > 0)
        {
            context.Response.Write("{success:true,data:true}");
        }
        else
        {
            context.Response.Write("{success:true,data:false}");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}