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

public partial class SendMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 23;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!IsPostBack)
        {
            ChildExtObj node=(ChildExtObj)Session["PIC"];
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "推荐商品给好友", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            
            if (node==null)
            {
                Response.Redirect("error.aspx?type=1");
            }
            else
            {
                imgProduct.Src = node.ChildName;
                ltrProductName.Text = node.NAME;
            }
        }
    }
    protected void btnSend_ServerClick(object sender, EventArgs e)
    {
        //System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

        System.Web.Mail.MailMessage msg = new System.Web.Mail.MailMessage();
        msg.Subject = "ABS精品推荐";
        
        System.Text.StringBuilder strHtml=new System.Text.StringBuilder ();
        Res.Model.ChildExtObj node = (Res.Model.ChildExtObj)Session["PIC"];
        strHtml.Append("<div style=\" margin-top: 5px;  border-right: 1px solid #c9c9c9;\">");
        strHtml.Append(" <div style=\"padding: 20px;\">&nbsp;<a href=\"http://www.abs.cn/SingleHeader.aspx?PRH_ID=" + node.ID + "\"><img style=\"border: 1px solid #000000\" src=\"http://www.abs.cn/" + node.ChildName + "\"/></div>");
		strHtml.Append(" <div style=\"text-align: center; font-weight: bold;\">"+node.NAME+"</div>");
        strHtml.Append("<p>" + txtCall.Value.Trim() + ":<br>&nbsp;&nbsp;&nbsp;&nbsp;你好!<br>&nbsp;&nbsp;&nbsp;&nbsp;我是"+txtMyName.Value+",我在ABS网站上向你推荐以上产品,也许你会喜欢.</p></div>");

        msg.Body = strHtml.ToString();

        msg.Cc = txtEmail.Value.Trim();
        try
        {
            WebUtility.SendMailMessage(msg, "abs");
            string script = "<script type='text/javascript'>alert('邮件发送成功！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }
        catch (System.Net.Mail.SmtpException)
        {
            string script = "<script type='text/javascript'>alert('邮件发送失败！');</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        }

        //Response.Write(strHtml.ToString());
    }

   
}
