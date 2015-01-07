<%@ WebHandler Language="C#" Class="AddListServer" %>

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

public class AddListServer : IHttpHandler, IRequiresSessionState
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
      /*  if (string.IsNullOrEmpty(context.Request["txt_server_name"]) == true)
        {
            context.Response.Write("{success: false,data:'服务器名称不能为空'}");
            return;
        }
        if (string.IsNullOrEmpty(context.Request["txt_sn_name"]) == true)
        {
            context.Response.Write("{success: false,data:'SN 编码不能为空'}");
            return;
        }
        if (string.IsNullOrEmpty(context.Request["txt_ip_address"]) == true)
        {
            context.Response.Write("{success: false,data:'IP地址不能为空'}");
            return;
        }
        if (string.IsNullOrEmpty(context.Request["txt_server_spec"].ToString()) == true)
        {
            context.Response.Write("{success: false,data:'描述不能为空'}");
            return;
        }*/
        JsonParser parser = new JsonParser(new StringReader(context.Request["data"].ToString()), true);
        JsonArray array = parser.ParseArray();
        JsonObject ob = (JsonObject)array[0];
        JsonObject obj = (JsonObject)ob["data"];
        
        ServerBLL bll = new ServerBLL();
        BServerObj model = new BServerObj();
        RServerObj model2 = new RServerObj();
        int smo_id=0;
        int os_id=0;
        int mey_id=0;
        int cpu_id=0;
        int aty_id=0;
        int had_id=0;
        int str_id = 0;
        int tep_id = 0;
        if (string.IsNullOrEmpty(context.Request["cmb_os_type_no"])==true&&string.IsNullOrEmpty(obj["OS"].ToString())==true)
        {
            context.Response.Write("{success: false,data:'操作系统字段不能为空'}");
            return;
        }
        if (string.IsNullOrEmpty(context.Request["cmb_smo_type_no"])==true&&string.IsNullOrEmpty(obj["SMO"].ToString())==true)
        {
            context.Response.Write("{success: false,data:'服务型号不能为空'}");
            return;
        }        
        if (string.IsNullOrEmpty(context.Request["cmb_mey_type_no"])==true&&string.IsNullOrEmpty(obj["MEY"].ToString())==true)
        {
            context.Response.Write("{success: false,data:'内存字段不能为空'}");
            return;
        }        
        if (string.IsNullOrEmpty(context.Request["cmb_cpu_type_no"])==true&&string.IsNullOrEmpty(obj["CPU"].ToString())==true)
        {
            context.Response.Write("{success: false,data:'CPU 字段不能为空'}");
            return;
        }        
        if (string.IsNullOrEmpty(context.Request["cmb_aty_type_no"])==true&&string.IsNullOrEmpty(obj["ATY"].ToString())==true)
        {
            context.Response.Write("{success: false,data:'磁盘阵列字段不能为空'}");
            return;
        }        
        if (string.IsNullOrEmpty(context.Request["cmb_had_type_no"])==true&&string.IsNullOrEmpty(obj["HAD"].ToString())==true)
        {
            context.Response.Write("{success: false,data:'硬盘类型字段不能为空'}");
            return;
        }
        if (string.IsNullOrEmpty(context.Request["cmb_team_type_no"]) == true && string.IsNullOrEmpty(obj["TEAM"].ToString()) == true)
        {
            context.Response.Write("{success: false,data:'部门字段不能为空'}");
            return;
        }
        if (string.IsNullOrEmpty(context.Request["cmb_str_type_no"]) == true && string.IsNullOrEmpty(obj["STR"].ToString()) == true)
        {
            context.Response.Write("{success: false,data:'存储字段不能为空'}");
            return;
        }

        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                if (string.IsNullOrEmpty(obj["ATY"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, "ARRAY TYPE", Convert.ToString(obj["ATY"]), userStr, out aty_id);
                }
                if (string.IsNullOrEmpty(obj["SMO"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, "型號", Convert.ToString(obj["SMO"]), userStr, out smo_id);
                }
                if (string.IsNullOrEmpty(obj["CPU"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, "CPU", Convert.ToString(obj["CPU"]), userStr, out cpu_id);
                }
                if (string.IsNullOrEmpty(obj["OS"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, "OS", Convert.ToString(obj["OS"]), userStr, out os_id);
                }
                if (string.IsNullOrEmpty(obj["MEY"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, "MEMORY", Convert.ToString(obj["MEY"]), userStr, out mey_id);
                }
                if (string.IsNullOrEmpty(obj["HAD"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, " HARD DISK", Convert.ToString(obj["HAD"]), userStr, out had_id);
                }
                if (string.IsNullOrEmpty(obj["STR"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, "STORAGE", Convert.ToString(obj["STR"]), userStr, out str_id);
                }
                if (string.IsNullOrEmpty(obj["TEAM"].ToString()) == false)
                {
                    bll.InsertEntryItems(trans, "IT TEAM", Convert.ToString(obj["TEAM"]), userStr, out tep_id);
                }
                model.SVS_ATY_ID = string.IsNullOrEmpty(obj["ATY"].ToString()) ? Convert.ToInt32(context.Request["cmb_aty_type_no"]) : aty_id;
                model.SVS_CPU_ID = string.IsNullOrEmpty(obj["CPU"].ToString()) ? Convert.ToInt32(context.Request["cmb_cpu_type_no"]) : cpu_id;
                model.SVS_HAD_ID = string.IsNullOrEmpty(obj["HAD"].ToString()) ? Convert.ToInt32(context.Request["cmb_had_type_no"]) : had_id;
                model.SVS_IPADDRESS = WebUtility.InputText(context.Request["txt_ip_address"], 15);
                model.SVS_MEY_ID = string.IsNullOrEmpty(obj["MEY"].ToString()) ? Convert.ToInt32(context.Request["cmb_mey_type_no"]) : mey_id;
                model.SVS_NAME = WebUtility.InputText(context.Request["txt_server_name"].ToString(), 50);
                model.SVS_OS_ID = string.IsNullOrEmpty(obj["OS"].ToString()) ? Convert.ToInt32(context.Request["cmb_os_type_no"]) : os_id;
                model.SVS_SHORTDESC = WebUtility.InputText(context.Request["txt_server_spec"].ToString(), 100);
                model.SVS_SMO_ID = string.IsNullOrEmpty(obj["SMO"].ToString()) ? Convert.ToInt32(context.Request["cmb_smo_type_no"]) : smo_id;
                int svs_id = 0;
                model.SVS_SN = WebUtility.InputText(context.Request["txt_sn_name"].ToString(), 50);
                model.SVS_CREATIONUID = userStr;

                ////txt_po_no cmb_str_type,cmb_team_type] txt_owner txt_come_dt
                model2.SER_AP_LIST = WebUtility.HtmlText(context.Request["txt_ap_list"].ToString());
                model2.SER_COME_DT = DateTime.Parse(context.Request["txt_come_dt"].ToString());
                model2.SER_OPERATEUID = userStr;
                model2.SER_OWNER = WebUtility.InputText(context.Request["txt_owner"].ToString(),50);
                model2.SER_PO_NO = WebUtility.InputText(context.Request["txt_po_no"].ToString(), 50);
                model2.SER_STR_ID = string.IsNullOrEmpty(obj["STR"].ToString()) ? Convert.ToInt32(context.Request["cmb_str_type_no"]) : str_id;
                model2.SER_TEP_ID = string.IsNullOrEmpty(obj["TEAM"].ToString()) ? Convert.ToInt32(context.Request["cmb_team_type_no"]) : tep_id;
                int result = bll.AddServerMasterByAddServerList(trans, model, out svs_id);
                model2.SER_SVS_ID = svs_id;

                if (result > 0 && svs_id > 0)
                {
                    if (bll.AddRServerByAddServerList(trans, model2) > 0 )
                    {
                        trans.Commit();
                        context.Response.Write("{success:true,data:'添加服务器成功！'}");
                    }
                    else
                    {
                        trans.Rollback();
                        context.Response.Write("{success:false,data:'添加服务器信息失败！'}");
                    }

                }
                else if (result < 0 && svs_id > 0)
                {
                    trans.Rollback();
                    context.Response.Write("{success:true,data:'未向数据库插入信息，可能是因为输入了重复名！'}");   
                }
                else
                {
                    trans.Rollback();
                    context.Response.Write("{success:false,data:'添加服务器信息失败！'}");
                  
                }
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                context.Response.Write("{success:false,data:'发生异常:"+ex.ToString()+"，请联系技术人员！'}");
                return;
                
            }

            
        }

        

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}