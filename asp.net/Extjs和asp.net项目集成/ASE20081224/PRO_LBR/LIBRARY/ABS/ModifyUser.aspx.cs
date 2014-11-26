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

public partial class ModifyUser : System.Web.UI.Page
{
    TypeBLL bllType = new Res.BLL.TypeBLL();
    WUserBLL bll = new WUserBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 18;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "修改用户基本信息", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            UserObj us = (UserObj)Session["MEB"];

            BindComboboxValues();
            BindInitUserInfo();
        }
        
    }
    protected void btnModify_ServerClick(object sender, EventArgs e)
    {
        if (string.Compare(txtCode.Value.Trim(), Session["CheckCode"].ToString(), true) != 0)
        {
            string script = "<script type='text/javascript'>alert('验证码错误！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            return;
        }
        
        int pspId = ((UserObj)Session["MEB"]).USR_ID;

        int result= bll.ModifyWUser(pspId, txtPspEmail.Value, txtPspName.Value, Convert.ToInt32(rblSex.SelectedItem.Value), Convert.ToInt32(cmbAgeSplit.Value),
            Convert.ToInt32(ddlCity.SelectedValue), txtPspZip.Value, txtAddress.Value, txtPspTel.Value, txtPspFax.Value, cmbTrade.Value);
        if (result<=0)
        {
            string script = "<script type='text/javascript'>alert('修改个人信息失败!');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
        else
        {
            BindInitUserInfo();
            string script = "<script type='text/javascript'>alert('修改个人信息成功!');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
    }

    /// <summary>
    /// 绑定下拉列表的值


    /// </summary>
    private void BindComboboxValues()
    {
        //绑定年龄区间
        cmbAgeSplit.DataSource = bllType.GetAgesplit();
        cmbAgeSplit.DataTextField = "NAME";
        cmbAgeSplit.DataValueField = "ID";
        cmbAgeSplit.DataBind();
    }
    /// <summary>
    ///绑定初始用户信息
    /// </summary>
    private void BindInitUserInfo()
    {
        UserObj member = (UserObj)Session["MEB"];

        System.Data.SqlClient.SqlDataReader reader = bll.GetWUserById(member.USR_ID);
        if (reader.Read())
        {
            lblMobile.Text=reader["PSP_MOBILE"].ToString();
            txtAddress.Value = reader["PSP_ADDRESS"].ToString();
            txtPspEmail.Value = reader["PSP_EMAIL"].ToString();
            txtPspFax.Value = reader["PSP_FAX"].ToString();
            txtPspName.Value = reader["PSP_NAME"].ToString();
            txtPspTel.Value = reader["PSP_TEL"].ToString();
            txtPspZip.Value = reader["PSP_ZIP"].ToString();
            cmbAgeSplit.Value = reader["PSP_AGE_ID"].ToString();
            cmbTrade.Value = reader["PSP_MEMO"].ToString();
            ddlProvince.SelectedValue = reader["PRV_ID"].ToString();
            ddlProvince.DataBind();
            ddlCity.SelectedValue= reader["PSP_CTY_ID"].ToString();
            rblSex.SelectedValue = reader["PSP_GND_ID"].ToString();
        }
    }
}
