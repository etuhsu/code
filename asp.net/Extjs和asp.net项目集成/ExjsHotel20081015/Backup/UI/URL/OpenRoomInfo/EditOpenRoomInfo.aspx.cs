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

public partial class URL_OpenRoomInfo_EditOpenRoomInfo : System.Web.UI.Page
{
    OpenRoomInfoBLL bll = new OpenRoomInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        EditOpenRoomInfos();
    }
    public void EditOpenRoomInfos()
    { 
        string roomid=Request.Form["roomid"];
        string guestmoney=Request.Form["guestmoney"];
        string remark=Request.Form["remark"];

        if (roomid != null && guestmoney != null)
        {
            OpenRoomInfoBean open = new OpenRoomInfoBean();
            open.Roomid = int.Parse(roomid);
            open.GuestMoney = decimal.Parse(guestmoney);
            open.Remark = remark;

            int count = bll.EditOpenRoomInfo(open);
            if (count > 0)
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
