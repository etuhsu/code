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
using BLL;
using Model;

public partial class URL_Publish_EditPublishInfo : System.Web.UI.Page
{
    PublishBLL bll = new PublishBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        EditPublishInfo();
    }

    public void EditPublishInfo()
    {
        string pubid = Request.Form["pubid"];
        string pubtitle = Request.Form["pubtitle"];
        string pubcontent = Request.Form["pubcontent"];

        if (pubid != null && pubtitle != null && pubcontent != null)
        {
            PublishBean pub = new PublishBean();
            pub.pubID = int.Parse(pubid);
            pub.pubTitle = pubtitle;
            pub.pubContent = pubcontent;
            int count = bll.EditPublishInfo(pub);
            if (count > 0)
            {
                Response.Write("{success:'true'}");
            }
            else
            {
                Response.Write("{success:'false'}");
            }

        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
