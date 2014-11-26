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

public partial class URL_UserInfo_SavePwdUserInfo : System.Web.UI.Page
{
    UserInfoBLL bll = new UserInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        SaveUserInfoPwd();
    }

    public void SaveUserInfoPwd()
    { 
        string userid=Request.Form["userid"];
        string userpwd=Request.Form["userpwd2"];
        if (userid != null && userpwd != null)
        {
            int count = bll.SaveUserPwdInfo(userid, userpwd);
            if (count > 0)
            {
                Response.Write("{success:'true'}");
            }
            else
            {
                Response.Write("{success:'false'}");
            }
        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
