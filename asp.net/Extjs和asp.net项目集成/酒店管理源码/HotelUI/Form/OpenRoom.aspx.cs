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
using HotelModels;

public partial class Form_OpenRoom : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            OpenRoom();
        }
    }


    /// <summary>
    /// 开房操作
    /// </summary>
    private void OpenRoom()
    {
        OpenRoomInfoBLL oriBll = new OpenRoomInfoBLL(); //逻辑层
        OpenRoomInfoBean orib = new OpenRoomInfoBean(); //实体Bean

        //得到表单提交的值
        orib.RoomId = int.Parse(Request.Form["RoomId"].ToString());
        orib.GuestNumber = Request.Form["guestNumber"];
        orib.GuestName = Request.Form["guestName"];
        orib.GuestMoney = double.Parse(Request.Form["money"].ToString());
        orib.Remark = Request.Form["remark"];
        string json;
        //如果success为true,则表示服务器端处理成功
        if (oriBll.OpenRoom(orib))
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
