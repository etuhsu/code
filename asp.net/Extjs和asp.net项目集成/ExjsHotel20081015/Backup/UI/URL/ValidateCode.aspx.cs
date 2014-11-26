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

public partial class URL_ValidateCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      #region 开始判断从客户端传来的数据

        string Code = Request.QueryString["Code"].ToString();

        string ServerCode =Number.WaterNumber;
        if (Code == ServerCode)
        {
            Response.Write("YES");
            Response.End();
        }
        else
        {
            Response.Write("ON");
            Response.End();
        }

        #endregion
    }
}
