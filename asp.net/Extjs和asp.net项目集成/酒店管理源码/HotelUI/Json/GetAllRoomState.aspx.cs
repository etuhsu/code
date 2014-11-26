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

public partial class Json_GetAllRoomState : System.Web.UI.Page
{

    protected string strJson = "";
    RoomStateBLL rsBll = new RoomStateBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                GetAllRoomState();
            }
            catch (Exception)
            {
                strJson = @"{success: false}";//失败
            }
        }
    }


    /// <summary>
    /// 查询房间状态表(所有)
    /// </summary>
    private void GetAllRoomState()
    {
        string str = rsBll.GetAllRoomState();
        strJson = str;
    }
}
