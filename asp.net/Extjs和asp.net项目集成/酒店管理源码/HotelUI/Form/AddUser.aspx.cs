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
using HotelModels;

public partial class Form_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AddUser();
        }
    }


    /// <summary>
    /// 添加普通员工
    /// </summary>
    private void AddUser()
    {
        UserInfoBean uib = new UserInfoBean(); //实体Bean
        UserInfoBLL uBll = new UserInfoBLL(); //逻辑层
        //得到表单提交的值
        uib.LoginName = Request.Form["LoginName"];
        uib.LoginPass = Request.Form["LoginPass"];
        uib.UserName = Request.Form["UserName"];
        uib.Remark = Request.Form["remark"];
        string json;
        //如果success为true,则表示服务器端处理成功
        if (uBll.AddUser(uib))
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
