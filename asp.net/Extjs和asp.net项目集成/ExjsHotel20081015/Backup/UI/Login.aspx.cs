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
using BLL;
using Model;

public partial class Login : System.Web.UI.Page
{
    UserInfoBLL ubll = new UserInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        //注册ajax
        if(!Page.IsPostBack)
        {
         AjaxPro.Utility.RegisterTypeForAjax(typeof(Login));
        }
       
    }

    //判断用户名密码是否正确
    [AjaxPro.AjaxMethod]
    public int isRight(string userName, string userPwd)
    {
        int count = 0;
        UserInfoBean u = new UserInfoBean();
        u.userid = userName;
        u.userPwd= userPwd;
        try
        {
            count = ubll.userIsRight(u);
            
        }
        catch (Exception)
        {

            throw;
        }
        return count;
    }

    //判断用户类型
    [AjaxPro.AjaxMethod]
    public void UserType(string userID)
    {
        int roletype = ubll.getRoleTypeInfo(userID);
        int id = ubll.getIdByUserid(userID);
        Number.loginid = id.ToString();
        if(roletype==1)
        {   //服务员
            Number.userid="100";
        }
        else if(roletype==2)
        {   //管理员
            Number.userid = "1";
        }
        else if(roletype==3)
        {   //客人
            Number.userid = "1000";
        }
    } 
    //写入Session值
    [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
    public void WriteSession(string userID)
    {
        Session["Login"]=userID;
    }

    //判断用户状态
    [AjaxPro.AjaxMethod]
    public int userState(string userID)
    {
        try
        {
            int count = ubll.userStates(userID);
            return count;
        }
        catch (Exception)
        {
            
            throw;
        }
       
    }
}
