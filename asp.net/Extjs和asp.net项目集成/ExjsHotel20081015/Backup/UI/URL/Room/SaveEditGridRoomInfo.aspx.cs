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


public partial class URL_Room_SaveEditGridRoomInfo : System.Web.UI.Page
{
    RoomBLL bll = new RoomBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        SaveRoomInfo();
    }

    public void SaveRoomInfo()
    { 
        string roomids=Request.Form["roomid"];
        string field=Request.Form["field"];
        string value=Request.Form["value"];

        if (roomids != null && field != null && value != null)
        {
            int roomid = int.Parse(roomids);
            RoomBean room = bll.getRoonInfosNoState(roomid);

            if(field=="bednumber")
            {
                room.bedNumber = int.Parse(value);
            }
            else if(field=="guestnumber")
            {
                room.guestNumber = int.Parse(value);
            }
            else if (field == "typeid")
            {
                room.typeid = int.Parse(value);
            }
            else if (field == "roomstate")
            {
                room.roomstate = int.Parse(value);
            }
            else if (field == "roomdesc")
            {
                room.roomDesc = value;
            }

            int count = bll.SaveRoomInfo(room);

            if(count>0)
            {
                Response.Write("{success:'true'}");
            }else{
                Response.Write("{success:'false'}");
            }
        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
