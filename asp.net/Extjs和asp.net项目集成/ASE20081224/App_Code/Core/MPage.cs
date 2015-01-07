using System;
using System.Data;
using System.Configuration;
using System.Web;
using Res.Pub;
//该源码下载自www.51aspx.com(５1ａｓｐｘ．ｃｏｍ)

using Res.Model;
using Res.Core;
namespace Res.Core
{
    /// <summary>
    /// MPage 的摘要说明

    /// </summary>
    public class MPage : System.Web.UI.Page
    {
        protected string _logo;
        protected int PID;
        public MPage()
        {
           // Logo = "../../logo.jpg";
        }
       /* protected void MPage_Load()
        {
            UserObj us = (UserObj)(Session["user"]);
            if (UserManager.IsAuthenticated(Session) == false)
            {
                Response.Redirect("../../login.aspx");
                return;
            }
            UserBLL bll = new UserBLL();
            if (bll.CheckPermissionPage(us.USR_ID, PID) == false)
            {
                Response.Redirect("../../error.aspx?type=4");
                return;
            }
        }
        public string Logo
        {
            set { _logo = value; }
            get { return _logo; }
        }*/
    }
}
