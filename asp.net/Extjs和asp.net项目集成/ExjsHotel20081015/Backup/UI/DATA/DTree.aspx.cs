using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;

public partial class DATA_DTree : System.Web.UI.Page
{
    public string Jsons="";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        GetDTreeJSON();
    }

    public void GetDTreeJSON()
    {
        NavBLL navbll = new NavBLL();
        string id = Request.Form["id"];
        if(id==null)
        {
            Jsons = navbll.GetDtreeInfos(1);
        }
        else if (id != null)
        {
            int parentid = int.Parse(id);
            Jsons = navbll.GetDtreeInfos(parentid);
        }
        else
        {
            Response.Write("success:false");
        }
       
    }
}
