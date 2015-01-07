using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;

public partial class DATA_RoleInfo_RoleInfo : System.Web.UI.Page
{
    public string JSON = "";
    RoleInfoBLL bll = new RoleInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRoleInfo();
    }
    public void GetRoleInfo()
    {
        string starts = Request.Form["start"];
        string limits = Request.Form["limit"];
        if (starts != null && limits != null)
        {
            int start = int.Parse(starts);
            int limit = int.Parse(limits);
            JSON = bll.GetRoleInfos(start, limit);
        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
