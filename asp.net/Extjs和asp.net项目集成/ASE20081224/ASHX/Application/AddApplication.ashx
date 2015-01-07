<%@ WebHandler Language="C#" Class="AddApplication" %>

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
public class AddApplication : IHttpHandler, IRequiresSessionState
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
        List<Res.Model.ApplicationObj> aList = new List<Res.Model.ApplicationObj>();
        JsonParser parser = new JsonParser(new StringReader(context.Request["data"].ToString()), true);
        JsonArray array = parser.ParseArray();
        for (int i = 0; i < array.Count; i++)
        {
            NodeIntObj intOb = new NodeIntObj();
            JsonObject obj = (JsonObject)array[i];
            JsonObject ob = (JsonObject)obj["data"];
            Res.Model.ApplicationObj lo = new ApplicationObj();
            if (ob["APP_ADS_ID"].ToString() == "未用餐")
            {
                lo.APP_ADS_ID = "0";
            }
            else if (ob["APP_ADS_ID"].ToString() == "用餐1次")
            {
                lo.APP_ADS_ID = "1";
            }
            else if (ob["APP_ADS_ID"].ToString() == "用餐2次")
            {
                lo.APP_ADS_ID = "2";
            }
            else if (ob["APP_ADS_ID"].ToString() == "上班漏刷")
            {
                lo.APP_ADS_ID = "1";
            }
            else if (ob["APP_ADS_ID"].ToString() == "下班漏刷")
            {
                lo.APP_ADS_ID = "2";
            }
            else if (ob["APP_ADS_ID"].ToString() == "上/下班漏刷")
            {
                lo.APP_ADS_ID = "3";
            }
            else
            {
                lo.APP_ADS_ID = "99"; 
            }
                
                
            //==============================
            if (ob["APP_ATE_ID"].ToString() == "请假")
            {
                lo.APP_ATE_ID = "001";
            }
            else if (ob["APP_ATE_ID"].ToString() == "加班")
            {
                lo.APP_ATE_ID = "002"; 
            }
            else if (ob["APP_ATE_ID"].ToString() == "漏刷卡")
            {
                lo.APP_ATE_ID = "003"; 
            }
            lo.APP_LEE_OTE_ID = WebUtility.InputInt(ob["APP_TYPE"].ToString());
            lo.APP_CAUSE = WebUtility.InputText(ob["APP_CAUSE"].ToString(), 500);
            lo.APP_DATE = DateTime.Parse(ob["APP_DATE"].ToString());
            lo.APP_FROM_TIME = WebUtility.InputText(ob["APP_FROM_TIME"].ToString(),50);
            lo.APP_NUM_TIME = WebUtility.InputText(ob["APP_NUM_TIME"].ToString(),20);
            lo.APP_TO_TIME = WebUtility.InputText(ob["APP_TO_TIME"].ToString(), 50);
            lo.APP_USER_ID = WebUtility.InputText(ob["USER_ID"].ToString(), 5);
            lo.APP_CREATIONUID = userStr;
            aList.Add(lo);
        }
        Res.BLL.ApplicationBLL bll = new ApplicationBLL();
        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                foreach (Res.Model.ApplicationObj ob in aList)
                {
                    int app_id = 0;
                    if (bll.AddApplication(trans, ob, out app_id) > 0)
                    {
                        continue;
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
                trans.Commit();
                context.Response.Write("{success:true,data:'提交成功！'}");
                
            }
            catch
            {
                trans.Rollback();
                context.Response.Write("{success:false,data:'提交失败！'}");
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}