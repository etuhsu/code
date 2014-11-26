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


public partial class URL_RoomType_RoomTypeNameIsOk : System.Web.UI.Page
{
    RoomTypeBLL bll = new RoomTypeBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        RoomTypeIsOk();
    }

    public void RoomTypeIsOk()
    { 
        string roomtypename=Request.Form["typename"];

        if (roomtypename != null)
        {
            int count = bll.RoomTypeIsOK(roomtypename);
            if(count>0)
            {
                Response.Write(@"{success:true}");
            }else{

                Response.Write(@"{success:false}");
            }
        }
        else {

            Response.Write(@"{success:false}");
        }

    }
}
