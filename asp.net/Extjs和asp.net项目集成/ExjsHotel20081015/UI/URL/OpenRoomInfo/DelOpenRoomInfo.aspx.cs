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


public partial class URL_OpenRoomInfo_DelOpenRoomInfo : System.Web.UI.Page
{
    OpenRoomInfoBLL bll = new OpenRoomInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        DeleteOpenRoomInfo();
    }

    public void DeleteOpenRoomInfo()
    { 
        string openroomid=Request.Form["openroomid"];

        if (openroomid != null)
        {
            int count = bll.DelOpenRoomInfo(int.Parse(openroomid));
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
