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


public partial class URL_RoomType_EditTodayRoomTypePrice : System.Web.UI.Page
{
    RoomTypeBLL bll = new RoomTypeBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        editTodayTypePrice();
    }

   public void editTodayTypePrice()
   {
        string typename=Request.Form["typename"];
        string typeprice=Request.Form["typeprice"];
        
        if(typename!=null && typeprice!=null)
        {
            decimal roomtypeprice = decimal.Parse(typeprice);
            int count = bll.EditTodayPrice(typename, roomtypeprice);
            if (count > 0)
            {
                Response.Write("{success:'true'}");
            }
            else {
                Response.Write("{success:'false'}");
            }
        }
        else
        {
            Response.Write("{success:'false'}");
        }
   }
}
