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

public partial class Json_GetRoomType : System.Web.UI.Page
{
    protected string strJson = "";
    RoomTypeBLL rtb = new RoomTypeBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                GetRoomType();
            }
            catch (Exception)
            {
                strJson = @"{success: false}";//失败
            }
        }
    }


    /// <summary>
    /// 查询所有未被使用的房间类型(删除用到)
    /// </summary>
    private void GetRoomType()
    {
        string str = rtb.GetRoomType();
        strJson = str;
    }
}
