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


public partial class DATA_ToDayTypePrice : System.Web.UI.Page
{
    public string json = "";
    RoomTypeBLL bll = new RoomTypeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        ToDayRoomTypePrice();
    }
    public void ToDayRoomTypePrice()
    {
        try
        {
            json = bll.getToDayRoomTypeInfo();
            
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}
