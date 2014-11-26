<%@ WebHandler Language="C#" Class="DownQueryServerList" %>
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

public class DownQueryServerList : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {


        StringBuilder strWhere = new StringBuilder();
        if (string.IsNullOrEmpty(context.Session["user"].ToString()))
        {
            return;
        }
        if (string.IsNullOrEmpty(context.Request["SVS_NAME"]) == false)
        {
            strWhere.Append("  SVS_NAME= '" + context.Request["SVS_NAME"].ToString() + "'  ");
        }
        if (string.IsNullOrEmpty(context.Request["SVS_IPADDRESS"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND SVS_IPADDRESS ='" + context.Request["SVS_IPADDRESS"].ToString()+"' ");
            }
            else
            {
                strWhere.Append(" SVS_IPADDRESS ='" + context.Request["SVS_IPADDRESS"].ToString()+"' ");
            }
        }
        if (string.IsNullOrEmpty(context.Request["SVS_SHORTDESC"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND SVS_SHORTDESC ='" + context.Request["SVS_SHORTDESC"].ToString()+"' ");
            }
            else
            {
                strWhere.Append(" SVS_SHORTDESC ='" + context.Request["SVS_SHORTDESC"].ToString()+"' ");
            }
        }
        if (string.IsNullOrEmpty(context.Request["SVS_SN"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND SVS_SN ='" + context.Request["SVS_SN"].ToString()+"' ");
            }
            else
            {
                strWhere.Append(" SVS_SN ='" + context.Request["SVS_SN"].ToString()+"' ");
            }
        }
        if (string.IsNullOrEmpty(context.Request["SMO_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND SMO_ID =" + context.Request["SMO_ID"].ToString() );
            }
            else
            {
                strWhere.Append(" SMO_ID =" + context.Request["SMO_ID"].ToString() );
            }
        }
        if (string.IsNullOrEmpty(context.Request["CPU_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND CPU_ID =" + context.Request["CPU_ID"].ToString());
            }
            else
            {
                strWhere.Append(" CPU_ID =" + context.Request["CPU_ID"].ToString());
            }
        }
        if (string.IsNullOrEmpty(context.Request["MEY_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND MEY_ID =" + context.Request["MEY_ID"].ToString());
            }
            else
            {
                strWhere.Append(" MEY_ID =" + context.Request["MEY_ID"].ToString());
            }
        }
        if (string.IsNullOrEmpty(context.Request["HAD_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND HAD_ID =" + context.Request["HAD_ID"].ToString());
            }
            else
            {
                strWhere.Append(" HAD_ID =" + context.Request["HAD_ID"].ToString());
            }
        }
        if (string.IsNullOrEmpty(context.Request["ATY_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND ATY_ID =" + context.Request["ATY_ID"].ToString());
            }
            else
            {
                strWhere.Append(" ATY_ID =" + context.Request["ATY_ID"].ToString());
            }
        }
               
        if (string.IsNullOrEmpty(context.Request["OS_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND OS_ID =" + context.Request["OS_ID"].ToString());
            }
            else
            {
                strWhere.Append(" OS_ID =" + context.Request["OS_ID"].ToString());
            }
        }
        if (string.IsNullOrEmpty(context.Request["DT_FROM"]) == false && string.IsNullOrEmpty(context.Request["DT_TO"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND SER_COME_DT BETWEEN '" + context.Request["DT_FROM"].ToString() + "' AND '" + context.Request["DT_TO"].ToString() + "'");
            }
            else
            {
                strWhere.Append(" SER_COME_DT  BETWEEN '" + context.Request["DT_FROM"].ToString() + "' AND '" + context.Request["DT_TO"].ToString() + "'");
            }
        }
        if (string.IsNullOrEmpty(context.Request["STR_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND STR_ID =" + context.Request["STR_ID"].ToString());
            }
            else
            {
                strWhere.Append(" STR_ID =" + context.Request["STR_ID"].ToString());
            }
        }

        if (string.IsNullOrEmpty(context.Request["TEP_ID"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND TEP_ID =" + context.Request["TEP_ID"].ToString());
            }
            else
            {
                strWhere.Append(" TEP_ID =" + context.Request["TEP_ID"].ToString());
            }
        }
        if (string.IsNullOrEmpty(context.Request["OWNER"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND SER_OWNER ='" + context.Request["OWNER"].ToString() + "' ");
            }
            else
            {
                strWhere.Append(" SER_OWNER ='" + context.Request["OWNER"].ToString() + "' ");
            }
        }
        if (string.IsNullOrEmpty(context.Request["PO_NO"]) == false)
        {
            if (strWhere.Length > 0)
            {
                strWhere.Append(" AND SER_PO_NO ='" + context.Request["PO_NO"].ToString() + "' ");
            }
            else
            {
                strWhere.Append(" SER_PO_NO ='" + context.Request["PO_NO"].ToString() + "' ");
            }
        }
        ServerBLL bll = new ServerBLL();
        context.Response.Write(bll.GetServerList(strWhere.ToString()));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}