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

public partial class Json_GetIs : System.Web.UI.Page
{
    protected string strJson = "";
    IsTableBLL itBll = new IsTableBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                GetIsAll();
            }
            catch (Exception)
            {
                strJson = @"{success: false}";//失败
            }  
        }
    }


    /// <summary>
    /// 查询所有
    /// </summary>
    private void GetIsAll()
    {
        string str = itBll.GetIsAll();
        strJson = str;
    }
}
