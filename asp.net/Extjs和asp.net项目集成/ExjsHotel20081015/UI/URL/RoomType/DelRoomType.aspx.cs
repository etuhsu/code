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

public partial class URL_RoomType_DelRoomType : System.Web.UI.Page
{
    RoomTypeBLL bll = new RoomTypeBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        DeleteRoomType();
    }

    //删除房间类型
    public void DeleteRoomType()
    {
        string typeid = Request.Form["typeids"];
        if (typeid != null)
        {
            string[] roomtype = typeid.Split(',');

            foreach (string r in roomtype)
            {
                try
                {
                    bll.DeleteRoomTypeInfo(int.Parse(r));
                }
                catch (Exception)
                {

                    Response.Write(@"{success:'false'}");
                }
               
            }

            Response.Write(@"{success:'true'}");
        }
        else
        {
            Response.Write(@"{success:'false'}");
        }
    }
}
