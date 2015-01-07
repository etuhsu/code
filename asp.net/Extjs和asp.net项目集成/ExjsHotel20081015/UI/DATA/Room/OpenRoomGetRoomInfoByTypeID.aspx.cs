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

public partial class DATA_Room_OpenRoomGetRoomInfoByTypeID : System.Web.UI.Page
{
    public string JSON = "";
    RoomBLL bll = new RoomBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRoomInfoBytypeid();
    }
    public void GetRoomInfoBytypeid()
    {
        string typeid=Request.QueryString["typeid"];

        if (typeid != null)
        {
            JSON = bll.GetRoomInfosByTypeid(int.Parse(typeid));
        }
        else
        {
            Response.Write("{success:'false'}");
        }
    
    }
}
