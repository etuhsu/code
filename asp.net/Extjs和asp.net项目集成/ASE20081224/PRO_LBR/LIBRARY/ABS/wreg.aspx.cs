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

public partial class wreg : System.Web.UI.Page
{
    TypeBLL bllType = new Res.BLL.TypeBLL();
    WUserBLL bll = new WUserBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int PageID = 7;
            Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
            BindComboboxValues();
        }

    }
    protected void btnRegister_ServerClick(object sender, EventArgs e)
    {
        if (string.Compare(txtCode.Value.Trim(), Session["CheckCode"].ToString(), true) != 0)
        {
            string script = "<script type='text/javascript'>alert('验证码错误！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            return;
        }
        int psp_id = 0;
        string user = txtPspMobile.Value.Trim();
        if (bll.CheckUserRegister(user))
        {
            string script = "<script type='text/javascript'>alert('对不起，用户名" + user + "已经存在！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            return;
        }
        string pwd = WebUtility.MD5(txtPspPwd.Value.Trim());
        string recomander = txtRecomand.Value.Trim();

        int recomandId = bll.GetPspIdByLoginName(recomander);

        int result = bll.Register(out psp_id, user, txtPspEmail.Value, txtPspNmae.Value,
            Convert.ToInt32(rblSex.SelectedItem.Value),
            Convert.ToInt32(ddlAgeSplit.SelectedValue), Convert.ToInt32(ddlCity.SelectedValue),
            txtPspZip.Value, txtAddress.Value, txtPspTel.Value, txtPspFax.Value,
            recomandId, Convert.ToInt32(ddlDts.SelectedValue), cmbTrade.Value=="0"?"":cmbTrade.Value);
        if (result > 0)
        {
            bll.AddWUserLogin(psp_id, user, pwd);
            string script = "<script type='text/javascript'>alert('注册成功！');window.location.href='wlogin.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
        else
        {
            string script = "<script type='text/javascript'>alert('注册失败！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
    }
    /// <summary>
    /// 绑定下拉列表的值

    /// </summary>
    private void BindComboboxValues()
    {
        //绑定年龄区间
        ddlAgeSplit.DataSource = bllType.GetAgesplit();
        ddlAgeSplit.DataTextField = "NAME";
        ddlAgeSplit.DataValueField = "ID";
        ddlAgeSplit.DataBind();

        ddlDts.DataSource = bllType.GetDataSurceName();
        ddlDts.DataTextField = "NAME";
        ddlDts.DataValueField = "ID";
        ddlDts.DataBind();
    }
    protected void ddlCity_DataBound(object sender, EventArgs e)
    {
        ddlCity.Items.Insert(0, new ListItem("--请选择--", "0"));
    }
    protected void ddlProvince_DataBound(object sender, EventArgs e)
    {
        ddlProvince.Items.Insert(0, new ListItem("--请选择--","0"));
    }
    protected void ddlAgeSplit_DataBound(object sender, EventArgs e)
    {
        ddlAgeSplit.Items.Insert(0, new ListItem("--请选择--", "0"));
    }
    protected void ddlDts_DataBound(object sender, EventArgs e)
    {
        ddlDts.Items.Insert(0, new ListItem("--请选择--", "0"));
    }
}
