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

public partial class URL_TotalInfo_SaveRoomMoneyInfo : System.Web.UI.Page
{
    TotalInfoBLL bll = new TotalInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        SaveOpenRoomMoney();
    }
    public void SaveOpenRoomMoney()
    {
        try
        {
            string totalmoney = Request.Form["roommoney"];
            string totalremark = Request.Form["totalremark"];
            if(totalmoney!=null)
            {
                TotalInfoBean total = new TotalInfoBean();
                total.totalMoney = decimal.Parse(totalmoney);
                total.totalRemark = totalremark;
                int count = bll.SaveRoomMoney(total);
                if (count > 0)
                {
                    Response.Write("{success:'true'}");
                }
                else
                {
                    Response.Write("{success:'false'}");
                }
            }else
            {
                Response.Write("{success:'false'}");
            }
           
        }
        catch (Exception)
        {
            
            throw;
        }
    }
}
