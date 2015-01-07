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

public partial class Form_AddRoomType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AddRoomType();
        }
    }


    /// <summary>
    /// 添加房间类型
    /// </summary>
    private void AddRoomType()
    {
        RoomTypeBLL rtBll = new RoomTypeBLL();
        RoomTypeBean rtb = new RoomTypeBean();
        //得到表单提交的值
        rtb.TypeName = Request.Form["TypeName"];
        rtb.TypePrice = double.Parse(Request.Form["TypePrice"].ToString());
        rtb.IsTv = Request.Form["IsTv"];
        rtb.IsKongTiao = Request.Form["IsKongTiao"];
        rtb.Remark = Request.Form["remark"];
        string json;
        //如果success为true,则表示服务器端处理成功
        if (rtBll.AddRoomType(rtb))
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
