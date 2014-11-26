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


public partial class DATA_RoomType_LoadEditRoomTypeForm : System.Web.UI.Page
{
    RoomTypeBLL bll = new RoomTypeBLL();
    public string json = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRoomTypeInfo();
    }

    public void GetRoomTypeInfo()
    { 
        string typeid=Request.QueryString["typeid"];
        if (typeid != null)
        {
            json = bll.getRoomTypeInfo(int.Parse(typeid));

        }
        else
        {
            Response.Write("success:false");
        }
    }
}
