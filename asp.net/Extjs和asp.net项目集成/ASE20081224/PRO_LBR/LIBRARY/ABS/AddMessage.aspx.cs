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

public partial class AddMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int PageID = ;
        //Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "添加留言信息", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }       
            UserObj user = (UserObj)Session["MEB"];
            hddPspId.Value = user.USR_ID.ToString();
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        UserObj user = (UserObj)Session["MEB"];
        Res.BLL.ComplainBLL bll = new Res.BLL.ComplainBLL();
        Res.Model.ComplainObj model = new Res.Model.ComplainObj();
        model.CPL_CLS_ID = 1;//状态，未处理

        model.CPL_CPT_ID = 3;//类型，客户留言
        model.CPL_CREATION_DT = DateTime.Now;
        model.CPL_CREATIONUID = user.USR_LOGIN;
        model.CPL_DT = DateTime.Now;
        model.CPL_MEMO = txtContent.Text;
        model.CPL_PSP_ID =Convert.ToInt32(hddPspId.Value.Trim());
        model.CPL_TITLE = txtTitle.Text.Trim();
        model.CPL_UPDATE_DT = DateTime.Now;
        model.CPL_UPDATEUID = user.USR_LOGIN;
       int cpl_id;
        if (bll.AddComplain(model, out cpl_id) > 0)
        {
            string script = "<script type='text/javascript'>alert('添加留言成功！');window.location.href='LeaveMessage.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
            return;
        }
        else
        {
            string script = "<script type='text/javascript'>alert('添加留言失败！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
            return;
        }
    }
}
