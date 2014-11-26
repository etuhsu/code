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
using Model;

public partial class DATA_UserInfo_LoadUserInfo : System.Web.UI.Page
{
    UserInfoBLL bll = new UserInfoBLL();
    public string JSON = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        GetUserInfoByID();
    }

    public void GetUserInfoByID()
    { 
        string id=Request.QueryString["loginid"];
        if (id != null)
        {
            JSON = bll.GetUserInfoByID(id);
        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
