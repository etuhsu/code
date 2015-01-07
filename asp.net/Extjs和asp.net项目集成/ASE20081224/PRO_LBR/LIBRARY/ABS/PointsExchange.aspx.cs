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
using Res.Model;
using Res.BLL;
using Res.DBUtility;
using System.Data.SqlClient;

public partial class PointsExchange : System.Web.UI.Page
{
    #region 自定义内容
    Res.BLL.CustomerBLL bll = new Res.BLL.CustomerBLL();
    private void BindFPROSPECT(int pspId)
    {
        using (SqlDataReader reader = bll.GetIntegralByPspId(pspId))
        {
            if (reader.Read())
            {
                if (reader["FPP_TOTALPOINTS"] != DBNull.Value)
                    ltrTotalPoint.Text = reader["FPP_TOTALPOINTS"].ToString();
                else
                    ltrTotalPoint.Text = "0";

                if (reader["FPP_AVAILABLEPOINTS"] != DBNull.Value)
                    ltrAvailablePoint.Text = reader["FPP_AVAILABLEPOINTS"].ToString();
                else
                    ltrAvailablePoint.Text = "0";

                if (reader["FPP_REDEEMPOINTS"] != DBNull.Value)
                    ltrRedeemPoint.Text = reader["FPP_REDEEMPOINTS"].ToString();
                else
                    ltrRedeemPoint.Text = "0";
            }
        }
    }
    protected string FormatDate(object obj)
    {
        return Convert.ToDateTime(obj).ToString("yyyy年MM月dd日");
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        //int PageID = ;
        //Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
        if (!IsPostBack)
        {
            WUserBLL bllUser = new WUserBLL();
            int timeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
            if (bllUser.IsAuthenticated(Session, "积分兑换", timeOut) == false)
            {
                WebUtility.SetBackUrl(Request, Response);
                Response.Redirect("error.aspx?type=2");
            }
            UserObj us = (UserObj)Session["MEB"];
            hddPspId.Value = us.USR_ID.ToString();

            BindFPROSPECT(us.USR_ID);

        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        UserObj us = (UserObj)Session["MEB"];
        lblMessage.Text = "";
        int count;//数量
        if (int.TryParse(txtNum.Value.Trim(), out count) == false)
        {
            lblMessage.Text = "<span style='color:red;'>请输入数字！</span>";
            return;
        }
        int availablePoint = Convert.ToInt32(ltrAvailablePoint.Text.Trim());//有效积分
        int redeemPoint = Convert.ToInt32(ltrRedeemPoint.Text.Trim());//兑换积分

        PointBLL bllPoint = new PointBLL();
        int gifId = Convert.ToInt32(ddlPoitProduct.SelectedValue);//赠品编号
        int prdPoint=0;//赠品所需积分
        int prdId=0;//赠品对应产品编号
        int evtId=0;//对应专案编号
        using (SqlDataReader reader = bllPoint.GetPointById(gifId))
        {
            if (reader.Read())
            {
                if (reader["GIF_POINT"] != DBNull.Value)
                    prdPoint = Convert.ToInt32(reader["GIF_POINT"]);
                else
                    prdPoint = 0;
                if (reader["GIF_PRD_ID"] != DBNull.Value)
                    prdId = Convert.ToInt32(reader["GIF_PRD_ID"]);
                else
                    prdId = 0;
                if (reader["GIF_EVT_ID"] != DBNull.Value)
                    evtId = Convert.ToInt32(reader["GIF_EVT_ID"]);
                else
                    evtId = 0;
            }
        }
        if (prdPoint * count > availablePoint)
        {
            lblMessage.Text = "<span style='color:red;'>对不起,你的积分余额不足！</span>";
            return;
        }
        /****************生成订单*****************/
        OrderBLL bllOrder = new OrderBLL();
        int pspId = Convert.ToInt32(hddPspId.Value.Trim());
        string purCode = bllOrder.CreateOrderCode(pspId, 9);//积分兑换订单编码

        PurchaseObj purModel = new PurchaseObj();
        purModel.PUR_AMOUNT = 0;
        purModel.PUR_CNT_ID = int.MinValue;
        purModel.PUR_CODE = purCode;
        purModel.PUR_CONFIRM_DT = DateTime.MinValue;
        purModel.PUR_CPG_ID = int.MinValue;
        purModel.PUR_CREATION_DT = DateTime.Now;
        purModel.PUR_CREATIONUID = us.USR_LOGIN;
        purModel.PUR_CUR_ID = 0;
        purModel.PUR_DT = DateTime.Now;
        purModel.PUR_EXPAMOUNT = 0;// 运费
        purModel.PUR_OUT_DT = DateTime.MinValue;
        purModel.PUR_PAY_ID = 1;//
        purModel.PUR_PSP_ID = pspId;
        purModel.PUR_PTY_ID = 9;//订单类型(9为积分兑换)
        purModel.PUR_PUS_ID = 1;
        purModel.PUR_SLM_ID = int.MinValue;
        purModel.PUR_UPDATE_DT = DateTime.Now;
        purModel.PUR_UPDATEUID = us.USR_LOGIN;
        purModel.XPU_NEXT_ADDRESS = "";
        purModel.XPU_NEXT_DT = DateTime.MinValue;
        purModel.XPU_NEXT_ORA_ID = int.MinValue;
        purModel.XPU_ORA_ID = int.MinValue;

        List<LprdpurObj> lstDetails = new List<LprdpurObj>();
        LprdpurObj lprdModel = new LprdpurObj();
        lprdModel.LPK_AMOUNT = 0;
        lprdModel.LPK_CREATION_DT = DateTime.Now;
        lprdModel.LPK_CREATIONUID = us.USR_LOGIN;
        lprdModel.LPK_CUR_ID = int.MinValue;//[支付货币形式 暂时不用]
        lprdModel.LPK_INVSTATUS = 1;//订单状态
        lprdModel.LPK_PRD_ID = prdId;
        lprdModel.LPK_PUR_ID = int.MinValue;
        lprdModel.LPK_PURSTATUS = 1;//订单状态
        lprdModel.LPK_QTY = count;
        lprdModel.LPK_REFAMOUNT = decimal.MinValue;
        lprdModel.LPK_STATUS = 1;
        lprdModel.LPK_UPDATE_DT = DateTime.Now;
        lprdModel.LPK_UPDATEUID = us.USR_LOGIN;
        lstDetails.Add(lprdModel);


        /****************运用事务添加订单,添加积分记录并修改积分相关信息******************/

        int purId;
        int hptId;
        int result = 0;
        using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionString))
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                result = bllOrder.AddMaster(trans,purModel, out purId);//添加订单主表
                if (result <= 0)
                    trans.Rollback();
                result = bllOrder.AddDetail(trans,lstDetails, purId, us.USR_LOGIN);//添加订单子表
                if (result <= 0)
                    trans.Rollback();
                result = bllPoint.UpdatePoint(trans, pspId, prdPoint * count);//修改个人积分
                if (result <= 0)
                    trans.Rollback();

                HPointObj hpointModel = new HPointObj();
                hpointModel.HPT_CREATIONUID = us.USR_LOGIN;
                hpointModel.HPT_DT = DateTime.Now;
                hpointModel.HPT_EVT_ID = evtId;//对应专案
                hpointModel.HPT_PNT_ID = 3;//积分操作类型(3为积分兑换)
                hpointModel.HPT_POINT_NUM = prdPoint * count;//相应积分
                hpointModel.HPT_POINTEND_DT = DateTime.MinValue;
                hpointModel.HPT_PSP_ID = pspId;
                hpointModel.HPT_PUR_ID = purId;
                hpointModel.HPT_UPDATE_DT = DateTime.Now;
                hpointModel.HPT_UPDATEUID = us.USR_LOGIN;

                result = bllPoint.AddHPoint(trans, hpointModel, out hptId);//添加积分记录信息
                if (result <= 0)
                    trans.Rollback();
                trans.Commit();

            }
            catch (SqlException ex)
            {
                result = 0;
                trans.Rollback();
            }
        }

        if (result > 0)
        {
            txtNum.Value = "";
            lblMessage.Text = "<span style='color:red;'>积分兑换成功！</span>";
            return;
        }



        //if (bllOrder.AddOrder(purModel, lstDetails, out purId))
        //{
        //    bllPoint.UpdatePoint(pspId, prdPoint * count);//修改个人积分
        //    /******添加积分记录******/
        //    HPointObj hpointModel=new HPointObj ();
        //    hpointModel.HPT_CREATIONUID=us.USR_LOGIN;
        //    hpointModel.HPT_DT=DateTime.Now;
        //    hpointModel.HPT_EVT_ID=evtId;//对应专案
        //    hpointModel.HPT_PNT_ID = 3;//积分操作类型(3为积分兑换)
        //    hpointModel.HPT_POINT_NUM = prdPoint * count;//相应积分
        //    hpointModel.HPT_POINTEND_DT = DBNull.Value;
        //    hpointModel.HPT_PSP_ID = pspId;
        //    hpointModel.HPT_PUR_ID = purId;
        //    hpointModel.HPT_UPDATE_DT = DateTime.Now;
        //    hpointModel.HPT_UPDATEUID = us.USR_LOGIN;
        //    int hptId;
        //    bllPoint.AddHPoint(hpointModel, out hptId);
        //}

    }
}
