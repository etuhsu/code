<%@ WebHandler Language="C#" Class="AddSRRelating" %>

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

public class AddSRRelating : IHttpHandler, IRequiresSessionState
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

        Res.Model.Sr_bsrObj model = new Sr_bsrObj();
        model.SR_TITLE = WebUtility.InputText(context.Request["txt_sr_title"].ToString(), 200);
        model.SR_PROPOSER = WebUtility.InputText(context.Request["txt_application"].ToString(), 20);
        model.SR_CLIENT = WebUtility.InputText(context.Request["txt_sr_client"].ToString(), 20);
        model.SR_IT_COST = WebUtility.InputText(context.Request["txt_IT_cost"].ToString(), 20);
        model.SR_USER_BENEFIT = WebUtility.InputText(context.Request["txt_user_benefit"].ToString(), 200);
        model.SR_IT_OWNER = WebUtility.InputText(context.Request["txt_IT_owner"].ToString(), 20);

        model.SR_DET_ID = WebUtility.InputInt(context.Request["cmb_apply_no"].ToString());
        model.SR_LEL_ID = WebUtility.InputInt(context.Request["cmb_sr_level_no"].ToString());
        model.SR_RAT_ID = WebUtility.InputInt(context.Request["cmb_sr_sort_no"].ToString());
        model.SR_SYE_ID = WebUtility.InputInt(context.Request["cmb_sys_type_no"].ToString());
        model.SR_GRP_ID = WebUtility.InputInt(context.Request["cmb_sr_group_no"].ToString());

        model.SR_OVERDATE = DateTime.Parse(context.Request["txt_over_dt"].ToString());
        model.SR_SOD_EXPECT = DateTime.Parse(context.Request["txt_sod_expect_dt"].ToString());
        model.SR_SOD_UPDATE = DateTime.Parse(context.Request["txt_sod_update"].ToString());

        model.SR_SR_FLAG = context.Request["sr_flag"].ToString() == "1" ? true : false;
        model.SR_AR_FLAG = context.Request["ar_flag"].ToString() == "1" ? true : false;
        model.SR_PRO_FLAG = context.Request["pro_flag"].ToString() == "1" ? true : false;


        Res.BLL.SrBLL bll = new SrBLL();
        int intSr= bll.GetNumOfSr_idGroup(Convert.ToInt32(context.Request["SR_ID"].ToString()))+1;
        model.SR_CODE = context.Request["SR_CODE"].ToString() +"-"+intSr.ToString();

        model.SR_DEMAND_DESC = WebUtility.HtmlText(context.Request["txt_requirement"].ToString());
        model.SR_CREATIONUID = userStr;

    
        Res.Model.ChildObj co = new ChildObj();

        int sr_id = 0;
        if (bll.AddSrList(model, out sr_id) > 0)
        {

                 co.ID = Convert.ToInt32(context.Request["SR_ID"].ToString());
                 co.Level = sr_id;
                 co.NAME = userStr;
                 if (bll.AddSrrelation(co) > 0)
                 {
                     context.Response.Write("{success:true,data:'提交成功！'}");
                     return;  
                 }
        }
        else
        {
            context.Response.Write("{success:false,data:'提交失败！'}");
            return;
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}