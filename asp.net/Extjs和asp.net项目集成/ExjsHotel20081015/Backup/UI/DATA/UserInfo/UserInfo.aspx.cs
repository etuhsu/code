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

public partial class DATA_UserInfo_UserInfo : System.Web.UI.Page
{
    UserInfoBLL bll = new UserInfoBLL();
    public string JSON = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUserInfo();
    }
    public void GetUserInfo()
    { 
        string starts=Request.Form["start"];
        string limits=Request.Form["limit"];
        if(starts!=null&&limits!=null)
        {
            int start = int.Parse(starts);
            int limit = int.Parse(limits);
            JSON = bll.GetUserInfos(start, limit);
        }else{
            Response.Write("{success:'false'}");
        }
    
    }
}
