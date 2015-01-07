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

public partial class Json_GetRoom : System.Web.UI.Page
{
    protected string strJson = "";
    RoomBLL rBll = new RoomBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetRoom();
        }
    }


    /// <summary>
    /// 查询所有状态为空闲的房间(删除客房时用到)
    /// </summary>
    private void GetRoom()
    {
        string str = rBll.GetRoom();
        strJson = str;
    }
}
