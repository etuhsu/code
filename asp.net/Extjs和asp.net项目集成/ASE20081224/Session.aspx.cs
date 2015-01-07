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

public partial class PAGE_Server_Session : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //string strUrl;
        //strUrl =Request.UrlReferrer.ToString();
        //if (strUrl.IndexOf("/eas") > 1)
        //{
      
            if (string.IsNullOrEmpty(Request["user"]))// = null || Request["user"] == "")
            {
                Response.Redirect("");
                return;
            }
            else
            {
                Session["user"] = Request["user"].ToString();
                Response.Redirect("page/Application/GetApplication.aspx");
            }

        //else {
        //    Response.Redirect("http://eas.gaptl.com");
        //}
    }
}
