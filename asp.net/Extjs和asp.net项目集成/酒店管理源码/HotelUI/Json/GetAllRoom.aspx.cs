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

public partial class Json_GetAllRoom : System.Web.UI.Page
{

    protected string strJson = "";
    RoomBLL rBll = new RoomBLL();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                GetAllRoom();
            }
            catch (Exception)
            {
                strJson = @"{success: false}";//失败
            }
        }
    }


    /// <summary>
    /// 查询所有客房信息(查看客房信息用到,带搜索)
    /// </summary>
    private void GetAllRoom()
    {
        if (Request.Form["msg"] != null)
        {
            string message = Request.Form["msg"];
            string str = rBll.GetAllRoom(message);
            strJson = str;
        }
        else
        {
            string str = rBll.GetAllRoom("");
            strJson = str;
        }
        
    }
}
