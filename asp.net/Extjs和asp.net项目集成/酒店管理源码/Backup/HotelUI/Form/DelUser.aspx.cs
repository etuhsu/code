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

public partial class Form_DelUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DelUser();
        }
    }



    /// <summary>
    /// 删除员工(根据Id删除)
    /// </summary>
    private void DelUser()
    {
        UserInfoBLL uib = new UserInfoBLL(); //逻辑层
        //得到表单提交的值
        int UserId = int.Parse(Request.Form["LoginName"]);
        string json;
        //如果success为true,则表示服务器端处理成功
        if (uib.DelUser(UserId))
        {
            json = @"{success: true}";
        }
        else
        {
            json = @"{success: false}";
        }
        Response.Write(json);
    }
}
