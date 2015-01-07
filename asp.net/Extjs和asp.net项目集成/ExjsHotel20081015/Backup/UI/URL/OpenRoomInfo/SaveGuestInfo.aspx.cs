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

public partial class URL_OpenRoomInfo_SaveGuestInfo : System.Web.UI.Page
{
    GuestInfoBLL bll = new GuestInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        AddGuestInfo();
    }

    public void AddGuestInfo()
    { 
        string GuestCardId=Request.Form["guestcardid"];
        string GuestName=Request.Form["guestname"];
        string GuestSex=Request.Form["guestsex"];
        string GuestMobile=Request.Form["guestmobile"];
        string GuestAddress=Request.Form["guestaddress"];

        if(GuestCardId!=null && GuestName!=null)
        {
            GuestInfoBean guest = new GuestInfoBean();
            guest.GuestCardID=decimal.Parse(GuestCardId);
            guest.GuestName = GuestName;
            guest.GuestSex = int.Parse(GuestSex);
            guest.GuestMobile = decimal.Parse(GuestMobile);
            guest.GuestAddress = GuestAddress;

            int count = bll.SaveGuestInfo(guest);
            if(count>0)
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
