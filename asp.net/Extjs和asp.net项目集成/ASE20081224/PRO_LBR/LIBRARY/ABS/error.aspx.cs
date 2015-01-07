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

public partial class error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 14;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["type"]) == false)
            {
                int i = System.Convert.ToInt32(Request.QueryString["type"]);
                hf_error.Value = GetErrorString(i);
            }
        }
    }
    private string GetErrorString(int i)
    {
        string result = "";
        switch (i)
        {
            case 1:
                {
                    result = "页面跳转出现错误";
                    break;
                }
            case 2:
                {
                    result = "您尚未登陆，请<a href='wlogin.aspx'><span style='color:Purple;text-decoration:underline;'>登陆</span></a>";
                    break;
                }
            case 3:
                {
                    result = "操作错误";
                    break;
                }
            case 4:
                {
                    result = "您没有访问权限";
                    break;
                }
        }
        return result;
    }
}
