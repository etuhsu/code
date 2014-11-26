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

public partial class DATA_OpenRoomInfo_RoomOpenInfo : System.Web.UI.Page
{
    public string RoomOpenJSON = "";
    OpenRoomInfoBLL bll = new OpenRoomInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        string starts = Request.Form["start"];
        string limits = Request.Form["limit"];

        int start = 0;
        if (starts != null)
        {
            start = int.Parse(starts);
        }

        int limit = 0;
        if (limits != null)
        {
            limit = int.Parse(limits);
        }
        openRoomInfo(start, limit);
    }
    public void openRoomInfo(int start, int limit)
    {
        try
        {
            RoomOpenJSON = bll.PageingOpenRoomInfo(start,limit);
        }
        catch (Exception)
        {
            
            throw;
        }
        
    }
}
