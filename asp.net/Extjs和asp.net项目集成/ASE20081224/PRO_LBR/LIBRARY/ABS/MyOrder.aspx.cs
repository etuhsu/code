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
using Res.BLL;
using Res.Model;

public partial class MyOrder : System.Web.UI.Page
{
    protected string totalPages = "0";
    protected string totalData = "0";
    OrderBLL bll = new OrderBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 19;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "查询订单列表", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }

            UserObj user = (UserObj)Session["MEB"];
            hddUserId.Value = user.USR_ID.ToString();
            ViewState["pageNo"] = 1;

        }
    }
    protected void imgGo_ServerClick(object sender, ImageClickEventArgs e)
    {
        ViewState["pageNo"] = 1;
        Query();
    }
    protected void btnQuery_ServerClick(object sender, EventArgs e)
    {
        ViewState["pageNo"] = 1;
        Query();
    }
    protected void ddlOrderStatus_DataBound(object sender, EventArgs e)
    {
        ddlOrderStatus.Items.Insert(0, new ListItem("--选择订单状态--", "0"));
    }
    protected void rptOrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "first")//第一页



        {
            int tempNo = Convert.ToInt32(ViewState["pageNo"]);
            tempNo = 1;
            ViewState["pageNo"] = tempNo;
            Query();
        }
        if (e.CommandName == "previous")//上一页



        {
            int tempNo = Convert.ToInt32(ViewState["pageNo"]);
            if (tempNo > 1)
            {
                tempNo--;
            }
            else
            {
                tempNo = 1;
            }
            ViewState["pageNo"] = tempNo;
            Query();
        }
        if (e.CommandName == "next")//下一页



        {
            int tempNo = Convert.ToInt32(ViewState["pageNo"]);
            if (tempNo < Convert.ToInt32(ViewState["total"]))
            {
                tempNo++;
            }
            else
            {
                tempNo = Convert.ToInt32(ViewState["total"]);
            }
            ViewState["pageNo"] = tempNo;
            Query();
        }
        if (e.CommandName == "last")//最后一页



        {
            int tempNo = Convert.ToInt32(ViewState["pageNo"]);
            tempNo = Convert.ToInt32(ViewState["total"]);
            ViewState["pageNo"] = tempNo;
            Query();
        }
    }
    /// <summary>
    /// 查询
    /// </summary>
    private void Query()
    {
        System.Text.StringBuilder strWhere = new System.Text.StringBuilder();

        string beginDate = txtBegin.Text.Trim();
        string endDate = txtEnd.Text.Trim();
        string orderCode = txtOrderCode.Value.Trim();
        string orderStatus = ddlOrderStatus.SelectedValue.Trim();

        if (string.IsNullOrEmpty(beginDate) == false && string.IsNullOrEmpty(endDate) == false && beginDate != "开始时间" && endDate != "结束时间")
        {
            strWhere.Append(" AND PUR_DT BETWEEN '");
            strWhere.Append(beginDate);
            strWhere.Append("' AND '");
            strWhere.Append(endDate);
            strWhere.Append("' ");
        }
        if (string.IsNullOrEmpty(orderCode) == false && orderCode != "订单号")
        {
            strWhere.Append(" AND PUR_CODE LIKE '%");
            strWhere.Append(orderCode);
            strWhere.Append("%' ");
        }
        if (string.IsNullOrEmpty(orderStatus) == false && orderStatus != "0")
        {
            strWhere.Append(" AND PUR_PUS_ID=");
            strWhere.Append(orderStatus);
        }

        int count = bll.GetOrderPagingCount(Convert.ToInt32(hddUserId.Value), strWhere.ToString());
        totalData = count.ToString();
        totalPages = Convert.ToString(Math.Ceiling(Convert.ToDecimal((decimal)count / (decimal)10)));
        ViewState["total"] = totalPages;
        rptOrderList.DataSource = bll.GetOrderPaging(Convert.ToInt32(hddUserId.Value), (Convert.ToInt32(ViewState["pageNo"]) - 1) * 10, 10, strWhere.ToString());
        rptOrderList.DataBind();
    }
    protected void imgQuery_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["pageNo"] = 1;
        Query();
    }
}
