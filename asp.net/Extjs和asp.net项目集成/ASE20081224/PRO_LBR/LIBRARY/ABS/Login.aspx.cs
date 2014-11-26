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
using Res.BLL;
using Res.Model;
using Res.Core;

public partial class _Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgBtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        string code = txtCode.Text.Trim();
        if (string.Compare(txtCode.Text.Trim(), Session["CheckCode"].ToString(), true) != 0)
        {
            string script = "<script type='text/javascript'>alert('验证码错误！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            return;
        }

        bool flag = false;
        UserObj user = UserManager.Login(txtUserName.Text.Trim(), txtPwd.Text.Trim(), out flag);
        if (flag == true)
        {
            Session["user"] = user;
           // Response.Redirect("page/Customer/ShowGift.aspx?GIF_ID=15");
            Response.Redirect("page/user/NewIndex.aspx");
        }
        else
        {
            string script = "<script type='text/javascript'>alert('用户名或密码错误,登录失败！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
    }
    protected void imgBtnReset_Click(object sender, ImageClickEventArgs e)
    {
        txtUserName.Text = "";
        txtPwd.Text = "";
        txtCode.Text = "";
    }
}
