using System;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using Res.Pub;
using Res.BLL;
using Res.Model;
using System.Security.Cryptography;
using Res.Core;
using NetServ.Net.Json;
using System.Web.Security;

public partial class ModifyPassword : System.Web.UI.Page
{
    protected static int userId =0;
    WUserBLL bll = new WUserBLL();
    UserObj us = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 17;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!Page.IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "查看购物车", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            us = (UserObj)Session["MEB"];

            userId = us.USR_ID;
        }
    }
    protected void Submit1_ServerClick(object sender, EventArgs e)
    {

        if (this.Page.IsValid)
        {
            if (string.Compare(txtCode.Value.Trim(), Session["CheckCode"].ToString(), true) != 0)
            {
                string script = "<script type='text/javascript'>alert('验证码错误！');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
                return;
            }

            if (ComparePwd(this.oldPwd.Value.ToLower().ToLower()))
            {
                string newpwd = WebUtility.MD5(this.newPwd1.Value.ToLower().Trim());
                if (bll.ModifyPwd(userId, newpwd) > 0)
                {
                    string script = "<script type='text/javascript'>alert('修改成功！');</script>";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
                    return;
                }
                else
                {
                    string script = "<script type='text/javascript'>alert('修改失败！');</script>";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
                }
            }
            else
            {
                string script = "<script type='text/javascript'>alert('旧密码错误！');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
                return;
            }
 
        }

    }
    protected void Submit2_ServerClick(object sender, EventArgs e)
    {
        this.oldPwd.Value = "";
        this.newPwd1.Value = "";
        this.newPwd2.Value = "";
    }
    protected bool ComparePwd(string oldpwd)
    {
        string oldPwdStr = bll.GetPasswordByPspID(userId);
        string pwd = WebUtility.MD5(oldpwd);
        if (String.Compare(oldPwdStr, pwd)==0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
