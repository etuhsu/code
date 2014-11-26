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

public partial class URL_RoomType_AddRoomType : System.Web.UI.Page
{
    RoomTypeBLL bll = new RoomTypeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        AddRoomType();
    }

    public void AddRoomType()
    { 
        string typename=Request.Form["typename"];
        string typeprice = Request.Form["typeprice"];
        string typeaddbed = Request.Form["typeaddbed"];
        string addbed = Request.Form["addbed"];
        string typedesc = Request.Form["typedesc"];

        if (typename != null && typeprice != null)
        {
            if (addbed == null)
            {
                addbed = "0.00";
            }

            RoomTypeBean type = new RoomTypeBean();
            type.typeName = typename;
            type.typePrice = decimal.Parse(typeprice);
            type.typeAddBed = typeaddbed;
            type.addbed = decimal.Parse(addbed);
            type.typeDesc = typedesc;

            int count = bll.AddRoomTypeInfo(type);
            if (count > 0)
            {
                Response.Write(@"{success:'true'}");
            }
            else
            {
                Response.Write(@"{success:'false'}");
            }
        }
        else
        {
            Response.Write(@"{success:'false'}");
        }
    }
}
