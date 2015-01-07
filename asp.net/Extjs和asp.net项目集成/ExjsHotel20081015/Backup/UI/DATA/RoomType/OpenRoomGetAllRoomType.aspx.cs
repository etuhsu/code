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

public partial class DATA_RoomType_OpenRoomGetAllRoomType : System.Web.UI.Page
{
    RoomTypeBLL bll = new RoomTypeBLL();
    public string JSON = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllRoomType();
    }

    public void GetAllRoomType()
    {
        try
        {
            JSON = bll.OpenRoomGetAllRoomTypeInfos();
        }
        catch (Exception)
        {
            
            throw;
        }
    
    }
}
