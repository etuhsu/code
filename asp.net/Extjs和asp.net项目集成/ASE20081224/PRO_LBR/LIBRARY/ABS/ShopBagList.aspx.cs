using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using Res.BLL;
using Res.Model;

public partial class ShopBagList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 24;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        WUserBLL bllUser = new WUserBLL();
        int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
        if (bllUser.IsAuthenticated(Session, "查看购物车", timeOut) == false)
        {
            WebUtility.SetBackUrl(Request, Response);
            Response.Redirect("error.aspx?type=2");
        }
        UserObj us = (UserObj)Session["MEB"];
        if (!Page.IsPostBack)
        {
            hf_uid.Value = us.USR_ID.ToString();
            WShopBagBLL bll = new WShopBagBLL();
            decimal amount = bll.GetShopBagAmount(System.Convert.ToInt32(hf_uid.Value));
            lb_amount.Text = "<strong>总额：</strong><font color=\"##ff0000\">" + string.Format("{0:C}", amount) + "</font>";
        }
    }
    protected string GetString(object obj)
    {
        if (obj == null || obj == DBNull.Value)
        {
            return "缺货";
        }
        else
        {
            int num = System.Convert.ToInt32(obj);
            if (num >= 0)
            {
                return "有货";
            }
            else
            {
                return "缺货";
            }
        }
    }
    protected void gv_list_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {

    }
    protected void gv_list_RowUpdated(object sender, System.Web.UI.WebControls.GridViewUpdatedEventArgs e)
    {
        if (e.Exception == null)
        {
            WShopBagBLL bll = new WShopBagBLL();
            decimal amount = bll.GetShopBagAmount(System.Convert.ToInt32(hf_uid.Value));
            lb_amount.Text = "<strong>总额：</strong><font color=\"##ff0000\">" + string.Format("{0:C}", amount) + "</font>";
        }
    }
    protected void btn_clear_ServerClick(object sender, EventArgs e)
    {
        //   string[] idArray = checkedIDs.Value.Split(new char[] { ',' }); 
        WShopBagBLL bll = new WShopBagBLL();
        int result = bll.DeleteShopBagAll(System.Convert.ToInt32(hf_uid.Value));
        gv_list.DataBind();

        decimal amount = bll.GetShopBagAmount(System.Convert.ToInt32(hf_uid.Value));
        lb_amount.Text = "<strong>总额：</strong><font color=\"##ff0000\">" + string.Format("{0:C}", amount) + "</font>";
    }
    protected void gv_list_RowDeleted(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
    {
        if (e.Exception == null)
        {
            WShopBagBLL bll = new WShopBagBLL();
            decimal amount = bll.GetShopBagAmount(System.Convert.ToInt32(hf_uid.Value));
            lb_amount.Text = "<strong>总额：</strong><font color=\"##ff0000\">" + string.Format("{0:C}", amount) + "</font>";
        }
    }
    protected void btn_createorder_ServerClick(object sender, EventArgs e)
    {
        IList<int> lst_result = new List<int>();
        if (hf_shopbag.Value.Trim().Length > 0)
        {
            string[] idArray = hf_shopbag.Value.Split(',');
            if (idArray.Length > 0)
            {
                foreach (string str in idArray)
                {
                    if (str.Trim().Length > 0 && WebUtility.IsInteger(str, true))
                    {
                        lst_result.Add(WebUtility.InputInt(str));
                    }
                }
                if (lst_result.Count > 0)
                {
                    cvlid.IsValid = true;
                    Session["SPB"] = lst_result;
                    Response.Redirect("ConfirmInfo.aspx");
                }
                else
                {
                    cvlid.ErrorMessage = "没有选中购物记录";
                    cvlid.IsValid = false;
                }
            }
            else
            {
                cvlid.ErrorMessage = "没有选中购物记录";
                cvlid.IsValid = false;
            }
        }
        else
        {
            cvlid.ErrorMessage = "没有选中购物记录";
            cvlid.IsValid = false;
        }
    }

    protected void btn_continu_ServerClick(object sender, EventArgs e)
    {
        string nextUrl= WebUtility.GetBackUrl(Request, Response);
        if (string.IsNullOrEmpty(nextUrl)==false)
        {
            string[] strs = nextUrl.Split('/');
            Response.Redirect(strs[strs.Length - 1]);
        }
        else
        {
            Response.Redirect("ListLine.aspx");
        }
    }
   
    protected void gv_list_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTemp = (Label)e.Row.Cells[6].FindControl("Label6");
            if (lblTemp.Text == "缺货")
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chkTemp = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Row.Cells[0].FindControl("Checkbox2");
                chkTemp.Disabled = true;
            }
        }
    }
}
