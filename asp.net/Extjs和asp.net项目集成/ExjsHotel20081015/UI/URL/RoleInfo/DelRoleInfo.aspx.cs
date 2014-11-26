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

public partial class URL_RoleInfo_DelRoleInfo : System.Web.UI.Page
{
    RoleInfoBLL bll = new RoleInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        DelRoleInfo();
    }
    public void DelRoleInfo()
    {
        string roleinfo = Request.Form["roleinfo"];
        if ( roleinfo != null)
        {
            string[] roleinfos = roleinfo.Split(',');

            foreach (string r in roleinfos)
            {
                try
                {
                    bll.DelRoleInfo(int.Parse(r));
                }
                catch (Exception)
                {

                    Response.Write(@"{success:'false'}");
                }

            }

            Response.Write(@"{success:'true'}");
        }
        else
        {
            Response.Write(@"{success:'false'}");
        }
    }
}
