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

public partial class URL_UserInfo_DelUserInfo : System.Web.UI.Page
{
    UserInfoBLL bll = new UserInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        DelUserInfo();
    }

    public void DelUserInfo()
    { 
        string userinfo=Request.Form["userinfo"];
        if (userinfo != null)
        {
            string[] userinfos = userinfo.Split(',');

            foreach (string u in userinfos)
            {
                try
                {
                    bll.DelUserInfo(int.Parse(u));
                }
                catch (Exception)
                {

                    Response.Write(@"{success:'false'}");
                }

            }

            Response.Write(@"{success:'true'}");
        }
        else
        {
            Response.Write(@"{success:'false'}");
        }
    }
}
