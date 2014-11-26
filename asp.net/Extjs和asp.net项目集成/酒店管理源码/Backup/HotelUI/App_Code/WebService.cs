using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
//该源码首发自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

/// <summary>
/// WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//支持JS调用
[System.Web.Script.Services.ScriptService]

public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }


    [WebMethod]
    public string GetLoginName()
    {
        string Name = "admin: 已登陆";
        //if (Session["LoginName"] != null)
        //{
        //    Name = Session["LoginName"].ToString();
        //}
        //else
        //{
        //    Name = "aaa: 已登陆";
        //}
        return Name;
    }

}

