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

public partial class Json_GetAllRoomType : System.Web.UI.Page
{

    protected string strJson = "";
    RoomTypeBLL rtb = new RoomTypeBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                GetAllRoomType();
            }
            catch (Exception)
            {
                strJson = @"{success: false}";//失败
            }
        }
    }


    /// <summary>
    /// 查询所有房间类型(查询房间类型用到,带搜索)
    /// </summary>
    private void GetAllRoomType()
    {
        if (Request.Form["msg"] != null)
        {
            string message = Request.Form["msg"];
            string str = rtb.GetAllRoomType(message);
            strJson = str;
        }
        else
        {
            string str = rtb.GetAllRoomType("");
            strJson = str;
        }
    }
}
