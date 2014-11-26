using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using System.Web.Security;
using System.Text;
using Res.BLL;
public partial class ListHeader : System.Web.UI.Page
{
    protected string next_str;
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 4;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!Page.IsPostBack)
        {
            int pct_id =0;
            if (string.IsNullOrEmpty(Request.QueryString["pct_id"]) == false)
            {
                pct_id = WebUtility.InputInt(Request.QueryString["pct_id"]);
            }
            else
            {
                Response.Redirect("error.aspx?type=1");
            }
            WConfigBLL bll = new WConfigBLL();
            string path = ConfigurationManager.AppSettings["WUploadImageFile"];
            IList<Res.Model.ImageObj> lst_image = bll.GetProductList(pct_id);
            StringBuilder lst_text = new StringBuilder();
            int i = 0;
            foreach(Res.Model.ImageObj model in lst_image)
            {
                if (i == 0)
                {
                    lst_text.Append("<div class=\"clearfix\" style=\"margin-top:10px;\">");
                    lst_text.Append("<ul>");
                    lst_text.Append("<li><a href=\"SingleHeader.aspx?prh_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + model.IMG_TITLE + "</p></li>");
                }
                else if (i % 4 == 0 && i > 0)
                {
                    lst_text.Append("</ul>");
                    lst_text.Append("</div>");
                    lst_text.Append("<div class=\"clearfix\" style=\"margin-top:10px;\">");
                    lst_text.Append("<ul>");
                    lst_text.Append("<li><a href=\"SingleHeader.aspx?prh_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + model.IMG_TITLE + "</p></li>");
                }
                else
                {
                    lst_text.Append("<li><a href=\"SingleHeader.aspx?prh_id=" + model.IMG_ID.ToString() + "\"><img src=\"" + path + "/" + model.IMG_URL + "\" width=\"150\" height=\"150\" border=\"0\" /></a><p>" + model.IMG_TITLE + "</p></li>");
                }
                i++;
            }
            if (i % 4 != 0)
            {
                lst_text.Append("</ul>");
                lst_text.Append("</div>");
            }
            ViewState["LST_IMAGE"] = lst_text.ToString();
        }
    }
   /* private void GetNewPage(int pct_id)
    {
        int ct = System.Convert.ToInt32(ViewState["PageIndex"]);
        int StartIndex = (ct - 1) * 15;
        WConfigBLL bll = new WConfigBLL();
        DataSet ds = bll.GetProductList(pct_id, StartIndex, 15);
        dl_header.DataSource = ds;
        dl_header.DataBind();

    }
    private void getNextStr(int count,int pct_id)
    {
        StringBuilder result=new StringBuilder();
        result.Append("<div style=\"margin-top: 130px; text-align:right;\" id=\"result-page\">");
        for (int i = 1; i <= count; i++)
        {
            if (System.Convert.ToInt32(ViewState["PageIndex"]) == i)
            {
                result.Append("<a href=\"ListHeader.aspx?page=" + i.ToString() + "&pct_id=" + pct_id.ToString() + "\" class=\"page-in1\">" + i.ToString() + "</a>&nbsp;");
            }
            else
            {
                result.Append("<a href=\"ListHeader.aspx?page=" + i.ToString() + "&pct_id=" + pct_id.ToString() + "\" class=\"page-out1\">2</a>&nbsp;");
            }
            //<div style="margin-top: 130px; text-align:right;" id="result-page"><a href="#" class="page-in1">1</a>&nbsp;<a href="#" class="page-out1">2</a>&nbsp;<a href="#" class="page-out1">3</a>&nbsp;&nbsp;<a href="#" class="page-out1">下一页</a>
        }
        int next_count = System.Convert.ToInt32(System.Convert.ToInt32(ViewState["PageIndex"]))+1;
        int page_count=System.Convert.ToInt32(System.Convert.ToInt32(ViewState["PageCount"]));
        string nt = "";
        if (next_count > page_count)
        {
            nt = "#";
        }
        else
        {
            nt = "ListHeader.aspx?page=" + (next_count + 1).ToString()+"&pct_id="+pct_id.ToString();
        }
        result.Append("&nbsp;<a href=\""+nt+"\" class=\"page-out1\">下一页</a></div>");
        next_str = result.ToString();
    }*/
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

    protected string GetSpliteString(int index, string str)
    {
        string[] lstStr = str.Split('/');
        return lstStr[index];
    }

   /* private void BindLink(int pctId)
    {
        WConfigBLL bllConfig = new WConfigBLL();
        //Res.Model.NodeObj hNode = bllConfig.GetHeaderNameById(pctId);
        Res.Model.NodeObj cNode = bllConfig.GetCategoryNameById(pctId);
        string lineName = bllConfig.GetLineNameById(cNode.ID);
        ltrLineName.Text = GetSpliteString(0, lineName);
        ltrLineName1.Text = GetSpliteString(1, lineName);
        ltrCategoryName.Text = cNode.NAME;
        hlkLineName.NavigateUrl = "ListLine.aspx?prl_name="+GetSpliteString(0,lineName);
        hlkLineName1.NavigateUrl = "ListCategory.aspx?pct_id=" + cNode.ID;
    }*/
}
