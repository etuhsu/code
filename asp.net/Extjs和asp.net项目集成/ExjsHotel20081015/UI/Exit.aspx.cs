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
//该源码首发自www.51aspx.com(５１aｓｐｘ．ｃｏｍ)

public partial class Exit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Login"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            Session["Login"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}
