<%@ WebHandler Language="C#" Class="DelServerListBySVS_ID" %>

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

public class DelServerListBySVS_ID : IHttpHandler, IRequiresSessionState
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
        
        ServerBLL bll = new ServerBLL();
        int result = bll.DelServerListBySVS_ID(IDArray, userStr);
        if (result > 0)
        {
            context.Response.Write("{success:true,data:'成功删除 <span color=red><B>"+result.ToString()+" </B></span> 条数据！'}");
            return;
        }
        else
        {
            context.Response.Write("{success:false,data:'删除失败！'}");
            return;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}