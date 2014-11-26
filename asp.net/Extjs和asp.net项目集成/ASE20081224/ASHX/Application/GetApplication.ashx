<%@ WebHandler Language="C#" Class="GetApplication" %>

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

public class GetApplication : IHttpHandler, IRequiresSessionState
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

        ApplicationBLL bll = new ApplicationBLL();
        string strWhere = " USER_ID='" + userStr + "' OR USER_ID IN ";
        strWhere += "(SELECT POM_USER_ID FROM APP_POPEDOM WHERE  POM_POP_LEVEL<(SELECT POM_POP_LEVEL FROM APP_POPEDOM WHERE POM_USER_ID='"+userStr+"' )) ";

        context.Response.Write(bll.GetApplication(strWhere));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}