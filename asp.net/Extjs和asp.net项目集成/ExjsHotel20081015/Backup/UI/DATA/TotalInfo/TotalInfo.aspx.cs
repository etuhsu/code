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

public partial class DATA_TotalInfo_TotalInfo : System.Web.UI.Page
{
    TotalInfoBLL bll = new TotalInfoBLL();
    public string JSON = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GetTotalInfo();
    }

    public void GetTotalInfo()
    { 
        string limits=Request.Form["limit"];
        string starts=Request.Form["start"];
        string starttime=Request.Form["starttime"];
        string endtime=Request.Form["endtime"];


        if (limits != null && starts != null)
        {
            int limit = int.Parse(limits);
            int start = int.Parse(starts);
            JSON = bll.GetTotalInfo(start,limit,starttime,endtime);
        }
        else
        {
            Response.Write("{success:false}");
        }

    }
}
