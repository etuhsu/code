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
using Vifir.Model.Service;
using Vifir.Core;
using Vifir.Model.Domain;
//该源码下载自www.51aspx.com(５1ａｓｐｘ．ｃｏｍ)

namespace Vifir.Web.manage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserContext.isAdmin())
            {
                Response.Redirect("login.html");
            }
        }
    }
}
