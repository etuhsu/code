using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Collections.Generic;
using Res.BLL;
public partial class index : System.Web.UI.Page
{
    protected string path;
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 16;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!Page.IsPostBack)
        {
            WConfigBLL bll = new WConfigBLL();

            path = System.Configuration.ConfigurationManager.AppSettings["WUploadImageFile"];

            IList<Res.Model.ImageObj> lst_cast = bll.GetListImage(1);
            StringBuilder CAST_STR = new StringBuilder();
            CAST_STR.Append("<data><channel>");
            foreach (Res.Model.ImageObj model in lst_cast)
            {
                CAST_STR.Append("<item><link>" + model.IMG_HREF + "</link><image>" + path + "//" + model.IMG_URL + "</image><title>" + model.IMG_TITLE + "</title></item>");
            }
            CAST_STR.Append("</channel></data>");

            cpc_main.CastString = CAST_STR.ToString();

            IList<Res.Model.ImageObj> lst_cyc = bll.GetListImage(2);
            cpl_main.ListImage = lst_cyc;

            IList<Res.Model.ImageObj> lst_right = bll.GetListImage("4,7,18,19,20,21,22");

            Cia_main.TopAAlt = lst_right[0].IMG_TITLE;
            Cia_main.TopAImage = path + "//" + lst_right[0].IMG_URL;
            Cia_main.TopAUrl = lst_right[0].IMG_HREF;

            Cia_main.TopBAlt = lst_right[1].IMG_TITLE;
            Cia_main.TopBImage = path + "//" + lst_right[1].IMG_URL;
            Cia_main.TopBUrl = lst_right[1].IMG_HREF;

            Cia_main.TopCAlt = lst_right[2].IMG_TITLE;
            Cia_main.TopCImage = path + "//" + lst_right[2].IMG_URL;
            Cia_main.TopCUrl = lst_right[2].IMG_HREF;

            Cia_main.MiddleLeftAlt = lst_right[3].IMG_TITLE;
            Cia_main.MiddleLeftImage = path + "//" + lst_right[3].IMG_URL;
            Cia_main.MiddleLeftUrl = lst_right[3].IMG_HREF;

            Cia_main.MiddleRightAlt = lst_right[4].IMG_TITLE;
            Cia_main.MiddleRightImage = path + "//" + lst_right[4].IMG_URL;
            Cia_main.MiddleRightUrl = lst_right[4].IMG_HREF;

            Cia_main.BottomRightAlt = lst_right[5].IMG_TITLE;
            Cia_main.BottomRightImage = path + "//" + lst_right[5].IMG_URL;
            Cia_main.BottomRightUrl = lst_right[5].IMG_HREF;

            Cia_main.BottomAlt = lst_right[6].IMG_TITLE;
            Cia_main.BottomImage = path + "//" + lst_right[6].IMG_URL;
            Cia_main.BottomUrl = lst_right[6].IMG_HREF;
        }

    }
}
