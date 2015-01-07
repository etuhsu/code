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

public partial class URL_GuestInfo_DelGuestInfo : System.Web.UI.Page
{
    GuestInfoBLL bll = new GuestInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        DelGuestInfo();
    }

    public void DelGuestInfo()
    {
        string guestids = Request.Form["guestids"];

        if (guestids != null)
        {
            string [] guestid = guestids.Split(',');

            foreach(string gid in guestid)
            {
                int guest = int.Parse(gid);
                try
                {
                    int count = bll.DeleteGuestInfo(guest);
                }
                catch (Exception)
                {

                    Response.Write("{success:'false'}");
                }
                
            }
            Response.Write("{success:'true'}");
        }
        else {

            Response.Write("{success:'false'}");
        }
    }
}
