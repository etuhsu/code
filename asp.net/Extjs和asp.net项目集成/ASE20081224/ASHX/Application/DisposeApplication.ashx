<%@ WebHandler Language="C#" Class="DisposeApplication" %>

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

public class DisposeApplication : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context)
    {
        if (string.IsNullOrEmpty(context.Request["IDList"]))
        {
            context.Response.Write("{success:false,data:'缺乏参数！'}");
            return;
        }
        string userStr = "";
        if (string.IsNullOrEmpty(context.Session["user"].ToString()))
        {
            return;
        }
        else
        {
            userStr = context.Session["user"].ToString();
        }
        string IDStr = context.Request["IDList"];
        string[] IDArray = IDStr.Split(',');

        Res.BLL.ApplicationBLL bll = new ApplicationBLL();
        int result = bll.DisponseApplication(IDArray, userStr);
        if (result > 0)
        {
            context.Response.Write("{success:true,data:'成功处理<span color=red><B>" + result.ToString() + " </B></span> 条考勤数据！'}");
            return;
        }
        else
        {
            context.Response.Write("{success:false,data:'处理失败！'}");
            return;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}