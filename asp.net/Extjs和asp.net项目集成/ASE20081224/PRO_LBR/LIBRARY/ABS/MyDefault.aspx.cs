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

public partial class MyDefault : System.Web.UI.Page
{
    protected string strTitle = "";
    protected string strContent = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 12;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["FRM_ID"]) == false)
            {
                int frmId = Convert.ToInt32(Request.QueryString["FRM_ID"]);
                Res.BLL.WConfigBLL bll = new Res.BLL.WConfigBLL();
                using (System.Data.SqlClient.SqlDataReader reader = bll.GetBaseInfoById(frmId))
                {
                    if (reader.Read())
                    {
                        if (reader.IsDBNull(0) == false)
                            strTitle = reader.GetString(0);
                        if (reader.IsDBNull(1) == false)
                        {
                            if (reader.GetString(1) != "" && reader.GetString(1).Length > 0)
                            {
                                string path = ConfigurationManager.AppSettings["WUploadImageFile"];
                                strTitle = "<img src=\"" + path + "/" + reader.GetString(1) + "\"/><br><br>" + strTitle;
                            }
                        }
                        if (reader.IsDBNull(2) == false)
                            strContent = reader.GetString(2);
                    }
                }
            }
            else
            {
                Response.Redirect("error.aspx?type=1");
            }
        }
    }
}
