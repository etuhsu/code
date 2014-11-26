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

public partial class URL_Room_DelRoomInfo : System.Web.UI.Page
{
    RoomBLL bll = new RoomBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        DeleteRoomInfo();
    }
    public void DeleteRoomInfo()
    { 
        string roomids=Request.Form["roomid"];

        if (roomids != null)
        {
            string[] roomid = roomids.Split(',');

            try
            {
                foreach (string r in roomid)
                {
                    bll.DelRoomInfos(int.Parse(r));
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
