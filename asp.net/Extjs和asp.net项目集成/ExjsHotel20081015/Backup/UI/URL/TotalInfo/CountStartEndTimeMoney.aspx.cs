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


public partial class URL_TotalInfo_CountStartEndTimeMoney : System.Web.UI.Page
{
    TotalInfoBLL bll = new TotalInfoBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllMoneys();
    }

    public void GetAllMoneys()
    {
        string starttime = Request.Form["starttime"];
        string endtime = Request.Form["endtime"];
        try
        {
    		string money = bll.GetAllMoney(starttime, endtime);
            Response.Write(@"{success:"+money+"}");
	    }
	    catch (Exception)
	    {
            throw;
            //Response.Write("{success:'false'}");
	    }

     
        
        
    }
}
