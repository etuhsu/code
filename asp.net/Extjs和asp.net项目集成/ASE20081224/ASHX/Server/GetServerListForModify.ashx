<%@ WebHandler Language="C#" Class="GetServerListForModify" %>

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

public class GetServerListForModify : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) 
    {
      /*  UserObj us = (UserObj)(context.Session["user"]);
        if (UserManager.IsAuthenticated(context.Session) == false)
        {
            context.Response.Redirect("../../ashx/user/Loginout.ashx");
            return;
        }
        if (String.IsNullOrEmpty(context.Request["ITR_ID"]) == true)
        {
            context.Response.Redirect("../../ashx/user/Loginout.ashx");
            return;
        }*/
        if (string.IsNullOrEmpty(context.Session["user"].ToString()))
        {
            return;
        }
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        int SVS_ID = System.Convert.ToInt32(context.Request["SVS_ID"]);
        ServerBLL bll = new ServerBLL();
        context.Response.Write(bll.GetServerListForModify(SVS_ID));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}