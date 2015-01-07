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

public partial class DATA_GuestInfo_GuestInfo : System.Web.UI.Page
{
    public string JSON = "";
    GuestInfoBLL bll = new GuestInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetGuestInfo();
    }

    public void GetGuestInfo()
    { 
        string limits=Request.Form["limit"];
        string starts=Request.Form["start"];

        if (limits != null && starts != null)
        {
            int limit = int.Parse(limits);
            int start = int.Parse(starts);
            JSON = bll.GetGuestInfos(start, limit);
        }
        else
        {
            Response.Write("{success:false}");
        }
    }
}
