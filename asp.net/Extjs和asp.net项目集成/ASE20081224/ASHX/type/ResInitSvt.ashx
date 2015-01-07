<%@ WebHandler Language="C#" Class="ResInitSvt" %>
using System;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.IO;
using Res.Pub;
using Res.BLL;
using Res.Model;
using Res.Core;
using NetServ.Net.Json;
public class ResInitSvt : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
       /* UserObj us = (UserObj)(context.Session["user"]);
        if (UserManager.IsAuthenticated(context.Session) == false)
        {
            context.Response.Redirect("../../ashx/user/Loginout.ashx");
            return;
        }*/
        string[] IDArray = new string[] { };
        if (string.IsNullOrEmpty(context.Request["IDstr"]) == false)
        {
            string str = context.Request["IDstr"];
            IDArray = str.Split(',');
        }
        else
        {
            return;
        }
        context.Response.ContentType = "application/json";
        context.Response.ContentEncoding = System.Text.Encoding.UTF8;

        JsonObject json = new JsonObject();
        foreach (string str_id in IDArray)
        {
            switch (System.Convert.ToInt32(str_id))
            {
                case ResPageEvent.ServerCpuType://产品分类
                    {
                        json.Add("CPU_TYPE", GetCpuTypeJson());
                        break;
                    }
                case ResPageEvent.ServerMeyType://产品发布
                    {
                        json.Add("MEY_TYPE", GetMeyTypeJson());
                        break;
                    }
                case ResPageEvent.ServerHadType://产品分类
                    {
                        json.Add("HAD_TYPE", GetHadTypeJson());
                        break;
                    }
                case ResPageEvent.ServerAtyType://产品发布
                    {
                        json.Add("ATY_TYPE", GetAtyTypeJson());
                        break;
                    }
                case ResPageEvent.ServerOsType://产品分类
                    {
                        json.Add("OS_TYPE", GetOstypeJson());
                        break;
                    }
                case ResPageEvent.ServerSmoType://产品分类
                    {
                        json.Add("SMO_TYPE", GetSmoTypeJson());
                        break;
                    }
                case ResPageEvent.ServerStrType://产品发布
                    {
                        json.Add("STR_TYPE", GetStrTypeJson());
                        break;
                    }
                case ResPageEvent.ServerTepType://产品发布
                    {
                        json.Add("TEP_TYPE", GetTepTypeJson());
                        break;
                    }
                case ResPageEvent.ApplicationOteType://请假类型
                    {
                        json.Add("OTE_TYPE", GetOteTypeJson());
                        break;
                    }
                case ResPageEvent.ApplicationLeeType://加班类型
                    {
                        json.Add("LEE_TYPE", GetLeeTypeJson());
                        break;
                    }
                case ResPageEvent.ApplicationAteType://请假类型
                    {
                        json.Add("ATE_TYPE", GetAteTypeJson());
                        break;
                    }
                case ResPageEvent.ApplicationAdsType://加班类型
                    {
                        json.Add("ADS_TYPE", GetAdsTypeJson());
                        break;
                    }
                //===================== SR ==================================      
                case ResPageEvent.SRSysType://请假类型
                    {
                        json.Add("SYS_TYPE", GetSysTypeJson());
                        break;
                    }
                case ResPageEvent.SRRassortType://加班类型
                    {
                        json.Add("RAT_TYPE", GetRassortTypeJson());
                        break;
                    }
                case ResPageEvent.SRLevelType://请假类型
                    {
                        json.Add("LEL_TYPE", GetLevelTypeJson());
                        break;
                    }
                case ResPageEvent.SRDepartmentType://加班类型
                    {
                        json.Add("DET_TYPE", GetDepartmentTypeJson());
                        break;
                    }
                case ResPageEvent.SRGroupType://IT 组别
                    {
                        json.Add("GRP_TYPE", GetGroupTypeJson());
                        break;
                    }
                case ResPageEvent.SRStatusType://SR 状态
                    {
                        json.Add("STS_TYPE", GetStatusTypeJson());
                        break;
                    }
            }
        } 

        IJsonWriter writer = new JsonWriter();
        json.Write(writer);
        context.Response.Write(writer.ToString());
    }
    private JsonArray GetGroupTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetGroupType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetAteTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<AppObj> lst_type = bll.GetAteType();
        foreach (AppObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.APP_ID);
            record.Add("NAME", node.APP_NAME);
            record.Add("LEVEL", node.APP_CODE1);
        }
        return typeList;
    }
    private JsonArray GetAdsTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<AppObj> lst_type = bll.GetAdsType();
        foreach (AppObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.APP_CODE1);
            record.Add("NAME", node.APP_NAME);
            record.Add("LEVEL", node.APP_CODE2);
        }
        return typeList;
    }
    private JsonArray GetCpuTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetCpuType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetStrTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetStrType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetTepTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetTepType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetSmoTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetSmoType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }

    private JsonArray GetOteTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetOteType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetLeeTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetLeeType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetOstypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetOstype();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetAtyTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetAtyType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetHadTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetHadType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    //GetCpuTypeJson  GetMeyTypeJson  GetHadTypeJson GetAtyTypeJson  GetOstypeJson
    private JsonArray GetMeyTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetMeyType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    //==========================  SR ============================
    private JsonArray GetDepartmentTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetDepartmentType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetLevelTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetLevelType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetRassortTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetRassortType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetSysTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetSysType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    private JsonArray GetStatusTypeJson()
    {
        TypeBLL bll = new TypeBLL();
        JsonArray typeList = new JsonArray();
        IList<NodeObj> lst_type = bll.GetStatusType();
        foreach (NodeObj node in lst_type)
        {
            JsonObject record = new JsonObject();
            typeList.Add(record);
            record.Add("ID", node.ID);
            record.Add("NAME", node.NAME);
        }
        return typeList;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}

