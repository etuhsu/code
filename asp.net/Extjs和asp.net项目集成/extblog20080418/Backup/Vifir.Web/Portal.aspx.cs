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
using Vifir.Model.Service;
using Vifir.Core;
using Vifir.Model.Domain;
using Spring.Context;
using Spring.Context.Support;
public partial class Portal : Vifir.Core.Web.AbstractCmdPage
{
    private IBlogService blogService;

    public IBlogService BlogService
    {
        set { blogService = value; }
    }

    public void AdminLogin()
    {   
        string name = Request.Params["userName"];
        if (name != null)
        {
          bool ret = blogService.adminLogin(name, Request.Params["password"]);
          if (ret)
          {
             Session.Add("ADMIN", "true");
          }
          else
           {
              AddError("msg", "用户名或密码错误，请重新登录!");
           }
           }   
        extFormResult = true;
    }

    public void adminLogout()
    {
        if (Session["ADMIN"].ToString() == "true")
        {
            Session.Remove("ADMIN");
            Response.Redirect("~/Default.aspx");
           
        }
    }
}
