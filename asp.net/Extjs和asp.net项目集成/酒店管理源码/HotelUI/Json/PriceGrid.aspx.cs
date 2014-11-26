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

public partial class Json_PriceGrid : System.Web.UI.Page
{

    protected string strJson = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                GetTodyPrice();
            }
            catch (Exception)
            {
                strJson = @"{success: false}";//失败
            }
        }
    }


    /// <summary>
    ///  查询今日房价
    /// </summary>
    private void GetTodyPrice()
    {
        RoomTypeBLL rtBll = new RoomTypeBLL();
        string str = rtBll.GetTodyPrice();
        strJson = str;
    }
}
