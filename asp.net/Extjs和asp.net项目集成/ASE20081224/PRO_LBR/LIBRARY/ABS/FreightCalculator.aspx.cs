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

public partial class FreightCalculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int PageID = 15;
        Page.Master.Page.Title = WebUtility.GetPageHeader(PageID);
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        int ctyId = Convert.ToInt32(ddlCity.SelectedValue);

        decimal amount;
        decimal weight;
        if (decimal.TryParse(txtAmount.Text.Trim(),out amount) == false || decimal.TryParse(txtWeight.Text.Trim(),out weight) == false)
        {
            lblMessage.Text = "<span style='color:red;'>请输入数字！</span>";
            return;
        }

        lblMessage.Text = "重量为 " + weight + "kg 且总值为 " + amount + " 元的商品运费计算结果为： " + Res.Library.Freight.CalculateAmountByWeight(ctyId, weight, amount) + " 元";
    }
}
