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
using Res.Model;
using Res.BLL;

public partial class LeaveMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int PageID = ;
        //Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "留言信息列表", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            UserObj user = (UserObj)Session["MEB"];
            hddPspId.Value = user.USR_ID.ToString();
        }
    }

    protected string FormatDate(object obj)
    {
        if (obj!=DBNull.Value)
        {
            return Convert.ToDateTime(obj).ToString("yyyy年MM月dd日");
        }
        else
        {
            return "";
        }
    }
    protected void lnkBtnLeaveMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMessage.aspx");
    }
    protected void rptMessages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName=="Show")
        {
            string url="ShowMsgDetails.aspx?id="+e.CommandArgument.ToString();
            string script = "<script type='text/javascript'>window.open("+url+",'查看产品大图','height=600,width=800,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no,title=no');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
    }
}
