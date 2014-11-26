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

public partial class URL_Room_RoomIDIsOK : System.Web.UI.Page
{
    RoomBLL bll = new RoomBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        NumberIsOK();
    }

    public void NumberIsOK()
    { 
        string roomid=Request.Form["roomid"];

        if (roomid != null)
        {
            int count = bll.RoomIDIsOK(roomid);
            if (count > 0)
            {
                Response.Write(@"{success:true}");
            }
            else
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
