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

public partial class DATA_RoomType_RoomType : System.Web.UI.Page
{
    public string RoomTypeJSON = "";
    RoomTypeBLL bll = new RoomTypeBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        string starts = Request.Form["start"];
        string limits = Request.Form["limit"];
        int start = 0;
        if(starts!=null)
        {
            start = int.Parse(starts);
        }

        int limit = 0;
        if (limits != null)
        {
            limit = int.Parse(limits);
        }
        GetRoomtypeJSON(start, limit);

    }

    public void GetRoomtypeJSON(int start,int limit)
    { 

        RoomTypeJSON=bll.getRoomTypeInfo(start,limit);
        
    }
}
