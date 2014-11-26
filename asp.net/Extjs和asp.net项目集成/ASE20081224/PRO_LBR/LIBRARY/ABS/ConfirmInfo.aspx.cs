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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Res.BLL;
using Res.Model;

public partial class ConfirmInfo : System.Web.UI.Page
{
    OrderBLL bllOrder = new OrderBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 11;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID); 
        if (!IsPostBack)
        {
            divAddress.Style.Add("display", "none");

            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "确认订单信息", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            UserObj us = (UserObj)Session["MEB"];
            hddPspId.Value = us.USR_ID.ToString();

            if (Session["SPB"] == null)
            {
                Response.Redirect("error.aspx?type=1");
            }

            
            ltrMobile.Text = ((Res.Model.UserObj)Session["MEB"]).USR_LOGIN; 

            dlAddress.DataSourceID = "sqlDsAddress";
            dlAddress.DataBind();
        }
    }
    protected void ddl_city_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_province_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_city_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    protected void btnAddAddress_Click(object sender, EventArgs e)
    {
        BindUserInfo(Convert.ToInt32(hddPspId.Value.Trim()));
        divAddress.Style.Add("display", "blank");
    }
    protected void btnAddAdr_Click(object sender, EventArgs e)
    {
        string regZip = @"\d{6}";
        if (txtName.Text.Trim().Length <= 0)
        {
            lblName.Visible = true;
            return;
        }
        else
        {
            lblName.Visible = false;
        }

        if (txtZip.Text.Trim().Length !=6 || Regex.IsMatch(txtZip.Text.Trim(),regZip)==false)
        {
           
            lblZip.Visible = true;
            return;
        }
        else
        {
            lblZip.Visible = false;
        }

        if (txtAddress.Value.Trim().Length <= 0)
        {
            lblAddress.Visible = true;
            return;
        }
        else
        {
            lblAddress.Visible = false;
        }

        
        OrderAddressObj model = new OrderAddressObj();
        model.ORA_ADDRESS = txtAddress.Value.Trim();
        model.ORA_CREATIONUID = ((UserObj)Session["MEB"]).USR_LOGIN;
        model.ORA_CTY_ID = Convert.ToInt32(ddl_city.SelectedValue);
        model.ORA_NAME = txtName.Text.Trim();
        model.ORA_PHONE = txtTel.Text.Trim();
        model.ORA_PSP_ID = Convert.ToInt32(hddPspId.Value.Trim());
        model.ORA_UPDATEUID = ((UserObj)Session["MEB"]).USR_LOGIN;
        model.ORA_ZIP = txtZip.Text.Trim();
        int oraId = 0;
        if (bllOrder.AddOrderAddress(model, out oraId) > 0)
        {
            ViewState["CTY_ID"] = ddl_city.SelectedValue;
            ViewState["ADDRESS_ID"] = oraId.ToString();
            divAddress.Style.Add("display", "none");

            dlAddress.DataSourceID = "sqlDsAddress";
            dlAddress.DataBind();
            UpdatePanel3.Update();
        }
    }
    protected void btnCancelAdr_Click(object sender, EventArgs e)
    {
        divAddress.Style.Add("display", "none");
    }

    protected void btnCreateCode_Click(object sender, EventArgs e)
    {
        //if (string.Compare(ddl_free.SelectedItem.Text, "--请选择--", false) == 0)
        //{
        //    string script = "<script type='text/javascript'>alert('请选择优惠信息！');window.location.href='ConfirmInfo.aspx';</script>";
        //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
        //    return;
        //}
        if (ViewState["ADDRESS_ID"]==null)
        {
            string script = "<script type='text/javascript'>alert('请选择或添加地址信息！');window.location.href='ConfirmInfo.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            return;
        }
        if (string.Compare(txtCode.Value.Trim(), Session["CheckCode"].ToString(), true) != 0)
        {
            string script = "<script type='text/javascript'>alert('验证码错误！');window.location.href='ConfirmInfo.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script, false);
            return;
        }

        WShopBagBLL bllShopBag = new WShopBagBLL();
        List<int> lstId = (List<int>)Session["SPB"];
        if (lstId.Count <= 0)
        {
            string script = "<script type='text/javascript'>alert('操作出错！');window.location.href='ConfirmInfo.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
            return;
        }

        string strIds = "";
        for (int i = 0; i < lstId.Count; i++)
        {
            strIds += lstId[i];
            if (i < lstId.Count - 1)
            {
                strIds += ",";
            }
        }

        UserObj objUser = (UserObj)Session["MEB"];

        PurchaseObj purNode = new PurchaseObj();
        List<LprdpurObj> lstPrdPur = new List<LprdpurObj>();

        Decimal totalAmount = 0;
   
        List<NodeIntObj> lstCount = new List<NodeIntObj>();//用于计算运费

        using (System.Data.SqlClient.SqlDataReader reader = bllShopBag.GetConfirmList(Convert.ToInt32(hddPspId.Value), strIds))
        {
            while (reader.Read())
            {
                LprdpurObj node = new LprdpurObj();
                if (reader.IsDBNull(4))
                    node.LPK_AMOUNT = 0;
                else
                    node.LPK_AMOUNT = Convert.ToDecimal(reader["AMOUNT"]);
                node.LPK_CREATION_DT = DateTime.Now;
                node.LPK_CREATIONUID = objUser.USR_LOGIN;//--
                node.LPK_CUR_ID = int.MinValue;//[支付货币形式 暂时不用]
                node.LPK_INVSTATUS = 1;//
                if (reader.IsDBNull(2))
                    node.LPK_PRD_ID = 0;
                else
                    node.LPK_PRD_ID = Convert.ToInt32(reader["SPB_PRD_ID"]);
                node.LPK_PUR_ID = int.MinValue;
                node.LPK_PURSTATUS = 0;//
                if (reader.IsDBNull(3))
                    node.LPK_QTY = 0;
                else
                    node.LPK_QTY = Convert.ToInt32(reader["SPB_QTY"]);

                node.LPK_REFAMOUNT = decimal.MinValue;

                node.LPK_STATUS = 1;//
                node.LPK_UPDATE_DT = DateTime.Now;
                node.LPK_UPDATEUID = objUser.USR_LOGIN;//--

                lstPrdPur.Add(node);

                if (reader.IsDBNull(4))
                    totalAmount += 0;
                else
                    totalAmount += Convert.ToDecimal(reader["AMOUNT"]);

                //以下用于计算用费
                NodeIntObj nodeCount = new NodeIntObj();
                nodeCount.ID = Convert.ToInt32(reader["SPB_PRD_ID"]);
                nodeCount.NAME = Convert.ToInt32(reader["SPB_QTY"]);
                lstCount.Add(nodeCount);
            }
        }

        OrderBLL bllOrder = new OrderBLL();

        //优惠
        decimal discount = bllOrder.GetDiscountAmountById(Convert.ToInt32(ddl_free.SelectedValue));
        totalAmount -= discount;
        if (totalAmount <= 0)
        {
            Response.Redirect("error.aspx?type=3");
        }

        purNode.PUR_AMOUNT = totalAmount;
        purNode.PUR_CNT_ID = int.MinValue;
        purNode.PUR_CODE = bllOrder.CreateOrderCode(0,8);
        purNode.PUR_CONFIRM_DT = DateTime.MinValue;
        purNode.PUR_CPG_ID = int.MinValue;
        purNode.PUR_CREATION_DT = DateTime.Now;
        purNode.PUR_CREATIONUID = objUser.USR_LOGIN;//--
        purNode.PUR_CUR_ID = 0;
        purNode.PUR_DT = DateTime.Now;
        purNode.PUR_OUT_DT = DateTime.MinValue;
        purNode.PUR_PAY_ID = Convert.ToInt32(RadioButtonList1.SelectedValue);
        purNode.PUR_PSP_ID = Convert.ToInt32(hddPspId.Value);
        purNode.PUR_PTY_ID = 8;//1为"网站客户自建为8"
        purNode.PUR_PUS_ID = 1;//1为"未确定"

        int ctyId=Convert.ToInt32(ViewState["CTY_ID"]);
        purNode.PUR_EXPAMOUNT = Res.Library.Freight.CalculateAmount(ctyId, lstCount, totalAmount);//运费

        purNode.PUR_SLM_ID = int.MinValue;
        purNode.PUR_UPDATE_DT = DateTime.Now;
        purNode.PUR_UPDATEUID = objUser.USR_LOGIN;//--
        purNode.XPU_NEXT_ADDRESS = "";
        purNode.XPU_NEXT_DT = DateTime.MinValue;
        purNode.XPU_NEXT_ORA_ID = int.MinValue;

        purNode.XPU_ORA_ID = Convert.ToInt32(ViewState["ADDRESS_ID"]);

        int purId;

        if (bllOrder.AddOrder(purNode, lstPrdPur, out purId) > 0)
        {
            bllShopBag.ConfirmShopBag(objUser.USR_LOGIN, strIds);

            bllOrder.AddOrderDiscount(purId, Convert.ToInt32(ddl_free.SelectedValue), objUser.USR_LOGIN);//添加优惠

            string script = "<script type='text/javascript'>alert('生成订单成功！');window.location.href='Order.aspx?PUR_ID=" + purId + "';</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
        }
        else
        {
            string script = "<script type='text/javascript'>alert('生成订单失败！');window.location.href='ConfirmInfo.aspx';</script>";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
        }
    }
    protected void ddl_free_DataBound(object sender, EventArgs e)
    {
        ddl_free.Items.Insert(0, new ListItem("--请选择--", "0"));
    }

    protected void dlAddress_ItemCommand(object source, DataListCommandEventArgs e)
    {
        foreach (DataListItem item in dlAddress.Items)
        {
            ((Button)item.FindControl("btnSel")).Style.Add("color", "black");
        }
        if (e.CommandName == "Select")
        {
            ((Button)e.Item.FindControl("btnSel")).Style.Add("color", "red");
            ViewState["CTY_ID"] = ((HiddenField)e.Item.FindControl("hddCtyId")).Value;
            ViewState["ADDRESS_ID"] = e.CommandArgument.ToString();
        }
    }

    /// <summary>
    /// 绑定用户信息
    /// </summary>
    /// <param name="pspId"></param>
    private void BindUserInfo(int pspId)
    {
        WUserBLL bllUser = new WUserBLL();
        using (System.Data.SqlClient.SqlDataReader reader = bllUser.GetWUserById(pspId))
        {
            if (reader.Read())
            {
                txtAddress.Value = reader["PSP_ADDRESS"].ToString();
                txtName.Text = reader["PSP_NAME"].ToString();
                txtZip.Text = reader["PSP_ZIP"].ToString();
                txtTel.Text = reader["PSP_TEL"].ToString();
                ddl_province.SelectedValue = reader["PRV_ID"].ToString();
                ddl_province.DataBind();
                ddl_city.SelectedValue = reader["PSP_CTY_ID"].ToString();
            }
            else
            {
                string script = "<script type='text/javascript'>alert('操作错误！');window.location.href='ConfirmInfo.aspx';</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", script);
                return;
            }
        }
    }
}
