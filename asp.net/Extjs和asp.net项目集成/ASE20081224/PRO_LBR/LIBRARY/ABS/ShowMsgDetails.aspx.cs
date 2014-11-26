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

public partial class ShowMsgDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int PageID = ;
        //Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "查看留言信息", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            UserObj user = (UserObj)Session["MEB"];

            if (string.IsNullOrEmpty(Request.QueryString["CPL_ID"])==true)
            {
                Response.Redirect("error.aspx?type=1");
            }

            int cpl_id = Convert.ToInt32(Request.QueryString["CPL_ID"]);
            Res.BLL.ComplainBLL bll = new Res.BLL.ComplainBLL();
            Res.Model.ComplainObj model= bll.GetComplainById(cpl_id);
            ltrTitle.Text = model.CPL_TITLE;
            ltrContent.Text = model.CPL_MEMO;
            ltrDate.Text = model.CPL_DT.ToString("yyyy年MM月dd日");
        }
    }
}
