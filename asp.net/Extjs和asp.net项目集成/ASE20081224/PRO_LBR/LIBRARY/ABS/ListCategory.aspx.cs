using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Text;
using Res.BLL;
using Res.Model;

public partial class ListCategory : System.Web.UI.Page
{
  //  protected string link_str;
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 3;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            int prl_id=0 ;
            if (string.IsNullOrEmpty(Request.QueryString["pct_id"]) == false)
            {
                prl_id = Convert.ToInt32(Request.QueryString["pct_id"]);
            }
            else
            {
                prl_id = 0;
                Response.Redirect("error.aspx?type=1");
            }

            WConfigBLL bll = new WConfigBLL();
            StringBuilder sLink = new StringBuilder();
            string lineName=bll.GetLineNameById(prl_id);


            IList<ImageObj> lst_img = bll.GetListImage("13,14,15,24,25,26,27");
            string path = ConfigurationManager.AppSettings["WUploadImageFile"];
            StringBuilder sText = new StringBuilder();

            if (lst_img.Count == 7)
            {
                sText.Append("<div style=\"width: 674px;\" class=\"clearfix\">");
                sText.Append("<div id=\"left-part\"><img src=\"" + path + "/" + lst_img[0].IMG_URL + "\" width=\"410\" height=\"250\" /></div>");
                sText.Append("<div id=\"right-part\">");
                sText.Append("<div id=\"in\">");
                sText.Append("<div style=\"padding: 0 28px;\">");
                sText.Append("<div id=\"in-one\"><img src=\"" + path + "/" + lst_img[1].IMG_URL + "\" width=\"170\" height=\"24\" /></div>");
                sText.Append("</div>");
                sText.Append("<div id=\"in-two\"><img src=\"" + path + "/" + lst_img[2].IMG_URL + "\" width=\"60\" height=\"60\" /><img src=\"" + path + "/" + lst_img[3].IMG_URL + "\" width=\"60\" height=\"60\" style=\"margin-left: 6px;\" /><img src=\"" + path + "/" + lst_img[4].IMG_URL + "\" width=\"60\" height=\"60\" style=\"margin-left: 6px;\" /></div>");
                sText.Append("<div id=\"in-three\"><img src=\"" + path + "/" + lst_img[5].IMG_URL + "\" width=\"198\" height=\"30\" /></div>");
                sText.Append("<div id=\"in-four\"><img src=\"" + path + "/" + lst_img[6].IMG_URL + "\" width=\"126\" height=\"31\" /></div>");
                sText.Append("</div></div></div>");
            }
            ViewState["IMAGE_STR"] = sText.ToString();

            IList<Res.Model.ImageObj> lst_prl = bll.GetCategoryList(prl_id);
            StringBuilder lst_text = new StringBuilder();
            int i = 0;
            foreach (Res.Model.ImageObj model in lst_prl)
            {
                if (i == 0)
                {
                    lst_text.Append("<ul>");
                    lst_text.Append("<li><a href=\"ListHeader.aspx?pct_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + model.IMG_TITLE + "</p></li>");
                }
                else if (i % 4 == 0 && i > 0)
                {
                    lst_text.Append("</ul>");
                    lst_text.Append("<ul>");
                    lst_text.Append("<li><a href=\"ListHeader.aspx?pct_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + model.IMG_TITLE + "</p></li>");
                }
                else
                {
                    lst_text.Append("<li><a href=\"ListHeader.aspx?pct_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + model.IMG_TITLE + "</p></li>");
                }
                i++;
            }
            if (i % 4 != 0)
            {
                lst_text.Append("</ul>");
            }
            ViewState["LST_IMAGE"] = lst_text.ToString();
            //using (System.Data.SqlClient.SqlDataReader reader = bll.GetCategoryList(prl_id))
            //{
            //    dlCategoryPrd.DataSource = reader;
            //    dlCategoryPrd.DataBind();
            //}

        }
    }

    protected string GetSpliteString(int index, string str)
    {
        string[] lstStr = str.Split('/');
        return lstStr[index];
    }
    protected string GetFile(object obj)
    {
        if (obj == null || obj == DBNull.Value)
        {
            return "";
        }
        else
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["WUploadImageFile"];
            return path + "/" + obj.ToString();
        }
    }
    protected void dlCategoryPrd_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
