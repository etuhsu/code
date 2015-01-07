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
using HotelBLL;

public partial class Json_GetRoomByTypeId : System.Web.UI.Page
{

    protected string strJson = "";
    RoomBLL rBll = new RoomBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ShowData();
        }
        catch (Exception)
        {
            strJson = @"{success: false}";//失败
        }
    }


    private void ShowData()
    {
        if (Request.Form["typeId"] != null)
        {
            int typeId = int.Parse(Request.Form["typeId"]);
            string str = rBll.GetRoomByTypeId(typeId);
            strJson = str;
        }
        else
        {
            string str = rBll.GetRoomByTypeId(1);
            strJson = str;
        }
    }
}
