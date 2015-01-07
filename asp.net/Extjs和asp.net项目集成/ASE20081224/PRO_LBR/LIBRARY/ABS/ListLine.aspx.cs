using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Text;
using Res.BLL;

public partial class ListLine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 2;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!Page.IsPostBack)
        {

            WConfigBLL bll = new WConfigBLL();
            string path = System.Configuration.ConfigurationManager.AppSettings["WUploadImageFile"];
            IList<Res.Model.ImageObj> lst_right = bll.GetListImage("9,10,11,12,23");
            StringBuilder stext = new StringBuilder();

            if (lst_right.Count == 5)
            {
                stext.Append("<div style=\"width: 674px;\" class=\"clearfix\">");
                stext.Append("<div id=\"left-part\"><img src=\"" + path + "/" + lst_right[0].IMG_URL + "\" width=\"410\" height=\"250\" /></div>");
                stext.Append("<div id=\"right-part\">");
                stext.Append("<div id=\"p1\"><img src=\"" + path + "/" + lst_right[1].IMG_URL + "\" width=\"214\" height=\"58\" /></div>");
                stext.Append("<div style=\"margin: 15px 0; text-align: center;\"><img src=\"" + path + "/" + lst_right[2].IMG_URL + "\" width=\"108\" height=\"87\" /><img src=\"" + path + "/" + lst_right[3].IMG_URL + "\" width=\"108\" height=\"87\" style=\"margin-left: 9px;\" /></div>");
                stext.Append("<div style=\"text-align: right;\"><img src=\"" + path + "/" + lst_right[4].IMG_URL + "\" width=\"52\" height=\"12\" /></div>");
                stext.Append("</div></div>");
            }
            ViewState["IMAGE_STR"] = stext.ToString();
            string prl_name = "家居用品";
            if (string.IsNullOrEmpty(Request.QueryString["prl_name"]) == false)
            {
                prl_name = Request.QueryString["prl_name"];
            }
            IList<Res.Model.ImageObj> lst_prl = bll.GetLineList(prl_name);
            StringBuilder lst_text = new StringBuilder();
            int i=0;
            foreach (Res.Model.ImageObj model in lst_prl)
            {
                if(i==0)
                {
                    lst_text.Append("<ul>");
                    lst_text.Append("<li><a href=\"ListCategory.aspx?pct_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + GetSpliteString(model.IMG_TITLE) + "</p></li>");
                }
                else if(i%4==0&&i>0)
                {
                    lst_text.Append("</ul>");
                    lst_text.Append("<ul>");
                    lst_text.Append("<li><a href=\"ListCategory.aspx?pct_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + GetSpliteString(model.IMG_TITLE) + "</p></li>");
                }
                else
                {
                    lst_text.Append("<li><a href=\"ListCategory.aspx?pct_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + GetSpliteString(model.IMG_TITLE) + "</p></li>");
                }
                i++;
            }
            if (i % 4 != 0)
            {
                lst_text.Append("</ul>");
            }
            ViewState["LST_IMAGE"]=lst_text.ToString();
        }
    }
    protected string GetSpliteString(object obj)
    {
        if (obj == null || obj == DBNull.Value)
        {
            return "";
        }
        else
        {
            string[] str = obj.ToString().Split('/');
            return str[1];
        }
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
}
