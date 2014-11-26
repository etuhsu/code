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

public partial class MyReceive : System.Web.UI.Page
{
    TypeBLL bllType = new Res.BLL.TypeBLL();
    WUserBLL bllUser = new WUserBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 20;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "收货人信息", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            UserObj us = (UserObj)Session["MEB"];
            hddPspId.Value = us.USR_ID.ToString();

            OrderBLL bllOrder=new OrderBLL ();
            int pspId=((UserObj)Session["MEB"]).USR_ID;
            Repeater1.DataSource = bllOrder.GetAddressList(pspId);
            Repeater1.DataBind();
        }
    }
    protected void ddl_province_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSave_ServerClick(object sender, EventArgs e)
    {
        OrderBLL bllOrder = new OrderBLL();
        OrderAddressObj model = new OrderAddressObj();
        int pspId = ((UserObj)Session["MEB"]).USR_ID;
        model.ORA_ADDRESS = txtAddress.Value.Trim();
        model.ORA_CREATIONUID = ((UserObj)Session["MEB"]).USR_LOGIN;
        model.ORA_CTY_ID = Convert.ToInt32(ddl_city.SelectedValue);
        model.ORA_NAME = txtName.Value.Trim();
        model.ORA_PHONE = txtPhone.Value.Trim();
        model.ORA_PSP_ID = Convert.ToInt32(hddPspId.Value.Trim());
        model.ORA_UPDATEUID = ((UserObj)Session["MEB"]).USR_LOGIN;
        model.ORA_ZIP = txtZip.Value.Trim();
        int oraId = 0;
        if (bllOrder.AddOrderAddress(model, out oraId) > 0)
        {
            Repeater1.DataSource = bllOrder.GetAddressList(pspId);
            Repeater1.DataBind();
            string script = "<script type='text/javascript'>alert('添加成功!');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
        else
        {
            string script = "<script type='text/javascript'>alert('添加失败!');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
    }
    protected void ddl_province_DataBound(object sender, EventArgs e)
    {
        ddl_province.Items.Insert(0, new ListItem("--请选择--", "0"));
    }
    protected void ddl_city_DataBound(object sender, EventArgs e)
    {
        ddl_city.Items.Insert(0, new ListItem("--请选择--", "0"));
    }
}
