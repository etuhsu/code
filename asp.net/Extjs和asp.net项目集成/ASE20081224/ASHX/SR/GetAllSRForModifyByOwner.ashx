<%@ WebHandler Language="C#" Class="GetAllSRForModifyByOwner" %>

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

public class GetAllSRForModifyByOwner : IHttpHandler, IRequiresSessionState
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
        SrBLL bll = new SrBLL();
        string strWhere = " user_id='" + userStr+"'";
        context.Response.Write(bll.GetAllSRForModifyByOwner(strWhere));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}