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

public partial class SingleHeader : System.Web.UI.Page
{
    #region 自定义内容

    WConfigBLL bllConfig = new WConfigBLL();
    ProductBLL bll = new ProductBLL();
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

    private void BindLink(int prhId)
    {
        Res.Model.NodeObj hNode = bllConfig.GetHeaderNameById(prhId);
        Res.Model.NodeObj cNode = bllConfig.GetCategoryNameById(hNode.ID);
        string lineName = bllConfig.GetLineNameById(cNode.ID);
        ltrLineName.Text = GetSpliteString(0, lineName);
        ltrLineName1.Text = GetSpliteString(1, lineName);
        ltrCategoryName.Text = cNode.NAME;
        hlkLineName.NavigateUrl = "ListLine.aspx?prl_name=" + GetSpliteString(0, lineName);
        hlkLineName1.NavigateUrl = "ListCategory.aspx?pct_id=" + cNode.ID;
        hlkCategoryName.NavigateUrl = "ListHeader.aspx?pct_id=" + hNode.ID;
    }
    protected void BindProduct(int prhId)
    {
        string path = ConfigurationManager.AppSettings["WUploadImageFile"];
        using (System.Data.SqlClient.SqlDataReader reader = bll.GetWebSingleProduct(prhId))
        {
            if (reader.Read())
            {
                if (reader.IsDBNull(2) == false)
                    lb_content.Text = reader.GetString(2);
                if (reader.IsDBNull(1) == false)
                    lb_main_name.Text = reader.GetString(1);
                ltrHeaderName.Text = reader.GetString(1);
                if (reader.IsDBNull(4) == false)
                    img_main.ImageUrl = GetFile(reader.GetString(4));
                if (reader.IsDBNull(4) == false)
                    hddImg.Value = GetFile(reader.GetString(4));
            }
        }

        divPrice.Visible = false;
    }

    private void BindLinkProduct(int prhId)
    {
        rptList.DataSource = bll.GetWebLinkProduct(prhId);
        rptList.DataBind();
    }

    protected string GetUrl()
    {
        return Request.Url.ToString();
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 25;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["PRH_ID"]))
            {
                Response.Redirect("error.aspx?type=1");
            }

            string sPrhId = Request.QueryString["PRH_ID"];
            hf_prh_id.Value = sPrhId;
            int prhId = Convert.ToInt32(hf_prh_id.Value.Trim());
            BindLink(prhId);
            BindProduct(prhId);
            BindLinkProduct(prhId);
        }
    }

    protected void rptColor_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        foreach (RepeaterItem item in rptColor.Items)
        {
            ((ImageButton)item.FindControl("IBtn_main_color")).BorderWidth = 1;
        }
        if (e.CommandName == "Color")
        {
            int prhId = Convert.ToInt32(hf_prh_id.Value.Trim());
            string color = e.CommandArgument.ToString();
            hf_main_color.Value = color;
            lblColor.Text = color;
            ImageButton imgBtnTemp = ((ImageButton)e.CommandSource);
            imgBtnTemp.BorderColor = System.Drawing.Color.Red;
            imgBtnTemp.BorderWidth = new Unit(2);
            ddlSize.DataSource = bll.GetProductPesc(prhId, color);
            ddlSize.DataBind();
        }
    }
    protected void ddlSize_DataBound(object sender, EventArgs e)
    {
        ddlSize.Items.Insert(0, new ListItem("--请选择尺寸--", "0"));
    }
    protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (string.Compare(ddlSize.SelectedValue, "0", true) != 0)
        {//PRD_ID,PRD_CODE,PRD_LOCALNAME,PRD_DESC,PRD_PIC3,PRD_PIC4,PRD_SPECDESC,PRD_MARKET_PRICE,PRD_MEMBER_PRICE,XPR_NUM
            lblSize.Text = ddlSize.SelectedItem.Text;
            using (System.Data.SqlClient.SqlDataReader reader = bll.GetWebSingleProduct(System.Convert.ToInt32(hf_prh_id.Value), ddlSize.SelectedValue, hf_main_color.Value))
            {
                if (reader.Read())
                {
                    if (reader.IsDBNull(3) == false)
                        lb_content.Text = reader.GetString(3);
                    if (reader.IsDBNull(2) == false)
                        lb_main_name.Text = reader.GetString(2);
                    if (reader.IsDBNull(4) == false)
                        img_main.ImageUrl = GetFile(reader.GetString(4));
                    if (reader.IsDBNull(5) == false)
                        hddImg.Value = GetFile(reader.GetString(5));
                    if (reader.IsDBNull(1) == false)
                        lb_main_code.Text = reader.GetString(1);
                    if (reader.IsDBNull(6) == false)
                        lb_spec_desc.Text = reader.GetString(6);
                    if (reader.IsDBNull(7) == false)
                        lb_main_market_price.Text = "市场价：" + System.Convert.ToDecimal(reader.GetValue(7)).ToString("C") + ";";
                    if (reader.IsDBNull(8) == false)
                        lb_main_member_price.Text ="ABS价："+ System.Convert.ToDecimal(reader.GetValue(8)).ToString("C");
                    if (reader.IsDBNull(9) == false)
                    {
                        int count = System.Convert.ToInt32(reader.GetValue(9));
                        if (count > 0)
                        {
                            lb_main_repertory.Text = "现有库存";
                        }
                        else
                        {
                            lb_main_repertory.Text = "库存不足";
                        }
                    }
                    else
                    {
                        lb_main_repertory.Text = "库存不足";
                    }

                    divPrice.Style["display"] = "block";
                    divPrice.Visible = true;
                    hf_main_prd_id.Value = reader.GetValue(0).ToString();
                }
            }
        }
        else
        {
            lblSize.Text = "";
        }
    }
    protected void btnBuyNow_ServerClick(object sender, EventArgs e)
    {
        WUserBLL bllUser = new WUserBLL();
        int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
        if (bllUser.IsAuthenticated(Session, "购买商品", timeOut) == false)
        {
            WebUtility.SetBackUrl(Request, Response);
            Response.Redirect("error.aspx?type=2");
        }
        Res.Model.UserObj us = (Res.Model.UserObj)Session["MEB"];
        if (string.IsNullOrEmpty(hf_main_prd_id.Value) == false)
        {
            int prd_id = System.Convert.ToInt32(hf_main_prd_id.Value);
            string value = edt_main_num.Value;
            if (WebUtility.IsInteger(value, true) == true && WebUtility.InputInt(value) > 0)
            {
                WShopBagBLL sbbll = new WShopBagBLL();
                Res.Model.WShopBagObj model = new Res.Model.WShopBagObj();
                model.SPB_PRD_ID = prd_id;
                model.SPB_QTY = WebUtility.InputInt(value);
                model.SPB_STATUS = 0;
                model.SPB_PSP_ID = us.USR_ID;
                model.SPB_CREATIONUID = us.USR_LOGIN;

                sbbll.Add(model);

                Response.Redirect("ShopBagList.aspx");
            }
            else
            {
                cv_main.IsValid = false;
                cv_main.Text = "请输入正确格式";
            }
        }
        else
        {
            cv_main.IsValid = false;
            cv_main.Text = "请选中购买的商品";
        }
    }
    protected void btnAddToCart_ServerClick(object sender, EventArgs e)
    {
        WUserBLL bllUser = new WUserBLL();
        int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
        if (bllUser.IsAuthenticated(Session, "购买商品", timeOut) == false)
        {
            WebUtility.SetBackUrl(Request, Response);
            Response.Redirect("error.aspx?type=2");
        }
        Res.Model.UserObj us = (Res.Model.UserObj)Session["MEB"];
        if (string.IsNullOrEmpty(hf_main_prd_id.Value) == false)
        {
            int prd_id = System.Convert.ToInt32(hf_main_prd_id.Value);
            string value = edt_main_num.Value.Trim();
            if (WebUtility.IsInteger(value, true) == true && WebUtility.InputInt(value) > 0)
            {
                WShopBagBLL sbbll = new WShopBagBLL();
                Res.Model.WShopBagObj model = new Res.Model.WShopBagObj();
                model.SPB_PRD_ID = prd_id;
                model.SPB_QTY = WebUtility.InputInt(value);
                model.SPB_STATUS = 0;
                model.SPB_PSP_ID = us.USR_ID;
                model.SPB_CREATIONUID = us.USR_LOGIN;

                sbbll.Add(model);
            }
            else
            {
                cv_main.IsValid = false;
                cv_main.Text = "请输入正确格式";
            }
        }
        else
        {
            cv_main.IsValid = false;
            cv_main.Text = "请选中购买的商品";
        }
    }
    protected void lnkBtnRecomandToFriend_Click(object sender, EventArgs e)
    {
        string url = img_main.ImageUrl;
        string name = lb_main_name.Text;

        Res.Model.ChildExtObj node = new Res.Model.ChildExtObj();
        node.ID = Convert.ToInt32(Request.QueryString["PRH_ID"]);
        node.NAME = name;
        node.ChildName = url;

        Session["PIC"] = node;
        Response.Redirect("SendMessage.aspx");
    }
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Link")
        {
            int prhId = Convert.ToInt32(e.CommandArgument);
            hf_prh_id.Value = e.CommandArgument.ToString();
            BindLink(prhId);
            BindProduct(prhId);
            BindLinkProduct(prhId);
            ddlSize.Items.Clear();
            ddlSize.DataBind();
        }
    }
}
