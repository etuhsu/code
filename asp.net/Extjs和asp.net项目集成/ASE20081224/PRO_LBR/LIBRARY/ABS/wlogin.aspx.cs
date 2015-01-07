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

public partial class wlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int PageID = 6;
            Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        }
    }
    protected void imgBtnWLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid == false)
        {
            return;
        }

        string user = txtUser.Value.Trim();
        string pwd = txtPwd.Value.Trim();
        string code = txtCode.Value.Trim();
        if (string.Compare(txtCode.Value.Trim(), Session["CheckCode"].ToString(), true) != 0)
        {
            string script = "<script type='text/javascript'>alert('验证码错误！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            return;
        }

        Res.BLL.WUserBLL bll = new Res.BLL.WUserBLL();
        int pspId = bll.GetPspIdByLoginName(user);
        if (bll.Login(user, WebUtility.MD5(pwd)) && pspId != -1)
        {
            Res.Model.UserObj member = new Res.Model.UserObj();

            
            member = bll.GetLoginInfoByLoginName(user);
            Session["meb"] = member;

            string nextUrl = WebUtility.GetBackUrl(Request, Response);
            if (string.IsNullOrEmpty(nextUrl))
            {
                string script = "<script type='text/javascript'>alert('登录成功！');window.location.href='Index.aspx';</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            }
            else
            {
                string script = "<script type='text/javascript'>alert('登录成功！');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
                string[] strs = nextUrl.Split('/');
                Response.Redirect(strs[strs.Length-1]);
            }
        }
        else
        {
            string script = "<script type='text/javascript'>alert('用户名或密码错误，登录失败！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
    }
}