<%@ WebHandler Language="C#" Class="UpdateSrStatus" %>

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

public class UpdateSrStatus : IHttpHandler, IRequiresSessionState
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
        List<Res.Model.ChildObj> aList = new List<Res.Model.ChildObj>();
        JsonParser parser = new JsonParser(new StringReader(context.Request["data"].ToString()), true);
        JsonArray array = parser.ParseArray();
        for (int i = 0; i < array.Count; i++)
        {
            NodeIntObj intOb = new NodeIntObj();
            JsonObject obj = (JsonObject)array[i];
            JsonObject ob = (JsonObject)obj["data"];
            Res.Model.ChildObj lo = new ChildObj();
            lo.ID = Convert.ToInt32(ob["SR_ID"].ToString());
            lo.Level = Convert.ToInt32(ob["STS_ID"].ToString());
            aList.Add(lo);
        }
        Res.BLL.SrBLL bll = new SrBLL();
        if (bll.UpdateSRStatus(aList,userStr) > 0)
        {
            context.Response.Write("{success:true,data:'修改成功 ！'}");
            return;
        }
        else
        {
            context.Response.Write("{success:false,data:'修改失败 ！'}");
            return;
        }
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}