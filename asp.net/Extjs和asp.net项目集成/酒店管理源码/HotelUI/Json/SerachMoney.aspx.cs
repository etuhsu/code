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

public partial class Json_SerachMoney : System.Web.UI.Page
{
    protected string strJson = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                SerachMoney();
            }
            catch (Exception)
            {
                strJson = @"{success: false}";//失败
            }
        }
    }


    /// <summary>
    /// 查账(全查,根据时间查询都可以)
    /// </summary>
    private void SerachMoney()
    {
        MoneyInfoBLL miBll = new MoneyInfoBLL();

        if (Request.Form["be"] != null && Request.Form["en"] != null)
        {
            string BeginTime = Request.Form["be"];
            string EndTime = Request.Form["en"];
            string str = miBll.SerachMoney(BeginTime, EndTime);
            strJson = str;
        }
        else
        {
            string str = miBll.SerachMoney("", "");
            strJson = str;
        }
    }
}
