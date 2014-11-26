<%@ WebHandler Language="C#" Class="CVS_DownServerList" %>

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

public class CVS_DownServerList : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context)
     {
    /*    context.Response.Buffer = true;
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        string sqlStr = context.Request["sqlStr"].ToString();
        ServerBLL bll = new ServerBLL();
        SqlDataReader reader = bll.DownServerListALL(sqlStr);

        ExcelTemplateService et = new ExcelTemplateService(context.Server.MapPath("/TemplateReport/ExcelCommonReport.htm"));

        et.SetTitle("服务器清单");

        string[] header = new string[] { "Server Name", "Function Description", "IP Address", " 型號", " CPU", " Memory", " Hard Disk", " Array Type", " OS", " SN", "PO NO.", "Owner", "IT Team", "Storage", " Arrive Date", "AP List" };
        string[] styles = new string[] { "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack", "cellBlack" };
        et.SetHeader(header);
        et.SetData(reader, styles);
        reader.Close();
        context.Response.Write(et.GetHtml());
        context.Response.Flush();
        context.Response.End();  */
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}