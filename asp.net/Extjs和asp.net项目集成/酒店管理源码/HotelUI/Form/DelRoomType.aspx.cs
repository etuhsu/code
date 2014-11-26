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

public partial class Form_DelRoomType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DelRoomType();
        }
    }


    /// <summary>
    /// 删除房间类型(根据类型Id)
    /// </summary>
    private void DelRoomType()
    {
        RoomTypeBLL rtBll = new RoomTypeBLL();
        //得到表单提交的值
        int TypeId = int.Parse(Request.Form["TypeId"].ToString());
        string json;
        //如果success为true,则表示服务器端处理成功
        if (rtBll.DelRoomType(TypeId))
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
