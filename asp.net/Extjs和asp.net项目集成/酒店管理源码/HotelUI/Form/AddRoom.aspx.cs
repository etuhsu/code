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

public partial class Form_AddRoom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AddRoom();
        }
    }


    /// <summary>
    /// 添加客房表
    /// </summary>
    private void AddRoom()
    {
        RoomBLL rBll = new RoomBLL(); //逻辑层
        RoomBean rb = new RoomBean();
        //得到表单提交的值
        rb.Number = Request.Form["Number"];
        //分别给实体Bean赋值
        rb.BedNumber = int.Parse(Request.Form["BedNumber"].ToString());
        rb.TypeId = int.Parse(Request.Form["TypeId"].ToString());
        rb.StateId = int.Parse(Request.Form["StateId"].ToString());
        rb.Remark = Request.Form["remark"];
        string json;
        //如果success为true,则表示服务器端处理成功
        if (rBll.AddRoom(rb))
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
