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

public partial class Form_DelRoom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DelRoom();
        }
    }


    /// <summary>
    /// 删除客房表(根据房间编号)
    /// </summary>
    private void DelRoom()
    {
        RoomBLL rBll = new RoomBLL();
        //得到表单提交的值
        string Number = Request.Form["Number"].ToString();
        string json;
        //如果success为true,则表示服务器端处理成功
        if (rBll.DelRoom(Number))
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
