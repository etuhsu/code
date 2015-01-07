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


public partial class URL_Room_AddRoomInfo : System.Web.UI.Page
{
    RoomBLL bll = new RoomBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        AddRoomInfo();
    }

    public void AddRoomInfo()
    { 
        string number=Request.Form["number"];
        string bednumber=Request.Form["bednumber"];
        string guestnumber=Request.Form["guestnumber"];
        string typeid=Request.Form["typeid"];
        string roomstate=Request.Form["roomstate"];
        string roomdesc=Request.Form["roomdesc"];

        if (number != null && bednumber != null && guestnumber != null)
        {
            RoomBean room = new RoomBean();
            room.Number = number;
            room.bedNumber = int.Parse(bednumber);
            room.guestNumber = int.Parse(guestnumber);
            room.typeid = int.Parse(typeid);
            room.roomstate = int.Parse(roomstate);
            room.roomDesc = roomdesc;

            int count = bll.AddRoomInfo(room);
            if (count > 0)
            {
                Response.Write("{success:'true'}");
            }
            else {
                Response.Write("{success:'false'}");
            }
        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
