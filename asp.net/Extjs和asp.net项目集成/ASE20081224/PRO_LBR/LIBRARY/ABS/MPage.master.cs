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

public partial class MPage : System.Web.UI.MasterPage
{
    protected string menu;
    protected void Page_Load(object sender, EventArgs e)
    {
        menu = WebUtility.GetMenuString();
        if (!Page.IsPostBack)
        {
            if (Session["meb"] != null)
            {
                string user=((Res.Model.UserObj)Session["meb"]).USR_NAME;
                lb_login.Text = "<a href=\"ModifyUser.aspx\"><span style=\"color:Red\">欢迎您:"+user+"</span></a>";
            }
            else
            {
                lb_login.Text = "<a href=\"WLogin.aspx\">登陆</a>&nbsp;&nbsp;<a href=\"Wreg.aspx\">注册</a>";
            }
        }
    }
}
