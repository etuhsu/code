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

public partial class URL_Publish_DelPublishInfo : System.Web.UI.Page
{
    PublishBLL bll = new PublishBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        DelPublishInfo();
    }

    public void DelPublishInfo()
    {
        string pubids = Request.Form["pubids"];

        if (pubids != null)
        {
            string[] pubid = pubids.Split(',');

            try
            {
                foreach (string p in pubid)
                {
                    bll.DelPublishInfo(int.Parse(p));
                }
                Response.Write(@"{success:true}");
            }
            catch (Exception)
            {

                Response.Write(@"{success:false}");
            }


        }
        else
        {
            Response.Write(@"{success:false}");
        }
    }
}
