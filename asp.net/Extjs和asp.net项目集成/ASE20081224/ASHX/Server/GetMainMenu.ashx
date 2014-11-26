<%@ WebHandler Language="C#" Class="GetMainMenu" %>
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


public class GetMainMenu : IHttpHandler, IRequiresSessionState
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
        ServerBLL bll = new ServerBLL();
        context.Response.Write(bll.GetMainMenu(userStr));
    }
 
    public bool IsReusable 
    {
        get
        {
            return false;
        }
    }

}