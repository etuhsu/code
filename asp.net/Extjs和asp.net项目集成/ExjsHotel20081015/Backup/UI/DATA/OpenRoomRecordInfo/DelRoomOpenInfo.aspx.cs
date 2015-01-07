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

public partial class DATA_OpenRoomRecordInfo_DelRoomOpenInfo : System.Web.UI.Page
{
    OpenRoomRecordInfoBLL bll = new OpenRoomRecordInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllMoney();
    }
    public void GetAllMoney()
    { 
        string roomid=Request.QueryString["roomid"];

        if (roomid != null)
        {
            string AllMeney = bll.GetRoomMoney(roomid);

            Response.Write(AllMeney);

        }
    }
}
