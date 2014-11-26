<%@ WebHandler Language="C#" Class="CVS_DownApplication" %>


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

public class CVS_DownApplication : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) 
    {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }


    
  
 
    public bool IsReusable 
    {
        get {
            return false;
        }
    }

}