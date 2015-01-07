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

public partial class URL_RoleInfo_EditRoleInfo : System.Web.UI.Page
{
    RoleInfoBLL bll = new RoleInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        EditRoleInfo();
    }

    public void EditRoleInfo()
    {
        string roleid=Request.Form["roleid"];
        string rolename = Request.Form["rolename"];
        string roledesc = Request.Form["roledesc"];

        if (roledesc != null && rolename != null)
        {
            RoleinfoBean role = new RoleinfoBean();
            role.roleid = int.Parse(roleid);

            role.roleName = rolename;
            role.roleDesc = roledesc;

            int count = bll.EditRoleInfo(role);
            if (count > 0)
            {
                Response.Write("{success:'true'}");
            }
            else
            {
                Response.Write("{success:'false'}");
            }
        }
        else
        {
            Response.Write("{success:'false'}");
        }
    }
}
