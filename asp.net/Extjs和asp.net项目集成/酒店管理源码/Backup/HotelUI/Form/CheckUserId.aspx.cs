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

public partial class Form_CheckUserId : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserId();
    }


    /// <summary>
    /// 检查登录名是否重复
    /// </summary>
    private void CheckUserId()
    {
        string json;
        string UserId = Request["name"]; //得到登陆Id
        UserInfoBLL uiBll = new UserInfoBLL();
        if (uiBll.CheckUserId(UserId))
        {
            json = @"{success: true}";//已经注册
        }
        else
        {
            json = @"{success: false}";//可以注册
        }
        Response.Write(json);
    }
}
