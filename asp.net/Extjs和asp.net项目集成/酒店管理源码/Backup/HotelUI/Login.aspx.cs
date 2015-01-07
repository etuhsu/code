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
using HotelModels;
using HotelBLL;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (this.txtName.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入用户名!')</script>");
        }
        else if (this.txtPass.Text.Trim() == "")
        {
            Response.Write("<script>alert('请输入密码!')</script>");
        }
        else
        {
            UserInfoBean uib = new UserInfoBean();
            UserInfoBLL userBll = new UserInfoBLL(); //逻辑层

            uib.LoginName = this.txtName.Text.Trim();
            uib.LoginPass = this.txtPass.Text.Trim();

            if (userBll.GetLogin(uib))
            {
                Session["LoginName"] = this.txtName.Text.Trim();
                Response.Redirect("index.aspx");
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误!')</script>");
            }
        }
      
    }

    protected void btnOut_Click(object sender, ImageClickEventArgs e)
    {

    }
}
