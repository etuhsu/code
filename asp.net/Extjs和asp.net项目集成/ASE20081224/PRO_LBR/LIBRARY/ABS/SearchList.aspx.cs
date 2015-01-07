using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Text;
using Res.BLL;

public partial class SearchList : System.Web.UI.Page
{
    protected string next_str;
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 22;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["page"]) == false)
            {
                ViewState["PageIndex"] = System.Convert.ToInt32(Request.QueryString["page"]);
                GetNewPage(System.Convert.ToInt32(Request.QueryString["page"]), Session["strWhere"].ToString());
            }
        }
    }
    protected void btn_search_ServerClick(object sender, EventArgs e)
    {
        
        StringBuilder strWhere = new StringBuilder();
        if (string.IsNullOrEmpty(edt_begin_num.Text) == true)
            edt_begin_num.Text = "0";
        if (string.IsNullOrEmpty(edt_end_num.Text) == true)
            edt_end_num.Text = "0";
        strWhere.Append("(PRH_LOCALNAME LIKE '%"+edt_keyword.Text+"%'  ");
        strWhere.Append("OR PRH_DESC LIKE '%"+edt_keyword.Text+"%'  ");
        strWhere.Append("OR  PRL_DESC LIKE '%"+edt_keyword.Text+"%'  ");
        strWhere.Append("OR PCT_DESC LIKE '%"+edt_keyword.Text+"%' ");
        strWhere.Append("OR PRH_LOCALNAME LIKE '%"+edt_keyword.Text+"%' ) ");
        strWhere.Append("AND PRD_MEMBER_PRICE BETWEEN " + edt_begin_num.Text + " AND " + edt_end_num.Text);
        Session["strWhere"] = strWhere.ToString();
        ViewState["PageIndex"] = 1;//默认页面
        GetNewPage(1, Session["strWhere"].ToString());
        
    }
    private void GetNewPage(int begin,string where)
    {
        int count = 0;
        WConfigBLL bll = new WConfigBLL();
        int PageSize = 5;
        using (SqlDataReader reader = bll.QueryProductHeader(begin, PageSize, where.ToString(), out count))
        {
            rp_list.DataSource = reader;
            rp_list.DataBind();

            if (count > 0)
            {
                int end = (count > PageSize ? PageSize : count);
                int PageCount = 0;
                if (PageSize > 0)
                    PageCount = (count % PageSize == 0) ? (count / PageSize) : ((count / PageSize) + 1);
                ViewState["PageCount"] = PageCount;
                getNextStr(PageCount);
            }
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
    protected string GetRepertory(object obj)
    {
        if (obj == null || obj == DBNull.Value)
        {
            return "现在缺货";
        }
        else
        {
            int count = System.Convert.ToInt32(obj);
            if (count > 0)
            {
                return "现在有货";
            }
            else
            {
                return "现在缺货";
            }
        }
    }
    private void getNextStr(int count)
    {
        StringBuilder result = new StringBuilder();
        result.Append("<div style=\"margin-top: 10px; text-align:right;\" id=\"result-page\">");
        for (int i = 1; i <= count; i++)
        {
            if (System.Convert.ToInt32(ViewState["PageIndex"]) == i)
            {
                result.Append("<a href=\"SearchList.aspx?page=" + i.ToString() + "\" class=\"page-in1\">" + i.ToString() + "</a>&nbsp;");
            }
            else
            {
                result.Append("<a href=\"SearchList.aspx?page=" + i.ToString() + "\" class=\"page-out1\">"+i.ToString()+"</a>&nbsp;");
            }
            //<div style="margin-top: 130px; text-align:right;" id="result-page"><a href="#" class="page-in1">1</a>&nbsp;<a href="#" class="page-out1">2</a>&nbsp;<a href="#" class="page-out1">3</a>&nbsp;&nbsp;<a href="#" class="page-out1">下一页</a>
        }
        int next_count = System.Convert.ToInt32(System.Convert.ToInt32(ViewState["PageIndex"])) + 1;
        int page_count = System.Convert.ToInt32(System.Convert.ToInt32(ViewState["PageCount"]));
        string nt = "";
        if (next_count > page_count)
        {
            nt = "#";
        }
        else
        {
            nt = "SearchList.aspx?page=" + (next_count).ToString();
        }
        result.Append("&nbsp;<a href=\"" + nt + "\" class=\"page-out1\">下一页</a></div>");
        next_str = result.ToString();
    }
}
