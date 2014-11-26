<%@ WebHandler Language="C#" Class="QueryApplication" %>

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

public class QueryApplication : IHttpHandler, IRequiresSessionState
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
        int start = WebUtility.InputInt(context.Request["start"]);
        int limit = WebUtility.InputInt(context.Request["limit"]);

        StringBuilder strWhere = new StringBuilder();
        if (string.IsNullOrEmpty(context.Request["NAME_ID"]) == false)
        {
            strWhere.Append("  USER_CNAME= '" + context.Request["NAME_ID"].ToString() + "'  ");
        }
        if (string.IsNullOrEmpty(context.Request["DT_FROM"]) == false && string.IsNullOrEmpty(context.Request["DT_TO"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND APP_DATE BETWEEN '" + context.Request["DT_FROM"].ToString() + "' AND '" + context.Request["DT_TO"].ToString() + "'");
            }
            else
            {
                strWhere.Append(" APP_DATE  BETWEEN '" + context.Request["DT_FROM"].ToString() + "' AND '" + context.Request["DT_TO"].ToString() + "'");
            }
        }
        if (string.IsNullOrEmpty(context.Request["isdisponse"]) == false)
        {
            if (strWhere.Length > 0)
            {
                if (Convert.ToInt32(context.Request["isdisponse"]) == 0)
                {
                    strWhere.Append(" AND APP_DISPOSED =0");                 
                }

            }
            else
            {
                if (Convert.ToInt32(context.Request["isdisponse"]) == 0)
                {
                    strWhere.Append("  APP_DISPOSED =0");
                }
            }
        }
    /*    if (string.IsNullOrEmpty(context.Request["USER_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND USER_ID ='" + context.Request["USER_ID"].ToString() + "' ");
            }
            else
            {
                strWhere.Append(" USER_ID ='" + context.Request["USER_ID"].ToString() + "' ");
            }
        }*/
        if (strWhere.Length > 0)
        {
            strWhere.Append(" AND  USER_ID='"+userStr+"' OR USER_ID IN ");
            strWhere.Append("(SELECT POM_USER_ID FROM APP_POPEDOM WHERE  POM_POP_LEVEL<(SELECT POM_POP_LEVEL FROM APP_POPEDOM WHERE POM_USER_ID='" + userStr + "' )) ");

        }
        else
        {
            strWhere.Append("   USER_ID='" + userStr + "' OR USER_ID IN ");
            strWhere.Append("(SELECT POM_USER_ID FROM APP_POPEDOM WHERE  POM_POP_LEVEL<(SELECT POM_POP_LEVEL FROM APP_POPEDOM WHERE POM_USER_ID='" + userStr + "' )) ");

        }
        
        ApplicationBLL bll = new ApplicationBLL();
        context.Response.Write(bll.QueryApplication(strWhere.ToString()));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}