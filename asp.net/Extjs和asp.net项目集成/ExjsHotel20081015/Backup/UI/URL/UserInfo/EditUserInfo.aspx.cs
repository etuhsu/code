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

public partial class URL_UserInfo_EditUserInfo : System.Web.UI.Page
{
    UserInfoBLL bll = new UserInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        EditUserInfo();
    }

    public void EditUserInfo()
    {
        string userid = Request.Form["userid"];
        string username = Request.Form["username"];
        string userpwd = Request.Form["userpwd"];
        string userstate = Request.Form["userstate"];
        string roleid = Request.Form["roleids"];

        if (userid != null && username != null && userpwd != null)
        {
            UserInfoBean user = new UserInfoBean();
            user.userid = userid;
            user.userName = username;
            user.userPwd = userpwd;
            user.userState = int.Parse(userstate);
            user.roleid = int.Parse(roleid);

            int count = bll.EditUserInfo(user);
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
