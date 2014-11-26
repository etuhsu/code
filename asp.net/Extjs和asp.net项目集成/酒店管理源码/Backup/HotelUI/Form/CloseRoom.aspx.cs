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

public partial class Form_CloseRoom : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CloseRoom();        
        }
    }



    /// <summary>
    /// 退房操作
    /// </summary>
    private void CloseRoom()
    {
        OpenRoomInfoBLL orBll = new OpenRoomInfoBLL();
        string RoomNumber = Request.Form["RoomNumber"].ToString();
        string json;
        //如果success为true,则表示服务器端处理成功
        if (orBll.CloseRoom(RoomNumber))
        {
            json = @"{success: true}";
        }
        else
        {
            json = @"{success: false}";
        }
        Response.Write(json);
    }
}
