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


public partial class DATA_OpenRoomRecordInfo_OpenRoomRecordInfo : System.Web.UI.Page
{
    public string JSON = "";

    OpenRoomRecordInfoBLL bll = new OpenRoomRecordInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetOpenRoomRecordInfo();
    }

    public void GetOpenRoomRecordInfo()
    { 
        string starts=Request.Form["start"];
        string limits = Request.Form["limit"];
        string message = Request.Form["msg"];

        if(starts!=null && limits!=null)
        {
         
                int start = int.Parse(starts);
                int limit = int.Parse(limits);
                JSON = bll.GetOpenRoomRecordInfos(start,limit,message);

        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
