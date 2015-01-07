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

public partial class Json_MainGrid : System.Web.UI.Page
{

    protected string strJson = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                GetOpenRoomInfoAll();
            }
        }
        catch (Exception)
        {
            strJson = @"{success: false}";//失败
        }
    }


    /// <summary>
    /// 查询所有的开房信息(首页的Grid,带搜索功能)
    /// </summary>
    private void GetOpenRoomInfoAll()
    {
        if (Request.Form["msg"] != null)
        {
            OpenRoomInfoBLL orib = new OpenRoomInfoBLL();
            string message = Request.Form["msg"];
            string str = orib.GetOpenRoomInfoAll(message);
            strJson = str;
        }
        else
        {
            OpenRoomInfoBLL orib = new OpenRoomInfoBLL();
            string str = orib.GetOpenRoomInfoAll("");
            strJson = str;
        }
    }
}
