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

public partial class URL_Publish_AddPublishInfo : System.Web.UI.Page
{
    PublishBLL bll = new PublishBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        AddPublishs();
    }

    public void AddPublishs()
    {
        string pubperson = Request.Form["userid"];
        string pubtitle=Request.Form["pubtitle"];
        string pubcontent=Request.Form["pubcontent"];

        if(pubperson !=null && pubtitle !=null && pubcontent !=null)
        {
            PublishBean pub = new PublishBean();
            pub.pubperson = pubperson;
            pub.pubTitle = pubtitle;
            pub.pubContent = pubcontent;
            int count = bll.InsertPublishInfo(pub);
            if (count > 0)
            {
                Response.Write("{success:'true'}");
            }
            else {
                Response.Write("{success:'false'}");
            }

        }else
        {
            Response.Write("{success:'false'}");
        }
    }
}
