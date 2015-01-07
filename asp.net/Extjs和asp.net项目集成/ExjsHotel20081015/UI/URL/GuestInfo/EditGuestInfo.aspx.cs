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

public partial class URL_GuestInfo_EditGuestInfo : System.Web.UI.Page
{
    GuestInfoBLL bll = new GuestInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        EditSaveGuestInfos();
    }
    public void EditSaveGuestInfos()
    { 
        string guestid=Request.Form["guestid"];
        string guestcardid=Request.Form["guestcardid"];
        string guestname=Request.Form["guestname"];
        string guestsex=Request.Form["guestsex"];
        string guestmobile=Request.Form["guestmobile"];
        string guestaddress=Request.Form["guestaddress"];

        if (guestid != null && guestcardid != null && guestname != null)
        {
            GuestInfoBean guest = new GuestInfoBean();
            guest.Guestid = int.Parse(guestid);
            guest.GuestCardID = decimal.Parse(guestcardid);
            guest.GuestName = guestname;
            guest.GuestSex = int.Parse(guestsex);
            guest.GuestMobile = decimal.Parse(guestmobile);
            guest.GuestAddress = guestaddress;

            int count = bll.EditSaveGuestInfo(guest);
            if(count>0)
            {
                Response.Write("{success:'true'}");
            }else
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
