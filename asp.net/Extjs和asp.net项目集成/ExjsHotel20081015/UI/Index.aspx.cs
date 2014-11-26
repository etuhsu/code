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

public partial class Index : System.Web.UI.Page
{
    public string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = Number.userid;

        if (Session["Login"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
